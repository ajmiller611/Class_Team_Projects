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
                <li><a href="index.html">Home</a></li>
                <li class="active"><a href="reservation.html">Reservation</a></li>
                <li><a href="contact_us.html">Contact Us</a></li>
            </ul>
        </nav>
    </header>

    <br>
    <h1>Book A Room</h1>

    <div class="reservationbox">
            <label>Start Date:</label>
            <form runat="server">
                <asp:calendar runat="server" />

            <label>End Date:</label>
                <asp:calendar runat="server" />
            </form>

        <form method="post">
            <p>
                <label>Number of Beds:</label>
                <select name="beds">
                    <option selected>1 Queen Bed</option>
                    <option>2 Queen Beds</option>
                    <option>1 King Bed</option>
                    <option>2 King Beds</option>
                </select>
            </p>

            <p>
                <label>Non-smoking:</label>
                <input name="nonsmoking" type="checkbox" value="Non-smoking"/>
            </p>

            <p>
                <label>Oceanfront:</label>
                <input name="oceanfront" type="checkbox" value="Oceanfront"/>
            </p>

            <p>
                <input type="submit" value="Find A Room"/>
            <p>
        </form>
    </div>



</body>

</html>