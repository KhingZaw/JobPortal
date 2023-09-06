using JobPortal.Shared.Features.ManageJobs.EditJob;
using MediatR;
using System.Net.Http.Json;

namespace JobPortal.Client.Features.ManageJobs.EditJob;

public class EditJobHandler : IRequestHandler<EditJobRequest, EditJobRequest.Response>
{
    //private readonly HttpClient _httpClient;
    private readonly IHttpClientFactory _httpClientFactory;

    //public EditJobHandler (HttpClient httpClient)
    public EditJobHandler(IHttpClientFactory httpClientFactory)

    {
        //_httpClient = httpClient;
        _httpClientFactory = httpClientFactory;

    }

    public async Task<EditJobRequest.Response> Handle(EditJobRequest request, CancellationToken cancellationToken)
    {
        var client = _httpClientFactory.CreateClient("SecureAPIClient");

       // var response = await _httpClient.PutAsJsonAsync(EditJobRequest.RouteTemplate, request, cancellationToken);
        var response = await client.PutAsJsonAsync(EditJobRequest.RouteTemplate, request, cancellationToken);


        if (response.IsSuccessStatusCode)
        {
            return new EditJobRequest.Response(true);
        }
        else
        {
            return new EditJobRequest.Response(false);
        }
    }
}
