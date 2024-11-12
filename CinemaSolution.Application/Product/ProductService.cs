using CinemaSolution.Data.EF;
using CinemaSolution.ViewModels.Common.Paging;
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
                                    where pc.IsDeleted == false
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

        public async Task<PagedResult<ProductComboViewModel>> GetPagedResult(GetProductPagingRequest request)
        {
            var query = from pc in cinemaDBContext.ProductCombos
                        join pic in cinemaDBContext.ProductInProductCombos on pc.Id equals pic.ProductComboId
                        join p in cinemaDBContext.Products on pic.ProductId equals p.Id
                        select new { pc, pic, p };

            var groupedProductCombos = await query.GroupBy(x => x.pc).Select(x =>
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

            if (!string.IsNullOrEmpty(request.Keyword))
            {
                groupedProductCombos = groupedProductCombos.Where(x => x.Name.Contains(request.Keyword)).ToList();
            }


            int totalRow = groupedProductCombos.Count();
            var data = groupedProductCombos.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToList();

            var pagedResult = new PagedResult<ProductComboViewModel>()
            {
                TotalRecords = totalRow,
                Items = data,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize
            };
            return pagedResult;
        }

        public async Task<ProductComboViewModel?> GetById(int id)
        {
            var productComboQuery = from pc in cinemaDBContext.ProductCombos
                                    join pic in cinemaDBContext.ProductInProductCombos on pc.Id equals pic.ProductComboId
                                    join p in cinemaDBContext.Products on pic.ProductId equals p.Id
                                    where pc.Id == id
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
                }).FirstOrDefaultAsync();
            return groupedProductCombos;
        }

        public async Task<bool> Delete(int id)
        {
            var productCombo = await cinemaDBContext.ProductCombos.FindAsync(id);
            if (productCombo == null)
            {
                throw new InvalidOperationException("Product not found");
            }

            productCombo.IsDeleted = true;

            // Sử dụng SaveChangesAsync() để cập nhật và trả về true nếu thành công
            return await cinemaDBContext.SaveChangesAsync() > 0;
        }
    }
}
