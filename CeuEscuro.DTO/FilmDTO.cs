using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeuEscuro.DTO
{
    public class FilmDTO
    {
        public int IdFilm { get; set; }
        public string TituloFilm { get; set; }
        public string ProdutoraFilm { get; set; }
        public string UrlImgFilm { get; set; }
        public string Classificacao_Id { get; set; }
        public string Genero_Id { get; set; }
    }
}
