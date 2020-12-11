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
            CreateMap<User, UserDto>();

            CreateMap<CreateUserDto, User>()
                .ForMember(entity => entity.PasswordHash, opt => opt.MapFrom(dto => HasherExtension.HashPassword(dto.Password)));
            CreateMap<User, CreateUserDto>();               

            CreateMap<UpdateUserDto, User>()
                .ForMember(entity => entity.PasswordHash, opt => opt.MapFrom(dto => HasherExtension.HashPassword(dto.Password)));
            CreateMap<User, UpdateUserDto>();                                
        }
    }
}
