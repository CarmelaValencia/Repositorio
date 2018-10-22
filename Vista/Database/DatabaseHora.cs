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
    class DatabaseHora
    {
        SQLiteConnection cn = null;
        SQLiteDataAdapter da = null;
        public Boolean Guardar(ModeloHora modeloHora)
        {
            String query = "insert into horas (inicio,fin,tipo) values(@inicio,@fin,@tipo)";
            try
            {
                cn = Conexion.Instance.Conectar();
                if (cn != null)
                {
                    cn.Open();
                    SQLiteCommand cmd = new SQLiteCommand(query, cn);

                    cmd.Parameters.AddWithValue("@inicio", modeloHora.Inicio);
                    cmd.Parameters.AddWithValue("@fin", modeloHora.Fin);
                    cmd.Parameters.AddWithValue("@tipo", modeloHora.Tipo);
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
            String query = "delete from horas where id_horas=@id";
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
        public Boolean Actualizar(ModeloHora modeloHora)
        {
            String query = "update horas set inicio=@inicio,fin=@fin,tipo=@turno " +
                " where id_horas=@id";
            try
            {
                cn = Conexion.Instance.Conectar();
                if (cn != null)
                {
                    cn.Open();
                    SQLiteCommand cmd = new SQLiteCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", modeloHora.IdHoras);
                    cmd.Parameters.AddWithValue("@inicio", modeloHora.Inicio);
                    cmd.Parameters.AddWithValue("@fin", modeloHora.Fin);
                    cmd.Parameters.AddWithValue("@turno", modeloHora.Tipo);
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
            da = new SQLiteDataAdapter("select * from horas where inicio like'%" + buscar + "%' " +
                " or fin like'%" + buscar + "%' or tipo like'%" + buscar + "%'", cn);
            return da;
        }
    }
}
