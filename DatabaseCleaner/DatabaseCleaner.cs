using System;
using System.Collections.Generic;
using System.Configuration;
using DatabaseCleaner.Configuration;

namespace DatabaseCleaner
{
    public class DatabaseCleaner : IDatabaseCleaner
    {
        private IList<ICleaningStrategy> _strategies;
        private static IDatabaseCleaner _current;

        public static IDatabaseCleaner Current
        {
            get
            {
                if (_current == null)
                    _current = new DatabaseCleaner();
                return _current;
            }
        }

        public IList<ICleaningStrategy> Strategies
        {
            get
            {
                return _strategies;
            }
        }

        private DatabaseCleaner()
        {
            DatabaseCleanerSection settings = ConfigurationManager.GetSection("DatabaseCleaner") as DatabaseCleanerSection;
            if (settings == null)
            {
                throw new ConfigurationErrorsException(Properties.Resources.DatabaseCleanerConfigurationException);
            }
            _strategies = settings.Strategies.ToStrategies();
        }
    }
}
