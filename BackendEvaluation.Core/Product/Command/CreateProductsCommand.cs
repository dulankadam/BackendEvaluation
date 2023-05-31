using MediatR;

namespace BackendEvaluation.Core.Product.Command;
public class CreateProductsCommand : IRequest<int>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Quantity { get; set; }
}
