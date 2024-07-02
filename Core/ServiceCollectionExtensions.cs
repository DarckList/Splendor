using Core.Components.Nobels;
using Microsoft.Extensions.DependencyInjection;

namespace Core;
public static class ServiceCollectionExtensions
{
	public static IServiceCollection AddSplenderCore(this IServiceCollection services)
	{
		services.AddSingleton<Random>();
		services.AddTransient<IDevelopmentCardFactory, DevelopmentCardFactory>();
		services.AddTransient<INobelFactory, NobelFactory>();
		return services;
	}
}
