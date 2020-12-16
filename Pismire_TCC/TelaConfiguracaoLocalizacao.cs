using Pismire_TCC.Resources;
using System;
using System.Data;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Pismire_TCC
{
    public partial class TelaConfiguracaoLocalizacao : Form
    {
        PismireEntities5 bd = new PismireEntities5();

        public TelaConfiguracaoLocalizacao()
        {
            InitializeComponent();
            Maximizacao.verifique(this, pbMaximizar);   //Verifica se a tela está maximizada ou não

            if (Preferencias.local == true)
            {
                pbLocalizacao.Image = Properties.Resources.selecionar3;
            }
            else                                                               //Seleção de opção notificaoes
            {
                pbLocalizacao.Image = Properties.Resources.selecionarDesativado;
            }
        }

        private void pbLocalizacao_Click(object sender, EventArgs e)
        {
            try
            {
                var preferencia = bd.preferencia.Where(x => x.FK_usuario == UsuarioDados.Id).FirstOrDefault();

                pbLocalizacao.Image = Properties.Resources.selecionar3;
                if (Preferencias.local == true)
                {
                    pbLocalizacao.Image = Properties.Resources.selecionarDesativado;     //Preenchimento no banco localizacao
                    Preferencias.local = false;
                }
                else
                {
                    pbLocalizacao.Image = Properties.Resources.selecionar3;
                    Preferencias.local = true;                                   //Preenchimento no banco localizacao
                }

                preferencia.localizacao = Preferencias.local;
                bd.preferencia.AddOrUpdate(preferencia);                   //salvamento
                bd.SaveChanges();
            }
            catch (Exception)
            {
                Mensagem.aviso = "Erro ao abrir!";
                TelaMensagemAviso f = new TelaMensagemAviso();
                f.ShowDialog();
            }
        }

        private void p_barra_Paint(object sender, PaintEventArgs e)
        {
            int x = (p_barra.Size.Width - lbl_localizacao.Width) / 2;
            int y = (p_barra.Size.Height - lbl_localizacao.Height);              //Posição da label na barra

            lbl_localizacao.Location = new Point(x, y);
        }

        private void p_barra_Resize(object sender, EventArgs e)
        {
            int x = (p_barra.Size.Width - lbl_localizacao.Width) / 2;
            int y = (p_barra.Size.Height - lbl_localizacao.Height);       //Posição da label na barra ao maximizar e desmaximizar 

            lbl_localizacao.Location = new Point(x, y);
        }

        private void pb_voltar_MouseEnter(object sender, EventArgs e)
        {
            pb_voltar.Image = Properties.Resources.VoltarRoxo;              //Animação de voltar
        }

        private void pb_voltar_MouseLeave(object sender, EventArgs e)
        {
            pb_voltar.Image = Properties.Resources.voltar;                 //Animação de voltar desfeita
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

        private void pb_voltar_Click(object sender, EventArgs e)
        {
            this.Hide();
            TelaConfiguracao f = new TelaConfiguracao();               //Voltar para tela principal
            f.Closed += (s, args) => this.Close();
            f.ShowDialog();
        }
    }
}
