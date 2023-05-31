using BackendEvaluation.Core.Common.Interfaces;
using BackendEvaluation.Domain.Models.Product;
using MediatR;
namespace BackendEvaluation.Core.Goods.Command;
public class CreateProductsCommandHandler : IRequestHandler<CreateProductsCommand, bool>
{
    private readonly IApplicationDbContext _context;
    public CreateProductsCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<bool> Handle(CreateProductsCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var prod = new Product { 
                Name = request.Name,
                Description= request.Description,
                Quantity= request.Quantity,
            };
            _context.Products.Add(prod);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
        catch (Exception ex)
        {
             throw new Exception(ex.Message, ex);
        }
    }
}
