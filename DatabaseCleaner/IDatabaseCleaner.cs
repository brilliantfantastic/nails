using System;
using System.Collections.Generic;

namespace DatabaseCleaner
{
    public interface IDatabaseCleaner
    {
        IList<ICleaningStrategy> Strategies { get; }
    }
}
