namespace API.Configuracion
{
    using Base.Datos.DAL;
    using Base.Negocio.BL;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.OpenApi.Models;
    using System;
    using System.IO;
    using System.Reflection;

    public static class DependencyInjectionRegistry
    {
        public static IServiceCollection AddMyServices(this IServiceCollection services)
        {
            //PersonaDI
            services.AddScoped<PersonaDAL>();
            services.AddScoped<PersonaBL>();

            #region Configuraciones de servicos para la API

            //Configuracion del servicio de Swagger
            services.AddSwaggerGen(config =>
            {
                config.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "V1",
                    Title = "API Synergy",
                    Description = "API Synergy. Gestion para laboratorios quimicos.",
                    Contact = new OpenApiContact()
                    {
                        Name = "Andres Leon",
                        Email = "personalandresll@gmail.com",
                        Url = new Uri("https://www.linkedin.com/in/marlon-andres-leon-leon-840a36192/")
                    }
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                config.IncludeXmlComments(xmlPath);
            });

            //Configuracion de los cors
            services.AddCors(opt =>
            {
                opt.AddPolicy("Default_CorsPolicy", o =>
                {
                    o.AllowAnyHeader();
                    o.AllowAnyMethod();
                    o.AllowAnyOrigin();
                });
            });

            //V2
            //services.AddCors(options => options.AddPolicy("ApiCorsPolicy", build =>
            //{
            //    build.WithOrigins("http://localhost:4200")
            //         .AllowAnyMethod()
            //         .AllowAnyHeader();

            //}));

            services.AddControllers();

            #endregion Configuraciones de servicos para la API

            return services;
        }
    }
}