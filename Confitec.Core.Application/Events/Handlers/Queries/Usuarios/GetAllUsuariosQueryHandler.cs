using AutoMapper;
using Confitec.Core.Application.Events.Dtos;
using Confitec.Core.Application.Events.Handlers.Base;
using Confitec.Core.Application.Events.Queries;
using Confitec.Core.Domain.Entities;
using Confitec.Core.Domain.Interfaces;
using Confitec.Core.Model.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Confitec.Core.Application.Events.Handlers.Queries.Usuarios
{
    public class GetAllUsuariosQueryHandler : EventHandlerBase,
             IRequestHandler<GetAllUsuariosQuery, Response<IEnumerable<UsuarioModel>>>
    {
        private readonly IRepository<Usuario> _usuarioRepository;
        private readonly IMapper _mapper;

        public GetAllUsuariosQueryHandler(
            IRepository<Usuario> usuarioRepository,
            IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<UsuarioModel>>> Handle(GetAllUsuariosQuery request, CancellationToken cancellationToken)
        {
            return await OnHandler<Response<IEnumerable<UsuarioModel>>, GetAllUsuariosQuery>(request, async (request) =>
            {
                var users = await _usuarioRepository.Table.ToListAsync();

                return new Response<IEnumerable<UsuarioModel>>()
                {
                    Result = _mapper.Map<IEnumerable<UsuarioModel>>(users)
                };
            });
        }
    }
}
