using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prediccion
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Procedencia { get; set; }


        private Usuario(int id, string nombre, string procedencia)
        {
            Id = id;
            Nombre = nombre;
            Procedencia = procedencia;
        }

        public static Usuario Create(int id, string nombre, string procedencia)
        {
            return new Usuario(id, nombre, procedencia);
        }
    }
}
