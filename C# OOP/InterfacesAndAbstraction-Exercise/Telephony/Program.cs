using System;

namespace Telephony
{
    class Program
    {
        static void Main(string[] args)
        {
            ICallable s;

            string[] numbersToCall = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] websites = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            foreach(var number in numbersToCall)
            {
                if (number.Length == 7)
                {
                    s = new StationaryPhone();
                    s.Call(number);
                    
                }
                else if (number.Length == 10)
                {
                    s = new Smartphone();
                    s.Call(number);
                }
                else
                {
                    Console.WriteLine("Invalid number!");
                }
            }

            IBrowsable smartphone = new Smartphone();

            foreach(var website in websites)
            {
                smartphone.Browse(website);
            }
        }
    }
}
