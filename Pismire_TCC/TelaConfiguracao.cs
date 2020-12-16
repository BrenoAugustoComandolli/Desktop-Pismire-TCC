using Pismire_TCC.Resources;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Pismire_TCC
{
    public partial class TelaConfiguracao : Form
    {
        PismireEntities5 bd = new PismireEntities5();

        public TelaConfiguracao()
        {
            InitializeComponent();   //Método construtor

            try
            {
                var usuario = bd.usuario.Where(x => x.idUsuario == UsuarioDados.Id).FirstOrDefault();

                if (usuario.tipoUsuario == true)
                {
                    pnLocalizacao.Visible = true;  //Ativa localização para usuário trabalhador
                }

                Maximizacao.verifique(this, pbMaximizar);   //Verifica se a tela está maximizada ou não
            }
            catch (Exception)
            {
                Mensagem.aviso = "Erro ao abrir!";
                TelaMensagemAviso f = new TelaMensagemAviso();
                f.ShowDialog();
            }
        }

        private void pb_voltar_MouseEnter(object sender, EventArgs e)
        {
            pb_voltar.Image = Properties.Resources.VoltarRoxo;              //Animação de voltar
        }

        private void pb_voltar_MouseLeave(object sender, EventArgs e)
        {
            pb_voltar.Image = Properties.Resources.voltar;                 //Animação de voltar desfeita
        }

        private void p_barra_Paint(object sender, PaintEventArgs e)
        {
            int x = (p_barra.Size.Width - lbl_configuracao.Width) / 2;
            int y = (p_barra.Size.Height - lbl_configuracao.Height);              //Posição da label na barra

            lbl_configuracao.Location = new Point(x, y);
        }

        private void TelaConfiguracao_Resize(object sender, EventArgs e)
        {
            int x = (p_barra.Size.Width - lbl_configuracao.Width) / 2;
            int y = (p_barra.Size.Height - lbl_configuracao.Height);       //Posição da label na barra ao maximizar e desmaximizar 

            lbl_configuracao.Location = new Point(x, y);
        }

        private void p_barra_Resize(object sender, EventArgs e)
        {
            int x = (p_barra.Size.Width - lbl_configuracao.Width) / 2;
            int y = (p_barra.Size.Height - lbl_configuracao.Height);       //Posição da label na barra ao maximizar e desmaximizar 

            lbl_configuracao.Location = new Point(x, y);
        }

        private void pbNotificacao_MouseEnter(object sender, EventArgs e)
        {
            lbl_notificacao.ForeColor = Color.FromArgb(197, 189, 251);     //Animação notificacao
            pb_notificacao.Image = Properties.Resources.NotificacaoRoxo;
        }

        private void pbNotificacao_MouseLeave(object sender, EventArgs e)
        {
            lbl_notificacao.ForeColor = Color.White;                      //Animação notificacao desativada
            pb_notificacao.Image = Properties.Resources.Notificacao2;
        }

        private void pnPrivacidade_MouseEnter(object sender, EventArgs e)
        {
            lbl_privacidade.ForeColor = Color.FromArgb(197, 189, 251);       //Aniamação privacidade
            pb_privacidade.Image = Properties.Resources.privacidadeRoxo;
        }

        private void pnPrivacidade_MouseLeave(object sender, EventArgs e)
        {
            lbl_privacidade.ForeColor = Color.White;                          //Animação privacidade desativada
            pb_privacidade.Image = Properties.Resources.cadeado2;
        }

        private void pnSeguranca_MouseEnter(object sender, EventArgs e)
        {
            lbl_seguranca.ForeColor = Color.FromArgb(197, 189, 251);         //Animação segurança     
            pb_seguranca.Image = Properties.Resources.cadeadoRoxo;
        }

        private void pnSeguranca_MouseLeave(object sender, EventArgs e)
        {
            lbl_seguranca.ForeColor = Color.White;                          //Animação segurança desativada
            pb_seguranca.Image = Properties.Resources.cadeado5;
        }

        private void pnAjuda_MouseEnter(object sender, EventArgs e)
        {
            lbl_ajuda.ForeColor = Color.FromArgb(197, 189, 251);            //Animação ajuda
            pb_ajuda.Image = Properties.Resources.ajudaRoxo;
        }

        private void pnAjuda_MouseLeave(object sender, EventArgs e)
        {
            lbl_ajuda.ForeColor = Color.White;                              //Animação ajuda desativada
            pb_ajuda.Image = Properties.Resources.informacao2;
        }

        private void pnSobre_MouseEnter(object sender, EventArgs e)
        {
            lbl_sobre.ForeColor = Color.FromArgb(197, 189, 251);           //Animação sobre
            pb_sobre.Image = Properties.Resources.infoRoxo;
        }

        private void pnSobre_MouseLeave(object sender, EventArgs e)
        {
            lbl_sobre.ForeColor = Color.White;                            //Animação sobre desativada
            pb_sobre.Image = Properties.Resources.informacao;
        }

        private void pbLocalizacao_MouseEnter(object sender, EventArgs e)
        {
            lbl_localizacao.ForeColor = Color.FromArgb(197, 189, 251);           //Animação localizacao
            pb_localizacao.Image = Properties.Resources.localRoxo;
        }

        private void pbLocalizacao_MouseLeave(object sender, EventArgs e)
        {
            lbl_localizacao.ForeColor = Color.White;                            //Animação localizacao desativada
            pb_localizacao.Image = Properties.Resources.local2;
        }

        private void pbNotificacao_Click(object sender, EventArgs e)
        {
            this.Hide();
            TelaConfiguracaoNotificacao f = new TelaConfiguracaoNotificacao();               //Abrir tela configurações de notificacao
            f.Closed += (s, args) => this.Close();
            f.ShowDialog();
        }

        private void pnPrivacidade_Click(object sender, EventArgs e)
        {
            this.Hide();
            TelaConfiguracaoPrivacidade f = new TelaConfiguracaoPrivacidade();               //Abrir tela configurações de privacidade
            f.Closed += (s, args) => this.Close();
            f.ShowDialog();
        }

        private void pnSeguranca_Click(object sender, EventArgs e)
        {
            this.Hide();
            TelaSeguranca f = new TelaSeguranca();               //Abrir tela configurações de seguranca
            f.Closed += (s, args) => this.Close();
            f.ShowDialog();
        }

        private void pnAjuda_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://localhost:8080/ajuda");                //Abrir tela configurações de ajuda
        }

        private void pnSobre_Click(object sender, EventArgs e)
        {
            this.Hide();
            TelaSobre f = new TelaSobre();               //Abrir tela configurações de sobre
            f.Closed += (s, args) => this.Close();
            f.ShowDialog();
        }

        private void pbLocalizacao_Click(object sender, EventArgs e)
        {
            this.Hide();
            TelaConfiguracaoLocalizacao f = new TelaConfiguracaoLocalizacao();               //Abrir tela configurações de localizacao
            f.Closed += (s, args) => this.Close();
            f.ShowDialog();
        }

        private void pb_voltar_Click(object sender, EventArgs e)
        {
            try
            {
                var usuario = bd.usuario.Where(x => x.idUsuario == UsuarioDados.Id).FirstOrDefault();

                if (usuario.tipoUsuario == true)
                {
                    this.Hide();
                    TelaPrincipalTrabalhador f = new TelaPrincipalTrabalhador();               //Voltar para tela principal
                    f.Closed += (s, args) => this.Close();
                    f.ShowDialog();
                }
                else
                {
                    this.Hide();
                    TelaPrincipalEmpresa f = new TelaPrincipalEmpresa();               //Voltar para tela principal
                    f.Closed += (s, args) => this.Close();
                    f.ShowDialog();
                }
            }
            catch (Exception)
            {
                Mensagem.aviso = "Erro ao voltar!";
                TelaMensagemAviso f = new TelaMensagemAviso();
                f.ShowDialog();
            }
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
