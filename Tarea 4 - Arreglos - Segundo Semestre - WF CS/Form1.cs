using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tarea_2___Segundo_Semestre;

namespace Tarea_4___Arreglos___Segundo_Semestre___WF_CS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void lblNombre_Click(object sender, EventArgs e)
        {}



        int cantidadContactos;
        int siguienteIndex = 0;
        Contacto[] contactos;

        // ESTABLECER TAMAÑO DEL ARREGLO.
        private void btnEstablecer_Click(object sender, EventArgs e)
        {
            cantidadContactos = int.Parse(txtArregloLenght.Text);
            contactos = new Contacto[cantidadContactos];
        }

        // AGREGAR UN NUEVO CONTACTO.
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (contactos == null) { MessageBox.Show("Establezca el número de contactos por agregar.");}
            else if (siguienteIndex >= contactos.Length)
            {
                MessageBox.Show("La cantidad de contactos por agregar se completó.");
               
            }
            else
            {
                Contacto nuevo = new Contacto();
                nuevo.Nombre = txtNombre.Text;
                nuevo.Telefono = txtTelefono.Text;
                DateTime fechaNacimiento;
                if (DateTime.TryParseExact(txtFecha.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out fechaNacimiento))
                {
                    nuevo.FechaNacimiento = fechaNacimiento;
                }
                else
                {
                    MessageBox.Show("La fecha de nacimiento debe tener el formato dd/MM/yyyy");
                    return;
                }
                nuevo.Correo= txtCorreo.Text;

                contactos[siguienteIndex] = nuevo;
                lbContactos.Items.Add(nuevo.ToString());
                siguienteIndex++;

            }

        }

        private void label1_Click(object sender, EventArgs e)
        {}
    }
}
