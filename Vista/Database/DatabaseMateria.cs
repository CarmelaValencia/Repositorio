using Modelo;
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
            String query = "insert into materias (nombre_materias,total_horas,horas_semana,ciclo) values(@nombre,@total,@semana,@periodo)";
            try
            {
                cn = Conexion.Instance.Conectar();
                if (cn != null)
                {
                    cn.Open();
                    SQLiteCommand cmd = new SQLiteCommand(query, cn);
                    
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

        public SQLiteDataAdapter Consultar(String buscar)
        {
            cn = Conexion.Instance.Conectar();
            da = new SQLiteDataAdapter("select * from materias where nombre_materias like'%"+buscar+ "%' " +
                " or ciclo like'%" + buscar + "%' ", cn);
            return da;
        }
        public SQLiteDataAdapter ListarMaterias(int idGrupo) {
            cn = Conexion.Instance.Conectar();
            da = new SQLiteDataAdapter("select * from m_g where id_gruposf="+idGrupo+" ",cn);
            return da;
        }
    }
}
