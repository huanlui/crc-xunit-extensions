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
        public FactParameters AddCase(params object[] parameters)
        {
            Add(parameters);
            return this;
        }

        /* Example:
         *     public static FactParameters GetSuts()
        {
            var suts = new FactParameters();

            suts.AddCase( new InMemoryMcsClient());

#if TEST_WITH_REAL
            McsClient real = new McsClient("http://localhost:5002");
            real.Login("admin", "adminPW");
            suts.AddCase(real);
#endif

            return suts;
        }

         * */
    }
}
