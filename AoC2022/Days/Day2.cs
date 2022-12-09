namespace AoC2022.Days;

public class Day2
{
    public int Part1()
    {
        var sum = 0;
        string? second;
        string? first;

        while (((first, second) = (BetterConsole.GetNextWord(), BetterConsole.GetNextWord())) != (null, null))
        {
            var opponent = Convert(first);
            var you = Convert(opponent, second);
            sum += Evaluate(opponent, you);
            sum += (int) you;
            sum += 1;
        }

        return sum;
    }

    private int Evaluate(RockPaperScissor first, RockPaperScissor second)
    {
        if (second == Win(first))
            return 6;
        if (second == Lose(first))
            return 0;

        return 3;
    }

    private RockPaperScissor Convert(string input)
    {
        switch (input)
        {
            case "A":
            case "X":
                return RockPaperScissor.Rock;
            case "B":
            case "Y":
                return RockPaperScissor.Paper;
            case "C":
            case "Z":
                return RockPaperScissor.Scissor;
        }

        throw new ArgumentOutOfRangeException();
    }

    private RockPaperScissor Convert(RockPaperScissor opponent, string input)
    {
        return (opponent, input) switch
        {
            (_, "X") => Lose(opponent),
            (_, "Y") => opponent,
            (_, "Z") => Win(opponent),
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    private RockPaperScissor Win(RockPaperScissor choice)
    {
        return (RockPaperScissor) ((int) (choice + 1) % 3);
    }

    private RockPaperScissor Lose(RockPaperScissor choice)
    {
        return (RockPaperScissor) ((int) (choice + 2) % 3);
    }

    private enum RockPaperScissor
    {
        Rock = 0,
        Paper = 1,
        Scissor = 2,
    }
}

/*
 * Rock Paper Scissor
 * 1    2     3
 *
 * Paper Scissor Rock (Win)
 * 2    3       1
 *
 * Scissor Rock Paper (Lose)
 * 3       1    2
 * 
*/