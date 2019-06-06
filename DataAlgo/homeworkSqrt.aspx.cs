using System;

namespace DataAlgo
{
    public partial class homeworkSqrt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSqrt_Click(object sender, EventArgs e)
        {
            double square = double.Parse(txtSquare.Text);
            uint accuracy = uint.Parse(txtAccuracy.Text);
            double guess = 1;
            double guessImproved = 0;
            bool isGoodEnough = false;
            // 牛顿法迭代
            while (!isGoodEnough)
            {
                guessImproved = guess - (guess * guess - square) / (2 * guess);
                if (Math.Abs(guessImproved / guess - 1) <= Math.Pow(10, -accuracy * 3))
                {
                    // 如果再迭代一次改进量足够小则认为估计结果已经够好
                    isGoodEnough = true;
                }
                guess = guessImproved;
            }
            lblSqrt.Text = "本程序计算结果为: " + guess.ToString();
            lblStdSqrt.Text = "Math.Sqrt 计算结果为: " + Math.Sqrt(square).ToString();
        }
    }
}