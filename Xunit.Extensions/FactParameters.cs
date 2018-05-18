using System;
using System.Collections.Generic;
using System.Text;

namespace Xunit.Extensions
{
    /// <summary>
    /// Useful to create parametrized test data of type [MemberData(nameof(GetSuts))]
    /// </summary>
    public class FactParameters : List<object[]>
    {
        public void AddCase(params object[] parameters)
        {
            Add(parameters);
        }
    }
}
