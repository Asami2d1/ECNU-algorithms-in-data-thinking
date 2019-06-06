using Common.AITools.Tvbboy;
using SQL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ProjectAlgorithm
{
    public partial class HomeworkDijkstra : System.Web.UI.Page
    {
        private ArrayList arrayNodes;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                // 数据初始化, 必须每次刷新都重新运行
                // WARNING: 此处数据库交互多, 可能导致缓慢
                Initialize();
                if (!IsPostBack)
                {
                    // 页面初始化, 仅需在第一次打开后运行
                    SQLHelper helper = new SQLHelper();
                    string strSqlA = "SELECT DISTINCT PointA FROM tblDistance;";
                    string strSqlB = "SELECT DISTINCT PointB FROM tblDistance;";
                    DataTable tableA;
                    DataTable tableB;
                    DataSet set = new DataSet();

                    helper.RunSQL(strSqlA, ref set);
                    if (set.Tables[0] != null)
                    {
                        tableA = set.Tables[0];
                        if (tableA.Rows.Count > 0)
                        {
                            DdlPointA.DataTextField = "PointA";
                            DdlPointA.DataValueField = "PointA";
                            DdlPointA.DataSource = tableA;
                            DdlPointA.DataBind();
                        }
                    }
                    set = null;
                    set = new DataSet();
                    helper.RunSQL(strSqlB, ref set);
                    if (set.Tables[0] != null)
                    {
                        tableB = set.Tables[0];
                        if (tableB.Rows.Count > 0)
                        {
                            DdlPointB.DataTextField = "PointB";
                            DdlPointB.DataValueField = "PointB";
                            DdlPointB.DataSource = tableB;
                            DdlPointB.DataBind();
                        }
                    }
                    helper.Close();
                }
            }
            catch (Exception Ex)
            {
                Response.Write(Ex.Message);
            }
        }

        // 读取数据库中所有的路径和点并储存
        private void Initialize()
        {
            SQLHelper helper = new SQLHelper();
            SqlDataReader reader;
            DataTable table;
            DataSet data;
            arrayNodes = new ArrayList();
            try
            {
                // 获取所有不同的PointA
                string strSqlQueryA = "SELECT DISTINCT PointA FROM tblDistance;";
                data = new DataSet();
                helper.RunSQL(strSqlQueryA, ref data);
                if (data.Tables[0] != null)
                {
                    table = data.Tables[0];
                    if (table.Rows.Count > 0)
                    {
                        foreach (DataRow row in table.Rows)
                        {
                            arrayNodes.Add(new Node(row["PointA"].ToString()));
                        }
                    }
                }

                // 获得所有的边
                foreach (Node node in arrayNodes)
                {
                    string strSqlQueryEdgesFromA = string.Format("SELECT PointA, PointB, Distance FROM tblDistance " +
                        "WHERE PointA='{0}';", node.ID);
                    data = new DataSet();
                    helper.RunSQL(strSqlQueryEdgesFromA, ref data);
                    if (data.Tables[0] != null)
                    {
                        table = data.Tables[0];
                        if (table.Rows.Count > 0)
                        {
                            foreach (DataRow row in table.Rows)
                            {
                                node.EdgeList.Add(new Edge(node.ID, row["PointB"].ToString(),
                                    Convert.ToDouble(row["Distance"])));
                            }
                        }
                    }
                }
                
                // 处理脏数据, 补全数据库未给出的节点A
                for (int i = 0; i < arrayNodes.Count; ++i)
                {
                    // 糟糕的写法, 但是Node类貌似不是Hashable Object...
                    Node node = (Node)arrayNodes[i];
                    for (int j = 0; j < node.EdgeList.Count; ++j)
                    {
                        Edge edge = (Edge)node.EdgeList[j];
                        string strSqlQueryEndPoint = string.Format("SELECT PointA FROM tblDistance WHERE PointA = '{0}';",
                            edge.EndNodeID);
                        helper.RunSQL(strSqlQueryEndPoint, out reader);

                        if (!reader.Read())
                        {
                            // 关闭sdr
                            reader.Close();
                            reader = null;
                            bool exist = false;
                            foreach (Node n in arrayNodes)
                            {
                                exist = exist || n.ID.Equals(edge.EndNodeID);
                            }
                            if (!exist)
                            {
                                arrayNodes.Add(new Node(edge.EndNodeID));
                            }
                        }
                        else
                        {
                            reader.Close();
                            reader = null;
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                Response.Write(Ex.Message);
            }
            finally
            {
                helper.Close();
            }

        }

        protected void BtnDijkstra_Click(object sender, EventArgs e)
        {
            string strPointAID, strPointBID;
            strPointAID = DdlPointA.SelectedValue;
            strPointBID = DdlPointB.SelectedValue;

            if (strPointAID.Equals(strPointBID))
            {
                Response.Write("距离为: 0<br />路径: " + strPointAID);
                return;
            }

            try
            {
                // 调包, 运行Dijkstra算法
                RoutePlanner planner = new RoutePlanner();
                RoutePlanResult planResult = planner.Paln(arrayNodes, strPointAID, strPointBID);
                if (planResult.getWeight() < 100000)
                {
                    Response.Write("距离为: " + planResult.getWeight().ToString());
                    PrintRouteResult(planResult);
                    Response.Write(strPointBID + "<br />");
                }
                else
                {
                    Response.Write("无路径<br />");
                }
                planner = null;

            }
            catch (Exception Ex)
            {
                Response.Write(Ex.Message);
            }
        }

        // 数据库插入函数, 仅在第一次debug时有用
        protected void BtnInsertPoints_Click(object sender, EventArgs e)
        {
            SQLHelper helper = new SQLHelper();
            SqlDataReader sdr;
            string strStudentId = "10181900128";
            string strPointA = "合肥";
            string[] strPointBs = { "南京", "杭州", "南昌", "武汉", "郑州", "济南" };
            Dictionary<string, double> dictDistances = new Dictionary<string, double>();
            dictDistances.Add("南京", 150.4);
            dictDistances.Add("杭州", 327.5);
            dictDistances.Add("南昌", 372.3);
            dictDistances.Add("武汉", 309.8);
            dictDistances.Add("郑州", 466.7);
            dictDistances.Add("济南", 537.2);

            try
            {
                string strSqlCount = "SELECT MAX(ID) AS MAXID FROM tblDistance;";
                foreach (var pointB in strPointBs)
                {
                    helper.RunSQL(strSqlCount, out sdr);
                    if (sdr.Read())
                    {
                        // 读取当前最大ID
                        int maxID = Convert.ToInt32(sdr["MAXID"]);
                        sdr.Close();
                        sdr = null;

                        // 插入路径
                        string strSqlQuery = string.Format("SELECT PointA, PointB, StudentNumber FROM tblDistance " +
                            "WHERE PointA='{0}' AND PointB='{1}' AND StudentNumber='{2}';", strPointA, pointB, strStudentId);
                        string strSqlInsert = string.Format("INSERT INTO tblDistance(ID, PointA, PointB, Distance, StudentNumber) " +
                            "VALUES({0}, '{1}', '{2}', '{3}', '{4}');", maxID + 1, strPointA, pointB, dictDistances[pointB], strStudentId);
                        // 防止重复插入
                        helper.RunSQL(strSqlQuery, out sdr);
                        if (!sdr.Read())
                        {
                            sdr.Close();
                            int ret = helper.RunSQL(strSqlInsert);
                            if (ret > 0)
                            {
                                Response.Write("语句: " + strSqlInsert + " 插入成功<br />");
                            }
                            else
                            {
                                Response.Write("语句: " + strSqlInsert + " 插入失败");
                            }
                        }
                        else
                        {
                            Response.Write(string.Format("已经存在<br />", pointB));
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                Response.Write(Ex.Message);
            }
            finally
            {
                sdr = null;
                helper.Close();
            }
        }

        // 打印路径, 照抄
        private void PrintRouteResult(RoutePlanResult result)
        {
            Response.Write("<br />路径: ");
            string[] tmp = result.getPassedNodeIDs();
            for (int i = 0; i < tmp.Length; i++)
            {
                Response.Write(tmp[i] + "--");
            }
        }
    }
}