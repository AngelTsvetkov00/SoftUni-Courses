using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Telephony
{
    public class StationaryPhone : ICallable
    {

        public void Call(string otherPhone)
        {
            if (otherPhone.Any(x => char.IsLetter(x)))
            {
                Console.WriteLine("Invalid number!");
            }
            else
            {
                Console.WriteLine($"Dialing... {otherPhone}");
            }
        }
    }
}
