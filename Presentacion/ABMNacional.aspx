<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ABMNacional.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <br />
        <br />
        <h3>ABM Nacional</h3>
        <span>Codigo: </span>
        <asp:TextBox ID="txtCodigo" runat="server"></asp:TextBox>
        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
        &nbsp;
        <br />
        <br />
        <span>Ciudad: </span>        
        <asp:TextBox ID="txtCiudad" runat="server"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <br />
        <span>Taxi: </span>
        <asp:RadioButton ID="RBsi" runat="server" GroupName="RBTAXI" Text="Si" />
        <asp:RadioButton ID="RBno" runat="server" GroupName="RBTAXI" Text="No" />
        <br />
        <br />
        <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" />
        <asp:Button ID="btnModificar" runat="server" Text="Modificar" OnClick="btnModificar_Click" />
        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" />
        <asp:Button ID="btnDeshacer" runat="server" Text="Deshacer" OnClick="btnDeshacer_Click" />
        <br />
        <br />
        <asp:Label ID="lblerror" runat="server" ForeColor="Red"></asp:Label>
    </div>    
</asp:Content>

