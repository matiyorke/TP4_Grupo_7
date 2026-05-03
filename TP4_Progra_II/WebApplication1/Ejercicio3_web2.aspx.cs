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
    public partial class Ejercicio3_web2 : System.Web.UI.Page
    {
        private const string CadenaConexion = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=Libreria;Integrated Security=True";
        
        private const string ConsultaSQL = "SELECT * FROM Libros";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SqlConnection conexion = new SqlConnection(CadenaConexion);
                conexion.Open();



                SqlDataAdapter adapter = new SqlDataAdapter(ConsultaSQL, conexion);
                DataTable tabla = new DataTable();
                adapter.Fill(tabla);

                // ejemplo para mostrar los datos
                GridView1.DataSource = tabla;
                GridView1.DataBind();



                conexion.Close();
            }
        }    
    }
}