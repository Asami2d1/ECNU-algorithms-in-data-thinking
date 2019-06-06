using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using JiebaNet.Segmenter;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectWordSegmenter
{
    public partial class HomeworkSegmentationStoryCut : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var segmenter = new JiebaSegmenter();
            var blacklist = ReadBlacklist("./Resources/OrdinaryWorldBlacklist.txt");
            string aimFile = @"./Resources/平凡的世界.txt";
            string content = ReadData(aimFile);
            Stopwatch sw = new Stopwatch();
            sw.Start();
            //搜索引擎模式分词
            var wordsforSearch = segmenter.CutForSearch(content);
            //定义数据结构 persons ，放置人名和词频
            Dictionary<string, int> persons = new Dictionary<string, int>();
            //将要以 JSON 格式输出的字符串，将其写到 JSON 文件中，就可以实现词云图
            string jsonstr = "[";
            int i = 0;
            foreach (string item in wordsforSearch.Distinct<string>())
            {
                //对长度大于等于 2 并且小于等于 5 的词进行统计
                if (item.Length >= 2 && item.Length <= 5)
                {
                    if (!persons.ContainsKey(item) && !blacklist.Contains(item))
                    {
                        int f = GetFrequence(wordsforSearch, item);//统计词频
                        persons.Add(item.Trim(), f);
                        //出于测试需要只对频率 100 以上的关键词，制作词云
                        if (f >= 100 && f != 19970)
                        {
                            //第一个前不用加逗号，目的是构造一个 A,B,C,D,.....，注意除了 A 之外，每一个
                            //字母前都有逗号
                            if (i == 0)
                                jsonstr += "{\"name\":\"" + item.Trim() + "\",\"value\":" + f + "}";
                            else
                                jsonstr += ",{\"name\":\"" + item.Trim() + "\",\"value\":" + f + "}";
                            i++;
                        }
                    }
                }
            }//end of foreach
            jsonstr += "]";
            WriteData("Story.json", jsonstr);
            persons = (from entry in persons
                       orderby entry.Value descending
                       select entry).ToDictionary(pair => pair.Key, pair => pair.Value);
            string result = "";
            foreach (var person in persons)
            {
                if (person.Value >= 100)
                    result += ("<br>" + person.Key + "-" + person.Value.ToString());
            }
            Response.Write(result);
            sw.Stop();
            TimeSpan ts2 = sw.Elapsed;
            Response.Write($"</br>Stopwatch 总共花费{ts2.TotalMilliseconds.ToString()}ms.");
        }

        public int GetFrequence(IEnumerable<string> content, string specficword)
        {
            return content.Count(item => item == specficword);
        }

        public void WriteData(string filePath, string fileContent)
        {
            string aimfilepath = MapPath(filePath);//将虚拟路径转为实际路径
            using (FileStream fs = new FileStream(aimfilepath, FileMode.OpenOrCreate))
            {
                StreamWriter sw = new StreamWriter(fs);
                sw.Write(fileContent);
                sw.Close();
            }
        }

        public string ReadData(string filepath)
        {
            //C#读取 TXT 文件之建立 FileStream 的对象,说白了告诉程序,
            //文件在那里,对文件如何 处理,对文件内容采取的处理方式
            System.Text.Encoding code = System.Text.Encoding.GetEncoding("gb2312");
            FileStream fs = new FileStream(Server.MapPath(filepath), FileMode.Open, FileAccess.Read);
            //仅 对文本 执行 读写操作
            StreamReader sr = new StreamReader(fs, code);
            //定位操作点,begin 是一个参考点 
            sr.BaseStream.Seek(0, SeekOrigin.Begin);
            //读一下，看看文件内有没有内容，为下一步循环 提供判断依据
            //sr.ReadLine() 这里是 StreamReader 的要领 可不是 console 中的~
            string str = sr.ReadToEnd();//假如 文件有内容
            //C#读取 TXT 文件之关上文件，留心顺序，先对文件内部执行 关上，然后才是文件~
            sr.Close();
            fs.Close();
            return str;
        }

        public ArrayList ReadBlacklist(string filePath)
        {
            var blacklist = new ArrayList();
            var code = System.Text.Encoding.GetEncoding("gb2312");
            FileStream fileStream = new FileStream(Server.MapPath(filePath), FileMode.Open, FileAccess.Read);
            using (var sr = new StreamReader(fileStream, code))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    blacklist.Add(line);
                }
            }
            return blacklist;
        }
    }
}