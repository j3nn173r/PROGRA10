using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tarea10.clases.archivos;
using tarea10.clases.datos;

namespace tarea10
{
    public partial class formularioinicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void cargardatos()
        {
            string Cool = @"C:\Users\alumno\Documents\datoscvs\crudDB.csv";
            ClsArchivos nu = new ClsArchivos();
            ClsConexion an = new ClsConexion();

            String[] arregloNotas = nu.LeerArchivo(Cool);
            string ang_sql = "";
            int cnlinea = 0;
            foreach(string linea in arregloNotas)
            {
                string[] datos = linea.Split(';');
                if (cnlinea > 0)
                {
                    ang_sql = $"insert into alumno values({datos[0]},'{datos[1]}'{datos[2]},{datos[3]},{datos[4]},{datos[5]},'{datos[6]}'";
                    an.EjecutaSQLDirecto(ang_sql);
                }
                cnlinea++;
            }
            cnlinea = 0;
        }

        public DataTable Cargarsql(string no = "1=1")
        {


            ClsConexion an = new ClsConexion();
            DataTable ma = new DataTable();
            string lo = $"select*from alumno where {no}";
            ma = an.consultaTablaDirecta(lo);
            return ma;


        }
            protected void Button1cargardatos_Click(object sender, EventArgs e)
        {

            cargardatos();

        }
                   
    }
}