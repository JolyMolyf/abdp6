using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace WebApplication5.MidlleWare
{
    public class Midleware
    {
        private  RequestDelegate _next;

        public Midleware(RequestDelegate next)

        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            //Our code

            httpContext.Request.EnableBuffering();
            StringBuilder strb = new StringBuilder();
            StreamReader reader = new StreamReader(httpContext.Request.Body, Encoding.UTF8, true, 2048, true);
            strb.Append(httpContext.Request.Method);
            strb.Append("\n");
            strb.Append(httpContext.Request.Path);
            strb.Append("\n");
            string stream = "";
            stream = await reader.ReadToEndAsync();
            strb.Append(stream);
            strb.Append("\n");
            strb.Append(httpContext.Request.Query);
            strb.Append("\n");
            File.AppendAllText("logs.txt", strb.ToString());
            httpContext.Request.Body.Seek(0, SeekOrigin.Begin);
            await _next(httpContext);
        }
    }
}