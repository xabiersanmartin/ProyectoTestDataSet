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

        }

        private void cboCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {

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
    }
}
