using System;
using Common.AITools.Tvbboy;

namespace ProjectAlgorithm
{
    public partial class ExLinearRegression : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Point[] points = new Point[6];
            points[0] = new Point(1, 5);
            points[1] = new Point(2, 7);
            points[2] = new Point(3, 9);
            points[3] = new Point(4, 11);
            points[4] = new Point(5, 13);
            points[5] = new Point(100, 201);

            LinearRegression(points);
        }

        public void LinearRegression(Point[] points)
        {
            if (points.Length < 2)
            {
                Response.Write("点的数量小于2，无法进行线性回归。");
                return;
            }
            double averagex = 0, averagey = 0;
            foreach (Point point in points)
            {
                averagex += point.X;
                averagey += point.Y;
            }
            averagex /= points.Length;
            averagey /= points.Length;
            double numerator = 0;
            double denominator = 0;
            foreach (Point point in points)
            {
                numerator += (point.X - averagex) * (point.Y - averagey);
                denominator += (point.X - averagex) * (point.X - averagex);
            }
            double RCB = numerator / denominator;
            double RCA = averagey - RCB * averagex;
            Response.Write("回归系数A：" + RCA.ToString("0.0000"));
            Response.Write("回归系数B：" + RCB.ToString("0.0000"));
            Response.Write(string.Format("回归方程为：y={0}+{1}*x",
                RCA.ToString("0.0000"), RCB.ToString("0.0000")));
        }
    }
}