using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FrmPrincipal : Form
    {
        string msg;

        List<TextBox> listText = new List<TextBox>();
        List<CheckBox> listCheck = new List<CheckBox>();
        List<PictureBox> listPicB = new List<PictureBox>();
        List<Point> points = new List<Point>();

        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            List<Categoria> listCategoria = Program.gestor.DevolverCategorias(out msg);

            if (listCategoria == null)
            {
                MessageBox.Show(msg);
                cboCategorias.Enabled = false;
                return;
            }
            else
            {
                cboCategorias.Items.Clear();
                cboCategorias.Items.AddRange(listCategoria.ToArray());
                cboCategorias.DisplayMember = "Descripcion";
            }
            btnHacerTest.Enabled = false;
        }

        private void cboCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            grbPreguntas.Controls.Clear();

            btnHacerTest.Enabled = false;

            cboTestCategorias.SelectedIndex = -1;

            if (cboCategorias.SelectedIndex == -1)
            {
                MessageBox.Show("Debe estar seleccionada una categoria para cargar sus tests", "ATENCIÓN");
                return;
            }

            Categoria newCategoria = cboCategorias.SelectedItem as Categoria;

            Categoria categoriaTests = Program.gestor.DevolverCategoriaTests(newCategoria);

            if (categoriaTests.testCategorias.Count == 0)
            {
                MessageBox.Show("Esta categoria(" + categoriaTests.Descripcion + ") no tienes tests asociados.", "ATENCIÓN");
                List<Categoria> listCategoria = Program.gestor.DevolverCategorias(out msg);
                cboCategorias.Items.Clear();
                cboCategorias.Items.AddRange(listCategoria.ToArray());
                cboCategorias.DisplayMember = "Descripcion";

                cboTestCategorias.Enabled = false;
                return;
            }

            cboTestCategorias.Enabled = true;
            cboTestCategorias.Items.Clear();
            cboTestCategorias.Items.AddRange(categoriaTests.testCategorias.ToArray());
            cboTestCategorias.DisplayMember = "Descripcion";

        }

        private void cboTestCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            grbPreguntas.Controls.Clear();

            if (cboTestCategorias.SelectedIndex == -1)
            {
                return;
            }
            Test testBuscar = cboTestCategorias.SelectedItem as Test;

            Test testPreguntas = Program.gestor.DevolverTestPreguntas(testBuscar,out msg);

            if (msg != "")
            {
                MessageBox.Show(msg,"ATENCIÓN");
                cboTestCategorias.SelectedIndex = -1;
                btnHacerTest.Enabled = false;
                return;
            }

            int columna = 180;
            int columna2 = 660;
            int fila = 50;

            for (int i = 0; i < testPreguntas.preguntasTest.Count; i++)
            {
                TextBox newText = new TextBox();
                CheckBox newCheck = new CheckBox();

                newText.Text = testPreguntas.preguntasTest[i].enunciado;
                newText.Location = new Point(columna, fila);
                newText.Width = 450;
                newText.Height = 120;
                newText.ReadOnly = true;

                newCheck.Text = "Verdadera";
                newCheck.Location = new Point(columna2, fila);

                listCheck.Add(newCheck);
                listText.Add(newText);
                fila += 40;
            }

            foreach (var text in listText)
            {
                grbPreguntas.Controls.Add(text);
            }

            foreach (var checkB in listCheck)
            {
                grbPreguntas.Controls.Add(checkB);
            }
            btnHacerTest.Enabled = true;
        }

        private void btnHacerTest_Click(object sender, EventArgs e)
        {
            List<bool> comprobarTest = new List<bool>();
            int contador = 0;

            Test testBuscar = cboTestCategorias.SelectedItem as Test;
            Test testPreguntas = Program.gestor.DevolverTestPreguntas(testBuscar, out msg);

            foreach (var checkB in listCheck)
            {
                if (checkB.Checked)
                {
                    bool comprobar = true;
                    comprobarTest.Add(comprobar);
                }
                else
                {
                    bool comprobar = false;
                    comprobarTest.Add(comprobar);
                }

                Point point = checkB.Location;
                points.Add(point);

            }

            for (int i = 0; i < testBuscar.preguntasTest.Count; i++)
            {
                if (testBuscar.preguntasTest[i].respV == comprobarTest[i])
                {
                    contador += 1;
                }
                else
                {
                    bool comprobar = false;
                    comprobarTest.Add(comprobar);

                    Image image = Image.FromFile("../../../Icono/interfaz.png");

                    PictureBox pictureBox = new PictureBox();
                    pictureBox.Image = image;
                    pictureBox.Width = 30;
                    pictureBox.Height = 20;
                    pictureBox.Location = points[i] + new Size(-20, +2);
                    listPicB.Add(pictureBox);
                }

            }


            if (listPicB.Count != 0)
            {
                foreach (var pic in listPicB)
                {
                    grbPreguntas.Controls.Add(pic);
                }
            }


            if (contador == 0)
            {
                MessageBox.Show("No has acertado ninguna pregunta", "ATENCIÓN");
            }
            else
            {
                MessageBox.Show("Has acertado " + contador.ToString() + " preguntas", "ATENCIÓN");
            }

            btnHacerTest.Enabled = false;
        }
    }
}
