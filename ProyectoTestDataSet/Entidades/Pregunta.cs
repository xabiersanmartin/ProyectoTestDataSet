using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Pregunta : IEquatable<Pregunta>
    {
        public int idPregunta { get; set; }
        public string enunciado { get; set; }
        public bool respV { get; set; }
        public int idTest { get; set; }

        public Pregunta()
        {
        }

        public Pregunta(string enunciado)
        {
            this.enunciado = enunciado;
        }

        public Pregunta(int idPregunta, string enunciado, bool respV, int idTest)
        {
            this.idPregunta = idPregunta;
            this.enunciado = enunciado;
            this.respV = respV;
            this.idTest = idTest;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Pregunta);
        }

        public bool Equals(Pregunta other)
        {
            return other != null &&
                   idPregunta == other.idPregunta;
        }

        public override int GetHashCode()
        {
            return 1071672450 + idPregunta.GetHashCode();
        }
    }
}
