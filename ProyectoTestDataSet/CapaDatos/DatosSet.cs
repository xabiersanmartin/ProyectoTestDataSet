using CapaDatos.DataSetTestTableAdapters;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CapaDatos.DataSetTest;

namespace CapaDatos
{
    public class DatosSet
    {
        DataSetTest ds = new DataSetTest();
        CategoriasTableAdapter dtCategorias = new CategoriasTableAdapter();
        PreguntasTableAdapter dtPreguntas = new PreguntasTableAdapter();
        TestTableAdapter dtTests = new TestTableAdapter();
        CategoriasTestsTableAdapter dtCategoriasTests = new CategoriasTestsTableAdapter();

        public DatosSet(out string msg)
        {
            try
            {
                msg = "";
                dtCategorias.Fill(ds.Categorias);
                dtTests.Fill(ds.Test);
                dtPreguntas.Fill(ds.Preguntas);
                dtCategoriasTests.Fill(ds.CategoriasTests);
            }
            catch (Exception ex)
            {
                msg = "No se ha podido conectar con la base de datos, mensaje de error: " + ex.Message;
            }
        }

        public List<Categoria> DevolverCategorias(out string msg)
        {
            if (dtCategorias == null)
            {
                msg = "No hay caregorías";
                return null;
            }

            List<CategoriasRow> dsCategoria;
            dsCategoria = ds.Categorias.ToList();

            List<Categoria> listCategorias = (from dr in dsCategoria
                                              orderby dr.Descripcion ascending
                                              select new Categoria(dr.IdCategoria, dr.Descripcion)).ToList();

            if (listCategorias.Count == 0)
            {
                msg = "No hay categorías que mostrar";
                return null;
            }

            msg = "";
            return listCategorias;
        }

        public Categoria DevolverTestsCategoria(int idCategoria, out string msg) 
        {
            CategoriasRow drCategoria = ds.Categorias.FindByIdCategoria(idCategoria);

            if (drCategoria == null)
            {
                msg = "No existe la categoría";
                return null;
            }

            List<CategoriasTestsRow> drCategoriasTest = drCategoria.GetCategoriasTestsRows().ToList();

            var listTest = (from drcatTest in drCategoriasTest
                            select new Test(drcatTest.IdTest, drcatTest.TestRow.Descripcion)).ToList();

            if (listTest.Count == 0)
            {
                msg = "Esta categoría no tiene tests";
                return null;
            }

            foreach (var test in listTest)
            {
                TestRow drTest = ds.Test.FindByIdTest(test.idTest);

                List<PreguntasRow> drPreguntas = drTest.GetPreguntasRows().ToList();

                List<Pregunta> listPreguntas = (from drPregunta in drPreguntas
                                                select new Pregunta(drPregunta.IdPregunta, drPregunta.Enunciado, drPregunta.RespV)).ToList();
                if (listPreguntas.Count != 0)
                {
                    foreach (var pregunta in listPreguntas)
                    {
                        test.preguntasTest.Add(pregunta);
                    }
                } 
            }

            Categoria nuevaCategoria = new Categoria(drCategoria.IdCategoria, drCategoria.Descripcion, listTest);

            msg = "";
            return nuevaCategoria;

        }
        //Igual que la anterior función pero mas resumida y hecha de otra forma sin un for each
        public Categoria DevolverTestsCategoria2(int idCategoria, out string msg)
        {
            CategoriasRow drCategoria = ds.Categorias.FindByIdCategoria(idCategoria);

            if (drCategoria == null)
            {
                msg = "No existe la categoría";
                return null;
            }

            List<CategoriasTestsRow> drCategoriasTest = drCategoria.GetCategoriasTestsRows().ToList();
            if(drCategoriasTest.Count == 0)
            {
                msg = "Esta categoría no tiene tests";
                return null;
            }

            var listTest = (from drcatTest in drCategoriasTest
                            select new Test(drcatTest.IdTest, drcatTest.TestRow.Descripcion, (from drPregunta in drcatTest.TestRow.GetPreguntasRows()
                                                                                              select new Pregunta(drPregunta.IdPregunta, drPregunta.Enunciado, drPregunta.RespV)).ToList())).ToList();


            Categoria nuevaCategoria = new Categoria(drCategoria.IdCategoria, drCategoria.Descripcion, listTest);

            msg = "";
            return nuevaCategoria;

        }

        public Test DevolverPreguntasTest(int idTest, out string msg)
        {
            TestRow drTest = ds.Test.FindByIdTest(idTest);

            if (drTest == null)
            {
                msg = "No existe el test";
                return null;
            }

            Test nuevoTest = new Test(idTest);

            List<PreguntasRow> drPreguntas = drTest.GetPreguntasRows().ToList();
            
            List<Pregunta> listPreguntas = (from drpregunta in drPreguntas
                                            select new Pregunta(drpregunta.IdPregunta, drpregunta.Enunciado, drpregunta.RespV)).ToList();

            if (listPreguntas.Count == 0)
            {
                msg = "Este test no tiene preguntas";
                return null;
            }

            //foreach (var pregunta in listPreguntas)
            //{
            //    nuevoTest.preguntasTest.Add(pregunta);
            //}
            nuevoTest.preguntasTest = listPreguntas;

            msg = "";
            return nuevoTest;
        }

    }
}
