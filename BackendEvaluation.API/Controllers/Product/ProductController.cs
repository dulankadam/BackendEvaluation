using BackendEvaluation.API.Controllers.Base;
using BackendEvaluation.API.Controllers.Goods;
using BackendEvaluation.Core.Goods.Command;
using BackendEvaluation.Core.Goods.Query;
using BackendEvaluation.Domain.Models.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BackendEvaluation.API.Controllers.Product
{
    public class ProductController : BaseApiController
    {
        [HttpGet("Get")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ProductListVM> GetProduct(GetProductQuery product)
        {
            return (ProductListVM)await Mediator.Send(product);
        }

        [HttpPost("CreateProducts")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<bool> Create(CreateProductsCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("EditProduct")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<bool> Edit(EditProductsCommand command)
        {
            return await Mediator.Send(command);
        }
        
        [AllowAnonymous]
        [HttpDelete("DeleteProduct")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<bool> Delete(DeleteProductCommand command)
        {
            return (bool)await Mediator.Send(command);
        }
    }
}
