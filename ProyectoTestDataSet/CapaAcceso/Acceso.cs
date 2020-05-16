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
        DatosSet nuevoAcceso = new DatosSet(out string msg);
        public List<Categoria> DevolverCategorias(out string msg)
        {
            return nuevoAcceso.DevolverCategorias(out msg);
        }

        public Categoria DevolverCategoriaTests(int idCategoria, out string msg)
        {
            return nuevoAcceso.DevolverTestsCategoria(idCategoria, out msg);
        }

        public Test DevolverTestPreguntas (int idTest, out string msg)
        {
            return nuevoAcceso.DevolverPreguntasTest(idTest, out msg);
        }
    }
}
