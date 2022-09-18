using Confitec.Api.Attributes;
using Confitec.Api.Attributes.Middlewares;
using Confitec.Core.Application.Services.Intefaces;
using Confitec.Core.Model.Dtos;
using Confitec.Core.Model.Models;
using Microsoft.AspNetCore.Mvc;

namespace Confitec.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [UsuarioMiddleware]
    public class UsuariosController : ControllerBase
    {
        private readonly ILogger<UsuariosController> _logger;
        private readonly IService<UsuarioModel> _userService;

        public UsuariosController(ILogger<UsuariosController> logger,
            IUsuarioService<UsuarioModel> serviceUser)
        {
            _logger = logger;
            _userService = serviceUser;
        }

        [HttpGet("{id}")]
        public async Task<ResponseDTO<UsuarioModel>> Find(int id)
        {
            return await _userService.FindByIdAsync(id);
        }

        [HttpGet]
        public async Task<ResponseDTO<IEnumerable<UsuarioModel>>> FindAll()
        {
            return await _userService.FindAllAsync();
        }

        [HttpPost]
        public async Task<ResponseDTO<UsuarioModel>> Create([FromBody] RequestDTO<UsuarioModel> request)
        {
            return await _userService.CreateAsync(request);
        }

        [HttpDelete("{id}")]
        public async Task<ResponseDTO> Delete(int id)
        {
            return await _userService.DeleteAsync(id);
        }

        [HttpPut("{id}")]
        public async Task<ResponseDTO<UsuarioModel>> Update(int id, [FromBody] RequestDTO<UsuarioModel> request)
        {
            return await _userService.UpdateAsync(request);
        }
    }
}
