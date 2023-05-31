using BackendEvaluation.API.Controllers.Goods;
using BackendEvaluation.Core.Common.Interfaces;
using BackendEvaluation.Domain.Models.Product;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BackendEvaluation.Core.Goods.Query;
public class GetProductQueryHandler : IRequestHandler<GetProductQuery, ProductListVM>
{
    private readonly IApplicationDbContext _context;
    public GetProductQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<ProductListVM> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var productList = new ProductListVM();
            var result = await _context.Products.Where(q => q.Id == request.Id).ToListAsync();
            if (result.Count > 0)
            {
                productList.products.AddRange(result);
            }
            return productList;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
