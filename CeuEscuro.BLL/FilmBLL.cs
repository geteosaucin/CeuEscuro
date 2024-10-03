using CeuEscuro.DAL;
using CeuEscuro.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeuEscuro.BLL
{
    public class FilmBLL
    {
        FilmDAL filmBLL = new FilmDAL();

        //CRUD
        //Create
        public void CreateFilm(FilmDTO filme)
        {
            filmBLL.Create(filme);
        }

        //Read
        public List<FilmDTO> GetFilms_Film()
        {
            return filmBLL.GetFilms();
        }

        //Update
        public void UpdateFilm(FilmDTO filme)
        {
            filmBLL.Update(filme);
        }


        //Delete
        public void DeleteFilm(int idFilme)
        {
            filmBLL.Delete(idFilme);
        }

        //Search by Id
        public FilmDTO SearchById(int filmeId)
        {
            return filmBLL.Search(filmeId);
        }

        //Search by name
        public FilmDTO SearchByName(string filmeTitulo)
        {
            return filmBLL.Search(filmeTitulo);
        }

        //Load DDLClassificacao
        public List<ClassificacaoDTO> LoadDDLClassif_Classif()
        {
            return filmBLL.LoadDDLClassif();
        }

        //Load DDLGenero
        public List<GeneroDTO> LoadDDLGenero_Genero()
        {
            return filmBLL.LoadDDLGenero();
        }

        //Filter by genre
        public List<FilmDTO> FilterFilm(string genero)
        {
            return filmBLL.Filter(genero);
        }

    }
}
