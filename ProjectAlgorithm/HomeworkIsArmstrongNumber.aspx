<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomeworkIsArmstrongNumber.aspx.cs" Inherits="ProjectAlgorithm.HomeworkIsArmstrongNumber" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox runat="server" ID="TxtInput"></asp:TextBox>
            <asp:Button runat="server" ID="BtnCheck" OnClick="BtnCheck_Click" Text="Check" />
        </div>
    </form>
</body>
</html>
