<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="HotelWebApp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <table>
            <tr>
                <td><img src="Content/logo.jpg" width="100px" height="100px" /></td>
                <td><h1 style="padding-left:20px">Welcome to Hotel California</h1>
                    <p style="padding-left:25px">Enjoy your stay at our lovely and luxorious hotel. Our home, is your home.</p>
                </td>
            </tr>
        </table>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Outdoor Pool</h2>
            <img src="Content/HotelAtNight.jpg" alt="Image of Hotel at Night" style="width:100%; height:100%" />
        </div>
        <div class="col-md-4">
            <h2>Our Front Entrance</h2>
            <img src="Content/FrontEntrance.jpg" alt="Image for Front Entrance" style="width:100%; height:100%" />
        </div>
        <div class="col-md-4">
            <h2>Boardwalk Entertainment</h2>
            <img src="Content/Entertainment.jpg" alt="Image of Entertainment" style="width:100%; height:100%" />
        </div>
    </div>

</asp:Content>
