using JobPortal.Shared.Features.ManageJobs.EditJob;
using MediatR;
using System.Net.Http.Json;

namespace JobPortal.Client.Features.ManageJobs.EditJob;
public class GetJobHandler : IRequestHandler<GetJobRequest, GetJobRequest.Response?>
{
    //private readonly HttpClient _httpClient;
    private readonly IHttpClientFactory _httpClientFactory;

    //public GetJobHandler(HttpClient httpClient)
    //{
    //    _httpClient = httpClient;
    //}
    public GetJobHandler(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    public async Task<GetJobRequest.Response?> Handle(GetJobRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var client = _httpClientFactory.CreateClient("SecureAPIClient");

            //return await _httpClient.GetFromJsonAsync<GetJobRequest.Response>(GetJobRequest.RouteTemplate.Replace("{jobsId}", request.JobsId.ToString()));
            return await client.GetFromJsonAsync<GetJobRequest.Response>(GetJobRequest.RouteTemplate.Replace("{jobsId}", request.JobsId.ToString()));

        }
        catch (HttpRequestException)
        {
            return default!;
        }
    }
}

