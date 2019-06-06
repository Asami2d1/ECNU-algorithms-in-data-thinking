using System;

namespace ProjectAlgorithm
{
    public partial class ExCalcPi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            double probability;
            double maxTrials = 1000000;
            double inCounts = 0.0;
            Random random = new Random();

            for (int i = 0; i < maxTrials; i++)
            {
                double randX = random.NextDouble();
                double randY = random.NextDouble();
                if ((randX - 0.5) * (randX - 0.5) + (randY - 0.5) * (randY - 0.5) <= 0.25)
                {
                    inCounts += 1.0;
                }
            }
            probability = inCounts / maxTrials;
            Response.Write((probability * 4).ToString());
        }
    }
}