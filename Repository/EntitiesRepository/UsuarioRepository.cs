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
            using (var ctx = new PredictionSQLEntities())
            {
                var response = (from u in ctx.Usuario select u);
                rtn = response.ToList();
            }
            return rtn;
        }

        public Usuario Insert(string email, string procedencia, string token)
        {
            Usuario newUsu = null;
            using (var ctx = new PredictionSQLEntities())
            {
                var response = (from u in ctx.Usuario where u.Email == email select u);
                var usu = response.ToList().FirstOrDefault();
                if (usu == null)
                {
                    newUsu = new Usuario() { Email = email, Procedencia = procedencia, Token = token };
                    ctx.Usuario.AddObject(newUsu);
                }
                else
                {
                    usu.Token = token;
                    usu.Procedencia = procedencia;
                    newUsu = usu;
                }
                ctx.SaveChanges();
            }
            return newUsu;
        }

        public Usuario UploadTokenById(int id, string token)
        {
            Usuario newUsu = null;
            using (var ctx = new PredictionSQLEntities())
            {
                var response = (from u in ctx.Usuario where u.Id == id select u);
                var usu = response.ToList().FirstOrDefault();
                if (usu != null)
                {
                    usu.Token = token;
                    newUsu = usu;
                    ctx.SaveChanges();
                }

            }
            return newUsu;
        }

        public Usuario GetById(int id)
        {
            Usuario usuario = null;
            using (var ctx = new PredictionSQLEntities())
            {
                var response = (from u in ctx.Usuario where u.Id == id select u);
                if (response.ToList().FirstOrDefault() != null)
                {
                    usuario = response.ToList().FirstOrDefault();
                }
            }
            return usuario;
        }
    }
}
