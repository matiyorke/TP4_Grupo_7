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
                SqlDataAdapter adapter = new SqlDataAdapter(consultaSQL, cadenaConexion);
                DataTable tabla = new DataTable();
                adapter.Fill(tabla);
                Session["TablaProvincias"] = tabla;

                ddlProvincia1.DataSource = tabla;
                ddlProvincia1.DataTextField = "NombreProvincia";
                ddlProvincia1.DataValueField = "IdProvincia";
                ddlProvincia1.DataBind();

                ddlProvincia2.DataSource = tabla;
                ddlProvincia2.DataTextField = "NombreProvincia";
                ddlProvincia2.DataValueField = "IdProvincia";
                ddlProvincia2.DataBind();

                FiltrarProvincia(ddlProvincia2, ddlProvincia1.SelectedValue);
                FiltrarProvincia(ddlProvincia1, ddlProvincia2.SelectedValue);
                CargarLocalidades(ddlLocalidad2, ddlProvincia2.SelectedValue);
                CargarLocalidades(ddlLocalidad1, ddlProvincia1.SelectedValue);
            }
            else
            {
                if (ddlProvincia1.SelectedValue != "0")
                {
                    CargarLocalidades(ddlLocalidad1, ddlProvincia1.SelectedValue);
                }

                if (ddlProvincia2.SelectedValue != "0")
                {
                    CargarLocalidades(ddlLocalidad2, ddlProvincia2.SelectedValue);
                }
            }
        }

        private void CargarLocalidades(DropDownList ddl, string idProvincia)
        {
            string valorAnterior = ddl.SelectedValue;

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

            if (ddl.Items.FindByValue(valorAnterior) != null)
            {
                ddl.SelectedValue = valorAnterior;
            }

            conexion.Close();
        }

        private void FiltrarProvincia(DropDownList ddl, string idExcluir)
        {
            string valorAnterior = ddl.SelectedValue;

            SqlConnection conexion = new SqlConnection(cadenaConexion);
            conexion.Open();

            SqlCommand comando = new SqlCommand("SELECT * FROM Provincias WHERE IdProvincia != @id", conexion);
            comando.Parameters.AddWithValue("@id", idExcluir);
            SqlDataReader lector = comando.ExecuteReader();

            ddl.Items.Clear();
            ddl.DataSource = lector;
            ddl.DataTextField = "NombreProvincia";
            ddl.DataValueField = "IdProvincia";
            ddl.DataBind();

            if (ddl.Items.FindByValue(valorAnterior) != null)
            {
                ddl.SelectedValue = valorAnterior;
            }

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

        private void FiltrarProvincia_opcion2(DropDownList ddl, string idExcluir)
        {
            DataTable tabla = (DataTable)Session["TablaProvincias"];
            DataView vista = new DataView(tabla);
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
            MostrarResumen();
        }

        protected void ddlProvincia2_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarLocalidades(ddlLocalidad2, ddlProvincia2.SelectedValue);
            FiltrarProvincia(ddlProvincia1, ddlProvincia2.SelectedValue);
            MostrarResumen();
        }

        protected void ddlLocalidad1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MostrarResumen();
        }

        protected void ddlLocalidad2_SelectedIndexChanged(object sender, EventArgs e)
        {
            MostrarResumen();
        }

        private void MostrarResumen()
        {
            if (ddlLocalidad1.Items.Count > 0 && ddlLocalidad2.Items.Count > 0)
            {
                lblResumen.Text = "Viaje: " + ddlLocalidad1.SelectedItem.Text + " (" + ddlProvincia1.SelectedItem.Text + ") → " +
                                  ddlLocalidad2.SelectedItem.Text + " (" + ddlProvincia2.SelectedItem.Text + ")";
                lblResumen.Visible = true;
            }
            else
            {
                lblResumen.Visible = false;
            }
        }
    }
}