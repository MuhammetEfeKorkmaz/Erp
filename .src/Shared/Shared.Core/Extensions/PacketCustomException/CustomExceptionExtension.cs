using Microsoft.AspNetCore.Http;

namespace Shared.Backend.Core.Extensions.PacketCustomException
{
    public class CustomExceptionExtension
    {
        private RequestDelegate _next;

        public CustomExceptionExtension(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                // Gerekli Dönüş Tipleri Belirlenecek.
               // await HandleExceptionAsync(httpContext, ex);
            }

        }
    }
}
