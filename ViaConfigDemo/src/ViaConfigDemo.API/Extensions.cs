using RulesEngine.Models;

namespace ViaConfigDemo.API
{
    public static class Extensions
    {
        public static IServiceCollection AddRulesEngine(this IServiceCollection services, IConfiguration configuration)
        {
            ArgumentNullException.ThrowIfNull(services);

            var workflows = configuration.GetSection("RulesEngine").Get<List<Workflow>>();

            if (workflows == null)
                return services;

            var re = new RulesEngine.RulesEngine(workflows.ToArray());

            services.AddSingleton<RulesEngine.RulesEngine>(re);

            return services;
        }
    }
}
