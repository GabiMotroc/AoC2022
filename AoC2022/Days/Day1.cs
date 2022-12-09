namespace AoC2022.Days;

public class Day1
{
    public int Part1()
    {
        var lines = new List<string>();
        while (Console.ReadLine() is { } line)
        {
            lines.Add(line);
        }

        var numbers = new List<int>();
        var sum = 0;
        foreach (var line in lines)
        {
            if (string.IsNullOrEmpty(line))
            {
                numbers.Add(sum);
                sum = 0;
                continue;
            }

            sum += int.Parse(line);
        }

        return numbers.OrderDescending().Take(3).Sum();
    }
}