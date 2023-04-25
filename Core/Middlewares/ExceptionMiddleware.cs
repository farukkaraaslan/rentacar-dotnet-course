using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Core.Middlewares
{
   public class ExceptionMiddleware
   {
       private readonly RequestDelegate _next;

       public ExceptionMiddleware( RequestDelegate next)
       {
           _next=next;
       }

       public async Task InvokeAsync(HttpContext context)
       {
           try
           {
               await _next(context);
           }
           catch (Exception exception)
           {
               await HandleExceptionAsync(context, exception);
           }
       }

       private async Task HandleExceptionAsync(HttpContext context, Exception exception)
       {
           context.Response.ContentType = "application/json";
           context.Response.StatusCode = StatusCodes.Status500InternalServerError;
           var result = new ExceptionResult
           {
               Type = exception.GetType().Name,
               Message = exception.Message,
           };
           var json = JsonConvert.SerializeObject(result);

           await context.Response.WriteAsync(json);
       }
   }
}
