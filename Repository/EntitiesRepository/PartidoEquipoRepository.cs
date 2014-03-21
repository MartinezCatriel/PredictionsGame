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
            using (var ctx = new PredictionSQLEntities())
            {
                var partidoEquipo = new PartidoEquipo() { IdEquipo = idequipo, IdPartido = idpartido, Goles = goles };
                ctx.PartidoEquipo.AddObject(partidoEquipo);
                ctx.SaveChanges();
            }

        }

        public void Update(int idPartido, int oldIdEquipo, int idEquipo, int goles)
        {
            using (var ctx = new PredictionSQLEntities())
            {
                var response =
                    (from pe in ctx.PartidoEquipo
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
