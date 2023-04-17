<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Reservation.aspx.cs" Inherits="HotelWebApp.Reservation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>
    
    <div class ="form-horizontal">
        <h4>Book A Room</h4>
        <hr />
        <asp:Label runat="server" ID="test"></asp:Label>
        <asp:Label runat="server" ID="test1"></asp:Label>
        <asp:ValidationSummary ID="ValidationSummary" runat="server" CssClass="text-danger" />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="StartDate" CssClass="col-md-2 control-label">Start Date:</asp:Label>
            <div class="col-md-10">
                <asp:Calendar ID="StartDate" runat="server" />
                <asp:CustomValidator ID="StartDateValidation" runat="server" CssClass="text-danger" ErrorMessage="Please select a start date."></asp:CustomValidator>
                <br />
                <asp:CustomValidator ID="StartDateNotBeforeTodayValidation" runat="server" CssClass="text-danger" ErrorMessage="Please select a start date that is today or after."></asp:CustomValidator>
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="EndDate" CssClass="col-md-2 control-label">End Date:</asp:Label>
            <div class="col-md-10">
                <asp:Calendar ID="EndDate" runat="server" />
                <asp:CustomValidator ID="EndDateValidation" runat="server" CssClass="text-danger" ErrorMessage="Please select an end date." />
                <br />
                <asp:CustomValidator ID="EndDateAfterStartDateValidation" runat="server" CssClass="text-danger" ErrorMessage="Please select an end date that is after the start date."  />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Smoking" CssClass="col-md-2 control-label">Smoking:</asp:Label>
            <div class="col-md-10">
                <asp:DropDownList runat="server" ID="Smoking" CssClass="form-control" Width="150">
                    <asp:ListItem Selected="True">Non-Smoking</asp:ListItem>
                    <asp:ListItem>Smoking</asp:ListItem>
                    <asp:ListItem>No Preference</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="OceanView" CssClass="col-md-2 control-label">Ocean View:</asp:Label>
            <div class="col-md-10">
                <asp:DropDownList runat="server" ID="OceanView" CssClass="form-control" Width="150">
                    <asp:ListItem Selected="True">Ocean View</asp:ListItem>
                    <asp:ListItem>No Ocean View</asp:ListItem>
                    <asp:ListItem>No Preference</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button OnClick="Submit_Click" Text="Submit"  runat="server" />
	            <asp:Button OnClick="Clear_Click" Text="Clear" runat="server" />
                <br />
                <asp:CustomValidator ID="UserLoggedInCheck" runat="server" CssClass="text-danger" ErrorMessage="Please log into your account." />
            </div>
        </div>
    </div>
</asp:Content>
