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
        txtNomUsu.Text = "";
        txtPass.Text = "";
        txtNomCom.Text = "";
        btnAgregar.Enabled = true;
    }

    protected void btnLimpio_Click(object sender, EventArgs e)
    {
        LimpioForm();
    }

    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        string nomUsu, pass, nomCom;
        Empleado unEmp;

        try
        {
            nomUsu = txtNomUsu.Text;
            pass = txtPass.Text;
            nomCom = txtNomCom.Text;


            unEmp = new Empleado(pass, nomUsu, nomCom);
            ILogicaEmpleado LEmpleado = FabricaLogica.GetLogicaEmpleado();
            LEmpleado.Alta(unEmp);

            LimpioForm();

            lblerror.Text = "Alta con éxito";
        }
        catch (Exception ex)
        {
            lblerror.Text = ex.Message;
        }
    }
}