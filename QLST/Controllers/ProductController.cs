using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLST.Models;

namespace QLST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public static List<ProductVN> products = new List<ProductVN>();
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(products);
        }
        [HttpPost]
        public IActionResult Create(ProductVN productVN)
        {
            var product = new ProductVN
            {
                idProduct = Guid.NewGuid(),
                name = productVN.name,
                price = productVN.price
            };
            products.Add(product);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            // Kiểm tra nếu id không phải là GUID hợp lệ
            if (!Guid.TryParse(id, out Guid parsedId))
            {
                return BadRequest("Invalid ID format.");
            }

            // Tìm sản phẩm trong danh sách
            var product = products.SingleOrDefault(hh => hh.idProduct == parsedId);

            // Nếu tìm thấy sản phẩm, trả về 200 OK kèm dữ liệu sản phẩm
            if (product != null)
            {
                return Ok(product);
            }
            else
            {
                // Nếu không tìm thấy sản phẩm, trả về 404 Not Found
                return NotFound("Product not found.");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Edit(string id, ProductVN editProduct)
        {
            var product = products.SingleOrDefault(p => p.idProduct == Guid.Parse(id));
            if (product != null)
            {
                product.name = editProduct.name;
                product.price = editProduct.price;
                return Ok(product);
            }
            else
            {
                return NotFound("Product not found");
            }
            
        }

    }
   
}
