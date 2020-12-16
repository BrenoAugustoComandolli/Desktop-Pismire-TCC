namespace Pismire_TCC
{
    partial class TelaNotificacao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaNotificacao));
            this.btLimpar = new System.Windows.Forms.Button();
            this.dt = new System.Windows.Forms.DataGridView();
            this.lblAviso = new System.Windows.Forms.Label();
            this.pLixeira = new System.Windows.Forms.Panel();
            this.btCancelar2 = new System.Windows.Forms.Button();
            this.lblL1 = new System.Windows.Forms.Label();
            this.btConfirmar = new System.Windows.Forms.Button();
            this.pbL1 = new System.Windows.Forms.PictureBox();
            this.btConfirmar2 = new System.Windows.Forms.Button();
            this.pLimparAberto = new System.Windows.Forms.Panel();
            this.btCancelar = new System.Windows.Forms.Button();
            this.lblL2 = new System.Windows.Forms.Label();
            this.pbL2 = new System.Windows.Forms.PictureBox();
            this.lblDesativado = new System.Windows.Forms.Label();
            this.lblAtivado = new System.Windows.Forms.Label();
            this.pbLixeira = new System.Windows.Forms.PictureBox();
            this.p_barra = new System.Windows.Forms.Panel();
            this.pb_voltar = new System.Windows.Forms.PictureBox();
            this.lbl_notificacao = new System.Windows.Forms.Label();
            this.pnBarraDeCima = new System.Windows.Forms.Panel();
            this.pbMinimizar = new System.Windows.Forms.PictureBox();
            this.pbMaximizar = new System.Windows.Forms.PictureBox();
            this.pbFechar = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dt)).BeginInit();
            this.pLixeira.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbL1)).BeginInit();
            this.pLimparAberto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbL2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLixeira)).BeginInit();
            this.p_barra.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_voltar)).BeginInit();
            this.pnBarraDeCima.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMinimizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMaximizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFechar)).BeginInit();
            this.SuspendLayout();
            // 
            // btLimpar
            // 
            this.btLimpar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btLimpar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.btLimpar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(92)))));
            this.btLimpar.FlatAppearance.BorderSize = 3;
            this.btLimpar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(92)))));
            this.btLimpar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(92)))));
            this.btLimpar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btLimpar.Font = new System.Drawing.Font("Myanmar Text", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btLimpar.ForeColor = System.Drawing.Color.White;
            this.btLimpar.Location = new System.Drawing.Point(1240, 674);
            this.btLimpar.Name = "btLimpar";
            this.btLimpar.Size = new System.Drawing.Size(118, 39);
            this.btLimpar.TabIndex = 20;
            this.btLimpar.Text = "Limpar Tudo";
            this.btLimpar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btLimpar.UseVisualStyleBackColor = false;
            this.btLimpar.Click += new System.EventHandler(this.btLimpar_Click);
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
            this.dt.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.dt.Location = new System.Drawing.Point(41, 95);
            this.dt.MultiSelect = false;
            this.dt.Name = "dt";
            this.dt.ReadOnly = true;
            this.dt.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dt.RowHeadersVisible = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dt.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dt.RowTemplate.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(5);
            this.dt.RowTemplate.Height = 50;
            this.dt.RowTemplate.ReadOnly = true;
            this.dt.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dt.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dt.ShowCellErrors = false;
            this.dt.ShowCellToolTips = false;
            this.dt.ShowEditingIcon = false;
            this.dt.ShowRowErrors = false;
            this.dt.Size = new System.Drawing.Size(1317, 517);
            this.dt.TabIndex = 21;
            this.dt.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dt_CellDoubleClick);
            this.dt.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dt_CellEnter);
            this.dt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dt_KeyDown);
            // 
            // lblAviso
            // 
            this.lblAviso.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblAviso.AutoSize = true;
            this.lblAviso.Font = new System.Drawing.Font("Myanmar Text", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAviso.ForeColor = System.Drawing.Color.White;
            this.lblAviso.Location = new System.Drawing.Point(508, 350);
            this.lblAviso.Name = "lblAviso";
            this.lblAviso.Size = new System.Drawing.Size(386, 65);
            this.lblAviso.TabIndex = 23;
            this.lblAviso.Text = "Nenhuma Notificação";
            this.lblAviso.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAviso.Visible = false;
            // 
            // pLixeira
            // 
            this.pLixeira.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pLixeira.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(92)))));
            this.pLixeira.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pLixeira.Controls.Add(this.btCancelar2);
            this.pLixeira.Controls.Add(this.lblL1);
            this.pLixeira.Controls.Add(this.btConfirmar);
            this.pLixeira.Controls.Add(this.pbL1);
            this.pLixeira.Location = new System.Drawing.Point(500, 247);
            this.pLixeira.Name = "pLixeira";
            this.pLixeira.Size = new System.Drawing.Size(390, 217);
            this.pLixeira.TabIndex = 24;
            this.pLixeira.Visible = false;
            // 
            // btCancelar2
            // 
            this.btCancelar2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.btCancelar2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.btCancelar2.FlatAppearance.BorderSize = 0;
            this.btCancelar2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(189)))), ((int)(((byte)(251)))));
            this.btCancelar2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(189)))), ((int)(((byte)(251)))));
            this.btCancelar2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCancelar2.Font = new System.Drawing.Font("Myanmar Text", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCancelar2.ForeColor = System.Drawing.Color.White;
            this.btCancelar2.Location = new System.Drawing.Point(65, 150);
            this.btCancelar2.Name = "btCancelar2";
            this.btCancelar2.Size = new System.Drawing.Size(105, 33);
            this.btCancelar2.TabIndex = 21;
            this.btCancelar2.Text = "Cancelar";
            this.btCancelar2.UseVisualStyleBackColor = false;
            this.btCancelar2.Click += new System.EventHandler(this.btCancelar2_Click);
            this.btCancelar2.MouseEnter += new System.EventHandler(this.btCancelar2_MouseEnter);
            this.btCancelar2.MouseLeave += new System.EventHandler(this.btCancelar2_MouseLeave);
            // 
            // lblL1
            // 
            this.lblL1.AutoSize = true;
            this.lblL1.Font = new System.Drawing.Font("Myanmar Text", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblL1.ForeColor = System.Drawing.Color.White;
            this.lblL1.Location = new System.Drawing.Point(20, 92);
            this.lblL1.Name = "lblL1";
            this.lblL1.Size = new System.Drawing.Size(343, 34);
            this.lblL1.TabIndex = 14;
            this.lblL1.Text = "Deseja mesmo excluir está mensagem?";
            this.lblL1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btConfirmar
            // 
            this.btConfirmar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.btConfirmar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.btConfirmar.FlatAppearance.BorderSize = 0;
            this.btConfirmar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(189)))), ((int)(((byte)(251)))));
            this.btConfirmar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(189)))), ((int)(((byte)(251)))));
            this.btConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btConfirmar.Font = new System.Drawing.Font("Myanmar Text", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btConfirmar.ForeColor = System.Drawing.Color.White;
            this.btConfirmar.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btConfirmar.Location = new System.Drawing.Point(217, 151);
            this.btConfirmar.Name = "btConfirmar";
            this.btConfirmar.Size = new System.Drawing.Size(105, 33);
            this.btConfirmar.TabIndex = 19;
            this.btConfirmar.Text = "Confirmar";
            this.btConfirmar.UseVisualStyleBackColor = false;
            this.btConfirmar.Click += new System.EventHandler(this.btConfirmar_Click);
            this.btConfirmar.MouseEnter += new System.EventHandler(this.btConfirmar_MouseEnter);
            this.btConfirmar.MouseLeave += new System.EventHandler(this.btConfirmar_MouseLeave);
            // 
            // pbL1
            // 
            this.pbL1.Image = global::Pismire_TCC.Properties.Resources.excluir;
            this.pbL1.Location = new System.Drawing.Point(172, 21);
            this.pbL1.Name = "pbL1";
            this.pbL1.Size = new System.Drawing.Size(49, 40);
            this.pbL1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbL1.TabIndex = 13;
            this.pbL1.TabStop = false;
            // 
            // btConfirmar2
            // 
            this.btConfirmar2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.btConfirmar2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.btConfirmar2.FlatAppearance.BorderSize = 0;
            this.btConfirmar2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(189)))), ((int)(((byte)(251)))));
            this.btConfirmar2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(189)))), ((int)(((byte)(251)))));
            this.btConfirmar2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btConfirmar2.Font = new System.Drawing.Font("Myanmar Text", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btConfirmar2.ForeColor = System.Drawing.Color.White;
            this.btConfirmar2.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btConfirmar2.Location = new System.Drawing.Point(217, 151);
            this.btConfirmar2.Name = "btConfirmar2";
            this.btConfirmar2.Size = new System.Drawing.Size(105, 33);
            this.btConfirmar2.TabIndex = 20;
            this.btConfirmar2.Text = "Confirmar";
            this.btConfirmar2.UseVisualStyleBackColor = false;
            this.btConfirmar2.Click += new System.EventHandler(this.btConfirmar2_Click);
            this.btConfirmar2.MouseEnter += new System.EventHandler(this.btConfirmar2_MouseEnter);
            this.btConfirmar2.MouseLeave += new System.EventHandler(this.btConfirmar2_MouseLeave);
            // 
            // pLimparAberto
            // 
            this.pLimparAberto.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pLimparAberto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(92)))));
            this.pLimparAberto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pLimparAberto.Controls.Add(this.btCancelar);
            this.pLimparAberto.Controls.Add(this.btConfirmar2);
            this.pLimparAberto.Controls.Add(this.lblL2);
            this.pLimparAberto.Controls.Add(this.pbL2);
            this.pLimparAberto.Location = new System.Drawing.Point(500, 247);
            this.pLimparAberto.Name = "pLimparAberto";
            this.pLimparAberto.Size = new System.Drawing.Size(390, 217);
            this.pLimparAberto.TabIndex = 25;
            this.pLimparAberto.Visible = false;
            // 
            // btCancelar
            // 
            this.btCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.btCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.btCancelar.FlatAppearance.BorderSize = 0;
            this.btCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(189)))), ((int)(((byte)(251)))));
            this.btCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(189)))), ((int)(((byte)(251)))));
            this.btCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCancelar.Font = new System.Drawing.Font("Myanmar Text", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCancelar.ForeColor = System.Drawing.Color.White;
            this.btCancelar.Location = new System.Drawing.Point(65, 150);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(105, 33);
            this.btCancelar.TabIndex = 20;
            this.btCancelar.Text = "Cancelar";
            this.btCancelar.UseVisualStyleBackColor = false;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            this.btCancelar.MouseEnter += new System.EventHandler(this.btCancelar_MouseEnter);
            this.btCancelar.MouseLeave += new System.EventHandler(this.btCancelar_MouseLeave);
            // 
            // lblL2
            // 
            this.lblL2.Font = new System.Drawing.Font("Myanmar Text", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblL2.ForeColor = System.Drawing.Color.White;
            this.lblL2.Location = new System.Drawing.Point(22, 64);
            this.lblL2.Name = "lblL2";
            this.lblL2.Size = new System.Drawing.Size(347, 79);
            this.lblL2.TabIndex = 14;
            this.lblL2.Text = "Deseja mesmo excluir todas as mensagens?";
            this.lblL2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbL2
            // 
            this.pbL2.Image = global::Pismire_TCC.Properties.Resources.excluir;
            this.pbL2.Location = new System.Drawing.Point(172, 21);
            this.pbL2.Name = "pbL2";
            this.pbL2.Size = new System.Drawing.Size(49, 40);
            this.pbL2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbL2.TabIndex = 13;
            this.pbL2.TabStop = false;
            // 
            // lblDesativado
            // 
            this.lblDesativado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDesativado.AutoSize = true;
            this.lblDesativado.Font = new System.Drawing.Font("Myanmar Text", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesativado.ForeColor = System.Drawing.Color.White;
            this.lblDesativado.Location = new System.Drawing.Point(126, 679);
            this.lblDesativado.Name = "lblDesativado";
            this.lblDesativado.Size = new System.Drawing.Size(149, 34);
            this.lblDesativado.TabIndex = 26;
            this.lblDesativado.Text = "Não visualizado";
            // 
            // lblAtivado
            // 
            this.lblAtivado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAtivado.AutoSize = true;
            this.lblAtivado.Font = new System.Drawing.Font("Myanmar Text", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAtivado.ForeColor = System.Drawing.Color.White;
            this.lblAtivado.Location = new System.Drawing.Point(126, 679);
            this.lblAtivado.Name = "lblAtivado";
            this.lblAtivado.Size = new System.Drawing.Size(112, 34);
            this.lblAtivado.TabIndex = 27;
            this.lblAtivado.Text = "Visualizado";
            this.lblAtivado.Visible = false;
            // 
            // pbLixeira
            // 
            this.pbLixeira.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pbLixeira.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbLixeira.Image = global::Pismire_TCC.Properties.Resources.excluir;
            this.pbLixeira.Location = new System.Drawing.Point(50, 674);
            this.pbLixeira.Name = "pbLixeira";
            this.pbLixeira.Size = new System.Drawing.Size(35, 35);
            this.pbLixeira.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLixeira.TabIndex = 22;
            this.pbLixeira.TabStop = false;
            this.pbLixeira.Click += new System.EventHandler(this.pbLixeira_Click);
            this.pbLixeira.MouseEnter += new System.EventHandler(this.pbLixeira_MouseEnter);
            this.pbLixeira.MouseLeave += new System.EventHandler(this.pbLixeira_MouseLeave);
            // 
            // p_barra
            // 
            this.p_barra.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.p_barra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(92)))));
            this.p_barra.Controls.Add(this.pb_voltar);
            this.p_barra.Controls.Add(this.lbl_notificacao);
            this.p_barra.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(92)))));
            this.p_barra.Location = new System.Drawing.Point(0, 21);
            this.p_barra.Name = "p_barra";
            this.p_barra.Size = new System.Drawing.Size(1402, 65);
            this.p_barra.TabIndex = 28;
            this.p_barra.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.p_barra.Resize += new System.EventHandler(this.p_barra_Resize_1);
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
            // lbl_notificacao
            // 
            this.lbl_notificacao.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_notificacao.AutoSize = true;
            this.lbl_notificacao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(92)))));
            this.lbl_notificacao.Font = new System.Drawing.Font("Myanmar Text", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_notificacao.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbl_notificacao.Location = new System.Drawing.Point(654, 10);
            this.lbl_notificacao.Name = "lbl_notificacao";
            this.lbl_notificacao.Size = new System.Drawing.Size(185, 56);
            this.lbl_notificacao.TabIndex = 0;
            this.lbl_notificacao.Text = "Notificação";
            this.lbl_notificacao.TextAlign = System.Drawing.ContentAlignment.TopCenter;
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
            this.pnBarraDeCima.Size = new System.Drawing.Size(1402, 21);
            this.pnBarraDeCima.TabIndex = 31;
            // 
            // pbMinimizar
            // 
            this.pbMinimizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbMinimizar.Image = global::Pismire_TCC.Properties.Resources.minimizar;
            this.pbMinimizar.Location = new System.Drawing.Point(1296, 2);
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
            this.pbMaximizar.Location = new System.Drawing.Point(1330, 2);
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
            this.pbFechar.Location = new System.Drawing.Point(1364, 2);
            this.pbFechar.Name = "pbFechar";
            this.pbFechar.Size = new System.Drawing.Size(33, 16);
            this.pbFechar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbFechar.TabIndex = 0;
            this.pbFechar.TabStop = false;
            this.pbFechar.Click += new System.EventHandler(this.pbFechar_Click);
            this.pbFechar.MouseEnter += new System.EventHandler(this.pbFechar_MouseEnter);
            this.pbFechar.MouseLeave += new System.EventHandler(this.pbFechar_MouseLeave);
            // 
            // TelaNotificacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.ClientSize = new System.Drawing.Size(1400, 750);
            this.Controls.Add(this.pnBarraDeCima);
            this.Controls.Add(this.p_barra);
            this.Controls.Add(this.lblAtivado);
            this.Controls.Add(this.lblDesativado);
            this.Controls.Add(this.pLimparAberto);
            this.Controls.Add(this.pLixeira);
            this.Controls.Add(this.lblAviso);
            this.Controls.Add(this.pbLixeira);
            this.Controls.Add(this.dt);
            this.Controls.Add(this.btLimpar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TelaNotificacao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pismire";
            ((System.ComponentModel.ISupportInitialize)(this.dt)).EndInit();
            this.pLixeira.ResumeLayout(false);
            this.pLixeira.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbL1)).EndInit();
            this.pLimparAberto.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbL2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLixeira)).EndInit();
            this.p_barra.ResumeLayout(false);
            this.p_barra.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_voltar)).EndInit();
            this.pnBarraDeCima.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbMinimizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMaximizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFechar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btLimpar;
        private System.Windows.Forms.PictureBox pbLixeira;
        public System.Windows.Forms.Label lblAviso;
        public System.Windows.Forms.DataGridView dt;
        private System.Windows.Forms.Panel pLixeira;
        private System.Windows.Forms.Label lblL1;
        private System.Windows.Forms.PictureBox pbL1;
        private System.Windows.Forms.Panel pLimparAberto;
        private System.Windows.Forms.Label lblL2;
        private System.Windows.Forms.PictureBox pbL2;
        private System.Windows.Forms.Label lblDesativado;
        private System.Windows.Forms.Label lblAtivado;
        private System.Windows.Forms.Button btConfirmar;
        private System.Windows.Forms.Button btCancelar;
        private System.Windows.Forms.Button btCancelar2;
        private System.Windows.Forms.Button btConfirmar2;
        private System.Windows.Forms.Panel p_barra;
        private System.Windows.Forms.PictureBox pb_voltar;
        private System.Windows.Forms.Label lbl_notificacao;
        private System.Windows.Forms.Panel pnBarraDeCima;
        private System.Windows.Forms.PictureBox pbMinimizar;
        private System.Windows.Forms.PictureBox pbMaximizar;
        private System.Windows.Forms.PictureBox pbFechar;
    }
}