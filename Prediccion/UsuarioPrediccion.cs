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

        public List<Equipo> Equipos { get; set; }

        public Equipo Ganador
        {
            get
            {
                var ganador = (from a in GolesPorEquipo orderby a.Value descending select a).FirstOrDefault();
                if (ganador.Value == 0)//no hay ganador
                    return null;
                return Equipos.Find((item) => { return item.Id == ganador.Key; });
            }
        }

        private UsuarioPrediccion(int idPartido, int idUsuario, Dictionary<Equipo, int> golesPorEquipo, int predecido)
        {
            IdUsuario = idUsuario;
            IdPartido = idPartido;

            if (golesPorEquipo == null
                ||
                golesPorEquipo.Count == 0)
            {
                throw new Exception("La cantidad de equipos no debe ser nula");
            }


            GolesPorEquipo = new Dictionary<int, int>(golesPorEquipo.Count);
            Equipos = new List<Equipo>(golesPorEquipo.Count);
            foreach (var equipo in golesPorEquipo)
            {
                GolesPorEquipo.Add(equipo.Key.Id, equipo.Value);
                Equipos.Add(equipo.Key);
            }

            Predecido = predecido;
        }

        public static UsuarioPrediccion Create(int idPartido, int idUsuario, Dictionary<Equipo, int> golesPorEquipo, int predecido)
        {
            return new UsuarioPrediccion(idPartido, idUsuario, golesPorEquipo, predecido);
        }
    }
}
