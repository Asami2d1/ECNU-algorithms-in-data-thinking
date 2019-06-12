using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using Common.AITools.Tvbboy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectCrawler
{
    public partial class ExampleDownloadPictures : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<string> imgList = IMGCrawler();
            string folder = "~/Pictures";
            foreach (var img in imgList)
            {
                DownloadingImage(img, folder);
            }
        }

        public List<string> IMGCrawler()
        {
            string initurl = "http://www.hr.ecnu.edu.cn/s/116/t/209/p/1/c/3538/d/7465/i/{0}/list.htm";
            List<string> imgList = new List<string>();
            for (int i = 1; i <= 12; i++)
            {
                string strResult = string.Empty;
                var imgCrawler = new SimpleCrawler();
                imgCrawler.url = new Uri(string.Format(initurl, i));
                Response.Write("开始爬取地址" + imgCrawler.url.ToString() + "<br />");
                imgCrawler.OnError += (s, e) => { Response.Write(" 爬虫抓取出现错误，异常消息： ：" + e.Exception.Message); };
                imgCrawler.OnCompleted += (s, e) =>
                {
                    // 使用正则表达式清洗数据
                    var imgs = Regex.Matches(e.PageSource,
                        @"<img\b[^<>]*?\bsrc[\s\t\r\n]*=[\s\t\r\n]*[""']?[\s\t\r\n]*(?<imgUrl>/picture/article/116/[^<>\s\t\r\n]+\.jpg)[^<>]*?/?[\s\t\r\n]*>",
                        RegexOptions.IgnoreCase);
                    foreach (Match match in imgs)
                    {
                        if (!imgList.Contains(match.Groups["imgUrl"].Value))
                        {
                            imgList.Add("http://www.hr.ecnu.edu.cn" + match.Groups["imgUrl"].Value);
                        }
                    }
                };

                imgCrawler.start();
            }

            return imgList;
        }

        public void DownloadingImage(string url, string VirtualFolder)
        {
            try
            {
                string LocalFolder = Server.MapPath(VirtualFolder);
                if (!Directory.Exists(LocalFolder))
                    Directory.CreateDirectory(LocalFolder);
                string ext = string.Empty;
                ext = url.Substring(url.Length - 3, 3);
                string filename = DateTime.Now.ToString("yyyyMMddHHmmssffff") + "." + ext;
                WebClient my = new WebClient();
                byte[] myBytes;
                myBytes = my.DownloadData(url);
                MemoryStream ms = new MemoryStream(myBytes);
                System.Drawing.Image img;
                img = System.Drawing.Image.FromStream(ms);
                switch (ext.ToLower())
                {
                    case "gif":
                        img.Save(Path.Combine(LocalFolder, filename), ImageFormat.Gif);
                        break;
                    case "png":
                        img.Save(Path.Combine(LocalFolder, filename), ImageFormat.Png);
                        break;
                    case "jpeg":
                    case "jpg":
                        img.Save(Path.Combine(LocalFolder, filename), ImageFormat.Jpeg);
                        break;

                }
            }
            catch (Exception e)
            {
                Response.Write(e.Message);
            }
        }
    }
}