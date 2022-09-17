using Confitec.Core.Application.DTOs;
using Confitec.Core.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Confitec.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly ILogger<UsuariosController> _logger;
        private readonly IService<UsuarioDto> _serviceUser;

        public UsuariosController(ILogger<UsuariosController> logger,
            IService<UsuarioDto> serviceUser)
        {
            _logger = logger;
            _serviceUser = serviceUser;
        }

        [HttpGet(Name = "GetUsuarios")]
        public async Task<UsuarioDto?> Get()
        {
            return await _serviceUser.Create(new UsuarioDto { Nome = "Lucas", Sobrenome = "Oliveira" });
        }
    }
}
