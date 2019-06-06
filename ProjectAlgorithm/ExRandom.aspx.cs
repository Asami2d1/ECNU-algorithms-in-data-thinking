using System;

namespace ProjectAlgorithm
{
    public partial class ExRandom : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bool[] isNumExist = new bool[100];
            for (int i = 0; i < 100; ++i)
            {
                isNumExist[i] = false;
            }
            Random random = new Random();
            for (int i = 0; i < 99; i++)
            {
                int randnum = random.Next(1, 101);
                if (isNumExist[randnum - 1])
                {
                    i--;
                    continue;
                }
                isNumExist[randnum - 1] = true;
                Response.Write(randnum.ToString() + "<br />");
            }
        }
        private void Swap(ref int a, ref int b)
        {
            int t = a;
            a = b;
            b = t;
        }
        private void Sort(ref int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = arr.Length-1; j > i; j--)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        Swap(ref arr[j], ref arr[j + 1]);
                    }
                }
            }
        }
    }
}