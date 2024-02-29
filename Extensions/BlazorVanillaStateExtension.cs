using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorVanillaState.MAUI.Extensions
{
    public static class BlazorVanillaStateExtension
    {
        public static IServiceCollection UseBlazorVanillaState(this IServiceCollection services, Action<IServiceCollection> action)
        {
            action.Invoke(services);

            return services;
        }

        public static IServiceCollection AddState<T>(this IServiceCollection services) where T : class
        {
            services.AddSingleton<T>();

            return services;
        }
    }
}
