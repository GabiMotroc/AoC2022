namespace AoC2022.Days;

public class Day3
{
    public int Part1()
    {
        var sum = 0;
        while (Console.ReadLine() is { } line)
        {
            var first = line.Take(line.Length / 2);
            var second = line.Skip(line.Length / 2);
            var distict = first.Distinct();
            var intersect = distict.Intersect(second.Distinct());
            var single = intersect.FirstOrDefault();
            if (single >= 'a')
            {
                sum += single - 'a' + 1;
            }
            else
                sum += single - 'A' + 27;
        }

        return sum;
    }

    public int Solve2()
    {
        var sum = 0;
        while (Console.ReadLine() is { } line1)
        {
            var line2 = Console.ReadLine();
            var line3 = Console.ReadLine();
            var intersect = line1.Distinct()
                .Intersect(line2.Distinct())
                .Intersect(line3.Distinct());
            var single = intersect.FirstOrDefault();
            if (single >= 'a')
            {
                sum += single - 'a' + 1;
            }
            else
                sum += single - 'A' + 27;
        }

        return sum;
    }
}