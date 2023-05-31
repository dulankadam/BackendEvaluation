using BackendEvaluation.API.Controllers.Base;
using BackendEvaluation.API.Controllers.Goods;
using BackendEvaluation.Core.Goods.Command;
using BackendEvaluation.Core.Goods.Query;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BackendEvaluation.API.Controllers.Product
{
    public class ProductController : BaseApiController
    {
        [Authorize]
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ProductListVM> GetProduct(int id)
        {            
            return await Mediator.Send(new GetProductQuery { Id = id});
        }

        [Authorize]
        [HttpPost("CreateProducts")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<bool> Create(CreateProductsCommand command)
        {
            return await Mediator.Send(command);
        }

        [Authorize]
        [HttpPut("EditProduct")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<bool> Edit(EditProductsCommand command)
        {
            return await Mediator.Send(command);
        }

        [Authorize]
        [HttpDelete("DeleteProduct")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<bool> Delete(DeleteProductCommand command)
        {
            var result = await Mediator.Send(command);
            return true;
        }
    }
}
