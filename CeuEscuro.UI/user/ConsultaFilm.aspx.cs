using CeuEscuro.BLL;
using CeuEscuro.DTO;
using CeuEscuro.UI.utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CeuEscuro.UI.user
{
    public partial class ConsultaFilm : System.Web.UI.Page
    {
        FilmBLL filmBLL = new FilmBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            PopularGV2();
        }

        //popular gv2
        public void PopularGV2()
        {
            gv2.DataSource = filmBLL.GetFilms_Film();
            gv2.DataBind();
            gv2.SelectedRowStyle.Reset();
        }

        //Filter By Genre
        public void FilterGv2()
        {
            string filter = txtFiltro.Text.Trim();
            gv2.DataSource = filmBLL.FilterFilm(filter);
            gv2.DataBind();
            gv2.SelectedRowStyle.Reset();
        }

        //btnFilter
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

        //btnClear
        protected void btnClearFilter_Click(object sender, EventArgs e)
        {
            PopularGV2();
            txtFiltro.Text = string.Empty;
            txtFiltro.Focus();
        }
    }
}