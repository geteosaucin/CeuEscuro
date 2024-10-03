using CeuEscuro.BLL;
using CeuEscuro.DTO;
using CeuEscuro.UI.utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CeuEscuro.UI.adm
{
    public partial class ManageFilm : System.Web.UI.Page
    {
        FilmDTO filmDTO = new FilmDTO();
        FilmBLL filmBLL = new FilmBLL();


        //load
        protected void Page_Load(object sender, EventArgs e)
        {
            txtId.Enabled = false;
            if (!IsPostBack)
            {
                PopularGV2();
                PopularddlClassif();
                PopularddlGenero();
            }

        }

        //popular gv2
        public void PopularGV2()
        {
            gv2.DataSource = filmBLL.GetFilms_Film();
            gv2.DataBind();
            gv2.SelectedRowStyle.Reset();
            img1.ImageUrl = string.Empty;
        }

        //popular ddlClassif
        public void PopularddlClassif()
        {
            ddlClassif.DataSource = filmBLL.LoadDDLClassif_Classif();
            ddlClassif.DataBind();
        }

        //popular ddlGenero
        public void PopularddlGenero()
        {
            ddlGenero.DataSource = filmBLL.LoadDDLGenero_Genero();
            ddlGenero.DataBind();
        }

        //validation
        public bool ValidaPage()
        {
            bool valid;
            if (string.IsNullOrEmpty(txtTitulo.Text))
            {
                lblTitulo.Text = "Digite um Título !!";
                txtTitulo.Focus();
                valid = false;
            }
            else if (string.IsNullOrEmpty(txtProdutora.Text))
            {
                lblProdutora.Text = "Digite uma Produtora !!";
                txtProdutora.Focus();
                valid = false;
            }
            else if (!Fup.HasFile && img1.ImageUrl == string.Empty)
            {
                lblFup.Text = "Selecione uma imagem !!";
                Fup.Focus();
                valid = false;
            }
            else
            {
                valid = true;
            }
            return valid;
        }

        //clear
        protected void btnClear_Click(object sender, EventArgs e)
        {
            PopularGV2();
            Clear.ClearControl(this);
            txtSearch.Focus();
        }

        //Search by id
        protected void gv2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int filmeId = int.Parse(gv2.SelectedRow.Cells[1].Text);
            filmDTO = filmBLL.SearchById(filmeId);
            //preenchendo os campos
            txtId.Text = filmDTO.IdFilm.ToString();
            txtTitulo.Text = filmDTO.TituloFilm.ToString();
            txtProdutora.Text = filmDTO.ProdutoraFilm.ToString();
            ddlClassif.SelectedValue = filmDTO.Classificacao_Id.ToString();
            ddlGenero.SelectedValue = filmDTO.Genero_Id.ToString();

            //carregando Img
            img1.ImageUrl = filmDTO.UrlImgFilm;
            lblImg.Text = img1.ImageUrl;

            txtTitulo.Focus();
        }

        //Search by name
        public void SearchByName(string titulo)
        {
            titulo = txtSearch.Text.Trim();

            filmDTO = filmBLL.SearchByName(titulo);
            //preenchendo os campos
            txtId.Text = filmDTO.IdFilm.ToString();
            txtTitulo.Text = filmDTO.TituloFilm.ToString();
            txtProdutora.Text = filmDTO.ProdutoraFilm.ToString();
            ddlClassif.SelectedValue = filmDTO.Classificacao_Id.ToString();
            ddlGenero.SelectedValue = filmDTO.Genero_Id.ToString();

            //carregando Img
            img1.ImageUrl = filmDTO.UrlImgFilm;
            lblImg.Text = img1.ImageUrl;

            txtTitulo.Focus();

        }

        //Search by Name
        protected void btnSearch_Click(object serder, EventArgs e)
        {

            string titulo = txtSearch.Text.Trim();
            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                lblSearch.Text = "Digite um título para a busca";
                txtSearch.Focus();
                PopularGV2();
                return;
            }
            else if (filmDTO.TituloFilm == null)
            {
                lblSearch.Text = "Título Não Encontrado!!!";
                txtSearch.Text = string.Empty;
                txtSearch.Focus();
                PopularGV2();
                return;
            }
            else
            {
                SearchByName(titulo);
                lblSearch.Text = string.Empty;
            }

            SearchByName(titulo);
            lblSearch.Text = string.Empty;

        }

        //Filter by Genre
        public void FilterGv2()
        {
            string filter = txtFiltro.Text.Trim();
            gv2.DataSource = filmBLL.FilterFilm(filter);
            gv2.DataBind();
            gv2.SelectedRowStyle.Reset();
        }

        //Filter
        protected void btnFilter_Click(object sender, EventArgs e)
        {
            string filter = txtFiltro.Text.Trim();
            var result = filmBLL.FilterFilm(filter);

            if (string.IsNullOrEmpty(txtFiltro.Text) || result.Count == 0)
            {
                Clear.ClearControl(this);
                lblFilter.Text = "Digite um Genero Existente !";
                txtFiltro.Text = string.Empty;
                txtFiltro.Focus();
                PopularGV2();
            }
            else
            {
                FilterGv2();
                Clear.ClearControl(this);
                txtFiltro.Focus();
            }
        }

        //ClearFilter
        protected void btnClearFilter_Click(object sender, EventArgs e)
        {
            PopularGV2();
            txtFiltro.Text = string.Empty;
            txtFiltro.Focus();
        }

        //Record
        protected void btnRecord_Click(object sender, EventArgs e)
        {
            if (ValidaPage())
            {



                //preenchendo dados fornecidos pelo usuario
                filmDTO.TituloFilm = txtTitulo.Text.Trim();
                filmDTO.ProdutoraFilm = txtProdutora.Text.Trim();
                filmDTO.Classificacao_Id = ddlClassif.SelectedValue;
                filmDTO.Genero_Id = ddlGenero.SelectedValue;

                //imagem
                if (Fup.HasFile)
                {
                    string str = Fup.FileName;
                    Fup.PostedFile.SaveAs(Server.MapPath($"/img/{str}"));
                    string pathImg = $"/img/{str}";
                    filmDTO.UrlImgFilm = pathImg;
                }
                else
                {
                    filmDTO.UrlImgFilm = img1.ImageUrl;
                }
                

                //checando campo id
                if (string.IsNullOrEmpty(txtId.Text))
                {
                    filmBLL.CreateFilm(filmDTO);
                    PopularGV2();
                    Clear.ClearControl(this);
                    txtSearch.Focus();
                    lblMessage.Text = $"O Titulo {filmDTO.TituloFilm.ToUpper()} foi cadastrado com sucesso !!";
                }
                else
                {
                    filmDTO.IdFilm = int.Parse(txtId.Text);
                    filmBLL.UpdateFilm(filmDTO);
                    PopularGV2();
                    Clear.ClearControl(this);
                    txtSearch.Focus();
                    lblMessage.Text = $"O Titulo {filmDTO.TituloFilm.ToUpper()} foi editado com sucesso !!";
                }
            }

        }

        //Delete
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            filmDTO.IdFilm = int.Parse(txtId.Text);

            //pegando o nome do filme
            filmDTO = filmBLL.SearchById(filmDTO.IdFilm);
            string titulo = filmDTO.TituloFilm;

            filmBLL.DeleteFilm(filmDTO.IdFilm);
            Clear.ClearControl(this);
            txtSearch.Focus();
            lblMessage.Text = $"O Titulo {titulo} foi eliminado com sucesso !!";
            PopularGV2();
        }


    }
}