<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="homeworkSqrt.aspx.cs" Inherits="DataAlgo.homeworkSqrt" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            被开方数:<asp:TextBox ID="txtSquare" runat="server"></asp:TextBox>
            <br />
            精度控制值：<asp:TextBox ID="txtAccuracy" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="btnSqrt" runat="server" Text="Sqrt" OnClick="btnSqrt_Click" />
            <br />
            <asp:Label ID="lblSqrt" runat="server" Text=""></asp:Label>
            <br />
            <asp:Label ID="lblStdSqrt" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
