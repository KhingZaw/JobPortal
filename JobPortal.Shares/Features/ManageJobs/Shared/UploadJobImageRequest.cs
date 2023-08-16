using MediatR;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Shared.Features.ManageJobs.Shared
{
    public record UploadJobImageRequest(int JobId, IBrowserFile File) : IRequest<UploadJobImageRequest.Response>
    {
        public const string RouteTemplate = "/api/jobs/{jobId}/images";

        public record Response(string ImageName);
    }
}
