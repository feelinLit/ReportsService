using AutoMapper;
using ReportsBLL.DataTransferObjects.Reports;
using ReportsBLL.Models.Reports;

namespace ReportsBLL.Tools.Mapping;

public class ReportProfile : Profile
{
    public ReportProfile()
    {
        CreateMap<Report, ReportDto>();

        CreateMap<AddReportDto, Report>();
    }
}