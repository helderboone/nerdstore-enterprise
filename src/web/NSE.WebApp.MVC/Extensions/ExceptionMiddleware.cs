using Microsoft.AspNetCore.Http;
using NSE.WebApp.MVC.Services;
using Polly.CircuitBreaker;
using Refit;
using System.Net;
using System.Threading.Tasks;

namespace NSE.WebApp.MVC.Extensions
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private static IAutenticacaoService _autenticacaoService;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext, IAutenticacaoService autenticacaoService)
        {
            _autenticacaoService = autenticacaoService;

            try
            {
                await _next(httpContext);
            }
            catch (CustomHttpRequestException ex)
            {
                HandleRequestExceptionAsync(httpContext, ex.StatusCode);
            }
            catch(ValidationApiException ex)
            {
                HandleRequestExceptionAsync(httpContext, ex.StatusCode);
            }
            catch(ApiException ex)
            {
                HandleRequestExceptionAsync(httpContext, ex.StatusCode);
            }
            catch (BrokenCircuitException ex)
            {
                HandleCircuitBreakerExpcetion(httpContext);
            }
        }

        private static void HandleRequestExceptionAsync(HttpContext context, HttpStatusCode httpStatusCode)
        {
            if (httpStatusCode == HttpStatusCode.Unauthorized)
            {
                if (_autenticacaoService.TokenExpirado())
                {
                    if (_autenticacaoService.RefreshTokenValido().Result)
                    {
                        context.Response.Redirect(context.Request.Path);
                        return;
                    }
                }

                _autenticacaoService.Logout();
                context.Response.Redirect($"/login?ReturnUrl={context.Request.Path}");
                return;
            }

            context.Response.StatusCode = (int)httpStatusCode;
        }

        private static void HandleCircuitBreakerExpcetion(HttpContext context)
        {
            context.Response.Redirect("/sistema-indisponivel");
        }
    }
}
