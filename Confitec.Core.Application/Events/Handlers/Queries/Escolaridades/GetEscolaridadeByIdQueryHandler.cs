using AutoMapper;
using Confitec.Core.Application.Events.Dtos;
using Confitec.Core.Application.Events.Handlers.Base;
using Confitec.Core.Application.Events.Queries.Escolaridades;
using Confitec.Core.Domain.Entities;
using Confitec.Core.Domain.Interfaces;
using Confitec.Core.Model.Models;
using MediatR;

namespace Confitec.Core.Application.Events.Handlers.Queries.Escolaridades
{
    public class GetEscolaridadeByIdQueryHandler : EventHandlerBase,
             IRequestHandler<GetEscolaridadeByIdQuery, Response<EscolaridadeModel>>
    {
        private readonly IRepository<Escolaridade> _escolaridadeRepository;
        private readonly IMapper _mapper;

        public GetEscolaridadeByIdQueryHandler(
            IRepository<Escolaridade> escolaridadeRepository,
            IMapper mapper)
        {
            _escolaridadeRepository = escolaridadeRepository;
            _mapper = mapper;
        }

        public async Task<Response<EscolaridadeModel>> Handle(GetEscolaridadeByIdQuery request, CancellationToken cancellationToken)
        {
            return await OnHandler(request, async (request) =>
            {
                var schooling = await _escolaridadeRepository.FindByIdAsync(request.Id);

                return new Response<EscolaridadeModel>()
                {
                    Result = _mapper.Map<EscolaridadeModel>(schooling)
                };
            });
        }
    }
}
