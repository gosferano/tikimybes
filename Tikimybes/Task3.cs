using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tikimybes
{
    class Task3 : RandomTasks
    {
        public static bool TryCd()
        {
            int N = 13;
            int n = 4;
            int m = 6;
            List<int> cdN1 = new List<int>();
            List<int> cdM1 = new List<int>();
            for (int i = 0; i<N; i++)
            {
                cdN1.Add(i);
                cdM1.Add(i);
            }
            List<int> cdN2 = new List<int>();
            for (int i=0; i<n; i++)
            {
                int randCd = rand.Next(cdN1.Count());
                cdN2.Add(cdN1[randCd]);
                cdN1.Remove(cdN1[randCd]);
            }
            List<int> cdM2 = new List<int>();
            for (int i = 0; i < m; i++)
            {
                int randCd = rand.Next(cdM1.Count());
                cdM2.Add(cdM1[randCd]);
                cdM1.Remove(cdM1[randCd]);
            }
            IEnumerable<int> intersects = cdN2.Intersect<int>(cdM2);

            if (intersects.Count() >= 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool TryAnt()
        {
            int m = 7;
            int n = 5;
            bool[,] board = new bool[m+1, n+1];

            Tuple<int, int>[] points = new Tuple<int, int>[3];
            points[0] = Tuple.Create(1, 1);
            points[1] = Tuple.Create(3, 1);
            points[2] = Tuple.Create(5, 2);

            for (int i = 0; i<m+1; i++)
            {
                for (int j=0; j<n+1; j++)
                {
                    board[i, j] = false;
                }
            }

            Tuple<int, int> position = Tuple.Create(0, 0);
            Tuple<int, int> finish = Tuple.Create(m, n);
            board[position.Item1, position.Item2] = true;

            while (position.Item1 != finish.Item1 || position.Item2 != finish.Item2)
            {
                if (position.Item1 == m && position.Item2 != n)
                {
                    position = Tuple.Create(position.Item1, position.Item2 +1);
                }
                else if (position.Item2 == n && position.Item1 != m)
                {
                    position = Tuple.Create(position.Item1 + 1, position.Item2);
                }
                else
                {
                    int randDir = rand.Next(2);
                    if (randDir == 0)
                    {
                        position = Tuple.Create(position.Item1, position.Item2 + 1);
                    }
                    else
                    {
                        position = Tuple.Create(position.Item1 + 1, position.Item2);
                    }
                }
                board[position.Item1, position.Item2] = true;
            }

            int visited = 0;

            for (int i=0; i<points.Count(); i++)
            {
                if (board[points[i].Item1, points[i].Item2] == true)
                {
                    visited++;
                }
            }
            
            if (visited == 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool TryStops()
        {
            int stopNum = 5;
            int passNum = 6;
            int treshold = 3;
            List<int> stops = new List<int>();

            for (int i=0; i<stopNum; i++)
            {
                stops.Add(0);
                for (int j = 0; j<passNum; j++)
                {
                    int randDecision = rand.Next(2);
                    if (randDecision == 0 && passNum != 0)
                    {
                        stops[i]++;
                        passNum--;
                    }
                }
                if ((i == stopNum - 1) && passNum !=0)
                {
                    stops[i] += passNum;
                }
            }

            if (stops.Where(x => x == 0).Count() == 3)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool TryMails()
        {
            int m = 6;
            int n = 4;
            int k = 2;
            List<char> mSide = new List<char>();
            List<char> nSide = new List<char>();
            List<char> mails = new List<char>();
            for (int i=0; i<m; i++)
            {
                mails.Add('m');
            }
            for (int i=0; i<n; i++)
            {
                mails.Add('n');
            }
            for (int i=0; i<m+n; i++)
            {
                int randMail = rand.Next(mails.Count());
                if (i<m)
                {
                    mSide.Add(mails[randMail]);
                }
                else
                {
                    nSide.Add(mails[randMail]);
                }
                mails.Remove(mails[randMail]);
            }

            if (mSide.Where(x => x == 'n').Count() == 1 || nSide.Where(x => x == 'm').Count() == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool TryBricks()
        {
            int n = 17;
            int k = 3;
            int o = 4;
            List<int> towers = new List<int>();
            for (int i=0; i<o; i++)
            {
                towers.Add(0);
            }

            for (int i = 0; i<n; i++)
            {
                int randTower = rand.Next(o);
                towers[randTower]++;
            }
            
            if (towers.Where(x => x == k).Count() == 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool TryLecture()
        {
            int numStudents = 12;
            int numCaffees = 13;
            int treshold = 4;
            List<int> caffees = new List<int>();
            for (int i=0; i<numCaffees; i++)
            {
                caffees.Add(0);
            }

            for (int i=0; i<numStudents; i++)
            {
                int randCaffee = rand.Next(numCaffees);
                caffees[randCaffee]++;
            }

            /*caffees[0] = treshold;
            caffees[1] = treshold;
            for (int i = 0; i< numStudents - treshold - treshold; i++)
            {
                caffees[i + 2]++;
            }*/

            if (caffees.Where(x => x == treshold).Count() == 2 && caffees.Where(x => x == 1).Count() == numStudents - treshold - treshold)
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
