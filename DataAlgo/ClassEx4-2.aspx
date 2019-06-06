<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClassEx4-2.aspx.cs" Inherits="DataAlgo.ClassEx4_2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:DropDownList ID="ddlRange1" runat="server" OnSelectedIndexChanged="ddlRange1_SelectedIndexChanged">
        </asp:DropDownList>
        <div>
            <asp:DropDownList ID="ddlRange2" runat="server" OnSelectedIndexChanged="ddlRange2_SelectedIndexChanged">
            </asp:DropDownList>
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
            <br />
            <asp:Label ID="lblOut" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
