namespace AoC2022.Days;

public class Day9
{
    private Dictionary<char, Position> Moves { get; set; } = new()
    {
        {'D', new Position(0, -1)},
        {'U', new Position(0, 1)},
        {'L', new Position(-1, 0)},
        {'R', new Position(1, 0)},
    };

    public int Part1(int length = 2)
    {
        var rope = Enumerable.Range(0, length).Select(_ => new Position(0, 0)).ToList();
        var visited = new List<(int, int)>();
        while (Console.ReadLine() is { } line)
        {
            var split = line.Split();
            var (instruction, steps) = (split[0], int.Parse(split[1]));
            for (var i = 0; i < steps; i++)
            {
                var move = Moves[instruction.FirstOrDefault()];
                rope[0] += move;
                for (var j = 1; j < rope.Count; j++)
                {
                    if (Position.Distance(rope[j], rope[j - 1]) > 1)
                    {
                        var delta = rope[j - 1] - rope[j];
                        rope[j] += new Position(Math.Sign(delta.X), Math.Sign(delta.Y));
                    }
                }

                var tail = rope.LastOrDefault();
                visited.Add((tail.X, tail.Y));
            }
        }

        return visited.Distinct().Count();
    }

    public int Part2()
    {
        return Part1(10);
    }
}

internal struct Position
{
    public Position(int x, int y)
    {
        X = x;
        Y = y;
    }

    public int X { get; set; }
    public int Y { get; set; }
    public static Position operator +(Position a, Position b) => new(a.X + b.X, a.Y + b.Y);
    public static Position operator -(Position a, Position b) => new(a.X - b.X, a.Y - b.Y);
    public static int Distance(Position a, Position b) => Math.Max(Math.Abs(a.X - b.X), Math.Abs(a.Y - b.Y));
}
