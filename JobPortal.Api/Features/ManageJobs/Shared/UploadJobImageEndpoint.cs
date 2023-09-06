using Ardalis.ApiEndpoints;
using JobPortal.Api.Persistence;
using JobPortal.Shared.Features.ManageJobs.Shared;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JobPortal.Api.Features.ManageJobs.Shared
{
    public class UploadJobImageEndpoint : BaseAsyncEndpoint.WithRequest<int>.WithResponse<string>
    {
        private readonly JobPortalContext _database;

        public UploadJobImageEndpoint(JobPortalContext database)
        {
            _database = database;
        }
        [Authorize]
        [HttpPost(UploadJobImageRequest.RouteTemplate)]
        public override async Task<ActionResult<string>> HandleAsync([FromRoute] int jobId, CancellationToken cancellationToken = default)
        {
            var job = await _database.Jobs.SingleOrDefaultAsync(x => x.Id == jobId, cancellationToken);
            if (job is null)
            {
                return BadRequest("Job does not exist.");
            }
            if (!job.Owner.Equals(HttpContext.User.Identity!.Name, StringComparison.OrdinalIgnoreCase) && !HttpContext.User.IsInRole("Administrator"))
            {
                return Unauthorized();
            }
            var file = Request.Form.Files[0];
            if (file.Length == 0)
            {
                return BadRequest("No image found.");
            }

            var filename = $"{Guid.NewGuid()}.jpg";
            var saveLocation = Path.Combine(Directory.GetCurrentDirectory(), "Images", filename);

            var resizeOptions = new ResizeOptions
            {
                Mode = ResizeMode.Pad,
                Size = new Size(640, 426)
            };

            using var image = Image.Load(file.OpenReadStream());
            image.Mutate(x => x.Resize(resizeOptions));
            await image.SaveAsJpegAsync(saveLocation, cancellationToken: cancellationToken);

            if (!string.IsNullOrWhiteSpace(job.Image))
            {
                System.IO.File.Delete(Path.Combine(Directory.GetCurrentDirectory(), "Images", job.Image));
            }

            job.Image = filename;
            await _database.SaveChangesAsync(cancellationToken);

            return Ok(job.Image);
        }
    }

}

