using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Called.Application.Dto;
using Called.Application.Services.Command;
using Called.Application.Services.Query;
using Called.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Called.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public TicketController(IMapper mapper,
            IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<TicketDto>> Get()
        {
            var tickets = await _mediator.Send(new GetTicketQuery { });

            return Ok(_mapper.Map<List<TicketDto>>(tickets));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TicketDto>> Get(Guid id)
        {
            var ticket = await _mediator.Send(new GetTicketByIdQuery 
            { 
                Id = id
            });

            return Ok(_mapper.Map<TicketDto>(ticket));
        }

        [HttpPost]
        public async Task<ActionResult<TicketDto>> Post(CreateTicketDto createTicketDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(createTicketDto);
            }

            var ticket = await _mediator.Send(new CreateTicketCommand
            {
                Ticket = _mapper.Map<Ticket>(createTicketDto)
            });

            return Ok(_mapper.Map<TicketDto>(ticket));
        }        
    }
}
