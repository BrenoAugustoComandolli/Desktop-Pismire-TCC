namespace Pismire_TCC
{
    partial class TelaConfiguracao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaConfiguracao));
            this.p_barra = new System.Windows.Forms.Panel();
            this.lbl_configuracao = new System.Windows.Forms.Label();
            this.lbl_notificacao = new System.Windows.Forms.Label();
            this.lbl_privacidade = new System.Windows.Forms.Label();
            this.lbl_seguranca = new System.Windows.Forms.Label();
            this.lbl_ajuda = new System.Windows.Forms.Label();
            this.lbl_sobre = new System.Windows.Forms.Label();
            this.pbNotificacao = new System.Windows.Forms.Panel();
            this.pnPrivacidade = new System.Windows.Forms.Panel();
            this.pnSeguranca = new System.Windows.Forms.Panel();
            this.pnAjuda = new System.Windows.Forms.Panel();
            this.pnSobre = new System.Windows.Forms.Panel();
            this.pnBarraDeCima = new System.Windows.Forms.Panel();
            this.lbl_localizacao = new System.Windows.Forms.Label();
            this.pnLocalizacao = new System.Windows.Forms.Panel();
            this.pb_localizacao = new System.Windows.Forms.PictureBox();
            this.pbMinimizar = new System.Windows.Forms.PictureBox();
            this.pbMaximizar = new System.Windows.Forms.PictureBox();
            this.pbFechar = new System.Windows.Forms.PictureBox();
            this.pb_sobre = new System.Windows.Forms.PictureBox();
            this.pb_ajuda = new System.Windows.Forms.PictureBox();
            this.pb_seguranca = new System.Windows.Forms.PictureBox();
            this.pb_privacidade = new System.Windows.Forms.PictureBox();
            this.pb_notificacao = new System.Windows.Forms.PictureBox();
            this.pb_voltar = new System.Windows.Forms.PictureBox();
            this.p_barra.SuspendLayout();
            this.pbNotificacao.SuspendLayout();
            this.pnPrivacidade.SuspendLayout();
            this.pnSeguranca.SuspendLayout();
            this.pnAjuda.SuspendLayout();
            this.pnSobre.SuspendLayout();
            this.pnBarraDeCima.SuspendLayout();
            this.pnLocalizacao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_localizacao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMinimizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMaximizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFechar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_sobre)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_ajuda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_seguranca)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_privacidade)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_notificacao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_voltar)).BeginInit();
            this.SuspendLayout();
            // 
            // p_barra
            // 
            this.p_barra.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.p_barra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(92)))));
            this.p_barra.Controls.Add(this.pb_voltar);
            this.p_barra.Controls.Add(this.lbl_configuracao);
            this.p_barra.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(92)))));
            this.p_barra.Location = new System.Drawing.Point(0, 21);
            this.p_barra.Name = "p_barra";
            this.p_barra.Size = new System.Drawing.Size(1402, 65);
            this.p_barra.TabIndex = 0;
            this.p_barra.Paint += new System.Windows.Forms.PaintEventHandler(this.p_barra_Paint);
            this.p_barra.Resize += new System.EventHandler(this.p_barra_Resize);
            // 
            // lbl_configuracao
            // 
            this.lbl_configuracao.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_configuracao.AutoSize = true;
            this.lbl_configuracao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(92)))));
            this.lbl_configuracao.Font = new System.Drawing.Font("Myanmar Text", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_configuracao.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbl_configuracao.Location = new System.Drawing.Point(654, 10);
            this.lbl_configuracao.Name = "lbl_configuracao";
            this.lbl_configuracao.Size = new System.Drawing.Size(228, 56);
            this.lbl_configuracao.TabIndex = 0;
            this.lbl_configuracao.Text = "Configurações";
            this.lbl_configuracao.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbl_notificacao
            // 
            this.lbl_notificacao.AutoSize = true;
            this.lbl_notificacao.Font = new System.Drawing.Font("Myanmar Text", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_notificacao.ForeColor = System.Drawing.Color.White;
            this.lbl_notificacao.Location = new System.Drawing.Point(35, 2);
            this.lbl_notificacao.Name = "lbl_notificacao";
            this.lbl_notificacao.Size = new System.Drawing.Size(119, 34);
            this.lbl_notificacao.TabIndex = 2;
            this.lbl_notificacao.Text = "Notificações";
            this.lbl_notificacao.Click += new System.EventHandler(this.pbNotificacao_Click);
            this.lbl_notificacao.MouseEnter += new System.EventHandler(this.pbNotificacao_MouseEnter);
            this.lbl_notificacao.MouseLeave += new System.EventHandler(this.pbNotificacao_MouseLeave);
            // 
            // lbl_privacidade
            // 
            this.lbl_privacidade.AutoSize = true;
            this.lbl_privacidade.Font = new System.Drawing.Font("Myanmar Text", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_privacidade.ForeColor = System.Drawing.Color.White;
            this.lbl_privacidade.Location = new System.Drawing.Point(35, 2);
            this.lbl_privacidade.Name = "lbl_privacidade";
            this.lbl_privacidade.Size = new System.Drawing.Size(113, 34);
            this.lbl_privacidade.TabIndex = 4;
            this.lbl_privacidade.Text = "Privacidade";
            this.lbl_privacidade.Click += new System.EventHandler(this.pnPrivacidade_Click);
            this.lbl_privacidade.MouseEnter += new System.EventHandler(this.pnPrivacidade_MouseEnter);
            this.lbl_privacidade.MouseLeave += new System.EventHandler(this.pnPrivacidade_MouseLeave);
            // 
            // lbl_seguranca
            // 
            this.lbl_seguranca.AutoSize = true;
            this.lbl_seguranca.Font = new System.Drawing.Font("Myanmar Text", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_seguranca.ForeColor = System.Drawing.Color.White;
            this.lbl_seguranca.Location = new System.Drawing.Point(35, 1);
            this.lbl_seguranca.Name = "lbl_seguranca";
            this.lbl_seguranca.Size = new System.Drawing.Size(104, 34);
            this.lbl_seguranca.TabIndex = 6;
            this.lbl_seguranca.Text = "Segurança";
            this.lbl_seguranca.Click += new System.EventHandler(this.pnSeguranca_Click);
            this.lbl_seguranca.MouseEnter += new System.EventHandler(this.pnSeguranca_MouseEnter);
            this.lbl_seguranca.MouseLeave += new System.EventHandler(this.pnSeguranca_MouseLeave);
            // 
            // lbl_ajuda
            // 
            this.lbl_ajuda.AutoSize = true;
            this.lbl_ajuda.Font = new System.Drawing.Font("Myanmar Text", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ajuda.ForeColor = System.Drawing.Color.White;
            this.lbl_ajuda.Location = new System.Drawing.Point(35, 0);
            this.lbl_ajuda.Name = "lbl_ajuda";
            this.lbl_ajuda.Size = new System.Drawing.Size(64, 34);
            this.lbl_ajuda.TabIndex = 8;
            this.lbl_ajuda.Text = "Ajuda";
            this.lbl_ajuda.Click += new System.EventHandler(this.pnAjuda_Click);
            this.lbl_ajuda.MouseEnter += new System.EventHandler(this.pnAjuda_MouseEnter);
            this.lbl_ajuda.MouseLeave += new System.EventHandler(this.pnAjuda_MouseLeave);
            // 
            // lbl_sobre
            // 
            this.lbl_sobre.AutoSize = true;
            this.lbl_sobre.Font = new System.Drawing.Font("Myanmar Text", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_sobre.ForeColor = System.Drawing.Color.White;
            this.lbl_sobre.Location = new System.Drawing.Point(35, 1);
            this.lbl_sobre.Name = "lbl_sobre";
            this.lbl_sobre.Size = new System.Drawing.Size(64, 34);
            this.lbl_sobre.TabIndex = 10;
            this.lbl_sobre.Text = "Sobre";
            this.lbl_sobre.Click += new System.EventHandler(this.pnSobre_Click);
            this.lbl_sobre.MouseEnter += new System.EventHandler(this.pnSobre_MouseEnter);
            this.lbl_sobre.MouseLeave += new System.EventHandler(this.pnSobre_MouseLeave);
            // 
            // pbNotificacao
            // 
            this.pbNotificacao.Controls.Add(this.lbl_notificacao);
            this.pbNotificacao.Controls.Add(this.pb_notificacao);
            this.pbNotificacao.Location = new System.Drawing.Point(55, 108);
            this.pbNotificacao.Name = "pbNotificacao";
            this.pbNotificacao.Size = new System.Drawing.Size(154, 32);
            this.pbNotificacao.TabIndex = 11;
            this.pbNotificacao.Click += new System.EventHandler(this.pbNotificacao_Click);
            this.pbNotificacao.MouseEnter += new System.EventHandler(this.pbNotificacao_MouseEnter);
            this.pbNotificacao.MouseLeave += new System.EventHandler(this.pbNotificacao_MouseLeave);
            // 
            // pnPrivacidade
            // 
            this.pnPrivacidade.Controls.Add(this.lbl_privacidade);
            this.pnPrivacidade.Controls.Add(this.pb_privacidade);
            this.pnPrivacidade.Location = new System.Drawing.Point(55, 158);
            this.pnPrivacidade.Name = "pnPrivacidade";
            this.pnPrivacidade.Size = new System.Drawing.Size(154, 32);
            this.pnPrivacidade.TabIndex = 12;
            this.pnPrivacidade.Click += new System.EventHandler(this.pnPrivacidade_Click);
            this.pnPrivacidade.MouseEnter += new System.EventHandler(this.pnPrivacidade_MouseEnter);
            this.pnPrivacidade.MouseLeave += new System.EventHandler(this.pnPrivacidade_MouseLeave);
            // 
            // pnSeguranca
            // 
            this.pnSeguranca.Controls.Add(this.pb_seguranca);
            this.pnSeguranca.Controls.Add(this.lbl_seguranca);
            this.pnSeguranca.Location = new System.Drawing.Point(55, 208);
            this.pnSeguranca.Name = "pnSeguranca";
            this.pnSeguranca.Size = new System.Drawing.Size(148, 32);
            this.pnSeguranca.TabIndex = 13;
            this.pnSeguranca.Click += new System.EventHandler(this.pnSeguranca_Click);
            this.pnSeguranca.MouseEnter += new System.EventHandler(this.pnSeguranca_MouseEnter);
            this.pnSeguranca.MouseLeave += new System.EventHandler(this.pnSeguranca_MouseLeave);
            // 
            // pnAjuda
            // 
            this.pnAjuda.Controls.Add(this.lbl_ajuda);
            this.pnAjuda.Controls.Add(this.pb_ajuda);
            this.pnAjuda.Location = new System.Drawing.Point(55, 258);
            this.pnAjuda.Name = "pnAjuda";
            this.pnAjuda.Size = new System.Drawing.Size(108, 32);
            this.pnAjuda.TabIndex = 14;
            this.pnAjuda.Click += new System.EventHandler(this.pnAjuda_Click);
            this.pnAjuda.MouseEnter += new System.EventHandler(this.pnAjuda_MouseEnter);
            this.pnAjuda.MouseLeave += new System.EventHandler(this.pnAjuda_MouseLeave);
            // 
            // pnSobre
            // 
            this.pnSobre.Controls.Add(this.lbl_sobre);
            this.pnSobre.Controls.Add(this.pb_sobre);
            this.pnSobre.Location = new System.Drawing.Point(55, 308);
            this.pnSobre.Name = "pnSobre";
            this.pnSobre.Size = new System.Drawing.Size(108, 32);
            this.pnSobre.TabIndex = 15;
            this.pnSobre.Click += new System.EventHandler(this.pnSobre_Click);
            this.pnSobre.MouseEnter += new System.EventHandler(this.pnSobre_MouseEnter);
            this.pnSobre.MouseLeave += new System.EventHandler(this.pnSobre_MouseLeave);
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
            // lbl_localizacao
            // 
            this.lbl_localizacao.AutoSize = true;
            this.lbl_localizacao.Font = new System.Drawing.Font("Myanmar Text", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_localizacao.ForeColor = System.Drawing.Color.White;
            this.lbl_localizacao.Location = new System.Drawing.Point(35, 1);
            this.lbl_localizacao.Name = "lbl_localizacao";
            this.lbl_localizacao.Size = new System.Drawing.Size(113, 34);
            this.lbl_localizacao.TabIndex = 10;
            this.lbl_localizacao.Text = "Localização";
            this.lbl_localizacao.Click += new System.EventHandler(this.pbLocalizacao_Click);
            this.lbl_localizacao.MouseEnter += new System.EventHandler(this.pbLocalizacao_MouseEnter);
            this.lbl_localizacao.MouseLeave += new System.EventHandler(this.pbLocalizacao_MouseLeave);
            // 
            // pnLocalizacao
            // 
            this.pnLocalizacao.Controls.Add(this.lbl_localizacao);
            this.pnLocalizacao.Controls.Add(this.pb_localizacao);
            this.pnLocalizacao.Location = new System.Drawing.Point(55, 358);
            this.pnLocalizacao.Name = "pnLocalizacao";
            this.pnLocalizacao.Size = new System.Drawing.Size(148, 32);
            this.pnLocalizacao.TabIndex = 16;
            this.pnLocalizacao.Visible = false;
            this.pnLocalizacao.Click += new System.EventHandler(this.pbLocalizacao_Click);
            this.pnLocalizacao.MouseEnter += new System.EventHandler(this.pbLocalizacao_MouseEnter);
            this.pnLocalizacao.MouseLeave += new System.EventHandler(this.pbLocalizacao_MouseLeave);
            // 
            // pb_localizacao
            // 
            this.pb_localizacao.Image = global::Pismire_TCC.Properties.Resources.local2;
            this.pb_localizacao.Location = new System.Drawing.Point(9, 0);
            this.pb_localizacao.Name = "pb_localizacao";
            this.pb_localizacao.Size = new System.Drawing.Size(22, 31);
            this.pb_localizacao.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_localizacao.TabIndex = 9;
            this.pb_localizacao.TabStop = false;
            this.pb_localizacao.Click += new System.EventHandler(this.pbLocalizacao_Click);
            this.pb_localizacao.MouseEnter += new System.EventHandler(this.pbLocalizacao_MouseEnter);
            this.pb_localizacao.MouseLeave += new System.EventHandler(this.pbLocalizacao_MouseLeave);
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
            // pb_sobre
            // 
            this.pb_sobre.Image = global::Pismire_TCC.Properties.Resources.informacao;
            this.pb_sobre.Location = new System.Drawing.Point(6, -1);
            this.pb_sobre.Name = "pb_sobre";
            this.pb_sobre.Size = new System.Drawing.Size(22, 31);
            this.pb_sobre.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_sobre.TabIndex = 9;
            this.pb_sobre.TabStop = false;
            this.pb_sobre.Click += new System.EventHandler(this.pnSobre_Click);
            this.pb_sobre.MouseEnter += new System.EventHandler(this.pnSobre_MouseEnter);
            this.pb_sobre.MouseLeave += new System.EventHandler(this.pnSobre_MouseLeave);
            // 
            // pb_ajuda
            // 
            this.pb_ajuda.Image = global::Pismire_TCC.Properties.Resources.informacao2;
            this.pb_ajuda.Location = new System.Drawing.Point(6, -1);
            this.pb_ajuda.Name = "pb_ajuda";
            this.pb_ajuda.Size = new System.Drawing.Size(22, 30);
            this.pb_ajuda.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_ajuda.TabIndex = 7;
            this.pb_ajuda.TabStop = false;
            this.pb_ajuda.Click += new System.EventHandler(this.pnAjuda_Click);
            this.pb_ajuda.MouseEnter += new System.EventHandler(this.pnAjuda_MouseEnter);
            this.pb_ajuda.MouseLeave += new System.EventHandler(this.pnAjuda_MouseLeave);
            // 
            // pb_seguranca
            // 
            this.pb_seguranca.Image = global::Pismire_TCC.Properties.Resources.cadeado5;
            this.pb_seguranca.Location = new System.Drawing.Point(6, -1);
            this.pb_seguranca.Name = "pb_seguranca";
            this.pb_seguranca.Size = new System.Drawing.Size(22, 31);
            this.pb_seguranca.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_seguranca.TabIndex = 5;
            this.pb_seguranca.TabStop = false;
            this.pb_seguranca.Click += new System.EventHandler(this.pnSeguranca_Click);
            this.pb_seguranca.MouseEnter += new System.EventHandler(this.pnSeguranca_MouseEnter);
            this.pb_seguranca.MouseLeave += new System.EventHandler(this.pnSeguranca_MouseLeave);
            // 
            // pb_privacidade
            // 
            this.pb_privacidade.Image = global::Pismire_TCC.Properties.Resources.cadeado2;
            this.pb_privacidade.Location = new System.Drawing.Point(6, -1);
            this.pb_privacidade.Name = "pb_privacidade";
            this.pb_privacidade.Size = new System.Drawing.Size(22, 32);
            this.pb_privacidade.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_privacidade.TabIndex = 3;
            this.pb_privacidade.TabStop = false;
            this.pb_privacidade.Click += new System.EventHandler(this.pnPrivacidade_Click);
            this.pb_privacidade.MouseEnter += new System.EventHandler(this.pnPrivacidade_MouseEnter);
            this.pb_privacidade.MouseLeave += new System.EventHandler(this.pnPrivacidade_MouseLeave);
            // 
            // pb_notificacao
            // 
            this.pb_notificacao.Image = global::Pismire_TCC.Properties.Resources.Notificacao2;
            this.pb_notificacao.Location = new System.Drawing.Point(6, -1);
            this.pb_notificacao.Name = "pb_notificacao";
            this.pb_notificacao.Size = new System.Drawing.Size(22, 32);
            this.pb_notificacao.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_notificacao.TabIndex = 1;
            this.pb_notificacao.TabStop = false;
            this.pb_notificacao.Click += new System.EventHandler(this.pbNotificacao_Click);
            this.pb_notificacao.MouseEnter += new System.EventHandler(this.pbNotificacao_MouseEnter);
            this.pb_notificacao.MouseLeave += new System.EventHandler(this.pbNotificacao_MouseLeave);
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
            // TelaConfiguracao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.ClientSize = new System.Drawing.Size(1400, 750);
            this.Controls.Add(this.pnLocalizacao);
            this.Controls.Add(this.pnBarraDeCima);
            this.Controls.Add(this.pnSobre);
            this.Controls.Add(this.pnAjuda);
            this.Controls.Add(this.pnSeguranca);
            this.Controls.Add(this.pnPrivacidade);
            this.Controls.Add(this.pbNotificacao);
            this.Controls.Add(this.p_barra);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TelaConfiguracao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pismire";
            this.Resize += new System.EventHandler(this.TelaConfiguracao_Resize);
            this.p_barra.ResumeLayout(false);
            this.p_barra.PerformLayout();
            this.pbNotificacao.ResumeLayout(false);
            this.pbNotificacao.PerformLayout();
            this.pnPrivacidade.ResumeLayout(false);
            this.pnPrivacidade.PerformLayout();
            this.pnSeguranca.ResumeLayout(false);
            this.pnSeguranca.PerformLayout();
            this.pnAjuda.ResumeLayout(false);
            this.pnAjuda.PerformLayout();
            this.pnSobre.ResumeLayout(false);
            this.pnSobre.PerformLayout();
            this.pnBarraDeCima.ResumeLayout(false);
            this.pnLocalizacao.ResumeLayout(false);
            this.pnLocalizacao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_localizacao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMinimizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMaximizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFechar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_sobre)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_ajuda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_seguranca)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_privacidade)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_notificacao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_voltar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel p_barra;
        private System.Windows.Forms.Label lbl_configuracao;
        private System.Windows.Forms.PictureBox pb_voltar;
        private System.Windows.Forms.PictureBox pb_notificacao;
        private System.Windows.Forms.Label lbl_notificacao;
        private System.Windows.Forms.PictureBox pb_privacidade;
        private System.Windows.Forms.Label lbl_privacidade;
        private System.Windows.Forms.PictureBox pb_seguranca;
        private System.Windows.Forms.Label lbl_seguranca;
        private System.Windows.Forms.PictureBox pb_ajuda;
        private System.Windows.Forms.Label lbl_ajuda;
        private System.Windows.Forms.PictureBox pb_sobre;
        private System.Windows.Forms.Label lbl_sobre;
        private System.Windows.Forms.Panel pbNotificacao;
        private System.Windows.Forms.Panel pnPrivacidade;
        private System.Windows.Forms.Panel pnSeguranca;
        private System.Windows.Forms.Panel pnAjuda;
        private System.Windows.Forms.Panel pnSobre;
        private System.Windows.Forms.Panel pnBarraDeCima;
        private System.Windows.Forms.PictureBox pbMinimizar;
        private System.Windows.Forms.PictureBox pbMaximizar;
        private System.Windows.Forms.PictureBox pbFechar;
        private System.Windows.Forms.Label lbl_localizacao;
        private System.Windows.Forms.PictureBox pb_localizacao;
        private System.Windows.Forms.Panel pnLocalizacao;
    }
}

