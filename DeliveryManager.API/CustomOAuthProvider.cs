using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DeliveryManager.API
{
    public class CustomOAuthProvider : OAuthAuthorizationServerProvider
    {
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            // Implemente a autenticação de usuário aqui (por exemplo, usando o Identity)
            // Verifique as credenciais do usuário, gere um ClaimsIdentity, etc.

            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));

            var props = new AuthenticationProperties(new Dictionary<string, string>
        {
            { "audience", context.ClientId ?? string.Empty }
        });

            var ticket = new AuthenticationTicket(identity, props);
            context.Validated(ticket);
        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            // Implemente a validação do cliente OAuth (por exemplo, verificar o client_id e client_secret)
            // Defina context.Validated() para autenticar o cliente
            return base.ValidateClientAuthentication(context);
        }
    }
}
