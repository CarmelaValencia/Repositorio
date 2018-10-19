using System.Drawing;
using System.Windows.Forms;
using Vista.Vistas;

namespace documentosEstadia1._1
{

    public partial class Form1 : Form
    {
        docentes doc;
        materias mat;
        grupos grp;
        horario hr;
        Point DragCursor;
        Point DragForm;
        bool Dragging;
        bool max_min = false;
        public Form1()
        {
            InitializeComponent();
            button_docentes.BackColor = Color.Black;
            button_docentes.FlatAppearance.MouseOverBackColor = Color.Black;
            doc = new docentes();
            mat = new materias();
            grp = new grupos();
            hr = new horario();
            bajarNivel(doc);
            bajarNivel(mat);
            bajarNivel(grp);
            bajarNivel(hr);
        }

        public void bajarNivel(Form frm) {
            frm.TopLevel = false;
            frm.Visible = true;
            flowLayoutPanel2.Controls.Add(frm);
        }

        private void pictureBox14_Click(object sender, System.EventArgs e)
        {
            if (max_min == false)
            {
                WindowState = FormWindowState.Maximized;
            }
            if (max_min == true)
            {
                WindowState = FormWindowState.Normal;
            }
            if (max_min == false)
            {
                max_min = true;
            }
            else
            {
                max_min = false;
            }
            //MessageBox.Show(flowLayoutPanel2.Size.Width+"----"+ flowLayoutPanel2.Size.Height);
            agregarTamanio(doc);
            agregarTamanio(mat);
            agregarTamanio(grp);
        }

        public void agregarTamanio(Form frm) {
            frm.Width = flowLayoutPanel2.Size.Width;
            frm.Height = flowLayoutPanel2.Size.Height;
        }

        private void pictureBox7_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void button_titulo_Click(object sender, System.EventArgs e)
        {

        }

        private void button_titulo_MouseMove(object sender, MouseEventArgs e)
        {
            if (Dragging == true)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(DragCursor));
                this.Location = Point.Add(DragForm, new Size(dif));
            }
        }

        private void button_titulo_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void button_titulo_MouseUp(object sender, MouseEventArgs e)
        {
            Dragging = false;
        }

        private void button_titulo_MouseDown(object sender, MouseEventArgs e)
        {
            Dragging = true;
            DragCursor = Cursor.Position;
            DragForm = this.Location;
        }

        private void pictureBox15_Click(object sender, System.EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        public void seleccionarBtn(int seleccionado) {
            if (seleccionado == 1){
                button_docentes.BackColor = Color.Black;
                button_docentes.FlatAppearance.MouseOverBackColor = Color.Black;
            } else {
                button_docentes.BackColor = Color.DimGray;
                button_docentes.FlatAppearance.MouseOverBackColor = Color.Gray;
            }

            if (seleccionado == 2){
                button_grupos.BackColor = Color.Black;
                button_grupos.FlatAppearance.MouseOverBackColor = Color.Black;
            }else {
                button_grupos.BackColor = Color.DimGray;
                button_grupos.FlatAppearance.MouseOverBackColor = Color.Gray;
            }

            if (seleccionado == 3){
                button_materias.BackColor = Color.Black;
                button_materias.FlatAppearance.MouseOverBackColor = Color.Black;
            }
            else {
                button_materias.BackColor = Color.DimGray;
                button_materias.FlatAppearance.MouseOverBackColor = Color.Gray;
            }

            if (seleccionado == 4){
                button_horas.FlatAppearance.MouseOverBackColor = Color.Black;
                button_horas.BackColor = Color.Black;
            }
            else {
                button_horas.BackColor = Color.DimGray;
                button_horas.FlatAppearance.MouseOverBackColor = Color.Gray;
            }
            
        }

        private void button_docentes_Click(object sender, System.EventArgs e)
        {
            seleccionarBtn(1);
            doc.Visible = true;
            mat.Visible = false;
            grp.Visible = false;
            hr.Visible = false;
        }

        private void button_grupos_Click(object sender, System.EventArgs e)
        {
            seleccionarBtn(2);
            doc.Visible = false;
            mat.Visible = false;
            grp.Visible = true;
            hr.Visible = false;
        }

        private void button_materias_Click(object sender, System.EventArgs e)
        {
            doc.Visible = false;
            mat.Visible = true;
            grp.Visible = false;
            hr.Visible = false;
            seleccionarBtn(3);
        }

        private void button_horas_Click(object sender, System.EventArgs e)
        {
            doc.Visible = false;
            mat.Visible = false;
            grp.Visible = false;
            hr.Visible = true;
            seleccionarBtn(4);
        }

        private void button_generar_horario_Click(object sender, System.EventArgs e)
        {

        }
    }
}
