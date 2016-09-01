using ConsoleCustomConfigDemo.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCustomConfigDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //var abc = Configuration.SiteConfig.Instance.Connections;
            //Console.WriteLine(abc["SiteWebDb"].ConnectionString);
            //Console.WriteLine(SiteConfig.Instance.WebSettings["siteUrl"].Value);
            //Console.WriteLine(SiteConfig.Instance.WebSettings.GetModel().LoginUrl);
            //获取上传设置
            var us = SiteConfig.Instance.UploadSettings;
            var t = us.GetType();
            Console.WriteLine("------------------------Method------------------------\r\n");
            t.GetMethods().ToList().ForEach(e => { Console.WriteLine(e); });

            Console.WriteLine("------------------------Fields------------------------\r\n");
            t.GetFields().ToList().ForEach(e => { Console.WriteLine(e); });

            Console.WriteLine("------------------------GetMembers------------------------\r\n");
            t.GetMembers().ToList().ForEach(e => { Console.WriteLine(e); });

            Console.WriteLine("------------------------GetProperties------------------------\r\n");
            t.GetProperties().ToList().ForEach(e => { Console.WriteLine(e); });

            Console.WriteLine("------------------------GetConstructors------------------------\r\n");
            t.GetConstructors().ToList().ForEach(e => { Console.WriteLine(e); });

            //获取属性：值
            Console.WriteLine("------------------------取属性：值------------------------\r\n");
            t.GetProperties().ToList().ForEach(e => { Console.WriteLine(e.Name + "：" + e.GetCustomAttributes(false).Any(item => item is System.Configuration.ConfigurationPropertyAttribute) + "-->" + e.GetValue(us, null)); });



            Console.WriteLine(SiteConfig.Instance.UploadSettings.DownloadUrl);


        }
    }
}
