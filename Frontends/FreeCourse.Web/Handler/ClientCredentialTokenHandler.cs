using FreeCourse.Web.Exceptions;
using FreeCourse.Web.Services.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace FreeCourse.Web.Handler
{
    public class ClientCredentialTokenHandler:DelegatingHandler
    {
        private readonly IClientCridentialTokenService _clientCridentialTokenService;

        public ClientCredentialTokenHandler(IClientCridentialTokenService clientCridentialTokenService)
        {
            _clientCridentialTokenService = clientCridentialTokenService;
        }

        protected  override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer",await _clientCridentialTokenService.GetToken());

            var response = await base.SendAsync(request, cancellationToken);
            if (response.StatusCode==HttpStatusCode.Unauthorized)
            {
                throw new UnAutharizedException();
            }
            return response;
        }
    }
}
