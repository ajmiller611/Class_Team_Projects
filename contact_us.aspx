<script runat="server">
Sub submit(Source As Object, e As EventArgs)
       
End Sub

Sub clear(Source As Object, e As EventArgs)

End Sub
</script>

<!DOCTYPE html>
<html>
<head>
	<title>Contact Us</title>
	<meta charset="utf-8" />
	<link rel="stylesheet" type="text/css" href="css/style.css" />
</head>

<body>
	<h1>Hotel</h1>
	<header  class = "menuBar">		
		<nav>
			<ul>
			<li><a href="index.aspx">Home</a></li>
			<li><a href="reservation.aspx">Reservation</a></li>
			<li class="active"><a href="contact_us.aspx">Contact Us</a></li>
			</ul>
		</nav>
	</header>
	
	<br>
	<h1>Contact Us</h1>
		
	<form runat="server">
		<label>Question:</label>
		<asp:TextBox ID="question" runat="server" /><br/>
		<br/>
		<label>Comments:<br></label>
		<asp:TextBox ID="comments" TextMode="MultiLine" runat="server" /><br/>
		
		<asp:Button OnClick="submit" Text="Submit" runat="server" />
        <asp:Button OnClick="clear" Text="Clear" runat="server" />
	</form>
	
	
	
</body>
</html>