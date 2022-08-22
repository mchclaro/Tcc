using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Aggregates.Product.Commands;
using Application.Aggregates.Product.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : BaseController
    {
        /// <summary>
        /// Cria um produto
        /// </summary>
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateProduct.Command command)
        {
            return GetIActionResult(await Mediator.Send(command));
        }

        /// <summary>
        /// Atualiza um produto
        /// </summary>
        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateProduct.Command command)
        {
            return GetIActionResult(await Mediator.Send(command));
        }

        /// <summary>
        /// Busca todos produtos
        /// </summary>
        [HttpGet("read/all")]
        public async Task<IActionResult> ReadAll()
        {
            return GetIActionResult(await Mediator.Send(new ListProduct.Query { }));
        }

        /// <summary>
        /// Exclui um produto
        /// </summary>
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteProduct.Command { Id = id };
            return GetIActionResult(await Mediator.Send(command));
        }
    }
}