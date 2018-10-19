using Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vista.Modelos;

namespace Vista.Database
{
    class DatabaseDocente
    {
        SQLiteConnection cn = null;
        SQLiteDataAdapter da = null;
        public Boolean Guardar(ModeloDocente modeloDocente)
        {
            String query = "insert into docentes (nombre_docentes,apellidos,numero_horas,estado) " +
                "values(@nombre,@apellidos,@numero_horas,@estado)";
            try
            {
                cn = Conexion.Instance.Conectar();
                if (cn != null)
                {
                    cn.Open();
                    SQLiteCommand cmd = new SQLiteCommand(query, cn);

                    cmd.Parameters.AddWithValue("@nombre", modeloDocente.Nombre_docentes);
                    cmd.Parameters.AddWithValue("@apellidos", modeloDocente.Apellidos);
                    cmd.Parameters.AddWithValue("@numero_horas", modeloDocente.Numero_horas);
                    cmd.Parameters.AddWithValue("@estado", modeloDocente.Estado);
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Mensaje Error: " + e.Message);
                return false;
            }

        }

        public Boolean Eliminar(int id)
        {
            String query = "delete from docentes where id_docentes=@id";
            try
            {
                cn = Conexion.Instance.Conectar();
                if (cn != null)
                {
                    cn.Open();
                    SQLiteCommand cmd = new SQLiteCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error:" + e.Message);
                return false;
            }
        }

        public Boolean Actualizar(ModeloDocente modeloDocente)
        {
            String query = "update materias set nombre_docentes=@nombre,apellidos=@apellidos,numero_horas=@numero_horas," +
                "estado=@estado where id_docentes=@id";
            try
            {
                cn = Conexion.Instance.Conectar();
                if (cn != null)
                {
                    cn.Open();
                    SQLiteCommand cmd = new SQLiteCommand(query, cn);
                    cmd.Parameters.AddWithValue("@nombre", modeloDocente.Nombre_docentes);
                    cmd.Parameters.AddWithValue("@apellidos", modeloDocente.Apellidos);
                    cmd.Parameters.AddWithValue("@numero_horas", modeloDocente.Numero_horas);
                    cmd.Parameters.AddWithValue("@estado", modeloDocente.Estado);
                    cmd.Parameters.AddWithValue("@id",modeloDocente.Id_docentes);
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error:" + e.Message);
                return false;
            }
        }

        public SQLiteDataAdapter Consultar(String buscar)
        {
            cn = Conexion.Instance.Conectar();
            /*Creamos el objeto y le pasamos la consulta*/
            da = new SQLiteDataAdapter("select * from docentes where nombre_docentes like'%" + buscar + "%' " +
                " or apellidos like'%" + buscar + "%' ", cn);
            return da;
        }
    }
}
