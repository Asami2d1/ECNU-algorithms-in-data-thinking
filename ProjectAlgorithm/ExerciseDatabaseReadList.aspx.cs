using SQL;
using System;
using System.Data;

namespace ProjectAlgorithm
{
    public partial class ExerciseDatabaseReadList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SQLiteHelper sh = new SQLiteHelper();
            string sql = "SELECT c_dy,c_dynasty_chn FROM DYNASTIES ORDER BY c_sort;";
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            try
            {
                sh.RunSQL(sql, ref ds);
                if (ds.Tables[0] != null)
                {
                    dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        DdlDynasties.DataTextField = "c_dynasty_chn";
                        DdlDynasties.DataValueField = "c_dy";
                        DdlDynasties.DataSource = dt;
                        DdlDynasties.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            finally
            {
                sh.Close();
            }
        }
    }
}