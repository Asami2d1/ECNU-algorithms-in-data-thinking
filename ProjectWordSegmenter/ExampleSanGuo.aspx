<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExampleSanGuo.aspx.cs" Inherits="ProjectWordSegmenter.ExampleSanGuo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button runat="server" ID="BtnAll" OnClick="BtnAll_Click" Text="全模式" />
            <br />
            <asp:Button ID="BtnSearch" runat="server" Text="搜索引擎模式" OnClick="BtnSearch_Click" />
        </div>
    </form>
</body>
</html>
