namespace Pismire_TCC
{

    partial class TelaConfiguracaoPrivacidade
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaConfiguracaoPrivacidade));
            this.p_barra = new System.Windows.Forms.Panel();
            this.pb_voltar = new System.Windows.Forms.PictureBox();
            this.lbl_privacidade = new System.Windows.Forms.Label();
            this.lb_txt_privacidade = new System.Windows.Forms.Label();
            this.pb_aviso = new System.Windows.Forms.PictureBox();
            this.pb_privacidade = new System.Windows.Forms.PictureBox();
            this.lbl_mensagem = new System.Windows.Forms.Label();
            this.pnBarraDeCima = new System.Windows.Forms.Panel();
            this.pbMinimizar = new System.Windows.Forms.PictureBox();
            this.pbMaximizar = new System.Windows.Forms.PictureBox();
            this.pbFechar = new System.Windows.Forms.PictureBox();
            this.p_barra.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_voltar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_aviso)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_privacidade)).BeginInit();
            this.pnBarraDeCima.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMinimizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMaximizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFechar)).BeginInit();
            this.SuspendLayout();
            // 
            // p_barra
            // 
            this.p_barra.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.p_barra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(92)))));
            this.p_barra.Controls.Add(this.pb_voltar);
            this.p_barra.Controls.Add(this.lbl_privacidade);
            this.p_barra.Location = new System.Drawing.Point(0, 21);
            this.p_barra.Name = "p_barra";
            this.p_barra.Size = new System.Drawing.Size(1402, 65);
            this.p_barra.TabIndex = 0;
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
            // 
            // lbl_privacidade
            // 
            this.lbl_privacidade.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_privacidade.AutoSize = true;
            this.lbl_privacidade.Font = new System.Drawing.Font("Myanmar Text", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_privacidade.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbl_privacidade.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lbl_privacidade.Location = new System.Drawing.Point(596, 12);
            this.lbl_privacidade.Name = "lbl_privacidade";
            this.lbl_privacidade.Size = new System.Drawing.Size(186, 56);
            this.lbl_privacidade.TabIndex = 0;
            this.lbl_privacidade.Text = "Privacidade";
            // 
            // lb_txt_privacidade
            // 
            this.lb_txt_privacidade.AutoSize = true;
            this.lb_txt_privacidade.Font = new System.Drawing.Font("Myanmar Text", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_txt_privacidade.ForeColor = System.Drawing.Color.White;
            this.lb_txt_privacidade.Location = new System.Drawing.Point(58, 118);
            this.lb_txt_privacidade.Name = "lb_txt_privacidade";
            this.lb_txt_privacidade.Size = new System.Drawing.Size(627, 34);
            this.lb_txt_privacidade.TabIndex = 1;
            this.lb_txt_privacidade.Text = "Permite o compartilhamento das informações de seu perfil para usuários";
            // 
            // pb_aviso
            // 
            this.pb_aviso.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.pb_aviso.Image = global::Pismire_TCC.Properties.Resources.Aviso1;
            this.pb_aviso.Location = new System.Drawing.Point(597, 295);
            this.pb_aviso.Name = "pb_aviso";
            this.pb_aviso.Size = new System.Drawing.Size(199, 108);
            this.pb_aviso.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_aviso.TabIndex = 3;
            this.pb_aviso.TabStop = false;
            // 
            // pb_privacidade
            // 
            this.pb_privacidade.Image = global::Pismire_TCC.Properties.Resources.selecionar3;
            this.pb_privacidade.Location = new System.Drawing.Point(685, 118);
            this.pb_privacidade.Name = "pb_privacidade";
            this.pb_privacidade.Size = new System.Drawing.Size(58, 31);
            this.pb_privacidade.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_privacidade.TabIndex = 2;
            this.pb_privacidade.TabStop = false;
            this.pb_privacidade.Click += new System.EventHandler(this.pb_privacidade_Click);
            // 
            // lbl_mensagem
            // 
            this.lbl_mensagem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_mensagem.Font = new System.Drawing.Font("Myanmar Text", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_mensagem.ForeColor = System.Drawing.Color.White;
            this.lbl_mensagem.Location = new System.Drawing.Point(465, 421);
            this.lbl_mensagem.Name = "lbl_mensagem";
            this.lbl_mensagem.Size = new System.Drawing.Size(480, 157);
            this.lbl_mensagem.TabIndex = 4;
            this.lbl_mensagem.Text = "Se você desativar essa opção, não poderá criar eventos";
            this.lbl_mensagem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            // TelaConfiguracaoPrivacidade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.ClientSize = new System.Drawing.Size(1400, 750);
            this.Controls.Add(this.pnBarraDeCima);
            this.Controls.Add(this.lbl_mensagem);
            this.Controls.Add(this.pb_aviso);
            this.Controls.Add(this.pb_privacidade);
            this.Controls.Add(this.lb_txt_privacidade);
            this.Controls.Add(this.p_barra);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TelaConfiguracaoPrivacidade";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pismire";
            this.p_barra.ResumeLayout(false);
            this.p_barra.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_voltar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_aviso)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_privacidade)).EndInit();
            this.pnBarraDeCima.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbMinimizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMaximizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFechar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel p_barra;
        private System.Windows.Forms.Label lbl_privacidade;
        private System.Windows.Forms.PictureBox pb_voltar;
        private System.Windows.Forms.Label lb_txt_privacidade;
        private System.Windows.Forms.PictureBox pb_privacidade;
        private System.Windows.Forms.PictureBox pb_aviso;
        private System.Windows.Forms.Label lbl_mensagem;
        private System.Windows.Forms.Panel pnBarraDeCima;
        private System.Windows.Forms.PictureBox pbMinimizar;
        private System.Windows.Forms.PictureBox pbMaximizar;
        private System.Windows.Forms.PictureBox pbFechar;
    }
}

