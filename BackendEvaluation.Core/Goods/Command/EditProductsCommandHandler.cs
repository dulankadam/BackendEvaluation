using BackendEvaluation.Core.Common.Interfaces;
using BackendEvaluation.Core.Goods.Query;
using BackendEvaluation.Domain.Models.Product;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BackendEvaluation.Core.Goods.Command;
public class EditProductsCommandHandler : IRequestHandler<EditProductsCommand, bool>
{
    private readonly IApplicationDbContext _context;
    public EditProductsCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<bool> Handle(EditProductsCommand request, CancellationToken cancellationToken)
    {
        try
        {
            if (request == null)
                throw new NullReferenceException("Request shoudn't be null.");

            var product = _context.Products.Where(p => p.Id == request.EditProducts.Id).FirstOrDefault();
            
            if (product != null)
            {
                product.UpdatedDate = DateTime.Now;
                product.Name = request.EditProducts.Name;
                product.Description = request.EditProducts.Description;
                product.Quantity = request.EditProducts.Quantity;
            };
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}