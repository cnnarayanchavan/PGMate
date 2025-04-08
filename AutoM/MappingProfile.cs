using AutoMapper;
using PGMate.Models;

namespace PGMate.AutoM
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CleaningTask, CleaningTaskDto>().ReverseMap();
            CreateMap<PGMember, PGMemberDTO>().ReverseMap();
            CreateMap<Room, RoomDTO>().ReverseMap();
        }
    }
}
