<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExCalcE.aspx.cs" Inherits="ProjectAlgorithm.ExCalcE" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            取样点数<asp:TextBox ID="TxtMAX" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="BtnCalc" runat="server" Text="计算" OnClick="BtnCalc_Click" />
        </div>
    </form>
</body>
</html>
