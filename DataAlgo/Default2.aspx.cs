using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Response.Write(frac(3).ToString());
    }
    /*
    int frac(int n)
    {
        if (n == 0 || n == 1)
        {
            return 1;
        }
        return n * frac(n - 1);
    }*/

    protected void Button1_Click(object sender, EventArgs e)
    {
        int n = int.Parse(TextBox1.Text);
        char c = 'A';
        for (int i = 1; i <= n; i++)
        {
            for (int j = 0; j < n - i; j++)
            {
                Response.Write("&nbsp;&nbsp;");
            }
            for (int j = 0; j < i * 2 - 1; j++)
            {
                Response.Write(Convert.ToChar(c + i - 1));
            }
            Response.Write("<br />");
        }
    }
}