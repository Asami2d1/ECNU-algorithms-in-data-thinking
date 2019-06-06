<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomeworkDijkstra.aspx.cs" Inherits="ProjectAlgorithm.HomeworkDijkstra" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            出发点: <asp:DropDownList runat="server" ID="DdlPointA"></asp:DropDownList><br />
            终止点: <asp:DropDownList runat="server" ID="DdlPointB"></asp:DropDownList><br />
            <asp:Button runat="server" ID="BtnDijkstra" Text="查询" OnClick="BtnDijkstra_Click" /> <br />
            <asp:Button runat="server" ID="BtnInsertPoints" Text="插入数据" OnClick="BtnInsertPoints_Click" />
        </div>
    </form>
</body>
</html>
