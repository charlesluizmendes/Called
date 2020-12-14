using AutoMapper;
using Identity.Application.Dto;
using Identity.Domain.Entities;
using Identity.Domain.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.Application.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AcessTokenDto, AcessToken>();
            CreateMap<AcessToken, AcessTokenDto>();

            CreateMap<GetAcessTokenDto, User>()
                .ForMember(entity => entity.PasswordHash, opt => opt.MapFrom(dto => dto.Password));
            CreateMap<User, GetAcessTokenDto>()
                .ForMember(dto => dto.Password, opt => opt.MapFrom(entity => entity.PasswordHash));

            CreateMap<UserDto, User>();
            CreateMap<User, UserDto>()
                .ForMember(dto => dto.Name, opt => opt.MapFrom(entity => entity.UserName));

            CreateMap<CreateUserDto, User>()
                .ForMember(entity => entity.UserName, opt => opt.MapFrom(dto => dto.Name))
                .ForMember(entity => entity.PasswordHash, opt => opt.MapFrom(dto => dto.Password));
            CreateMap<User, CreateUserDto>()
                .ForMember(dto => dto.Name, opt => opt.MapFrom(entity => entity.UserName));

            CreateMap<UpdateUserDto, User>()
                .ForMember(entity => entity.UserName, opt => opt.MapFrom(dto => dto.Name))
                .ForMember(entity => entity.PasswordHash, opt => opt.MapFrom(dto => dto.Password));
            CreateMap<User, UpdateUserDto>()
                .ForMember(dto => dto.Name, opt => opt.MapFrom(entity => entity.UserName));
        }
    }
}
