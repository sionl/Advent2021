namespace Day5
{
    public class Solution : ISolution
    {
        private int[,] map = new int[1000, 1000];

        public void Run()
        {
            var lines = File.ReadAllText("Day5\\Input1.txt").Split(Environment.NewLine);
            foreach (var line in lines)
            {
                var array = line.Split(" -> ");
                var point1 = array[0].Split(",");
                var point2 = array[1].Split(",");
                var sX = int.Parse(point1[0]);
                var sY = int.Parse(point1[1]);
                var eX = int.Parse(point2[0]);
                var eY = int.Parse(point2[1]);

                if (sX == eX)
                {
                    for (int y = sY; y <= eY; y++)
                    {
                        map[sX, y] = map[sX, y] + 1;
                    }
                    for (int y = eY; y <= sY; y++)
                    {
                        map[sX, y] = map[sX, y] + 1;
                    }
                }

                if (sY == eY)
                {
                    for (int x = sX; x <= eX; x++)
                    {
                        map[x, sY] = map[x, sY] + 1;
                    }
                    for (int x = eX; x <= sX; x++)
                    {
                        map[x, sY] = map[x, sY] + 1;
                    }
                }
            }

            OutputData();
        }

        private void OutputData()
        {
            var overlap = 0;
            var builder = new OutputBuilder();
            for (int x = 0; x < map.GetLength(0); x++)
            {
                for (int y = 0; y < map.GetLength(1); y++)
                {
                    if (map[y, x] > 0)
                    {
                        if (map[y, x] > 1)
                        {
                            overlap += 1;
                        }
                        builder.Append(map[y, x].ToString());
                    }
                    else
                    {
                        builder.Append(".");
                    }
                }
                builder.AppendNewLine();
            }

            builder.AppendNewLine();
            builder.Append($"Overlap: {overlap}");

            File.WriteAllText("Day5\\Output.txt", builder.ToString());
        }
    }
}