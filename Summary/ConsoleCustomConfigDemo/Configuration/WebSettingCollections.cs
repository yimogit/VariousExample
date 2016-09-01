using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCustomConfigDemo.Configuration
{
    public class WebSettingCollections : ConfigurationElementCollection
    {

        public new WebSettingElement this[string prefix]
        {
            get
            {
                return BaseGet(prefix) as WebSettingElement;
            }
        }
        public override ConfigurationElementCollectionType CollectionType
        {
            get
            {
                return ConfigurationElementCollectionType.AddRemoveClearMap;
            }
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new WebSettingElement();
        }

        protected override Object GetElementKey(ConfigurationElement element)
        {
            return ((WebSettingElement)element).Key;
        }
        private static WebSettingModel _model;
        /// <summary>
        /// 获取配置模型
        /// </summary>
        /// <returns></returns>
        public WebSettingModel GetModel()
        {
            if (_model == null)
            {
                lock (typeof(WebSettingModel))
                {
                    if (_model == null)
                    {
                        _model = new WebSettingModel();
                    }
                }
            }
            return _model;
        }
    }
    public class WebSettingModel
    {
        public string SiteUrl
        {
            get
            {
                return SiteConfig.Instance.WebSettings["siteUrl"].Value;
            }
        }

        public string LoginUrl
        {
            get
            {
                return SiteConfig.Instance.WebSettings["loginUrl"].Value;
            }
        }

        public string WebAuthCookieName
        {
            get
            {
                return SiteConfig.Instance.WebSettings["webAuthCookieName"].Value;
            }
        }

        public string AdminAuthCookieName
        {
            get
            {
                return SiteConfig.Instance.WebSettings["adminAuthCookieName"].Value;
            }
        }
    }
}
