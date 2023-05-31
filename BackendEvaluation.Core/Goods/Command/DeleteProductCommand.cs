using MediatR;

namespace BackendEvaluation.Core.Goods.Command;
public class DeleteProductCommand : IRequest<bool>
{
    public int ProductId { get; set; }
}
