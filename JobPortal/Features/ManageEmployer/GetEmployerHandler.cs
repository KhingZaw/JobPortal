using JobPortal.Shared.Features.ManageEmployer;
using MediatR;
using System.Net.Http.Json;

namespace JobPortal.Features.ManageEmployer;

public class GetEmployerHandler : IRequestHandler<GetEmployerRequest, GetEmployerRequest.Response?>
{
    private readonly IHttpClientFactory _httpClientFactory;
    public GetEmployerHandler(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    public async Task<GetEmployerRequest.Response?> Handle(GetEmployerRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var client = _httpClientFactory.CreateClient("SecureAPIClient");

            return await client.GetFromJsonAsync<GetEmployerRequest.Response>(GetEmployerRequest.RouteTemplate.Replace("{employerId}", request.EmployerId.ToString()));
        }
        catch (HttpRequestException)
        {
            return default!;
        }
    }

}
