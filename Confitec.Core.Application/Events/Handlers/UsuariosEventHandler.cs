using AutoMapper;
using Confitec.Core.Application.Events.Commands.Usuarios;
using Confitec.Core.Application.Events.Dtos;
using Confitec.Core.Application.Events.Handlers.Base;
using Confitec.Core.Domain.Entities;
using Confitec.Core.Domain.Interfaces;
using Confitec.Core.Model.Models;
using MediatR;

namespace Confitec.Core.Application.Events.Handlers
{
    public class UsuariosEventHandler : EventHandlerBase,
        IRequestHandler<UsuariosCreateCommand, Response<UsuarioModel>>,
        IRequestHandler<UsuariosUpdateCommand, Response<UsuarioModel>>,
        IRequestHandler<UsuariosDeleteCommand, Response>
    {
        private readonly IRepository<Usuario> _usuarioRepository;
        private readonly IMapper _mapper;

        public UsuariosEventHandler(IRepository<Usuario> usuarioRepository,
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
            return await OnHandler<Response<UsuarioModel>, UsuariosCreateCommand>(request, async (request) =>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<Response<UsuarioModel>> Handle(UsuariosUpdateCommand request, CancellationToken cancellationToken)
        {
            return await OnHandler<Response<UsuarioModel>, UsuariosUpdateCommand>(request, async (request) =>
            {
                var user = _mapper.Map<Usuario>(request);

                if (user == null)
                {
                    throw new ApplicationException($"Error updating entity.");
                }

                var save = await _usuarioRepository.UpdateAsync(user);

                await _usuarioRepository.CommitAsync();

                return new Response<UsuarioModel>()
                {
                    Result = _mapper.Map<UsuarioModel>(save)
                };
            });
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
            return await OnHandler<Response, UsuariosDeleteCommand>(request, async (request) =>
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