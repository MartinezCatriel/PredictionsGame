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

        public int Predecido { get; set; }
        /// <summary>
        /// key=equipo
        /// value=goles
        /// </summary>
        public Dictionary<int, int> GolesPorEquipo { get; set; }

        public int Ganador
        {
            get
            {
                var ganador = (from a in GolesPorEquipo orderby a.Value descending select a).FirstOrDefault();
                if (ganador.Value == 0)//no hay ganador
                    return ganador.Value;
                return ganador.Key;
            }
        }

        private UsuarioPrediccion(int idPartido, int idUsuario, Dictionary<int, int> golesPorEquipo)
        {
            IdUsuario = idUsuario;
            IdPartido = idPartido;

            if (golesPorEquipo == null
                ||
                golesPorEquipo.Count == 0)
            {
                throw new Exception("La cantidad de equipos no debe ser nula");
            }



            GolesPorEquipo = golesPorEquipo;
        }

        public static UsuarioPrediccion Create(int idPartido, int idUsuario, Dictionary<int, int> golesPorEquipo)
        {
            return new UsuarioPrediccion(idPartido, idUsuario, golesPorEquipo);
        }


    }
}
