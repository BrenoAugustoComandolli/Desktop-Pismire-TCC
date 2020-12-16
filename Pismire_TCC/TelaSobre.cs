using System;
using System.Drawing;
using System.Windows.Forms;

namespace Pismire_TCC
{
    public partial class TelaSobre : Form
    {
        public TelaSobre()
        {
            InitializeComponent();
            Maximizacao.verifique(this, pbMaximizar);   //Verifica se a tela está maximizada ou não
        }

        private void pb_voltar_Click(object sender, EventArgs e)
        {
            this.Hide();
            TelaConfiguracao f = new TelaConfiguracao();                 //Voltar para configurações
            f.Closed += (s, args) => this.Close();
            f.ShowDialog();
        }

        private void p_barra_Paint(object sender, PaintEventArgs e)
        {
            int x = (p_barra.Size.Width - lbl_sobre.Width) / 2;
            int y = (p_barra.Size.Height - lbl_sobre.Height);              //Posição da label na barra

            lbl_sobre.Location = new Point(x, y);
        }

        private void p_barra_Resize(object sender, EventArgs e)
        {
            int x = (p_barra.Size.Width - lbl_sobre.Width) / 2;
            int y = (p_barra.Size.Height - lbl_sobre.Height);       //Posição da label na barra ao maximizar e desmaximizar 

            lbl_sobre.Location = new Point(x, y);
        }

        private void lbl_politica_MouseEnter(object sender, EventArgs e)
        {
            lbl_politica.ForeColor = Color.FromArgb(197, 189, 251);          //Animação politica de privacidade
        }

        private void lbl_politica_MouseLeave(object sender, EventArgs e)
        {
            lbl_politica.ForeColor = Color.White;                         //Animação política de privacidade desfeita
        }

        private void lbl_licenca_MouseEnter(object sender, EventArgs e)
        {
            lbl_licenca.ForeColor = Color.FromArgb(197, 189, 251);             //Aniação termos de licença 
        }

        private void lbl_licenca_MouseLeave(object sender, EventArgs e)
        {
            lbl_licenca.ForeColor = Color.White;                            //Animação termos de licença desfeita
        }

        private void lbl_termos_MouseEnter(object sender, EventArgs e)
        {
            lbl_termos.ForeColor = Color.FromArgb(197, 189, 251);          //Animação temos de uso
        }

        private void lbl_termos_MouseLeave(object sender, EventArgs e)
        {
            lbl_termos.ForeColor = Color.White;                            //Animação termos de uso desfeita
        }

        private void pb_voltar_MouseEnter(object sender, EventArgs e)
        {
            pb_voltar.Image = Properties.Resources.VoltarRoxo;           //Animação de voltar 
        }

        private void pb_voltar_MouseLeave(object sender, EventArgs e)
        {
            pb_voltar.Image = Properties.Resources.voltar;              //Animação de voltar desfeita
        }

        private void lbl_politica_Click(object sender, EventArgs e)
        {
            this.Hide();
            TelaPoliticaPrivacidade f = new TelaPoliticaPrivacidade();               //Entrar na políca de privacidade
            f.Closed += (s, args) => this.Close();
            f.ShowDialog();
            Preferencias.termos = true;
        }

        private void lbl_licenca_Click(object sender, EventArgs e)
        {
            this.Hide();
            TelaTermosLicenca f = new TelaTermosLicenca();                 //Entrar nos termos de licença
            f.Closed += (s, args) => this.Close();
            f.ShowDialog();
            Preferencias.termos = false;
        }

        private void lbl_termos_Click(object sender, EventArgs e)
        {
            this.Hide();
            TelaTermosUso f = new TelaTermosUso();                                   //Entrar nos termos de uso
            f.Closed += (s, args) => this.Close();
            f.ShowDialog();
        }

        private void pbFechar_MouseEnter(object sender, EventArgs e)
        {
            pbFechar.BackColor = Color.Red;
        }

        private void pbFechar_MouseLeave(object sender, EventArgs e)
        {
            pbFechar.BackColor = Color.FromArgb(60, 62, 85);
        }

        private void pbMaximizar_MouseEnter(object sender, EventArgs e)
        {
            pbMaximizar.BackColor = Color.FromArgb(41, 41, 41);
        }

        private void pbMaximizar_MouseLeave(object sender, EventArgs e)
        {
            pbMaximizar.BackColor = Color.FromArgb(60, 62, 85);
        }
                                                                                    
        private void pbMinimizar_MouseEnter(object sender, EventArgs e)
        {
            pbMinimizar.BackColor = Color.FromArgb(41, 41, 41);
        }

        private void pbMinimizar_MouseLeave(object sender, EventArgs e)
        {
            pbMinimizar.BackColor = Color.FromArgb(60, 62, 85);
        }

        private void pbFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pbMaximizar_Click(object sender, EventArgs e)
        {
            if (Maximizacao.contadorMax == false)
            {
                pbMaximizar.Image = Properties.Resources.maximizar;
                this.WindowState = FormWindowState.Maximized;
                Maximizacao.contadorMax = true;                      //Maximizar e normalizar tela 
            }
            else
            {
                pbMaximizar.Image = Properties.Resources.maximizar2;
                this.WindowState = FormWindowState.Normal;
                this.CenterToScreen();
                Maximizacao.contadorMax = false;
            }
        }

        private void pbMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;    //Minimizar tela 
        }
    }
}
