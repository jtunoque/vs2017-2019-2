<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdministrarArtistas.aspx.cs" Inherits="App.UI.Web.WebForm.Mantenimientos.AdministrarArtistas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">   
    <div class="form-inline">
        <div class="form-group">
            <label for="staticEmail2">Buscar por nombre</label>
            <asp:TextBox ID="txtFiltroPorNombre" runat="server" CssClass="form-control mx-sm-2"></asp:TextBox>
        </div>       
        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click"
        CssClass="btn btn-primary" />
    </div>
    <br />
    <asp:Button ID="btnNuevo" runat="server" Text="Nuevo Artista"
        PostBackUrl="~/Mantenimientos/ArtistEdit.aspx"
        />
    <br />
    <asp:GridView ID="gvListado" runat="server"
        CssClass="table" GridLines="None" AutoGenerateColumns="false"
        >

        <Columns>
            <asp:BoundField DataField="ArtistId" HeaderText="Código"
                HeaderStyle-Width="150" />
            <asp:BoundField DataField="Name" HeaderText="Nombre" />
            <asp:HyperLinkField HeaderText="Acción"
                Text="Editar"
                DataNavigateUrlFormatString="ArtistEdit.aspx?id={0}"
                DataNavigateUrlFields="ArtistId"
                />

        </Columns>
        
    </asp:GridView>



</asp:Content>
