using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda
{
    class Agenda
    {
        Contacto inicio;
        Contacto ultimo;
        private int totalContactos = 0;
        public Agenda()
        {

        }
        public void Agregar(Contacto contacto)
        {        
            if (totalContactos < 15) // Mientras haya menos de 15 contactos 
            {
                if (inicio == null) // Si no hay un contacto primero lo asignamos
                {
                    inicio = contacto; // El contacto lo asignamos al primero
                    ultimo = inicio; // El ultimo es el primero
                    totalContactos++;
                }
                else
                {/*
                    Contacto aux = inicio; // El primer contacto se lo asignamos al aux
                    while (aux.Siguente != null) // Mientras el siguiente de aux del contaco no sea nulo
                        aux = aux.Siguente;
                    aux.Siguente = contacto; // Entonces es nulo, el contacto que su siguiente es nulo, su siguiente va ser el nuevo
                    */
                    /*
                    ultimo.Siguente = contacto; // El siguiente del ultimo va ser el nuevo contacto
                    ultimo = contacto; // El contacto nuevo va ser el ultimo,
                    totalContactos++;
                    */
                    Contacto aux = inicio, anterior = null;
                    while (aux != null && contacto.Telefono > aux.Telefono)
                    {
                        anterior = aux;
                        aux = aux.Siguente;
                    }
                    if(aux == null) { // Fue mayor a todos se va al ultimo
                        ultimo.Siguente = contacto;
                        ultimo = contacto;
                    }
                    else if(anterior != null) // Estuvo antes del ultimo
                    {
                        contacto.Siguente = anterior.Siguente;
                        contacto.Anterior = anterior;
                        anterior.Siguente = contacto;
                        contacto.Siguente.Anterior = contacto;
                    }
                    else
                    {
                        contacto.Siguente = inicio;
                        inicio.Anterior = contacto;
                        inicio = contacto;
                    }
                    totalContactos++;
                }
            }
        }

        public Contacto Buscar(int telefono)
        {
            Contacto aux;
            aux = inicio;
            while (aux != null && aux.Telefono != telefono && aux.Telefono < telefono) // Mientras no sea null el contacto y sea diferente el telefono al buscado pasaremos de siguiente en siguiente
            {                                               // En caso de encontrar el numero, el ultimo contacto en aux sera el contacto buscado
                aux = aux.Siguente;
            }
            if (aux != null && aux.Telefono <= telefono) // Si lo encuentra aux, no sera null, entonces regresa el contacto buscado
                return aux;
            else
                return null;
        }

        public void Eliminar(int telefono)
        {
            Contacto aux;
            Contacto anterior = null;
            aux = inicio;
            while (aux != null && aux.Telefono != telefono && aux.Telefono < telefono)  // Mientras no sea nulo y no sea igual el telefono iremos pasando siguiente por siguiente
            {
                anterior = aux; // Guardamos el valor como anterior, para que ahora su siguiente sea, el siguiente del contacto eliminado
                aux = aux.Siguente; // Pasamos al siguiente contacto para el siguiente ciclo
            }
            if (aux != null) // Si el valor se encontro no sera aux nulo, entonces entra
            {
                if (inicio == aux) // Si el contacto es el primero
                {
                    inicio = aux.Siguente; // El siguiente del primero ahora sera el primero
                }
                else
                {
                    anterior.Siguente = aux.Siguente; // ahora el siguiente del valor a eliminar, sera el siguiente del contacto anterior
                    aux.Siguente.Anterior = anterior;
                }
                totalContactos--; 
            }
        }
        public void Insertar(int posicion, Contacto contacto)
        {
            Contacto aux;
            Contacto anterior = null;
            aux = inicio;
            
            if (posicion == 0) // Si la posicion es 0
            {
                inicio = contacto; // El inicio ahora sera el nuevo
                contacto.Siguente = aux; // El siguiente del nuevo sera el aux para enlazar con los siguientes, en este caso el siguiente sera el que era  antes el primero
                totalContactos++;
            }
            else
            {
                for (int contador = 0; contador < posicion; contador++)
                {
                    anterior = aux; // Guardamos el anterior
                    aux = aux.Siguente; // El siguiente de aux ahora sera aux, similando a recorrerse al siguiente
                }

                anterior.Siguente = contacto; // El siguiente del anterior sera el nuevo a insertar
                contacto.Siguente = aux; // El siguiente del nuevo sera el aux, que antes era el siguiente de anterior
                totalContactos++;
            }
        }
        public override string ToString()
        {
            string cadena = "";
            Contacto aux;
            aux = inicio;
            while(aux != null) // Mientras no sea nullo iremos pasando al siguiente
            {
                cadena += aux.ToString();
                aux = aux.Siguente; // Ahora el siguiente de aux sera el nuevo aux para el siguiente ciclo 
            }
            return cadena;
        } 

        public void EliminarUltimo()
        {
            Contacto aux;
            aux = inicio;
            while(aux.Siguente.Siguente != null)
            {
                aux = aux.Siguente;
            }
            ultimo = aux;
            aux.Siguente = null;
            totalContactos--;
        }

        public void EliminarPrimero()
        {
            Contacto aux;
            aux = inicio.Siguente;
            inicio = aux;
            totalContactos--;
        }

        public string ReporteInverso()
        {
            string cadena ="";
            Contacto aux, limite, anterior = null;
            limite = ultimo;
            aux = inicio;
            for (int i = 0; i < totalContactos; i++)
            {
                aux = inicio;
                while (aux != limite)
                {
                    anterior = aux;
                    aux = aux.Siguente;
                }
                limite = anterior;
                cadena += aux;
            }
            return cadena;
        }

        public void InvertirLista()
        {
            Contacto aux, limite, anterior = null;
            limite = ultimo;
            aux = inicio;
            for (int i = 0; i < totalContactos; i++)
            {
                aux = inicio;
                while (aux != limite)
                {
                    anterior = aux;
                    aux = aux.Siguente;
                }
                limite = anterior;
                aux.Siguente = anterior;
                anterior = null;
            }
            aux = inicio;
            inicio = ultimo;
            ultimo = aux;
        }
    }
}
