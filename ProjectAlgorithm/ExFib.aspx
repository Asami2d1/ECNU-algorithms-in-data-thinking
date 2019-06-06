<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExFib.aspx.cs" Inherits="ProjectAlgorithm.ExFib" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox runat="server" ID="TxtNum"></asp:TextBox>
            <asp:Button runat="server" ID="BtnFib" OnClick="BtnFib_Click" />
        </div>
    </form>
</body>
</html>
