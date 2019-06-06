using System;
using System.IO;
using JiebaNet.Segmenter;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectWordSegmenter
{
    public partial class ExampleSanGuo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var segmenter = new JiebaSegmenter();
            string aimFile = @"./Resources/三国演义.txt";
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
                //对长度大于等于 2 并且小于等于 4 的词进行统计
                if (item.Length >= 2 && item.Length <= 4)
                {
                    if (!persons.ContainsKey(item))
                    {
                        int f = GetFrequence(wordsforSearch, item);//统计词频
                        persons.Add(item.Trim(), f);
                        //出于测试需要只对频率 100 以上的关键词，制作词云
                        if (f >= 100 && f != 2406)
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
            WriteData("test.json", jsonstr);
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
            Response.Write("</br>Stopwatch 总共花费{0}ms." + ts2.TotalMilliseconds.ToString());
        }

        protected void BtnAll_Click(object sender, EventArgs e)
        {
            var segmenter = new JiebaSegmenter();
            string aimFile = @"./Resources/三国演义.txt";
            string content = ReadData(aimFile);
            var wordsforSearch = segmenter.Cut(content, cutAll: true);
            Response.Write("</br>【全模式】：{0}" + string.Join("/ ", wordsforSearch));
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

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            var segmenter = new JiebaSegmenter();
            string aimFile = @"./Resources/三国演义.txt";
            string content = ReadData(aimFile);
            var wordsforSearch = segmenter.CutForSearch(content);
            Response.Write("</br>【搜索引擎模式】：{0}" + string.Join("/ ", wordsforSearch));
        }

        /// <summary>
        /// 统计某个特殊单词，再文章中出现的次数
        /// </summary>
        /// <param name="content"></param>
        /// <param name="specficword"></param>
        /// <returns></returns>
        public int GetFrequence(IEnumerable<string> content, string specficword)
        {
            int ret = 0;
            foreach (string item in content)
            {
                if (item == specficword)
                    ret++;
            }
            return ret;
        }

        /// <summary>
        /// C#数组去掉重复的元素
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        string[] DelRepeatData(string[] a)
        {
            return a.GroupBy(p => p).Select(p => p.Key).ToArray();
        }

        /// <summary>
        /// 将某个内容写入到 JSON 文件中
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="fileContent"></param>
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

    }
}