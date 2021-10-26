using System;
using System.Collections.Generic;
using System.Linq;

namespace AdvancedExam
{
    class Program
    {
        static void Main(string[] args)
        {
             List<string> pear = new List<string>() { "p", "e", "a", "r" };
            List<string> flour = new List<string>() { "f", "l", "o", "u", "r" };
            List<string> pork = new List<string>() { "p", "o", "r", "k" };
            List<string> olive = new List<string>() { "o", "l", "i", "v", "e" };
			
			//read input
            Queue<string> vowels = new Queue<string>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray());
            Stack<string> consonants = new Stack<string>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray());

            while (consonants.Count != 0)
            {
                string currentVowel = vowels.Dequeue();
                string currentCons = consonants.Pop();

                pear.RemoveAll(x => x == currentCons);
                pear.RemoveAll(x => x == currentVowel);

                flour.RemoveAll(x => x == currentCons);
                flour.RemoveAll(x => x == currentVowel);

                pork.RemoveAll(x => x == currentCons);
                pork.RemoveAll(x => x == currentVowel);

                olive.RemoveAll(x => x == currentCons);
                olive.RemoveAll(x => x == currentVowel);
				
				vowels.Enqueue(currentVowel);
				
            }

            int wordsFound = 0;
            if (pear.Count == 0) wordsFound++;
            if (flour.Count == 0) wordsFound++;
            if (pork.Count == 0) wordsFound++;
            if (olive.Count == 0) wordsFound++;

            Console.WriteLine($"Words found: {wordsFound} ");
            if (pear.Count == 0) Console.WriteLine("pear"); ;
            if (flour.Count == 0) Console.WriteLine("flour"); ;
            if (pork.Count == 0) Console.WriteLine("pork"); ;
            if (olive.Count == 0) Console.WriteLine("olive"); ;

        }
    }
}
