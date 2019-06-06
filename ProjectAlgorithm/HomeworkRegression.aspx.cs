using Common.AITools.Tvbboy;
using System;
using System.Collections.Generic;
using System.IO;

namespace ProjectAlgorithm
{
    public partial class HomeworkRegression : System.Web.UI.Page
    {
        // 系数数组
        private double[] coefficientsLinear;
        private double[] coefficientsQuad;

        protected void Page_Load(object sender, EventArgs e)
        {
            // 读取训练集
            List<double> happinessIndexes;
            List<double> lifeSpans;
            ReadData(@"D:\Github\DataAlgo\ProjectAlgorithm\dataset.csv",
                out happinessIndexes, out lifeSpans);
            Point[] points = new Point[happinessIndexes.Count];
            for (int i = 0; i < happinessIndexes.Count; i++)
            {
                points[i] = new Point(lifeSpans[i], happinessIndexes[i]);
            }

            // 训练线性回归模型
            MultiLinearRegression(points, 1, out coefficientsLinear);
            MultiLinearRegression(points, 2, out coefficientsQuad);

            // 读取测试集
            List<double> testSetHappinessIndexes;
            List<double> testSetLifeSpans;
            ReadData(@"D:\Github\DataAlgo\ProjectAlgorithm\test1.csv",
                out testSetHappinessIndexes, out testSetLifeSpans);

            // 测试模型并输出表格
            Response.Write("<table border=\"1\">");
            Response.Write("<tr><td width=\"50px\">序号</td><td width=\"150px\">x(健康指数)</td><td width=\"200px\">y_1(幸福指数)</td>" +
                "<td width=\"200px\">y_2(幸福指数)</td><td width=\"150px\">真实值</td><td width=\"50px\"></td></tr>");
            for (int i = 0; i < testSetLifeSpans.Count; i++)
            {
                double y1 = CalcPoly(coefficientsLinear, testSetLifeSpans[i]);
                double y2 = CalcPoly(coefficientsQuad, testSetLifeSpans[i]);
                Response.Write(
                    string.Format("<tr><td width=\"50px\">{0}</td><td width=\"150px\">{1}</td>" +
                    "<td width=\"200px\">{2}</td><td width=\"200px\">{3}</td><td width=\"150px\">{4}</td>" +
                    "<td width=\"50px\">{5}</td></tr>",
                    i + 1,
                    testSetLifeSpans[i],
                    y1,
                    y2,
                    testSetHappinessIndexes[i],
                    (Math.Abs(y1 - testSetHappinessIndexes[i]) < Math.Abs(y2 - testSetHappinessIndexes[i])) ?
                    "一次" : "二次")
                    );
            }
            Response.Write("</table><br />");
        }

        // 计算回归系数
        public void MultiLinearRegression(Point[] points, int times, out double[] coefficients)
        {
            if (points.Length < 2)
            {
                Response.Write("点的数量小于2，无法进行线性回归");
                coefficients = null;
                return;
            }
            coefficients = ClassLeastSquares.MultiLine(points, times);
            string expr = coefficients[0].ToString() + "+";
            for (int i = 1; i < coefficients.Length; i++)
            {
                expr += coefficients[i].ToString() + "*x^" + i + "+";
            }
            expr = expr.Substring(0, expr.Length - 1);
            Response.Write(string.Format("线性回归{0}次方程：y=", times) + expr);
            Response.Write("<br />");
        }

        // 从外部CSV文件中读取数据
        // 数据集来源: https://www.kaggle.com/dgscharan/data-set-for-happines
        private void ReadData(string filepath, out List<double> col1, out List<double> col2)
        {
            var reader = new StreamReader(File.OpenRead(filepath));
            col1 = new List<double>();
            col2 = new List<double>();
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');

                col1.Add(double.Parse(values[0]));
                col2.Add(double.Parse(values[1]));
            }
        }

        // 计算多项式的值
        private double CalcPoly(double[] coefficients, double x)
        {
            double res = 0.0;
            for (int i = 0; i < coefficients.Length; i++)
            {
                res += coefficients[i] * Math.Pow(x, i);
            }
            return res;
        }

        protected void BtnPredict_Click(object sender, EventArgs e)
        {
            try
            {
                double input = double.Parse(TxtInput.Text);
                double result;
                if (RadioLinear.Checked)
                {
                    result = CalcPoly(coefficientsLinear, input);
                }
                else if (RadioQuad.Checked)
                {
                    result = CalcPoly(coefficientsQuad, input);
                }
                else
                {
                    Exception exception = new Exception("未选择计算所用的模型。");
                    throw exception;
                }
                LblPredictValue.Text = "预测值为: " + result.ToString();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }

        }
    }
}
