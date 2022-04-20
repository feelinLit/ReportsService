using AutoMapper;
using Reports.Domain.Models.Problems;
using Reports.Shared.DataTransferObjects;

namespace Reports.Domain.Tools.Mapping;

public class ProblemProfile : Profile
{
    public ProblemProfile()
    {
        CreateMap<Problem, ProblemViewModel>()
            .ForMember(dest => dest.State, opt => opt
                .MapFrom(src => src.State.ToString()));

        CreateMap<AddProblemDto, Problem>();
    }
}