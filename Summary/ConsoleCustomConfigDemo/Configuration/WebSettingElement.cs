using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace ConsoleCustomConfigDemo.Configuration
{
    public class WebSettingElement : ConfigurationElement
    {

        [ConfigurationProperty("key", IsRequired = true, IsKey = true)]
        public string Key
        {
            get
            {
                return this["key"].ToString();
            }
        }

        [ConfigurationProperty("value", IsRequired = true, IsKey = false)]
        public string Value
        {
            get
            {
                return (string)this["value"];
            }
        }
    }
}
