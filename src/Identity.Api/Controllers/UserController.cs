using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Identity.Application.Dto;
using Identity.Application.Services.Command;
using Identity.Application.Services.Query;
using Identity.Domain.Entities;
using Identity.Domain.Extensions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public UserController(IMapper mapper,
            IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<UserDto>> Get()
        {
            var users = await _mediator.Send(new GetUserQuery()
            {
            });

            return Ok(_mapper.Map<List<UserDto>>(users));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> Get(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest();
            }

            var user = await _mediator.Send(new GetUserByIdQuery
            {
                Id = id
            });

            return Ok(_mapper.Map<UserDto>(user));
        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> Post(CreateUserDto createUserDto)
        {
            var user = await _mediator.Send(new CreateUserCommand
            {
                User = _mapper.Map<User>(createUserDto)
            });

            return Ok(_mapper.Map<UserDto>(user));
        }

        [HttpPut]
        public async Task<ActionResult<UserDto>> Put(UpdateUserDto updateUserDto)
        {
            var _user = await _mediator.Send(new UpdateUserCommand
            {
                User = _mapper.Map<User>(updateUserDto)
            });

            return Ok(_mapper.Map<UserDto>(_user));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UserDto>> Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest();
            }           

            var _user = await _mediator.Send(new DeleteUserCommand
            {
                Id = id
            });

            return Ok(_mapper.Map<UserDto>(_user));
        }
    }
}
