<script runat="server">
Sub submit(Source As Object, e As EventArgs)
       
End Sub

Sub clear(Source As Object, e As EventArgs)

End Sub
</script>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">

<head>
    <meta charset="utf-8" />
    <title>Reservation</title>
    <link rel="stylesheet" type="text/css" href="css/style.css" />
</head>

<body>
    <h1>Hotel</h1>
    <header class="menuBar">
        <nav>
            <ul>
                <li><a href="index.aspx">Home</a></li>
                <li class="active"><a href="reservation.aspx">Reservation</a></li>
                <li><a href="contact_us.aspx">Contact Us</a></li>
            </ul>
        </nav>
    </header>

    <br>
    <h1>Book A Room</h1>

    <div class="reservationbox">
        <form runat="server">
        <div class="reservationStartCal">
            <label>Start Date:</label>
            <asp:calendar runat="server" />
        </div>
        <div class="reservationEndCal">
            <label>End Date:</label>
            <asp:calendar runat="server" />
        </div>

            <label>Number of Beds:</label>
            <asp:DropDownList ID="beds" runat="server">
                <asp:ListItem Selected="True">1 Queen Bed</asp:ListItem>
                <asp:ListItem>2 Queen Beds</asp:ListItem>
                <asp:ListItem>1 King Bed</asp:ListItem>
                <asp:ListItem>2 King Beds</asp:ListItem>
            </asp:DropDownList><br/>
            <br/>
            <asp:CheckBox ID="nonsmoking" Text="Nonsmoking:" TextAlign="Right" runat="server" /><br/>
            <br/>
            <asp:CheckBox ID="oceanfront" Text="Oceanfront:" TextAlign="Right" runat="server" /><br/>
            <br/>
            <asp:Button OnClick="submit" Text="Submit"  runat="server" />
	        <asp:Button OnClick="clear" Text="Clear" runat="server" />
        </form>
    </div>



</body>

</html>