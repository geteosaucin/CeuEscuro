using CeuEscuro.DTO;//
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeuEscuro.DAL
{
    public class FilmDAL:Conexao
    {
        //CRUD
        //Create
        public void Create(FilmDTO filme)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("INSERT INTO Film (TituloFilm,ProdutoraFilm,UrlImgFilm,Classificacao_Id,Genero_Id) VALUES (@TituloFilm,@ProdutoraFilm,@UrlImgFilm,@Classificacao_Id,@Genero_Id);", conn);
                cmd.Parameters.AddWithValue("@TituloFilm", filme.TituloFilm);
                cmd.Parameters.AddWithValue("@ProdutoraFilm", filme.ProdutoraFilm);
                cmd.Parameters.AddWithValue("@UrlImgFilm", filme.UrlImgFilm);
                cmd.Parameters.AddWithValue("@Classificacao_Id", filme.Classificacao_Id);
                cmd.Parameters.AddWithValue("@Genero_Id", filme.Genero_Id);
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
        public List<FilmDTO> GetFilms()
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT IdFilm,TituloFilm,ProdutoraFilm,UrlImgFilm,DescricaoGenero,DescricaoClassificacao FROM Film INNER JOIN Genero ON Genero_Id = IdGenero INNER JOIN Classificacao ON Classificacao_Id = IdClassificacao;", conn);
                dr = cmd.ExecuteReader();
                List<FilmDTO> Lista = new List<FilmDTO>();//lista vazia
                while (dr.Read())
                {
                    FilmDTO filme = new FilmDTO();
                    filme.IdFilm = Convert.ToInt32(dr["IdFilm"]);
                    filme.TituloFilm = dr["TituloFilm"].ToString();
                    filme.ProdutoraFilm = dr["ProdutoraFilm"].ToString();
                    filme.UrlImgFilm = dr["UrlImgFilm"].ToString();
                    filme.Classificacao_Id = dr["DescricaoClassificacao"].ToString();
                    filme.Genero_Id = dr["DescricaoGenero"].ToString();
                    Lista.Add(filme);
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
        public void Update(FilmDTO filme)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("UPDATE Film SET TituloFilm=@TituloFilm,ProdutoraFilm=@ProdutoraFilm,UrlImgFilm=@UrlImgFilm, Classificacao_Id=@Classificacao_Id,Genero_Id=@Genero_Id WHERE IdFilm = @IdFilm;", conn);
                cmd.Parameters.AddWithValue("@TituloFilm", filme.TituloFilm);
                cmd.Parameters.AddWithValue("@ProdutoraFilm", filme.ProdutoraFilm);
                cmd.Parameters.AddWithValue("@UrlImgFilm", filme.UrlImgFilm);
                cmd.Parameters.AddWithValue("@Classificacao_Id", filme.Classificacao_Id);
                cmd.Parameters.AddWithValue("@Genero_Id", filme.Genero_Id);
                cmd.Parameters.AddWithValue("@IdFilm", filme.IdFilm);
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
        public void Delete(int idFilme)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("DELETE FROM Film WHERE IdFilm = @IdFilm;", conn);
                cmd.Parameters.AddWithValue("@IdFilm", idFilme);
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


        //Search by Id
        public FilmDTO Search(int filmeId)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT * FROM Film WHERE IdFilm = @IdFilm;", conn);
                cmd.Parameters.AddWithValue("@IdFilm", filmeId);
                dr = cmd.ExecuteReader();
                FilmDTO filme = new FilmDTO();//objeto vazio
                if (dr.Read())
                {
                    filme = new FilmDTO();
                    filme.IdFilm = Convert.ToInt32(dr["IdFilm"]);
                    filme.TituloFilm = dr["TituloFilm"].ToString();
                    filme.ProdutoraFilm = dr["ProdutoraFilm"].ToString();
                    filme.UrlImgFilm = dr["UrlImgFilm"].ToString();
                    filme.Classificacao_Id =dr["Classificacao_Id"].ToString();
                    filme.Genero_Id = dr["Genero_Id"].ToString();

                }
                return filme;
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
        public FilmDTO Search(string filmeTitulo)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT * FROM Film WHERE TituloFilm = @TituloFilm;", conn);
                cmd.Parameters.AddWithValue("@TituloFilm", filmeTitulo);
                dr = cmd.ExecuteReader();
                FilmDTO filme = new FilmDTO();//objeto vazio
                if (dr.Read())
                {
                    filme = new FilmDTO();
                    filme.IdFilm = Convert.ToInt32(dr["IdFilm"]);
                    filme.TituloFilm = dr["TituloFilm"].ToString();
                    filme.ProdutoraFilm = dr["ProdutoraFilm"].ToString();
                    filme.UrlImgFilm = dr["UrlImgFilm"].ToString();
                    filme.Classificacao_Id = dr["Classificacao_Id"].ToString();
                    filme.Genero_Id = dr["Genero_Id"].ToString();

                }
                return filme;
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


        //Load DDLClassificacao
        public List<ClassificacaoDTO> LoadDDLClassif()
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT * FROM Classificacao;", conn);
                dr = cmd.ExecuteReader();
                List<ClassificacaoDTO> Lista = new List<ClassificacaoDTO>();//lista vazia
                while (dr.Read())
                {
                    ClassificacaoDTO classificacao = new ClassificacaoDTO();
                    classificacao.IdClassificacao = Convert.ToInt32(dr["IdClassificacao"]);
                    classificacao.DescricaoClassificacao = dr["DescricaoClassificacao"].ToString();
                    Lista.Add(classificacao);
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


        //Load DDLGenero
        public List<GeneroDTO> LoadDDLGenero()
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT * FROM Genero;", conn);
                dr = cmd.ExecuteReader();
                List<GeneroDTO> Lista = new List<GeneroDTO>();//lista vazia
                while (dr.Read())
                {
                    GeneroDTO genero = new GeneroDTO();
                    genero.IdGenero = Convert.ToInt32(dr["IdGenero"]);
                    genero.DescricaoGenero = dr["DescricaoGenero"].ToString();
                    Lista.Add(genero);
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


        //Filter by genre
        public List<FilmDTO> Filter(string genero)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT IdFilm,TituloFilm,ProdutoraFilm,UrlImgFilm,DescricaoGenero,DescricaoClassificacao FROM Film INNER JOIN Genero ON Genero_Id = IdGenero INNER JOIN Classificacao ON Classificacao_Id = IdClassificacao WHERE DescricaoGenero = @DescricaoGenero;", conn);
                cmd.Parameters.AddWithValue("@DescricaoGenero", genero);
                dr = cmd.ExecuteReader();
                List<FilmDTO> Lista = new List<FilmDTO>();//lista vazia
                while (dr.Read())
                {
                    FilmDTO filme = new FilmDTO();
                    filme.IdFilm = Convert.ToInt32(dr["IdFilm"]);
                    filme.TituloFilm = dr["TituloFilm"].ToString();
                    filme.ProdutoraFilm = dr["ProdutoraFilm"].ToString();
                    filme.UrlImgFilm = dr["UrlImgFilm"].ToString();
                    filme.Genero_Id = dr["DescricaoGenero"].ToString();
                    filme.Classificacao_Id = dr["DescricaoClassificacao"].ToString();
                    Lista.Add(filme);
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
