namespace Pismire_TCC
{
    partial class TelaGerenciarNotificacoes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaGerenciarNotificacoes));
            this.dt = new System.Windows.Forms.DataGridView();
            this.btLimpar = new System.Windows.Forms.Button();
            this.lblAviso = new System.Windows.Forms.Label();
            this.pLixeira = new System.Windows.Forms.Panel();
            this.btConfirmar = new System.Windows.Forms.Button();
            this.btCancelar = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pLimparAberto1 = new System.Windows.Forms.Panel();
            this.btConfirmar2 = new System.Windows.Forms.Button();
            this.btCancelar2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pbLixeira = new System.Windows.Forms.PictureBox();
            this.pnBarraDeCima = new System.Windows.Forms.Panel();
            this.pbMinimizar = new System.Windows.Forms.PictureBox();
            this.pbMaximizar = new System.Windows.Forms.PictureBox();
            this.pbFechar = new System.Windows.Forms.PictureBox();
            this.p_barra = new System.Windows.Forms.Panel();
            this.lbl_notificacoes = new System.Windows.Forms.Label();
            this.pb_voltar = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dt)).BeginInit();
            this.pLixeira.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.pLimparAberto1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLixeira)).BeginInit();
            this.pnBarraDeCima.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMinimizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMaximizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFechar)).BeginInit();
            this.p_barra.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_voltar)).BeginInit();
            this.SuspendLayout();
            // 
            // dt
            // 
            this.dt.AllowUserToAddRows = false;
            this.dt.AllowUserToDeleteRows = false;
            this.dt.AllowUserToResizeColumns = false;
            this.dt.AllowUserToResizeRows = false;
            this.dt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dt.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dt.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.dt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dt.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dt.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dt.ColumnHeadersVisible = false;
            this.dt.EnableHeadersVisualStyles = false;
            this.dt.GridColor = System.Drawing.SystemColors.ControlLightLight;
            this.dt.Location = new System.Drawing.Point(41, 104);
            this.dt.MultiSelect = false;
            this.dt.Name = "dt";
            this.dt.ReadOnly = true;
            this.dt.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dt.RowHeadersVisible = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dt.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dt.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.dt.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dt.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dt.RowTemplate.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(5);
            this.dt.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Gray;
            this.dt.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dt.RowTemplate.Height = 50;
            this.dt.RowTemplate.ReadOnly = true;
            this.dt.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dt.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dt.ShowCellErrors = false;
            this.dt.ShowCellToolTips = false;
            this.dt.ShowEditingIcon = false;
            this.dt.ShowRowErrors = false;
            this.dt.Size = new System.Drawing.Size(1317, 529);
            this.dt.TabIndex = 22;
            // 
            // btLimpar
            // 
            this.btLimpar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btLimpar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.btLimpar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(92)))));
            this.btLimpar.FlatAppearance.BorderSize = 3;
            this.btLimpar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(92)))));
            this.btLimpar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(92)))));
            this.btLimpar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btLimpar.Font = new System.Drawing.Font("Myanmar Text", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btLimpar.ForeColor = System.Drawing.Color.White;
            this.btLimpar.Location = new System.Drawing.Point(1252, 687);
            this.btLimpar.Name = "btLimpar";
            this.btLimpar.Size = new System.Drawing.Size(116, 36);
            this.btLimpar.TabIndex = 24;
            this.btLimpar.Text = "Limpar Tudo";
            this.btLimpar.UseVisualStyleBackColor = false;
            this.btLimpar.Click += new System.EventHandler(this.btLimpar_Click);
            // 
            // lblAviso
            // 
            this.lblAviso.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblAviso.AutoSize = true;
            this.lblAviso.Font = new System.Drawing.Font("Myanmar Text", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAviso.ForeColor = System.Drawing.Color.White;
            this.lblAviso.Location = new System.Drawing.Point(513, 336);
            this.lblAviso.Name = "lblAviso";
            this.lblAviso.Size = new System.Drawing.Size(386, 65);
            this.lblAviso.TabIndex = 25;
            this.lblAviso.Text = "Nenhuma Notificação";
            this.lblAviso.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAviso.Visible = false;
            // 
            // pLixeira
            // 
            this.pLixeira.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pLixeira.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(92)))));
            this.pLixeira.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pLixeira.Controls.Add(this.btConfirmar);
            this.pLixeira.Controls.Add(this.btCancelar);
            this.pLixeira.Controls.Add(this.label6);
            this.pLixeira.Controls.Add(this.pictureBox2);
            this.pLixeira.Location = new System.Drawing.Point(500, 247);
            this.pLixeira.Name = "pLixeira";
            this.pLixeira.Size = new System.Drawing.Size(390, 217);
            this.pLixeira.TabIndex = 26;
            this.pLixeira.Visible = false;
            // 
            // btConfirmar
            // 
            this.btConfirmar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.btConfirmar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(92)))));
            this.btConfirmar.FlatAppearance.BorderSize = 3;
            this.btConfirmar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(189)))), ((int)(((byte)(251)))));
            this.btConfirmar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(189)))), ((int)(((byte)(251)))));
            this.btConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btConfirmar.Font = new System.Drawing.Font("Myanmar Text", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btConfirmar.ForeColor = System.Drawing.Color.White;
            this.btConfirmar.Location = new System.Drawing.Point(222, 146);
            this.btConfirmar.Name = "btConfirmar";
            this.btConfirmar.Size = new System.Drawing.Size(106, 36);
            this.btConfirmar.TabIndex = 18;
            this.btConfirmar.Text = "Confirmar";
            this.btConfirmar.UseVisualStyleBackColor = false;
            this.btConfirmar.Click += new System.EventHandler(this.btConfirmar_Click);
            this.btConfirmar.MouseEnter += new System.EventHandler(this.btConfirmar_MouseEnter);
            this.btConfirmar.MouseLeave += new System.EventHandler(this.btConfirmar_MouseLeave);
            // 
            // btCancelar
            // 
            this.btCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.btCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(92)))));
            this.btCancelar.FlatAppearance.BorderSize = 3;
            this.btCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(189)))), ((int)(((byte)(251)))));
            this.btCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(189)))), ((int)(((byte)(251)))));
            this.btCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCancelar.Font = new System.Drawing.Font("Myanmar Text", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCancelar.ForeColor = System.Drawing.Color.White;
            this.btCancelar.Location = new System.Drawing.Point(63, 146);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(106, 36);
            this.btCancelar.TabIndex = 17;
            this.btCancelar.Text = "Cancelar";
            this.btCancelar.UseVisualStyleBackColor = false;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar1_Click);
            this.btCancelar.MouseEnter += new System.EventHandler(this.btCancelar_MouseEnter);
            this.btCancelar.MouseLeave += new System.EventHandler(this.btCancelar_MouseLeave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Myanmar Text", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(20, 92);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(343, 34);
            this.label6.TabIndex = 14;
            this.label6.Text = "Deseja mesmo excluir está mensagem?";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Pismire_TCC.Properties.Resources.excluir;
            this.pictureBox2.Location = new System.Drawing.Point(172, 21);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(49, 40);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 13;
            this.pictureBox2.TabStop = false;
            // 
            // pLimparAberto1
            // 
            this.pLimparAberto1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pLimparAberto1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(92)))));
            this.pLimparAberto1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pLimparAberto1.Controls.Add(this.btConfirmar2);
            this.pLimparAberto1.Controls.Add(this.btCancelar2);
            this.pLimparAberto1.Controls.Add(this.label1);
            this.pLimparAberto1.Controls.Add(this.pictureBox1);
            this.pLimparAberto1.Location = new System.Drawing.Point(500, 247);
            this.pLimparAberto1.Name = "pLimparAberto1";
            this.pLimparAberto1.Size = new System.Drawing.Size(390, 217);
            this.pLimparAberto1.TabIndex = 27;
            this.pLimparAberto1.Visible = false;
            // 
            // btConfirmar2
            // 
            this.btConfirmar2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.btConfirmar2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(92)))));
            this.btConfirmar2.FlatAppearance.BorderSize = 3;
            this.btConfirmar2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(189)))), ((int)(((byte)(251)))));
            this.btConfirmar2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(189)))), ((int)(((byte)(251)))));
            this.btConfirmar2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btConfirmar2.Font = new System.Drawing.Font("Myanmar Text", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btConfirmar2.ForeColor = System.Drawing.Color.White;
            this.btConfirmar2.Location = new System.Drawing.Point(222, 152);
            this.btConfirmar2.Name = "btConfirmar2";
            this.btConfirmar2.Size = new System.Drawing.Size(106, 36);
            this.btConfirmar2.TabIndex = 18;
            this.btConfirmar2.Text = "Confirmar";
            this.btConfirmar2.UseVisualStyleBackColor = false;
            this.btConfirmar2.Click += new System.EventHandler(this.btLimparAberto_Click);
            this.btConfirmar2.MouseEnter += new System.EventHandler(this.btConfirmar2_MouseEnter);
            this.btConfirmar2.MouseLeave += new System.EventHandler(this.btConfirmar2_MouseLeave);
            // 
            // btCancelar2
            // 
            this.btCancelar2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.btCancelar2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(92)))));
            this.btCancelar2.FlatAppearance.BorderSize = 3;
            this.btCancelar2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(189)))), ((int)(((byte)(251)))));
            this.btCancelar2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(189)))), ((int)(((byte)(251)))));
            this.btCancelar2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCancelar2.Font = new System.Drawing.Font("Myanmar Text", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCancelar2.ForeColor = System.Drawing.Color.White;
            this.btCancelar2.Location = new System.Drawing.Point(63, 152);
            this.btCancelar2.Name = "btCancelar2";
            this.btCancelar2.Size = new System.Drawing.Size(106, 36);
            this.btCancelar2.TabIndex = 17;
            this.btCancelar2.Text = "Cancelar";
            this.btCancelar2.UseVisualStyleBackColor = false;
            this.btCancelar2.Click += new System.EventHandler(this.btCancelarAberto_Click);
            this.btCancelar2.MouseEnter += new System.EventHandler(this.btCancelar2_MouseEnter);
            this.btCancelar2.MouseLeave += new System.EventHandler(this.btCancelar2_MouseLeave);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Myanmar Text", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(22, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(347, 51);
            this.label1.TabIndex = 14;
            this.label1.Text = "Deseja mesmo excluir todas as mensagens?";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Pismire_TCC.Properties.Resources.excluir;
            this.pictureBox1.Location = new System.Drawing.Point(172, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(49, 40);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // pbLixeira
            // 
            this.pbLixeira.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pbLixeira.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbLixeira.Image = global::Pismire_TCC.Properties.Resources.excluir;
            this.pbLixeira.Location = new System.Drawing.Point(51, 686);
            this.pbLixeira.Name = "pbLixeira";
            this.pbLixeira.Size = new System.Drawing.Size(35, 35);
            this.pbLixeira.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLixeira.TabIndex = 23;
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
            // p_barra
            // 
            this.p_barra.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.p_barra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(92)))));
            this.p_barra.Controls.Add(this.lbl_notificacoes);
            this.p_barra.Controls.Add(this.pb_voltar);
            this.p_barra.Location = new System.Drawing.Point(0, 21);
            this.p_barra.Name = "p_barra";
            this.p_barra.Size = new System.Drawing.Size(1402, 65);
            this.p_barra.TabIndex = 33;
            this.p_barra.Paint += new System.Windows.Forms.PaintEventHandler(this.p_barra_Paint);
            this.p_barra.Resize += new System.EventHandler(this.p_barra_Resize);
            // 
            // lbl_notificacoes
            // 
            this.lbl_notificacoes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_notificacoes.AutoSize = true;
            this.lbl_notificacoes.Font = new System.Drawing.Font("Myanmar Text", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_notificacoes.ForeColor = System.Drawing.Color.White;
            this.lbl_notificacoes.Location = new System.Drawing.Point(620, 10);
            this.lbl_notificacoes.Name = "lbl_notificacoes";
            this.lbl_notificacoes.Size = new System.Drawing.Size(185, 56);
            this.lbl_notificacoes.TabIndex = 2;
            this.lbl_notificacoes.Text = "Notificação";
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
            // TelaGerenciarNotificacoes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.ClientSize = new System.Drawing.Size(1400, 750);
            this.Controls.Add(this.p_barra);
            this.Controls.Add(this.pnBarraDeCima);
            this.Controls.Add(this.pLimparAberto1);
            this.Controls.Add(this.pLixeira);
            this.Controls.Add(this.lblAviso);
            this.Controls.Add(this.btLimpar);
            this.Controls.Add(this.pbLixeira);
            this.Controls.Add(this.dt);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.MaximizeBox = false;
            this.Name = "TelaGerenciarNotificacoes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pismire";
            ((System.ComponentModel.ISupportInitialize)(this.dt)).EndInit();
            this.pLixeira.ResumeLayout(false);
            this.pLixeira.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.pLimparAberto1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLixeira)).EndInit();
            this.pnBarraDeCima.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbMinimizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMaximizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFechar)).EndInit();
            this.p_barra.ResumeLayout(false);
            this.p_barra.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_voltar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.DataGridView dt;
        private System.Windows.Forms.PictureBox pbLixeira;
        private System.Windows.Forms.Button btLimpar;
        public System.Windows.Forms.Label lblAviso;
        private System.Windows.Forms.Panel pLixeira;
        private System.Windows.Forms.Button btConfirmar;
        private System.Windows.Forms.Button btCancelar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel pLimparAberto1;
        private System.Windows.Forms.Button btConfirmar2;
        private System.Windows.Forms.Button btCancelar2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel pnBarraDeCima;
        private System.Windows.Forms.PictureBox pbMinimizar;
        private System.Windows.Forms.PictureBox pbMaximizar;
        private System.Windows.Forms.PictureBox pbFechar;
        private System.Windows.Forms.Panel p_barra;
        private System.Windows.Forms.Label lbl_notificacoes;
        private System.Windows.Forms.PictureBox pb_voltar;
    }
}