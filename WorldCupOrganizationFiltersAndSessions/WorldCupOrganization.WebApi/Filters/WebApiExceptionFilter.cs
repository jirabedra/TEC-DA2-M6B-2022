using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using WorldCupOrganization.Logic.Interfaces.Errors;

namespace WorldCupOrganization.WebApi.Filters
{
    public class WebApiExceptionFilter : Attribute, IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            try
            {
                throw context.Exception;
            }
            catch (InterruptedActionException)
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 400,
                    Content = context.Exception.Message
                };
            }
            catch (Exception)
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 500,
                    Content = "Error inesperado [FILTER]: " + context.Exception.Message
                };
            }
        }
    }
}