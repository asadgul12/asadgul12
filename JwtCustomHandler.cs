using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace AspNetCoreAuthenticationAuthorization.IjwtCustomTokens.CustomeJwtHandler
{
    public class BasicAuthScheme : AuthenticationSchemeOptions
    {

    }
    public class JwtCustomHandler : AuthenticationHandler<BasicAuthScheme>
    {
        private readonly IJwtCustomerManager jwtCustomerManager;
        public JwtCustomHandler(IOptionsMonitor<BasicAuthScheme> optionsMonitor,ILoggerFactory loggerFactory,
            UrlEncoder urlEncoder,
            ISystemClock systemClock,
            IJwtCustomerManager jwtCustomerManager
            )            
            :base(optionsMonitor,loggerFactory,urlEncoder,systemClock)
        {
            this.jwtCustomerManager = jwtCustomerManager;
        }
       
        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            string authorizeheader = Request.Headers["Authorization"];
            string token = authorizeheader.Substring("bearer".Length).Trim();
         //   throw new NotImplementedException();
        }
        public string valdidateToken(string token)
        {
            var valitoken = jwtCustomerManager.Tokens.FirstOrDefault(T => T.Key == token);
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name,valitoken.Value)
            };
            var idetity = new ClaimsIdentity(claims,Scheme.Name);

            var principal = new ClaimsPrincipal(idetity);
            var ticket = new AuthenticationTicket(principal,Scheme.Name);
            return AuthenticateResult.Success(ticket);
        
        
        
        }
    }
}
