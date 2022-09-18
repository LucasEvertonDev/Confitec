using Confitec.Core.Application.Services.Intefaces;
using Confitec.Core.Model.Models;
using Confitec.Infra.Utils.Exceptions;
using Confitec.Infra.Utils.Utils;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Confitec.Api.Attributes.Middlewares
{
    public class UsuarioMiddlewareAttribute : ActionFilterAttribute
    {
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var usuarioService = EngineContext.GetService<IUsuarioService<UsuarioModel>>();

            if (context.HttpContext.Request.RouteValues.ContainsKey("id"))
            {
                int userId = 0;

                int.TryParse(context.HttpContext.GetRouteValue("id")?.ToString() ?? "0", out userId);

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
