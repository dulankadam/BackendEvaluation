using BackendEvaluation.Domain.Models.Product;
using MediatR;

namespace BackendEvaluation.Core.Goods.Command;
public class EditProductsCommand : IRequest<bool>
{
    public Product EditProducts { get; set; }
}
