namespace Pismire_TCC
{
    partial class TelaTermosUso
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaTermosUso));
            this.p_barra = new System.Windows.Forms.Panel();
            this.pb_voltar = new System.Windows.Forms.PictureBox();
            this.lbl_termos = new System.Windows.Forms.Label();
            this.tb_texto = new System.Windows.Forms.TextBox();
            this.pnBarraDeCima = new System.Windows.Forms.Panel();
            this.pbMinimizar = new System.Windows.Forms.PictureBox();
            this.pbMaximizar = new System.Windows.Forms.PictureBox();
            this.pbFechar = new System.Windows.Forms.PictureBox();
            this.p_barra.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_voltar)).BeginInit();
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
            this.p_barra.Controls.Add(this.lbl_termos);
            this.p_barra.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(92)))));
            this.p_barra.Location = new System.Drawing.Point(0, 20);
            this.p_barra.Name = "p_barra";
            this.p_barra.Size = new System.Drawing.Size(1402, 65);
            this.p_barra.TabIndex = 6;
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
            // lbl_termos
            // 
            this.lbl_termos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_termos.AutoSize = true;
            this.lbl_termos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(92)))));
            this.lbl_termos.Font = new System.Drawing.Font("Myanmar Text", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_termos.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbl_termos.Location = new System.Drawing.Point(654, 10);
            this.lbl_termos.Name = "lbl_termos";
            this.lbl_termos.Size = new System.Drawing.Size(107, 56);
            this.lbl_termos.TabIndex = 0;
            this.lbl_termos.Text = "Sobre";
            this.lbl_termos.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tb_texto
            // 
            this.tb_texto.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.tb_texto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_texto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.tb_texto.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_texto.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_texto.ForeColor = System.Drawing.Color.White;
            this.tb_texto.HideSelection = false;
            this.tb_texto.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tb_texto.Location = new System.Drawing.Point(62, 88);
            this.tb_texto.Multiline = true;
            this.tb_texto.Name = "tb_texto";
            this.tb_texto.ReadOnly = true;
            this.tb_texto.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_texto.Size = new System.Drawing.Size(1337, 661);
            this.tb_texto.TabIndex = 7;
            this.tb_texto.TabStop = false;
            this.tb_texto.Text = resources.GetString("tb_texto.Text");
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
            // TelaTermosUso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.ClientSize = new System.Drawing.Size(1400, 750);
            this.Controls.Add(this.pnBarraDeCima);
            this.Controls.Add(this.tb_texto);
            this.Controls.Add(this.p_barra);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TelaTermosUso";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pismire";
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

        private System.Windows.Forms.Panel p_barra;
        private System.Windows.Forms.PictureBox pb_voltar;
        private System.Windows.Forms.Label lbl_termos;
        private System.Windows.Forms.TextBox tb_texto;
        private System.Windows.Forms.Panel pnBarraDeCima;
        private System.Windows.Forms.PictureBox pbMinimizar;
        private System.Windows.Forms.PictureBox pbMaximizar;
        private System.Windows.Forms.PictureBox pbFechar;
    }
}