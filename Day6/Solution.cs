namespace Day6
{
    public class Solution : ISolution
    {
        private string OUTPUT_FILE = "Day6\\Output.txt";
        private int DAYS = 256;
        private long[] fishList = new long[9];
        private OutputBuilder builder = new();

        public void Run()
        {
            var data = File.ReadAllText("Day6\\Input.txt").Split(",").Select(int.Parse).ToList();

            foreach (var i in data)
            {
                fishList[i] = fishList[i] + 1;
            }

            builder.AppendLine($"0, 1, 2, 3, 4, 5, 6, 7, 8  -  Day:");
            builder.AppendLine($"{string.Join(", ", fishList)}  -   0");

            int day = 1;
            while (day <= DAYS)
            {
                var spawn = fishList[0];

                for (int i = 0; i < fishList.Length - 1; i++)
                {
                    fishList[i] = fishList[i + 1];
                }

                fishList[6] = fishList[6] + spawn;
                fishList[8] = spawn;

                builder.AppendLine($"{string.Join(", ", fishList)}  -   {day}");
                day += 1;
            }

            long total = 0;
            for (int i = 0; i < fishList.Length; i++)
            {
                total += fishList[i];
            }

            builder.AppendNewLine();
            builder.AppendLine($"Total: {total}");
            File.WriteAllText(OUTPUT_FILE, builder.ToString());
        }
    }
}