using CinemaSolution.Data.EF;
using CinemaSolution.ViewModels.Product;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSolution.Application.Product
{
    public class ProductService : IProductService
    {
        private readonly CinemaDBContext cinemaDBContext;
        public ProductService(CinemaDBContext cinemaDBContext)
        {
            this.cinemaDBContext = cinemaDBContext;
        }
        public async Task<List<ProductComboViewModel>> GetProductCombos()
        {
            var productComboQuery = from pc in cinemaDBContext.ProductCombos
                                    join pic in cinemaDBContext.ProductInProductCombos on pc.Id equals pic.ProductComboId
                                    join p in cinemaDBContext.Products on pic.ProductId equals p.Id
                                    select new { pc, pic, p };

            var groupedProductCombos = await productComboQuery.GroupBy(x => x.pc).Select(x => 
                new ProductComboViewModel
                {
                    Id = x.Key.Id,
                    Name = x.Key.Name,
                    Description = x.Key.Description,
                    ImageUrl = x.Key.ImageUrl,
                    Price = x.Key.Price,
                    Items = x.Select(y => new ProductViewModel
                    {
                        Id = y.p.Id,
                        Name = y.p.Name,
                        Description = y.p.Description,
                        Quantity = y.pic.Quantity
                    }).ToList()
                }).ToListAsync();

            return groupedProductCombos;
        }
    }
}
