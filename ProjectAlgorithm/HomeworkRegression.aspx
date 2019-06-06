<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomeworkRegression.aspx.cs" Inherits="ProjectAlgorithm.HomeworkRegression" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            
            <asp:RadioButton ID="RadioLinear" runat="server" Text="一次" GroupName="RadioTimes" Checked="True" />
            <asp:RadioButton ID="RadioQuad" runat="server" Text="二次" GroupName="RadioTimes" />
            
            <br />
            <asp:TextBox ID="TxtInput" runat="server"></asp:TextBox>
            <asp:Button ID="BtnPredict" runat="server" Text="Predict" OnClick="BtnPredict_Click" />
            
            <br />
            <asp:Label ID="LblPredictValue" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
