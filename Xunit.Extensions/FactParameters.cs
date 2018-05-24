using System;
using System.Collections.Generic;
using System.Text;

namespace Xunit.Extensions
{
    /// <summary>
    /// Useful to create parametrized test data of type [MemberData(nameof(MultiplicateCases))]
    /// </summary>
    public class FactParameters : List<object[]>
    {
        public FactParameters AddCase(params object[] parameters)
        {
            Add(parameters);
            return this;
        }

        /* Example:
        public static FactParameters MultiplicateCases()
        {
            return new FactParameters()
                  .AddCase("cualquierExpression", Expr.Abs(2))
                  .AddCase(2, "cualquierExpression")
                  .AddCase(Expr.Macro(5), Expr.Sum(2, "#1"))
                  .AddCase(10, 5);
        }

         * */
    }
}
