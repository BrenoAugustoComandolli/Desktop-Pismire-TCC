namespace Pismire_TCC
{
    partial class TelaInscricoes
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaInscricoes));
            this.lbl_Inscricao = new System.Windows.Forms.Label();
            this.p_barra = new System.Windows.Forms.Panel();
            this.pb_voltar = new System.Windows.Forms.PictureBox();
            this.pCabecalho = new System.Windows.Forms.Panel();
            this.lblCabecalho4 = new System.Windows.Forms.Label();
            this.lblCabecalho3 = new System.Windows.Forms.Label();
            this.lblCabecalho2 = new System.Windows.Forms.Label();
            this.lblCabecalho1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pLimparAberto = new System.Windows.Forms.Panel();
            this.btCancelar = new System.Windows.Forms.Button();
            this.btConfirmar2 = new System.Windows.Forms.Button();
            this.lblL2 = new System.Windows.Forms.Label();
            this.pbL2 = new System.Windows.Forms.PictureBox();
            this.dtInscricoes = new System.Windows.Forms.DataGridView();
            this.pnLixeira = new System.Windows.Forms.Panel();
            this.pbLixeira = new System.Windows.Forms.PictureBox();
            this.pbChat = new System.Windows.Forms.PictureBox();
            this.pnBarraDeCima = new System.Windows.Forms.Panel();
            this.pbMinimizar = new System.Windows.Forms.PictureBox();
            this.pbMaximizar = new System.Windows.Forms.PictureBox();
            this.pbFechar = new System.Windows.Forms.PictureBox();
            this.lblAviso = new System.Windows.Forms.Label();
            this.p_barra.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_voltar)).BeginInit();
            this.pCabecalho.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pLimparAberto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbL2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtInscricoes)).BeginInit();
            this.pnLixeira.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLixeira)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbChat)).BeginInit();
            this.pnBarraDeCima.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMinimizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMaximizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFechar)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_Inscricao
            // 
            this.lbl_Inscricao.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Inscricao.AutoSize = true;
            this.lbl_Inscricao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(92)))));
            this.lbl_Inscricao.Font = new System.Drawing.Font("Myanmar Text", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Inscricao.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbl_Inscricao.Location = new System.Drawing.Point(642, 10);
            this.lbl_Inscricao.Name = "lbl_Inscricao";
            this.lbl_Inscricao.Size = new System.Drawing.Size(149, 56);
            this.lbl_Inscricao.TabIndex = 0;
            this.lbl_Inscricao.Text = "Inscrição";
            this.lbl_Inscricao.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // p_barra
            // 
            this.p_barra.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.p_barra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(92)))));
            this.p_barra.Controls.Add(this.pb_voltar);
            this.p_barra.Controls.Add(this.lbl_Inscricao);
            this.p_barra.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(92)))));
            this.p_barra.Location = new System.Drawing.Point(1, 19);
            this.p_barra.Name = "p_barra";
            this.p_barra.Size = new System.Drawing.Size(1418, 65);
            this.p_barra.TabIndex = 29;
            this.p_barra.Paint += new System.Windows.Forms.PaintEventHandler(this.p_barra_Paint);
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
            this.pb_voltar.Click += new System.EventHandler(this.pb_voltar_Click);
            this.pb_voltar.MouseEnter += new System.EventHandler(this.pb_voltar_MouseEnter);
            this.pb_voltar.MouseLeave += new System.EventHandler(this.pb_voltar_MouseLeave);
            this.pb_voltar.MouseHover += new System.EventHandler(this.pb_voltar_MouseHover);
            // 
            // pCabecalho
            // 
            this.pCabecalho.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pCabecalho.BackColor = System.Drawing.Color.MediumPurple;
            this.pCabecalho.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pCabecalho.Controls.Add(this.lblCabecalho4);
            this.pCabecalho.Controls.Add(this.lblCabecalho3);
            this.pCabecalho.Controls.Add(this.lblCabecalho2);
            this.pCabecalho.Controls.Add(this.lblCabecalho1);
            this.pCabecalho.Location = new System.Drawing.Point(99, 133);
            this.pCabecalho.Name = "pCabecalho";
            this.pCabecalho.Size = new System.Drawing.Size(1202, 62);
            this.pCabecalho.TabIndex = 31;
            // 
            // lblCabecalho4
            // 
            this.lblCabecalho4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCabecalho4.Font = new System.Drawing.Font("Myanmar Text", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCabecalho4.Location = new System.Drawing.Point(901, 15);
            this.lblCabecalho4.Name = "lblCabecalho4";
            this.lblCabecalho4.Size = new System.Drawing.Size(300, 43);
            this.lblCabecalho4.TabIndex = 3;
            this.lblCabecalho4.Text = "Salário";
            this.lblCabecalho4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCabecalho3
            // 
            this.lblCabecalho3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCabecalho3.Font = new System.Drawing.Font("Myanmar Text", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCabecalho3.Location = new System.Drawing.Point(601, 15);
            this.lblCabecalho3.Name = "lblCabecalho3";
            this.lblCabecalho3.Size = new System.Drawing.Size(300, 43);
            this.lblCabecalho3.TabIndex = 2;
            this.lblCabecalho3.Text = "Cargo";
            this.lblCabecalho3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCabecalho2
            // 
            this.lblCabecalho2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCabecalho2.Font = new System.Drawing.Font("Myanmar Text", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCabecalho2.Location = new System.Drawing.Point(302, 15);
            this.lblCabecalho2.Name = "lblCabecalho2";
            this.lblCabecalho2.Size = new System.Drawing.Size(300, 43);
            this.lblCabecalho2.TabIndex = 1;
            this.lblCabecalho2.Text = "Empresa";
            this.lblCabecalho2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCabecalho1
            // 
            this.lblCabecalho1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCabecalho1.Font = new System.Drawing.Font("Myanmar Text", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCabecalho1.Location = new System.Drawing.Point(2, 15);
            this.lblCabecalho1.Name = "lblCabecalho1";
            this.lblCabecalho1.Size = new System.Drawing.Size(300, 43);
            this.lblCabecalho1.TabIndex = 0;
            this.lblCabecalho1.Text = "Expiração";
            this.lblCabecalho1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.panel2.Controls.Add(this.pLimparAberto);
            this.panel2.Controls.Add(this.dtInscricoes);
            this.panel2.Location = new System.Drawing.Point(99, 194);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1202, 342);
            this.panel2.TabIndex = 30;
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
            this.pLimparAberto.Location = new System.Drawing.Point(419, 62);
            this.pLimparAberto.Name = "pLimparAberto";
            this.pLimparAberto.Size = new System.Drawing.Size(390, 217);
            this.pLimparAberto.TabIndex = 38;
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
            // 
            // lblL2
            // 
            this.lblL2.Font = new System.Drawing.Font("Myanmar Text", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblL2.ForeColor = System.Drawing.Color.White;
            this.lblL2.Location = new System.Drawing.Point(22, 64);
            this.lblL2.Name = "lblL2";
            this.lblL2.Size = new System.Drawing.Size(347, 79);
            this.lblL2.TabIndex = 14;
            this.lblL2.Text = "Deseja mesmo excluir essa empresa?";
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
            // dtInscricoes
            // 
            this.dtInscricoes.AllowUserToAddRows = false;
            this.dtInscricoes.AllowUserToDeleteRows = false;
            this.dtInscricoes.AllowUserToResizeColumns = false;
            this.dtInscricoes.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Transparent;
            this.dtInscricoes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtInscricoes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtInscricoes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtInscricoes.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dtInscricoes.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.dtInscricoes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtInscricoes.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dtInscricoes.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dtInscricoes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.MediumPurple;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.MediumPurple;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            this.dtInscricoes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtInscricoes.ColumnHeadersHeight = 50;
            this.dtInscricoes.ColumnHeadersVisible = false;
            this.dtInscricoes.Cursor = System.Windows.Forms.Cursors.Arrow;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(20);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtInscricoes.DefaultCellStyle = dataGridViewCellStyle3;
            this.dtInscricoes.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.dtInscricoes.EnableHeadersVisualStyles = false;
            this.dtInscricoes.GridColor = System.Drawing.Color.White;
            this.dtInscricoes.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.dtInscricoes.Location = new System.Drawing.Point(0, 1);
            this.dtInscricoes.MultiSelect = false;
            this.dtInscricoes.Name = "dtInscricoes";
            this.dtInscricoes.ReadOnly = true;
            this.dtInscricoes.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtInscricoes.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(15);
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtInscricoes.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dtInscricoes.RowHeadersVisible = false;
            this.dtInscricoes.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtInscricoes.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dtInscricoes.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.dtInscricoes.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtInscricoes.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dtInscricoes.RowTemplate.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(15);
            this.dtInscricoes.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Gray;
            this.dtInscricoes.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dtInscricoes.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dtInscricoes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtInscricoes.ShowCellErrors = false;
            this.dtInscricoes.ShowCellToolTips = false;
            this.dtInscricoes.ShowEditingIcon = false;
            this.dtInscricoes.ShowRowErrors = false;
            this.dtInscricoes.Size = new System.Drawing.Size(1202, 340);
            this.dtInscricoes.TabIndex = 0;
            this.dtInscricoes.TabStop = false;
            // 
            // pnLixeira
            // 
            this.pnLixeira.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pnLixeira.Controls.Add(this.pbLixeira);
            this.pnLixeira.Location = new System.Drawing.Point(1274, 662);
            this.pnLixeira.Name = "pnLixeira";
            this.pnLixeira.Size = new System.Drawing.Size(78, 62);
            this.pnLixeira.TabIndex = 33;
            this.pnLixeira.Click += new System.EventHandler(this.pnLixeira_Click);
            this.pnLixeira.MouseEnter += new System.EventHandler(this.pnLixeira_MouseEnter);
            this.pnLixeira.MouseLeave += new System.EventHandler(this.pnLixeira_MouseLeave);
            this.pnLixeira.MouseHover += new System.EventHandler(this.pnLixeira_MouseHover);
            // 
            // pbLixeira
            // 
            this.pbLixeira.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pbLixeira.Image = global::Pismire_TCC.Properties.Resources.excluir;
            this.pbLixeira.Location = new System.Drawing.Point(18, 11);
            this.pbLixeira.Name = "pbLixeira";
            this.pbLixeira.Size = new System.Drawing.Size(44, 38);
            this.pbLixeira.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLixeira.TabIndex = 3;
            this.pbLixeira.TabStop = false;
            this.pbLixeira.Click += new System.EventHandler(this.pbLixeira_Click);
            this.pbLixeira.MouseEnter += new System.EventHandler(this.pbLixeira_MouseEnter);
            this.pbLixeira.MouseLeave += new System.EventHandler(this.pbLixeira_MouseLeave);
            this.pbLixeira.MouseHover += new System.EventHandler(this.pbLixeira_MouseHover);
            // 
            // pbChat
            // 
            this.pbChat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pbChat.Image = global::Pismire_TCC.Properties.Resources.chatAzul;
            this.pbChat.Location = new System.Drawing.Point(1187, 662);
            this.pbChat.Name = "pbChat";
            this.pbChat.Size = new System.Drawing.Size(81, 62);
            this.pbChat.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbChat.TabIndex = 32;
            this.pbChat.TabStop = false;
            this.pbChat.Click += new System.EventHandler(this.pbChat_Click);
            this.pbChat.MouseEnter += new System.EventHandler(this.pbChat_MouseEnter);
            this.pbChat.MouseLeave += new System.EventHandler(this.pbChat_MouseLeave);
            // 
            // pnBarraDeCima
            // 
            this.pnBarraDeCima.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnBarraDeCima.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(62)))), ((int)(((byte)(85)))));
            this.pnBarraDeCima.Controls.Add(this.pbMinimizar);
            this.pnBarraDeCima.Controls.Add(this.pbMaximizar);
            this.pnBarraDeCima.Controls.Add(this.pbFechar);
            this.pnBarraDeCima.Location = new System.Drawing.Point(1, -1);
            this.pnBarraDeCima.Name = "pnBarraDeCima";
            this.pnBarraDeCima.Size = new System.Drawing.Size(1402, 21);
            this.pnBarraDeCima.TabIndex = 34;
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
            this.pbMinimizar.MouseHover += new System.EventHandler(this.pbMinimizar_MouseHover);
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
            this.pbMaximizar.MouseHover += new System.EventHandler(this.pbMaximizar_MouseHover);
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
            this.pbFechar.MouseHover += new System.EventHandler(this.pbFechar_MouseHover);
            // 
            // lblAviso
            // 
            this.lblAviso.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblAviso.AutoSize = true;
            this.lblAviso.Font = new System.Drawing.Font("Myanmar Text", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAviso.ForeColor = System.Drawing.Color.White;
            this.lblAviso.Location = new System.Drawing.Point(535, 334);
            this.lblAviso.Name = "lblAviso";
            this.lblAviso.Size = new System.Drawing.Size(343, 65);
            this.lblAviso.TabIndex = 26;
            this.lblAviso.Text = "Nenhuma Inscrição";
            this.lblAviso.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAviso.Visible = false;
            // 
            // TelaInscricoes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.ClientSize = new System.Drawing.Size(1400, 750);
            this.Controls.Add(this.lblAviso);
            this.Controls.Add(this.pnBarraDeCima);
            this.Controls.Add(this.pnLixeira);
            this.Controls.Add(this.pbChat);
            this.Controls.Add(this.pCabecalho);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.p_barra);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TelaInscricoes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pismire";
            this.p_barra.ResumeLayout(false);
            this.p_barra.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_voltar)).EndInit();
            this.pCabecalho.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.pLimparAberto.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbL2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtInscricoes)).EndInit();
            this.pnLixeira.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLixeira)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbChat)).EndInit();
            this.pnBarraDeCima.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbMinimizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMaximizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFechar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pb_voltar;
        private System.Windows.Forms.Label lbl_Inscricao;
        private System.Windows.Forms.Panel p_barra;
        private System.Windows.Forms.Panel pCabecalho;
        private System.Windows.Forms.Label lblCabecalho4;
        private System.Windows.Forms.Label lblCabecalho3;
        private System.Windows.Forms.Label lblCabecalho2;
        private System.Windows.Forms.Label lblCabecalho1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dtInscricoes;
        private System.Windows.Forms.Panel pnLixeira;
        private System.Windows.Forms.PictureBox pbLixeira;
        private System.Windows.Forms.PictureBox pbChat;
        private System.Windows.Forms.Panel pnBarraDeCima;
        private System.Windows.Forms.PictureBox pbMinimizar;
        private System.Windows.Forms.PictureBox pbMaximizar;
        private System.Windows.Forms.PictureBox pbFechar;
        public System.Windows.Forms.Label lblAviso;
        private System.Windows.Forms.Panel pLimparAberto;
        private System.Windows.Forms.Button btCancelar;
        private System.Windows.Forms.Button btConfirmar2;
        private System.Windows.Forms.Label lblL2;
        private System.Windows.Forms.PictureBox pbL2;
    }
}