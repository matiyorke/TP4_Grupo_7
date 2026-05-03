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


        protected void btnFiltrar_Click1(object sender, EventArgs e)
        {

            if (txtCategoria.Text == "" && txtProducto.Text == "")
            {

            }
            else
            {

                SqlConnection conn = new SqlConnection(rutaNeptunoSQL);
                conn.Open();

                string[] ops = { "=", ">", "<" };
                string operadorP = ops[int.Parse(DropDownList1.SelectedValue)]; //operador en producto
                string operadorC = ops[int.Parse(DropDownList2.SelectedValue)]; //operador en categoría
                bool productoF = txtProducto.Text != "";  //tiene producto o no
                bool categoriaF = txtCategoria.Text != "";  //tiene categoría o no
                string consulta = "";

                //caso completo//
                if (productoF && categoriaF)
                {
                    consulta = "SELECT * FROM Productos WHERE IdProducto " + operadorP + " @id AND IdCategoría " + operadorC + " @cat";
                }
                //caso categoria/
                else if (!productoF && categoriaF)
                {

                    consulta = "SELECT * FROM Productos WHERE IdCategoría " + operadorC + " @cat";   //busquen si hay tilde en el nombre de la columna//

                }
                //caso producto//
                else if (productoF && !categoriaF)
                {
                    consulta = "SELECT * FROM Productos WHERE IdProducto " + operadorP + " @id";
                }


                SqlCommand cmd = new SqlCommand(consulta, conn);

                // Convertir a número
                if (categoriaF)
                {
                    cmd.Parameters.AddWithValue("@cat", int.Parse(txtCategoria.Text));
                }
                if (productoF)
                {
                    cmd.Parameters.AddWithValue("@id", int.Parse(txtProducto.Text));

                }




                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                da.Fill(dt);

                gvProdCat.DataSource = dt;
                gvProdCat.DataBind();

                txtProducto.Text = ""; // limpiamos los campos
                txtCategoria.Text = "";

                lblResultados.Text = "Resultados encontrados: " + dt.Rows.Count; // mostramos el número de resultados encontrados

                conn.Close();
            }
        }

        protected void btnQuitar_Click(object sender, EventArgs e)
        {
            txtProducto.Text = "";
            txtCategoria.Text = "";
            CargarGrid();
        }
    }
}

    