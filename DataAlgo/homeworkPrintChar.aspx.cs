using System;

namespace DataAlgo
{
    public partial class homeworkPrintChar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int n = int.Parse(TextBox1.Text);
            if (n <= 26)
            {
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
    }
}