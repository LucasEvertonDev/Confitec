using Confitec.Core.Application.Services.Intefaces;
using Confitec.Core.Model.Dtos;
using Confitec.Core.Model.Models;
using Microsoft.AspNetCore.Mvc;

namespace Confitec.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly ILogger<UsuariosController> _logger;
        private readonly IService<UsuarioModel> _userService;

        public UsuariosController(ILogger<UsuariosController> logger,
            IService<UsuarioModel> serviceUser)
        {
            _logger = logger;
            _userService = serviceUser;
        }

        [HttpGet(Name = "")]
        public async Task<ResponseDTO<IEnumerable<UsuarioModel>>> Index()
        {
            return await _userService.FindAllAsync();
        }

        [HttpPost(Name = "")]
        public async Task<ResponseDTO<UsuarioModel>> Create([FromBody] RequestDTO<UsuarioModel> request)
        {
            return await _userService.CreateAsync(request);
        }

        [HttpDelete(Name = "")]
        public async Task<ResponseDTO> Delete([FromBody] RequestDTO request)
        {
            return await _userService.DeleteAsync(request);
        }

        [HttpPut(Name = "")]
        public async Task<ResponseDTO<UsuarioModel>> Update([FromBody] RequestDTO<UsuarioModel> request)
        {
            return await _userService.UpdateAsync(request);
        }
    }
}
