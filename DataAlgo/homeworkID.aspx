<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="homeworkID.aspx.cs" Inherits="DataAlgo.homeworkID_aspx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="txtId" runat="server"></asp:TextBox>
            <asp:Button ID="btnCheck" runat="server" OnClick="btnCheck_Click" Text="校验" />
            <br />
            <asp:Label ID="lblBirthday" runat="server"></asp:Label>
            <br />
            <asp:Label ID="lblGender" runat="server"></asp:Label>
            <br />
        </div>
    </form>
</body>
</html>
