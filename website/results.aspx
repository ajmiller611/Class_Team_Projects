﻿<!DOCTYPE html>
<html>

<head>
	<title>Results</title>
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
	
	<h1>Room Results</h1>
	<form runat="server">
	<asp:RadioButtonList id="radiolist1" runat="server">
		<asp:ListItem selected="true">Item 1</asp:ListItem>
		<asp:ListItem>Item 2</asp:ListItem>
		<asp:ListItem>Item 3</asp:ListItem>
		<asp:ListItem>Item 4</asp:ListItem>
	</asp:RadioButtonList>
	<br>
	<asp:Button text="Book My Room" OnClick="submit" runat="server"/>
	</form>
	
	
	
</body>

</html>