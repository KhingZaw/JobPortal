using JobPortal.Shared.Features.ManageJobs.AddJob;
using MediatR;
using System.Net.Http;
using System.Net.Http.Json;

namespace JobPortal.Client.Features.ManageJobs.AddJob;

public class AddJobslHandler : IRequestHandler<AddJobRequest, AddJobRequest.Response>
{
   // private readonly HttpClient _httpClient;
    private readonly IHttpClientFactory _httpClientFactory;

    //public AddJobslHandler(HttpClient httpClient)
    //{
    //    _httpClient = httpClient;
    //}
    public AddJobslHandler(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<AddJobRequest.Response> Handle(AddJobRequest request, CancellationToken cancellationToken)
    {
        var client = _httpClientFactory.CreateClient("SecureAPIClient");

        // var response = await _httpClient.PostAsJsonAsync(AddJobRequest.RouteTemplate, request, cancellationToken);
        var response = await client.PostAsJsonAsync(AddJobRequest.RouteTemplate, request, cancellationToken);

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