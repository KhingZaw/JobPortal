using JobPortal.Shared.Features.ManageJobs.AddJob;
using MediatR;
using System.Net.Http.Json;

namespace JobPortal.Client.Features.ManageJobs.AddJob;

public class AddJobslHandler : IRequestHandler<AddJobRequest, AddJobRequest.Response>
{
    private readonly HttpClient _httpClient;

    public AddJobslHandler(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<AddJobRequest.Response> Handle(AddJobRequest request, CancellationToken cancellationToken)
    {
        var response = await _httpClient.PostAsJsonAsync(AddJobRequest.RouteTemplate, request, cancellationToken);

        if (response.IsSuccessStatusCode)
        {
            var jobsId = await response.Content.ReadFromJsonAsync<int>(cancellationToken: cancellationToken);
            return new AddJobRequest.Response(jobsId);
        }
        else
        {
            return new AddJobRequest.Response(-1);
        }
    }
}
