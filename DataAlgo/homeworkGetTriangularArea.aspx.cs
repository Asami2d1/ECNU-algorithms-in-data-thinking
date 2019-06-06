using System;

namespace DataAlgo
{
    public partial class homeworkGetTriangularArea : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGetArea_Click(object sender, EventArgs e)
        {
            double lengthA = double.Parse(txtLengthA.Text);
            double lengthB = double.Parse(txtLengthB.Text);
            double lengthC = double.Parse(txtLengthC.Text);

            if (lengthA <= 0 || lengthB <= 0 || lengthC <= 0 ||
                lengthA + lengthB <= lengthC ||
                lengthA + lengthC <= lengthB ||
                lengthB + lengthC <= lengthA)
            {
                lblAns.Text = " 你输入的三条边不能构成1个三角形";
            }
            else
            {
                //计算三角形面积
                double lengthP = (lengthA + lengthB + lengthC) / 2; //半周长
                double s = Math.Sqrt(lengthP * (lengthP - lengthA) * (lengthP - lengthB) * (lengthP - lengthC));

                //计算三个对角的余弦值
                double cosA = (lengthB * lengthB + lengthC * lengthC - lengthA * lengthA) / (2 * lengthB * lengthC);
                double cosB = (lengthA * lengthA + lengthC * lengthC - lengthB * lengthB) / (2 * lengthA * lengthC);
                double cosC = (lengthA * lengthA + lengthB * lengthB - lengthC * lengthC) / (2 * lengthB * lengthC);

                double angleType = cosA * cosB * cosC; //=0,<0,>0分别表示直角,钝角,锐角
                bool isIsosceles = cosA == cosB || cosA == cosC || cosB == cosC; //是否等腰
                bool isEquilateral = cosA == cosB && cosA == cosC; //是否等边  

                lblAns.Text = "你输入的三条边组成了一个" +
                    (isEquilateral ? "等边" : (isIsosceles ? "等腰" : "一般")) +
                    (angleType == 0 ? "直角" : (angleType < 0 ? "钝角" : "锐角")) +
                    "三角形，它的面积是" + s;

            }
        }
    }
}