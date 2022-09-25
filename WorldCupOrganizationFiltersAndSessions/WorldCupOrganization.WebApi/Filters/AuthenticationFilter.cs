using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using WorldCupOrganization.Logic.Interfaces.Contracts;
using Microsoft.AspNetCore.Http;

namespace WorldCupOrganization.WebApi.Filters
{
    public class AuthenticationFilter : Attribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            string headerToken = context.HttpContext.Request.Headers["Authorization"];
            if (headerToken is null)
            {
                context.Result = new ContentResult()
                {
                    Content = "Se requiere un token",
                    StatusCode = 401
                };
            }
            else
            {
                try
                {
                    Guid token = Guid.Parse(headerToken);
                    VerifyToken(token, context);
                }
                catch (FormatException)
                {
                    context.Result = new ContentResult()
                    {
                        Content = "El formato del token es invalido",
                        StatusCode = 401

                    };
                }

            }
        }

        public void OnActionExecuted(ActionExecutedContext context) { }

        private void VerifyToken(Guid aToken, ActionExecutingContext aContext)
        {
            var session = GetSessionLogic(aContext);
            if (!session.IsValidToken(aToken))
            {
                aContext.Result = new ContentResult()
                {
                    Content = "Token invalido",
                    StatusCode = 401
                };
            }
            else
            {
                int adminLoggedId = session.GetAdminIdFromToken(aToken);
                aContext.HttpContext.Items.Add("adminId", adminLoggedId);
            }
        }

        private ISessionLogic GetSessionLogic(ActionExecutingContext context)
        {
            return context.HttpContext.RequestServices.GetService(typeof(ISessionLogic)) as ISessionLogic;
        }
    }
}
