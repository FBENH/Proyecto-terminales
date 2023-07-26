<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AltaEmpleado.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">    
    <h3>Alta empleado</h3>
    <p>
        Nombre de usuario: 
        <asp:TextBox ID="txtNomUsu" runat="server"></asp:TextBox>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </p>    
    <p>
        Contraseña:
        <asp:TextBox ID="txtPass" runat="server"></asp:TextBox>
    &nbsp;
    </p>
    <p>
        Nombre completo:
        <asp:TextBox ID="txtNomCom" runat="server"></asp:TextBox>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </p>
    <asp:Button ID="btnAgregar" runat="server" OnClick="btnAgregar_Click" Text="Agregar" />
    <asp:Button ID="btnLimpio" runat="server" OnClick="btnLimpio_Click" Text="Deshacer" />
    <br />    
    <asp:Label ID="lblerror" runat="server"></asp:Label>    
</asp:Content>

