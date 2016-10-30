using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ajax_IMEC.Models
{
    public class ModeloIntermedio
    {
        public persona modeloPersona { get; set; }
        public List<persona> listaPersonas = new List<persona>();

        public ModeloIntermedio(persona nueva)
        {
            modeloPersona = nueva;
        }

        public ModeloIntermedio()
        {
        }

    }
}
