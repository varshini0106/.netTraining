create database ElectricityBillDB
use ElectricityBillDB

create table ElectricityBill (
    consumer_number varchar(20) primary key not null,
    consumer_name varchar(50) not null,
    units_consumed int not null,
    bill_amount float not null
)

select * from ElectricityBill