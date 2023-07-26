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
            LimpioForm();

        lblerror.Text = "";
    }

    private void LimpioForm()
    {
        txtNombre.Text = "";
        txtDireccion.Text = "";
        txtTelefono.Text = "";        
    }

    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        string nombre, direccion;
        int telefono;
        Compañia unaComp;

        try
        {
            nombre = txtNombre.Text;
            direccion = txtDireccion.Text;
            telefono = Convert.ToInt32(txtTelefono.Text);


            unaComp = new Compañia(nombre, direccion, telefono);
            ILogicaCompañia LCompania = FabricaLogica.GetLogicaCompañia();
            LCompania.Alta(unaComp);

            LimpioForm();

            lblerror.Text = "Alta con éxito";
        }
        catch (Exception ex)
        {
            lblerror.Text = ex.Message;
        }
    }

    protected void btnLimpio_Click(object sender, EventArgs e)
    {
        LimpioForm();
    }
}