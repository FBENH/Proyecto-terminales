using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades_Compartidas;
using Logica;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Session["Usuario"] = null;//deslogueo 
            LblError.Text = "";
            ILogicaViaje LViaje = FabricaLogica.GetLogicaViaje();
            List<Viaje> _lista = LViaje.ListadoViajes();
            GVViajesFu.DataSource = (from unV in _lista
                                     orderby unV.FechaHoraP
                                     select new
                                     {
                                         Número = unV.Codigo,
                                         FechaPartida = unV.FechaHoraP,
                                         Anden = unV.Anden,
                                         Destino = unV.Coleccion.Last().Ter.Ciudad,
                                     }).ToList<object>(); //hola
            GVViajesFu.DataBind();
        }
        catch (Exception ex)
        {
            LblError.Text = ex.Message;
        }
    }
    protected void BtnLogin_Click(object sender, EventArgs e)
    {
        try
        {
            Empleado unE = FabricaLogica.GetLogicaEmpleado().Logueo(txtnomusu.Text.Trim(), txtpass.Text.Trim());
            if (unE == null)
            {
                LblError.Text = "Usuario o contraseña incorrectas";
            }
            else
            {
                Session["Usuario"] = unE;
                Response.Redirect("~/Bienvenida.aspx");
            }
        }
        catch (Exception ex)
        {
            LblError.Text = ex.Message;
        }
    }
}