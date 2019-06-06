using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.AITools.Tvbboy;

namespace ProjectAlgorithm
{
    public partial class ExMultiLinearRegression : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Point[] points = new Point[8];
            points[0] = new Point(100, 5100);
            points[1] = new Point(110, 6170);
            points[2] = new Point(120, 7340);
            points[3] = new Point(130, 8610);
            points[4] = new Point(140, 9980);
            points[5] = new Point(150, 11450);
            points[6] = new Point(160, 13020);
            points[7] = new Point(170, 14690.5);
            MultiLinearRegression(points, 2);
        }

        public void MultiLinearRegression(Point[] points, int times)
        {
            if (points.Length < 2)
            {
                Response.Write("点的数量小于2，无法进行线性回归");
                return;
            }
            double[] coefficients = ClassLeastSquares.MultiLine(points, times);
            string expr = "";
            for (int i = 0; i < coefficients.Length; i++)
            {
                expr += coefficients[i].ToString() + "*x^" + i + "+";
            }
            expr = expr.Substring(0, expr.Length - 1);
            Response.Write(string.Format("线性回归{0}次方程：y=", times) + expr);
        }
    }
}