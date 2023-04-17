<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Payment.aspx.cs" Inherits="HotelWebApp.Payment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>
	<div class= "form-horizontal">
	    <h4>Payment & Confirm</h4>
        <asp:Label ID="total" runat="server"></asp:Label>
	    <div class= "form-group">
	        <asp:Label runat="server" AssociatedControlID="CardNumber" CssClass="col-md-2 control-label">Credit Card Number:</asp:Label>
	        <div class= "col-md-10">
	            <asp:TextBox id="CardNumber" runat="server" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="CardNumber" CssClass="text-danger" ErrorMessage="Please enter a credit card number." />
	        </div>
	    </div>
	    <div class= "form-group">
	        <asp:Label runat="server" AssociatedControlID="Expiration" CssClass="col-md-2 control-label">Expiration Date:</asp:Label>
	        <div class= "col-md-10">
	            <asp:TextBox id="Expiration" runat="server" />
                <asp:CustomValidator ID="ExpirationValidation" runat="server" CssClass="text-danger" ErrorMessage="Expiration date of the card entered has expired."></asp:CustomValidator>
	        </div>
	    </div>
	    <div class= "form-group">
	        <asp:Label runat="server" AssociatedControlID="Cvv" CssClass="col-md-2 control-label">CVV Number:</asp:Label>
	        <div class= "col-md-10">
	            <asp:TextBox id="Cvv" runat="server" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Cvv" CssClass="text-danger" ErrorMessage="Please enter the CVV number." />
	        </div>
	    </div>
	    <div class= "form-group">
	    <asp:Label runat="server" AssociatedControlID="CardType" CssClass="col-md-2 control-label">Card Type:</asp:Label>
	        <div class= "col-md-10">
	            <asp:DropDownList id="CardType" runat="server">
		            <asp:ListItem>Visa</asp:ListItem>
		            <asp:ListItem>MasterCard</asp:ListItem>
		            <asp:ListItem>Discover</asp:ListItem>
	            </asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="CardType" CssClass="text-danger" ErrorMessage="Please select a card type." />
	        </div>
	    </div>
	    <div class= "form-group">
	        <div class="col-md-offset-2 col-md-10">
	            <asp:Button Text="Book My Room" OnClick="Submit_Click" runat="server"/>
                <asp:Button Text="Clear" OnClick="Clear_Click" runat="server" />
	        </div>
	    </div>
	</div>
</asp:Content>
