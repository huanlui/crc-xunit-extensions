using System.Runtime.CompilerServices;

namespace Crc.Xunit.Extensions
{
    public class ToDoTheoryAttribute : XTheoryAttribute
    {
        public ToDoTheoryAttribute(string cause = null, [CallerMemberName] string memberName = null) : base(cause, memberName)
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