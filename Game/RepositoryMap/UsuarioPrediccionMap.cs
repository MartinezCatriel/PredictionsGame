using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Prediccion;
using UsuarioPrediccionMod = Prediccion.UsuarioPrediccion;
using UsuarioPrediccionSql = Repository.UsuarioPrediccion;
namespace Game.RepositoryMap
{
    public class UsuarioPrediccionMap
    {
        public List<UsuarioPrediccionMod> MapUsuarioPrediccion(List<UsuarioPrediccionSql> toMap)
        {

            var agrupadoPorPartido = toMap.GroupBy((item) => { return item.IdPartido; });
            var listadepredicciones = new List<UsuarioPrediccionMod>(agrupadoPorPartido.Count());


            Dictionary<Equipo, int> golesporequipo = null;
            var idPartido = 0;
            var idUsuario = 0;
            var predecido = 0;
            UsuarioPrediccionMod usuarioPrediccion = null;
            foreach (var grupo in agrupadoPorPartido)
            {
                golesporequipo = new Dictionary<Equipo, int>(grupo.Count());
                grupo.ToList().ForEach((ups) => golesporequipo.Add(Equipo.Create(ups.Equipo.Id, ups.Equipo.Nombre), ups.Goles));
                idPartido = 0;
                idUsuario = 0;
                predecido = 0;
                if (grupo.FirstOrDefault() != null)
                {
                    idUsuario = grupo.FirstOrDefault().IdUsuario;
                    idPartido = grupo.FirstOrDefault().IdPartido;
                    predecido = grupo.FirstOrDefault().Predecido;
                }


                usuarioPrediccion = UsuarioPrediccionMod.Create(idPartido,
                                                                    idUsuario,
                                                                    golesporequipo, predecido);
                listadepredicciones.Add(usuarioPrediccion);
            }




            return listadepredicciones;
        }
    }
}