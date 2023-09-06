using JobPortal.Shared.Features.ManageJobs.Shared;
using MediatR;

namespace JobPortal.Features.ManageJobs.Shared;

public class UploadJobImageHandler : IRequestHandler<UploadJobImageRequest, UploadJobImageRequest.Response>
{
    //private readonly HttpClient _httpClient;
    private readonly IHttpClientFactory _httpClientFactory;

    //public UploadJobImageHandler(HttpClient httpClient)
    //{
    //    _httpClient = httpClient;
    //}
    public UploadJobImageHandler(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    public async Task<UploadJobImageRequest.Response> Handle(UploadJobImageRequest request, CancellationToken cancellationToken)
    {
        var fileContent = request.File.OpenReadStream(request.File.Size, cancellationToken);

        //using var content = new MultipartFormDataContent        
        //{
        //    { new StreamContent(fileContent), "image", request.File.Name }
        //};
        using var content = new MultipartFormDataContent();
        content.Add(new StreamContent(fileContent), "image", request.File.Name);

        var client = _httpClientFactory.CreateClient("SecureAPIClient");

        //var response = await _httpClient.PostAsync(UploadJobImageRequest.RouteTemplate.Replace("{jobId}", request.JobId.ToString()), content, cancellationToken);
        var response = await client.PostAsync(UploadJobImageRequest.RouteTemplate.Replace("{jobId}", request.JobId.ToString()), content, cancellationToken);

        if (response.IsSuccessStatusCode)
        {
            var fileName = await response.Content.ReadAsStringAsync(cancellationToken: cancellationToken);
            return new UploadJobImageRequest.Response(fileName);
        }
        else
        {
            return new UploadJobImageRequest.Response("");
        }
    }
}

