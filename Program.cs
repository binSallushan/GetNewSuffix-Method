using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetNewSuffix_Method
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a suffix: ");
            var suffix = Console.ReadLine().ToUpper();

            var newSuffix = GetNewSuffix(suffix);
            Console.WriteLine($"new suffix is: {newSuffix}");
            Console.ReadLine();
        }
        public static string GetNewSuffix(string lastSuffix)
        {
            string newSuffix = string.Empty;
            var length = lastSuffix.Length;

            if (lastSuffix == String.Empty)
            {
                newSuffix = "A";
            }
            else if (length == 1 && lastSuffix != "Z")
            {
                var asciiOfLastSuffix = char.ConvertToUtf32(lastSuffix, 0);
                var asciiOfNewSuffix = asciiOfLastSuffix + 1;
                newSuffix = char.ConvertFromUtf32(asciiOfNewSuffix);
            }
            else if (lastSuffix == "Z")
            {
                newSuffix = "A1";
            }
            else
            {
                var numberAsString = lastSuffix.Substring(1, length - 1);
                var numberAsInt = Convert.ToInt32(numberAsString);
                if (lastSuffix.Substring(0, 1) == "Z")
                {
                    newSuffix = "A" + Convert.ToString(numberAsInt + 1);
                }
                else
                {
                    newSuffix = char.ConvertFromUtf32(char.ConvertToUtf32(lastSuffix, 0) + 1) + numberAsString;
                }
            }

            return newSuffix;
        }
    }
}
