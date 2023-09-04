using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Shared.Features.ManageEmployer
{
    public record GetEmployerRequest : IRequest<GetEmployerRequest.Response>
    {

        public const string RouteTemplate = "/api/employers";

        public record Employers
        (
            int Id,
            string EmployerName,
            string EmployerEmail,
            string EmployerPhone,
            string? Image,
            string Location,
            string Description);

        public record Response(IEnumerable<Employers> Employers);

    }
}