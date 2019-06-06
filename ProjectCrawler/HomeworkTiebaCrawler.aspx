<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomeworkTiebaCrawler.aspx.cs" Inherits="ProjectCrawler.HomeworkTiebaCrawler" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="js/jquery.min.js"></script>
    <script src="js/echarts.simple.js"></script>
    <script src="js/echarts-wordcloud.js"></script>
    <title></title>
    <style>
        html, body, #main {
            width: 100%;
            height: 100%;
            margin: 0;
        }
    </style>
</head>

<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox runat="server" ID="TxtKeyword"></asp:TextBox>
            <asp:Button runat="server" Text="查询" ID="BtnSearch" OnClick="BtnSearch_OnClick"/>
        </div>
    </form>
    <div id="main"></div>
    <script type="text/javascript">
        //设置数据源
        var Url = "tieba.json";
        // var Url = "test.json";
        $.getJSON(Url, function (data) {
            //下面语句为调试语句，可以在浏览器中调试 data 的内容是什么。
            console.dir(data)
            //显示处理后的数据
            //在 id 为“ main ”的 div 内，绘制图形
            var chart = echarts.init(document.getElementById('main'));
            var option = {
                tooltip: {},
                series: [
                    {
                        type: 'wordCloud',
                        gridSize: 2,
                        sizeRange: [12, 50],
                        rotationRange: [0, 0],
                        shape: 'circle',
                        width: 600,
                        height: 600,
                        drawOutOfBound: true,
                        textStyle: {
                            normal: {
                                color: function () {
                                    return 'rgb(' +
                                        [
                                            Math.round(Math.random() * 160),
                                            Math.round(Math.random() * 160),
                                            Math.round(Math.random() * 160)
                                        ].join(',') +
                                        ')';
                                }
                            },
                            emphasis: {
                                shadowBlur: 10,
                                shadowColor: '#333'
                            }
                        },
                        data: data
                    }
                ]
            };
            chart.setOption(option);
            window.onresize = chart.resize;
        })
    </script>
</body>
</html>
