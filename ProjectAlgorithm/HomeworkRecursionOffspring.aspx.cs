using SQL;
using System;
using System.Data;
using System.Data.Sql;

namespace ProjectAlgorithm
{
    public partial class HomeworkRecursionOffspring : System.Web.UI.Page
    {
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void BtnLookup_Click(object sender, EventArgs e)
        {
            string sql = "select * from  DynastyHanEmperor ";
            string sqlLookupEID = string.Format("SELECT EID, ENAME FROM DynastyHanEmperor WHERE ENAME = '{0}'", TxtName.Text);
            SQLHelper sh = new SQLHelper();
            DataSet ds = new DataSet();
            DataSet dsIDs = new DataSet();
            try
            {
                sh.RunSQL(sql, ref ds);
                sh.RunSQL(sqlLookupEID, ref dsIDs);
                if (dsIDs.Tables.Count > 0 && dsIDs.Tables[0].Rows.Count > 0)
                {
                    string Eid = dsIDs.Tables[0].Rows[0]["EID"].ToString();
                    if (ds.Tables.Count > 0)
                    {
                        dt = ds.Tables[0];
                        PrintChildren(Eid);
                    }
                }
                else
                {
                    Response.Write("查无此人，请重新输入。<br />");
                }
            }
            catch (Exception EX)
            {
                Response.Write(EX.Message);
            }
            finally
            {
                sh.Close();
            }
        }

        private bool IsHaveChildren(string EID)
        {
            foreach(DataRow person in dt.Rows)
            {
                if (person["EPARENTID"].ToString()==EID)
                {
                    return true;
                }
            }
            return false;
        }

        private void PrintChildren(string EID)
        {
            if (IsHaveChildren(EID))
            {
                foreach (DataRow person in dt.Rows)
                {
                    if (person["EPARENTID"].ToString() == EID)
                    {
                        Response.Write(person["ENAME"] + "<br />");
                        PrintChildren(person["EID"].ToString());
                    }
                }
            }
            else
                return;
        }

    }
}