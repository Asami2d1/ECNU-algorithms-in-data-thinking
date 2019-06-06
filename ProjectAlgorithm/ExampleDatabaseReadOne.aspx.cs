using SQL;
using System;
using System.Data.SQLite;

namespace ProjectAlgorithm
{
    public partial class ExampleDatabaseReadOne : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            string pName = TxtName.Text;
            string result = "";
            if (pName.Length < 1)
            {
                Response.Write("请输入人名！");
                return;
            }
            string sql = string.Format("SELECT c_personid,c_name,c_name_chn,c_birthyear,c_deathyear " +
                "FROM biog_main WHERE C_NAME_CHN=\'{0}\'", pName);
            SQLiteHelper sh = new SQLiteHelper();
            SQLiteDataReader sdr;
            try
            {
                sh.RunSQL(sql, out sdr);
                if (sdr.Read())
                {
                    result = string.Format("姓名：{0},生于{1}年", 
                        sdr["c_name_chn"].ToString(), sdr["c_birthyear"].ToString());
                }
                else
                {
                    result = "没有找到该记录";
                }
            }
            catch(Exception ex)
            {
                result = ex.Message;
            }
            finally
            {
                Response.Write(result);
                sh.Close();
            }
        }
    }
}