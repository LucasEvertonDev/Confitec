using AutoMapper;
using Confitec.Core.Application.DTOs;
using Confitec.Core.Application.Events.Commands.Usuarios;
using Confitec.Core.Domain.Entities;
using Confitec.Core.Domain.Interfaces;
using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace Confitec.Core.Application.Events.Handlers
{
    public class UsuariosEventHandler : IRequestHandler<UsuariosCreateCommand, UsuarioDto>,
        IRequestHandler<UsuariosUpdateCommand, UsuarioDto>,
        IRequestHandler<UsuariosDeleteCommand, UsuarioDto>
    {
        private readonly IRepository<Usuario> _usuarioRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<UsuariosCreateCommand> _validatorCreateCommand;

        public UsuariosEventHandler(IRepository<Usuario> usuarioRepository,
            IMapper mapper,
            IValidator<UsuariosCreateCommand> validatorCreateCommand)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
            _validatorCreateCommand = validatorCreateCommand;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="ApplicationException"></exception>
        public async Task<UsuarioDto> Handle(UsuariosCreateCommand request, CancellationToken cancellationToken)
        {

            ValidationResult result = await _validatorCreateCommand.ValidateAsync(request);
            var user = _mapper.Map<Usuario>(request);

            if (user == null)
            {
                throw new ApplicationException($"Error creating entity.");
            }
            else
            {
                var save = await _usuarioRepository.InsertAsync(user);

                await _usuarioRepository.CommitAsync();

                return _mapper.Map<UsuarioDto>(save);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<UsuarioDto> Handle(UsuariosUpdateCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<Usuario>(request);

            if (user == null)
            {
                throw new ApplicationException($"Error creating entity.");
            }
            else
            {
                var save = await _usuarioRepository.UpdateAsync(user);

                await _usuarioRepository.CommitAsync();

                return _mapper.Map<UsuarioDto>(save);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<UsuarioDto> Handle(UsuariosDeleteCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<Usuario>(request);

            if (user == null)
            {
                throw new ApplicationException($"Error creating entity.");
            }
            else
            {
                var save = await _usuarioRepository.DeleteAsync(user);

                await _usuarioRepository.CommitAsync();

                return _mapper.Map<UsuarioDto>(save);
            }
        }
    }
}