using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea_2___Segundo_Semestre
{
    internal class Persona
    {
        protected String nombre;
        protected DateTime? fechaNacimiento;
        public string edad;

        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public DateTime? FechaNacimiento
        {
            get { return fechaNacimiento; }
            set { fechaNacimiento = value; }
        }
        string edad_;
        public string Edad
        {
            set { edad_ = value; }
            get
            {
                if (fechaNacimiento.HasValue)
                {
                    int edad = DateTime.Now.Year - fechaNacimiento.Value.Year;
                    if (fechaNacimiento.Value.Month > DateTime.Now.Month ||
                        (fechaNacimiento.Value.Month == DateTime.Now.Month && fechaNacimiento.Value.Day > DateTime.Now.Day))
                    {
                        edad--;
                    }
                    return edad.ToString();
                }
                else
                {
                    return edad_;
                }
            }
            

        }
        public Persona()
        {
            nombre = String.Empty;
            fechaNacimiento = null;//DateTime.MinValue;
        }
        public Persona(String nombre, DateTime? fechaNacimiento)
        {
            this.nombre = nombre;
            this.fechaNacimiento = fechaNacimiento;
        }

        public override string ToString()
        {
            return "NOMBRE: " + nombre.ToUpper() + " " + "---" + " EDAD: " + Edad;
        }
    }
}
