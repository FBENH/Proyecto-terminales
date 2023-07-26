<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ListadoDeViajes.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <h2>Listado de viajes</h2>
        <div>
            <h3>Filtros:</h3>
            <div>
                <span>Compañía: </span>
                <asp:DropDownList ID="ddlCompania" runat="server"></asp:DropDownList>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </div>
            <div>
                <span>Destino: </span>
                <asp:DropDownList ID="ddlDestinoFinal" runat="server"></asp:DropDownList>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </div>           
            <div>
                <span>Fecha: </span>
                <asp:TextBox ID="txtFecha" runat="server" TextMode="Date"></asp:TextBox>
            </div>
            <asp:Button ID="btnFiltrar" runat="server" Text="Filtrar" OnClick="btnFiltrar_Click" />
            <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar Filtros" OnClick="btnLimpiar_Click" />
        </div>
        <div style="margin:auto">
            <h3>Viajes</h3>
            <asp:GridView ID="grvViajes" runat="server" HorizontalAlign="Center" AllowPaging="True" OnPageIndexChanging="grvViajes_PageIndexChanging"></asp:GridView>
        </div>
        <asp:Label ID="lblerror" runat="server" Text=""></asp:Label>
    </div>
</asp:Content>

