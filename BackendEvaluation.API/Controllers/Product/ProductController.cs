using BackendEvaluation.API.Controllers.Base;
using BackendEvaluation.Core.Product;
using Microsoft.AspNetCore.Mvc;

namespace BackendEvaluation.API.Controllers.Product
{
    public class ProductController : BaseApiController
    {
        [HttpGet("Get")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<Product> GetProduct() => await Mediator.Send(new GetProductQuery());

        [HttpGet("Get/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<Product> GetProductById() => await Mediator.Send(new GetProductQuery());

        [HttpPost("CreateProducts")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<int> Create(CreateProductsCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPost("EditProduct")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<Product> Edit(CreateProductsCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("DeleteProduct/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<bool> Delete(int id)
        {
            return (bool)await Mediator.Send(id);
        }
    }
}
