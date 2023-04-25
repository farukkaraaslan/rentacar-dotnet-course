using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
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

           catch (DbUpdateException exception)
           {
               await HandleExceptionAsync(context, exception,exception.InnerException.Message);
           }
           catch (Exception exception)
           {
               await HandleExceptionAsync(context, exception, exception.Message);
           }
        }

       private async Task HandleExceptionAsync(HttpContext context, Exception exception, string ExceptionMessage)
       {
           context.Response.ContentType = "application/json";
           context.Response.StatusCode = StatusCodes.Status500InternalServerError;
           var result = new ExceptionResult
           {
               Type = exception.GetType().Name,
               Message = ExceptionMessage,
           };
           var json = JsonConvert.SerializeObject(result);

           await context.Response.WriteAsync(json);
       }
   }
}
