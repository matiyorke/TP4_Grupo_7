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

            if (!IsPostBack)
            {
                //establecer la conexión con la BD

                SqlConnection conexion = new SqlConnection(cadenaConexion);
                conexion.Open();

                //ejecutar la consulta SQL

                SqlCommand comando = new SqlCommand(consultaSQL, conexion);
                SqlDataReader lector = comando.ExecuteReader();
                DataTable tabla = new DataTable();// Creamos tabla, aca se van a guardar los datos que lea SqlDataReader y los almacene en lector
                Session["TablaProvincias"] = tabla; //Guardamos en "session" para utilizar las veces q sea necesario
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
            else
            {
                if (ddlProvincia1.SelectedValue != "0")
                {
                    CargarLocalidades(ddlLocalidad1, ddlProvincia1.SelectedValue);
                }

            }
              //Otra manera de filtrar provincia para que no se repitan en lugar de origen y destino
             

        }

        private void CargarLocalidades(DropDownList ddl, string idProvincia)
        {
            SqlConnection conexion = new SqlConnection(cadenaConexion);
            conexion.Open();

            SqlCommand comando = new SqlCommand(comandoLocalidades, conexion);
            comando.Parameters.AddWithValue("@id", idProvincia);
            SqlDataReader lector = comando.ExecuteReader();

            ddl.Items.Clear();
            //ddl.Items.Add(new ListItem("--Seleccionar--", "0"));
            ddl.DataSource = lector;
            ddl.DataTextField = "NombreLocalidad";
            ddl.DataValueField = "IdLocalidad";
            ddl.DataBind();

            conexion.Close();
        }



        private void FiltrarProvincia(DropDownList ddl, string idExcluir) // este es como la otra funcion solo que excluimos la provincia seleccionada en el otro dropdown
        {
            SqlConnection conexion = new SqlConnection(cadenaConexion);
            conexion.Open();

            SqlCommand comando = new SqlCommand("SELECT * FROM Provincias WHERE IdProvincia != @id", conexion); // modificamos la consulta para excluir la provincia seleccionada
            comando.Parameters.AddWithValue("@id", idExcluir); //el comando se puede simplificar si alguno quiere agarrar el aporte
            SqlDataReader lector = comando.ExecuteReader();

            ddl.Items.Clear();
            ddl.DataSource = lector;
            ddl.DataTextField = "NombreProvincia";
            ddl.DataValueField = "IdProvincia";
            ddl.DataBind();

            conexion.Close();
        }

        /*
        private void FiltrarProvincia(DropDownList ddl, string idExcluir)
        {
            SqlConnection conexion = new SqlConnection(cadenaConexion);
            conexion.Open();

            SqlDataAdapter adapter = new SqlDataAdapter(
                "SELECT IdProvincia, NombreProvincia FROM Provincias WHERE IdProvincia <> " + idExcluir,
                conexion
            );

            DataTable tabla = new DataTable();
            adapter.Fill(tabla);

            ddl.DataSource = tabla;
            ddl.DataTextField = "NombreProvincia";
            ddl.DataValueField = "IdProvincia";
            ddl.DataBind();

            conexion.Close();
        }
        */




        private void FiltrarProvincia_opcion2(DropDownList ddl, string idExcluir) //Con esta opcion evitamos llamar 2 veces a la base de datos
        {
            DataTable tabla = (DataTable)Session["TablaProvincias"];
            DataView vista = new DataView(tabla); //Es la vista de la DataTable, nos permite utilizar diferentes metodos como .sort() .filter, etc
            vista.RowFilter = "IdProvincia <>" + idExcluir;

            ddl.DataSource = vista;
            ddl.DataTextField = "NombreProvincia";
            ddl.DataValueField = "IdProvincia";
            ddl.DataBind();
        }

        protected void ddlProvincia1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarLocalidades(ddlLocalidad1, ddlProvincia1.SelectedValue);
            FiltrarProvincia(ddlProvincia2, ddlProvincia1.SelectedValue);
        }

        protected void ddlProvincia2_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarLocalidades(ddlLocalidad2, ddlProvincia2.SelectedValue);
            FiltrarProvincia(ddlProvincia1, ddlProvincia2.SelectedValue);
        }
    }
}