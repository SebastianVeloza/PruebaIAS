using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValueObjets
{
    public partial class Marca
    {
        public int idMarca { get; set; }
        public string NombreMarca { get; set;}

        public Marca(int idMarca, string nombreMarca)
        {
            this.idMarca = idMarca;
            NombreMarca = nombreMarca;
        }

        public static Marca? create (int idMarca, string nombreMarca)
        {
            if(idMarca == 0 || string.IsNullOrEmpty(nombreMarca)) {
                return null;
            }
            return new Marca(idMarca, nombreMarca);
        }
    }
}
