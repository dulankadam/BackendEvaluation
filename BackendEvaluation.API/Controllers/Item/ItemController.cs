using BackendEvaluation.API.Controllers.Base;
using BackendEvaluation.Core.Item;
using Microsoft.AspNetCore.Mvc;

namespace BackendEvaluation.API.Controllers.Item
{
    public class ItemController : BaseApiController
    {
        [HttpPost("CreateItems")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<int> Create(CreateItemsCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}
