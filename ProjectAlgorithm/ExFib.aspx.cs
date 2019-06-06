using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectAlgorithm
{
    public partial class ExFib : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnFib_Click(object sender, EventArgs e)
        {
            long num = long.Parse(TxtNum.Text);
            Response.Write(Fib2(num));
        }

        private long Fib(long num)
        {
            if (num == 1 || num == 2)
            {
                return 1; 
            }
            return Fib(num - 1) + Fib(num - 2);
        }

        private long Fib2(long num)
        {
            return FibIter(2, 1, 0, num);
        }

        private long FibIter(long a, long b, long c, long count)
        {
            if (count == 0)
            {
                return c;
            }
            else
            {
                count--;
                return FibIter(a + 2 * b + 3 * c, a, b, count);
            }
        }
    }
}