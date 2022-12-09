namespace AoC2022.Days;

public class Day8
{
    private readonly (int, int)[] _moves = {
        (-1, 0),
        (1, 0),
        (0, -1),
        (0, 1),
    };

    private readonly List<List<int>> _forest = new();

    public string Part1()
    {
        while (Console.ReadLine() is { } line)
        {
            _forest.Add(line.ToList().Select(x => x - '0').ToList());
        }

        var result = 0;
        var maxScenicScore = 0;
        for (var i = 0; i < _forest.Count; i++)
        {
            for (var j = 0; j < _forest.Count; j++)
            {
                var isVisible = false;
                var scenicScore = 1;
                foreach (var (xD, yD) in _moves)
                {
                    isVisible |= IsVisible(i, j, xD, yD, _forest[i][j]);
                    scenicScore *= ScenicScore(i, j, xD, yD, _forest[i][j]);
                }

                if (isVisible)
                    result++;

                maxScenicScore = Math.Max(maxScenicScore, scenicScore);
            }
        }
        return $"\nPart1: {result}\nPart2: {maxScenicScore}";
    }

    private int ScenicScore(int x, int y, int xD, int yD, int previousTree)
    {
        var result = 0;
        while (true)
        {
            if (x == 0 || x == _forest.Count - 1 || y == 0 || y == _forest.Count - 1)
                return result;
            if (previousTree <= _forest[x + xD][y + yD])
                return result + 1;

            x += xD;
            y += yD;
            result++;
        }
    }
    private bool IsVisible(int x, int y, int xd, int yd, int startValue)
    {
        while (true)
        {
            if (x <= 0 || x >= _forest.Count - 1 || y <= 0 || y >= _forest.Count - 1)
                return true;
            if (startValue <= _forest[x + xd][y + yd])
                return false;

            x += xd;
            y += yd;
        }
    }
}