using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace ConsoleCustomConfigDemo.Configuration
{
    public class ConnectionElement : ConfigurationElement
    {
        [ConfigurationProperty("name", IsRequired = true, IsKey = true)]
        public string Name
        {
            get
            {
                return this["name"].ToString();
            }
        }

        [ConfigurationProperty("connectionString", IsRequired = true, IsKey = false)]
        public string ConnectionString
        {
            get
            {
                return (string)this["connectionString"];
            }
        }
    }
}
