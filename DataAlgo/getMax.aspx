<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="getMax.aspx.cs" Inherits="DataAlgo.getMax" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        请输入第一个数<asp:TextBox ID="txtNum1" runat="server" OnTextChanged="txtNum1_TextChanged" style="height: 22px"></asp:TextBox>
        <br />
        请输入第二个数<asp:TextBox ID="txtNum2" runat="server" OnTextChanged="txtNum2_TextChanged"></asp:TextBox>
        <br />
        请输入第三个数<asp:TextBox ID="txtNum3" runat="server" OnTextChanged="txtNum3_TextChanged"></asp:TextBox>
        <br />
        <asp:Button ID="btnGetMax" runat="server" OnClick="btnGetMax_Click" Text="求最大值" />
        <br />
        <asp:Label ID="lblMaxNum" runat="server"></asp:Label>
    
    </div>
    </form>
</body>
</html>
