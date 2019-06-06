<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomeworkRecursionOffspring.aspx.cs" Inherits="ProjectAlgorithm.HomeworkRecursionOffspring" %>

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
            <asp:Button runat="server" ID="BtnLookup" OnClick="BtnLookup_Click" Text="查询" />
        </div>
    </form>
</body>
</html>
