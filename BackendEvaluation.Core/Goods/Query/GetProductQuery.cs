using BackendEvaluation.Core.Goods.Query;
using BackendEvaluation.Domain.Models.Product;
using MediatR;

namespace BackendEvaluation.API.Controllers.Goods;
public class GetProductQuery : IRequest<ProductListVM>
{
    public int? Id { get; set; }
}