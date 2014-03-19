using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.EntitiesRepository
{
    public class EquipoRepository
    {
        public List<Equipo> GetAll()
        {
            var equipos = new List<Equipo>();
            using (var ctx = new PrediccionesSQLContainer())
            {
                var response = (from e in ctx.Equipoes select e);
                equipos.AddRange(response.ToList());
            }
            return equipos;
        }

        public Equipo GetById(int idEquipo)
        {
            var equipo = new Equipo();
            using (var ctx = new PrediccionesSQLContainer())
            {
                var response = (from e in ctx.Equipoes where e.Id == idEquipo select e);
                equipo = response.ToList().FirstOrDefault();
            }
            return equipo;
        }

    }
}
