using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DataAlgo
{
    public partial class getMax : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGetMax_Click(object sender, EventArgs e)
        {
            try
            {
                double num1 = double.Parse(txtNum1.Text);
                double num2 = double.Parse(txtNum2.Text);
                double num3 = double.Parse(txtNum3.Text);
                double max = num1;

                if (max < num2)
                {
                    max = num2;
                }

                if (max < num3)
                {
                    max = num3;
                }

                //Response.Write(num1.ToString() + ", " + num2.ToString() + ", " + num3.ToString()
                //    + "的最大值是" + max.ToString());

                lblMaxNum.Text = num1.ToString() + ", " + num2.ToString() + ", " + num3.ToString()
                    + "的最大值是" + max.ToString();
            }
            catch
            {
                lblMaxNum.Text = "ERROR!";
            }
        }
        
        protected void txtNum1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtNum2_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtNum3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}