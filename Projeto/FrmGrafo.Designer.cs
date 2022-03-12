
namespace Grafos
{
    partial class FrmGrafo
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tpArvore = new System.Windows.Forms.TabPage();
            this.pnlArvore = new System.Windows.Forms.Panel();
            this.tpInicio = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cbCidadeExcluir = new System.Windows.Forms.ComboBox();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnCadastrarCidade = new System.Windows.Forms.Button();
            this.numLongitude = new System.Windows.Forms.NumericUpDown();
            this.txtNomeCidade = new System.Windows.Forms.TextBox();
            this.numLatitude = new System.Windows.Forms.NumericUpDown();
            this.lbCidades = new System.Windows.Forms.ListBox();
            this.lvResultados = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numDistancia = new System.Windows.Forms.NumericUpDown();
            this.numPreco = new System.Windows.Forms.NumericUpDown();
            this.cbCidadeOrigem = new System.Windows.Forms.ComboBox();
            this.cbCidadeDestino = new System.Windows.Forms.ComboBox();
            this.btnCadastrarRota = new System.Windows.Forms.Button();
            this.pbMapa = new System.Windows.Forms.PictureBox();
            this.lbCidade = new System.Windows.Forms.ListBox();
            this.cbPara = new System.Windows.Forms.ComboBox();
            this.cbDe = new System.Windows.Forms.ComboBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.openFile = new System.Windows.Forms.OpenFileDialog();
            this.tpArvore.SuspendLayout();
            this.tpInicio.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLongitude)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLatitude)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDistancia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPreco)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMapa)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tpArvore
            // 
            this.tpArvore.Controls.Add(this.pnlArvore);
            this.tpArvore.Location = new System.Drawing.Point(4, 24);
            this.tpArvore.Name = "tpArvore";
            this.tpArvore.Padding = new System.Windows.Forms.Padding(3);
            this.tpArvore.Size = new System.Drawing.Size(1122, 625);
            this.tpArvore.TabIndex = 1;
            this.tpArvore.Text = "Árvore";
            this.tpArvore.UseVisualStyleBackColor = true;
            // 
            // pnlArvore
            // 
            this.pnlArvore.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlArvore.Location = new System.Drawing.Point(8, 6);
            this.pnlArvore.Name = "pnlArvore";
            this.pnlArvore.Size = new System.Drawing.Size(1106, 602);
            this.pnlArvore.TabIndex = 2;
            this.pnlArvore.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlArvore_Paint);
            // 
            // tpInicio
            // 
            this.tpInicio.Controls.Add(this.groupBox3);
            this.tpInicio.Controls.Add(this.groupBox2);
            this.tpInicio.Controls.Add(this.lbCidades);
            this.tpInicio.Controls.Add(this.lvResultados);
            this.tpInicio.Controls.Add(this.groupBox1);
            this.tpInicio.Controls.Add(this.pbMapa);
            this.tpInicio.Controls.Add(this.lbCidade);
            this.tpInicio.Controls.Add(this.cbPara);
            this.tpInicio.Controls.Add(this.cbDe);
            this.tpInicio.Controls.Add(this.btnBuscar);
            this.tpInicio.Controls.Add(this.label1);
            this.tpInicio.Controls.Add(this.label2);
            this.tpInicio.Location = new System.Drawing.Point(4, 24);
            this.tpInicio.Name = "tpInicio";
            this.tpInicio.Padding = new System.Windows.Forms.Padding(3);
            this.tpInicio.Size = new System.Drawing.Size(1122, 625);
            this.tpInicio.TabIndex = 0;
            this.tpInicio.Text = "Início";
            this.tpInicio.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.cbCidadeExcluir);
            this.groupBox3.Controls.Add(this.btnExcluir);
            this.groupBox3.Location = new System.Drawing.Point(22, 506);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(276, 100);
            this.groupBox3.TabIndex = 29;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Excluir Cidade";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(14, 34);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(47, 15);
            this.label11.TabIndex = 31;
            this.label11.Text = "Cidade:";
            // 
            // cbCidadeExcluir
            // 
            this.cbCidadeExcluir.FormattingEnabled = true;
            this.cbCidadeExcluir.Location = new System.Drawing.Point(67, 31);
            this.cbCidadeExcluir.Name = "cbCidadeExcluir";
            this.cbCidadeExcluir.Size = new System.Drawing.Size(203, 23);
            this.cbCidadeExcluir.TabIndex = 26;
            // 
            // btnExcluir
            // 
            this.btnExcluir.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnExcluir.Location = new System.Drawing.Point(14, 60);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(256, 28);
            this.btnExcluir.TabIndex = 24;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.btnCadastrarCidade);
            this.groupBox2.Controls.Add(this.numLongitude);
            this.groupBox2.Controls.Add(this.txtNomeCidade);
            this.groupBox2.Controls.Add(this.numLatitude);
            this.groupBox2.Location = new System.Drawing.Point(22, 15);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(276, 146);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Cadastrar Cidade";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 87);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 15);
            this.label10.TabIndex = 30;
            this.label10.Text = "Longitude:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 58);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 15);
            this.label9.TabIndex = 29;
            this.label9.Text = "Latitude:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 27);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 15);
            this.label8.TabIndex = 28;
            this.label8.Text = "Cidade:";
            // 
            // btnCadastrarCidade
            // 
            this.btnCadastrarCidade.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCadastrarCidade.Location = new System.Drawing.Point(11, 112);
            this.btnCadastrarCidade.Name = "btnCadastrarCidade";
            this.btnCadastrarCidade.Size = new System.Drawing.Size(256, 28);
            this.btnCadastrarCidade.TabIndex = 28;
            this.btnCadastrarCidade.Text = "Cadastrar";
            this.btnCadastrarCidade.UseVisualStyleBackColor = true;
            this.btnCadastrarCidade.Click += new System.EventHandler(this.btnCadastrarCidade_Click_1);
            // 
            // numLongitude
            // 
            this.numLongitude.DecimalPlaces = 3;
            this.numLongitude.Location = new System.Drawing.Point(78, 85);
            this.numLongitude.Name = "numLongitude";
            this.numLongitude.Size = new System.Drawing.Size(186, 23);
            this.numLongitude.TabIndex = 25;
            // 
            // txtNomeCidade
            // 
            this.txtNomeCidade.Location = new System.Drawing.Point(78, 24);
            this.txtNomeCidade.Name = "txtNomeCidade";
            this.txtNomeCidade.Size = new System.Drawing.Size(186, 23);
            this.txtNomeCidade.TabIndex = 20;
            // 
            // numLatitude
            // 
            this.numLatitude.DecimalPlaces = 3;
            this.numLatitude.Location = new System.Drawing.Point(78, 56);
            this.numLatitude.Name = "numLatitude";
            this.numLatitude.Size = new System.Drawing.Size(186, 23);
            this.numLatitude.TabIndex = 24;
            // 
            // lbCidades
            // 
            this.lbCidades.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbCidades.FormattingEnabled = true;
            this.lbCidades.ItemHeight = 15;
            this.lbCidades.Location = new System.Drawing.Point(304, 18);
            this.lbCidades.Name = "lbCidades";
            this.lbCidades.Size = new System.Drawing.Size(236, 589);
            this.lbCidades.TabIndex = 27;
            // 
            // lvResultados
            // 
            this.lvResultados.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvResultados.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lvResultados.FormattingEnabled = true;
            this.lvResultados.ItemHeight = 15;
            this.lvResultados.Location = new System.Drawing.Point(559, 89);
            this.lvResultados.Name = "lvResultados";
            this.lvResultados.Size = new System.Drawing.Size(555, 139);
            this.lvResultados.TabIndex = 12;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.numDistancia);
            this.groupBox1.Controls.Add(this.numPreco);
            this.groupBox1.Controls.Add(this.cbCidadeOrigem);
            this.groupBox1.Controls.Add(this.cbCidadeDestino);
            this.groupBox1.Controls.Add(this.btnCadastrarRota);
            this.groupBox1.Location = new System.Drawing.Point(22, 239);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(276, 179);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cadastrar Rota";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 113);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 15);
            this.label7.TabIndex = 27;
            this.label7.Text = "Distância";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 86);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 15);
            this.label6.TabIndex = 26;
            this.label6.Text = "Preço: €$";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 15);
            this.label5.TabIndex = 25;
            this.label5.Text = "Destino:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 15);
            this.label4.TabIndex = 24;
            this.label4.Text = "Origem:";
            // 
            // numDistancia
            // 
            this.numDistancia.DecimalPlaces = 2;
            this.numDistancia.Location = new System.Drawing.Point(62, 111);
            this.numDistancia.Name = "numDistancia";
            this.numDistancia.Size = new System.Drawing.Size(202, 23);
            this.numDistancia.TabIndex = 23;
            // 
            // numPreco
            // 
            this.numPreco.DecimalPlaces = 2;
            this.numPreco.Location = new System.Drawing.Point(62, 84);
            this.numPreco.Name = "numPreco";
            this.numPreco.Size = new System.Drawing.Size(202, 23);
            this.numPreco.TabIndex = 22;
            // 
            // cbCidadeOrigem
            // 
            this.cbCidadeOrigem.FormattingEnabled = true;
            this.cbCidadeOrigem.Location = new System.Drawing.Point(62, 21);
            this.cbCidadeOrigem.Name = "cbCidadeOrigem";
            this.cbCidadeOrigem.Size = new System.Drawing.Size(202, 23);
            this.cbCidadeOrigem.TabIndex = 18;
            // 
            // cbCidadeDestino
            // 
            this.cbCidadeDestino.FormattingEnabled = true;
            this.cbCidadeDestino.Location = new System.Drawing.Point(62, 50);
            this.cbCidadeDestino.Name = "cbCidadeDestino";
            this.cbCidadeDestino.Size = new System.Drawing.Size(202, 23);
            this.cbCidadeDestino.TabIndex = 19;
            // 
            // btnCadastrarRota
            // 
            this.btnCadastrarRota.Location = new System.Drawing.Point(8, 141);
            this.btnCadastrarRota.Name = "btnCadastrarRota";
            this.btnCadastrarRota.Size = new System.Drawing.Size(262, 28);
            this.btnCadastrarRota.TabIndex = 21;
            this.btnCadastrarRota.Text = "Cadastrar Rota";
            this.btnCadastrarRota.UseVisualStyleBackColor = true;
            this.btnCadastrarRota.Click += new System.EventHandler(this.btnCadastrarRota_Click_1);
            // 
            // pbMapa
            // 
            this.pbMapa.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbMapa.BackgroundImage = global::Grafos.Properties.Resources.mapaEspanhaPortugal;
            this.pbMapa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbMapa.Location = new System.Drawing.Point(559, 234);
            this.pbMapa.Name = "pbMapa";
            this.pbMapa.Size = new System.Drawing.Size(555, 373);
            this.pbMapa.TabIndex = 17;
            this.pbMapa.TabStop = false;
            // 
            // lbCidade
            // 
            this.lbCidade.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbCidade.FormattingEnabled = true;
            this.lbCidade.ItemHeight = 15;
            this.lbCidade.Location = new System.Drawing.Point(34, 693);
            this.lbCidade.Name = "lbCidade";
            this.lbCidade.Size = new System.Drawing.Size(590, 64);
            this.lbCidade.TabIndex = 16;
            // 
            // cbPara
            // 
            this.cbPara.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cbPara.FormattingEnabled = true;
            this.cbPara.Location = new System.Drawing.Point(603, 58);
            this.cbPara.Name = "cbPara";
            this.cbPara.Size = new System.Drawing.Size(307, 23);
            this.cbPara.TabIndex = 15;
            // 
            // cbDe
            // 
            this.cbDe.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cbDe.FormattingEnabled = true;
            this.cbDe.Location = new System.Drawing.Point(603, 18);
            this.cbDe.Name = "cbDe";
            this.cbDe.Size = new System.Drawing.Size(307, 23);
            this.cbDe.TabIndex = 14;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscar.Location = new System.Drawing.Point(916, 18);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(198, 63);
            this.btnBuscar.TabIndex = 4;
            this.btnBuscar.Text = "Buscar Caminho";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(557, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "De:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(557, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "Para:";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tpInicio);
            this.tabControl1.Controls.Add(this.tpArvore);
            this.tabControl1.Location = new System.Drawing.Point(0, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1130, 653);
            this.tabControl1.TabIndex = 8;
            this.tabControl1.Tag = "";
            // 
            // openFile
            // 
            this.openFile.FileName = "openFileDialog1";
            // 
            // FrmGrafo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1130, 663);
            this.Controls.Add(this.tabControl1);
            this.Name = "FrmGrafo";
            this.Text = "RENFE - Grafos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmGrafo_FormClosing);
            this.Load += new System.EventHandler(this.FrmGrafo_Load_1);
            this.Resize += new System.EventHandler(this.FrmGrafo_Resize);
            this.tpArvore.ResumeLayout(false);
            this.tpInicio.ResumeLayout(false);
            this.tpInicio.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLongitude)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLatitude)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDistancia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPreco)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMapa)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnMostrarArvore;
        private System.Windows.Forms.TabPage tpArvore;
        private System.Windows.Forms.Panel pnlArvore;
        private System.Windows.Forms.TabPage tpInicio;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtNomeCidade;
        private System.Windows.Forms.ComboBox cbCidadeOrigem;
        private System.Windows.Forms.ComboBox cbCidadeDestino;
        private System.Windows.Forms.Button btnCadastrarRota;
        private System.Windows.Forms.PictureBox pbMapa;
        private System.Windows.Forms.ListBox lbCidade;
        private System.Windows.Forms.ComboBox cbPara;
        private System.Windows.Forms.ComboBox cbDe;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.NumericUpDown numLongitude;
        private System.Windows.Forms.NumericUpDown numLatitude;
        private System.Windows.Forms.NumericUpDown numDistancia;
        private System.Windows.Forms.NumericUpDown numPreco;
        private System.Windows.Forms.ListBox lvResultados;
        private System.Windows.Forms.ComboBox cbCidadeExcluir;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.ListBox lbCidades;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnCadastrarCidade;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.OpenFileDialog openFile;
    }
}

