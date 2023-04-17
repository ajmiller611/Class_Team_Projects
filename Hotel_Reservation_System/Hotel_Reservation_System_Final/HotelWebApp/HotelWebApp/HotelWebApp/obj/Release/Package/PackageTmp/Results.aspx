<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Results.aspx.cs" Inherits="HotelWebApp.Results" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>
    <div class ="form-horizontal">
        <h4>Room Results</h4>
        <hr />
        <asp:CustomValidator ID="NonemptyListValidation" runat="server" CssClass="text-danger" ErrorMessage="No rooms available. Please go back and change your search criteria."></asp:CustomValidator>
        <div class="form-group">
                <asp:RadioButtonList ID="RoomResults" runat="server"></asp:RadioButtonList>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="RoomResults" CssClass="text-danger" ErrorMessage="Please select a room." />
        </div>
        <div class="form-group">  
            <div class="col-md-offset-2 col-md-10"> 
                <asp:Button ID="Submit" PostBackUrl="~/Payment.aspx" Text="Book My Room"  runat="server" />
            </div>
        </div>
    </div>
</asp:Content>
