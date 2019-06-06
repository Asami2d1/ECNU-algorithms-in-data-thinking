using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SQL;
using System.Data;

namespace ProjectEChart
{
    public partial class DynastyAndEra : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SQLiteHelper sQ = new SQLiteHelper();
                string sqlDynasty = "SELECT c_dy, c_dynasty_chn FROM DYNASTIES " +
                    "WHERE c_dynasty_chn != '未詳' ORDER BY c_sort;";
                DataTable dt = new DataTable();
                DataSet ds = new DataSet();
                try
                {
                    sQ.RunSQL(sqlDynasty, ref ds);
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
                    sQ.Close();
                }
            }
        }

        protected void DdlDynasties_SelectedIndexChanged(object sender, EventArgs e)
        {
            SQLiteHelper sQ = new SQLiteHelper();
            string sqlEra = "SELECT c_nianhao_id, c_nianhao_chn, c_dy FROM NIAN_HAO " +
                "WHERE c_dy = " + DdlDynasties.SelectedValue + ";";
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            try
            {
                sQ.RunSQL(sqlEra, ref ds);
                if (ds.Tables[0] != null)
                {
                    dt = ds.Tables[0];
                    if (dt.Rows.Count >= 0)
                    {
                        DdlEraName.DataTextField = "c_nianhao_chn";
                        DdlEraName.DataValueField = "c_nianhao_id";
                        DdlEraName.DataSource = dt;
                        DdlEraName.DataBind();
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
        }
    }
}