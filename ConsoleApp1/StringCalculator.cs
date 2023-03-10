using System;
using System.Collections.Generic;
using System.Text;

namespace Workshop
{
    public class StringCalculator
    {
        public static int SumString(String str)
        {
            //if (str == String.Empty)
            //    return 0;

            int result = 0;
            String[] numbers = str.Split('\n', ',');
            foreach (String s in numbers)
            {
                if (s == "") continue;
                int parsedNumber = Int32.Parse(s);
                if (parsedNumber > 1000) continue;
                if (parsedNumber < 0) throw new ArgumentException();
                result += parsedNumber;
            }


            return result;
        }
    }
}
