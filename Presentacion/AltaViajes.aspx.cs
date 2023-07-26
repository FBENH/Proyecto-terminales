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
        if (!IsPostBack)
            this.LimpioPantalla();
    }
    private void LimpioPantalla()
    {
        BtnBuscarComp.Enabled = true;
        Txtcomp.Enabled = true;
        Txtcomp.Text = "";

        BtnAñaTer.Enabled = false;
        BtnEliminarTer.Enabled = false;
        BtnAlta.Enabled = false;
        TxtOrden.Enabled = false;
        TxtTer.Enabled = false;
        TxtPasajero.Enabled = false;
        TxtPrecio.Enabled = false;
        TxtAnden.Enabled = false;
        TxtEmp.Enabled = false;

        TxtTer.Text = "";
        TxtAnden.Text = "";
        TxtOrden.Text = "";
        TxtPasajero.Text = "";
        TxtPrecio.Text = "";
        TxtEmp.Text = "";
        Lblerror.Text = "";
        GvViajes.DataSource = null;
        GvViajes.DataBind();
        Session["listapara"] = new List<PasaPor>(); //creo coleccion vacia

    }
    private void ActivoBotonAñaArt()
    {
        BtnAñaTer.Enabled = true;
        TxtTer.Enabled = true;
        TxtOrden.Enabled = true;

        BtnBuscarComp.Enabled = false;
        Txtcomp.Enabled = false;
        BtnEliminarTer.Enabled = false;
        BtnAlta.Enabled = false;
        TxtPasajero.Enabled = false;
        TxtPrecio.Enabled = false;
        TxtAnden.Enabled = false;
    }
    private void ActivoBotonAV()
    {
        BtnAñaTer.Enabled = true;
        TxtTer.Enabled = true;
        TxtOrden.Enabled = true;

        BtnBuscarComp.Enabled = false;
        Txtcomp.Enabled = false;
        BtnEliminarTer.Enabled = true;
        BtnAlta.Enabled = true;
        TxtPasajero.Enabled = true;
        TxtPrecio.Enabled = true;
        TxtAnden.Enabled = true;
    }
    protected void BtnBuscarComp_Click(object sender, EventArgs e)
    {
        try
        {
            string _nom = Txtcomp.Text;
            Compañia _objeto = FabricaLogica.GetLogicaCompañia().Buscar(_nom);
            if (_objeto == null)
            {
                Session["Compañia"] = null;
                Lblerror.Text = "No existe esa compañia en el sistema";
            }
            else
            {
                Session["Compañia"] = _objeto;
                Txtcomp.Text = _objeto.Nombre;
                ActivoBotonAñaArt();
                Lblerror.Text = "Compañia encontrada";
            }
        }
        catch (Exception ex)
        {
            Lblerror.Text = ex.Message;
        }
    }
    protected void BtnAñadArt_Click(object sender, EventArgs e)
    {
        try
        {
            int _orden = Convert.ToInt32(TxtOrden.Text);
            string _codTer = TxtTer.Text.Trim();
            Terminal _objeto = FabricaLogica.GetLogicaTerminal().BuscarTA(_codTer);
            List<PasaPor> _coleccion = (List<PasaPor>)Session["listapara"];
            _coleccion.Add(new PasaPor(_orden, _objeto));

            GvViajes.DataSource = _coleccion;
            GvViajes.DataBind();
            Session["Terminales"] = _coleccion;

            ActivoBotonAV();
            Lblerror.Text = "Terminal añadida a la lista";
            TxtTer.Text = "";
            TxtOrden.Text = "";

        }
        catch (Exception ex)
        {
            Lblerror.Text = ex.Message;
        }
    }
    protected void BtnAlta_Click(object sender, EventArgs e)
    {//agregar 2 cajitas de texto por cada fecha, una fecha otra hora .

        try
        {
            
            DateTime _fechaSalida = Convert.ToDateTime(TxtFeSa.Text);
            DateTime _horaSalida = Convert.ToDateTime(TxtHoraSA.Text);
            int _horaP = _horaSalida.Hour;
            int _minutoP = _horaSalida.Minute;
            DateTime _fechaHoraP = new DateTime(_fechaSalida.Year,_fechaSalida.Month,_fechaSalida.Day,_horaP,_minutoP,0);

            DateTime _fechaLlegada = Convert.ToDateTime(TxtFeLle.Text);
            DateTime _horaLlegada = Convert.ToDateTime(TxtHoraLle.Text);
            int _horaD = _horaLlegada.Hour;
            int _minutoD = _horaLlegada.Minute;
            DateTime _fechaHoraD = new DateTime(_fechaLlegada.Year, _fechaLlegada.Month, _fechaLlegada.Day, _horaD, _minutoD,0);

            int _maxPasajeros = Convert.ToInt32(TxtPasajero.Text);
            int _precio = Convert.ToInt32(TxtPrecio.Text);
            int _anden = Convert.ToInt32(TxtAnden.Text);
            List<PasaPor> _coleccion = (List<PasaPor>)Session["Terminales"];
            Empleado _unEmp = /*(Empleado)Session["Usuario"];*/ FabricaLogica.GetLogicaEmpleado().Buscar("CarloMag");
            Compañia _unaComp = (Compañia)Session["Compañia"];

            Viaje V = new Viaje(0, _fechaHoraP, _fechaHoraD, _maxPasajeros, _precio, _anden, _coleccion, _unEmp, _unaComp);

            ILogicaViaje Viaje = FabricaLogica.GetLogicaViaje();
            Viaje.AltaViaje(V);

            LimpioPantalla();
            Lblerror.Text = "Alta con éxito";
        }

        catch (Exception ex)
        {
            Lblerror.Text = ex.Message;
        }
    }
    protected void BtnDeshacer_Click(object sender, EventArgs e)
    {
        this.LimpioPantalla();
    }
    protected void BtnEliminarTer_Click(object sender, EventArgs e)
    {

        try
        {
            List<PasaPor> _coleccion = (List<PasaPor>)Session["Terminales"];
            PasaPor _ter = _coleccion[GvViajes.SelectedIndex];
            if (GvViajes.SelectedRow != null)
            {
                if (_coleccion != null)
                {
                    _coleccion.RemoveAt(GvViajes.SelectedIndex); //prpobar luego
                    GvViajes.DataSource = _coleccion;
                    GvViajes.DataBind();
                    Lblerror.Text = "Terminal eliminada con éxito";
                }
                else
                {
                    Lblerror.Text = "No Elimina";
                }
            }
        }
        catch (Exception ex)
        {
            Lblerror.Text = ex.Message;
        }
    }
}