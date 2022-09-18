using AutoMapper;
using Confitec.Core.Application.Events.Commands.Usuarios;
using Confitec.Core.Application.Events.Dtos;
using Confitec.Core.Application.Events.Handlers.Base;
using Confitec.Core.Domain.Entities;
using Confitec.Core.Domain.Interfaces;
using Confitec.Core.Model.Models;
using MediatR;

namespace Confitec.Core.Application.Events.Handlers.Commands.Usuarios
{
    public class UsuariosCreateCommandHandler : EventHandlerBase,
        IRequestHandler<UsuariosCreateCommand, Response<UsuarioModel>>
    {
        private readonly IRepository<Usuario> _usuarioRepository;
        private readonly IMapper _mapper;

        public UsuariosCreateCommandHandler(
            IRepository<Usuario> usuarioRepository,
            IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="ApplicationException"></exception>
        public async Task<Response<UsuarioModel>> Handle(UsuariosCreateCommand request, CancellationToken cancellationToken)
        {
            return await OnHandler(request, async (request) =>
            {
                var user = _mapper.Map<Usuario>(request);

                if (user == null)
                {
                    throw new ApplicationException($"Error creating entity.");
                }

                var save = await _usuarioRepository.InsertAsync(user);

                await _usuarioRepository.CommitAsync();

                return new Response<UsuarioModel>()
                {
                    Result = _mapper.Map<UsuarioModel>(save)
                };
            });
        }
    }
}
