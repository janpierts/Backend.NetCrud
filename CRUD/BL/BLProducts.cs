using CRUD.DAO.ProductsDAO;
using CRUD.IDAO.IProductsDAO;
using CRUD.BE.BEProducts;

namespace CRUD.BL.BLProducts
{
    public class BLProducts
    {
        private readonly IProductsDAO _productoDAO;

        public BLProducts(IProductsDAO productoDAO)
        {
            _productoDAO = productoDAO;
        }

        // Método para obtener todos los productos
        public List<BEProducts> ObtenerTodos()
        {
            return _productoDAO.ObtenerTodos();
        }

        // Método para obtener un producto por ID
        public BEProducts ObtenerPorId(int id)
        {
            return _productoDAO.ObtenerPorId(id);
        }

        // Método para crear un nuevo producto
        public void Crear(BEProducts product)
        {
            _productoDAO.Crear(product);
        }

        // Método para actualizar un producto
        public void Actualizar(BEProducts product)
        {
            _productoDAO.Actualizar(product);
        }

        // Método para eliminar un producto
        public void Eliminar(int id)
        {
            _productoDAO.Eliminar(id);
        }
    }
}