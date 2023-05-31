using MediatR;

namespace BackendEvaluation.Core.Goods.Command;
public class CreateProductsCommand : IRequest<bool>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Quantity { get; set; }
}
