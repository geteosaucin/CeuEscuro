using CeuEscuro.DTO;
using System;
using System.Data.SqlClient;//
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeuEscuro.DAL
{
    public class UsuarioDAL : Conexao
    {
        //autenticar
        public UsuarioDTO Autenticar(string nome, string senha)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT * FROM Usuario WHERE NomeUsuario = @NomeUsuario AND SenhaUsuario = @SenhaUsuario;", conn);
                cmd.Parameters.AddWithValue("@NomeUsuario", nome);
                cmd.Parameters.AddWithValue("@SenhaUsuario", senha);
                dr = cmd.ExecuteReader();
                UsuarioDTO usuario = null;
                if (dr.Read())
                {
                    usuario = new UsuarioDTO();
                    usuario.NomeUsuario = dr["NomeUsuario"].ToString();
                    usuario.SenhaUsuario = dr["SenhaUsuario"].ToString();
                    usuario.TipoUsuario_Id = dr["TipoUsuario_Id"].ToString();
                }
                return usuario;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                Desconectar();
            }

        }

        //CRUD
        //Create
        public void Create(UsuarioDTO usuario)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("INSERT INTO Usuario (NomeUsuario,EmailUsuario,SenhaUsuario,DtNascUsuario,TipoUsuario_Id) VALUES (@NomeUsuario,@EmailUsuario,@SenhaUsuario,@DtNascUsuario,@TipoUsuario_Id);", conn);
                cmd.Parameters.AddWithValue("@NomeUsuario", usuario.NomeUsuario);
                cmd.Parameters.AddWithValue("@EmailUsuario", usuario.EmailUsuario);
                cmd.Parameters.AddWithValue("@SenhaUsuario", usuario.SenhaUsuario);
                cmd.Parameters.AddWithValue("@DtNascUsuario", usuario.DtNascUsuario);
                cmd.Parameters.AddWithValue("@TipoUsuario_Id", usuario.TipoUsuario_Id);
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                Desconectar();
            }

        }

        //Read
        public List<UsuarioDTO> GetUsers()
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT IdUsuario, NomeUsuario, EmailUsuario,SenhaUsuario,DtNascUsuario,DescricaoTipoUsuario FROM Usuario INNER JOIN TipoUsuario ON TipoUsuario_Id = IdTipoUsuario;", conn);
                dr = cmd.ExecuteReader();
                List<UsuarioDTO> Lista = new List<UsuarioDTO>();//lista vazia
                while (dr.Read())
                {
                    UsuarioDTO usuario = new UsuarioDTO();
                    usuario.IdUsuario = Convert.ToInt32(dr["IdUsuario"]);
                    usuario.NomeUsuario = dr["NomeUsuario"].ToString();
                    usuario.EmailUsuario = dr["EmailUsuario"].ToString();
                    usuario.SenhaUsuario = dr["SenhaUsuario"].ToString();
                    usuario.DtNascUsuario = Convert.ToDateTime(dr["DtNascUsuario"]);
                    usuario.TipoUsuario_Id = dr["DescricaoTipoUsuario"].ToString();
                    Lista.Add(usuario);
                }
                return Lista;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }

        //Update
        public void Update(UsuarioDTO usuario)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("UPDATE Usuario SET Nomeusuario = @NomeUsuario, EmailUsuario=@EmailUsuario,SenhaUsuario= @SenhaUsuario,DtNascUsuario = @DtNascUsuario,TipoUsuario_Id = @TipoUsuario_Id WHERE IdUsuario = @IdUsuario;", conn);
                cmd.Parameters.AddWithValue("@NomeUsuario", usuario.NomeUsuario);
                cmd.Parameters.AddWithValue("@EmailUsuario", usuario.EmailUsuario);
                cmd.Parameters.AddWithValue("@SenhaUsuario", usuario.SenhaUsuario);
                cmd.Parameters.AddWithValue("@DtNascUsuario", usuario.DtNascUsuario);
                cmd.Parameters.AddWithValue("@TipoUsuario_Id", usuario.TipoUsuario_Id);
                cmd.Parameters.AddWithValue("@IdUsuario", usuario.IdUsuario);
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                Desconectar();
            }

        }


        //Delete
        public void Delete(int idUsuario)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("DELETE FROM Usuario WHERE IdUsuario = @IdUsuario;", conn);
                cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                Desconectar();
            }

        }

        //Search by id
        public UsuarioDTO Search(int usuarioId)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT * FROM Usuario WHERE IdUsuario = @IdUsuario;", conn);
                cmd.Parameters.AddWithValue("@IdUsuario", usuarioId);
                dr = cmd.ExecuteReader();
                UsuarioDTO usuario = new UsuarioDTO();//objeto vazio
                if (dr.Read())
                {
                    usuario = new UsuarioDTO();
                    usuario.IdUsuario = Convert.ToInt32(dr["IdUsuario"]);
                    usuario.NomeUsuario = dr["NomeUsuario"].ToString();
                    usuario.EmailUsuario = dr["EmailUsuario"].ToString();
                    usuario.SenhaUsuario = dr["SenhaUsuario"].ToString();
                    usuario.DtNascUsuario = Convert.ToDateTime(dr["DtNascUsuario"]);
                    usuario.TipoUsuario_Id = dr["TipoUsuario_Id"].ToString();

                }
                return usuario;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                Desconectar();
            }


        }

        //Search by name
        public UsuarioDTO Search(string usuarioName)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT * FROM Usuario WHERE NomeUsuario = @NomeUsuario;", conn);
                cmd.Parameters.AddWithValue("@NomeUsuario", usuarioName);
                dr = cmd.ExecuteReader();
                UsuarioDTO usuario = new UsuarioDTO();//objeto vazio
                if (dr.Read())
                {
                    usuario = new UsuarioDTO();
                    usuario.IdUsuario = Convert.ToInt32(dr["IdUsuario"]);
                    usuario.NomeUsuario = dr["NomeUsuario"].ToString();
                    usuario.EmailUsuario = dr["EmailUsuario"].ToString();
                    usuario.SenhaUsuario = dr["SenhaUsuario"].ToString();
                    usuario.DtNascUsuario = Convert.ToDateTime(dr["DtNascUsuario"]);
                    usuario.TipoUsuario_Id = dr["TipoUsuario_Id"].ToString();

                }
                return usuario;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                Desconectar();
            }


        }


        //Load DropDownList
        public List<TipoUsuarioDTO> LoadDDL()
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT * FROM TipoUsuario;", conn);
                dr = cmd.ExecuteReader();
                List<TipoUsuarioDTO> Lista = new List<TipoUsuarioDTO>();//lista vazia
                while (dr.Read())
                {
                    TipoUsuarioDTO tipoUsuario = new TipoUsuarioDTO();
                    tipoUsuario.IdTipoUsuario = Convert.ToInt32(dr["IdTipoUsuario"]);
                    tipoUsuario.DescricaoTipoUsuario = dr["DescricaoTipoUsuario"].ToString();
                    Lista.Add(tipoUsuario);
                }
                return Lista;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                Desconectar();
            }

        }

    }
}
