using System.Runtime.CompilerServices;
using Xunit;

namespace Xunit.Extensions
{
    public class XTheoryAttribute : TheoryAttribute
    {
        public XTheoryAttribute(string skip = null, [CallerMemberName] string memberName = null)
        {
            DisplayName = PrettyPrinter.PrintPretty(memberName);
            Skip = skip;
        }
    }
}