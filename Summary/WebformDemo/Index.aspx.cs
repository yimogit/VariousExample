using Autofac;
using Example.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebformDemo
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
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
            Response.Write("写入日志成功");
        }
    }
}