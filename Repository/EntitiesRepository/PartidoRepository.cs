using System;
using System.Collections.Generic;
using System.Data;
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
            using (var ctx = new PredictionSQLEntities())
            {
                var partidos = (from a in ctx.Partido.Include("PartidoEquipo").Include("PartidoEquipo.Equipo") select a);
                all.AddRange(partidos.ToList());
            }
            return all;
        }

        public List<Partido> GetAllByEquipoId(int idEquipo)
        {
            var all = new List<Partido>();
            using (var ctx = new PredictionSQLEntities())
            {
                var pbes = (from s in ctx.Partido.Include("PartidoEquipo").Include("PartidoEquipo.Equipo")
                            join sa in ctx.PartidoEquipo on s.Id equals sa.IdPartido
                            where sa.IdEquipo == idEquipo
                            select s);
                all.AddRange(pbes.ToList());
            }

            return all;
        }

        public Partido GetById(int idPartido)
        {
            var par = new Partido();
            using (var ctx = new PredictionSQLEntities())
            {
                var pbes = (from s in ctx.Partido.Include("PartidoEquipo").Include("PartidoEquipo.Equipo")
                            where s.Id == idPartido
                            select s);
                par = pbes.ToList().FirstOrDefault();
            }

            return par;
        }

        public void UpdateEquiposAndGolesFromPartido(int idPartido, Dictionary<int, int> equiposGoles)
        {
            if (idPartido != DefaultIdPartido)
            {
                using (var ctx = new PredictionSQLEntities())
                {
                    var toUpdate = (from p
                                    in ctx.PartidoEquipo
                                    where p.IdPartido == idPartido
                                    select p);
                    var partidos = toUpdate.ToList();


                    partidos.ForEach((partido) => { ctx.PartidoEquipo.DeleteObject(partido); });
                    if (partidos.Exists((partido) => { return partido.EntityState == EntityState.Deleted; }))
                    {
                        ctx.SaveChanges();
                    }


                    foreach (var golesEquipo in equiposGoles)
                    {
                        ctx.PartidoEquipo.AddObject(PartidoEquipo.CreatePartidoEquipo(idPartido, golesEquipo.Key, golesEquipo.Value));
                    }

                    if (partidos.Count > 0)
                    {
                        ctx.SaveChanges();
                    }
                }
            }
        }

        public Partido Insert(DateTime fecha
            , string geo
            , int ponderado
            , Dictionary<int, int> equiposGoles)
        {
            var rtnPartido = new Partido();
            using (var ctx = new PredictionSQLEntities())
            {
                var newPartido = new Partido();
                newPartido.Fecha = fecha;
                newPartido.Geolocalizacion = geo;
                newPartido.Ponderado = ponderado;
                ctx.Partido.AddObject(newPartido);

                PartidoEquipo newPartidoEquipo;
                foreach (var item in equiposGoles)
                {
                    newPartidoEquipo = new PartidoEquipo();
                    newPartidoEquipo.IdEquipo = item.Key;
                    newPartidoEquipo.IdPartido = newPartido.Id;
                    newPartidoEquipo.Goles = item.Value;

                    ctx.PartidoEquipo.AddObject(newPartidoEquipo);
                }
                ctx.SaveChanges();

                rtnPartido = (from p in ctx.Partido.Include("PartidoEquipo").Include("PartidoEquipo.Equipo") where p.Id == newPartido.Id select p).ToList().FirstOrDefault();
            }
            return rtnPartido;
        }
    }
}
