using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tikimybes
{
    class Program
    {
        private static int tries = 1000000000;           // edit this to set number of tries being made
        private static int triesDone = 0;
        private static int success = 0;
        private static Random rand = new Random();
        private static Func<bool> function = Task3.TryAnt;   // edit this to resemble correct try function 

        static void Main(string[] args)
        {
            for (int i=0; i<tries; i++)
            {
                if (function())
                {
                    success++;
                }
                triesDone++;
                if (triesDone%(tries/100) == 0)
                {
                    Console.WriteLine(triesDone*100.0/tries + "% done...\t Success rate: " + (success * 1.0 / triesDone).ToString("0.0000000") + " Time elapsed: " + (DateTime.UtcNow - Process.GetCurrentProcess().StartTime.ToUniversalTime()));
                }
            }
            Console.WriteLine("The succes rate was " + (success*1.0/tries));
            Console.ReadKey();
        }

    }
}
