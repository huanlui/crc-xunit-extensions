using System.Runtime.CompilerServices;
using Xunit;

namespace Crc.Xunit.Extensions
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