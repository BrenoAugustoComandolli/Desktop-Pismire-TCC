namespace Pismire_TCC
{
    partial class TelaVisualizarExperienciaInternacionalEvento
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaVisualizarExperienciaInternacionalEvento));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pb_voltar = new System.Windows.Forms.PictureBox();
            this.lblExperienciaInternacional = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pLixeira = new System.Windows.Forms.Panel();
            this.btConf = new System.Windows.Forms.Button();
            this.btCancelar1 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.dt = new System.Windows.Forms.DataGridView();
            this.lblAviso = new System.Windows.Forms.Label();
            this.pbLixeira = new System.Windows.Forms.PictureBox();
            this.pnBarraDeCima = new System.Windows.Forms.Panel();
            this.pbMinimizar = new System.Windows.Forms.PictureBox();
            this.pbMaximizar = new System.Windows.Forms.PictureBox();
            this.pbFechar = new System.Windows.Forms.PictureBox();
            this.pCabecalho = new System.Windows.Forms.Panel();
            this.lblCabecalho1 = new System.Windows.Forms.Label();
            this.lblCabecalho2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_voltar)).BeginInit();
            this.panel2.SuspendLayout();
            this.pLixeira.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLixeira)).BeginInit();
            this.pnBarraDeCima.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMinimizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMaximizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFechar)).BeginInit();
            this.pCabecalho.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(92)))));
            this.panel1.Controls.Add(this.pb_voltar);
            this.panel1.Controls.Add(this.lblExperienciaInternacional);
            this.panel1.Location = new System.Drawing.Point(0, 20);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1400, 65);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.Resize += new System.EventHandler(this.panel1_Resize);
            // 
            // pb_voltar
            // 
            this.pb_voltar.Image = global::Pismire_TCC.Properties.Resources.voltar;
            this.pb_voltar.Location = new System.Drawing.Point(32, 18);
            this.pb_voltar.Name = "pb_voltar";
            this.pb_voltar.Size = new System.Drawing.Size(32, 29);
            this.pb_voltar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_voltar.TabIndex = 1;
            this.pb_voltar.TabStop = false;
            this.pb_voltar.Click += new System.EventHandler(this.pb_voltar_Click);
            this.pb_voltar.MouseEnter += new System.EventHandler(this.pb_voltar_MouseEnter);
            this.pb_voltar.MouseLeave += new System.EventHandler(this.pb_voltar_MouseLeave);
            // 
            // lblExperienciaInternacional
            // 
            this.lblExperienciaInternacional.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblExperienciaInternacional.AutoSize = true;
            this.lblExperienciaInternacional.Font = new System.Drawing.Font("Myanmar Text", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExperienciaInternacional.ForeColor = System.Drawing.Color.White;
            this.lblExperienciaInternacional.Location = new System.Drawing.Point(527, 11);
            this.lblExperienciaInternacional.Name = "lblExperienciaInternacional";
            this.lblExperienciaInternacional.Size = new System.Drawing.Size(377, 56);
            this.lblExperienciaInternacional.TabIndex = 0;
            this.lblExperienciaInternacional.Text = "Experiência Internacional";
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel2.Controls.Add(this.pLixeira);
            this.panel2.Controls.Add(this.dt);
            this.panel2.Location = new System.Drawing.Point(285, 267);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(820, 350);
            this.panel2.TabIndex = 1;
            // 
            // pLixeira
            // 
            this.pLixeira.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pLixeira.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(92)))));
            this.pLixeira.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pLixeira.Controls.Add(this.btConf);
            this.pLixeira.Controls.Add(this.btCancelar1);
            this.pLixeira.Controls.Add(this.label6);
            this.pLixeira.Controls.Add(this.pictureBox3);
            this.pLixeira.Location = new System.Drawing.Point(217, 29);
            this.pLixeira.Name = "pLixeira";
            this.pLixeira.Size = new System.Drawing.Size(390, 217);
            this.pLixeira.TabIndex = 26;
            this.pLixeira.Visible = false;
            // 
            // btConf
            // 
            this.btConf.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.btConf.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(92)))));
            this.btConf.FlatAppearance.BorderSize = 3;
            this.btConf.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(189)))), ((int)(((byte)(251)))));
            this.btConf.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(189)))), ((int)(((byte)(251)))));
            this.btConf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btConf.Font = new System.Drawing.Font("Myanmar Text", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btConf.ForeColor = System.Drawing.Color.White;
            this.btConf.Location = new System.Drawing.Point(222, 146);
            this.btConf.Name = "btConf";
            this.btConf.Size = new System.Drawing.Size(106, 36);
            this.btConf.TabIndex = 18;
            this.btConf.Text = "Confirmar";
            this.btConf.UseVisualStyleBackColor = false;
            this.btConf.Click += new System.EventHandler(this.btConf_Click);
            this.btConf.MouseEnter += new System.EventHandler(this.btConf_MouseEnter);
            this.btConf.MouseLeave += new System.EventHandler(this.btConf_MouseLeave);
            // 
            // btCancelar1
            // 
            this.btCancelar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.btCancelar1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(92)))));
            this.btCancelar1.FlatAppearance.BorderSize = 3;
            this.btCancelar1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(189)))), ((int)(((byte)(251)))));
            this.btCancelar1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(189)))), ((int)(((byte)(251)))));
            this.btCancelar1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCancelar1.Font = new System.Drawing.Font("Myanmar Text", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCancelar1.ForeColor = System.Drawing.Color.White;
            this.btCancelar1.Location = new System.Drawing.Point(63, 146);
            this.btCancelar1.Name = "btCancelar1";
            this.btCancelar1.Size = new System.Drawing.Size(106, 36);
            this.btCancelar1.TabIndex = 17;
            this.btCancelar1.Text = "Cancelar";
            this.btCancelar1.UseVisualStyleBackColor = false;
            this.btCancelar1.Click += new System.EventHandler(this.btCancelar1_Click_1);
            this.btCancelar1.MouseEnter += new System.EventHandler(this.btCancelar1_MouseEnter);
            this.btCancelar1.MouseLeave += new System.EventHandler(this.btCancelar1_MouseLeave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Myanmar Text", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(20, 91);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(348, 34);
            this.label6.TabIndex = 14;
            this.label6.Text = "Deseja mesmo excluir esta experiência?";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::Pismire_TCC.Properties.Resources.excluir;
            this.pictureBox3.Location = new System.Drawing.Point(172, 21);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(49, 40);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 13;
            this.pictureBox3.TabStop = false;
            // 
            // dt
            // 
            this.dt.AllowUserToAddRows = false;
            this.dt.AllowUserToDeleteRows = false;
            this.dt.AllowUserToResizeColumns = false;
            this.dt.AllowUserToResizeRows = false;
            this.dt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dt.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dt.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dt.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.dt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dt.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dt.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dt.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dt.ColumnHeadersHeight = 50;
            this.dt.ColumnHeadersVisible = false;
            this.dt.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.dt.EnableHeadersVisualStyles = false;
            this.dt.GridColor = System.Drawing.Color.White;
            this.dt.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.dt.Location = new System.Drawing.Point(0, 0);
            this.dt.MultiSelect = false;
            this.dt.Name = "dt";
            this.dt.ReadOnly = true;
            this.dt.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dt.RowHeadersVisible = false;
            this.dt.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(15);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dt.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dt.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.dt.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dt.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dt.RowTemplate.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(15);
            this.dt.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Gray;
            this.dt.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dt.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dt.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dt.ShowCellErrors = false;
            this.dt.ShowCellToolTips = false;
            this.dt.ShowEditingIcon = false;
            this.dt.ShowRowErrors = false;
            this.dt.Size = new System.Drawing.Size(820, 350);
            this.dt.TabIndex = 0;
            this.dt.TabStop = false;
            // 
            // lblAviso
            // 
            this.lblAviso.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblAviso.AutoSize = true;
            this.lblAviso.Font = new System.Drawing.Font("Myanmar Text", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAviso.ForeColor = System.Drawing.Color.White;
            this.lblAviso.Location = new System.Drawing.Point(435, 359);
            this.lblAviso.Name = "lblAviso";
            this.lblAviso.Size = new System.Drawing.Size(541, 62);
            this.lblAviso.TabIndex = 6;
            this.lblAviso.Text = "Nenhuma experiência adicionada";
            this.lblAviso.Visible = false;
            // 
            // pbLixeira
            // 
            this.pbLixeira.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pbLixeira.Image = global::Pismire_TCC.Properties.Resources.excluir;
            this.pbLixeira.Location = new System.Drawing.Point(1303, 674);
            this.pbLixeira.Name = "pbLixeira";
            this.pbLixeira.Size = new System.Drawing.Size(41, 39);
            this.pbLixeira.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLixeira.TabIndex = 5;
            this.pbLixeira.TabStop = false;
            this.pbLixeira.Click += new System.EventHandler(this.pbLixeira_Click);
            this.pbLixeira.MouseEnter += new System.EventHandler(this.pbLixeira_MouseEnter);
            this.pbLixeira.MouseLeave += new System.EventHandler(this.pbLixeira_MouseLeave);
            // 
            // pnBarraDeCima
            // 
            this.pnBarraDeCima.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnBarraDeCima.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(62)))), ((int)(((byte)(85)))));
            this.pnBarraDeCima.Controls.Add(this.pbMinimizar);
            this.pnBarraDeCima.Controls.Add(this.pbMaximizar);
            this.pnBarraDeCima.Controls.Add(this.pbFechar);
            this.pnBarraDeCima.Location = new System.Drawing.Point(0, 0);
            this.pnBarraDeCima.Name = "pnBarraDeCima";
            this.pnBarraDeCima.Size = new System.Drawing.Size(1400, 21);
            this.pnBarraDeCima.TabIndex = 32;
            // 
            // pbMinimizar
            // 
            this.pbMinimizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbMinimizar.Image = global::Pismire_TCC.Properties.Resources.minimizar;
            this.pbMinimizar.Location = new System.Drawing.Point(1294, 2);
            this.pbMinimizar.Name = "pbMinimizar";
            this.pbMinimizar.Size = new System.Drawing.Size(33, 16);
            this.pbMinimizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbMinimizar.TabIndex = 2;
            this.pbMinimizar.TabStop = false;
            this.pbMinimizar.Click += new System.EventHandler(this.pbMinimizar_Click);
            this.pbMinimizar.MouseEnter += new System.EventHandler(this.pbMinimizar_MouseEnter);
            this.pbMinimizar.MouseLeave += new System.EventHandler(this.pbMinimizar_MouseLeave);
            // 
            // pbMaximizar
            // 
            this.pbMaximizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbMaximizar.Image = global::Pismire_TCC.Properties.Resources.maximizar2;
            this.pbMaximizar.Location = new System.Drawing.Point(1328, 2);
            this.pbMaximizar.Name = "pbMaximizar";
            this.pbMaximizar.Size = new System.Drawing.Size(33, 16);
            this.pbMaximizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbMaximizar.TabIndex = 1;
            this.pbMaximizar.TabStop = false;
            this.pbMaximizar.Click += new System.EventHandler(this.pbMaximizar_Click);
            this.pbMaximizar.MouseEnter += new System.EventHandler(this.pbMaximizar_MouseEnter);
            this.pbMaximizar.MouseLeave += new System.EventHandler(this.pbMaximizar_MouseLeave);
            // 
            // pbFechar
            // 
            this.pbFechar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbFechar.Image = global::Pismire_TCC.Properties.Resources.fechar1;
            this.pbFechar.Location = new System.Drawing.Point(1362, 2);
            this.pbFechar.Name = "pbFechar";
            this.pbFechar.Size = new System.Drawing.Size(33, 16);
            this.pbFechar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbFechar.TabIndex = 0;
            this.pbFechar.TabStop = false;
            this.pbFechar.Click += new System.EventHandler(this.pbFechar_Click);
            this.pbFechar.MouseEnter += new System.EventHandler(this.pbFechar_MouseEnter);
            this.pbFechar.MouseLeave += new System.EventHandler(this.pbFechar_MouseLeave);
            // 
            // pCabecalho
            // 
            this.pCabecalho.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pCabecalho.BackColor = System.Drawing.Color.MediumPurple;
            this.pCabecalho.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pCabecalho.Controls.Add(this.lblCabecalho1);
            this.pCabecalho.Controls.Add(this.lblCabecalho2);
            this.pCabecalho.Location = new System.Drawing.Point(285, 210);
            this.pCabecalho.Name = "pCabecalho";
            this.pCabecalho.Size = new System.Drawing.Size(820, 58);
            this.pCabecalho.TabIndex = 33;
            this.pCabecalho.Paint += new System.Windows.Forms.PaintEventHandler(this.pCabecalho_Paint);
            this.pCabecalho.Resize += new System.EventHandler(this.pCabecalho_Resize);
            // 
            // lblCabecalho1
            // 
            this.lblCabecalho1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCabecalho1.Font = new System.Drawing.Font("Myanmar Text", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCabecalho1.ForeColor = System.Drawing.Color.Black;
            this.lblCabecalho1.Location = new System.Drawing.Point(148, 10);
            this.lblCabecalho1.Name = "lblCabecalho1";
            this.lblCabecalho1.Size = new System.Drawing.Size(98, 43);
            this.lblCabecalho1.TabIndex = 3;
            this.lblCabecalho1.Text = "Cargo";
            this.lblCabecalho1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCabecalho2
            // 
            this.lblCabecalho2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCabecalho2.Font = new System.Drawing.Font("Myanmar Text", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCabecalho2.ForeColor = System.Drawing.Color.Black;
            this.lblCabecalho2.Location = new System.Drawing.Point(572, 11);
            this.lblCabecalho2.Name = "lblCabecalho2";
            this.lblCabecalho2.Size = new System.Drawing.Size(98, 43);
            this.lblCabecalho2.TabIndex = 4;
            this.lblCabecalho2.Text = "País";
            this.lblCabecalho2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TelaVisualizarExperienciaInternacionalEvento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.ClientSize = new System.Drawing.Size(1400, 750);
            this.Controls.Add(this.pCabecalho);
            this.Controls.Add(this.pnBarraDeCima);
            this.Controls.Add(this.pbLixeira);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblAviso);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TelaVisualizarExperienciaInternacionalEvento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pismire";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_voltar)).EndInit();
            this.panel2.ResumeLayout(false);
            this.pLixeira.ResumeLayout(false);
            this.pLixeira.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLixeira)).EndInit();
            this.pnBarraDeCima.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbMinimizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMaximizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFechar)).EndInit();
            this.pCabecalho.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblExperienciaInternacional;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dt;
        private System.Windows.Forms.PictureBox pb_voltar;
        private System.Windows.Forms.PictureBox pbLixeira;
        private System.Windows.Forms.Label lblAviso;
        private System.Windows.Forms.Panel pLixeira;
        private System.Windows.Forms.Button btConf;
        private System.Windows.Forms.Button btCancelar1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Panel pnBarraDeCima;
        private System.Windows.Forms.PictureBox pbMinimizar;
        private System.Windows.Forms.PictureBox pbMaximizar;
        private System.Windows.Forms.PictureBox pbFechar;
        private System.Windows.Forms.Panel pCabecalho;
        private System.Windows.Forms.Label lblCabecalho1;
        private System.Windows.Forms.Label lblCabecalho2;
    }
}

