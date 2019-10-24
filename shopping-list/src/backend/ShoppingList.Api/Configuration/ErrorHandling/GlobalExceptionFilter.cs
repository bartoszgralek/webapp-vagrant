namespace ShoppingList.Api.Configuration.ErrorHandling
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc.Filters;
    using NLog;

    public class GlobalExceptionFilter : ExceptionFilterAttribute
    {
        private readonly ILogger _logger = LogManager.GetCurrentClassLogger();

        public override async Task OnExceptionAsync(ExceptionContext context)
        {
            _logger.Error(context.Exception);

            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

            await context.HttpContext.Response.WriteAsync(context.Exception.Message);

            await base.OnExceptionAsync(context);
        }
    }
}