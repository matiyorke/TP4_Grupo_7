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
        private DataTable ObtenerProductos()
        {
            using (SqlConnection conn = new SqlConnection(rutaNeptunoSQL))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Productos", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
                DataTable dt = ObtenerProductos(); //Llamamos a la funcion obtener productos
                Session["Productos"] = dt;//Almacenamos

                CargarGrid();
            }
        }

        // Método para traer todos los datos
        private void CargarGrid()
        {
            /*SqlConnection conn = new SqlConnection(rutaNeptunoSQL);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Productos", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);*/
            gvProdCat.DataSource = Session["Productos"]; //Utilizamos los datos almacenados en Session
            gvProdCat.DataBind();
            //conn.Close();
        }


        protected void btnFiltrar_Click1(object sender, EventArgs e)
        {

            if (txtCategoria.Text == "" && txtProducto.Text == "")
            {

            }
            else
            {

                /*SqlConnection conn = new SqlConnection(rutaNeptunoSQL);
                conn.Open();*/

                string[] ops = { "=", ">", "<" };
                string operadorP = ops[int.Parse(DropDownList1.SelectedValue)]; //operador en producto
                string operadorC = ops[int.Parse(DropDownList2.SelectedValue)]; //operador en categoría
                bool productoF = txtProducto.Text != "";  //tiene producto o no
                bool categoriaF = txtCategoria.Text != "";  //tiene categoría o no
                                                            //string consulta = "";


                //caso completo//
                /*if (productoF && categoriaF)
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


                //SqlCommand cmd = new SqlCommand(consulta, conn);

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

                da.Fill(dt);*/

                DataTable dt = (DataTable)Session["Productos"]; //Traemos los datos almacenados en Session
                DataView dv = new DataView(dt); //Cargamos en DataView lo que esta en la DataTable

                string filtro = ""; //Creamos un query dinamico
                if (productoF)
                {
                    filtro += $"IdProducto {operadorP} {txtProducto.Text}"; //Si hay producto se agrega
                }
                if (categoriaF)
                {
                    if(filtro != "")
                    {
                        filtro += " AND "; //Si hay producto y catergoria, agrega un AND para conectar
                    }
                    filtro += $"IdCategoría {operadorC} {txtCategoria.Text}"; //Agrega despues del AND para completar la consulta
                }
                //Aplicamos el filtro
                dv.RowFilter = filtro;
                //bindeamos
                gvProdCat.DataSource = dv;
                gvProdCat.DataBind();

                txtProducto.Text = ""; // limpiamos los campos
                txtCategoria.Text = "";

                lblResultados.Text = "Resultados encontrados: " + dv.Count; // mostramos el número de resultados encontrados

                //conn.Close();
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

    