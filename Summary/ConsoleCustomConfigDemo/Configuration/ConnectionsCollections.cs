using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace ConsoleCustomConfigDemo.Configuration
{
    public class ConnectionsCollections : ConfigurationElementCollection
    {
        public override ConfigurationElementCollectionType CollectionType
        {
            get
            {
                return ConfigurationElementCollectionType.AddRemoveClearMap;
            }
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new ConnectionElement();
        }

        protected override Object GetElementKey(ConfigurationElement element)
        {
            return ((ConnectionElement)element).Name;
        }

        public new ConnectionElement this[string name]
        {
            get
            {
                return (ConnectionElement)this.BaseGet(name);
            }
        }
    }
}
