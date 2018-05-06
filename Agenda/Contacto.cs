using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda
{
    class Contacto
    {
        private int _telefono;
        private string _nombre;
        private string _apellidoPaterno;
        private string _apellidoMaterno;
        private int _edad;
        private string _correo;
        Contacto _siguiente = null;
        Contacto _anterior = null;

        public int Telefono{ get { return _telefono; } }
        public string Nombre { get { return _nombre; } }
        public string ApellidoPaterno { get { return _apellidoPaterno; } }
        public string ApellidoMaterno { get { return _apellidoMaterno; } }
        public int Edad { get { return _edad; } }
        public string Correo { get { return _correo; } }
        public Contacto Siguente { get { return _siguiente; } set { _siguiente = value; }}
        public Contacto Anterior { get { return _anterior; } set { _anterior = value; }}

        public Contacto(int telefono, string nombre, string apellidoPaterno, string apellidoMaterno, int edad, string correo)
        {
            _telefono = telefono;
            _nombre = nombre;
            _apellidoPaterno = apellidoPaterno;
            _apellidoMaterno = apellidoMaterno;
            _edad = edad;
            _correo = correo;
        }

        public override string ToString()
        {
            string cadena = "";

            cadena = _telefono + " "+ _nombre + " " +  _apellidoPaterno + " " + _apellidoMaterno + " " + _edad + " " + _correo + Environment.NewLine;

            return cadena;
        }

    }
}
