using System;
using System.Configuration;
using System.Collections.Generic;
using System.Reflection;

namespace DatabaseCleaner.Configuration
{
    public class StrategyElementCollection : ConfigurationElementCollection
    {
        public override ConfigurationElementCollectionType CollectionType
        {
            get
            {
                return ConfigurationElementCollectionType.AddRemoveClearMap;
            }
        }

        public StrategyElement this[int index]
        {
            get { return (StrategyElement)BaseGet(index); }
            set
            {
                if (BaseGet(index) != null)
                    BaseRemoveAt(index);
                BaseAdd(index, value);
            }
        }

        public void Add(StrategyElement element)
        {
            BaseAdd(element);
        }

        public void Clear()
        {
            BaseClear();
        }

        public void Remove(StrategyElement element)
        {
            BaseRemove(element.Name);
        }

        public void Remove(string name)
        {
            BaseRemove(name);
        }

        public void RemoveAt(int index)
        {
            BaseRemoveAt(index);
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new StrategyElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((StrategyElement)element).Name;
        }

        public IList<ICleaningStrategy> ToStrategies()
        {
            IList<ICleaningStrategy> strategies = new List<ICleaningStrategy>();
            foreach (StrategyElement element in this)
            {
                ConstructorInfo ctor = Type.GetType(element.Type).GetConstructor(Type.EmptyTypes);
                if (ctor == null)
                {
                    throw new ConfigurationErrorsException(global::DatabaseCleaner.Properties.Resources.DatabaseCleanerConfigurationException);
                }
                ICleaningStrategy strategy = (ICleaningStrategy)ctor.Invoke(new object[] { });
                strategies.Add(strategy);
            }
            return strategies;
        }
    }
}
