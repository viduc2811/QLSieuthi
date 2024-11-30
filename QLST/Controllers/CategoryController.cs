using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLST.data;

namespace QLST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly MyDBContext _context;

        public CategoryController(MyDBContext context) {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var listCat = _context.Categories.ToList();
            return Ok(listCat);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var cat = _context.Categories.SingleOrDefault(lo => lo.idCat == id);
            if (cat != null) {
                return Ok(cat); }
            else
            {
                return NotFound();
            }
        }
        public class CategoryDto
        {
            public string nameCat { get; set; }
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CategoryDto category)
        {
            var cat = new CategoryDto
            {
                nameCat = category.nameCat,
            };
            _context.Add(cat);
            await _context.SaveChangesAsync();
            return Ok(cat);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Category category)
        {
            var cat = _context.Categories.SingleOrDefault(lo => lo.idCat == id);
            if (cat != null)
            {
               cat.nameCat = category.nameCat;
                _context.SaveChanges();
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
