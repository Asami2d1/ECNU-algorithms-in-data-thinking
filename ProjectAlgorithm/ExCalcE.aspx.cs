using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectAlgorithm
{
    public partial class ExCalcE : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnCalc_Click(object sender, EventArgs e)
        {
            double maxTrials = double.Parse(TxtMAX.Text);
            double log2E;
            double inCounts = 0.0;
            Random random = new Random();

            for (int i = 0; i < maxTrials; i++)
            {
                double randX = random.NextDouble() + 1.0;
                double randY = random.NextDouble();
                double realY = 1.0 / randX;

                if (randY <= realY)
                {
                    inCounts += 1.0;
                }
            }

            log2E = inCounts / maxTrials;
            Response.Write("估算出的自然对数e约为:" + Math.Pow(2, 1.0 / log2E).ToString());
        }
    }
}