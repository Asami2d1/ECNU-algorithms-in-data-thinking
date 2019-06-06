using Common.AITools.Tvbboy;
using System;
using System.Collections;

namespace ProjectAlgorithm
{
    public partial class ExampleDijkstra : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ArrayList nodeList = new ArrayList();
            //Node aNode = new Node("北京");
            //nodeList.Add(aNode);
            //aNode.EdgeList.Add(new Edge("北京", "上海", 20));
            //aNode.EdgeList.Add(new Edge("北京", "武汉", 40));

            Node bNode = new Node("上海");
            nodeList.Add(bNode);
            bNode.EdgeList.Add(new Edge("上海", "北京", 20));
            bNode.EdgeList.Add(new Edge("上海", "武汉", 70));

            Node cNode = new Node("武汉");
            nodeList.Add(cNode);
            cNode.EdgeList.Add(new Edge("武汉", "北京", 40));
            cNode.EdgeList.Add(new Edge("武汉", "上海", 70));

            RoutePlanner planner = new RoutePlanner();
            RoutePlanResult result = null;

            result = planner.Paln(nodeList, "武汉", "上海");
            Response.Write("距离为" + result.getWeight());
            printRouteResult(result);
            Response.Write("上海");
            Response.Write("<br />");
            planner = null;
        }

        private void printRouteResult(RoutePlanResult result)
        {
            Response.Write("<br />路径");
            string[] tmp = result.getPassedNodeIDs();
            for (int i = 0; i < tmp.Length; i++)
            {
                Response.Write(tmp[i] + "--");
            }
        }
    }
}