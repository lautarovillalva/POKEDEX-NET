using System;
using System.Collections.Generic;
using System.Text;

namespace DOMINIO
{
    public class Elemento
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public Elemento(int id, string nombre)
        {
            Id = id;
            Nombre = nombre;
        }
        public Elemento(string nombre)
        {
            Nombre = nombre;
        }
        public override string ToString()
        {
            return Nombre;
        }
    }
}
