<%@ Page Title="Login" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ElectricityBillingSystem.Login" %>
<asp:Content ID="c1" ContentPlaceHolderID="MainContent" runat="server">
  <h2>Admin Login</h2>
  <div>
    <label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Username : &nbsp; </label>
    <asp:TextBox ID="txtUser" runat="server" CssClass="input" />
      <br />
    <label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Password : &nbsp;&nbsp; </label>
    <asp:TextBox ID="txtPass" runat="server" TextMode="Password" CssClass="input" />
    <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="aspNetLoginButton" OnClick="btnLogin_Click" />
  </div>
    
<div class="msgrow">
    <asp:Label ID="lblMsg" runat="server" CssClass="err" />
</div>

</asp:Content>
