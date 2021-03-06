﻿using documentosEstadia1._1.Vistas;
using System;
using System.Drawing;
using System.Windows.Forms;
using Vista.ControlVistas;
using Vista.Vistas;

namespace documentosEstadia1._1
{
    public partial class docentes : Form
    {
        agregardocentes agd;
        asignarMateriasDocente amd;
        public docentes()
        {
            InitializeComponent();
            this.lista.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 12);
            this.lista.DefaultCellStyle.SelectionForeColor = Color.White;
            this.lista.DefaultCellStyle.SelectionBackColor = Color.Orange;

            agd = new agregardocentes(flowLayoutPanel1,-1);
            agd.TopLevel = false;
            agd.Visible = true;
            flowLayoutPanel1.Width = this.Width;
            flowLayoutPanel1.Height = this.Height;
            flowLayoutPanel1.Controls.Add(agd);
            flowLayoutPanel1.Visible = false;
            ControlVistaDocente controlVistaDocente = new ControlVistaDocente();
            controlVistaDocente.iniciarDocentes(this);
            asignarTamanioVentanaResponsivo(agd);
        }

        private void btn_agregar_Click(object sender, EventArgs e)
        {
            ControlVistaDocente.opcion = "Registrar";
            flowLayoutPanel1.Controls.Remove(agd);
            flowLayoutPanel1.Controls.Remove(amd);
            flowLayoutPanel1.Visible = true;
            agd = new agregardocentes(flowLayoutPanel1, -1);
            ControlVistaDocente.cargarValores(agd);
            agd.labelOpcion.Text = "AGREGAR DOCENTE";
            agd.TopLevel = false;
            agd.Visible = true;
            flowLayoutPanel1.Width = this.Width;
            flowLayoutPanel1.Height = this.Height;
            flowLayoutPanel1.Controls.Add(agd);
            asignarTamanioVentanaResponsivo(agd);
        }

        private void flowLayoutPanel1_Resize(object sender, EventArgs e)
        {
            agd.Width = flowLayoutPanel1.Width-10;
            agd.Height = flowLayoutPanel1.Height-10;
        }

        private void btn_modificar_Click(object sender, EventArgs e)
        {
            ControlVistaDocente.opcion = "Modificar";
            flowLayoutPanel1.Controls.Remove(agd);
            flowLayoutPanel1.Visible = true;
            agd = new agregardocentes(flowLayoutPanel1, -1);
            agd.labelOpcion.Text = "MODIFICAR DATOS DEL DOCENTE";
            ControlVistaDocente.obtenerSeleccion();
            ControlVistaDocente.cargarValores(agd);
            agd.TopLevel = false;
            agd.Visible = true;
            flowLayoutPanel1.Width = this.Width;
            flowLayoutPanel1.Height = this.Height;
            asignarTamanioVentanaResponsivo(agd);
            flowLayoutPanel1.Controls.Add(agd);
        }

        public void asignarTamanioVentanaResponsivo(Form frm)
        {
            frm.Width = flowLayoutPanel1.Width - 10;
            frm.Height = flowLayoutPanel1.Height - 10;
        }

        private void btn_asignar_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Remove(agd);
            flowLayoutPanel1.Controls.Remove(amd);
            flowLayoutPanel1.Visible = true;
            amd = new asignarMateriasDocente(flowLayoutPanel1);
            ControlVistaMateriasDocentes.iniciarDocentes(this,amd);
            amd.TopLevel = false;
            amd.Visible = true;
            flowLayoutPanel1.Width = this.Width;
            flowLayoutPanel1.Height = this.Height;
            flowLayoutPanel1.Controls.Add(amd);
            asignarTamanioVentanaResponsivo(amd);
        }
    }
}
