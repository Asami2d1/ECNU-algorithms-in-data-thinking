<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomeworkRankEstimation.aspx.cs" Inherits="ProjectAlgorithm.HomeworkRankEstimation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox runat="server" ID="TxtGrade"></asp:TextBox>
            <asp:Button runat="server" ID="BtnEstimate" OnClick="BtnEstimate_Click" Text="估计" />
        </div>
    </form>
</body>
</html>
