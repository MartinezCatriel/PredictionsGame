using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.EntitiesRepository
{
    public class UsuarioPrediccionRepository
    {
        public List<UsuarioPrediccion> GetByUsuarioId(int idUsuario)
        {
            var rtn = new List<UsuarioPrediccion>();
            using (var ctx = new PrediccionesSQLContainer())
            {
                var response = (from up in ctx.UsuarioPrediccions.Include("Equipo").Include("Partido").Include("Usuario") where up.IdUsuario == idUsuario select up);
                rtn.AddRange(response.ToList());
            }
            return rtn;
        }

        public void Insert(int idpartido, int idusaurio, int idequipo, int goles)
        {
            using (var ctx = new PrediccionesSQLContainer())
            {
                var newUP = new UsuarioPrediccion() { IdUsuario = idusaurio, IdPartido = idpartido, IdEquipo = idequipo };
                ctx.UsuarioPrediccions.AddObject(newUP);
                ctx.SaveChanges();
            }
        }

        public void UpdateGolesToPrediccion(int idpartido, int idusaurio, int idequipo, int goles)
        {
            using (var ctx = new PrediccionesSQLContainer())
            {
                var response = (from up in ctx.UsuarioPrediccions.Include("Equipo").Include("Partido").Include("Usuario") where up.IdUsuario == idusaurio && up.IdPartido == idpartido && up.IdEquipo == idequipo select up);
                if (response.ToList().FirstOrDefault() != null)
                {
                    var toUpdate = response.ToList().FirstOrDefault();
                    toUpdate.Goles = goles;
                    ctx.SaveChanges();
                }
            }
        }
    }
}
