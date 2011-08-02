using System;
using System.Configuration;

namespace DatabaseCleaner.Configuration
{
    public class DatabaseCleanerSection : ConfigurationSection
    {
        [ConfigurationProperty("Strategies", IsDefaultCollection = false),
         ConfigurationCollection(typeof(StrategyElementCollection))]
        public StrategyElementCollection Strategies
        {
            get { return this["Strategies"] as StrategyElementCollection; }
        }
    }
}
