using System.Data;
using System.Data.SqlClient;
using CRUD.BE.BEProducts;
using CRUD.IDAO.IProductsDAO;
namespace CRUD.DAO.ProductsDAO
{
    public class ProductsDAO : IProductsDAO
    {
        private readonly string _connectionString;

         public ProductsDAO(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        // Método para obtener todos los productos
        public List<BEProducts> ObtenerTodos()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("sp_ListAll_CRUD", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();
                List<BEProducts> products = new List<BEProducts>();
                while (reader.Read())
                {
                    BEProducts productsList = new BEProducts
                    {
                        Id = reader.GetInt32(0),
                        Nombre = reader.GetString(1),
                        Precio = reader.GetDecimal(2)
                    };
                    products.Add(productsList);
                }
                return products;
            }
        }

        // Método para obtener un producto por ID
        public BEProducts ObtenerPorId(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("sp_GetProductById", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", id);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    BEProducts products = new BEProducts
                    {
                        Id = reader.GetInt32(0),
                        Nombre = reader.GetString(1),
                        Precio = reader.GetDecimal(2)
                    };
                    return products;
                }
                else
                {
                    return null;
                }
            }
        }
        public void Crear(BEProducts product)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("sp_AddProduct", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@name", product.Nombre);
                command.Parameters.AddWithValue("@price", product.Precio);
                command.ExecuteNonQuery();
            }
        }
        public void Actualizar(BEProducts product)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("sp_UpdateProduct", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id", product.Id);
                command.Parameters.AddWithValue("@name", product.Nombre);
                command.Parameters.AddWithValue("@price", product.Precio);
                command.ExecuteNonQuery();
            }
        }

        // Método para eliminar un producto
        public void Eliminar(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("sp_DeleteProduct", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }
        }
    }
}