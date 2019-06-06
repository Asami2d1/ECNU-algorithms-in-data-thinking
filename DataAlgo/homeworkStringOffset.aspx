<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="homeworkStringOffset.aspx.cs" Inherits="DataAlgo.homeworkStringOffset" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            请输入字符串：<asp:TextBox ID="txtInputStr" runat="server"></asp:TextBox>
            <br />
            右移位数：<asp:TextBox ID="txtOffset" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="btnConvert" runat="server" OnClick="btnConvert_Click" Text="转换" />
            <br />
            转换后输出：<asp:Label ID="lblOutput" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
