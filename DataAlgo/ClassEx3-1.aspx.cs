using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DataAlgo
{
    public partial class ClassEx : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int product = 1;
            for (int i = 1; i <= 10; i++)
            {
                product *= i;
            }
            Response.Write(product);
        }
    }
}