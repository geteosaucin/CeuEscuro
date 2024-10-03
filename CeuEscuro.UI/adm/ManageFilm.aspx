<%@ Page Title="" Language="C#" MasterPageFile="~/adm/DefaultAdm.Master" AutoEventWireup="true" CodeBehind="ManageFilm.aspx.cs" Inherits="CeuEscuro.UI.adm.ManageFilm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--formulario--%>
    <ul class="campos">
        <li>
            <asp:TextBox ID="txtId" runat="server" placeholder="Id:"></asp:TextBox>
        </li>
        <li>
            <asp:TextBox ID="txtTitulo" runat="server" placeholder="Titulo:" MaxLength="150"></asp:TextBox>
            <asp:Label ID="lblTitulo" runat="server" Text=""></asp:Label>
        </li>
        <li>
            <asp:TextBox ID="txtProdutora" runat="server" placeholder="Produtora:" MaxLength="150"></asp:TextBox>
            <asp:Label ID="lblProdutora" runat="server" Text=""></asp:Label>
        </li>
        <li>
            <span>Selecione a classificação:</span>
        </li>
        <li>
            <asp:DropDownList
                ID="ddlClassif"
                Width="270px"
                Height="40px"
                AutoPostBack="false"
                DataValueField="IdClassificacao"
                DataTextField="DescricaoClassificacao"
                runat="server">
            </asp:DropDownList>
        </li>
        <li>
            <span>Selecione o gênero:</span>
        </li>
        <li>
            <asp:DropDownList
                ID="ddlGenero"
                Width="270px"
                Height="40px"
                AutoPostBack="false"
                DataValueField="IdGenero"
                DataTextField="DescricaoGenero"
                runat="server">
            </asp:DropDownList>
        </li>
        <li>
            <asp:FileUpload ID="Fup" runat="server" />
            <asp:Label ID="lblFup" runat="server" Text=""></asp:Label>
        </li>
        <li>
            <asp:Image ID="img1" runat="server" Width="100" />
            <asp:Label ID="lblImg" runat="server" Text=""></asp:Label>
        </li>
        <li>
            <asp:Button ID="btnRecord" runat="server" Text="Record" OnClick="btnRecord_Click" />
            <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" />
            <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClientClick="if(!confirm('Deseja realmente eliminar esse registro ?'))return false" OnClick="btnDelete_Click" />
        </li>
        <li>
            <asp:TextBox ID="txtSearch" runat="server" placeholder="Search by name:" MaxLength="150"></asp:TextBox>
            <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
            <asp:Label ID="lblSearch" runat="server" Text=""></asp:Label>
        </li>
        <li>
            <%--filter--%>
            <asp:TextBox ID="txtFiltro" runat="server" placeholder="Filter by genre:" MaxLength="150"></asp:TextBox>
            <asp:Button ID="btnFilter" runat="server" Text="Filter" OnClick="btnFilter_Click" />
            <asp:Button ID="btnClearFilter" runat="server" Text="Clear Filter" OnClick="btnClearFilter_Click" />
            <asp:Label ID="lblFilter" runat="server" Text=""></asp:Label>
        </li>
    </ul>
    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>


    <div class="gv1">
        <%--gridView--%>
        <asp:GridView ID="gv2" AutoGenerateColumns="false" runat="server" OnSelectedIndexChanged="gv2_SelectedIndexChanged">
            <Columns>
                <asp:CommandField ShowSelectButton="true" ButtonType="Button" HeaderText="Options" />
                <asp:BoundField DataField="IdFilm" HeaderText="Código" />
                <asp:BoundField DataField="TituloFilm" HeaderText="Título" />
                <asp:BoundField DataField="ProdutoraFilm" HeaderText="Produtora" />
                <asp:BoundField DataField="Classificacao_Id" HeaderText="Classificação" />
                <asp:BoundField DataField="Genero_Id" HeaderText="Gênero" />
                <asp:ImageField DataImageUrlField="UrlImgFilm" HeaderText="Imagem" ControlStyle-Width="100" />

            </Columns>
            <SelectedRowStyle BackColor="Red" ForeColor="AliceBlue" Font-Bold="true" />

        </asp:GridView>
    </div>

</asp:Content>
