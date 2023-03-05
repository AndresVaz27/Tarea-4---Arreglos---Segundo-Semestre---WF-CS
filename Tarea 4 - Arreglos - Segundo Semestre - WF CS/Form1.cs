using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
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
        string nombreArchivo;
        int cantidadContactos;
        int siguienteIndex = 0;
        Contacto[] contactos;
        Contacto nuevo = new Contacto();
        public Form1()
        {
            InitializeComponent();

            nombreArchivo = "contactos.txt";
            if (!File.Exists(nombreArchivo))
            {
                File.Create(nombreArchivo).Dispose();
            }
            else
            {
                using (StreamReader sr = File.OpenText(nombreArchivo))
                {
                    string linea;
                    string encabezados = sr.ReadLine();
                    string[] encabezadosArray = encabezados.Split(',');
                    DataGridViewColumn columna = columna = new DataGridViewTextBoxColumn();
                    foreach (string s in encabezadosArray)
                    {
                        columna.HeaderText = s;
                    }




                    while ((linea = sr.ReadLine()) != null)
                    {
                        
                        Contacto nuevo = new Contacto();
                        string[] datos = linea.Split(',');
                        if (datos.Length == encabezadosArray.Length) // Comprobar que la línea tiene el mismo número de elementos que los encabezados
                        {
                            nuevo.Nombre = datos[0];
                            nuevo.Edad = datos[1];
                            nuevo.Telefono = datos[2];
                            nuevo.Correo = datos[3];
                            tabla.Rows.Add(nuevo.Nombre, nuevo.Edad, nuevo.Telefono, nuevo.Correo);
                        }
                        else
                        {
                            MessageBox.Show("Elementos distintos.");
                        }
                    }
                    sr.Close();
                }
            }
        }
        // ESTABLECER TAMAÑO DEL ARREGLO.
        private void btnEstablecer_Click(object sender, EventArgs e)
        {
            try
            {
                cantidadContactos = int.Parse(txtArregloLenght.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Únicamente números enteros para establecer la cantidad de contactos por agregar, por favor");
            }
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
                nuevo.Correo = txtCorreo.Text;

                contactos[siguienteIndex] = nuevo;
                tabla.Rows.Add(nuevo.Nombre, nuevo.Edad, nuevo.Telefono, nuevo.Correo);
                txtNombre.Clear();
                txtFecha.Clear();
                txtTelefono.Clear();
                txtCorreo.Clear();
                siguienteIndex++;
            }

        }

        private void tabla_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete) 
            foreach (DataGridViewRow rows in tabla.SelectedRows)
            {
                tabla.Rows.RemoveAt(rows.Index);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            using (StreamWriter sw = new StreamWriter(nombreArchivo))
            {
                sw.WriteLine("Nombre,Edad,Telefono,Correo");
                foreach (DataGridViewRow fila in tabla.Rows)
                {
                    // Crear un arreglo de cadenas para almacenar los datos de la fila
                    string[] columnas = new string[tabla.Columns.Count];

                    // Recorrer todas las columnas de la fila y agregar sus valores al arreglo de cadenas
                    for (int i = 0; i < tabla.Columns.Count; i++)
                    {
                        if (fila != null && fila.Cells[i].Value != null)
                        {
                            columnas[i] = fila.Cells[i].Value.ToString();
                        }
                        else
                        {
                            columnas[i] = "";
                        }
                    }

                    // Escribir la fila en el archivo
                    if (columnas[tabla.Columns.Count-1] == "")
                    {
                        break;
                    }
                    else { 
                    sw.WriteLine(string.Join(",", columnas));
                    }
                }
                sw.Close();
            }

        }
    }
}
