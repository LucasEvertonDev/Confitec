using AutoMapper;
using Confitec.Core.Application.Events.Commands.Usuarios;
using Confitec.Core.Application.Events.Dtos;
using Confitec.Core.Application.Events.Handlers.Base;
using Confitec.Core.Domain.Entities;
using Confitec.Core.Domain.Interfaces;
using MediatR;

namespace Confitec.Core.Application.Events.Handlers.Commands.Usuarios
{
    public class UsuariosDeleteCommandHandler : EventHandlerBase,
        IRequestHandler<UsuariosDeleteCommand, Response>
    {
        private readonly IRepository<Usuario> _usuarioRepository;
        private readonly IMapper _mapper;

        public UsuariosDeleteCommandHandler(IRepository<Usuario> usuarioRepository,
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
        /// <exception cref="NotImplementedException"></exception>
        public async Task<Response> Handle(UsuariosDeleteCommand request, CancellationToken cancellationToken)
        {
            return await OnHandler(request, async (request) =>
            {
                var user = _mapper.Map<Usuario>(request);

                if (user == null)
                {
                    throw new ApplicationException($"Error deleting entity.");
                }

                var save = await _usuarioRepository.DeleteAsync(user);

                await _usuarioRepository.CommitAsync();

                return new Response() { };
            });
        }
    }
}
