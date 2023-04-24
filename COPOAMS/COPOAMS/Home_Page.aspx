<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home_Page.aspx.cs" Inherits="COPOAMS.Home_page" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>HOME PAGE</title>
    <link href="CSS/HomePage.css" rel="stylesheet" type="text/css" />
    
</head>
<body>
    <form id="form1" runat="server">
    <asp:Menu ID="Menu1" runat="server" Orientation="Horizontal"></asp:Menu>
        <div class="row">
            <div class="column1">
                <asp:Image ID="Image1" runat="server" Height="688px" ImageUrl="~/Images/bmsit.jpg" Width="100%" />
            </div>
            <div class="column2">
                <asp:Image ID="Image2" runat="server" Height="128px" ImageUrl="~/Images/bmslogo.png" Width="100%" />
                <br />
                <br />
                <br />
                <center><asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="ADD NEW STUDENT" Height="30px" Width="320px" /></center>
                <br />
                <center><asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="ADD NEW SUBJECT" Height="30px" Width="320px" /></center>
                <br />
                <center><asp:Button ID="Button3" runat="server" onclick="Button3_Click" Text="ADD IA CO's" Height="30px" Width="320px" /></center>
                <br />
                <center><asp:Button ID="Button4" runat="server" onclick="Button4_Click" Text="ADD IA MARKS" Height="30px" Width="320px" /></center>
                <br />
                <center><asp:Button ID="Button5" runat="server" onclick="Button5_Click" Text="CALCULATE CO VALUES" Height="30px" Width="320px" /></center>
                <br />
                <center><asp:Button ID="Button6" runat="server" onclick="Button6_Click" Text="ADD EXTERNAL MARKS" Height="30px" Width="320px" /></center>
                <br />
                <center><asp:Button ID="Button7" runat="server" onclick="Button7_Click" Text="EXTERNAL EXAM RESULT" Height="30px" Width="320px" /></center>
                <br />
                <center><asp:Button ID="Button8" runat="server" onclick="Button8_Click" Text="CO ATTAINMENT" Height="30px" Width="320px" /></center>
                <br />
                <center><asp:Button ID="Button9" runat="server" onclick="Button9_Click" Text="ADD PO DETAILS" Height="30px" Width="320px" /></center>
                <br />
                <center><asp:Button ID="Button10" runat="server" onclick="Button10_Click" Text="PO RESULT" Height="30px" Width="320px" /></center>
                <br />
                <center><asp:Button ID="Button11" runat="server" onclick="Button11_Click" Text="FINAL PO RESULT" Height="30px" Width="320px" /></center>
            </div>
        </div>
    </form>
</body>
</html>
