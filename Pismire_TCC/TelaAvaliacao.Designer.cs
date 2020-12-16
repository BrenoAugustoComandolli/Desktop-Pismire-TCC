namespace Pismire_TCC
{
    partial class TelaAvaliacao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaAvaliacao));
            this.p_barra = new System.Windows.Forms.Panel();
            this.lbl_avaliacao = new System.Windows.Forms.Label();
            this.pb_voltar = new System.Windows.Forms.PictureBox();
            this.lb_CPF = new System.Windows.Forms.Label();
            this.lb_nota = new System.Windows.Forms.Label();
            this.lb_comentario = new System.Windows.Forms.Label();
            this.tb_caixaTexto = new System.Windows.Forms.TextBox();
            this.txtCPF = new System.Windows.Forms.TextBox();
            this.bt_enviar = new System.Windows.Forms.Button();
            this.pb_estrela5 = new System.Windows.Forms.PictureBox();
            this.pb_estrela4 = new System.Windows.Forms.PictureBox();
            this.pb_estrela3 = new System.Windows.Forms.PictureBox();
            this.pb_estrela2 = new System.Windows.Forms.PictureBox();
            this.pb_estrela1 = new System.Windows.Forms.PictureBox();
            this.bt_excluir = new System.Windows.Forms.Button();
            this.lbl_mensagem = new System.Windows.Forms.Label();
            this.pnBarraDeCima = new System.Windows.Forms.Panel();
            this.pbMinimizar = new System.Windows.Forms.PictureBox();
            this.pbMaximizar = new System.Windows.Forms.PictureBox();
            this.pbFechar = new System.Windows.Forms.PictureBox();
            this.p_barra.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_voltar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_estrela5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_estrela4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_estrela3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_estrela2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_estrela1)).BeginInit();
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
            this.p_barra.Controls.Add(this.lbl_avaliacao);
            this.p_barra.Controls.Add(this.pb_voltar);
            this.p_barra.Location = new System.Drawing.Point(0, 21);
            this.p_barra.Name = "p_barra";
            this.p_barra.Size = new System.Drawing.Size(1402, 65);
            this.p_barra.TabIndex = 0;
            this.p_barra.Paint += new System.Windows.Forms.PaintEventHandler(this.p_barra_Paint);
            // 
            // lbl_avaliacao
            // 
            this.lbl_avaliacao.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_avaliacao.AutoSize = true;
            this.lbl_avaliacao.Font = new System.Drawing.Font("Myanmar Text", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_avaliacao.ForeColor = System.Drawing.Color.White;
            this.lbl_avaliacao.Location = new System.Drawing.Point(654, 10);
            this.lbl_avaliacao.Name = "lbl_avaliacao";
            this.lbl_avaliacao.Size = new System.Drawing.Size(158, 56);
            this.lbl_avaliacao.TabIndex = 2;
            this.lbl_avaliacao.Text = "Avaliação";
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
            // lb_CPF
            // 
            this.lb_CPF.AutoSize = true;
            this.lb_CPF.Font = new System.Drawing.Font("Myanmar Text", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_CPF.ForeColor = System.Drawing.Color.White;
            this.lb_CPF.Location = new System.Drawing.Point(60, 125);
            this.lb_CPF.Name = "lb_CPF";
            this.lb_CPF.Size = new System.Drawing.Size(57, 37);
            this.lb_CPF.TabIndex = 1;
            this.lb_CPF.Text = "CPF:";
            // 
            // lb_nota
            // 
            this.lb_nota.AutoSize = true;
            this.lb_nota.Font = new System.Drawing.Font("Myanmar Text", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_nota.ForeColor = System.Drawing.Color.White;
            this.lb_nota.Location = new System.Drawing.Point(59, 184);
            this.lb_nota.Name = "lb_nota";
            this.lb_nota.Size = new System.Drawing.Size(68, 37);
            this.lb_nota.TabIndex = 2;
            this.lb_nota.Text = "Nota:";
            // 
            // lb_comentario
            // 
            this.lb_comentario.AutoSize = true;
            this.lb_comentario.Font = new System.Drawing.Font("Myanmar Text", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_comentario.ForeColor = System.Drawing.Color.White;
            this.lb_comentario.Location = new System.Drawing.Point(61, 249);
            this.lb_comentario.Name = "lb_comentario";
            this.lb_comentario.Size = new System.Drawing.Size(130, 37);
            this.lb_comentario.TabIndex = 3;
            this.lb_comentario.Text = "Comentário:";
            // 
            // tb_caixaTexto
            // 
            this.tb_caixaTexto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_caixaTexto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.tb_caixaTexto.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_caixaTexto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_caixaTexto.ForeColor = System.Drawing.Color.White;
            this.tb_caixaTexto.Location = new System.Drawing.Point(191, 253);
            this.tb_caixaTexto.MaxLength = 1500;
            this.tb_caixaTexto.Multiline = true;
            this.tb_caixaTexto.Name = "tb_caixaTexto";
            this.tb_caixaTexto.Size = new System.Drawing.Size(1036, 386);
            this.tb_caixaTexto.TabIndex = 2;
            // 
            // txtCPF
            // 
            this.txtCPF.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.txtCPF.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCPF.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCPF.ForeColor = System.Drawing.Color.White;
            this.txtCPF.Location = new System.Drawing.Point(121, 129);
            this.txtCPF.MaxLength = 14;
            this.txtCPF.Name = "txtCPF";
            this.txtCPF.Size = new System.Drawing.Size(314, 22);
            this.txtCPF.TabIndex = 1;
            this.txtCPF.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCPF_KeyDown);
            this.txtCPF.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCPF_KeyPress);
            this.txtCPF.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCPF_KeyUp);
            // 
            // bt_enviar
            // 
            this.bt_enviar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_enviar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.bt_enviar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(92)))));
            this.bt_enviar.FlatAppearance.BorderSize = 3;
            this.bt_enviar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(92)))));
            this.bt_enviar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(92)))));
            this.bt_enviar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_enviar.Font = new System.Drawing.Font("Myanmar Text", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_enviar.ForeColor = System.Drawing.Color.White;
            this.bt_enviar.Location = new System.Drawing.Point(1242, 679);
            this.bt_enviar.Name = "bt_enviar";
            this.bt_enviar.Size = new System.Drawing.Size(106, 36);
            this.bt_enviar.TabIndex = 11;
            this.bt_enviar.Text = "Enviar";
            this.bt_enviar.UseVisualStyleBackColor = false;
            this.bt_enviar.Click += new System.EventHandler(this.bt_enviar_Click);
            // 
            // pb_estrela5
            // 
            this.pb_estrela5.Image = global::Pismire_TCC.Properties.Resources.estrela;
            this.pb_estrela5.Location = new System.Drawing.Point(354, 180);
            this.pb_estrela5.Name = "pb_estrela5";
            this.pb_estrela5.Size = new System.Drawing.Size(40, 35);
            this.pb_estrela5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_estrela5.TabIndex = 9;
            this.pb_estrela5.TabStop = false;
            this.pb_estrela5.Click += new System.EventHandler(this.pb_estrela5_Click);
            this.pb_estrela5.MouseEnter += new System.EventHandler(this.pb_estrela5_MouseEnter);
            // 
            // pb_estrela4
            // 
            this.pb_estrela4.Image = global::Pismire_TCC.Properties.Resources.estrela;
            this.pb_estrela4.Location = new System.Drawing.Point(298, 180);
            this.pb_estrela4.Name = "pb_estrela4";
            this.pb_estrela4.Size = new System.Drawing.Size(40, 35);
            this.pb_estrela4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_estrela4.TabIndex = 8;
            this.pb_estrela4.TabStop = false;
            this.pb_estrela4.Click += new System.EventHandler(this.pb_estrela4_Click);
            this.pb_estrela4.MouseEnter += new System.EventHandler(this.pb_estrela4_MouseEnter);
            // 
            // pb_estrela3
            // 
            this.pb_estrela3.Image = global::Pismire_TCC.Properties.Resources.estrela;
            this.pb_estrela3.Location = new System.Drawing.Point(243, 180);
            this.pb_estrela3.Name = "pb_estrela3";
            this.pb_estrela3.Size = new System.Drawing.Size(40, 35);
            this.pb_estrela3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_estrela3.TabIndex = 7;
            this.pb_estrela3.TabStop = false;
            this.pb_estrela3.Click += new System.EventHandler(this.pb_estrela3_Click);
            this.pb_estrela3.MouseEnter += new System.EventHandler(this.pb_estrela3_MouseEnter);
            // 
            // pb_estrela2
            // 
            this.pb_estrela2.Image = global::Pismire_TCC.Properties.Resources.estrela;
            this.pb_estrela2.Location = new System.Drawing.Point(187, 180);
            this.pb_estrela2.Name = "pb_estrela2";
            this.pb_estrela2.Size = new System.Drawing.Size(40, 35);
            this.pb_estrela2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_estrela2.TabIndex = 6;
            this.pb_estrela2.TabStop = false;
            this.pb_estrela2.Click += new System.EventHandler(this.pb_estrela2_Click);
            this.pb_estrela2.MouseEnter += new System.EventHandler(this.pb_estrela2_MouseEnter);
            // 
            // pb_estrela1
            // 
            this.pb_estrela1.Image = global::Pismire_TCC.Properties.Resources.estrela;
            this.pb_estrela1.Location = new System.Drawing.Point(132, 180);
            this.pb_estrela1.Name = "pb_estrela1";
            this.pb_estrela1.Size = new System.Drawing.Size(40, 35);
            this.pb_estrela1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_estrela1.TabIndex = 5;
            this.pb_estrela1.TabStop = false;
            this.pb_estrela1.Click += new System.EventHandler(this.pb_estrela1_Click);
            this.pb_estrela1.MouseEnter += new System.EventHandler(this.pb_estrela1_MouseEnter);
            // 
            // bt_excluir
            // 
            this.bt_excluir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_excluir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.bt_excluir.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(92)))));
            this.bt_excluir.FlatAppearance.BorderSize = 3;
            this.bt_excluir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(92)))));
            this.bt_excluir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(92)))));
            this.bt_excluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_excluir.Font = new System.Drawing.Font("Myanmar Text", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_excluir.ForeColor = System.Drawing.Color.White;
            this.bt_excluir.Location = new System.Drawing.Point(1108, 679);
            this.bt_excluir.Name = "bt_excluir";
            this.bt_excluir.Size = new System.Drawing.Size(106, 36);
            this.bt_excluir.TabIndex = 12;
            this.bt_excluir.Text = "Excluir";
            this.bt_excluir.UseVisualStyleBackColor = false;
            this.bt_excluir.Visible = false;
            this.bt_excluir.Click += new System.EventHandler(this.bt_excluir_Click);
            // 
            // lbl_mensagem
            // 
            this.lbl_mensagem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_mensagem.AutoSize = true;
            this.lbl_mensagem.Font = new System.Drawing.Font("Myanmar Text", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_mensagem.ForeColor = System.Drawing.Color.White;
            this.lbl_mensagem.Location = new System.Drawing.Point(32, 679);
            this.lbl_mensagem.Name = "lbl_mensagem";
            this.lbl_mensagem.Size = new System.Drawing.Size(108, 34);
            this.lbl_mensagem.TabIndex = 13;
            this.lbl_mensagem.Text = "Mensagem";
            this.lbl_mensagem.Visible = false;
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
            // TelaAvaliacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.ClientSize = new System.Drawing.Size(1400, 750);
            this.Controls.Add(this.pnBarraDeCima);
            this.Controls.Add(this.lbl_mensagem);
            this.Controls.Add(this.bt_excluir);
            this.Controls.Add(this.bt_enviar);
            this.Controls.Add(this.txtCPF);
            this.Controls.Add(this.pb_estrela5);
            this.Controls.Add(this.pb_estrela4);
            this.Controls.Add(this.pb_estrela3);
            this.Controls.Add(this.pb_estrela2);
            this.Controls.Add(this.pb_estrela1);
            this.Controls.Add(this.tb_caixaTexto);
            this.Controls.Add(this.lb_comentario);
            this.Controls.Add(this.lb_nota);
            this.Controls.Add(this.lb_CPF);
            this.Controls.Add(this.p_barra);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TelaAvaliacao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pismire";
            this.MouseEnter += new System.EventHandler(this.TelaAvaliacao_MouseEnter);
            this.Resize += new System.EventHandler(this.TelaAvaliacao_Resize);
            this.p_barra.ResumeLayout(false);
            this.p_barra.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_voltar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_estrela5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_estrela4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_estrela3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_estrela2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_estrela1)).EndInit();
            this.pnBarraDeCima.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbMinimizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMaximizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFechar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel p_barra;
        private System.Windows.Forms.PictureBox pb_voltar;
        private System.Windows.Forms.Label lb_CPF;
        private System.Windows.Forms.Label lb_nota;
        private System.Windows.Forms.Label lb_comentario;
        private System.Windows.Forms.TextBox tb_caixaTexto;
        private System.Windows.Forms.PictureBox pb_estrela1;
        private System.Windows.Forms.PictureBox pb_estrela2;
        private System.Windows.Forms.PictureBox pb_estrela3;
        private System.Windows.Forms.PictureBox pb_estrela4;
        private System.Windows.Forms.PictureBox pb_estrela5;
        private System.Windows.Forms.TextBox txtCPF;
        private System.Windows.Forms.Button bt_enviar;
        private System.Windows.Forms.Label lbl_avaliacao;
        private System.Windows.Forms.Button bt_excluir;
        private System.Windows.Forms.Label lbl_mensagem;
        private System.Windows.Forms.Panel pnBarraDeCima;
        private System.Windows.Forms.PictureBox pbMinimizar;
        private System.Windows.Forms.PictureBox pbMaximizar;
        private System.Windows.Forms.PictureBox pbFechar;
    }
}

