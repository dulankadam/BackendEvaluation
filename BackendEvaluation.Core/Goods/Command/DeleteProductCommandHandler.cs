using BackendEvaluation.Core.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BackendEvaluation.Core.Goods.Command;
public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, bool>
{
    private readonly IApplicationDbContext _context;
    public DeleteProductCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
		try
		{
            var deleteResult = await _context.Products.Where(d => d.Id == request.ProductId).FirstAsync();
            if (deleteResult != null)
            {
                _context.Products.Remove(deleteResult);
                _context.SaveChangesAsync();

                return true;
            }

            return false;
            
		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message);
		}
    }
}

