using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.EntitiesRepository
{
    public class PartidoEquipo
    {
        public void Update(int idPartido, int oldIdEquipo, int idEquipo, int goles)
        {
            using (var ctx = new PrediccionesSQLContainer())
            {
                var response =
                    (from pe in ctx.PartidoEquipoes
                     where pe.IdPartido == idPartido && pe.IdEquipo == oldIdEquipo
                     select pe);
                var equipo = response.ToList().FirstOrDefault();

                if (equipo != null)
                {
                    equipo.IdEquipo = idEquipo;
                    equipo.Goles = goles;
                    ctx.SaveChanges();
                }
            }
        }
    }
}
