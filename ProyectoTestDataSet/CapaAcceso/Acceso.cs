using CapaDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaAcceso
{
    public class Acceso
    {
        DatosSet nuevoAcceso = new DatosSet();
        public List<Categoria> DevolverCategorias(out string msg)
        {
            return nuevoAcceso.DevolverCategorias(out msg);
        }

        public Categoria DevolverCategoriaTests(Categoria categoria)
        {
            return nuevoAcceso.DevolverTestsCategoria(categoria);
        }

        public Test DevolverTestPreguntas (Test test, out string msg)
        {
            return nuevoAcceso.DevolverPreguntasTest(test, out msg);
        }
    }
}
