using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Ejercicio2 : System.Web.UI.Page
    {
        private string rutaNeptunoSQL = @"Data Source=.\SQLEXPRESS;Initial Catalog=Neptuno; Integrated Security=True; Encrypt=False;TrustServerCertificate=True";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarGrid();
            }
        }

        // Método para traer todos los datos
        private void CargarGrid()
        {
            SqlConnection conn = new SqlConnection(rutaNeptunoSQL);
            conn.Open();

            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Productos", conn);
            DataTable dt = new DataTable();

            da.Fill(dt);

            gvProdCat.DataSource = dt;
            gvProdCat.DataBind();

            conn.Close();
        }

        // Botón Filtrar (solo caso IdProducto)

        protected void btnFiltrar_Click1(object sender, EventArgs e)
        {
            if (txtProducto.Text != "" && txtCategoria.Text == "")
            {
                SqlConnection conn = new SqlConnection(rutaNeptunoSQL);
                conn.Open();

                string[] ops = { "=", ">", "<" };
                string operador = ops[int.Parse(DropDownList1.SelectedValue)];

                string consulta = "SELECT * FROM Productos WHERE IdProducto " + operador + " @id";

                SqlCommand cmd = new SqlCommand(consulta, conn);

                // Convertir a número
                cmd.Parameters.AddWithValue("@id", int.Parse(txtProducto.Text));

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                da.Fill(dt);

                gvProdCat.DataSource = dt;
                gvProdCat.DataBind();

                conn.Close();
            }
        }



    }

}