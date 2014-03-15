using Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prediccion
{
    public class Partido
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public Equipo Ganador
        {
            get
            {
                //obtengo el id del equipo con la mayor cantidad de goles
                var item = (from pair in GolesPorEquipo
                            orderby pair.Value descending
                            select pair).FirstOrDefault();
                if (!Validations.Validar(Validations.ValidationTypes.GreatherThanZero, item.Value))
                {
                    return null;
                }
                return Equipos.Find((equi) => { return equi.Id == item.Key; });

            }
        }
        public string Geolocalizacion { get; set; }
        public int Ponderado { get; set; }
        public Dictionary<int, int> GolesPorEquipo { get; private set; }
        public List<Equipo> Equipos { get; set; }

        private Partido(int id, IEnumerable<Equipo> equipos, DateTime fecha, string geo, int ponderado)
        {
            Id = id;
            Equipos = new List<Equipo>();
            Equipos.AddRange(equipos);
            if (!Validations.Validar(Validations.ValidationTypes.EqualTo, Equipos.Count, 2))
            {
                throw new Exception(Mensajes.LaCantidadDeEquiposDebeSer2);
            }
            Fecha = fecha;
            Geolocalizacion = geo;
            GolesPorEquipo = new Dictionary<int, int>();
            Ponderado = ponderado;

        }

        public static Partido Create(int id, IEnumerable<Equipo> equipos, DateTime fecha, string geo, int ponderado)
        {
            return new Partido(id, equipos, fecha, geo, ponderado);
        }

        public void SetGolesPorEquipo(int equipo, int goles)
        {
            if (Equipos.Find(equi => equi.Id == equipo) == null)
            {
                throw new Exception("El id del equipo debe ser uno de los participantes del partido");
            }
            GolesPorEquipo[equipo] = goles;
        }

        public static string ToString()
        {
            return "Partido";
        }
    }
}
