using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using GamblingGame.Domain;
using GamblingGame.Domain.Consts;
using GamblingGame.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;

namespace GamblingGame.Api.Middlewares
{
    public class AuthenticateMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthenticateMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IAuthenticateContext authenticateContext)
        {
            if (!HasJwt(context.Request))
            {
                await _next(context);
                return;
            }

            var jwtString = GetJwtString(context.Request);
            var jwt = new JwtSecurityTokenHandler().ReadJwtToken(jwtString);
            var idClaim = jwt.Claims.SingleOrDefault(c => c.Type == Const.IdClaimType);
            if (idClaim != null && Guid.TryParse(idClaim.Value, out var id))
            {
                authenticateContext.UserId = id;
            }

            await _next(context);
        }

        private static bool HasJwt(HttpRequest request) =>
            request.Headers.ContainsKey(HeaderNames.Authorization) &&
            !request.Headers[HeaderNames.Authorization].IsNullOrEmpty() &&
            request.Headers[HeaderNames.Authorization].First().Length > Const.BearerPrefix.Length &&
            !request.Headers[HeaderNames.Authorization]
                .First()
                .Substring(Const.BearerPrefix.Length)
                .Trim()
                .IsNullOrEmpty();

        private static string GetJwtString(HttpRequest request) =>
            request.Headers[HeaderNames.Authorization].First().Substring(Const.BearerPrefix.Length).Trim();
    }
}
