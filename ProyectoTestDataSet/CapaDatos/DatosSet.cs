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

        public DatosSet()
        {
            try
            {
                dsCategorias.Fill(ds.Categorias);
                dsTests.Fill(ds.Test);
                dsPreguntas.Fill(ds.Preguntas);
                dsCategoriasTests.Fill(ds.CategoriasTests);

            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Categoria> DevolverCategorias(out string msg)
        {
            if (ds == null)
            {
                msg = "No se ha podido establecer conexión con la base de datos";

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
            categoria.testCategorias.Clear();

            List<CategoriasTestsRow> dsTestCat;
            dsTestCat = ds.CategoriasTests.Where(drCatTest => drCatTest.IdCategoria == categoria.idCategoria).ToList();

            List<Test> listTestCat = (from dr in dsTestCat
                                      select new Test(dr.IdTest)).ToList();

            List<TestRow> dsTest;
            dsTest = ds.Test.ToList();

            List<Test> listTest = new List<Test>();

            foreach (var test in listTestCat)
            {
                listTest = (from t in dsTest
                            where t.IdTest == test.idTest
                            select new Test(t.IdTest, t.Descripcion)).ToList();

                foreach (var test2 in listTest)
                {
                    categoria.testCategorias.Add(test2);
                }
            }

            return categoria;

        }

    }
}
