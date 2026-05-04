using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace WebApplication1
{
    public partial class Ejercicio3 : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
        

        }

        protected void lbVerLibros_Click(object sender, EventArgs e)
        {
            Session["TemaSeleccionado"] = ddlTemas.SelectedValue; // Guardamos el tema seleccionado ej (1,2,3)
            Session["OrdenPrecio"] = ddlPrecio.SelectedValue; // Guardamos orden descendente o ascendente.
            Response.Redirect("~/Ejercicio3_web2.aspx");
            
        }
    }
}