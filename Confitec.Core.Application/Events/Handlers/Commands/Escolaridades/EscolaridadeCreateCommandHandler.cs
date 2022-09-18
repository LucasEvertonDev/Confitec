using AutoMapper;
using Confitec.Core.Application.Events.Commands.Escolaridades;
using Confitec.Core.Application.Events.Dtos;
using Confitec.Core.Application.Events.Handlers.Base;
using Confitec.Core.Domain.Entities;
using Confitec.Core.Domain.Interfaces;
using Confitec.Core.Model.Models;
using MediatR;

namespace Confitec.Core.Application.Events.Handlers.Commands.Escolaridades
{
    public class EscolaridadeCreateCommandHandler : EventHandlerBase,
        IRequestHandler<EscolaridadeCreateCommand, Response<EscolaridadeModel>>
    {
        private readonly IRepository<Escolaridade> _escolaridadeRepository;
        private readonly IMapper _mapper;

        public EscolaridadeCreateCommandHandler(
            IRepository<Escolaridade> escolaridadeRepository,
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
        /// <exception cref="ApplicationException"></exception>
        public async Task<Response<EscolaridadeModel>> Handle(EscolaridadeCreateCommand request, CancellationToken cancellationToken)
        {
            return await OnHandler(request, async (request) =>
            {
                var schooling = _mapper.Map<Escolaridade>(request);

                if (schooling == null)
                {
                    throw new ApplicationException($"Error creating entity.");
                }

                var save = await _escolaridadeRepository.InsertAsync(schooling);

                await _escolaridadeRepository.CommitAsync();

                return new Response<EscolaridadeModel>()
                {
                    Result = _mapper.Map<EscolaridadeModel>(save)
                };
            });
        }
    }
}
