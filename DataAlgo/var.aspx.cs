using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DataAlgo
{
    public partial class var : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int a = 1;
            int b = 3;
            byte c = 6;
            char d = 'a';
            bool f;
            byte g = 255;
            // char h = g;
            // Response.Write((g + 1).ToString());  // <Output>: 256 Why???
            Response.Write(a.ToString() + "<br />");
            Response.Write("<font color=red>" + b + "</font><br />");
            f = b <= 4 && b >= 3;

            a = 3;
            b = a++;
            Response.Write(b + "<br />");

            a = 3;
            b = ++a;
            Response.Write(b + "<br />");

            a = 10;
            b = 3;
            Response.Write(a / b + "<br />");

            double e1 = a / b;  // e1 = 3
            Response.Write(e1 + "<br />");

            int t = Convert.ToInt32(f);
            Response.Write(t + "<br />");

        }
    }
}
