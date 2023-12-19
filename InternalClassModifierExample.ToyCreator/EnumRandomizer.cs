namespace InternalClassModifierExample.ToyCreator;

// DEMO:
// This interface should be internal, we are now exposing it to other assemblies
// Whenever we change this interface, it's a breaking change
public interface IEnumRandomizer
{
    TEnum GetRandomEnumValue<TEnum>() where TEnum : Enum;
}

// DEMO:
// This class should be internal, we are now exposing it to other assemblies
// Whenever we change this interface, it's a breaking change
public class EnumRandomizer : IEnumRandomizer
{
    private readonly Random _random;

    public EnumRandomizer()
    {
        _random = new Random();
    }

    public TEnum GetRandomEnumValue<TEnum>() where TEnum : Enum
    {
        if (!typeof(TEnum).IsEnum)
        {
            throw new ArgumentException("Type parameter must be an enumeration type.");
        }

        Array enumValues = Enum.GetValues(typeof(TEnum));
        int randomIndex = _random.Next(enumValues.Length);

        return (TEnum)enumValues.GetValue(randomIndex)!;
    }
}
