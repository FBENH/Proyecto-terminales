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
        //Para hacer: Si no hay usuario logueado no puedo acceder
        if (!IsPostBack)
        {
            Session["TerminalNacional"] = null;
            LimpioForm();
        }
        lblerror.Text = "";
    }

    private void LimpioForm()
    {
        txtCodigo.Text = "";
        txtCiudad.Text = "";
        btnBuscar.Enabled = true;
        btnAgregar.Enabled = false;
        btnModificar.Enabled = false;
        btnEliminar.Enabled = false;
        txtCodigo.Enabled = true;
        txtCiudad.Enabled = false;
        RBno.Enabled = false;
        RBsi.Enabled = false;       
    }
    private void BotonesAlta()
    {
        btnBuscar.Enabled = false;
        btnAgregar.Enabled = true;
        txtCodigo.Enabled = false;
        RBno.Enabled = true;
        RBsi.Enabled = true;
        txtCiudad.Enabled = true;
    }
    private void BotonesModificarEliminar()
    {
        btnBuscar.Enabled = false;
        btnAgregar.Enabled = false;
        txtCodigo.Enabled = false;
        RBno.Enabled = true;
        RBsi.Enabled = true;
        txtCiudad.Enabled = true;
        btnModificar.Enabled = true;
        btnEliminar.Enabled = true;
    }
    protected void btnDeshacer_Click(object sender, EventArgs e)
    {
        LimpioForm();
        Session["TerminalNacional"] = null;
    }
    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        try
        {
            ILogicaTerminal LTerminal = FabricaLogica.GetLogicaTerminal();
            Terminal unaT = LTerminal.BuscarTA(txtCodigo.Text);
            if (unaT == null)
            {
                BotonesAlta();
                Session["TerminalNacional"] = null;
            }
            else
            {                
                if(unaT is Nacional)
                {
                    BotonesModificarEliminar();
                    txtCiudad.Text = unaT.Ciudad;
                    Nacional unaTN = (Nacional)unaT;
                    if (unaTN.Taxi == false)
                            RBno.Checked = true;
                        else
                            RBsi.Checked = true;

                    Session["TerminalNacional"] = unaT;
                }
                else
                {
                    lblerror.Text = "Hay una terminal internacional con ese código.";
                }                
            }
        }
        catch (Exception ex)
        {
            lblerror.Text = ex.Message;
        }
        
    }

    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        string _codigo;
        string _ciudad;
        bool taxi;
        Nacional unaTN;
        try
        {
            _codigo = txtCodigo.Text;
            _ciudad = txtCiudad.Text;
            if (RBsi.Checked)
                taxi = true;
            else
                taxi = false;
            unaTN = new Nacional(_codigo, _ciudad, taxi);            
            ILogicaTerminal LTerminal = FabricaLogica.GetLogicaTerminal();
            LTerminal.Alta(unaTN);
            LimpioForm();
            lblerror.Text = "Alta con éxito";
        }
        catch (Exception ex)
        {
            lblerror.Text = ex.Message;
        }
    }

    protected void btnModificar_Click(object sender, EventArgs e)
    {
        bool _taxi;
        try
        {
            Nacional unaTN = (Nacional)Session["TerminalNacional"];            
            if (RBsi.Checked)
                _taxi = true;
            else
                _taxi = false;
            unaTN.Ciudad = txtCiudad.Text;
            unaTN.Taxi = _taxi;
            ILogicaTerminal LTerminal = FabricaLogica.GetLogicaTerminal();
            LTerminal.Modificar(unaTN);
            LimpioForm();
            lblerror.Text = "Modificación con éxito.";           
        }
        catch (Exception ex)
        {
            lblerror.Text = ex.Message;
        }
    }

    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        try
        {
            Nacional unaTN = (Nacional)Session["TerminalNacional"];
            ILogicaTerminal LTerminal = FabricaLogica.GetLogicaTerminal();
            LTerminal.Baja(unaTN);
            LimpioForm();
            lblerror.Text = "Baja con éxito";
        }
        catch (Exception ex)
        {
            lblerror.Text = ex.Message;
        }
    }
}