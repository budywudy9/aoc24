using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc24
{
    internal struct Day1
    {
        public List<int> firstIDs;
        public List<int> secondIDs;
        public List<int> distances;
        public Dictionary<int, int> dict;
    }

    internal static class Day1Part1
    {
        private const int ID_LENGTH = 5;

        public static void Fill_Lists(ref List<int> first, ref List<int> second)
        {
            using (StreamReader r = new StreamReader("inpd1p1.txt"))
            {
                string? line;
                while ((line = r.ReadLine()) != null)
                {
                    first.Add(int.Parse(line.Substring(0, ID_LENGTH)));

                    second.Add(int.Parse(line.Substring(line.IndexOf(" ") + 3, ID_LENGTH)));
                }
            }

            first.Sort();
            second.Sort();
        }

        public static List<int> Find_Distance(List<int> l, List<int> r)
        {
            List<int> distances = new List<int>();
            for (int i = 0; i < l.Count; i++)
            {
                distances.Add(Math.Abs(l[i] - r[i]));
            }
            return distances;
        }

        public static int Sum_Distances(List<int> distances)
        {
            return distances.Sum();
        }

        public static int run(Day1 d1)
        {
            Day1Part1.Fill_Lists(ref d1.firstIDs, ref d1.secondIDs);
            d1.distances = Day1Part1.Find_Distance(d1.firstIDs, d1.secondIDs);

            return Day1Part1.Sum_Distances(d1.distances);
        }
    }

    internal static class Day1Part2
    {
        public static Dictionary<int, int> Fill_Dict(List<int> l, List<int> r)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();

            for (int i = 0; i < l.Count; i++)
            {
                dict.Add(l[i], r.Count(x => x == l[i]));    
            }

            return dict;
        }

        public static int run(Day1 d1)
        {
            d1.dict = Day1Part2.Fill_Dict(d1.firstIDs, d1.secondIDs);
            int sum = 0;

            // this can totally be done better but its 11pm and im tired after an 8h shift
            foreach (int i in d1.dict.Keys)
            {
                sum += i * d1.dict[i];
            }

            return sum;
        }
    }
}
