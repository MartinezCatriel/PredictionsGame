using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RepoUsu = Repository.Usuario;
using ModelUsu = Prediccion.Usuario;
namespace Game.RepositoryMapper
{
    public class UsuarioMapper
    {
        public ModelUsu MapperUsuario(RepoUsu toMap)
        {
            return ModelUsu.Create(toMap.Id, toMap.Procedencia, toMap.Email, toMap.Token);
        }

        public List<ModelUsu> MapperUsuarios(List<RepoUsu> toMap)
        {
            return toMap.ConvertAll<ModelUsu>((item) => { return MapperUsuario(item); });
        }
    }
}