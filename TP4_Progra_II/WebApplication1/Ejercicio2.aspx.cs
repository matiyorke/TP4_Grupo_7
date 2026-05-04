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

            if (txtCategoria.Text == "" && txtProducto.Text == "" && txtProveedor.Text == "")
            {
                
                    gvProdCat.DataSource = Session["Productos"];
                    gvProdCat.DataBind();

                    lblResultados.Text = "Mostrando todos los registros";
                    return;
                

            }
            else
            {
                //if (!(int.TryParse(txtCategoria.Text, out _)) || !(int.TryParse(txtProducto.Text, out _)) 
                //|| !(int.TryParse(txtProveedor.Text, out _)))
                //{
                //    lblError.Text = "Todos los campos a filtrar deben contener números.";
                //    txtCategoria.Text = string.Empty;
                //    txtProducto.Text = string.Empty;
                //    txtProveedor.Text = string.Empty;
                //    return;
                //}

                //lblError.Text = string.Empty;

                /*SqlConnection conn = new SqlConnection(rutaNeptunoSQL);
                conn.Open();*/

                string[] ops = { "=", ">", "<" };
                string operadorP = ops[int.Parse(DropDownList1.SelectedValue)]; //operador en producto
                string operadorC = ops[int.Parse(DropDownList2.SelectedValue)]; //operador en categoría
                string operadorProv = ops[int.Parse(DropDownList3.SelectedValue)]; //operador en proveedor
                string operadorStock = ops[int.Parse(DropDownList4.SelectedValue)]; //operador en stock
                bool productoF = txtProducto.Text != "";  //tiene producto o no
                bool categoriaF = txtCategoria.Text != "";  //tiene categoría o no
                bool proveedorF = txtProveedor.Text != "";  //tiene proveedor o no
                                                            //string consulta = "";
                bool stockF = txtStock.Text != "";


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
                    filtro += (filtro != "" ? " AND" : "") + $" IdCategoría {operadorC} {txtCategoria.Text}"; //Agrega despues del AND para completar la consulta
                }
                if (proveedorF)
                {
                    filtro += (filtro != "" ? " AND" : "") + $" IdProveedor {operadorProv} {txtProveedor.Text}";
                }

                if (stockF)
                {
                    filtro += (filtro != "" ? " AND" : "") + $" UnidadesEnExistencia {operadorStock} {txtStock.Text}";
                }

                //if (productoF)
                //{
                //    filtro += $"IdProducto {operadorP} {txtProducto.Text}"; //Si hay producto se agrega
                //}
                //if (categoriaF)
                //{
                //    if(filtro != "")
                //    {
                //        filtro += " AND "; //Si hay producto y catergoria, agrega un AND para conectar
                //    }
                //    filtro += $"IdCategoría {operadorC} {txtCategoria.Text}"; //Agrega despues del AND para completar la consulta
                //}

                dv.RowFilter = filtro;
                //bindeamos
                gvProdCat.DataSource = dv;
                gvProdCat.DataBind();

                txtProducto.Text = ""; // limpiamos los campos
                txtCategoria.Text = "";
                txtProveedor.Text = "";
                txtStock.Text = "";

                lblResultados.Text = "Resultados encontrados: " + dv.Count; // mostramos el número de resultados encontrados

                //conn.Close();
            }
        }

        protected void btnQuitar_Click(object sender, EventArgs e)
        {
            lblError.Text = string.Empty;
            lblResultados.Text = "";
            txtProducto.Text = "";
            txtCategoria.Text = "";
            txtProveedor.Text = "";
            txtStock.Text = "";
            CargarGrid();
        }

        protected void btnWF1EJ2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Ejercicio1.aspx");
        }
        protected void btnWF3EJ2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Ejercicio3_web2.aspx");
        }

    }
}

    