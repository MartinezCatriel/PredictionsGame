using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Repositories;

namespace Repository.EntitiesRepository
{
    public class PartidoRepository
    {
        private const int DefaultIdPartido = 0;

        public PartidoRepository()
        {

        }

        public List<Partido> GetAll()
        {
            var all = new List<Partido>();
            using (var ctx = new PrediccionesSQLContainer())
            {
                var partidos = (from a in ctx.Partidoes select a);
                all.AddRange(partidos.ToList());
            }
            return all;
        }

        public List<Partido> GetAllByEquipoId(int idEquipo)
        {
            var all = new List<Partido>();
            using (var ctx = new PrediccionesSQLContainer())
            {
                var pbes = (from s in ctx.Partidoes.Include("PartidoEquipos").Include("PartidoEquipos.Equipo")
                            join sa in ctx.PartidoEquipoes on s.Id equals sa.IdPartido
                            where sa.IdEquipo == idEquipo
                            select s);
                all.AddRange(pbes.ToList());
            }

            return all;
        }

        public List<Partido> GetById(int idPartido)
        {
            var all = new List<Partido>();
            using (var ctx = new PrediccionesSQLContainer())
            {
                var pbes = (from s in ctx.Partidoes.Include("PartidoEquipos").Include("PartidoEquipos.Equipo")
                            where s.Id == idPartido
                            select s);
                all.AddRange(pbes.ToList());
            }

            return all;
        }

        public void Update(int idPartido, DateTime fecha, string geo, int ponderado)
        {
            if (idPartido != DefaultIdPartido)
            {
                using (var ctx = new PrediccionesSQLContainer())
                {
                    var toUpdate = (from p
                                    in ctx.Partidoes
                                    where p.Id == idPartido
                                    select p);
                    var partido = toUpdate.ToList().FirstOrDefault();
                    if (partido != null)
                    {
                        partido.Fecha = fecha;
                        partido.Geolocalizacion = geo;
                        partido.Ponderado = ponderado;
                        ctx.SaveChanges();
                    }

                }
            }
        }
    }
}
