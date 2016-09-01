using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Example.Core;
using Autofac;
using Autofac.Configuration;

namespace StackExchangeRedisTest
{
    class Program
    {
        static void Main(string[] args)
        {
            LoadRedisValue();
            LoadRedisValueByAutofac();
        }

        private static void LoadRedisValueByAutofac()
        {
            var build = new ContainerBuilder();
            build.RegisterModule(new ConfigurationSettingsReader("autofac"));
            using (var container = build.Build())
            {
                var cacheManger = container.Resolve<ICacheManager>();
                var value = cacheManger.Get<string>("string", () => { return "我是一个字符串"; });
                Console.WriteLine("使用autofac配置方式注入接口的方式获取redis值："+value);
            }
        }

        private static void LoadRedisValue()
        {
            ICacheManager cacheManger = new RedisManager();
            cacheManger.Remove("string");
            var value = cacheManger.Get<string>("string", () => { return "我是一个字符串"; });
            var value2 = cacheManger.Get<string>("string");
            Console.WriteLine("创建对象的方式获取redis的值"+value2);
        }

    }
}
