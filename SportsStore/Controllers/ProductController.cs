using Microsoft.AspNetCore.Mvc;
using SportsStore.Models.Interfaces;
using SportsStore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Controllers
{
   public class ProductController : Controller
   {
      private readonly IProductRepository _repo;
      public int PageSize = 4;

      public ProductController(IProductRepository repo)
      {
         _repo = repo;
      }

      public ViewResult List(int productPage = 1)
         => View(new ProductsListViewModel {
            Products = _repo.Products
               .OrderBy(p => p.ProductID)
               .Skip((productPage - 1) * PageSize)
               .Take(PageSize),
            PagingInfo = new PagingInfo
            {
               CurrentPage = productPage,
               ItemsPerPage = PageSize,
               TotalItems = _repo.Products.Count()
            }
         });
   }
}
