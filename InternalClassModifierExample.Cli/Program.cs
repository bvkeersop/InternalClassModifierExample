using InternalClassModifierExample;
using InternalClassModifierExample.ExternalAssembly;
using InternalClassModifierExample.ToyCreator;
using InternalClassModifierExample.ToyCreator.Model;
using Microsoft.Extensions.DependencyInjection;

// Below code is being used as expected
var serviceProvider = CreateServiceProvider();

Console.WriteLine("Beep, boop, I'm a robot that creates amazing toys!");
Console.WriteLine("How many toys do you want to create?");
var numberOfToys = PromptUserForNumberOfToys();

var toyCreator = serviceProvider.GetRequiredService<ICreateToys>();
var toys = toyCreator.CreateToys(numberOfToys);

PrintAllToyDescriptions(toys);

// Now let's misuse the external assembly!
// It's use was to expose utility to create toys, but since EnumRandomizer is public a reference can be made.
// The implementing side sees the EnumRandomizer and sees use for it, and decides to implement it.
// This is our fault as we didn't use the correct access modifier.
// The implementing side doesn't know what code is supposed to be internal or external.
// Now whener we change the INTERNAL workings of our code,
// we create a breaking change, and break the implementers code when they update to a new version.
var enumRandomizer = new EnumRandomizer();
var opinionOnToys = enumRandomizer.GetRandomEnumValue<Opinion>();
Console.WriteLine($"Hmmm, these toys are {opinionOnToys}"!);
Console.ReadKey();

static int PromptUserForNumberOfToys()
{
    Console.WriteLine("Please enter a number:");
    var input = Console.ReadLine();

    if(int.TryParse(input, out int result))
    {
        return result;
    }
    Console.WriteLine($"{input} is not a valid number, please enter a valid number");
    return PromptUserForNumberOfToys();
}

static void PrintAllToyDescriptions(IEnumerable<Toy> toys)
{
    foreach(var toy in toys)
    {
        Console.WriteLine(toy.GetDescription());
    }
}

static IServiceProvider CreateServiceProvider()
{
    var services = new ServiceCollection();
    services.AddToyCreator();
    return services.BuildServiceProvider();
}