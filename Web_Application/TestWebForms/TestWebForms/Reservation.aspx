<%@ Page Title="Reservation" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Reservation.aspx.cs" Inherits="TestWebForms.Reservation" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>
    
    <div class ="form-horizontal">
        <h4>Book A Room</h4>
        <hr />
        <asp:Label runat="server" ID="test"></asp:Label>
        <asp:Label runat="server" ID="test1"></asp:Label>
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="StartDate" CssClass="col-md-2 control-label">Start Date:</asp:Label>
            <div class="col-md-10">
                <asp:Calendar ID="StartDate" runat="server" />
                <asp:CustomValidator ID="StartDateValidation" runat="server" CssClass="text-danger" ErrorMessage="Please select a start date."></asp:CustomValidator>
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="EndDate" CssClass="col-md-2 control-label">End Date:</asp:Label>
            <div class="col-md-10">
                <asp:Calendar ID="EndDate" runat="server" />
                <asp:CustomValidator ID="EndDateValidation" runat="server" CssClass="text-danger" ErrorMessage="Please select an end date." />
                <br />
                <asp:CustomValidator ID="EndDateAfterStartDateValidation" runat="server" CssClass="text-danger" ErrorMessage="Please select a date that is after the start date."  />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Smoking" CssClass="col-md-2 control-label">Smoking:</asp:Label>
            <div class="col-md-10">
                <asp:CheckBox ID="Smoking" runat="server" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="OceanView" CssClass="col-md-2 control-label">Ocean View:</asp:Label>
            <div class="col-md-10">
                <asp:CheckBox ID="OceanView" runat="server" />
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button OnClick="Submit_Click" Text="Submit"  runat="server" />
	            <asp:Button OnClick="Clear_Click" Text="Clear" runat="server" />
            </div>
        </div>
    </div>
</asp:Content>
