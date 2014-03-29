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
                    toUpdate.Predecido = 1;

                }
                else
                {
                    var newPred = new Repository.UsuarioPrediccion();
                    newPred.Goles = goles;
                    newPred.IdEquipo = idequipo;
                    newPred.IdPartido = idpartido;
                    newPred.IdUsuario = idusaurio;
                    newPred.Predecido = 0;
                    ctx.UsuarioPrediccion.AddObject(newPred);
                }
                ctx.SaveChanges();
            }
        }

        private void UpdateUsuarioPuntaje(int idusuario)
        {
            //obtener los partidos predecidos del usuario(predecido = 1)
            //obtener los resultados reales(con goles diferentes a -1) comparar ganador del partido real con el del partido predecido
            //sumar puntos de ser necesario
            //actualizar db+





            //como saber si el partido ya tiene los resultados finales

            using (var ctx = new PredictionSQLEntities())
            {
                var usuarioPredicciones = (from up in ctx.UsuarioPrediccion where up.Predecido == 1 && up.IdUsuario == idusuario select up);


            }
        }
    }
}
