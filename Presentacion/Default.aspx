<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">

        .auto-style11 {
            width: 260px;
            height: 23px;
        }
        .auto-style6 {
            width: 574px;
            font-size: xx-large;
            height: 23px;
        }
        .auto-style12 {
            height: 23px;
        }
        .auto-style16 {
            width: 260px;
            height: 24px;
        }
        .auto-style17 {
            width: 574px;
            height: 24px;
        }
        .auto-style1 {
            width: 118px;
        }
        .auto-style1 {
            width: 574px;
        }
        .auto-style4 {
            width: 260px;
        }
        .auto-style13 {
            width: 260px;
            height: 45px;
        }
        .auto-style14 {
            width: 574px;
            height: 45px;
        }
        .auto-style15 {
            height: 45px;
        }
        .auto-style19 {
            margin-left: 116px;
        }
        .auto-style20 {
            height: 23px;
            width: 639px;
        }
        .auto-style21 {
            width: 639px;
        }
        .auto-style22 {
            width: 639px;
            height: 24px;
        }
        .auto-style23 {
            width: 639px;
            height: 45px;
        }
        .auto-style24 {
            margin-left: 28px;
        }
        .auto-style25 {
            width: 574px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table style="width:100%;">
            <tr>
                <td class="auto-style11"></td>
                <td class="auto-style6" style="font-size: x-small;"></td>
                <td class="auto-style20"></td>
                <td class="auto-style12">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style16"></td>
                <td class="auto-style17"></td>
                <td class="auto-style21" dir="rtl" style="background-color: #FFFFFF; font-size: large;">&nbsp;</td>
                <td class="auto-style1" dir="rtl" style="background-color: #FFFFFF; font-size: large;">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style17" style="font-size: xx-large; text-decoration: underline overline">Página Principal</td>
                <td class="auto-style22">&nbsp;</td>
                <td class="auto-style17" dir="auto">
                    <asp:Label ID="iniciosesion" runat="server" CssClass="auto-style15" Font-Bold="False" Font-Names="Arial" Font-Overline="False" Font-Size="Large" Text="Iniciar Sesión"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style25">&nbsp;</td>
                <td class="auto-style21">&nbsp;</td>
                <td>Usuario: <asp:TextBox ID="txtnomusu" runat="server" CssClass="auto-style24"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style13"></td>
                <td class="auto-style14">&nbsp;</td>
                <td class="auto-style23">&nbsp;</td>
                <td class="auto-style15">Contraseña:&nbsp;
                    <asp:TextBox ID="txtpass" runat="server" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style25">&nbsp;</td>
                <td class="auto-style21">
                    <asp:Label ID="LblError" runat="server" ForeColor="Red"></asp:Label>
                </td>
                <td>
                    <asp:Button ID="BtnLogin" runat="server" CssClass="auto-style19" OnClick="BtnLogin_Click" Text="Login" style="width: 47px" />
                </td>
            </tr>
            <tr>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style25">
                    <asp:GridView ID="GVViajesFu" runat="server" Height="208px" Width="463px" AutoGenerateColumns="False">
                        <Columns>
                            <asp:BoundField DataField="Número" HeaderText="N°" />
                            <asp:BoundField DataField="FechaPartida" HeaderText="Fecha de Partida" />
                            <asp:BoundField DataField="Anden" HeaderText="Anden" />
                            <asp:BoundField DataField="Destino" HeaderText="Destino" />
                        </Columns>
                    </asp:GridView>
                </td>
                <td class="auto-style21">&nbsp;&nbsp;</td>
                <td style="font-family: 'Arial Black'">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style25">
                    &nbsp;</td>
                <td class="auto-style21">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
