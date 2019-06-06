using System;

namespace ProjectAlgorithm
{
    public partial class ExBasicStatistics : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            double[] dataSZZS = { -0.3958, 0.2926, 2.3857, -0.3399, -0.0419, -1.603, 0.0699, -0.1586, -0.0542, 0.9413,
                1.2425, 0.2038, 2.5755, 3.1992, -0.9189, 0.855, -1.5095, -1.9689, 0.0869, 0.3499, -0.0108, -0.1758,
                2.471, 1.0388, -1.1981, -1.09, 1.1006, 1.9237, -4.3959, 0.1392, 1.5668, 0.8809, 1.1213, 1.8039, -0.4357,
                0.4184, -0.6675, 5.6007, 1.9051, -0.3411, 0.2022, 0.0468, 2.6831, -1.372, -0.0503, 1.8404, 0.6782, 1.3621,
                1.3023, 0.3493 };
            double[] dataSDHJ = { -0.8952, -0.1325, 0.9358, -0.8943, -1.8531, -2.1628, 1.4521, -2.0234, -0.6907, 0.4732,
                -0.627, 1.4954, 1.1261, -1.7389, -2.4368, -1.2789, 1.2955, 1.3125, -0.5902, 5.093, -1.5113, 0.4198, 1.541,
                -1.4221, -3.913, 0, 0.6565, 0.2821, -2.5954, -0.8477, 1.8501, -1.5781, 1.6035, -0.5215, -1.0322, -0.813,
                -2.2948, 2.5958, -2.7876, 2.1889, 1.6458, 1.8944, 1.931, 1.25, -0.9838, 0.4143, 1.8831, -0.3236, 0.7171,
                -1.824 };
            double meanSDHJ, varianceSDHJ, cov;
            meanSDHJ = CalcMean(dataSDHJ);
            varianceSDHJ = CalcVariance(dataSDHJ);
            cov = CalcCov(dataSDHJ, dataSZZS);
            Response.Write(string.Format("Mean of SDHJ: {0}<br />", meanSDHJ));
            Response.Write(string.Format("Variance of SDHJ: {0}<br />", varianceSDHJ));
            Response.Write(string.Format("The data vary in range {0} ± {1}<br />", meanSDHJ, varianceSDHJ));
            Response.Write(string.Format("The Cov between SDHJ and SZZS is {0}<br />", cov));
        }
        public double CalcMean(double[] data)
        {
            double sum = 0.0;
            foreach (double i in data)
            {
                sum += i;
            }
            return sum / data.Length;
        }
        public double CalcVariance(double[] data)
        {
            double mean;
            mean = CalcMean(data);
            double sum = 0;
            foreach (double i in data)
            {
                sum += (i - mean) * (i - mean);
            }
            return sum / data.Length;
        }

        public double CalcCov(double[] dataX, double[] dataY)
        {
            double meanX, meanY;
            meanX = CalcMean(dataX);
            meanY = CalcMean(dataY);
            double sum = 0.0;
            for (int i = 0; i < dataX.Length; i++)
            {
                sum += (dataX[i] - meanX) * (dataY[i] - meanY);
            }
            return sum / dataX.Length;
        }
    }
}