namespace AoC2022;

public static class BetterConsole
{
    private static string[]? _input = Array.Empty<string>();
    private static int _inputIndex;

    public static void ReadNextInput()
    {
        _input = Console.ReadLine()?.Split();
        _inputIndex = 0;
    }

    public static int GetNextInt()
    {
        return int.Parse(ReadNextWord());
    }

    public static string GetNextWord()
    {
        return ReadNextWord();
    }

    private static string ReadNextWord()
    {
        if (_input != null && _inputIndex >= _input.Length)
        {
            ReadNextInput();
        }

        return _input?[_inputIndex++]!;
    }
}