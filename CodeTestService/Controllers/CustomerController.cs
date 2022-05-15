﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CodeTest.Infrastructure.Dispatcher;  
using CodeTest.Domain.Contract.Request;
using CodeTest.Domain.Queries;
using CodeTest.Domain.Commands;
using System.Net.Http;
using System.IO;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CodeTestService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        public CustomerController()
        {
        }

        [Route("GetCustomerInfo/{userId}")]
        [HttpGet]
        public async Task<IActionResult> GetCustomerInfo(string userId)
        {
            var query = new GetCustomerQuery(userId);
            var result = await MediatorDispatcher.ExecuteMediatorAsync<GetCustomerQuery>(query);
            return Ok(result);
        }
        [HttpPost]
        [Route("AddCustomerInfo")]
        public async Task<IActionResult> AddCustomerInfo([FromBody] AddCustomerInfoRequest user)
        {
            var cmd = new AddCustomerInfoCommand(user);
            if (string.IsNullOrEmpty(user.SocialNumber))
            {
                var msg = new HttpResponseMessage(HttpStatusCode.BadRequest) { ReasonPhrase = "Invalid Input" };
                throw new InvalidDataException(msg.ToString());
            }
            var result = await MediatorDispatcher.ExecuteMediatorAsync<AddCustomerInfoCommand>(cmd);
            return Ok(result);
        }
    }
}

