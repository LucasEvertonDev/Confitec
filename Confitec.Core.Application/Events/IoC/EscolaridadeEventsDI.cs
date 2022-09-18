using Confitec.Core.Application.Events.Commands.Escolaridades;
using Confitec.Core.Application.Events.Contracts;
using Confitec.Core.Application.Events.Contracts.Base;
using Confitec.Core.Application.Events.Dtos;
using Confitec.Core.Application.Events.Handlers.Commands.Escolaridades;
using Confitec.Core.Application.Events.Handlers.Queries.Escolaridades;
using Confitec.Core.Application.Events.IoC.Base;
using Confitec.Core.Application.Events.Queries.Escolaridades;
using Confitec.Core.Model.Models;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Confitec.Core.Application.Events.IoC
{
    public class EscolaridadeEventsDI : BaseEventsDI
    {
        public override void AddCommandHandlers(IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<EscolaridadeCreateCommand, Response<EscolaridadeModel>>, EscolaridadeCreateCommandHandler>();
            services.AddScoped<IRequestHandler<EscolaridadeUpdateCommand, Response<EscolaridadeModel>>, EscolaridadeUpdateCommandHandler>();
            services.AddScoped<IRequestHandler<EscolaridadeDeleteCommand, Response>, EscolaridadeDeleteCommandHandler>();
        }

        public override void AddEventsContract(IServiceCollection services)
        {
            services.AddScoped<IEventsContract<EscolaridadeModel>, EscolaridadeEventsContract>();
        }

        public override void AddQueryHandlers(IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<GetAllEscolaridadesQuery, Response<IEnumerable<EscolaridadeModel>>>, GetAllEscolaridadesQueryHandler>();
        }

        public override void AddValidatorCommands(IServiceCollection services)
        {
         
        }
    }
}