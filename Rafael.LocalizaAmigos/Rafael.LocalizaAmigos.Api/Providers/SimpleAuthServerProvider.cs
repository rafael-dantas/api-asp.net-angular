using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Security.Claims;

namespace Rafael.LocalizaAmigos.Api.Providers
{
    public class SimpleAuthServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new string[] { "*" });
            if (context.UserName != "amigo" || context.Password != "amigo")
            {
                context.SetError("invalid_user_or_password", "Usuário e/ou senha incorretos.");
                return;
            }
            ClaimsIdentity identity = new ClaimsIdentity(context.Options.AuthenticationType);
            context.Validated(identity);
        }
    }
}