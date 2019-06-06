using System;

namespace DataAlgo
{
    public partial class ClassEx3_2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bool isAnsFound = false;
            for (int i = 0; i <= 35; i++)
            {
                for (int j = 0; j <= 23; j++)
                {
                    if (i + j == 35 && 2 * i + 4 * j == 94)
                    {
                        isAnsFound = true;
                        Response.Write("有" + i + "只鸡，" + j + "只兔子<br />");
                        break;
                    }
                }
                if (isAnsFound)
                    break;
            }
        }
    }
}