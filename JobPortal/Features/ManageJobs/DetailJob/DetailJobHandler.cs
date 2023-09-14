using JobPortal.Shared.Features.ManageJobs.DetailJob;
using MediatR;
using System.Net.Http.Json;

namespace JobPortal.Features.ManageJobs.DetailJob;
public class DetailJobHandler : IRequestHandler<DetailJobRequest, DetailJobRequest.Response?>
{
    private readonly HttpClient _httpClient;
    public DetailJobHandler(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<DetailJobRequest.Response?> Handle(DetailJobRequest request, CancellationToken cancellationToken)
    {
        try
        {
            return await _httpClient.GetFromJsonAsync<DetailJobRequest.Response>(DetailJobRequest.RouteTemplate.Replace("{jobsId}", request.JobsId.ToString()));
        }
        catch (HttpRequestException)
        {
            return default!;
        }
    }
}



