using JobPortal.Shared.Features.MangeEmployer;
using MediatR;
using System.Net.Http.Json;

namespace JobPortal.Features.ManageEmployer;

public class GetEmployerHandler : IRequestHandler<GetEmployerRequest, GetEmployerRequest.Response?>
{
    private readonly HttpClient _httpClient;

    public GetEmployerHandler(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<GetEmployerRequest.Response?> Handle(GetEmployerRequest request, CancellationToken cancellationToken)
    {
        try
        {
            return await _httpClient.GetFromJsonAsync<GetEmployerRequest.Response>(GetEmployerRequest.RouteTemplate.Replace("{employerId}", request.EmployerId.ToString()));
        }
        catch (HttpRequestException)
        {
            return default!;
        }
    }

}
