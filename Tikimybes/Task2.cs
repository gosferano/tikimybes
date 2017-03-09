using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tikimybes
{
    class Task2 : RandomTasks
    {
        public static bool TryRoad()
        {
            int length = 109;
            int point1 = 26;
            int point2 = 50;
            // 1: 0,348623853 | 0,651376146

            double randPoint1 = rand.NextDouble() * length;
            double randPoint2 = rand.NextDouble() * length;

            // 1 klausimas
            /*if (Math.Abs(point1-randPoint1) < Math.Abs(point2-randPoint1))
            {
                return true;
            }
            else
            {
                return false;
            }*/

            // 2 klausimas
            if (Math.Abs(point1 - randPoint1) < Math.Abs(point2 - randPoint1) || Math.Abs(point1 - randPoint2) < Math.Abs(point2 - randPoint2))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool TrySegment()
        {
            double treshold = 0.330;
            double randSegment = rand.NextDouble();

            // 1 klausimas
            /*if (Math.Abs(1 - randSegment - randSegment) > treshold)
            {
                return true;
            }
            else
            {
                return false;
            }*/

            // 2 klausimas
            if (Math.Min(1 - randSegment, randSegment)/Math.Max(1 - randSegment, randSegment) > treshold)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool TryMessages()
        {
            int x = 12;
            int y = 18;
            int z = 15;
            int u = 7;
            List<int> rands = new List<int>();
            rands.Add(rand.Next(x) + 1);
            rands.Add(rand.Next(y) + 1);
            rands.Add(rand.Next(z) + 1);
            IEnumerable<int> successful = rands.Where(e => e <= u);

            if (successful.Count() == 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool TryAngles()
        {
            int angle1 = 22;
            int angle2 = 141;
            int angleNum = 3;

            double[] pointAngles = new double[angleNum];
            for (int i = 0; i < angleNum; i++)
            {
                pointAngles[i] = rand.NextDouble() * 360;
            }
            pointAngles = pointAngles.OrderBy(x => x).ToArray();

            List<double> angles = new List<double>();
            double angleTotal = (angleNum - 2) * 180;

            for (int i=0; i < angleNum - 1; i++)
            {
                double randAngle = rand.NextDouble() * Math.Min(180, angleTotal);
                angles.Add(randAngle);
                angleTotal -= randAngle;
            }
            angles.Add(angleTotal);

            IEnumerable<double> less = angles.Where(x => x < angle1);
            List<double> tmp = less.ToList();

            if (less.Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool TryCars()
        {
            double s = 170;
            double v = 60;
            double deltaV = 27;
            double deltaT = 1.879;

            double t1 = s / v;
            double t2 = rand.NextDouble() * deltaT + s / (v + rand.NextDouble() * deltaV);

            if (t2 < t1)
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
