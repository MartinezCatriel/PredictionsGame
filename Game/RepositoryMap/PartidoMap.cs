using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PartidoMod = Prediccion.Partido;
using PartidoSql = Repository.Partido;

namespace Game.RepositoryMap
{
    public class PartidoMap
    {
        public PartidoMod MapPartido(PartidoSql toMap)
        {
            var equipos = new List<Prediccion.Equipo>();
            if (toMap.PartidoEquipoes.IsLoaded)
            {
                var equipoMap = new EquipoMap();

                foreach (var item in toMap.PartidoEquipoes)
                {
                    equipos.Add(equipoMap.MapEquipo(item.Equipo));
                }
            }
            return PartidoMod.Create(toMap.Id, equipos, toMap.Fecha, toMap.Geolocalizacion, toMap.Ponderado);
        }

        public List<PartidoMod> MapPartidos(List<PartidoSql> toMap)
        {
            return toMap.ConvertAll<PartidoMod>((item) => { return MapPartido(item); });
        }
    }
}