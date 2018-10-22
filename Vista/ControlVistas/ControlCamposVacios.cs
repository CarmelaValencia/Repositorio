using System;
using System.Windows.Forms;

namespace Vista.ControlVistas
{
    class ControlCamposVacios
    {

        public static int detactarVacios(String [] str) {
            int vacios = 0;
            for (int i=0;i<str.Length;i++) {
                if (str[i]=="") {
                    vacios = 1;
                    //MessageBox.Show("Vacios o men 1: " + vacios);
                }
                if (str[i]=="0") {
                    vacios = 1;
                    //MessageBox.Show("Vacios o men 2: " + vacios);
                }
            }
            if (vacios==1) {
                MessageBox.Show("DATOS NO VALIDOS");
            }
            return vacios;
        }

        public static void ShowBoxSuccess(string txtMessage)
        {
            MessageBox.Show(txtMessage,"",MessageBoxButtons.OK,MessageBoxIcon.Error);
            //return Button_id;
        }
    }
}
