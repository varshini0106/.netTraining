<%@ Page Title="Admin Home" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="AdminHome.aspx.cs" Inherits="ElectricityBillingSystem.AdminHome" %>
<asp:Content ID="c1" ContentPlaceHolderID="MainContent" runat="server">
  <h2>Electricity Billing System</h2>

  <div class="btnrow">
    <asp:Button ID="btnShowAdd" runat="server" Text="Add Bills" CssClass="aspNetButton" OnClick="btnShowAdd_Click" />
    <asp:Button ID="btnShowRetrieve" runat="server" Text="Retrieve Bills" CssClass="aspNetButton" OnClick="btnShowRetrieve_Click" />
  </div>

  <!-- Add Bills Panel -->
  <asp:Panel ID="pnlAdd" runat="server">
      <br />
    <h3>Add Electricity Bill</h3>
    

    <label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Consumer Number : &nbsp; </label>
    <asp:TextBox ID="txtConsumerNumber" runat="server" CssClass="input" />
      <br /><br />
    <label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Consumer Name : &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </label>
    <asp:TextBox ID="txtConsumerName" runat="server" CssClass="input" />
      <br /><br />
    <label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Units Consumed : &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </label>
    <asp:TextBox ID="txtUnitsConsumed" runat="server" CssClass="input" />

    <div class="btnrow">
      <asp:Button ID="btnGenerate" runat="server" Text="Generate & Save Bill" CssClass="aspNetButton" OnClick="btnGenerate_Click" />
    </div>
    <div class="msgrow">
      <asp:Label ID="lblAddErr" runat="server" CssClass="err"></asp:Label>
      <asp:Label ID="lblAddOut" runat="server" CssClass="out"></asp:Label>
    </div>
  </asp:Panel>

  <!-- Retrieve Bills Panel -->
  <asp:Panel ID="pnlRetrieve" runat="server" Visible="false">
      <br />
    <h3>Retrieve Last N Bills</h3>
    

    <label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Enter N : &nbsp; </label>
    <asp:TextBox ID="txtN" runat="server" CssClass="input" />
    <div class="btnrow">
      <asp:Button ID="btnRetrieve" runat="server" Text="Retrieve" CssClass="aspNetButton" OnClick="btnRetrieve_Click" />
    </div>
    <div class="msgrow">
        <asp:Label ID="lblRetErr" runat="server" CssClass="err"></asp:Label>
    </div>

    <div class="gridwrap">
      <asp:GridView ID="gvBills" runat="server" AutoGenerateColumns="false" GridLines="None">
        <Columns>
          <asp:BoundField DataField="ConsumerNumber" HeaderText="Consumer Number" />
          <asp:BoundField DataField="ConsumerName" HeaderText="Consumer Name" />
          <asp:BoundField DataField="UnitsConsumed" HeaderText="Units Consumed" />
          <asp:BoundField DataField="BillAmount" HeaderText="Bill Amount" DataFormatString="{0:N2}" />
        </Columns>
      </asp:GridView>
    </div>
  </asp:Panel>
</asp:Content>