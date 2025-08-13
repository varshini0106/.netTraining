create database RailwayDB
use RailwayDB

CREATE TABLE Admins (
    AdminId INT IDENTITY(1,1) PRIMARY KEY,
    Username NVARCHAR(50) NOT NULL,
    Password NVARCHAR(50) NOT NULL
)
 
INSERT INTO Admins (Username, Password)
VALUES ('admin', 'admin123')

CREATE TABLE Customers (
    CustomerId INT IDENTITY(1,1) PRIMARY KEY,
    CustomerName NVARCHAR(100),
    Phone VARCHAR(10),
    Email NVARCHAR(100) UNIQUE,
    Username NVARCHAR(50) UNIQUE,
    Password NVARCHAR(100),
    IsDeleted BIT DEFAULT 0
)

CREATE TABLE Trains (
    TrainNo INT PRIMARY KEY,
    TrainName NVARCHAR(100),
    Source NVARCHAR(100),
    Destination NVARCHAR(100),
    SleeperSeats INT,
    AC2Seats INT,
    AC3Seats INT,
    SleeperFare DECIMAL(10,2),
    AC2Fare DECIMAL(10,2),
    AC3Fare DECIMAL(10,2),
    IsDeleted BIT DEFAULT 0
)

CREATE TABLE Reservations (
    ReservationId INT IDENTITY(1,1) PRIMARY KEY,
    CustomerId INT FOREIGN KEY REFERENCES Customers(CustomerId),
    TrainNo INT FOREIGN KEY REFERENCES Trains(TrainNo),
    TravelDate DATE,
    ClassType NVARCHAR(10),
    Berth NVARCHAR(10),
    NumberOfSeats INT,
    TotalFare DECIMAL(10,2),
    BookingDate DATETIME DEFAULT GETDATE(),
    IsCancelled BIT DEFAULT 0
)

CREATE TABLE Cancellations (
    CancellationId INT IDENTITY(1,1) PRIMARY KEY,
    ReservationId INT,
    CustomerId INT,
    CancellationDate DATETIME,
    SeatsCancelled INT,
    RefundAmount DECIMAL(10,2)
)

INSERT INTO Trains (TrainNo, TrainName, Source, Destination, SleeperSeats, AC2Seats, AC3Seats, SleeperFare, AC2Fare, AC3Fare)
VALUES 
--(12860, 'Gitanjali Express', 'Mumbai', 'Kolkata', 180, 70, 110, 800.00, 1700.00, 1400.00),
(12627, 'Karnataka Express', 'New Delhi', 'Bangalore', 200, 60, 120, 750.00, 1600.00, 1300.00)

INSERT INTO Trains (TrainNo, TrainName, Source, Destination, SleeperSeats, AC2Seats, AC3Seats, SleeperFare, AC2Fare, AC3Fare)
VALUES 
(13487, 'Coastal Express', 'Visakhapatnam', 'Hyderabad', 120, 60, 80, 350.00, 750.00, 600.00),
(13985, 'Godavari Superfast', 'Visakhapatnam', 'Hyderabad', 100, 50, 70, 400.00, 800.00, 650.00),
(10632, 'Eastern Link', 'Kolkata', 'Delhi', 130, 65, 90, 500.00, 1000.00, 850.00),
(19238, 'Southern Star', 'Chennai', 'Bangalore', 110, 55, 75, 300.00, 700.00, 550.00),
(10054, 'Bay View Express', 'Visakhapatnam', 'Chennai', 115, 58, 78, 380.00, 780.00, 620.00),
(15012, 'Deccan Flyer', 'Hyderabad', 'Bangalore', 125, 62, 82, 420.00, 820.00, 670.00),
(10782, 'Krishna Valley Express', 'Vijayawada', 'Hyderabad', 105, 52, 72, 360.00, 760.00, 610.00)

select * from Admins
select * from Customers
select * from Reservations
select * from Cancellations
select * from Trains

--Stored Procedure for Booking Tickets
CREATE OR ALTER PROCEDURE sp_AddReservation
    @CustomerId INT,
    @TrainNo INT,
    @TravelDate DATE,
    @ClassType NVARCHAR(10),
    @Berth NVARCHAR(10),
    @NumberOfSeats INT,
    @TotalFare DECIMAL(10,2)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION;
 
        DECLARE @avail INT;
        IF @ClassType='Sleeper'
            SELECT @avail = SleeperSeats FROM Trains WHERE TrainNo=@TrainNo;
        ELSE IF @ClassType='2AC'
            SELECT @avail = AC2Seats FROM Trains WHERE TrainNo=@TrainNo;
        ELSE
            SELECT @avail = AC3Seats FROM Trains WHERE TrainNo=@TrainNo;
 
        IF @avail < @NumberOfSeats
        BEGIN
            RAISERROR('Not enough seats available',16,1);
            ROLLBACK TRANSACTION;
            RETURN;
        END
 
        -- insert reservation
        INSERT INTO Reservations(CustomerId,TrainNo,TravelDate,ClassType,Berth,NumberOfSeats,TotalFare)
        VALUES(@CustomerId,@TrainNo,@TravelDate,@ClassType,@Berth,@NumberOfSeats,@TotalFare);
 
        DECLARE @newId INT = SCOPE_IDENTITY();
 
        -- reduce seats
        IF @ClassType='Sleeper'
            UPDATE Trains SET SleeperSeats = SleeperSeats - @NumberOfSeats WHERE TrainNo=@TrainNo;
        ELSE IF @ClassType='2AC'
            UPDATE Trains SET AC2Seats = AC2Seats - @NumberOfSeats WHERE TrainNo=@TrainNo;
        ELSE
            UPDATE Trains SET AC3Seats = AC3Seats - @NumberOfSeats WHERE TrainNo=@TrainNo;
 
        COMMIT TRANSACTION;
        SELECT @newId; -- return reservation id
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT>0 ROLLBACK TRANSACTION;
        DECLARE @err NVARCHAR(4000)=ERROR_MESSAGE();
        RAISERROR(@err,16,1);
    END CATCH
END