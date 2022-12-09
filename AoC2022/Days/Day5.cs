namespace AoC2022.Days;

public class Day5
{
    public string Part1()
    {
        var space = new List<Stack<char>>();
        for (int i = 0; i < 9; i++)
        {
            var stack = new Stack<char>();
            var line = Console.ReadLine()?.Split().Reverse();
            foreach (var ch in line)
            {
                stack.Push(ch.FirstOrDefault());
            }
            space.Add(stack);
        }

        while (Console.ReadLine() is { } line)
        {
            var words = line.Split().ToArray();
            var quantity = int.Parse(words[1]);
            var from = int.Parse(words[3]) - 1;
            var to = int.Parse(words[5]) - 1;
            for (int i = 0; i < quantity; i++)
            {
                var ch = space[from].Pop();
                space[to].Push(ch);
            }
        }

        var result = space.Select(x => x.Pop());
        return string.Join("", result);
    }
    public string Part2()
    {
        var space = new List<Stack<char>>();
        for (int i = 0; i < 9; i++)
        {
            var stack = new Stack<char>();
            var line = Console.ReadLine()?.Split().Reverse();
            foreach (var ch in line)
            {
                stack.Push(ch.FirstOrDefault());
            }
            space.Add(stack);
        }

        while (Console.ReadLine() is { } line)
        {
            var words = line.Split().ToArray();
            var quantity = int.Parse(words[1]);
            var from = int.Parse(words[3]) - 1;
            var to = int.Parse(words[5]) - 1;
            var ch = new List<char>();
            for (var i = 0; i < quantity; i++)
            {
                ch.Add(space[from].Pop());
            }
            
            foreach (var c in ch.AsEnumerable().Reverse())
            {
                space[to].Push(c);
            }
        }

        var result = space.Select(x => x.Pop());
        return string.Join("", result);
    }
}