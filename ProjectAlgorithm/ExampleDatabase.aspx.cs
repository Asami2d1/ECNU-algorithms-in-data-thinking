using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using SQL;
namespace ProjectAlgorithm
{
    public partial class ExampleDatabase : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SQLiteHelper sh = new SQLiteHelper();
            string sql = "select count(*) from BIOG_MAIN";
            try
            {
                sh.RunSQL(sql);
                Response.Write("服务器连接成功");
            }
            catch (Exception ex)
            {
                Response.Write("服务器连接失败，原因：" + ex.Message);
            }
            finally
            {
                sh.Close();
            }
        }
    }
}