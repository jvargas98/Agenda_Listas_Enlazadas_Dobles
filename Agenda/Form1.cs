using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Agenda
{
    public partial class Form1 : Form
    {

        Agenda agenda = new Agenda();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            int telefono = int.Parse(txtTelefono.Text);
            string nombre = txtNombre.Text;
            string apellidoPaterno = txtApellidoPaterno.Text;
            string apellidoMaterno = txtApellidoMaterno.Text;
            int edad = int.Parse(txtEdad.Text);
            string correo = txtCorreo.Text;

            Contacto contacto = new Contacto(telefono,nombre,apellidoPaterno,apellidoMaterno,edad,correo);
            agenda.Agregar(contacto);

            txtTelefono.Clear();
            txtNombre.Clear();
            txtApellidoPaterno.Clear();
            txtApellidoMaterno.Clear();
            txtEdad.Clear();
            txtCorreo.Clear();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            txtListado.Text = agenda.ToString();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Contacto contacto;
            int telefono = int.Parse(txtTelefono.Text);
            contacto = agenda.Buscar(telefono);
            if (contacto != null)
            {
                txtTelefono.Text = contacto.Telefono.ToString();
                txtNombre.Text = contacto.Nombre;
                txtApellidoPaterno.Text = contacto.ApellidoPaterno;
                txtApellidoMaterno.Text = contacto.ApellidoPaterno;
                txtEdad.Text = contacto.Edad.ToString();
                txtCorreo.Text = contacto.Correo;
            }
            else
            {
                MessageBox.Show("Telefono no registrado");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int telefono = int.Parse(txtTelefono.Text);

            agenda.Eliminar(telefono);
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            int posicion = int.Parse(txtPosicion.Text);
            int telefono = int.Parse(txtTelefono.Text);
            string nombre = txtNombre.Text;
            string apellidoPaterno = txtApellidoPaterno.Text;
            string apellidoMaterno = txtApellidoMaterno.Text;
            int edad = int.Parse(txtEdad.Text);
            string correo = txtCorreo.Text;

            Contacto contacto = new Contacto(telefono, nombre, apellidoPaterno, apellidoMaterno, edad, correo);

           // agenda.Insertar(posicion, contacto);

            txtTelefono.Clear();
            txtNombre.Clear();
            txtApellidoPaterno.Clear();
            txtApellidoMaterno.Clear();
            txtEdad.Clear();
            txtCorreo.Clear();
         
        }

        private void btnEliminarPrimero_Click(object sender, EventArgs e)
        {
            agenda.EliminarPrimero();
        }

        private void btnEliminarUltimo_Click(object sender, EventArgs e)
        {
            agenda.EliminarUltimo();
        }

        private void btnReporteInverso_Click(object sender, EventArgs e)
        {
            txtListado.Text = agenda.ReporteInverso();
        }

        private void btnInvertirListas_Click(object sender, EventArgs e)
        {
            agenda.InvertirLista();
        }
    }
}
