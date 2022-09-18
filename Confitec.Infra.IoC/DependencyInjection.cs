﻿using AutoMapper;
using Confitec.Core.Application.Events.Commands.Usuarios;
using Confitec.Core.Application.Events.Contracts;
using Confitec.Core.Application.Events.Contracts.Base;
using Confitec.Core.Application.Events.Handlers;
using Confitec.Core.Application.Events.Validators.Usuarios;
using Confitec.Core.Application.Mappings;
using Confitec.Core.Application.Services;
using Confitec.Core.Application.Services.Intefaces;
using Confitec.Core.Domain.Entities;
using Confitec.Core.Domain.Interfaces;
using Confitec.Core.Model.Models;
using Confitec.Infra.Data.Contexts;
using Confitec.Infra.Data.Repositorys;
using Confitec.Infra.IoC.Configurations;
using Confitec.Infra.IoC.Injections;
using Confitec.Infra.Utils.Utils;
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
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            // Add Mapper Profiles
            services.AddMapperProfiles();

            // Adiciona os repositórios do projeto
            services.AddRepositorys();

            // Adiciona os servicos do projeto
            services.AddServices();

            // Adiciona os eventos (handlers) e mapeamentos relacionados ao mesmo
            services.AddEvents();

            // Add MemoryCache
            services.AddMemoryCache();

            // Incluir service Provider para instanciar classes fora do construtor pela injeção
            EngineContext.AddServiceProvider(services.BuildServiceProvider());

            return services;
        }
    }
}
