using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prediccion
{
    public class UsuarioPrediccion
    {
        public int IdPartido { get; set; }
        public int IdUsuario { get; set; }
        public Dictionary<int, int> GolesPorEquipo { get; set; }

        private UsuarioPrediccion(int idPartido, int idUsuario, Dictionary<int, int> golesPorEquipo)
        {
            IdUsuario = idUsuario;
            IdPartido = idPartido;
            GolesPorEquipo = golesPorEquipo;
        }

        public static UsuarioPrediccion Create(int idPartido, int idUsuario, Dictionary<int, int> golesPorEquipo)
        {
            return new UsuarioPrediccion(idPartido, idUsuario, golesPorEquipo);
        }
    }
}
