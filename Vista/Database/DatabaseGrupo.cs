using Database;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vista.Modelos;

namespace Vista.Database
{
    public class DatabaseGrupo
    {
        SQLiteConnection cn = null;
        SQLiteDataAdapter da;
        public Boolean Guardar(ModeloGrupo modeloGrupo)
        {
            String query = "insert into grupos (nombre_grupos,semestre,area,estado) values(@nombre,@semestre,@area,@estado)";
            try
            {
                cn = Conexion.Instance.Conectar();
                if (cn != null)
                {
                    cn.Open();
                    SQLiteCommand cmd = new SQLiteCommand(query, cn);

                    cmd.Parameters.AddWithValue("@nombre", modeloGrupo.Nombre_grupos);
                    cmd.Parameters.AddWithValue("@semestre", modeloGrupo.Semestre);
                    cmd.Parameters.AddWithValue("@area", modeloGrupo.Area);
                    cmd.Parameters.AddWithValue("@estado", modeloGrupo.Estado);
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
            String query = "delete from grupos where id_grupos=@id";
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

        public Boolean Actualizar(ModeloGrupo modeloGrupo)
        {
            String query = "update grupos set nombre_grupos=@nombre,semestre=@semestre,area=@area," +
                "estado=@estado where id_grupos=@id";
            try
            {
                cn = Conexion.Instance.Conectar();
                if (cn != null)
                {
                    cn.Open();
                    SQLiteCommand cmd = new SQLiteCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", modeloGrupo.Id_grupos);
                    cmd.Parameters.AddWithValue("@nombre", modeloGrupo.Nombre_grupos);
                    cmd.Parameters.AddWithValue("@semestre", modeloGrupo.Semestre);
                    cmd.Parameters.AddWithValue("@area", modeloGrupo.Area);
                    cmd.Parameters.AddWithValue("@estado", modeloGrupo.Estado);
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
            da = new SQLiteDataAdapter("select * from grupos where nombre_grupos like'%" + buscar + "%' " +
                " or semestre like'%" + buscar + "%' ", cn);
            return da;
        }

        public SQLiteDataAdapter ListarGrupos(String buscar) {
            cn = Conexion.Instance.Conectar();
            da = new SQLiteDataAdapter("select (semestre || ' Semestre :: Grupo ' || nombre_grupos || ' ' || area) " +
                " as nombreGrupos,id_grupos from grupos;",cn);
            return da;
        }
    }
}
