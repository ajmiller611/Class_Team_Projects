<%@ Imports System.Data
    Imports System.Data.SqlClient %>
<script runat="server">
    Sub Page_Load()
        If Not Page.IsPostBack Then
            Dim sqlConn As New SqlConnection(server=.\SQLEXPRESS;uid=testU;pwd=******;database=test)
            sqlConn.Open()
        End If
        
    End Sub
    
    Sub submit(sender As Object, e As EventArgs)
        Dim sqlComm As New SqlCommand("SELECT Username FROM Account", sqlConn)
    End Sub

    Sub clear(sender As Object, e As EventArgs)
        
    End Sub


</script>
<!DOCTYPE html>
<html>

<head>
	<title>Create an Account</title>
	<meta charset="utf-8" />
	<link rel="stylesheet" href="css/style.css" type="text/css" />
</head>

<body>
	<h1>Hotel</h1>
		<header  class = "menuBar">				
		<nav>
			<ul>
			<li><a href="index.aspx">Home</a></li>
			<li><a href="reservation.aspx">Reservation</a></li>
			<li><a href="contact_us.aspx">Contact Us</a></li>
			</ul>
		</nav>
	</header>
	
	<h1>Create an Account</h1>
	<h2>Sign up for an account here!</h2>
	

    <asp:SqlDataSource 
  ID="SqlDataSource1"
  runat="server" 
  ConnectionString="<%$ ConnectionStrings:server=.\SQLEXPRESS;uid=testU;pwd=******;database=test %>"
  SelectCommand="SELECT Username FROM Account"   />


    <form runat="server">
    <label>Username: <asp:TextBox ID="username" runat="server" /></label>
        <asp:RequiredFieldValidator ControlToValidate="username" Display="Dynamic" Text="Required" runat="server"/><br />
    <label>Password: <asp:TextBox ID="password" TextMode="Password" runat="server" /></label>
        <asp:RequiredFieldValidator ControlToValidate="password" Display="Dynamic" Text="Required" runat="server"/><br />
    <label>Confirm Password: <asp:TextBox ID="confirmpass" TextMode="Password" runat="server" /></label>
        <asp:CompareValidator ControlToValidate="confirmpass" ControlToCompare="password" Display="Dynamic" Text="Password does not match." runat="server"/><br />
    <label>First Name: <asp:TextBox ID="firstname" runat="server" /></label>
        <asp:RequiredFieldValidator ControlToValidate="firstname" Display="Dynamic" Text="Required" runat="server"/><br />
	<label>Last Name: <asp:TextBox ID="lastname" runat="server" /></label>
        <asp:RequiredFieldValidator ControlToValidate="lastname" Display="Dynamic" Text="Required" runat="server"/><br />
	<label>Email: <asp:TextBox ID="email" runat="server" /></label>
        <asp:RequiredFieldValidator ControlToValidate="email" Display="Dynamic" Text="Please enter a valid email address" runat="server"/><br />
	<label>Street Address: <asp:TextBox ID="street" runat="server" /></label><br>
    <label>City: <asp:TextBox ID="city" runat="server" /></label><br>
    <label>State: <asp:TextBox ID="state" runat="server" /></label><br>
    <label>Zip: <asp:TextBox ID="zip" runat="server" /></label><br>
	<label>Emergency Contact Name: <asp:TextBox ID="emergencyname" runat="server" /></label><br>
	<label>Emergency Contact Number: <asp:TextBox ID="emergencynumber" runat="server" /></label><br>
	<asp:Button OnClick="submit" Text="Submit"  runat="server" />
	<asp:Button OnClick="clear" Text="Clear" runat="server" />
	</form>
</body>
</html>