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

        public void DesAsignarMaterias(int grupo, int materia, int docente)
        {
            String query = "delete from docentes_materias where id_materiasf=@materia and id_gruposf=@grupo " +
                " and id_docentesf=@docente";
            try
            {
                cn = Conexion.Instance.Conectar();
                if (cn != null)
                {
                    cn.Open();
                    SQLiteCommand cmd = new SQLiteCommand(query, cn);
                    cmd.Parameters.AddWithValue("@materia", materia);
                    cmd.Parameters.AddWithValue("@grupo", grupo);
                    cmd.Parameters.AddWithValue("@docente", docente);
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error:" + e.Message);
            }
        }

        public void AsignarMaterias(int idSeleccionado, int materia, int docente)
        {
            String query = "insert into docentes_materias(id_docentesf,id_materiasf,id_gruposf) " +
                " values(@docente,@materia,@grupo)";
            try
            {
                cn = Conexion.Instance.Conectar();
                if (cn != null)
                {
                    cn.Open();
                    SQLiteCommand cmd = new SQLiteCommand(query, cn);

                    cmd.Parameters.AddWithValue("@docente", docente);
                    cmd.Parameters.AddWithValue("@materia", materia);
                    cmd.Parameters.AddWithValue("@grupo", idSeleccionado);
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Mensaje Error: " + e.Message);
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
        public SQLiteDataAdapter ListarMaterias(int idGrupo,int idDocente) {
            cn = Conexion.Instance.Conectar();
            da = new SQLiteDataAdapter("select * from m_g where id_gruposf="+idGrupo+" and id_materias " +
                " not in(select id_materiasf from docentes_materias where id_gruposf="+idGrupo+" and id_docentesf!="+idDocente+") ",cn);
            return da;
        }
    }
}
