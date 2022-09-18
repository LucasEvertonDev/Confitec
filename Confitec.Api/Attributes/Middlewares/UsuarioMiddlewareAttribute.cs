using Confitec.Core.Application.Services.Intefaces;
using Confitec.Core.Model.Dtos;
using Confitec.Core.Model.Models;
using Confitec.Core.Model.Models.Base;
using Confitec.Infra.Utils.Exceptions;
using Confitec.Infra.Utils.Utils;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace Confitec.Api.Attributes.Middlewares
{
    public class UsuarioMiddlewareAttribute : ActionFilterAttribute
    {
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (context.ActionArguments.ContainsKey("id"))
            {
                int userId = 0;

                int.TryParse(context.ActionArguments["id"]?.ToString() ?? "0", out userId);

                if ("PUT".Equals(context.HttpContext.Request.Method))
                {
                    var request = (dynamic)context.ActionArguments["request"];

                    if (request.Data.Id != userId)
                    {
                        throw new LogicalException("A chave id da rota é divergente da do objeto a ser atualizado");
                    }
                }

                var usuarioService = EngineContext.GetService<IUsuarioService<UsuarioModel>>();

                var user = await usuarioService.FindByIdAsync(userId);

                if (user == null || user.Data == null || user.Data.Id == 0)
                {
                    throw new LogicalException("Não existe nenhum usuário cadastrado para o id informado");
                }
            }
            await base.OnActionExecutionAsync(context, next);
        }
    }
}
