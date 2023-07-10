using AutoMapper;
using LeaveManager.web.Models;
using LeaveManager.web.ViewModels;

namespace LeaveManager.web.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        { 
            CreateMap<LeaveType, LeaveTypeViewModel>().ReverseMap();   
        
        }




    }
}
