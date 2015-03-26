<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Results.aspx.cs" Inherits="TestWebForms.Results" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>
    <div class ="form-horizontal">
        <h4>Room Results</h4>
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
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
