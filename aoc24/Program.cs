namespace aoc24
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Run_Day_One();
        }

        public static void Run_Day_One()
        {
            Day1 d1 = new Day1();
            d1.firstIDs = new List<int>();
            d1.secondIDs = new List<int>();
            d1.distances = new List<int>();
            d1.dict = new Dictionary<int, int>();

            Console.WriteLine($"DAY ONE PART ONE: {Day1Part1.run(d1)}");
            Console.WriteLine($"DAY ONE PART TWO: {Day1Part2.run(d1)}");
        }
    }
}