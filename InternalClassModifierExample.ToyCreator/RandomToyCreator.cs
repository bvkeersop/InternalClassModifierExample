using InternalClassModifierExample.ToyCreator.Model;

namespace InternalClassModifierExample.ToyCreator;

public interface ICreateToys
{
    Toy CreateToy();
    IEnumerable<Toy> CreateToys(int numberOfToys);
}

public class RandomToyCreator : ICreateToys
{
    private readonly IEnumRandomizer _enumRandomizer;

    public RandomToyCreator(IEnumRandomizer enumRandomizer)
    {
        _enumRandomizer = enumRandomizer;
    }

    public IEnumerable<Toy> CreateToys(int numberOfToys) =>
        Enumerable.Range(1, numberOfToys)
        .Select(_ => CreateToy());

    public Toy CreateToy() => new()
    {
        ToyType = _enumRandomizer.GetRandomEnumValue<ToyType>(),
        Color = _enumRandomizer.GetRandomEnumValue<Color>()
    };
}
