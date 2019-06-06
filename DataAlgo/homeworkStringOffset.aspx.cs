using System;

namespace DataAlgo
{
    public partial class homeworkStringOffset : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnConvert_Click(object sender, EventArgs e)
        {
            lblOutput.Text = "";
            string inputStr = txtInputStr.Text;
            ushort offset = ushort.Parse(txtOffset.Text);
            char c;

            for (int i = 0; i < inputStr.Length; ++i)
            {
                c = inputStr[i];

                if ((c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z'))
                {
                    int value = (c - ((c >= 'A' && c <= 'Z') ? 'A' : 'a') + offset) % 26; //转换为(mod 26)的完系上的运算
                    value += ((c >= 'A' && c <= 'Z') ? 'A' : 'a');
                    c = Convert.ToChar(value); //还原
                }

                lblOutput.Text += c;
            }
        }
    }
}