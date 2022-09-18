using AutoMapper;
using Confitec.Core.Application.Events.Dtos;
using Confitec.Core.Application.Events.Handlers.Base;
using Confitec.Core.Application.Events.Queries.Escolaridades;
using Confitec.Core.Domain.Entities;
using Confitec.Core.Domain.Interfaces;
using Confitec.Core.Model.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Confitec.Core.Application.Events.Handlers.Queries.Escolaridades
{
    public class GetAllEscolaridadesQueryHandler : EventHandlerBase,
             IRequestHandler<GetAllEscolaridadesQuery, Response<IEnumerable<EscolaridadeModel>>>
    {
        private readonly IRepository<Escolaridade> _escolaridadeRepository;
        private readonly IMapper _mapper;

        public GetAllEscolaridadesQueryHandler(
            IRepository<Escolaridade> escolaridadeRepository,
            IMapper mapper)
        {
            _escolaridadeRepository = escolaridadeRepository;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<EscolaridadeModel>>> Handle(GetAllEscolaridadesQuery request, CancellationToken cancellationToken)
        {
            return await OnHandler(request, async (request) =>
            {
                var schoolings = await _escolaridadeRepository.Table.ToListAsync();

                return new Response<IEnumerable<EscolaridadeModel>>()
                {
                    Result = _mapper.Map<IEnumerable<EscolaridadeModel>>(schoolings)
                };
            });
        }
    }
}
