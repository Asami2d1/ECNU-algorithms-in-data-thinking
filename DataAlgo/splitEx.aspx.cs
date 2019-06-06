using System;

namespace DataAlgo
{
    public partial class splitEx : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string[] email_arr = email.Split('@');

            if (email_arr.Length == 2)
            {
                string[] host_arr = email_arr[1].Split('.');
                Response.Write("顶级域名为" + host_arr[host_arr.Length - 1]);
            }
            else
                Response.Write("EMAIL格式不合法");
        }
    }
}