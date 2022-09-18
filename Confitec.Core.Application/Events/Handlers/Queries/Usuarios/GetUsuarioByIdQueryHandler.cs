using AutoMapper;
using Confitec.Core.Application.Events.Dtos;
using Confitec.Core.Application.Events.Handlers.Base;
using Confitec.Core.Application.Events.Queries.Escolaridades;
using Confitec.Core.Application.Events.Queries.Usuarios;
using Confitec.Core.Domain.Entities;
using Confitec.Core.Domain.Interfaces;
using Confitec.Core.Model.Models;
using MediatR;

namespace Confitec.Core.Application.Events.Handlers.Queries.Usuarios
{
    public class GetUsuarioByIdQueryHandler : EventHandlerBase,
             IRequestHandler<GetUsuarioByIdQuery, Response<UsuarioModel>>
    {
        private readonly IRepository<Usuario> _usuarioRepository;
        private readonly IMapper _mapper;

        public GetUsuarioByIdQueryHandler(
            IRepository<Usuario> usuarioRepository,
            IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        public async Task<Response<UsuarioModel>> Handle(GetUsuarioByIdQuery request, CancellationToken cancellationToken)
        {
            return await OnHandler(request, async (request) =>
            {
                var user = await _usuarioRepository.FindByIdAsync(request.Id);

                return new Response<UsuarioModel>()
                {
                    Result = _mapper.Map<UsuarioModel>(user)
                };
            });
        }
    }
}
