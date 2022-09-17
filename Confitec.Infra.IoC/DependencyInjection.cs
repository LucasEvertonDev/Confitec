using AutoMapper;
using Confitec.Core.Application.DTOs;
using Confitec.Core.Application.Events.Commands.Usuarios;
using Confitec.Core.Application.Events.Contracts;
using Confitec.Core.Application.Events.Contracts.Base;
using Confitec.Core.Application.Events.Handlers;
using Confitec.Core.Application.Events.Validators.Usuarios;
using Confitec.Core.Application.Mappings;
using Confitec.Core.Application.Services;
using Confitec.Core.Domain.Entities;
using Confitec.Core.Domain.Interfaces;
using Confitec.Infra.Data.Contexts;
using Confitec.Infra.Data.Repositorys;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel.DataAnnotations;

namespace Confitec.Infra.IoC
{
    public static class DependencyInjection
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddInfraEstructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer("Data Source=localhost;Initial Catalog=Web.Confitec;User ID=sa;Password=12345;Connect Timeout=120;Integrated Security=True;TrustServerCertificate=True",
                b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MapperProfile());
            });

            services.AddScoped<IRepository<Usuario>, Repository<Usuario>>();
            services.AddScoped<IEventsContract<UsuarioDto>, UsuarioEventsContract>();
            services.AddScoped<IService<UsuarioDto>, Service<UsuarioDto>>();

            // Domain - Commands
            services.AddScoped<IRequestHandler<UsuariosCreateCommand, UsuarioDto>, UsuariosEventHandler>();
            services.AddScoped<IRequestHandler<UsuariosUpdateCommand, UsuarioDto>, UsuariosEventHandler>();
            services.AddScoped<IRequestHandler<UsuariosDeleteCommand, UsuarioDto>, UsuariosEventHandler>();


            //services.AddScoped<IRequestHandler<UsuariosCreateCommand, ValidationResult>, UsuariosEventHandler>();
            //services.AddScoped<IRequestHandler<UsuariosUpdateCommand, ValidationResult>, UsuariosEventHandler>();
            //services.AddScoped<IRequestHandler<UsuariosDeleteCommand, ValidationResult>, UsuariosEventHandler>();

            services.AddScoped<IValidator<UsuariosCreateCommand>, UsuarioCommandValidator>();

            services.AddSingleton(mapperConfig.CreateMapper());

            var myhandlers = AppDomain.CurrentDomain.Load("Confitec.Core.Application");
            services.AddMediatR(myhandlers);

            services.AddMemoryCache();

            return services;
        }
    }
}
