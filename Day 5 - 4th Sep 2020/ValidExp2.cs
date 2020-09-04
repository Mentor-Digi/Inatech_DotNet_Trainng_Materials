using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace FWClasses
{
    class ValidExp2
    {
        public static void Main()
        {
            string str = "Pattern Matching with Regular Expressions";
            string pattern = "\\s+";
            string rept = "-";
            Regex rgx = new Regex(pattern);
            string res = rgx.Replace(str, rept);
            Console.WriteLine(str);
            Console.WriteLine(res);
            Console.Read();
        }
    }
}
