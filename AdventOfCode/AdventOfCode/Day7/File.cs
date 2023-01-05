namespace AdventOfCode.Day7;

public class File : Node
{
    private readonly long _size;
    private readonly string _fileType;

    public File(string name, long size) : base(name)
    {
        _size = size;
        _fileType = GetFileType();
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

    public virtual string ToString()
    {
        return $"Kind: {_fileType}, Name: {Name}, Size: {GetSize()}";
    }
}