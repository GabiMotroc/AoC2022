namespace AoC2022.Days;

public class Day7
{
    private Directory TopDirectory { get; set; } = new();

    public int Part1()
    {
        ReadInput();

        TopDirectory.CalculateSize();
        var result = Directory.Traverse(TopDirectory).Where(x => x.Size <= 100_000);

        return result.Sum(x => x.Size);
    }

    public int Part2()
    {
        ReadInput();
        TopDirectory.CalculateSize();
        const int systemSize = 70_000_000;
        const int required = 30_000_000;
        var needed = Math.Abs(systemSize - TopDirectory.Size - required);
        var toBeDeleted = Directory.Traverse(TopDirectory)
            .Where(x => x.Size - needed > 0)
            .MinBy(x => x.Size - needed);
        return toBeDeleted!.Size;
    }

    private void ReadInput()
    {
        Console.ReadLine();
        TopDirectory = new Directory
        {
            Name = "/"
        };

        var currentDirectory = TopDirectory;
        while (Console.ReadLine() is { } line)
        {
            Command:
            if (line == null)
                break;
            if (line?[0] == '$')
            {
                var command = line.Split();

                if (command[1] == "cd")
                {
                    if (command[2] == "..")
                        currentDirectory = currentDirectory?.Parent;
                    else
                    {
                        currentDirectory = currentDirectory!.SubDirectory
                            .FirstOrDefault(x => x.Name == command[2]);
                    }
                }
                else
                {
                    line = ReadList(currentDirectory!);
                    goto Command;
                }
            }
        }
    }

    private string? ReadList(Directory currentDirectory)
    {
        var lines = new List<string>();
        string? line;
        while (true)
        {
            line = Console.ReadLine();
            if (line == null || line[0] == '$')
                break;
            lines.Add(line);
        }

        var directoriesLines = lines.Where(x => x[..3] == "dir").ToList();
        var directories = directoriesLines.Select(x =>
        {
            var details = x.Split();
            return new Directory
            {
                Name = details[1],
                Parent = currentDirectory,
            };
        }).ToList();
        currentDirectory.SubDirectory = directories;

        var filesLines = lines.Where(x => x[..3] != "dir").ToList();
        var files = filesLines.Select(x =>
        {
            var details = x.Split();
            return new File
            {
                Size = int.Parse(details[0]),
                Name = details[1],
            };
        }).ToList();
        currentDirectory.Files = files;

        return line;
    }
}

public class Directory
{
    public string Name { get; set; }
    public List<Directory> SubDirectory { get; set; }
    public Directory Parent { get; set; }
    public List<File> Files { get; set; }
    public int Size { get; set; }

    public int CalculateSize()
    {
        var size = SubDirectory.Sum(x => x.CalculateSize());
        size += Files.Sum(x => x.Size);
        Size = size;
        return size;
    }

    public static IEnumerable<Directory> Traverse(Directory root)
    {
        var stack = new Stack<Directory>();
        stack.Push(root);
        while (stack.Count > 0)
        {
            var current = stack.Pop();
            yield return current;
            foreach (var child in current.SubDirectory)
                stack.Push(child);
        }
    }
}

public struct File
{
    public string Name { get; set; }
    public int Size { get; set; }
}