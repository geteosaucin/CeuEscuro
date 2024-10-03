using System;
using System.Data.SqlClient;

namespace CeuEscuro.DAL
{
    public class Conexao
    {
        //campos de apoio
        protected SqlConnection conn;
        protected SqlCommand cmd;
        protected SqlDataReader dr;

        //metodos
        protected void Conectar()
        {
            try
            {
                conn = new SqlConnection(@"Data source = (localdb)\MSSQLLocalDB;Initial Catalog = CeuEscuroDB; Integrated Security= true;");
                conn.Open();
            }
            catch (Exception ex)
            {

                throw new Exception($"Problema ao conectar {ex.Message}");
            }
        }

        protected void Desconectar()
        {
            try
            {
                conn.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
