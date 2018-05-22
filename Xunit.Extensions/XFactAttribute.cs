using System.Runtime.CompilerServices;

namespace Xunit.Extensions
{
    public class XFactAttribute : FactAttribute
    {
        public XFactAttribute(string skip = null, [CallerMemberName] string memberName = null)
        {
            DisplayName = PrettyPrinter.PrintPretty(memberName);
            Skip = skip;
        }
    }
}