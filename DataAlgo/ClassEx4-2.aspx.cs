using System;
using System.Web.UI.WebControls;

namespace DataAlgo
{
    public partial class ClassEx4_2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            const uint MAX = 20;
            if (ddlRange1.Items.Count == 0)
            {
                for (int i = 1; i <= MAX; ++i)
                {
                    ListItem liTemp = new ListItem(i.ToString(), i.ToString());
                    ddlRange1.Items.Add(liTemp);
                    ddlRange2.Items.Add(liTemp);
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int[] allPrimeNums = new int[] { 2, 3, 5, 6, 11, 13, 17, 19 };
            string primeNumbersFound = "";

            int range1 = int.Parse(ddlRange1.SelectedValue);
            int range2 = int.Parse(ddlRange2.SelectedValue);

            int low = (range1 <= range2) ? range1 : range2;
            int high = (range1 > range2) ? range1 : range2;

            int i = low;
            while (i >= low && i <= high)
            {
                foreach (int p in allPrimeNums)
                {
                    if (i == p)
                    {
                        primeNumbersFound += i.ToString()+" ";
                        break;
                    }
                }
                ++i;
            }
            if (primeNumbersFound.Length != 0)
            {
                lblOut.Text = low.ToString() + "与" + high.ToString() + "之间所有的素数为：" + primeNumbersFound;
            }
            else
            {
                lblOut.Text = low.ToString() + "与" + high.ToString() + "之间没有素数";
            }
        }

        protected void ddlRange2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlRange1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}