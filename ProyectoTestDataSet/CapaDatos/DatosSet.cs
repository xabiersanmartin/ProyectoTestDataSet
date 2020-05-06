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
        CategoriasTableAdapter dsCategorias = new CategoriasTableAdapter();
        PreguntasTableAdapter dsPreguntas = new PreguntasTableAdapter();
        TestTableAdapter dsTests = new TestTableAdapter();
        CategoriasTestsTableAdapter dsCategoriasTests = new CategoriasTestsTableAdapter();

        public DatosSet(out string msg)
        {
            try
            {
                msg = "";
                dsCategorias.Fill(ds.Categorias);
                dsTests.Fill(ds.Test);
                dsPreguntas.Fill(ds.Preguntas);
                dsCategoriasTests.Fill(ds.CategoriasTests);
            }
            catch (Exception ex)
            {
                msg = "No se ha podido conectar con la base de datos, mensaje de error: " + ex.Message;
            }
        }

        public List<Categoria> DevolverCategorias(out string msg)
        {
            if (ds == null)
            {
                msg = "No se ha podido establecer conexión con la base de datos interna";
                return null;
            }

            List<CategoriasRow> dsCategoria;
            dsCategoria = ds.Categorias.ToList();

            List<Categoria> listCategorias = (from dr in dsCategoria
                                              orderby dr.Descripcion ascending
                                              select new Categoria(dr.IdCategoria, dr.Descripcion)).ToList();

            if (listCategorias.Count == 0)
            {
                msg = "No hay categorias que mostrar";
                return null;
            }

            msg = "";
            return listCategorias;
        }

        public Categoria DevolverTestsCategoria(Categoria categoria)
        {
            if (categoria.testCategorias.Count != 0)
            {
                categoria.testCategorias.Clear();
            }

            List<CategoriasTestsRow> dsTestCat;
            dsTestCat = ds.CategoriasTests.Where(drCatTest => drCatTest.IdCategoria == categoria.idCategoria).ToList();

            foreach (var test in dsTestCat)
            {
                Test newTest = new Test();
                newTest.Descripcion = test.TestRow.Descripcion;
                newTest.idTest = test.IdTest;
                categoria.testCategorias.Add(newTest);
            }

            return categoria;

        }

        public Test DevolverPreguntasTest(Test test, out string msg)
        {
            if (test.preguntasTest.Count != 0)
            {
                test.preguntasTest.Clear();
            }

            List<PreguntasRow> dsPreg = ds.Preguntas.Where(drPreg => drPreg.IdTest == test.idTest).ToList();

            List<Pregunta> listPreguntas = (from dr in dsPreg
                                            select new Pregunta(dr.IdPregunta, dr.Enunciado, dr.RespV, dr.IdTest)).ToList();

            if (listPreguntas.Count == 0)
            {
                msg = "Este test no tiene preguntas";
                return null;
            }

            foreach (var preg in listPreguntas)
            {
                test.preguntasTest.Add(preg);
            }

            msg = "";
            return test;
        }

    }
}
