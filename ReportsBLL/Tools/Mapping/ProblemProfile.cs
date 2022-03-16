using AutoMapper;
using ReportsBLL.DataTransferObjects.Problems;
using ReportsBLL.Models.Problems;

namespace ReportsBLL.Tools.Mapping;

public class ProblemProfile : Profile
{
    public ProblemProfile()
    {
        CreateMap<Problem, ProblemDto>()
            .ForMember(dest => dest.State, opt => opt
                .MapFrom(src => src.State.ToString()));

        CreateMap<AddProblemDto, Problem>();
    }
}