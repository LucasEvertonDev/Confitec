using AutoMapper;
using Confitec.Core.Application.Events.Commands.Escolaridades;
using Confitec.Core.Application.Events.Commands.Usuarios;
using Confitec.Core.Application.Events.Dtos;
using Confitec.Core.Application.Events.Handlers.Base;
using Confitec.Core.Domain.Entities;
using Confitec.Core.Domain.Interfaces;
using MediatR;

namespace Confitec.Core.Application.Events.Handlers.Commands.Escolaridades
{
    public class EscolaridadeDeleteCommandHandler : EventHandlerBase,
        IRequestHandler<EscolaridadeDeleteCommand, Response>
    {
        private readonly IRepository<Escolaridade> _escolaridadeRepository;
        private readonly IMapper _mapper;

        public EscolaridadeDeleteCommandHandler(IRepository<Escolaridade> escolaridadeRepository,
            IMapper mapper)
        {
            _escolaridadeRepository = escolaridadeRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<Response> Handle(EscolaridadeDeleteCommand request, CancellationToken cancellationToken)
        {
            return await OnHandler(request, async (request) =>
            {
                var schooling = _mapper.Map<Escolaridade>(request);

                if (schooling == null)
                {
                    throw new ApplicationException($"Error deleting entity.");
                }

                var save = await _escolaridadeRepository.DeleteAsync(schooling);

                await _escolaridadeRepository.CommitAsync();

                return new Response() { };
            });
        }
    }
}
