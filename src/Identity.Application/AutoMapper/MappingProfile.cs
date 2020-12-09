using AutoMapper;
using Identity.Application.Dto;
using Identity.Domain.Entities;
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
            CreateMap<User, GetAcessTokenDto>();

            CreateMap<UserDto, User>();
            CreateMap<User, UserDto>();

            CreateMap<CreateUserDto, User>()
                .ForMember(entity => entity.PasswordHash, opt => opt.MapFrom(dto => dto.Password));
            CreateMap<User, CreateUserDto>();

            CreateMap<UpdateUserDto, User>()
                .ForMember(entity => entity.PasswordHash, opt => opt.MapFrom(dto => dto.Password));
            CreateMap<User, UpdateUserDto>();

            CreateMap<DeleteUserDto, User>();
            CreateMap<User, DeleteUserDto>();            
        }
    }
}
