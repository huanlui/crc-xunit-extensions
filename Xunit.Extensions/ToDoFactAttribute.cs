using System.Runtime.CompilerServices;

namespace Crc.Xunit.Extensions
{
    public class ToDoFactAttribute : XFactAttribute
    {
        public ToDoFactAttribute(string cause = null, [CallerMemberName] string memberName = null) : base(cause, memberName)
        {
            if (string.IsNullOrEmpty(cause))
            {
                DisplayName = $"TO DO: {DisplayName}";
                Skip = "TO DO";
            }
            else
            {
                DisplayName = $"TO DO ({cause}): {DisplayName}";
                Skip = cause;
            }
        }
    }
}
