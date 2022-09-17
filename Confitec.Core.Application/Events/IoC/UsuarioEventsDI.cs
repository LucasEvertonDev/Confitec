using Confitec.Core.Application.Events.Commands.Usuarios;
using Confitec.Core.Application.Events.Contracts;
using Confitec.Core.Application.Events.Contracts.Base;
using Confitec.Core.Application.Events.Dtos;
using Confitec.Core.Application.Events.Handlers;
using Confitec.Core.Application.Events.IoC.Base;
using Confitec.Core.Application.Events.Validators.Usuarios;
using Confitec.Core.Model.Models;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Confitec.Core.Application.Events.IoC
{
    public class UsuarioEventsDI : BaseEventsDI
    {
        public override void AddCommandHandlers(IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<UsuariosCreateCommand, Response<UsuarioModel>>, UsuariosEventHandler>();
            services.AddScoped<IRequestHandler<UsuariosUpdateCommand, Response<UsuarioModel>>, UsuariosEventHandler>();
            services.AddScoped<IRequestHandler<UsuariosDeleteCommand, Response>, UsuariosEventHandler>();
        }

        public override void AddEventsContract(IServiceCollection services)
        {
            services.AddScoped<IEventsContract<UsuarioModel>, UsuarioEventsContract>();
        }

        public override void AddQueryHandlers(IServiceCollection services)
        {
        }

        public override void AddValidatorCommands(IServiceCollection services)
        {
            services.AddScoped<IValidator<UsuariosCreateCommand>, UsuarioCreateCommandValidator>();
            services.AddScoped<IValidator<UsuariosDeleteCommand>, UsuarioDeleteCommandValidator>();
            services.AddScoped<IValidator<UsuariosUpdateCommand>, UsuarioUpdateCommandValidator>();
        }
    }
}
