using System;
using AutoMapper;
using AutoMapper.Configuration;
using LearnProject.Model;
using LearnProject.Models.ViewModels;

namespace LearnProject.Mappers
{
    public class CommonMapper : IMapper
    {
        static CommonMapper()
        {
            Mapper.Initialize(cfg =>
               cfg.CreateMap<User, UserView>()
                .ForMember(dest => dest.BirthdateDay, opt => opt.MapFrom(src => src.Birthdate.Day))
                .ForMember(dest => dest.BirthdateMonth, opt => opt.MapFrom(src => src.Birthdate.Month))
                .ForMember(dest => dest.BirthdateYear, opt => opt.MapFrom(src => src.Birthdate.Year)));

            Mapper.Initialize(cfg =>
               cfg.CreateMap<UserView, User>()
                .ForMember(dest => dest.Birthdate, opt => opt.MapFrom(src => new DateTime(src.BirthdateYear, src.BirthdateMonth, src.BirthdateDay))));

//            Mapper.AssertConfigurationIsValid();

            //2.0
            //Mapper.CreateMap<User, UserView>()
            //    .ForMember(dest => dest.BirthdateDay, opt => opt.MapFrom(src => src.Birthdate.Day))
            //    .ForMember(dest => dest.BirthdateMonth, opt => opt.MapFrom(src => src.Birthdate.Month))
            //    .ForMember(dest => dest.BirthdateYear, opt => opt.MapFrom(src => src.Birthdate.Year));
            //Mapper.CreateMap<UserView, User>()
            //    .ForMember(dest => dest.Birthdate, opt => opt.MapFrom(src => new DateTime(src.BirthdateYear, src.BirthdateMonth, src.BirthdateDay)));
        }

        public object Map(object source, Type sourceType, Type destinationType)
        {
            return Mapper.Map(source, sourceType, destinationType);
        }
    }
}