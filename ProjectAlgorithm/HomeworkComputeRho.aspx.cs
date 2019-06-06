using System;

namespace ProjectAlgorithm
{
    public partial class HomeworkComputeRho : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            double[] dataSZCZ = { 1.8039, 1.1213, 0.8809, 1.5668, 0.1392,
                -4.3959, 1.9237, 1.1006, -1.09, -1.1981, 1.0388, 2.471, -0.1758,
                -0.0108, 0.3499, 0.0869, -1.9689, -1.5095, 0.855, -0.9189, 3.1992 };
            double[] dataGZMT = { 4.5417, -0.9426, -0.266, -1.5107, -2.526,
                -1.4828, 2.8529, -1.7837, 1.2067, 3.183, -0.09, 4.2184, -2.1578,
                0.024, -0.8893, 1.05, -2.3174, -0.3352, 2.0052, 2.3209, 5.849 };
            Response.Write("<table border=\"0\">");
            Response.Write("<tr><td width=\"150px\">上证成指</td><td width=\"150px\">贵州茅台</td></tr>");
            for (int i = 0; i < dataSZCZ.Length; i++)
            {
                Response.Write(string.Format("<tr><td>{0}</td><td>{1}</td></tr>", dataSZCZ[i], dataGZMT[i]));
            }
            Response.Write("</table><br />");
            double rho = calcRho(dataSZCZ, dataGZMT);
            double cov = calcCov(dataGZMT, dataSZCZ);
            Response.Write(string.Format("上证成指与贵州茅台的涨跌幅的协方差为：{0}.相关系数为：{1}<br />",cov, rho));
            Response.Write("相关系数" + ((rho >= 0.8) ? "大于或等于0.8，涨跌幅一致" : "小于0.8，涨跌幅不一致"));
        }

        public double calcMean(double[] data)
        {
            double sum = 0.0;
            foreach (double i in data)
            {
                sum += i;
            }
            return sum / data.Length;
        }
        public double calcVariance(double[] data)
        {
            double mean;
            mean = calcMean(data);
            double sum = 0;
            foreach (double i in data)
            {
                sum += (i - mean) * (i - mean);
            }
            return sum / data.Length;
        }

        public double calcCov(double[] dataX, double[] dataY)
        {
            double meanX, meanY;
            meanX = calcMean(dataX);
            meanY = calcMean(dataY);
            double sum = 0.0;
            for (int i = 0; i < dataX.Length; i++)
            {
                sum += (dataX[i] - meanX) * (dataY[i] - meanY);
            }
            return sum / dataX.Length;
        }

        public double calcRho(double[] dataX, double[] dataY)
        {
            return calcCov(dataX, dataY) / Math.Sqrt(calcVariance(dataX) * calcVariance(dataY));
        }
    }
}