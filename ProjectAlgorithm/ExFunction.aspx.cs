using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectAlgorithm
{
    public partial class ExFunction : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnIsLeapYear_Click(object sender, EventArgs e)
        {
            int year = int.Parse(TxtYear.Text);
            if (isLeapYear(year))
            {
                Response.Write(TxtYear.Text+"年是闰年");
            }
            else
            {
                Response.Write(TxtYear.Text+"年不是闰年");
            }
        }

        private bool isLeapYear(int year)
        {
            if (year % 4 == 0)
            {
                if (year % 100 == 0 && year % 400 != 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            return false;
        }
    }
}