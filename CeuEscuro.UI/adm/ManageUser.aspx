<%@ Page Title="" Language="C#" MasterPageFile="~/adm/DefaultAdm.Master" AutoEventWireup="true" CodeBehind="ManageUser.aspx.cs" Inherits="CeuEscuro.UI.adm.ManageUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <%--formulario--%>
    <ul class="campos">
        <li>
            <asp:TextBox ID="txtIdUsuario" placeholder="Id:" runat="server"></asp:TextBox>
        </li>
        <li>
            <asp:TextBox ID="txtNomeUsuario" MaxLength="150" placeholder="Nome:" runat="server"></asp:TextBox>
            <asp:Label ID="lblNomeUsuario" runat="server" Text=""></asp:Label>
        </li>
        <li>
            <asp:TextBox ID="txtEmailUsuario" MaxLength="150" placeholder="Email:" runat="server"></asp:TextBox>
            <asp:Label ID="lblEmailUsuario" runat="server" Text=""></asp:Label>

        </li>
        <li>
            <asp:TextBox ID="txtSenhaUsuario" MaxLength="6" placeholder="Senha:" runat="server"></asp:TextBox>
            <asp:Label ID="lblSenhaUsuario" runat="server" Text=""></asp:Label>

        </li>
        <li>
            <asp:TextBox ID="txtDtNascUsuario" onkeypress="$(this).mask('00/00/0000')" placeholder="Data Nasc:" runat="server"></asp:TextBox>
            <asp:Label ID="lblDtNascUsuario" runat="server" Text=""></asp:Label>
        </li>
        <li>
            <asp:DropDownList
                ID="ddl1"
                Width="270px"
                Height="40px"
                AutoPostBack="false"
                DataValueField="IdTipoUsuario"
                DataTextField="DescricaoTipoUsuario"
                runat="server">
            </asp:DropDownList>
        </li>
        <li>
            <asp:Button ID="btnRecord" runat="server" Text="Record" OnClick="btnRecord_Click" />
            <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" />
            <asp:Button ID="btnDelete" OnClick="btnDelete_Click" OnClientClick="if(!confirm('Deseja realmente eliminar este registro?'))return false" runat="server" Text="Delete" />
        </li>
        <li>
            <asp:TextBox ID="txtSearch" placeholder="Search by name:" runat="server"></asp:TextBox>
            <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
            <asp:Label ID="lblSearch" runat="server" Text=""></asp:Label>

        </li>
    </ul>
    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>



    <div class="gv1">
        <%--gridView--%>
        <asp:GridView ID="gv1" OnSelectedIndexChanged="gv1_SelectedIndexChanged" AutoGenerateColumns="false" runat="server">
            <Columns>
                <asp:CommandField ShowSelectButton="true" ButtonType="Button" HeaderText="Options" />
                <asp:BoundField DataField="IdUsuario" HeaderText="Código" />
                <asp:BoundField DataField="NomeUsuario" HeaderText="Nome" />
                <asp:BoundField DataField="EmailUsuario" HeaderText="Email" />
                <asp:BoundField DataField="SenhaUsuario" HeaderText="Senha" />
                <asp:BoundField DataField="DtNascUsuario" HeaderText="Data" DataFormatString="{0:dd/MM/yyyy}" />
                <asp:BoundField DataField="TipoUsuario_Id" HeaderText="Permissão" />
            </Columns>

            <SelectedRowStyle BackColor="black" ForeColor="AliceBlue" Font-Bold="true" />

        </asp:GridView>
    </div>




</asp:Content>
