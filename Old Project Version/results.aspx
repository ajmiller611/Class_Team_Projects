<script runat="server">
Sub submit(Source As Object, e As EventArgs)
       
End Sub

Sub clear(Source As Object, e As EventArgs)

End Sub
</script>

<!DOCTYPE html>
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
			<li><a href="index.aspx">Home</a></li>
			<li class="active"><a href="reservation.aspx">Reservation</a></li>
			<li><a href="contact_us.aspx">Contact Us</a></li>
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
    <asp:Button OnClick="clear" Text="Clear" runat="server" />
	</form>
	
	
	
</body>

</html>