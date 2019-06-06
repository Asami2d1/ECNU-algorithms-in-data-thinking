using Common.AITools.Tvbboy;
using SQL;
using System;
using System.Collections;
using System.Data;

namespace ProjectAlgorithm
{
    public partial class homeworkKmeansGeneral : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnCluster_Click(object sender, EventArgs e)
        {
            int k = int.Parse(TxtK.Text);
            SQLHelper helper = new SQLHelper();
            string strQuery = "SELECT id, name, military, power, wisdom, politics, charm FROM TblGenerals;";
            string strCount = "SELECT COUNT(*) FROM TblGenerals;";
            DataSet data = new DataSet();
            ArrayList generals = new ArrayList();

            try
            {
                helper.RunSQL(strCount, ref data);
                if (data.Tables[0] != null)
                {
                    //Response.Write(data.Tables[0].Rows[0][0]);
                    int count = int.Parse(data.Tables[0].Rows[0][0].ToString());
                    data = new DataSet();
                    double[][] generalProperties = new double[count][];
                    helper.RunSQL(strQuery, ref data);
                    if (data.Tables[0] != null)
                    {
                        DataTable table = data.Tables[0];
                        int index = 0;
                        foreach (DataRow row in table.Rows)
                        {
                            General general = new General(
                                row["name"].ToString(),
                                Convert.ToDouble(row["military"]),
                                Convert.ToDouble(row["power"]),
                                Convert.ToDouble(row["power"]),
                                Convert.ToDouble(row["politics"]));
                            generals.Add(general);
                            generalProperties[index] = general.GetData;
                            index++;
                        }
                        int[] clustering = ClassKmeans.Cluster(generalProperties, k);
                        ShowClustered(generals, clustering, k, 1);
                    }
                }
            }
            catch (Exception exception)
            {
                Response.Write(exception.Message);
                throw;
            }
        }

        public void ShowClustered(ArrayList data, int[] clustering, int numClusters, int decimals)
        {
            for (int k = 0; k < numClusters; k++)
            {
                Response.Write("第"+(k+1).ToString()+"组"+"==========================<br /><table border=\"1\">");
                Response.Write("<tr><td>编号</td><td>姓名</td><td>军事</td><td>武力</td><td>智力</td><td>政治</td></tr>");
                for (int i = 0; i < data.Count; i++)
                {
                    int clusterID = clustering[i];
                    if (clusterID != k)
                        continue;
                    Response.Write("<tr>");
                    Response.Write("<td>第" + (i + 1).ToString() + "项</td>");
                    Response.Write("<td>"+((General)data[i]).Name + "</td><td>" +
                        ((General)data[i]).Military.ToString() + "</td><td>" +
                        ((General)data[i]).Power.ToString() + "</td><td>" +
                        ((General)data[i]).Wisdom.ToString() + "</td><td>" +
                        ((General)data[i]).Politics.ToString() + "</td></tr>");
                }
                Response.Write("</table>==========================<br />");
            }
        }

    }

    public class General
    {
        private string name;
        private double military;
        private double power;
        private double wisdom;
        private double politics;

        public General(string name, double military, double power, double wisdom, double politics)
        {
            this.name = name;
            this.military = military;
            this.power = power;
            this.wisdom = wisdom;
            this.politics = politics;
        }

        public string Name { get => name; set => name = value; }
        public double Military { get => military; set => military = value; }
        public double Power { get => power; set => power = value; }
        public double Wisdom { get => wisdom; set => wisdom = value; }
        public double Politics { get => politics; set => politics = value; }
        public double[] GetData { get => new double[] { military, power, wisdom, politics }; }
    }
}