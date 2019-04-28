<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ArtistEdit.aspx.cs" Inherits="App.UI.Web.WebForm.Mantenimientos.ArtistEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<div>
  <div class="form-group">
    <label >Nombre</label>
      <asp:TextBox ID="txtName" runat="server"
          class="form-control" 
          ></asp:TextBox>
  </div>

  <asp:Button ID="btnGuardar" 
      class="btn btn-primary"
      runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
</div>

</asp:Content>
