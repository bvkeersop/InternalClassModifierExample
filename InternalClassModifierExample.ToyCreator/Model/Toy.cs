namespace InternalClassModifierExample.ToyCreator.Model;

public enum Color
{
    Red,
    Green,
    Blue,
    Yellow,
}

public enum ToyType
{
    Teddybear,
    Car,
    Doll,
    Ball
}

public class Toy
{
    public Color Color { get; set; }
    public ToyType ToyType { get; set; }

    public string GetDescription() => $"This toy is a {Color} {ToyType}";
}
