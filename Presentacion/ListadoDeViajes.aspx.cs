using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades_Compartidas;
using Logica;

public partial class Default2 : System.Web.UI.Page
{
     
    protected void Page_Load(object sender, EventArgs e)
    {
        //Para hacer, checkeo si hay usuario logueado
        if (!IsPostBack)
        {
            try
            {
                List<Viaje> ListadoVaM = FabricaLogica.GetLogicaViaje().ListadoViajes(); //Cambiar por ListadoViajesAM , Esto es para que se vean registros y probar.
                Session["ListadoVaM"] = ListadoVaM;
                List<object> Listado = (from unV in ListadoVaM
                                       orderby unV.FechaHoraP
                                       select new
                                       {
                                           Compañia = unV.UnaComp.Nombre,
                                           Destino = unV.Coleccion.Last().Ter.Ciudad,
                                           FechaPartida = unV.FechaHoraP,
                                           FechaLlegada = unV.FechaHoraD,
                                           Anden = unV.Anden,
                                           Precio = "$"+Math.Floor(unV.Precio).ToString()
                                       }).ToList<object>();

                 Session["MovGrilla"] = Listado;      //para paginación de grilla           
                 grvViajes.DataSource = Listado;
                 grvViajes.DataBind();                
                
                List<string> Companias = (from unaC in ListadoVaM
                                          group unaC by unaC.UnaComp into grupo
                                          select grupo.Key.Nombre).Distinct().ToList();                
                ddlCompania.DataSource = Companias;               
                ddlCompania.DataBind();
                ddlCompania.Items.Add("Todas");
                ddlCompania.SelectedValue = "Todas";
                Session["CompSelec"] = ddlCompania.SelectedValue;


                List<string> Destinos = (from unV in ListadoVaM
                                         group unV by unV.Coleccion.Last() into grupo
                                         orderby grupo.Key.Ter.Ciudad
                                         select grupo.Key.Ter.Ciudad).Distinct().ToList();                
                ddlDestinoFinal.DataSource = Destinos;
                ddlDestinoFinal.DataBind();
                ddlDestinoFinal.Items.Add("Todos");
                ddlDestinoFinal.SelectedValue = "Todos";
                Session["DestSelec"] = ddlDestinoFinal.SelectedValue;
            }
            catch (Exception ex)
            {
                lblerror.Text = ex.Message;
            }
        }        
    }


    protected void CargarFiltros()
    {        
        List<Viaje> ListaFiltrada= (List<Viaje>)Session["ListadoVaM"];
        if (ddlCompania.SelectedValue != "Todas")
        {
            ListaFiltrada = (from unV in ListaFiltrada
                             where unV.UnaComp.Nombre == ddlCompania.SelectedValue
                             select unV).ToList<Viaje>();
        }
        if (ddlDestinoFinal.SelectedValue != "Todos")
        {
            ListaFiltrada = (from unV in ListaFiltrada
                             where unV.Coleccion.Last().Ter.Ciudad == ddlDestinoFinal.SelectedValue
                             select unV).ToList<Viaje>();
        }
        if (string.IsNullOrWhiteSpace(txtFecha.Text) == false)
        {
            ListaFiltrada = (from unV in ListaFiltrada
                             where unV.FechaHoraP.Year == Convert.ToDateTime(txtFecha.Text).Year &&
                                   unV.FechaHoraP.Month == Convert.ToDateTime(txtFecha.Text).Month &&
                                   unV.FechaHoraP.Day == Convert.ToDateTime(txtFecha.Text).Day
                             select unV).ToList<Viaje>();
        }
        List<object> ListaFinal = (from unV in ListaFiltrada
                                   orderby unV.FechaHoraP
                                   select
                                    new
                                    {
                                      Compañia = unV.UnaComp.Nombre,
                                      Destino = unV.Coleccion.Last().Ter.Ciudad,
                                      FechaPartida = unV.FechaHoraP,
                                      FechaLlegada = unV.FechaHoraD,
                                      Anden = unV.Anden,
                                      Precio = unV.Precio
                                    }).ToList<object>();
        grvViajes.DataSource = ListaFinal;
        grvViajes.DataBind();
        Session["MovGrilla"] = ListaFinal;    
    }

    protected void btnFiltrar_Click(object sender, EventArgs e)
    {
        CargarFiltros();
    }

    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        ddlCompania.SelectedValue = "Todas";
        ddlDestinoFinal.SelectedValue = "Todos";
        txtFecha.Text = "";
        CargarFiltros();
    }

    protected void grvViajes_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvViajes.PageIndex = e.NewPageIndex;
        grvViajes.DataSource = Session["MovGrilla"];
        grvViajes.DataBind();
    }
}