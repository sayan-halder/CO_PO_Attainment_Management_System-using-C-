<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add_External_Marks.aspx.cs" Inherits="COPOAMS.Add_External_Marks" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ADD EXTERNAL MARKS</title>
    <link href="CSS/Add_External_Marks.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <br />

        <center><asp:Label ID="Label1" runat="server" Text="ADD EXTERNAL MARKS"></asp:Label></center>
        <br />
        <br />

        <center><asp:Label ID="Label2" runat="server" Text="BATCH:"></asp:Label>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
        <asp:DropDownList ID="batch" runat="server" Width="310px" AutoPostBack="True" onselectedindexchanged="batch_SelectedIndexChanged">
            <asp:ListItem>Select batch</asp:ListItem>
            <asp:ListItem>2020-2022</asp:ListItem>
            <asp:ListItem>2021-2023</asp:ListItem>
            <asp:ListItem>2022-2024</asp:ListItem>
            <asp:ListItem>2023-2025</asp:ListItem>
            <asp:ListItem>2024-2026</asp:ListItem>
            <asp:ListItem>2025-2027</asp:ListItem>
            <asp:ListItem>2026-2028</asp:ListItem>
            <asp:ListItem>2029-2030</asp:ListItem>
        </asp:DropDownList></center>
        <br />
        <br />

        <center><asp:Label ID="Label3" runat="server" Text="SEMESTER:"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="semester" runat="server" Width="310px" AutoPostBack="True" onselectedindexchanged="semester_SelectedIndexChanged">
            <asp:ListItem>Select semester number</asp:ListItem>
            <asp:ListItem>1st</asp:ListItem>
            <asp:ListItem>2nd</asp:ListItem>
            <asp:ListItem>3rd</asp:ListItem>
            <asp:ListItem>4th</asp:ListItem>
            <asp:ListItem>5th</asp:ListItem>
            <asp:ListItem>6th</asp:ListItem>
            <asp:ListItem>7th</asp:ListItem>
            <asp:ListItem>8th</asp:ListItem>
            <asp:ListItem>9th</asp:ListItem>
            <asp:ListItem>10th</asp:ListItem>
        </asp:DropDownList></center>
        <br />
        <br />

        <center><asp:Label ID="Label4" runat="server" Text="SUBJECT CODE:"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="subject_code" runat="server" Width="310px">
            <asp:ListItem>Select subject code</asp:ListItem>
        </asp:DropDownList></center>
        <br />
        <br />

        <center><asp:Label ID="Label5" runat="server" Text="USN:"></asp:Label>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="usn" runat="server" Width="310px">
            <asp:ListItem>Select USN</asp:ListItem>
            <asp:ListItem>1st</asp:ListItem>
            <asp:ListItem>2nd</asp:ListItem>
            <asp:ListItem>3rd</asp:ListItem>
        </asp:DropDownList></center>
        <br />
        <br />

        <center><asp:Label ID="Label6" runat="server" Text="MARKS:"></asp:Label>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="marks" runat="server" Width="302px"></asp:TextBox>
        <br />
        <br />

        <center><asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="SUBMIT" Height="30px" Width="220px" /></center>
        <br />
        <br />

        <center><asp:Label ID="Label7" runat="server" Text="PERCENTAGE:"></asp:Label>&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <!--<asp:TextBox ID="percentage" runat="server" Width="302px"></asp:TextBox>-->
        <asp:Label ID="pctg" runat="server" Text="PERCENTAGE" BackColor="White" ForeColor="Black" Width="302px" Height="24px"
                BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"></asp:Label></center></center>
        <br />
        <br />

        <center><asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="CLEAR ALL FIELDS" Height="30px" Width="220px" />&nbsp&nbsp&nbsp&nbsp&nbsp
        <asp:Button ID="Button3" runat="server" onclick="Button3_Click" Text="GO BACK" Height="30px" Width="220px" /></center>
        
    </div>
    </form>
</body>
</html>
