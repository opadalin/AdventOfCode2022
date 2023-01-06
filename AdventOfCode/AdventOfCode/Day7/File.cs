namespace AdventOfCode.Day7;

public class File : Node
{
    private readonly long _size;
    private readonly string _fileType;

    private File(string name, long size) : base(name)
    {
        _size = size;
        _fileType = GetFileType();
    }

    public static File Create(string terminalOutput)
    {
        var fileProperties = terminalOutput.Split(" ");
        var size = long.Parse(fileProperties[0]);
        var fileName = fileProperties[1];
        return new File(fileName, size);
    }

    public override long GetSize()
    {
        return _size;
    }

    private string GetFileType()
    {
        var fileType = "Document";
        var split = Name.Split(".");

        if (split.Length == 2)
        {
            fileType = $"{split[1].ToUpper()}-file";
        }

        return fileType;
    }

    public override string ToString()
    {
        return $"Kind: {_fileType}, Name: {Name}, Size: {GetSize()}";
    }
}