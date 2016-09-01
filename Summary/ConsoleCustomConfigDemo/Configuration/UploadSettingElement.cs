using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace ConsoleCustomConfigDemo.Configuration
{
    public class UploadSettingElement : ConfigurationElement
    {
        [ConfigurationProperty("uploadPath", IsRequired = false, DefaultValue = @"c:\upload")]
        public string UploadPath
        {
            get
            {
                return (string)this["uploadPath"];
            }
        }

        [ConfigurationProperty("downloadUrl", IsRequired = true)]
        public string DownloadUrl
        {
            get
            {
                return (string)this["downloadUrl"];
            }
        }

        [ConfigurationProperty("uploadServerUrl", IsRequired = false)]
        public string UploadServerUrl
        {
            get
            {
                return (string)this["uploadServerUrl"];
            }
        }

        [ConfigurationProperty("isEnableLocalPath", IsRequired = false)]
        public string IsEnableLocalPath
        {
            get
            {
                return (string)this["isEnableLocalPath"];
            }
        }

        [ConfigurationProperty("key", IsRequired = true)]
        public string Key
        {
            get
            {
                return (string)this["key"];
            }
        }

    }

}
