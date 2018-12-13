using System;
using System.Linq;

namespace Crc.Xunit.Extensions
{
    public static class PrettyPrinter
    {
        public static string PrintPretty(string input)
        {
            String result = " " + input.Replace("_", " ")
                                .Replace("When ", "")
                                .Replace("Cuando ", "")
                                .Replace(" then ", " => ")
                                .Replace(" entonces ", " => ")
                                .Replace(" should be ", " : ")
                                .Replace(" debería ser ", " : ")
                                .Replace(" deberían ser ", " : ")
                                .FirstCharToUpper();

            return result;
        }

        private static string FirstCharToUpper(this string input)
        {
            switch (input)
            {
                case null: throw new ArgumentNullException(nameof(input));
                case "": throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input));
                default: return input.First().ToString().ToUpper() + input.Substring(1);
            }
        }
    }
}
