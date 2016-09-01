using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace ConsoleCustomConfigDemo.Configuration
{
    public class SiteConfig : ConfigurationSection
    {
        private SiteConfig() { }
        private static SiteConfig s_instance;
        private static bool s_instanceLoaded;

        public static SiteConfig Instance
        {
            get
            {
                if (!s_instanceLoaded)
                {
                    lock (typeof(SiteConfig))
                    {
                        if (!s_instanceLoaded)
                        {
                            //读取配置节点，若打开失败需要将文件属性改为始终复制
                            s_instance = (SiteConfig)ConfigurationManager.GetSection("SiteConfig");
                            s_instanceLoaded = true;
                        }
                    }
                }
                return s_instance;
            }
        }
        [ConfigurationProperty("webSettings", IsRequired = true)]
        public WebSettingCollections WebSettings
        {
            get
            {
                return (WebSettingCollections)this["webSettings"];
            }
        }
        [ConfigurationProperty("uploadSettings", IsRequired = true)]
        public UploadSettingElement UploadSettings
        {
            get
            {
                return (UploadSettingElement)this["uploadSettings"];
            }
        }
        [ConfigurationProperty("connections")]
        public ConnectionsCollections Connections
        {
            get
            {
                return (ConnectionsCollections)base["connections"];
            }
        }
    }
}
