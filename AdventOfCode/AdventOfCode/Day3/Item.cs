using System;

namespace AdventOfCode.Day3;

public sealed class Item : IEquatable<Item>
{
    private readonly char _value;

    public Item(char value, int priority)
    {
        _value = value;
        Priority = priority;
    }

    public int Priority { get; }

    public bool Equals(Item other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return _value == other._value && Priority == other.Priority;
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        return obj.GetType() == GetType() && Equals((Item) obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(_value, Priority);
    }

    public static bool operator ==(Item left, Item right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(Item left, Item right)
    {
        return !Equals(left, right);
    }
}