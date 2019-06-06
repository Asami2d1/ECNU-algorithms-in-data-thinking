using System;
using System.Text.RegularExpressions;
using Common.AITools.Tvbboy;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectCrawler
{
    public partial class ExampleCrawLink : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HrefCrawler();
        }

        public void HrefCrawler()
        {
            var hrefList = new List<ExampleMyHref>();
            string initurl =
                "http://tieba.baidu.com/f?kw=%E5%8D%8E%E4%B8%9C%E5%B8%88%E8%8C%83%E5%A4%A7%E5%AD%A6&ie=utf-8";
            string result = string.Empty;
            var hrefCrawler = new SimpleCrawler {url = new Uri(initurl)};
            Response.Write($"爬虫开始抓取地址: {hrefCrawler.url.ToString()} <br />");
            hrefCrawler.OnError += (s, e) => { Response.Write($"爬虫抓取出现错误, 异常信息: {e.Exception.Message}"); };
            hrefCrawler.OnCompleted += (s, e) =>
            {
                // 使用正则表达式清洗数据
                var links = Regex.Matches(e.PageSource,
                    @"<a[^>]+href=""*(?<href>[^>\s]+)""\s*[^>]*>(?<text>(?!.*img).*?)</a>",
                    RegexOptions.IgnoreCase);
                foreach (Match match in links)
                {
                    var h = new ExampleMyHref
                    {
                        HrefTitle = match.Groups["text"].Value,
                        HrefSrc = match.Groups["href"].Value
                    };
                    if (!hrefList.Contains(h))
                    {
                        hrefList.Add(h);
                        result += h.HrefTitle + "|" + h.HrefSrc + "<br />";
                    }
                }
                Response.Write("======================================<br />");
                Response.Write($"爬虫抓取任务完成！合计 {links.Count} 个超级链接。 <br />");
                Response.Write($"耗时: {e.Milliseconds} 毫秒<br />");
                Response.Write($"线程: {e.ThreadId} <br />");
                Response.Write(result);
                Response.Write("======================================<br />");
            };
            hrefCrawler.start();
        }
    }
}