using AutoMapper;
using Called.Application.Dto;
using Called.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Called.Application.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TicketDto, Ticket>();
            CreateMap<Ticket, TicketDto>()
                .ForMember(dto => dto.DateHour, opt => opt.MapFrom(entity => entity.DateHour.ToString("dd/MM/yyyy HH:mm:ss")));

            CreateMap<CreateTicketDto, Ticket>();
            CreateMap<Ticket, CreateTicketDto>();

            CreateMap<UpdateTicketDto, Ticket>();
            CreateMap<Ticket, UpdateTicketDto>();

            CreateMap<DeleteTicketDto, Ticket>();
            CreateMap<Ticket, DeleteTicketDto>();
        }
    }
}
