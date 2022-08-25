using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Aggregates.Business.Commands;
using Application.Aggregates.Business.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BusinessController : BaseController
    {
        /// <summary>
        /// Cria um comércio
        /// </summary>
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromForm] CreateBusiness.Command command)
        {
            return GetIActionResult(await Mediator.Send(command));
        }

        /// <summary>
        /// Atualiza um comércio
        /// </summary>
        [HttpPut("update")]
        public async Task<IActionResult> Update([FromForm] UpdateBusiness.Command command)
        {
            return GetIActionResult(await Mediator.Send(command));
        }

        /// <summary>
        /// Busca todos comércios
        /// </summary>
        [HttpGet("read/all")]
        public async Task<IActionResult> ReadAll()
        {
            return GetIActionResult(await Mediator.Send(new ListBusiness.Query { }));
        }

        /// <summary>
        /// Busca um comércio por id
        /// </summary>
        [HttpGet("read/{id}")]
        public async Task<IActionResult> Read(int id)
        {
            return GetIActionResult(await Mediator.Send(new DetailsBusiness.Query { Id = id }));
        }

        /// <summary>
        /// Exclui um comércio
        /// </summary>
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteBusiness.Command { Id = id };
            return GetIActionResult(await Mediator.Send(command));
        }
    }
}