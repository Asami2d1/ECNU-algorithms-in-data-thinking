using System;

namespace DataAlgo
{
    public partial class homeworkID_aspx : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCheck_Click(object sender, EventArgs e)
        {
            lblBirthday.Text = lblGender.Text = "";
            int[] coefficients = new int[17] { 7, 9, 10, 5, 8, 4, 2, 1, 6, 3, 7, 9, 10, 5, 8, 4, 2 };
            char[] lastCh = new char[11] { '1', '0', 'X', '9', '8', '7', '6', '5', '4', '3', '2' };

            string id = txtId.Text;
            if (id.Length == 18)
            {
                id = id.ToUpper();

                int sum = 0;

                for (int i = 0; i < 17; i++)
                    sum += int.Parse(id[i].ToString()) * coefficients[i];

                if (lastCh[sum % 11] == id[id.Length - 1])
                {
                    // Response.Write("合法");
                    string strBirthday = "出生日期" + id.Substring(6, 4) + "年" +
                        id.Substring(10, 2) + "月" + id.Substring(12, 2) + "日";
                    lblBirthday.Text = strBirthday;
                    lblGender.Text = "性别为" + ((int.Parse(id[id.Length - 2].ToString()) % 2 == 0) ? "女" : "男");
                }
                else
                {
                    lblBirthday.Text = "身份证不合法";
                }
            }
            else
            {
                lblBirthday.Text = "身份证不合法";
            }
        }
    }
}