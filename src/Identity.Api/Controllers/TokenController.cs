using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Identity.Application.Dto;
using Identity.Application.Services.Query;
using Identity.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Identity.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public TokenController(IMapper mapper,
            IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<AcessTokenDto>> Post(GetAcessTokenDto getAcessTokenDto)
        {
            var token = await _mediator.Send(new GetAcessTokenByLoginQuery 
            { 
                User = _mapper.Map<User>(getAcessTokenDto)
            });

            if (token != null)
            {                
                return Ok(_mapper.Map<AcessTokenDto>(token));
            }

            return Unauthorized();
        }
    }
}
