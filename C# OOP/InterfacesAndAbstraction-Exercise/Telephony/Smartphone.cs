using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Telephony
{
    public class Smartphone : IBrowsable
    {
        public void Browse(string website)
        {
            if (website.Any(x => char.IsDigit(x)))
            {
                Console.WriteLine("Invalid URL!");
            }
            else
            {
                Console.WriteLine($"Browsing: {website}!");
            }
        }

        public void Call(string otherPhone)
        {
            if (otherPhone.Any(x => char.IsLetter(x)))
            {
                Console.WriteLine("Invalid number!");
            }
            else
            {
                Console.WriteLine($"Calling... {otherPhone}");
            }
        }
    }
}
