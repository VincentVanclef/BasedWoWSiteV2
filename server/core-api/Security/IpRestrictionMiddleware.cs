using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace server.Security
{
    public class IpRestrictionMiddleware
    {
        public readonly RequestDelegate Next;
        public readonly IpSecuritySettings IpSecuritySettings;

        public IpRestrictionMiddleware(RequestDelegate next, IOptions<IpSecuritySettings> ipSecuritySettings)
        {
            Next = next;
            IpSecuritySettings = ipSecuritySettings.Value;
        }

        public async Task Invoke(HttpContext context)
        {
            var localAddress = context.Connection.LocalIpAddress?.ToString();
            var remoteAddress = context.Connection.RemoteIpAddress?.ToString();

            if (localAddress != remoteAddress && IpSecuritySettings.BlockedIPsList.Contains(remoteAddress))
            {
                context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                return;
            }

            await Next(context);
        }
    }
}
