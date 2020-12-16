namespace Pismire_TCC
{
    partial class TelaMensagemAberta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaMensagemAberta));
            this.pnBarraDeCima = new System.Windows.Forms.Panel();
            this.pbMinimizar = new System.Windows.Forms.PictureBox();
            this.pbMaximizar = new System.Windows.Forms.PictureBox();
            this.pbFechar = new System.Windows.Forms.PictureBox();
            this.p_barra = new System.Windows.Forms.Panel();
            this.lbl_mensagem = new System.Windows.Forms.Label();
            this.lblHorario = new System.Windows.Forms.Label();
            this.pbVoltar = new System.Windows.Forms.PictureBox();
            this.pLixeiraAberta = new System.Windows.Forms.Panel();
            this.btConfirmar = new System.Windows.Forms.Button();
            this.btCancelar = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lblTexto = new System.Windows.Forms.Label();
            this.pbLixeira = new System.Windows.Forms.PictureBox();
            this.lblData = new System.Windows.Forms.Label();
            this.pbFoto = new System.Windows.Forms.PictureBox();
            this.pbFotoTrab = new Pismire_TCC.RoundPictureBox();
            this.pnBarraDeCima.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMinimizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMaximizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFechar)).BeginInit();
            this.p_barra.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbVoltar)).BeginInit();
            this.pLixeiraAberta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLixeira)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFoto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFotoTrab)).BeginInit();
            this.SuspendLayout();
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
            this.pnBarraDeCima.TabIndex = 39;
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
            // p_barra
            // 
            this.p_barra.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.p_barra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(92)))));
            this.p_barra.Controls.Add(this.lbl_mensagem);
            this.p_barra.Controls.Add(this.lblHorario);
            this.p_barra.Controls.Add(this.pbVoltar);
            this.p_barra.Location = new System.Drawing.Point(0, 21);
            this.p_barra.Name = "p_barra";
            this.p_barra.Size = new System.Drawing.Size(1416, 65);
            this.p_barra.TabIndex = 37;
            this.p_barra.Paint += new System.Windows.Forms.PaintEventHandler(this.p_barra_Paint);
            this.p_barra.Resize += new System.EventHandler(this.p_barra_Resize);
            // 
            // lbl_mensagem
            // 
            this.lbl_mensagem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_mensagem.AutoSize = true;
            this.lbl_mensagem.Font = new System.Drawing.Font("Myanmar Text", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_mensagem.ForeColor = System.Drawing.Color.White;
            this.lbl_mensagem.Location = new System.Drawing.Point(610, 10);
            this.lbl_mensagem.Name = "lbl_mensagem";
            this.lbl_mensagem.Size = new System.Drawing.Size(182, 56);
            this.lbl_mensagem.TabIndex = 2;
            this.lbl_mensagem.Text = "Mensagem";
            // 
            // lblHorario
            // 
            this.lblHorario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHorario.AutoSize = true;
            this.lblHorario.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHorario.ForeColor = System.Drawing.Color.White;
            this.lblHorario.Location = new System.Drawing.Point(1292, 21);
            this.lblHorario.Name = "lblHorario";
            this.lblHorario.Size = new System.Drawing.Size(0, 24);
            this.lblHorario.TabIndex = 40;
            // 
            // pbVoltar
            // 
            this.pbVoltar.Image = global::Pismire_TCC.Properties.Resources.voltar;
            this.pbVoltar.Location = new System.Drawing.Point(32, 18);
            this.pbVoltar.Name = "pbVoltar";
            this.pbVoltar.Size = new System.Drawing.Size(32, 29);
            this.pbVoltar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbVoltar.TabIndex = 1;
            this.pbVoltar.TabStop = false;
            this.pbVoltar.Click += new System.EventHandler(this.pbVoltar_Click);
            this.pbVoltar.MouseEnter += new System.EventHandler(this.pbVoltar_MouseEnter);
            this.pbVoltar.MouseLeave += new System.EventHandler(this.pbVoltar_MouseLeave);
            // 
            // pLixeiraAberta
            // 
            this.pLixeiraAberta.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pLixeiraAberta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(92)))));
            this.pLixeiraAberta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pLixeiraAberta.Controls.Add(this.btConfirmar);
            this.pLixeiraAberta.Controls.Add(this.btCancelar);
            this.pLixeiraAberta.Controls.Add(this.label6);
            this.pLixeiraAberta.Controls.Add(this.pictureBox2);
            this.pLixeiraAberta.Location = new System.Drawing.Point(505, 299);
            this.pLixeiraAberta.Name = "pLixeiraAberta";
            this.pLixeiraAberta.Size = new System.Drawing.Size(390, 217);
            this.pLixeiraAberta.TabIndex = 36;
            this.pLixeiraAberta.Visible = false;
            // 
            // btConfirmar
            // 
            this.btConfirmar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.btConfirmar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(92)))));
            this.btConfirmar.FlatAppearance.BorderSize = 3;
            this.btConfirmar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(189)))), ((int)(((byte)(251)))));
            this.btConfirmar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(189)))), ((int)(((byte)(251)))));
            this.btConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btConfirmar.Font = new System.Drawing.Font("Myanmar Text", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btConfirmar.ForeColor = System.Drawing.Color.White;
            this.btConfirmar.Location = new System.Drawing.Point(217, 151);
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
            this.btCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.btCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(92)))));
            this.btCancelar.FlatAppearance.BorderSize = 3;
            this.btCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(189)))), ((int)(((byte)(251)))));
            this.btCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(189)))), ((int)(((byte)(251)))));
            this.btCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCancelar.Font = new System.Drawing.Font("Myanmar Text", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCancelar.ForeColor = System.Drawing.Color.White;
            this.btCancelar.Location = new System.Drawing.Point(65, 150);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(106, 36);
            this.btCancelar.TabIndex = 17;
            this.btCancelar.Text = "Cancelar";
            this.btCancelar.UseVisualStyleBackColor = false;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
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
            // lblTexto
            // 
            this.lblTexto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTexto.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblTexto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTexto.ForeColor = System.Drawing.Color.White;
            this.lblTexto.Location = new System.Drawing.Point(103, 290);
            this.lblTexto.Name = "lblTexto";
            this.lblTexto.Size = new System.Drawing.Size(1169, 384);
            this.lblTexto.TabIndex = 34;
            // 
            // pbLixeira
            // 
            this.pbLixeira.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pbLixeira.Image = global::Pismire_TCC.Properties.Resources.excluir;
            this.pbLixeira.Location = new System.Drawing.Point(1298, 669);
            this.pbLixeira.Name = "pbLixeira";
            this.pbLixeira.Size = new System.Drawing.Size(35, 35);
            this.pbLixeira.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLixeira.TabIndex = 33;
            this.pbLixeira.TabStop = false;
            this.pbLixeira.Click += new System.EventHandler(this.pbLixeira_Click);
            this.pbLixeira.MouseEnter += new System.EventHandler(this.pbLixeira_MouseEnter);
            this.pbLixeira.MouseLeave += new System.EventHandler(this.pbLixeira_MouseLeave);
            // 
            // lblData
            // 
            this.lblData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblData.AutoSize = true;
            this.lblData.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblData.ForeColor = System.Drawing.Color.White;
            this.lblData.Location = new System.Drawing.Point(49, 679);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(0, 24);
            this.lblData.TabIndex = 32;
            // 
            // pbFoto
            // 
            this.pbFoto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbFoto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.pbFoto.Location = new System.Drawing.Point(0, 87);
            this.pbFoto.Name = "pbFoto";
            this.pbFoto.Size = new System.Drawing.Size(1400, 164);
            this.pbFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbFoto.TabIndex = 41;
            this.pbFoto.TabStop = false;
            this.pbFoto.Visible = false;
            // 
            // pbFotoTrab
            // 
            this.pbFotoTrab.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pbFotoTrab.Image = global::Pismire_TCC.Properties.Resources.recomendados;
            this.pbFotoTrab.Location = new System.Drawing.Point(645, 117);
            this.pbFotoTrab.Name = "pbFotoTrab";
            this.pbFotoTrab.Size = new System.Drawing.Size(110, 110);
            this.pbFotoTrab.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbFotoTrab.TabIndex = 61;
            this.pbFotoTrab.TabStop = false;
            this.pbFotoTrab.Visible = false;
            // 
            // TelaMensagemAberta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.ClientSize = new System.Drawing.Size(1400, 750);
            this.Controls.Add(this.pbFotoTrab);
            this.Controls.Add(this.pbFoto);
            this.Controls.Add(this.pnBarraDeCima);
            this.Controls.Add(this.p_barra);
            this.Controls.Add(this.pLixeiraAberta);
            this.Controls.Add(this.lblTexto);
            this.Controls.Add(this.pbLixeira);
            this.Controls.Add(this.lblData);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TelaMensagemAberta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pismire";
            this.pnBarraDeCima.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbMinimizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMaximizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFechar)).EndInit();
            this.p_barra.ResumeLayout(false);
            this.p_barra.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbVoltar)).EndInit();
            this.pLixeiraAberta.ResumeLayout(false);
            this.pLixeiraAberta.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLixeira)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFoto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFotoTrab)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnBarraDeCima;
        private System.Windows.Forms.PictureBox pbMinimizar;
        private System.Windows.Forms.PictureBox pbMaximizar;
        private System.Windows.Forms.PictureBox pbFechar;
        private System.Windows.Forms.Panel p_barra;
        private System.Windows.Forms.Label lbl_mensagem;
        private System.Windows.Forms.PictureBox pbVoltar;
        private System.Windows.Forms.Panel pLixeiraAberta;
        private System.Windows.Forms.Button btConfirmar;
        private System.Windows.Forms.Button btCancelar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lblTexto;
        private System.Windows.Forms.PictureBox pbLixeira;
        private System.Windows.Forms.Label lblData;
        private System.Windows.Forms.Label lblHorario;
        private System.Windows.Forms.PictureBox pbFoto;
        private RoundPictureBox pbFotoTrab;
    }
}