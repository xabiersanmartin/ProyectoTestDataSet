namespace CapaPresentacion
{
    partial class FrmPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.cboCategorias = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboTestCategorias = new System.Windows.Forms.ComboBox();
            this.grbPreguntas = new System.Windows.Forms.GroupBox();
            this.btnHacerTest = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cboCategorias
            // 
            this.cboCategorias.FormattingEnabled = true;
            this.cboCategorias.Location = new System.Drawing.Point(489, 70);
            this.cboCategorias.Name = "cboCategorias";
            this.cboCategorias.Size = new System.Drawing.Size(164, 24);
            this.cboCategorias.TabIndex = 0;
            this.cboCategorias.SelectedIndexChanged += new System.EventHandler(this.cboCategorias_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(392, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Categorias";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(745, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tests De Categoria";
            // 
            // cboTestCategorias
            // 
            this.cboTestCategorias.FormattingEnabled = true;
            this.cboTestCategorias.Location = new System.Drawing.Point(900, 70);
            this.cboTestCategorias.Name = "cboTestCategorias";
            this.cboTestCategorias.Size = new System.Drawing.Size(164, 24);
            this.cboTestCategorias.TabIndex = 3;
            this.cboTestCategorias.SelectedIndexChanged += new System.EventHandler(this.cboTestCategorias_SelectedIndexChanged);
            // 
            // grbPreguntas
            // 
            this.grbPreguntas.Location = new System.Drawing.Point(267, 134);
            this.grbPreguntas.Name = "grbPreguntas";
            this.grbPreguntas.Size = new System.Drawing.Size(1073, 466);
            this.grbPreguntas.TabIndex = 4;
            this.grbPreguntas.TabStop = false;
            this.grbPreguntas.Text = "Hacer Test";
            // 
            // btnHacerTest
            // 
            this.btnHacerTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHacerTest.Location = new System.Drawing.Point(702, 624);
            this.btnHacerTest.Name = "btnHacerTest";
            this.btnHacerTest.Size = new System.Drawing.Size(119, 43);
            this.btnHacerTest.TabIndex = 5;
            this.btnHacerTest.Text = "&Hacer Test";
            this.btnHacerTest.UseVisualStyleBackColor = true;
            this.btnHacerTest.Click += new System.EventHandler(this.btnHacerTest_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrar.Location = new System.Drawing.Point(12, 750);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(119, 43);
            this.btnCerrar.TabIndex = 7;
            this.btnCerrar.Text = "&Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1386, 805);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnHacerTest);
            this.Controls.Add(this.grbPreguntas);
            this.Controls.Add(this.cboTestCategorias);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboCategorias);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "FrmPrincipal";
            this.Text = "Formulario Principal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboCategorias;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboTestCategorias;
        private System.Windows.Forms.GroupBox grbPreguntas;
        private System.Windows.Forms.Button btnHacerTest;
        private System.Windows.Forms.Button btnCerrar;
    }
}

