using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DataAlgo
{
    public partial class output : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write("Hello, World.");
            //输出JS
            Response.Write("<script>alert(\"欢迎学习数据思维下的算法与程序设计\");</script>");
            //输出html
            Response.Write("<h1>Hello, World. Headline</h1>");
            Label1.Text = "Hello, World. Label";
        }
    }
}