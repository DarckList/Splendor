using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Core;
public static class ServiceCollectionExtensions
{
	public static IServiceCollection AddSplenderCore(this IServiceCollection services)
	{
		services.AddSingleton<Random>();
		services.AddTransient<IDevelopmentCardFactory, DevelopmentCardFactory>();
		return services;
	}
}
