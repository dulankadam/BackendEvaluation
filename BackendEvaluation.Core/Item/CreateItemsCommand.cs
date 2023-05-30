using MediatR;

namespace BackendEvaluation.Core.Item;
public class CreateItemsCommand : IRequest<int>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Quantity { get; set; }
}
