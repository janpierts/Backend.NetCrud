using Microsoft.AspNetCore.Mvc;
using CRUD.BL.BLProducts;
using CRUD.BE.BEProducts;
namespace CRUD.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly BLProducts _productsBL;

        public ProductsController(BLProducts productsBL)
        {
            _productsBL = productsBL;
        }

        // Método para obtener todos los productos
        [HttpGet]
        public IActionResult ObtenerTodos()
        {
            List<BEProducts> products = _productsBL.ObtenerTodos();
            return Ok(products);
        }

        // Método para obtener un producto por ID
        [HttpGet("{id}")]
        public IActionResult ObtenerPorId(int id)
        {
            BEProducts product = _productsBL.ObtenerPorId(id);
            if (product != null)
            {
                return Ok(product);
            }
            else
            {
                return NotFound();
            }
        }

        // Método para crear un nuevo producto
        [HttpPost]
        public IActionResult Crear(BEProducts product)
        {
            _productsBL.Crear(product);
            return CreatedAtAction(nameof(ObtenerPorId), new { id = product.Id }, product);
        }

        // Método para actualizar un producto
        [HttpPut("{id}")]
        public IActionResult Actualizar(int id, BEProducts product)
        {
            _productsBL.Actualizar(product);
            return Ok(product);
        }

        // Método para eliminar un producto
        [HttpDelete("{id}")]
        public IActionResult Eliminar(int id)
        {
            _productsBL.Eliminar(id);
            return NoContent();
        }
    }
}