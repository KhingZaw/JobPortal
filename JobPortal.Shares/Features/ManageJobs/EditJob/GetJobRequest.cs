﻿using MediatR;

namespace JobPortal.Shared.Features.ManageJobs.EditJob;

public record GetJobRequest(int JobsId) : IRequest<GetJobRequest.Response>
{
    public const string RouteTemplate = "/api/jobs/{jobsId}";

    public record Response(Jobs Jobs);
    public record Jobs(
        int Id,
        string Name,
        string? Image,
        string FrameworkName,
        string PLanguage,
        string EmployerName,
        string JobType,
        int TimeInMinutes,
        string OpentoName,
        string Opento,
        string SourceName,
        string Description,
        string Location,
        int Salary,
        IEnumerable<JobDescription> JobDescriptions,
        IEnumerable<JobRequirement> JobRequirements);/*int TimeInMinutes,*/

    public record JobDescription(
        int Id, 
        int Stage, 
        string Descriptions);
    public record JobRequirement(
        int Id,
        int Stage, 
        string Requirement);

}