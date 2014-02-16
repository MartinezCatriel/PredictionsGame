using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prediccion
{
    public class Partido
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public Equipo Ganador { get { return Equipo.Create(1, "nombre"); } }
        public Geolocalizacion geo { get; set; }
        public Dictionary<int, int> GolesPorEquipo { get; private set; }
        public List<Equipo> Equipos { get; set; }

        private Partido(int id, List<Equipo> equipos, DateTime fecha)
        {

        }

        public static Partido Create()
        {
            return new Partido();
        }
    }
}
