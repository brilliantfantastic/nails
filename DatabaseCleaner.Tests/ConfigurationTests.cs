using System;
using NUnit.Framework;
using System.Configuration;
using DatabaseCleaner.Configuration;

namespace DatabaseCleaner.Tests
{
    [TestFixture()]
    public class ConfigurationTests
    {
        [Test()]
        public void Test_Strategies_Can_Be_Loaded()
        {
            AddStrategyToConfig("Test", new MockStrategy());
            Assert.AreEqual(DatabaseCleaner.Current.Strategies.Count, 1);
        }

        private static void AddStrategyToConfig(string name, ICleaningStrategy strategy)
        {
            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.Sections.Add("DatabaseCleaner", new DatabaseCleanerSection());
            DatabaseCleanerSection section = (DatabaseCleanerSection)config.GetSection("DatabaseCleaner");
            section.Strategies.Add(new StrategyElement(name, strategy.GetType().AssemblyQualifiedName));
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("DatabaseCleaner");
        }

        public class MockStrategy : ICleaningStrategy
        {
            #region ICleaningStrategy Members

            void ICleaningStrategy.Clean()
            {
                throw new NotImplementedException();
            }

            #endregion
        }
    }
}