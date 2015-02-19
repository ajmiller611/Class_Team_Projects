<!DOCTYPE html>
<html>

<head>
	<title>Payment</title>
	<meta charset="utf-8" />
	<link rel="stylesheet" type="text/css" href="css/style.css" />
</head>

<body>
	<h1>Hotel</h1>
	<header  class = "menuBar">			
		<nav>
			<ul>
			<li><a href="index.html">Home</a></li>
			<li class="active"><a href="reservation.html">Reservation</a></li>
			<li><a href="contact_us.html">Contact Us</a></li>
			</ul>
		</nav>
	</header>
	
	<h1>Payment & Confirm</h1>
	<form runat="server">
	<asp:RadioButton id="savedcard" Text="Use my saved credit card" runat="server"/>
	<br>
	Credit Card Number:
	<asp:TextBox id="cardnumber" runat="server" />
	<br>
	Expiration Date:
	<asp:TextBox id="expiration" runat="server" />
	<br>
	CVV Number:
	<asp:TextBox id="cvv" runat="server" />
	<br>
	Type:
	<asp:DropDownList id="cardtype" runat="server">
		<asp:ListItem>Visa</asp:ListItem>
		<asp:ListItem>MasterCard</asp:ListItem>
		<asp:ListItem>Discover</asp:ListItem>
	</asp:DropDownList>
	<br>
	<asp:Button text="Book My Room" OnClick="submit" runat="server"/>
	</form>
	
</body>

</html>