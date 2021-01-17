namespace API.Configuracion
{
    using Base.Datos.DAL;
    using Base.Negocio.BL;
    using Microsoft.Extensions.DependencyInjection;

    public static class DependencyInjectionRegistry
    {
        public static IServiceCollection AddMyServices(this IServiceCollection services)
        {
            //PersonaDI
            services.AddScoped<PersonaDAL>();
            services.AddScoped<PersonaBL>();
            return services;
        }
    }
}