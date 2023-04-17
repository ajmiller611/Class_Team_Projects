<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Confirmation.aspx.cs" Inherits="HotelWebApp.Confirmation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
        <h4>Thank you!</h4>
        <hr />
        
        <h1>Confirmation</h1>
        <p id="confirm" runat="server"></p>

        <p>Thank you for choosing to stay at Hotel California.</p>
</asp:Content>
