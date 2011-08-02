using System;
using System.Configuration;

namespace DatabaseCleaner.Configuration
{
    public class StrategyElement : ConfigurationElement
    {
        [ConfigurationProperty("name", IsRequired = true)]
        public string Name
        {
            get { return (string)this["name"]; }
            set { this["name"] = value; }
        }

        [ConfigurationProperty("type", IsRequired = true)]
        public string Type
        {
            get { return (string)this["type"]; }
            set { this["type"] = value; }
        }

        public StrategyElement() { }

        public StrategyElement(string name, string type)
        {
            Name = name;
            Type = type;
        }
    }
}
