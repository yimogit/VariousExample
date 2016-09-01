using Example.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
namespace ConsoleDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //1.不使用autofac写日志
            //OldMethod();

            #region 2.使用autofac写日志
            var builder = new ContainerBuilder();
            builder.RegisterType<FileLogger>();
            builder.Register<ILogger>(c => new FileLogger()).InstancePerLifetimeScope();
            //builder.RegisterType<FileLogger>();
            //builder.RegisterType<FileLogger>().As<ILogger>();
            using (var container = builder.Build())
            {
                ILogger logger = container.Resolve<ILogger>();
                logger.Info("使用autofac写入日志");
            }
            #endregion

        }
        static void OldMethod()
        {
            ILogger logger = new FileLogger();
            logger.Info("创建对象的方式写入日志信息");
        }




    }
}
