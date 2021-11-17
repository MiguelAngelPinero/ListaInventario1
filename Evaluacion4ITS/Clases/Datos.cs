using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluacion4ITS
{
    public class Datos
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public float Precio { get; set; }
        public int Cantidad { get; set; }


        public bool Validar()
        {
            bool respuesta = false;

            if (Precio > 0 )
            {
                respuesta = true;
            }
            return respuesta;
        }
    }
}
