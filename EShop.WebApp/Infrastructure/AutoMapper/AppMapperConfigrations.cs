using AutoMapper;
using EShop.Areas.Admin.Models.UserModels;
using EShop.Entities.Domain;

namespace EShop.Infrastructure.AutoMapper
{
    public  class AppMapperConfigrations : Profile
    {
        public AppMapperConfigrations()
        {
            AddMappers();
        }
        public  void AddMappers()
        {
            //services.AddAutoMapper(typeof(UserModel), typeof(User));
            //services.AddAutoMapper(typeof(User), typeof(UserModel));
            CreateMap<User, UserModel>();
            CreateMap<UserModel, User>();
        }
    }
}
