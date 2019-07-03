using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;

namespace Pixey.Website.Middlewares
{
    /// <summary>
    /// This middleware is a temporary replacement until proper Authentication and Authorization
    /// is available. The idea is to make it play nicely with the integrated Auth framework so that
    /// we can plug in OAuth later.
    /// </summary>
    public class SignInUserMiddleware : IMiddleware
    {
        public const string UserIdCookieName = "UserId";

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            if (!context.User.Identity.IsAuthenticated)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, Guid.NewGuid().ToString("N"))
                };

                var userIdentity = new ClaimsIdentity(claims, "login");
                var principal = new ClaimsPrincipal(userIdentity);

                await context.SignInAsync(principal).ConfigureAwait(false);
            }

            await next(context).ConfigureAwait(false);
        }
    }
}