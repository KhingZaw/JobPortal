using JobPortal.Shared.Features.Home.Shared;
using MediatR;
using System.Net.Http.Json;

namespace JobPortal.Features.Home
{
    public class GetJobHandler : IRequestHandler<GetJobsRequest, GetJobsRequest.Response?>
    {
        private readonly HttpClient _httpClient;

        public GetJobHandler(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<GetJobsRequest.Response?> Handle(GetJobsRequest request, CancellationToken cancellationToken)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<GetJobsRequest.Response>(GetJobsRequest.RouteTemplate);
            }
            catch (HttpRequestException)
            {
                return default!;
            }
        }
    }
}
