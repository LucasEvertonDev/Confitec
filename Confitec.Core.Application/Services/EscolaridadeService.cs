using AutoMapper;
using Confitec.Core.Application.Events.Contracts.Base;
using Confitec.Core.Application.Services.Intefaces;
using Confitec.Core.Domain.Entities;
using Confitec.Core.Domain.Interfaces;
using Confitec.Core.Model.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Confitec.Core.Application.Services
{
    public class EscolaridadeService : Service<EscolaridadeModel>, IEscolaridadeService<EscolaridadeModel>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private IEventsContract<EscolaridadeModel> _eventsContract; // Determina as ações padrões que serão disparadas pelo objeto

        public EscolaridadeService(IMapper mapper,
            IMediator mediator,
            IEventsContract<EscolaridadeModel> eventsContract) : base(mapper, mediator, eventsContract)
        {
            _mapper = mapper;
            _mediator = mediator;
            _eventsContract = eventsContract;
        }

        public async Task<bool> UsuarioExists(int id)
        {
            var user = await this.FindByIdAsync(id);

            return user != null && user.Data.Id > 0; 
        }
    }
}
