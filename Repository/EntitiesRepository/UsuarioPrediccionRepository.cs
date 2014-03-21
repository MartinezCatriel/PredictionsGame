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
            using (var ctx = new PredictionSQLEntities())
            {
                var response = (from up in ctx.UsuarioPrediccion.Include("Equipo").Include("Partido").Include("Usuario") where up.IdUsuario == idUsuario select up);
                rtn.AddRange(response.ToList());
            }
            return rtn;
        }

        public List<UsuarioPrediccion> GetByUsuarioIdAndPartidoId(int idUsuario, int idPartido)
        {
            var rtn = new List<UsuarioPrediccion>();
            using (var ctx = new PredictionSQLEntities())
            {
                var response = (from up in ctx.UsuarioPrediccion.Include("Equipo").Include("Partido").Include("Usuario") where up.IdUsuario == idUsuario && up.IdPartido == idPartido select up);
                rtn.AddRange(response.ToList());
            }
            return rtn;
        }

        public void Insert(int idpartido, int idusaurio, int idequipo, int goles)
        {
            using (var ctx = new PredictionSQLEntities())
            {
                var newUP = new UsuarioPrediccion() { IdUsuario = idusaurio, IdPartido = idpartido, IdEquipo = idequipo };
                ctx.UsuarioPrediccion.AddObject(newUP);
                ctx.SaveChanges();
            }
        }

        public void UpdateGolesToPrediccion(int idpartido, int idusaurio, int idequipo, int goles)
        {
            using (var ctx = new PredictionSQLEntities())
            {
                var response = (from up in ctx.UsuarioPrediccion.Include("Equipo").Include("Partido").Include("Usuario") where up.IdUsuario == idusaurio && up.IdPartido == idpartido && up.IdEquipo == idequipo select up);
                if (response.ToList().FirstOrDefault() != null)
                {
                    var toUpdate = response.ToList().FirstOrDefault();
                    toUpdate.Goles = goles;

                }
                else
                {
                    var newPred = new Repository.UsuarioPrediccion();
                    newPred.Goles = goles;
                    newPred.IdEquipo = idequipo;
                    newPred.IdPartido = idpartido;
                    newPred.IdUsuario = idusaurio;
                    ctx.UsuarioPrediccion.AddObject(newPred);
                }
                ctx.SaveChanges();
            }
        }
    }
}
