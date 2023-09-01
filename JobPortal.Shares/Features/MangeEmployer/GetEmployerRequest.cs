using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Shared.Features.MangeEmployer
{
    public record GetEmployerRequest(int EmployerId): IRequest<GetEmployerRequest.Response>
    {

        public const string RouteTemplate = "/api/Employers";

        public record Response(Employers Employers);
        public record Employers
        (
        int Id,
        string EmployerName,
        string EmployerEmail,
        string EmployerPhone,
        string? Image,
        string Location,
        string Description );
    }
}