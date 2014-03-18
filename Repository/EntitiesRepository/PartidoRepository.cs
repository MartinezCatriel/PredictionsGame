using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.EntitiesRepository
{
    public class PartidoRepository
    {
        public IRepository Repo { get; private set; }
        public PartidoRepository(IRepository repo)
        {
            Repo = repo;
        }

        public void GetAll()
        {
            Repo.GetAll<Partido>();
        }

        public void Update(object unPartido)
        {
            //Repo.SearchFor<Partido>((uno) => {return uno. });
        }
    }
}
