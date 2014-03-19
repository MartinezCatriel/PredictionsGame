using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.EntitiesRepository
{
    public class PartidoEquipoRepository
    {
        public void Insert(int idpartido, int idequipo, int goles)
        {
            using (var ctx = new PrediccionesSQLContainer())
            {
                var partidoEquipo = new PartidoEquipo() { IdEquipo = idequipo, IdPartido = idpartido, Goles = goles };
                ctx.PartidoEquipoes.AddObject(partidoEquipo);
                ctx.SaveChanges();
            }

        }

        public void Update(int idPartido, int oldIdEquipo, int idEquipo, int goles)
        {
            using (var ctx = new PrediccionesSQLContainer())
            {
                var response =
                    (from pe in ctx.PartidoEquipoes
                     where pe.IdPartido == idPartido && pe.IdEquipo == oldIdEquipo
                     select pe);
                var partidoEquipo = response.ToList().FirstOrDefault();

                if (partidoEquipo != null)
                {
                    partidoEquipo.IdEquipo = idEquipo;
                    partidoEquipo.Goles = goles;
                    ctx.SaveChanges();
                }
            }
        }
    }
}
