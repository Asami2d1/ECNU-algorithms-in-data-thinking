using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.AITools.Tvbboy;

namespace ProjectAlgorithm
{
    public partial class HomeworkRankEstimation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnEstimate_Click(object sender, EventArgs e)
        {
            double[] existedGrades = { 90, 79, 91, 89, 77, 82, 85, 88, 78, 92,
                92, 94, 93, 72, 92, 91, 0, 92, 76, 86, 87, 77, 79, 89, 90, 90,
                81, 92, 86 };
            double grade;
            try
            {
                grade = double.Parse(TxtGrade.Text);
                double mean = CalcMean(existedGrades);
                //Response.Write(mean.ToString()+"<br />");
                double s = Math.Sqrt(CalcVariance(existedGrades));
                //Response.Write(s);
                double z = (grade - mean) / s;
                double rank = 1 - ClassStatistics.selfCaculate((float)z);
                Response.Write(string.Format("{0}分排名大约为前{1:F2}%", grade, rank * 100));
            }
            catch(Exception Ex)
            {
                Response.Write(Ex.Message);
            }
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
    }
}