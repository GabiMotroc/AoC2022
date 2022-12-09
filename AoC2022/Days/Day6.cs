namespace AoC2022.Days;

public class Day6
{
    public int Part1()
    {
        var line = Console.ReadLine();
        for (int i = 3; i < line.Length; i++)
        {
            if (line[i] != line[i - 1] && line[i] != line[i - 2] && line[i] != line[i - 3] &&
                line[i - 1] != line[i - 2] && line[i - 1] != line[i - 3] && line[i - 2] != line[i - 3])
                return i;
        }

        return 0;
    }
    public int Part2()
    {
        var line = Console.ReadLine().ToArray();
        for (var i = 0; i < line.Length - 13; i++)
        {
            var segment = line[i..(i + 14)].Distinct();
            if (segment.Count() == 14)
                return i + 14;
        }

        return 0;
    }
}