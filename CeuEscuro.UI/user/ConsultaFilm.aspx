<%@ Page Title="" Language="C#" MasterPageFile="~/user/DefaultUser.Master" AutoEventWireup="true" CodeBehind="ConsultaFilm.aspx.cs" Inherits="CeuEscuro.UI.user.ConsultaFilm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <ul class="campos">
        <li>
            <%--filter--%>
            <asp:TextBox ID="txtFiltro" runat="server" placeholder="Filter by genre:" MaxLength="150"></asp:TextBox>
            <asp:Button ID="btnFilter" runat="server" Text="Filter" OnClick="btnFilter_Click" />
            <asp:Button ID="btnClearFilter" runat="server" Text="Clear Filter" OnClick="btnClearFilter_Click" />
            <asp:Label ID="lblFilter" runat="server" Text=""></asp:Label>
        </li>
    </ul>



    <div class="gv1">
        <%--gridView--%>
        <asp:GridView ID="gv2" AutoGenerateColumns="false" runat="server">
            <Columns>
                <%--<asp:CommandField ShowSelectButton="true" ButtonType="Button" HeaderText="Options" />--%>
                <asp:BoundField DataField="IdFilm" HeaderText="Código" />
                <asp:BoundField DataField="TituloFilm" HeaderText="Título" />
                <asp:BoundField DataField="ProdutoraFilm" HeaderText="Produtora" />
                <asp:BoundField DataField="Classificacao_Id" HeaderText="Classificação" />
                <asp:BoundField DataField="Genero_Id" HeaderText="Gênero" />
                <asp:ImageField DataImageUrlField="UrlImgFilm" HeaderText="Imagem" ControlStyle-Width="100" />

            </Columns>
            <%--<SelectedRowStyle BackColor="Red" ForeColor="AliceBlue" Font-Bold="true" />--%>
        </asp:GridView>
    </div>


</asp:Content>
