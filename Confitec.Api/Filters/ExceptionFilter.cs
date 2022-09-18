using Confitec.Core.Model.Dtos;
using Confitec.Infra.Utils.Exceptions;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Confitec.Api.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is ValidatorException)
            {
                var response = new ResponseDTO()
                {
                    Errors = (context.Exception as ValidatorException).Errors
                };
                context.Result = new JsonResult(response) { StatusCode = 400 };
            }
            else if (context.Exception is HandlerException)
            {
                context.ExceptionHandled = true;
                var response = new ResponseDTO()
                {
                    Errors = new List<string>()
                    {
                        "Ocorreu um erro ao se conectar a base de dados. Por favor tente novamente mais tarde."
                    }
                };

                context.Result = new JsonResult(response) { StatusCode = 500 };
            }
            else if (context.Exception is LogicalException)
            {
                context.ExceptionHandled = true;
                var response = new ResponseDTO()
                {
                    Errors = new List<string>()
                    {
                        context.Exception.Message
                    }
                };

                context.Result = new JsonResult(response) { StatusCode = 400 };
            }
            else
            {
                context.ExceptionHandled = true;
                var response = new ResponseDTO()
                {
                    Errors = new List<string>()
                    {
                        "Ocorreu um erro ao realizar a ação. Por favor tente novamente mais tarde."
                    }
                };

                context.Result = new JsonResult(response) { StatusCode = 500 };
            }
        }
    }
}
