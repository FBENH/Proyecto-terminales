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
            LimpioForm();
            Session["TerminalInternacional"] = null;
        }
            

        lblerror.Text = "";
    }

    private void LimpioForm()
    {
        txtCodigo.Text = "";
        txtCiudad.Text = "";
        txtPais.Text = "";
        btnBuscar.Enabled = true;
        btnAgregar.Enabled = false;
        btnModificar.Enabled = false;
        btnEliminar.Enabled = false;
        txtCodigo.Enabled = true;
        txtCiudad.Enabled = false;
        txtPais.Enabled = false;
    }
    private void BotonesAlta()
    {
        btnBuscar.Enabled = false;
        btnAgregar.Enabled = true;
        txtCodigo.Enabled = false;
        txtPais.Enabled = true;
        txtCiudad.Enabled = true;
    }
    private void BotonesModificarEliminar()
    {
        btnBuscar.Enabled = false;
        btnAgregar.Enabled = false;
        txtCodigo.Enabled = false;
        txtPais.Enabled = true;
        txtCiudad.Enabled = true;
        btnModificar.Enabled = true;
        btnEliminar.Enabled = true;
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
                Session["TerminalInternacional"] = null;
            }
            else
            {
                if (unaT is Internacional)
                {
                    BotonesModificarEliminar();
                    txtCiudad.Text = unaT.Ciudad;
                    Internacional unaTI = (Internacional)unaT;
                    txtPais.Text = unaTI.Pais;
                    Session["TerminalInternacional"] = unaT;
                }
                else
                {
                    lblerror.Text = "Hay una terminal nacional con ese código.";
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
        string _codigo, _ciudad, _pais;
        Internacional unaTI;
        try
        {
            _codigo = txtCodigo.Text;
            _ciudad = txtCiudad.Text;
            _pais = txtPais.Text;
            unaTI = new Internacional(_codigo, _ciudad, _pais);
            ILogicaTerminal LTerminal = FabricaLogica.GetLogicaTerminal();
            LTerminal.Alta(unaTI);
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
        try
        {
            Internacional unaTI = (Internacional)Session["TerminalInternacional"];            
            unaTI.Ciudad = txtCiudad.Text;
            unaTI.Pais = txtPais.Text;
            ILogicaTerminal LTerminal = FabricaLogica.GetLogicaTerminal();
            LTerminal.Modificar(unaTI);
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
            Internacional unaTI = (Internacional)Session["TerminalInternacional"];
            ILogicaTerminal LTerminal = FabricaLogica.GetLogicaTerminal();
            LTerminal.Baja(unaTI);
            LimpioForm();
            lblerror.Text = "Baja con éxito";
        }
        catch (Exception ex)
        {
            lblerror.Text = ex.Message;
        }
    }

    protected void btnDeshacer_Click(object sender, EventArgs e)
    {
        LimpioForm();
        Session["TerminalInternacional"] = null;
    }
}