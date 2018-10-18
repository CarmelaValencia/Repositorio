//importar libreria sqlite
using System.Data.SQLite;
using System.Windows.Forms;
namespace Database
{
    public sealed class Conexion
    {
        private static Conexion conexion = null;
        SQLiteConnection cn = null;
        
        private Conexion() {
            Conectar();
        }
        public static Conexion Instance
        {
            get
            {
                if (conexion == null)
                {
                    conexion = new Conexion();
                }
                return conexion;
            }
        }
        public SQLiteConnection Conectar() {
            
            /*Realizamos la conexion a la base de datos*/
            try {
                cn = new SQLiteConnection("data source=C:/Users/Karmela/Documents/generadorHorario.db");
                return cn;
            }
            catch (SQLiteException ex) {
                MessageBox.Show("Error al realizar la conexion \n "+ex.Message);
                return cn;
            }
            
        }

    }

}
