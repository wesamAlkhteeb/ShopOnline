using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopOnline.API.Application.Services.interfaces;
using ShopOnline.API.Domain.Helper;
using ShopOnline.API.Domain.Models.Product;

namespace ShopOnline.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }
        [HttpPost]
        [Authorize(Roles =ConstantsService.ADMIN)]
        public async Task<IActionResult> AddProduct([FromForm] AddProductModel productModel)
        {
            return Ok(await productService.AddProduct(productModel));
        }

        [HttpGet("{page}")]
        [Authorize(Roles = ConstantsService.ADMIN + ","+ConstantsService.USER)]
        public async Task<IActionResult> GetProduct(int page)
        {
            return Ok(await productService.GetProduct(page));
        }

        [HttpGet("byId/{id}")]
        [Authorize(Roles = ConstantsService.ADMIN + "," + ConstantsService.USER)]
        public async Task<IActionResult> GetProductById(int id)
        {
            return Ok(await productService.GetProductById(id));
        }

        [HttpGet("categoryId/{categoryId}/{page}")]
        [Authorize(Roles = ConstantsService.ADMIN + "," + ConstantsService.USER)]
        public async Task<IActionResult> GetProductByCategoryId(int categoryId , int page)
        {
            return Ok(await productService.GetProductByCategoryId(categoryId,page));
        }

        [HttpPut]
        [Authorize(Roles = ConstantsService.ADMIN)]
        public async Task<IActionResult> PutProduct([FromBody]UpdateProductModel updateProduct)
        {
            return Ok(await productService.PutProduct(updateProduct));
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = ConstantsService.ADMIN)]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            return Ok(await productService.DeleteProduct(id));
        }

        [HttpPut("Image")]
        [Authorize(Roles = ConstantsService.ADMIN)]
        public async Task<IActionResult> PutImage([FromForm] PutImageProduct putImage)
        {
            return Ok(await productService.PutImage(putImage));
        }

    }
}
