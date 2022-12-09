using System.ComponentModel.DataAnnotations;

namespace AoC2022.Days;

public class Day4
{
    public int Part1()
    {
        var sum = 0;
        while (Console.ReadLine() is {} line)
        {
            var sections = line.Split(',')
                .Select(
                    x => x.Split('-')
                        .Select(int.Parse)
                        .ToArray())
                .ToArray();
            if(sections[0][0] <= sections[1][0] && sections[0][1] >= sections[1][1])
                sum += 1;
            else if(sections[0][0] >= sections[1][0] && sections[0][1] <= sections[1][1])
                sum += 1;
        }

        return sum;
    }

    public int Part2()
    {
        var sum = 0;
        while (Console.ReadLine() is {} line)
        {
            var sections = line.Split(',')
                .Select(
                    x => x.Split('-')
                        .Select(int.Parse)
                        .ToArray())
                .ToArray();

            var x1 = sections[0][0];
            var x2 = sections[0][1];
            var y1 = sections[1][0];
            var y2 = sections[1][1];
            if (x1 <= y2 && y1 <= x2)
                sum++;
        }

        return sum;
    }
}