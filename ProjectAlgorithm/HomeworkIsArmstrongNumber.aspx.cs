using System;

namespace ProjectAlgorithm
{
    public partial class HomeworkIsArmstrongNumber : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnCheck_Click(object sender, EventArgs e)
        {
            try
            {
                uint input = uint.Parse(TxtInput.Text);
                if (TxtInput.Text.Length >= 3)
                {
                    if (IsArmstrongNumber(input))
                    {
                        Response.Write(TxtInput.Text + "是水仙花数");
                    }
                    else
                    {
                        Response.Write(TxtInput.Text + "不是水仙花数");
                    }
                }
                else
                {
                    Response.Write("数字过小，请输入大于三位的数。");
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        private bool IsArmstrongNumber(uint num)
        {
            uint sum = 0;
            int digits = TxtInput.Text.Length;

            for (int i = 0; i < digits; ++i)
            {
                sum += (uint)Math.Pow(uint.Parse(num.ToString()[i].ToString()), digits);
            }
            return (sum == num);
        }
    }
}