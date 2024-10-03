using CeuEscuro.DAL;
using CeuEscuro.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeuEscuro.BLL
{
    public class UsuarioBLL
    {
        //objeto para acessar os recursos da camada DAL
        UsuarioDAL objBLL = new UsuarioDAL();


        public UsuarioDTO AutenticarUsuario(string objNome, string objSenha)
        {
            UsuarioDTO user = objBLL.Autenticar(objNome, objSenha);

            return user;

        }

        //CRUD
        //Create
        public void CreateUser(UsuarioDTO usuario)
        {
            objBLL.Create(usuario);
        }

        //Read
        public List<UsuarioDTO> GetUsersAll()
        {
            return objBLL.GetUsers();
        }

        //Update
        public void UpdateUser(UsuarioDTO usuario)
        {
            objBLL.Update(usuario);
        }

        //Delete
        public void DeleteUser(int usuarioId)
        {
            objBLL.Delete(usuarioId);
        }

        //Search by Id
        public UsuarioDTO SearchByIdUser(int usuarioId)
        {
            return objBLL.Search(usuarioId);
        }

        //Load DropDownList
        public List<TipoUsuarioDTO> LoadDDL_TpUser()
        {
            return objBLL.LoadDDL();
        }

        //Search by Name
        public UsuarioDTO SearchByNameUser(string nome)
        {
            return objBLL.Search(nome);
        }
    }
}
