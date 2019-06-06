<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="homeworkKmeansGeneral.aspx.cs" Inherits="ProjectAlgorithm.homeworkKmeansGeneral" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="TxtK" runat="server"></asp:TextBox>
            <asp:Button ID="BtnCluster" runat="server" Text="聚类" OnClick="BtnCluster_Click" />
        </div>
    </form>
</body>
</html>
