﻿using System.Runtime.CompilerServices;

namespace Crc.Xunit.Extensions
{
    public class ToDoAttribute : XFactAttribute
    {
        public ToDoAttribute(string cause, [CallerMemberName] string memberName = null) : base(cause, memberName)
        {
            DisplayName = $"TO DO ({cause}): {DisplayName}";
        }
    }

}
