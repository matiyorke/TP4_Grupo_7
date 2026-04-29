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
    public partial class Ejercicio1 : System.Web.UI.Page
    {
        private const string cadenaConexion = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=Viajes;Integrated Security=True";
        private string consultaSQL = "SELECT * FROM Provincias";
        private string comandoLocalidades = "SELECT * FROM Localidades WHERE IdProvincia = @id";

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
                DataTable tabla = new DataTable();// Creamos tabla, aca se van a guardar los datos que lea SqlDataReader y los almacene en lector
                tabla.Load(lector);//Lo que contenga lector lo guaradmos en memoria
                //guardar datos en el control ddlProvincia1

                ddlProvincia1.DataSource = tabla;
                ddlProvincia1.DataTextField = "NombreProvincia";
                ddlProvincia1.DataValueField = "IdProvincia";
                ddlProvincia1.DataBind(); 

                //guardar datos en el control ddlProvincia2
                ddlProvincia2.DataSource = tabla;
                ddlProvincia2.DataTextField = "NombreProvincia";
                ddlProvincia2.DataValueField = "IdProvincia";
                ddlProvincia2.DataBind();

                conexion.Close(); 
            }
        }

        private void CargarLocalidades(DropDownList ddl, string idProvincia)
        {
            SqlConnection conexion = new SqlConnection(cadenaConexion);
            conexion.Open();

            SqlCommand comando = new SqlCommand(comandoLocalidades, conexion);
            comando.Parameters.AddWithValue("@id", idProvincia);
            SqlDataReader lector = comando.ExecuteReader();

            ddl.Items.Clear();
            ddl.Items.Add(new ListItem("--Seleccionar--", "0"));
            ddl.DataSource = lector;
            ddl.DataTextField = "NombreLocalidad";
            ddl.DataValueField = "IdLocalidad";
            ddl.DataBind();

            conexion.Close();
        }

        protected void ddlProvincia1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarLocalidades(ddlLocalidad1, ddlProvincia1.SelectedValue);
        }
    }
}