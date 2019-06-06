using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Common.AITools.Tvbboy;
using JiebaNet.Segmenter;
using JiebaNet.Segmenter.Common;


namespace ProjectCrawler
{
    public partial class HomeworkTiebaCrawler : System.Web.UI.Page
    {
        private readonly string SESSION_NAME = "ListResultHrefs"; //缓存的key
        protected void Page_Load(object sender, EventArgs e)
        {
            List<ExampleMyHref> resultHrefs;
            if (!IsPostBack)
            {
                Session.RemoveAll(); //清空已有缓存以免冲突
                resultHrefs = HrefCrawler(15); //爬取前15页

                //分词并保存, 词频大于20的写入json
                var segmenter = new JiebaSegmenter();
                string allTItles = "";
                foreach (ExampleMyHref href in resultHrefs)
                {
                    allTItles += href.HrefTitle + ";";
                    href.KeywordList = new List<string>();
                    var word4Search = segmenter.CutForSearch(href.HrefTitle);
                    foreach (var word in word4Search)
                    {
                        if (!href.KeywordList.Contains(word))
                        {
                            href.KeywordList.Add(word);
                        }
                    }
                }
                var allWords = segmenter.CutForSearch(allTItles);
                Dictionary<string, int> wordsInts = new Dictionary<string, int>();
                string jsonstr = "[";
                int i = 0;
                foreach (var item in allWords.Distinct<string>())
                {
                    if (item.Length >= 2 && item.Length <= 5)
                    {
                        if (!wordsInts.ContainsKey(item))
                        {
                            int f = GetFrequency(allWords, item); //统计词频
                            wordsInts.Add(item.Trim(), f);
                            if (f >= 20)
                            {
                                if (i == 0)
                                    jsonstr += "{\"name\":\"" + item.Trim() + "\",\"value\":" + f + "}";
                                else
                                    jsonstr += ",{\"name\":\"" + item.Trim() + "\",\"value\":" + f + "}";
                                i++;
                            }
                        }
                    }
                }
                jsonstr += "]";
                WriteData("tieba.json", jsonstr);

                Session[SESSION_NAME] = resultHrefs;  //使用Session缓存查询到的数据
            }
        }

        public List<ExampleMyHref> HrefCrawler(int maxPages)
        {
            var hrefList = new List<ExampleMyHref>();
            var urlList = new List<string>();
            string urlTemplate = "http://tieba.baidu.com/f?kw=linux&ie=utf-8&pn={0}";
            for (var i = 0; i < maxPages; i++)
            {
                urlList.Add(string.Format(urlTemplate, (i + 1) * 50));
            }

            var hrefCrawler = new SimpleCrawler();
            //string result = string.Empty;
            int j = 1;
            foreach (var url in urlList)
            {
                hrefCrawler.url = new Uri(url);
                //Response.Write($"爬虫开始抓取地址: {hrefCrawler.url.ToString()} <br />");
                hrefCrawler.OnError += (s, e) => { Response.Write($"爬虫抓取出现错误, 异常信息: {e.Exception.Message}"); };
                hrefCrawler.OnCompleted += (s, e) =>
                {
                    // 使用正则表达式清洗数据
                    var links = Regex.Matches(e.PageSource,
                        @"<a[^>]+href=""*(?<href>/p[^>\s]+)""\s*[^>]*>(?<text>(?!.*img).*?)</a>",
                        RegexOptions.IgnoreCase);
                    foreach (Match match in links)
                    {
                        var h = new ExampleMyHref
                        {
                            HrefTitle = match.Groups["text"].Value,
                            HrefSrc = "https://tieba.baidu.com" + match.Groups["href"].Value,
                            KeywordList = null
                        };
                        if (!hrefList.Contains(h))
                        {
                            hrefList.Add(h);
                            //result += h.HrefTitle + "|" + h.HrefSrc + "<br />";
                        }
                    }
                };
                hrefCrawler.start();
                j++;
            }

            return hrefList;
        }

        public void WriteData(string filePath, string fileContent)
        {
            string aimfilepath = MapPath(filePath);//将虚拟路径转为实际路径
            if (File.Exists(aimfilepath))
            {
                // 如果文件已经存在则删掉重写
                File.Delete(aimfilepath);
            }
            using (FileStream fs = new FileStream(aimfilepath, FileMode.OpenOrCreate))
            {
                StreamWriter sw = new StreamWriter(fs);
                sw.Write(fileContent);
                sw.Close();
            }
        }
        public int GetFrequency(IEnumerable<string> content, string specficword)
        {
            return content.Count(item => item == specficword);
        }

        protected void BtnSearch_OnClick(object sender, EventArgs e)
        {
            string strSearch = TxtKeyword.Text;
            var segmenter = new JiebaSegmenter();
            var searchKeywords = segmenter.CutForSearch(strSearch); //为了尽可能匹配到将搜索内容也分解为关键字
            var searchResults = new List<ExampleMyHref>();
            var resultHrefs = (List<ExampleMyHref>)Session[SESSION_NAME]; //读取缓存
            var hrefUrls = new List<string>(); // 用于去重

            foreach (var href in resultHrefs)
            {
                if (!hrefUrls.Contains(href.HrefSrc))
                {
                    foreach (var hrefKeyword in href.KeywordList)
                    {
                        if (searchKeywords.Contains(hrefKeyword))
                        {
                            hrefUrls.Add(href.HrefSrc);
                            searchResults.Add(href);
                            break;
                        }
                    }
                }
            }

            if (searchResults.IsNotEmpty())
            {
                foreach (var item in searchResults)
                {
                    string resulttag = "<a href=\"" + item.HrefSrc + "\">" + item.HrefTitle + "</a><br />";
                    Response.Write(resulttag);
                    //Response.Write(item.HrefTitle + "|" + item.HrefSrc + "<br />");
                }
            }
            else
            {
                Response.Write("没有找到相关内容<br />");
            }
        }
    }
}
