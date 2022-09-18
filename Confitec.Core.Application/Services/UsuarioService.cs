using AutoMapper;
using Confitec.Core.Application.Events.Contracts.Base;
using Confitec.Core.Application.Services.Intefaces;
using Confitec.Core.Model.Models;
using MediatR;

namespace Confitec.Core.Application.Services
{
    public class UsuarioService : Service<UsuarioModel>, IUsuarioService<UsuarioModel>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private IEventsContract<UsuarioModel> _eventsContract; // Determina as ações padrões que serão disparadas pelo objeto

        public UsuarioService(IMapper mapper,
            IMediator mediator,
            IEventsContract<UsuarioModel> eventsContract) : base(mapper, mediator, eventsContract)
        {
            _mapper = mapper;
            _mediator = mediator;
            _eventsContract = eventsContract;
        }
    }
}
