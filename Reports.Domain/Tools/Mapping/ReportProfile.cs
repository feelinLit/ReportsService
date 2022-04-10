using AutoMapper;
using Reports.Domain.DataTransferObjects;
using Reports.Domain.Models.Reports;

namespace Reports.Domain.Tools.Mapping;

public class ReportProfile : Profile
{
    public ReportProfile()
    {
        CreateMap<Report, ReportViewModel>();

        CreateMap<AddReportDto, Report>();
    }
}