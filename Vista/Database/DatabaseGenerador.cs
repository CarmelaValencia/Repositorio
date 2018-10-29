using Database;
using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace Vista.Database
{
    public class DatabaseGenerador
    {
        SQLiteConnection cn = null;
        SQLiteDataAdapter da = null;
        public Boolean Guardar(string dia, int hora, int docente, int materia, int grupo)
        {
            String query = "insert into horario values(@dia,@hora,@docente,@materia,@grupo)";
            try
            {
                cn = Conexion.Instance.Conectar();
                if (cn != null)
                {
                    cn.Open();
                    SQLiteCommand cmd = new SQLiteCommand(query, cn);

                    cmd.Parameters.AddWithValue("@dia", dia);
                    cmd.Parameters.AddWithValue("@hora", hora);
                    cmd.Parameters.AddWithValue("@docente", docente);
                    cmd.Parameters.AddWithValue("@materia", materia);
                    cmd.Parameters.AddWithValue("@grupo", grupo);
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
        /*Método para buscar el siguiente al que se le va a crear el horario*/
        public String[] ObtenerSiguienteGrupo()
        {
            String[] datos = new string[2];
            DataTable dataTable = new DataTable();
            cn = Conexion.Instance.Conectar();
            da = new SQLiteDataAdapter("SELECT id_grupos,turno FROM grupos where id_grupos not in" +
                " (select distinct id_gruposf from horario) ORDER BY random() limit 1", cn);
            da.Fill(dataTable);
            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];
                datos[0] = row["id_grupos"].ToString();
                datos[1] = row["turno"].ToString();
            }
            else {
                datos[0] = "0";
                datos[1] ="0";
            }
            
            return datos;//devolver idGrupo y turno
        }
        
        /*Metodo para obtener las horas que va a tener clases el grupo (matutino/vespertino)*/
        public int [] ObtenerHoras(string turno)
        {
            DataTable dataTable = new DataTable();
            cn = Conexion.Instance.Conectar();
            da = new SQLiteDataAdapter("SELECT id_horas FROM horas where tipo='"+turno+"'", cn);
            da.Fill(dataTable);
            int [] datos = new int[dataTable.Rows.Count];
            for (int i = 0; i < datos.Length; i++)
            {
                DataRow row = dataTable.Rows[i];
                datos[i] = int.Parse(row["id_horas"].ToString());
            }
            return datos;
        }
        /*Método para buscar que clase(materia)/y docente tendra el grupo a un hora*/
        //el docente no debe tener asignado una clase a esa hora y dia con ningun otro grupo
        public int ObtenerMateria(int grupo,string dia)
        {
            int idMateria = 0;
            DataTable dataTable = new DataTable();
            cn = Conexion.Instance.Conectar();
            da = new SQLiteDataAdapter("SELECT id_materias,horas_semana FROM materias where id_materias not in " +
                " (select distinct id_materiasf from horario where id_gruposf = "+grupo+" and dia = '"+dia+"') and id_materias " +
                "in(select distinct m_g.id_materias as id_materias from m_g inner join TotalClasesImpartidos on m_g.id_gruposf = TotalClasesImpartidos.id_gruposf " +
                " where m_g.id_gruposf = "+grupo+" and m_g.id_materias = TotalClasesImpartidos.id_materiasf " +
                "and  m_g.horas_semana > TotalClasesImpartidos.totalClases) " +
                " ORDER BY random() limit 1", cn);
            da.Fill(dataTable);
            if (dataTable.Rows.Count>0) {
                DataRow row = dataTable.Rows[0];
                idMateria = int.Parse(row["id_materias"].ToString());
            }
            return idMateria;
        } 
        public int ObtenerDocente(int materia, int grupo, string dia, int hora)
        {
            int idDocente = 0;
            DataTable dataTable = new DataTable();
            cn = Conexion.Instance.Conectar();
            da = new SQLiteDataAdapter("select id_docentesf FROM docentes_materias where id_materiasf="+materia+" and id_gruposf="+grupo+ " and id_docentesf not in(select  distinct id_docentesf from horario where id_horasf="+hora+" and dia='"+dia+"') limit 1", cn);
            da.Fill(dataTable);
            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];
                idDocente = int.Parse(row["id_docentesf"].ToString());
            }
            return idDocente;
        }
    }
}
