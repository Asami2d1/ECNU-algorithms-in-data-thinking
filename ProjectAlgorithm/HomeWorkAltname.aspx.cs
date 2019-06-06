using SQL;
using System;
using System.Data;

namespace ProjectAlgorithm
{
    public partial class HomeWorkAltname : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLookUp_Click(object sender, EventArgs e)
        {
            SQLiteHelper sQ = new SQLiteHelper();
            string name = txtName.Text;
            string sql = string.Format("SELECT c_alt_name_chn FROM ALTNAME_DATA WHERE c_personid IN (" +
                "SELECT c_personid FROM BIOG_MAIN WHERE c_name_chn='{0}');", name);
            DataTable dataTable = new DataTable();
            DataSet dataSet = new DataSet();
            string result = "TA的曾用名：";

            try
            {
                sQ.RunSQL(sql, ref dataSet);
                if (dataSet.Tables[0] != null)
                {
                    dataTable = dataSet.Tables[0];
                    if (dataTable.Rows.Count > 0)
                    {
                        foreach (DataRow altName in dataTable.Rows)
                        {
                            result += altName["c_alt_name_chn"] + "，";
                        }
                    }
                    else
                    {
                        result = "查无此人或其无曾用名。";
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            finally
            {
                sQ.Close();
            }
            lblResult.Text = result.Substring(0, result.Length - 1) + "。";
        }
    }
}