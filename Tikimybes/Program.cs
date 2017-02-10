﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tikimybes
{
    class Program
    {
        private static int tries = 1000000000;          // edit this to set number of tries being made
        private static int triesDone = 0;
        private static int success = 0;
        private static Random rand = new Random();
        private static Func<bool> function = TryKeys;   // edit this to resemble correct try function 

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

        static bool TryPhone()
        {
            #region Editable
            List<int> numbers = new List<int>();
            int houseNum = 9;
            int abonentsNum = 3;
            int callsNum = 5;
            #endregion

            int bustedOn = 0;
            
            List<List<bool>> houses = new List<List<bool>>();
            for (int i=0; i < houseNum; i++)
            {
                houses.Add(new List<bool>());
                for (int j=0; j<abonentsNum; j++)
                {
                    houses[i].Add(false);
                    numbers.Add(j + i * abonentsNum + 1);
                }
            }
            int numCount = numbers.Count;

            for (int i=0; i<numCount; i++)
            {
                int randNum = numbers[rand.Next(numbers.Count)];
                numbers.Remove(randNum);
                if (houses[(randNum - 1) / 3].Contains(true) && bustedOn == 0)
                {
                    bustedOn = i + 1;
                    break;
                }
                houses[(randNum - 1) / 3][(randNum - 1) % 3] = true;
            }

            if (bustedOn > callsNum)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static bool TryKeys()
        {
            #region Editable
            List<int> keys = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            int locks = 4;
            int targetKeysMissed = 4;
            #endregion

            int keysMissed = 0;

            while (keys.Count != 0)
            {
                int randKey = keys[rand.Next(keys.Count)];
                if (randKey > locks)
                {
                    keysMissed++;
                }
                keys.Remove(randKey);
                bool shallBreak = true;
                for (int i=0; i<locks; i++)
                {
                    if (keys.Contains(i+1))
                    {
                        shallBreak = false;
                    }
                }
                if (shallBreak)
                {
                    break;
                }
            }

            if (keysMissed == targetKeysMissed)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}