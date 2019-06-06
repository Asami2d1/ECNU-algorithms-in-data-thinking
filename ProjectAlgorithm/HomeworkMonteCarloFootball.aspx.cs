using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectAlgorithm
{
    public partial class HomeworkMonteCarloFootball : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int MAXTIMES = 100000;
            Random random1 = new Random();
            //Random random2 = new Random();
            double countNIG = 0.0, countAGT = 0.0, countICL = 0.0;

            for (int i = 0; i < MAXTIMES; i++)
            {
                int res1 = random1.Next(1, 4); // 1:尼日利亚, 2:平, 3:阿根廷
                int res2 = random1.Next(1, 4); // 1: 冰岛 2:平 3:克罗地亚
                if (res1 == 1)
                {
                    countNIG += 1.0;
                }
                else if (res1 == 2 && res2 == 1)
                {
                    countNIG += 0.5;
                    countICL += 0.5;
                }
                else if (res1 == 2 && res2 != 1)
                {
                    countNIG += 1.0;
                }
                else if (res1 == 3 && res2 == 1)
                {
                    countAGT += 0.5;
                    countICL += 0.5;
                }
                else if (res1 == 3 && res2 != 1)
                {
                    countAGT += 1.0;
                }
            }
            double probNIG = countNIG / MAXTIMES;
            double probAGT = countAGT / MAXTIMES;
            double probICL = countICL / MAXTIMES;
            Response.Write(string.Format("尼日利亚出线概率约为: {0}<br />阿根廷出线概率约为: {1}<br />冰岛出线概率约为: {2}",
                probNIG, probAGT, probICL));
        }
    }
}