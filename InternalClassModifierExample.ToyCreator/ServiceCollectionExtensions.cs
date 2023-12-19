using Microsoft.Extensions.DependencyInjection;

namespace InternalClassModifierExample.ToyCreator;
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddToyCreator(this IServiceCollection services)
        => services
        .AddScoped<ICreateToys, RandomToyCreator>()
        .AddScoped<IEnumRandomizer, EnumRandomizer>();
}
