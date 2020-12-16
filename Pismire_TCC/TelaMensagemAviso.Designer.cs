namespace Pismire_TCC
{
    partial class TelaMensagemAviso
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaMensagemAviso));
            this.lbl_mensagem = new System.Windows.Forms.Label();
            this.bt_ok = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_mensagem
            // 
            this.lbl_mensagem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_mensagem.Font = new System.Drawing.Font("Myanmar Text", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_mensagem.ForeColor = System.Drawing.Color.White;
            this.lbl_mensagem.Location = new System.Drawing.Point(40, 27);
            this.lbl_mensagem.Name = "lbl_mensagem";
            this.lbl_mensagem.Size = new System.Drawing.Size(220, 59);
            this.lbl_mensagem.TabIndex = 0;
            this.lbl_mensagem.Text = "Mensagem";
            this.lbl_mensagem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bt_ok
            // 
            this.bt_ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_ok.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.bt_ok.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(92)))));
            this.bt_ok.FlatAppearance.BorderSize = 3;
            this.bt_ok.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(189)))), ((int)(((byte)(251)))));
            this.bt_ok.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(189)))), ((int)(((byte)(251)))));
            this.bt_ok.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_ok.Font = new System.Drawing.Font("Myanmar Text", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_ok.ForeColor = System.Drawing.Color.White;
            this.bt_ok.Location = new System.Drawing.Point(97, 98);
            this.bt_ok.Name = "bt_ok";
            this.bt_ok.Size = new System.Drawing.Size(106, 36);
            this.bt_ok.TabIndex = 12;
            this.bt_ok.Text = "Ok";
            this.bt_ok.UseVisualStyleBackColor = false;
            this.bt_ok.Click += new System.EventHandler(this.bt_ok_Click);
            this.bt_ok.MouseEnter += new System.EventHandler(this.bt_ok_MouseEnter);
            this.bt_ok.MouseLeave += new System.EventHandler(this.bt_ok_MouseLeave);
            // 
            // TelaMensagemAviso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(92)))));
            this.ClientSize = new System.Drawing.Size(300, 150);
            this.Controls.Add(this.bt_ok);
            this.Controls.Add(this.lbl_mensagem);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(92)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TelaMensagemAviso";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pismire";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_mensagem;
        private System.Windows.Forms.Button bt_ok;
    }
}