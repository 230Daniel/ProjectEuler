namespace ProjectEuler;

public abstract class Problem
{
    public int Number { get; }
    public string Name { get; }

    protected Problem(int number, string name)
    {
        Number = number;
        Name = name;
    }

    public abstract object Run();

    public override string ToString()
    {
        return $"{Number}: {Name}";
    }
}
