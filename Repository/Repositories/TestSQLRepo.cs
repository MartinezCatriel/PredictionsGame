using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class TestSQLRepo
    {
        public TestSQLRepo()
        {
            //equipo
            using (var ctx = new PrediccionesSQLContainer())
            {
                var repo = new SQLRepository<Equipo>(ctx);
                var newequipo = new Equipo();
                newequipo.Nombre = "Brasil";
                repo.Insert(newequipo);
                var equipoById = repo.SearchFor(equipo => (equipo.Id == 1));
                equipoById.ToList();



                newequipo = new Equipo();
                newequipo.Nombre = "Croacia";
                repo.Insert(newequipo);
                ctx.SaveChanges(SaveOptions.DetectChangesBeforeSave);
            }

            //partido
            /*using (var ctx = new PrediccionesSQLContainer())
            {
                var repo = new SQLRepository<Partido>(ctx);
                var newpartido = new Partido();
                newpartido.Fecha = Convert.ToDateTime("2014-06-12 17:00");
                newpartido.Geolocalizacion = "San Pablo";
                repo.Insert(newpartido);
                ctx.SaveChanges(SaveOptions.DetectChangesBeforeSave);
            }

            //partidoequipo
            using (var ctx = new PrediccionesSQLContainer())
            {
                var repo = new SQLRepository<PartidoEquipo>(ctx);
                var newpartidoequipo = new PartidoEquipo();
                newpartidoequipo.IdPartido = 1;
                newpartidoequipo.IdEquipo = 1;
                repo.Insert(newpartidoequipo);
                ctx.SaveChanges(SaveOptions.DetectChangesBeforeSave);
            }

            //usuario
            using (var ctx = new PrediccionesSQLContainer())
            {
                var repo = new SQLRepository<Usuario>(ctx);
                var newequipo = new Usuario();
                newequipo.Nombre = "NewTeam";
                repo.Insert(newequipo);
                ctx.SaveChanges(SaveOptions.DetectChangesBeforeSave);
            }

            //usuarioprediccion
            using (var ctx = new PrediccionesSQLContainer())
            {
                var repo = new SQLRepository<UsuarioPrediccion>(ctx);
                var newequipo = new UsuarioPrediccion();
                newequipo.Nombre = "NewTeam";
                repo.Insert(newequipo);
                ctx.SaveChanges(SaveOptions.DetectChangesBeforeSave);
            }*/
        }
    }
}
