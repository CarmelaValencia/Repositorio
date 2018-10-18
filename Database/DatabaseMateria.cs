using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace Database
{
    public class DatabaseMateria
    {
        SQLiteConnection cn = null;
        SQLiteDataAdapter da = null;
        public Boolean Guardar(ModeloMateria modeloMateria)
        {
            if (modeloMateria == null)
            {
                throw new ArgumentNullException(nameof(modeloMateria));
            }

            String query = "insert into materias values(@id,@nombre,@total,@semana,@periodo)";
            try
            {
                cn = Conexion.Instance.Conectar();
                if (cn != null)
                {
                    cn.Open();
                    SQLiteCommand cmd = new SQLiteCommand(query, cn);

                    cmd.Parameters.AddWithValue("@id", 0);
                    cmd.Parameters.AddWithValue("@nombre", modeloMateria.NombreMateria);
                    cmd.Parameters.AddWithValue("@total", modeloMateria.Total_horas);
                    cmd.Parameters.AddWithValue("@semana", modeloMateria.Horas_semana);
                    cmd.Parameters.AddWithValue("@periodo", modeloMateria.Ciclo);
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    return true;
                }
                else {
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
            String query = "delete from materias where id_materias=@id";
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

        public Boolean Actualizar(ModeloMateria modeloMateria)
        {
            String query = "update materias set nombre_materias=@nombre,total_horas=@total,horas_semana=@semana," +
                "ciclo=@ciclo where id_materias=@id";
            try
            {
                cn = Conexion.Instance.Conectar();
                if (cn != null)
                {
                    cn.Open();
                    SQLiteCommand cmd = new SQLiteCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", modeloMateria.IdMateria);
                    cmd.Parameters.AddWithValue("@nombre", modeloMateria.NombreMateria);
                    cmd.Parameters.AddWithValue("@total", modeloMateria.Total_horas);
                    cmd.Parameters.AddWithValue("@semana", modeloMateria.Horas_semana);
                    cmd.Parameters.AddWithValue("@ciclo", modeloMateria.Ciclo);
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    return true;
                }
                else {
                    return false;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error:" + e.Message);
                return false;
            }
        }

        public DataTable Consultar(String buscar)
        {
            /*Creamos el objeto y le pasamos la consulta*/
            da = new SQLiteDataAdapter("select * from materias where nombre_materias like'%"+buscar+ "%' " +
                " or ciclo like'%" + buscar + "%' ", cn);
            /*Creamos el modelo de una tabla*/
            System.Data.DataTable dt = new DataTable();
            /*Rellenamos el modelo de la tabla con los datos de la consulta*/
            da.Fill(dt);
            /*Pasamos los datos del modelo al datagrid view de la vista*/
            return dt;
        }

    }
}
