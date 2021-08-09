using AutoMapper;
using DataAccess.Models;
using Business.DTO;
namespace Business.Mapping
{
    public class MappingProfile : Profile
    {
        
        public  MappingProfile()
        {
            //Domain to DTO
            CreateMap<User, UserSignUp>();
          

            //DTO to DTO

             CreateMap<UserSignUp, User>();
            

        }
    }
}