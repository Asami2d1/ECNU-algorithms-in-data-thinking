<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="homeworkGetTriangularArea.aspx.cs" Inherits="DataAlgo.homeworkGetTriangularArea" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="txtLengthA" runat="server"></asp:TextBox>
            <br />
            <asp:TextBox ID="txtLengthB" runat="server"></asp:TextBox>
            <br />
            <asp:TextBox ID="txtLengthC" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="btnGetArea" runat="server" OnClick="btnGetArea_Click" Text="求三角形面积" />
            <br />
            <asp:Label ID="lblAns" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
