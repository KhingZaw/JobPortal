using JobPortal.Shared.Features.ManageJobs.EditJob;
using JobPortal.Shared.Features.ManageJobs.Employer;
using MediatR;
using System.Net.Http.Json;

namespace JobPortal.Features.ManageJobs.Employer;
public class EmployerJobHandler : IRequestHandler<EmployerJobRequest, EmployerJobRequest.Response>
{
    private readonly IHttpClientFactory _httpClientFactory;
    public EmployerJobHandler(IHttpClientFactory httpClientFactory)

    {
        _httpClientFactory = httpClientFactory;
    }
    public async Task<EmployerJobRequest.Response> Handle(EmployerJobRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var _Client = _httpClientFactory.CreateClient("SecureAPIClient");

           //return await _Client.GetFromJsonAsync<EmployerJobRequest.Response>(EmployerJobRequest.RouteTemplate);
            //var response = await _Client.GetFromJsonAsync<EmployerJobRequest.Response>(EmployerJobRequest.RouteTemplate);
            return await _Client.GetFromJsonAsync<EmployerJobRequest.Response>(EmployerJobRequest.RouteTemplate);

        }
        catch (HttpRequestException)
        {
            return default!;
        }
    }
}

