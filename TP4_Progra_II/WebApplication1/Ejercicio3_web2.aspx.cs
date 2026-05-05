using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Reflection.Emit;

namespace WebApplication1
{
    public partial class Ejercicio3_web2 : System.Web.UI.Page
    {
        private const string CadenaConexion = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=Libreria;Integrated Security=True";

        private const string ConsultaSQL = "SELECT * FROM Libros WHERE IdTema = @Tema ";

        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {
                if (Session["TemaSeleccionado"] == null || Session["OrdenPrecio"] == null)
                {
                    Response.Redirect("Ejercicio3a.aspx");
                    return;
                }

                int tema = Convert.ToInt32(Session["TemaSeleccionado"]);
                string ordenPrecio = Session["OrdenPrecio"].ToString();

                string ordenSQL = "";

                if (ordenPrecio == "ASC")
                {
                    ordenSQL = " ORDER BY Precio ASC";
                }
                else if (ordenPrecio == "DESC")
                {
                    ordenSQL = " ORDER BY Precio DESC";
                }
                else
                {
                    ordenSQL = " ORDER BY Precio ASC"; // Por default
                }

                string consultaSQLFinal = ConsultaSQL + " " + ordenSQL;

                using (SqlConnection conexion = new SqlConnection(CadenaConexion))
                {
                    conexion.Open();

                    SqlCommand comando = new SqlCommand(consultaSQLFinal, conexion);
                    comando.Parameters.AddWithValue("@Tema", tema);

                    SqlDataAdapter adapter = new SqlDataAdapter(comando);
                    DataTable tabla = new DataTable();
                    adapter.Fill(tabla);

                    GridView1.DataSource = tabla;
                    GridView1.DataBind();

                    //  Cantidad de libros
                    int cantidad = tabla.Rows.Count;

                    //  Total de precios
                    decimal totalPrecios = 0;

                    if (tabla.Rows.Count > 0)
                    {
                        totalPrecios = Convert.ToDecimal(tabla.Compute("SUM(Precio)", ""));
                    }

                    //  Mostrar en labels
                    lblCantidad.Text = "Cantidad de libros: " + cantidad;
                    lblTotal.Text = "Total : $" + totalPrecios.ToString("0.00");
                }
            }
        }

        protected void libVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Ejercicio3a.aspx");
        }
    }
}