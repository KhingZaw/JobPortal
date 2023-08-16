using JobPortal.Shared.Features.ManageJobs.EditJob;
using MediatR;
using System.Net.Http.Json;

namespace JobPortal.Client.Features.ManageJobs.EditJob;

public class EditJobHandler : IRequestHandler<EditJobRequest, EditJobRequest.Response>
{
    private readonly HttpClient _httpClient;

    public EditJobHandler (HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<EditJobRequest.Response> Handle(EditJobRequest request, CancellationToken cancellationToken)
    {
        var response = await _httpClient.PutAsJsonAsync(EditJobRequest.RouteTemplate, request, cancellationToken);

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
