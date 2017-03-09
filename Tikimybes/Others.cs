using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tikimybes
{
    public class Others : RandomTasks
    {

        public static bool TryMeeting()
        {
            int delegatesV = 10;
            int delegatesK = 10;
            int delegatesP = 7;
            int size = 3;
            int cities = 1;

            int delegatesTotal = delegatesV + delegatesK + delegatesP;
            List<int> delegates = new List<int>();
            List<int> council = new List<int>();
            for (int i = 0; i < delegatesTotal; i++)
            {
                if (i < delegatesV)
                {
                    delegates.Add(1);
                }
                else if (i < delegatesV + delegatesK)
                {
                    delegates.Add(2);
                }
                else if (i < delegatesTotal)
                {
                    delegates.Add(3);
                }
            }

            for (int i = 0; i < size; i++)
            {
                int randDelegate = delegates[rand.Next(delegates.Count)];
                delegates.Remove(randDelegate);
                council.Add(randDelegate);
            }
            int currentCities = council.Distinct().Count();

            if (cities == currentCities)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool TryExam()
        {
            int studentNum = 13;
            int targetStudent = 6;
            List<int> students = new List<int>();
            List<bool> pardons = new List<bool>();
            for (int i = 0; i < studentNum; i++)
            {
                students.Add(i);
                pardons.Add(false);
            }
            while (students.Contains(targetStudent - 1) && pardons[targetStudent - 1] == false)
            {
                int randStudent = students[rand.Next(students.Count())];
                if (students.Where(x => x < randStudent).Count() > 0)
                {
                    pardons[randStudent] = true;
                }
                students.Remove(randStudent);
            }
            return !pardons[targetStudent - 1];
        }

        public static bool TryTrain()
        {
            #region Editable
            int rooms = 9;
            int friends = 5;
            int slots = 3;
            #endregion

            List<List<bool>> wagon = new List<List<bool>>();
            for (int i = 0; i < rooms; i++)
            {
                wagon.Add(new List<bool>());
                for (int j = 0; j < slots; j++)
                {
                    wagon[i].Add(false);
                }
            }

            List<int> tickets = new List<int>();
            for (int i = 0; i < rooms * slots; i++)
            {
                tickets.Add(i);
            }

            for (int i = 0; i < friends; i++)
            {
                int randTicket = tickets[rand.Next(tickets.Count)];
                tickets.Remove(randTicket);
                if (wagon[randTicket / slots].Contains(true))
                {
                    return true;
                }
                wagon[randTicket / slots][randTicket % slots] = true;
            }

            return false;
        }

        public static bool TryFootball()
        {
            int teams = 14;
            int spectators = 4;
            List<int> spectatorTeams = new List<int>();
            for (int i = 0; i < spectators; i++)
            {
                spectatorTeams.Add(rand.Next(teams) + 1);
            }
            foreach (int team in spectatorTeams)
            {
                if (spectatorTeams.Where(x => x == team).Count() > 1)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
