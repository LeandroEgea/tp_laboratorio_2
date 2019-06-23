using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace Formulario
{
    public partial class FrmPpal : Form
    {
        Correo correo;
        public FrmPpal()
        {
            InitializeComponent();
        }

        private void ActualizarEstados()
        {
            throw new NotImplementedException(); //TODO
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Paquete paquete = new Paquete(txtDireccion.Text, mtxtTrackingID.Text);
            paquete.InformaEstado += paq_InformaEstado;

            //TODO

        }

        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException(); //TODO
        }

        private void FrmPpal_FormClosing(object sender, FormClosingEventArgs e)
        {
            throw new NotImplementedException(); //TODO
        }

        private void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            throw new NotImplementedException(); //TODO
        }

        private void mostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException(); //TODO
        }

        private void paq_InformaEstado(object sender, EventArgs e)
        {
            throw new NotImplementedException(); //TODO
        }
    }
}
