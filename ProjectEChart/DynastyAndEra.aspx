<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DynastyAndEra.aspx.cs" Inherits="ProjectEChart.DynastyAndEra" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            朝代：<asp:DropDownList ID="DdlDynasties" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DdlDynasties_SelectedIndexChanged">
            </asp:DropDownList>
            <br />
            年号：<asp:DropDownList ID="DdlEraName" runat="server">
            </asp:DropDownList>
        </div>
    </form>
</body>
</html>
