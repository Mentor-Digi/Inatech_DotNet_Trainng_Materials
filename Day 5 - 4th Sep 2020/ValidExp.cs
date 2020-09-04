using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace FWClasses
{
    class ValidExp
    {
        public static void Main()
        {
            String str = "Peacock";
            Console.WriteLine(str.Length);
            Console.WriteLine(str.Substring(3, 4));
            Console.WriteLine(str.ToUpper());
            Console.WriteLine(str.ToLower());
            Console.WriteLine(str.Replace("cock", "hen"));
            Console.WriteLine(str.Replace("c", "d"));
            //Prod001
            //if "Yes" "Male" "male"
            //Production - prod prd 
            //Matching Pettern
            //Regex -Java Script - Client - Client Side Validation
            //patterns - universal
            str = "It is Simply a South Special dish";
            MatchCollection match = Regex.Matches(str, @"\bS\S*");
            foreach (Match m in match)
                Console.WriteLine(m);

            str = "Money and material is not everything that makes life";
            MatchCollection match1= Regex.Matches(str, @"\bm\S*s\b");
            foreach (Match m in match1)
                Console.WriteLine(m);
            Console.ReadLine();

        }
    }
}
