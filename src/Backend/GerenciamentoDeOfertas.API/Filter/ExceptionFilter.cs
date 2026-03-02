using GerenciamentoDeOfertas.Communication.Responses;
using GerenciamentoDeOfertas.Exceptions.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GerenciamentoDeOfertas.API.Filter
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if(context.Exception is GerenciamentoDeOfertasException)
                HandlerProjectException(context);
            else
                HandlerUnknownException(context);
        }

        private void HandlerProjectException(ExceptionContext context)
        {
            if(context.Exception is ErroNaValidacaoException excepton)
            {
                context.HttpContext.Response.StatusCode = (int)excepton.StatusCode;
                context.Result = new BadRequestObjectResult(new ResponseErroJson(excepton.ErroMessages));
            }
        }
        private void HandlerUnknownException(ExceptionContext context)
        {
            context.HttpContext.Response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
            context.Result = new ObjectResult(new ResponseErroJson("Ocorreu um erro inesperado."));
        }
    }
}
