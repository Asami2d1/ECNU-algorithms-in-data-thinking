<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomeWorkAltname.aspx.cs" Inherits="ProjectAlgorithm.HomeWorkAltname" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox runat="server" ID="txtName"></asp:TextBox>
            <br />
            <asp:Button runat="server" ID="btnLookUp" Text="查找曾用名" OnClick="btnLookUp_Click" />
            <br />
            <asp:Label runat="server" ID="lblResult" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
