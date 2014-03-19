using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.EntitiesRepository
{
    public class UsuarioRepository
    {
        public List<Usuario> GetAll()
        {
            var rtn = new List<Usuario>();
            using (var ctx = new PrediccionesSQLContainer())
            {
                var response = (from u in ctx.Usuarios select u);
                rtn = response.ToList();
            }
            return rtn;
        }

        public Usuario Insert(string email, string procedencia, string token)
        {
            Usuario newUsu = null;
            using (var ctx = new PrediccionesSQLContainer())
            {
                newUsu = new Usuario() { Email = email, Procedencia = procedencia, Token = token };
                ctx.Usuarios.AddObject(newUsu);

                ctx.SaveChanges();
            }
            return newUsu;
        }

        public Usuario GetById(int id)
        {
            Usuario usuario = null;
            using (var ctx = new PrediccionesSQLContainer())
            {
                var response = (from u in ctx.Usuarios where u.Id == id select u);
                if (response.ToList().FirstOrDefault() != null)
                {
                    usuario = response.ToList().FirstOrDefault();
                }
            }
            return usuario;
        }
    }
}
