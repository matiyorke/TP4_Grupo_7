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
        
        private const string ConsultaSQL = "SELECT * FROM Libros WHERE IdTema = @Tema";

        protected void Page_Load(object sender, EventArgs e)
        {
          

            if (!IsPostBack)
            {
                int tema = Convert.ToInt32(Session["TemaSeleccionado"]);

                SqlConnection conexion = new SqlConnection(CadenaConexion);
                conexion.Open();

                SqlCommand comando = new SqlCommand(ConsultaSQL, conexion);
                comando.Parameters.AddWithValue("@Tema", tema);

                SqlDataAdapter adapter = new SqlDataAdapter(comando);
                DataTable tabla = new DataTable();
                adapter.Fill(tabla);

                GridView1.DataSource = tabla;
                GridView1.DataBind();



                conexion.Close();
            }
        }    
    }
}