using System.Runtime.CompilerServices;
using xunit.extensions;

namespace Xunit.Extensions
{
    public class ToDoAttribute : XFactAttribute
    {
        public ToDoAttribute(string cause, [CallerMemberName] string memberName = null) : base(cause, memberName)
        {
            DisplayName = $"TO DO ({cause}): {DisplayName}";
        }
    }

}
