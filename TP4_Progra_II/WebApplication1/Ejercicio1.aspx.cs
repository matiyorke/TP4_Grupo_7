using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace WebApplication1
{
    public partial class Ejercicio1 : System.Web.UI.Page
    {
        private const string cadenaConexion = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=Viajes;Integrated Security=True";
        private string consultaSQL = "SELECT * FROM Provincias";

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if(!IsPostBack)
            {
                //establecer la conexión con la BD

                SqlConnection conexion = new SqlConnection(cadenaConexion);
                conexion.Open(); 
                
                //ejecutar la consulta SQL

                SqlCommand comando = new SqlCommand(consultaSQL , conexion);
                SqlDataReader lector = comando.ExecuteReader();

                //guardar datos en el control ddlProvincia1

                ddlProvincia1.DataSource = lector;
                ddlProvincia1.DataTextField = "NombreProvincia";
                ddlProvincia1.DataValueField = "IdProvincia";
                ddlProvincia1.DataBind(); 

                conexion.Close(); 
            }
        }
    }
}