<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AltaViajes.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <style type="text/css">
        .auto-style3 {
            height: 23px;
        }
        .auto-style5 {
            height: 23px;
            width: 309px;
        }
        .auto-style6 {
            width: 309px;
        }
        .auto-style7 {
            width: 436px;
        }
        .auto-style8 {
            height: 23px;
            width: 436px;
        }
        .auto-style9 {
            margin-left: 52px;
        }
        .auto-style10 {
            margin-left: 50px;
        }
        .auto-style11 {
            margin-left: 27px;
        }
        .auto-style12 {
            margin-left: 26px;
        }
        .auto-style13 {
            margin-left: 23px;
        }
        .auto-style16 {
            width: 309px;
            height: 30px;
        }
        .auto-style17 {
            width: 436px;
            height: 30px;
        }
        .auto-style18 {
            height: 30px;
        }
        .auto-style20 {
            margin-left: 29px;
        }
        .auto-style21 {
            margin-left: 15px;
        }
        .auto-style22 {
            margin-left: 51px;
        }
        .auto-style23 {
            margin-left: 0px;
        }
        .auto-style24 {
            margin-left: 13px;
        }
        .auto-style25 {
            margin-left: 42px;
        }
        .auto-style26 {
            margin-left: 34px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">     
        <table style="width: 100%;">
            <tr>
                <td class="auto-style6">&nbsp;</td>
                <td class="auto-style7">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style6">&nbsp;</td>
                <td class="auto-style7">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style6">&nbsp;</td>
                <td class="auto-style7" style="font-size: xx-large; text-decoration: underline overline; font-family: 'Century Gothic'">AltaViaje</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style6">&nbsp;</td>
                <td class="auto-style7">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style5"></td>
                <td class="auto-style8"></td>
                <td class="auto-style3"></td>
            </tr>
            <tr>
                <td class="auto-style6">&nbsp;</td>
                <td class="auto-style7">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style16">Max.Pasajeros
                <asp:TextBox ID="TxtPasajero" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style17">Fecha Salida&nbsp;
                    <asp:TextBox ID="TxtFeSa" runat="server" CssClass="auto-style23" TextMode="Date" Width="108px"></asp:TextBox>
                    <asp:TextBox ID="TxtHoraSA" runat="server" CssClass="auto-style25" TextMode="Time" Width="80px"></asp:TextBox>
                </td>
                <td class="auto-style18"></td>
            </tr>
            <tr>
                <td class="auto-style6">Precio<asp:TextBox ID="TxtPrecio" runat="server" CssClass="auto-style9"></asp:TextBox>
                </td>
                <td class="auto-style17">Fecha Llegada&nbsp;
                    <asp:TextBox ID="TxtFeLle" runat="server" CssClass="auto-style23" TextMode="Date" Width="115px"></asp:TextBox>
                    <asp:TextBox ID="TxtHoraLle" runat="server" CssClass="auto-style26" TextMode="Time" Width="92px"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style16">Anden<asp:TextBox ID="TxtAnden" runat="server" CssClass="auto-style10"></asp:TextBox>
                </td>
                <td class="auto-style17"></td>
                <td class="auto-style18"></td>
            </tr>
            <tr>
                <td class="auto-style16">Empleado<asp:TextBox ID="TxtEmp" runat="server" CssClass="auto-style12"></asp:TextBox>
                </td>
                <td class="auto-style17">Compañia<asp:TextBox ID="Txtcomp" runat="server" CssClass="auto-style11" Width="117px" TextMode="DateTime"></asp:TextBox>
                    <asp:Button ID="BtnBuscarComp" runat="server" CssClass="auto-style24" OnClick="BtnBuscarComp_Click" Text="Buscar Compañia" Width="116px" />
                </td>
                <td class="auto-style18">Terminal<asp:TextBox ID="TxtTer" runat="server" CssClass="auto-style13" Width="127px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style6">
                <asp:Button ID="BtnAlta" runat="server" Text="Alta Viaje" CssClass="auto-style23" OnClick="BtnAlta_Click" Width="82px" />
                <asp:Button ID="BtnDeshacer" runat="server" CssClass="auto-style21" Text="Deshacer" OnClick="BtnDeshacer_Click" />
                </td>
                <td class="auto-style7">&nbsp;</td>
                <td>Orden<asp:TextBox ID="TxtOrden" runat="server" CssClass="auto-style20"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style6">&nbsp;</td>
                <td class="auto-style7">&nbsp;</td>
                <td>
                    <asp:Button ID="BtnAñaTer" runat="server" OnClick="BtnAñadArt_Click" style="height: 26px" Text="Añadir Terminal" Width="98px" />
                <asp:Button ID="BtnEliminarTer" runat="server" CssClass="auto-style22" Text="Eliminar Terminal" Width="110px" OnClick="BtnEliminarTer_Click" />
                </td>
            </tr>
            <tr>
                <td class="auto-style6">
                    &nbsp;</td>
                <td class="auto-style7">
                    &nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style6">&nbsp;</td>
                <td class="auto-style7">&nbsp;</td>
                <td>
                <asp:GridView ID="GvViajes" runat="server" AutoGenerateColumns="False" Height="229px" Width="452px" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical">
                    <AlternatingRowStyle BackColor="#CCCCCC" />
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" />
                        <asp:BoundField DataField="Orden" HeaderText="Orden" />
                        <asp:BoundField DataField="Ter.Codigo" HeaderText="Terminal" />
                        <asp:BoundField DataField="Ter.Ciudad" HeaderText="Ciudad" />
                    </Columns>
                    <FooterStyle BackColor="#CCCCCC" />
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#808080" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#383838" />
                </asp:GridView>
                </td>
            </tr>
            <tr>
                <td class="auto-style6">&nbsp;</td>
                <td class="auto-style7">
                <asp:Label ID="Lblerror" runat="server" ForeColor="Red"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style6">&nbsp;</td>
                <td class="auto-style7">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style6">&nbsp;</td>
                <td class="auto-style7">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style6">&nbsp;</td>
                <td class="auto-style7">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style6">&nbsp;</td>
                <td class="auto-style7">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style6">&nbsp;</td>
                <td class="auto-style7">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style6">&nbsp;</td>
                <td class="auto-style7">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style6">&nbsp;</td>
                <td class="auto-style7">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>    
</asp:Content>

