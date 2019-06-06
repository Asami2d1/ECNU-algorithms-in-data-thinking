<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExampleDatabaseReadOne.aspx.cs" Inherits="ProjectAlgorithm.ExampleDatabaseReadOne" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox runat="server" ID="TxtName"></asp:TextBox><br />
            <asp:Button runat="server" ID="BtnSearch" Text="检索" OnClick="BtnSearch_Click" />
        </div>
    </form>
</body>
</html>
