using CRUD.BE.BEProducts;

namespace CRUD.IDAO.IProductsDAO
{
    public interface IProductsDAO
    {
        List<BEProducts> ObtenerTodos();
        BEProducts ObtenerPorId(int id);
        void Crear(BEProducts product);
        void Actualizar(BEProducts product);
        void Eliminar(int id);
    }
}