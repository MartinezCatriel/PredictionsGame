using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prediccion
{
    public class Equipo
    {
        private Equipo()
        {

        }

        public static Equipo Create()
        {
            return new Equipo();
        }

        public string Nombre { get { return "Argentina"; }
            set { throw new NotImplementedException(); }
        }

        public int Id
        {
            get { return 1; }
            set { throw new NotImplementedException(); }
        }
    }
}
