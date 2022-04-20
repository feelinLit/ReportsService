using AutoMapper;
using Reports.Domain.Models.Reports;
using Reports.Shared.DataTransferObjects;

namespace Reports.Domain.Tools.Mapping;

public class ReportProfile : Profile
{
    public ReportProfile()
    {
        CreateMap<Report, ReportViewModel>();

        CreateMap<AddReportDto, Report>();
    }
}