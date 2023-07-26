<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AltaCompañia.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h3>Alta compañía</h3>
&nbsp;&nbsp; Nombre:&nbsp;
        <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>    
    &nbsp;&nbsp;&nbsp;    
    <p>
        Direccion:&nbsp;
        <asp:TextBox ID="txtDireccion" runat="server"></asp:TextBox>
    &nbsp;&nbsp;
    </p>
    <p>
&nbsp; Telefono:&nbsp;
        <asp:TextBox ID="txtTelefono" runat="server"></asp:TextBox>
    &nbsp;&nbsp;&nbsp;
    </p>
    <p>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnAgregar" runat="server" OnClick="btnAgregar_Click" Text="Agregar" />
        <asp:Button ID="btnLimpio" runat="server" OnClick="btnLimpio_Click" Text="Deshacer" />
    </p>
    <p>
        <asp:Label ID="lblerror" runat="server"></asp:Label>
    </p>
</asp:Content>

