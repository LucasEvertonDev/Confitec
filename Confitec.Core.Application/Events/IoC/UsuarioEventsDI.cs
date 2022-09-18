using Confitec.Core.Application.Events.Commands.Usuarios;
using Confitec.Core.Application.Events.Contracts;
using Confitec.Core.Application.Events.Contracts.Base;
using Confitec.Core.Application.Events.Dtos;
using Confitec.Core.Application.Events.Handlers;
using Confitec.Core.Application.Events.Handlers.Commands.Usuarios;
using Confitec.Core.Application.Events.Handlers.Queries.Usuarios;
using Confitec.Core.Application.Events.IoC.Base;
using Confitec.Core.Application.Events.Queries;
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
            services.AddScoped<IRequestHandler<UsuariosCreateCommand, Response<UsuarioModel>>, UsuariosCreateCommandHandler>();
            services.AddScoped<IRequestHandler<UsuariosUpdateCommand, Response<UsuarioModel>>, UsuariosUpdateCommandHandler>();
            services.AddScoped<IRequestHandler<UsuariosDeleteCommand, Response>, UsuariosDeleteCommandHandler>();
        }

        public override void AddEventsContract(IServiceCollection services)
        {
            services.AddScoped<IEventsContract<UsuarioModel>, UsuarioEventsContract>();
        }

        public override void AddQueryHandlers(IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<GetAllUsuariosQuery, Response<IEnumerable<UsuarioModel>>>, GetAllUsuariosQueryHandler>();
        }

        public override void AddValidatorCommands(IServiceCollection services)
        {
            services.AddScoped<IValidator<UsuariosCreateCommand>, UsuarioCreateCommandValidator>();
            services.AddScoped<IValidator<UsuariosDeleteCommand>, UsuarioDeleteCommandValidator>();
            services.AddScoped<IValidator<UsuariosUpdateCommand>, UsuarioUpdateCommandValidator>();
        }
    }
}
