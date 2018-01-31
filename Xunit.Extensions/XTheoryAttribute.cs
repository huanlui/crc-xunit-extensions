using System.Runtime.CompilerServices;
using Xunit.Extensions;

namespace xunit.extensions
{
    public class ToDoAttribute : XFactAttribute
    {
        public ToDoAttribute(string cause, [CallerMemberName] string memberName = null) : base(cause, memberName)
        {
            DisplayName = $"TO DO ({cause}): {DisplayName}";
        }
    }
}
