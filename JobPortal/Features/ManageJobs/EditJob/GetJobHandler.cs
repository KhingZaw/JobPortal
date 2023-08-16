using JobPortal.Shared.Features.ManageJobs.EditJob;
using MediatR;
using System.Net.Http.Json;

namespace JobPortal.Client.Features.ManageJobs.EditJob;
public class GetJobHandler : IRequestHandler<GetJobRequest, GetJobRequest.Response?>
{
    private readonly HttpClient _httpClient;

    public GetJobHandler(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<GetJobRequest.Response?> Handle(GetJobRequest request, CancellationToken cancellationToken)
    {
        try
        {
            return await _httpClient.GetFromJsonAsync<GetJobRequest.Response>(GetJobRequest.RouteTemplate.Replace("{jobsId}", request.JobsId.ToString()));
        }
        catch (HttpRequestException)
        {
            return default!;
        }
    }
}

