namespace Pismire_TCC
{
    partial class TelaCandidatos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaCandidatos));
            this.p_barra = new System.Windows.Forms.Panel();
            this.pb_voltar = new System.Windows.Forms.PictureBox();
            this.lblCandidatos = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dt = new System.Windows.Forms.DataGridView();
            this.pCabecalho = new System.Windows.Forms.Panel();
            this.lblCabecalho1 = new System.Windows.Forms.Label();
            this.lblCabecalho4 = new System.Windows.Forms.Label();
            this.lblCabecalho2 = new System.Windows.Forms.Label();
            this.lblCabecalho3 = new System.Windows.Forms.Label();
            this.pb_chat = new System.Windows.Forms.PictureBox();
            this.pbLixeira = new System.Windows.Forms.PictureBox();
            this.pnLixeira = new System.Windows.Forms.Panel();
            this.pnBarraDeCima = new System.Windows.Forms.Panel();
            this.pbMinimizar = new System.Windows.Forms.PictureBox();
            this.pbMaximizar = new System.Windows.Forms.PictureBox();
            this.pbFechar = new System.Windows.Forms.PictureBox();
            this.lblAviso = new System.Windows.Forms.Label();
            this.pLimparAberto = new System.Windows.Forms.Panel();
            this.btCancelar = new System.Windows.Forms.Button();
            this.btConfirmar = new System.Windows.Forms.Button();
            this.lblL2 = new System.Windows.Forms.Label();
            this.pbL2 = new System.Windows.Forms.PictureBox();
            this.p_barra.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_voltar)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dt)).BeginInit();
            this.pCabecalho.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_chat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLixeira)).BeginInit();
            this.pnLixeira.SuspendLayout();
            this.pnBarraDeCima.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMinimizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMaximizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFechar)).BeginInit();
            this.pLimparAberto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbL2)).BeginInit();
            this.SuspendLayout();
            // 
            // p_barra
            // 
            this.p_barra.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.p_barra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(92)))));
            this.p_barra.Controls.Add(this.pb_voltar);
            this.p_barra.Controls.Add(this.lblCandidatos);
            this.p_barra.Location = new System.Drawing.Point(0, 21);
            this.p_barra.Name = "p_barra";
            this.p_barra.Size = new System.Drawing.Size(1400, 65);
            this.p_barra.TabIndex = 0;
            this.p_barra.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.p_barra.Resize += new System.EventHandler(this.p_barra_Resize);
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
            this.pb_voltar.Click += new System.EventHandler(this.pbVoltar_Click);
            this.pb_voltar.MouseEnter += new System.EventHandler(this.pbVoltar_MouseEnter);
            this.pb_voltar.MouseLeave += new System.EventHandler(this.pbVoltar_MouseLeave);
            // 
            // lblCandidatos
            // 
            this.lblCandidatos.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblCandidatos.AutoSize = true;
            this.lblCandidatos.Font = new System.Drawing.Font("Myanmar Text", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCandidatos.ForeColor = System.Drawing.Color.White;
            this.lblCandidatos.Location = new System.Drawing.Point(632, 12);
            this.lblCandidatos.Name = "lblCandidatos";
            this.lblCandidatos.Size = new System.Drawing.Size(184, 56);
            this.lblCandidatos.TabIndex = 0;
            this.lblCandidatos.Text = "Candidatos";
            this.lblCandidatos.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.dt);
            this.panel2.Location = new System.Drawing.Point(87, 192);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1219, 440);
            this.panel2.TabIndex = 2;
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
            this.dt.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dt.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.dt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dt.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dt.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dt.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.MediumPurple;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Myanmar Text", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(15);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.MediumPurple;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dt.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dt.ColumnHeadersVisible = false;
            this.dt.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.dt.EnableHeadersVisualStyles = false;
            this.dt.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.dt.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.dt.Location = new System.Drawing.Point(1, 1);
            this.dt.MultiSelect = false;
            this.dt.Name = "dt";
            this.dt.ReadOnly = true;
            this.dt.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dt.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dt.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dt.RowHeadersVisible = false;
            this.dt.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.dt.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dt.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.dt.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.dt.Size = new System.Drawing.Size(1218, 437);
            this.dt.TabIndex = 0;
            this.dt.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dt_CellDoubleClick);
            this.dt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dt_KeyDown);
            // 
            // pCabecalho
            // 
            this.pCabecalho.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pCabecalho.BackColor = System.Drawing.Color.MediumPurple;
            this.pCabecalho.Controls.Add(this.lblCabecalho1);
            this.pCabecalho.Controls.Add(this.lblCabecalho4);
            this.pCabecalho.Controls.Add(this.lblCabecalho2);
            this.pCabecalho.Controls.Add(this.lblCabecalho3);
            this.pCabecalho.Location = new System.Drawing.Point(87, 131);
            this.pCabecalho.Name = "pCabecalho";
            this.pCabecalho.Size = new System.Drawing.Size(1218, 62);
            this.pCabecalho.TabIndex = 9;
            this.pCabecalho.Paint += new System.Windows.Forms.PaintEventHandler(this.pCabecalho_Paint);
            this.pCabecalho.Resize += new System.EventHandler(this.pCabecalho_Resize);
            // 
            // lblCabecalho1
            // 
            this.lblCabecalho1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblCabecalho1.Font = new System.Drawing.Font("Myanmar Text", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCabecalho1.ForeColor = System.Drawing.Color.Black;
            this.lblCabecalho1.Location = new System.Drawing.Point(10, 15);
            this.lblCabecalho1.Name = "lblCabecalho1";
            this.lblCabecalho1.Size = new System.Drawing.Size(300, 43);
            this.lblCabecalho1.TabIndex = 0;
            this.lblCabecalho1.Text = "Candidato";
            this.lblCabecalho1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCabecalho4
            // 
            this.lblCabecalho4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCabecalho4.Font = new System.Drawing.Font("Myanmar Text", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCabecalho4.ForeColor = System.Drawing.Color.Black;
            this.lblCabecalho4.Location = new System.Drawing.Point(901, 15);
            this.lblCabecalho4.Name = "lblCabecalho4";
            this.lblCabecalho4.Size = new System.Drawing.Size(316, 43);
            this.lblCabecalho4.TabIndex = 3;
            this.lblCabecalho4.Text = "Vaga";
            this.lblCabecalho4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCabecalho2
            // 
            this.lblCabecalho2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCabecalho2.Font = new System.Drawing.Font("Myanmar Text", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCabecalho2.ForeColor = System.Drawing.Color.Black;
            this.lblCabecalho2.Location = new System.Drawing.Point(302, 15);
            this.lblCabecalho2.Name = "lblCabecalho2";
            this.lblCabecalho2.Size = new System.Drawing.Size(316, 43);
            this.lblCabecalho2.TabIndex = 1;
            this.lblCabecalho2.Text = "Qualificação";
            this.lblCabecalho2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCabecalho3
            // 
            this.lblCabecalho3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCabecalho3.Font = new System.Drawing.Font("Myanmar Text", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCabecalho3.ForeColor = System.Drawing.Color.Black;
            this.lblCabecalho3.Location = new System.Drawing.Point(601, 15);
            this.lblCabecalho3.Name = "lblCabecalho3";
            this.lblCabecalho3.Size = new System.Drawing.Size(316, 43);
            this.lblCabecalho3.TabIndex = 2;
            this.lblCabecalho3.Text = "Idioma";
            this.lblCabecalho3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pb_chat
            // 
            this.pb_chat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pb_chat.Image = global::Pismire_TCC.Properties.Resources.chatAzul;
            this.pb_chat.Location = new System.Drawing.Point(1180, 662);
            this.pb_chat.Name = "pb_chat";
            this.pb_chat.Size = new System.Drawing.Size(78, 62);
            this.pb_chat.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_chat.TabIndex = 4;
            this.pb_chat.TabStop = false;
            this.pb_chat.Click += new System.EventHandler(this.pb_chat_Click);
            this.pb_chat.MouseEnter += new System.EventHandler(this.pbChat_MouseEnter);
            this.pb_chat.MouseLeave += new System.EventHandler(this.pbChat_MouseLeave);
            // 
            // pbLixeira
            // 
            this.pbLixeira.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pbLixeira.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbLixeira.Image = global::Pismire_TCC.Properties.Resources.excluir;
            this.pbLixeira.Location = new System.Drawing.Point(23, 14);
            this.pbLixeira.Name = "pbLixeira";
            this.pbLixeira.Size = new System.Drawing.Size(33, 33);
            this.pbLixeira.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLixeira.TabIndex = 23;
            this.pbLixeira.TabStop = false;
            this.pbLixeira.Click += new System.EventHandler(this.pLixeira_Click);
            this.pbLixeira.MouseEnter += new System.EventHandler(this.pbLixeira_MouseEnter);
            this.pbLixeira.MouseLeave += new System.EventHandler(this.pbLixeira_MouseLeave);
            // 
            // pnLixeira
            // 
            this.pnLixeira.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pnLixeira.Controls.Add(this.pbLixeira);
            this.pnLixeira.Location = new System.Drawing.Point(1274, 662);
            this.pnLixeira.Name = "pnLixeira";
            this.pnLixeira.Size = new System.Drawing.Size(78, 62);
            this.pnLixeira.TabIndex = 24;
            this.pnLixeira.Click += new System.EventHandler(this.pLixeira_Click);
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
            // lblAviso
            // 
            this.lblAviso.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblAviso.AutoSize = true;
            this.lblAviso.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAviso.ForeColor = System.Drawing.Color.White;
            this.lblAviso.Location = new System.Drawing.Point(533, 353);
            this.lblAviso.Name = "lblAviso";
            this.lblAviso.Size = new System.Drawing.Size(340, 42);
            this.lblAviso.TabIndex = 33;
            this.lblAviso.Text = "Nenhum Candidato";
            this.lblAviso.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAviso.Visible = false;
            // 
            // pLimparAberto
            // 
            this.pLimparAberto.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pLimparAberto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(92)))));
            this.pLimparAberto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pLimparAberto.Controls.Add(this.btCancelar);
            this.pLimparAberto.Controls.Add(this.btConfirmar);
            this.pLimparAberto.Controls.Add(this.lblL2);
            this.pLimparAberto.Controls.Add(this.pbL2);
            this.pLimparAberto.Location = new System.Drawing.Point(505, 267);
            this.pLimparAberto.Name = "pLimparAberto";
            this.pLimparAberto.Size = new System.Drawing.Size(390, 217);
            this.pLimparAberto.TabIndex = 34;
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
            this.btConfirmar.TabIndex = 20;
            this.btConfirmar.Text = "Confirmar";
            this.btConfirmar.UseVisualStyleBackColor = false;
            this.btConfirmar.Click += new System.EventHandler(this.btConfirmar_Click);
            this.btConfirmar.MouseEnter += new System.EventHandler(this.btConfirmar_MouseEnter);
            this.btConfirmar.MouseLeave += new System.EventHandler(this.btConfirmar_MouseLeave);
            // 
            // lblL2
            // 
            this.lblL2.Font = new System.Drawing.Font("Myanmar Text", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblL2.ForeColor = System.Drawing.Color.White;
            this.lblL2.Location = new System.Drawing.Point(22, 64);
            this.lblL2.Name = "lblL2";
            this.lblL2.Size = new System.Drawing.Size(347, 79);
            this.lblL2.TabIndex = 14;
            this.lblL2.Text = "Deseja mesmo excluir esse currículo dos candidatos?";
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
            // TelaCandidatos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.ClientSize = new System.Drawing.Size(1400, 750);
            this.Controls.Add(this.pLimparAberto);
            this.Controls.Add(this.pnBarraDeCima);
            this.Controls.Add(this.pnLixeira);
            this.Controls.Add(this.pb_chat);
            this.Controls.Add(this.pCabecalho);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.p_barra);
            this.Controls.Add(this.lblAviso);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TelaCandidatos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pismire";
            this.p_barra.ResumeLayout(false);
            this.p_barra.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_voltar)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dt)).EndInit();
            this.pCabecalho.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pb_chat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLixeira)).EndInit();
            this.pnLixeira.ResumeLayout(false);
            this.pnBarraDeCima.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbMinimizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMaximizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFechar)).EndInit();
            this.pLimparAberto.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbL2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel p_barra;
        private System.Windows.Forms.Label lblCandidatos;
        private System.Windows.Forms.PictureBox pb_voltar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dt;
        private System.Windows.Forms.Panel pCabecalho;
        private System.Windows.Forms.Label lblCabecalho1;
        private System.Windows.Forms.Label lblCabecalho2;
        private System.Windows.Forms.Label lblCabecalho4;
        private System.Windows.Forms.Label lblCabecalho3;
        private System.Windows.Forms.PictureBox pb_chat;
        private System.Windows.Forms.PictureBox pbLixeira;
        private System.Windows.Forms.Panel pnLixeira;
        private System.Windows.Forms.Panel pnBarraDeCima;
        private System.Windows.Forms.PictureBox pbMinimizar;
        private System.Windows.Forms.PictureBox pbMaximizar;
        private System.Windows.Forms.PictureBox pbFechar;
        public System.Windows.Forms.Label lblAviso;
        private System.Windows.Forms.Panel pLimparAberto;
        private System.Windows.Forms.Button btCancelar;
        private System.Windows.Forms.Button btConfirmar;
        private System.Windows.Forms.Label lblL2;
        private System.Windows.Forms.PictureBox pbL2;
    }
}

