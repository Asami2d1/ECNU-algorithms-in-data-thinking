<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExFunction.aspx.cs" Inherits="ProjectAlgorithm.ExFunction" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="TxtYear" runat="server"></asp:TextBox>
            <asp:Button ID="BtnIsLeapYear" runat="server" OnClick="BtnIsLeapYear_Click" Text="Check" />
        </div>
    </form>
</body>
</html>
