using System;
using System.Data;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Pismire_TCC.Resources;

namespace Pismire_TCC
{
    public partial class TelaConfiguracaoPrivacidade : Form
    {
        PismireEntities5 bd = new PismireEntities5();
        int id = UsuarioDados.Id;                             //Atributos

        public TelaConfiguracaoPrivacidade()
        {
            InitializeComponent();
            Maximizacao.verifique(this, pbMaximizar);   //Verifica se a tela está maximizada ou não

            try
            {
                if (Preferencias.priv == true)
                {
                    pb_privacidade.Image = Properties.Resources.selecionar3;
                }
                else                                                                  //Seleção de opção notificaoes
                {
                    pb_privacidade.Image = Properties.Resources.selecionarDesativado;
                }

                var usuario = bd.usuario.Where(x => x.idUsuario == UsuarioDados.Id).FirstOrDefault();

                if (usuario.tipoUsuario == true)
                {
                    lbl_mensagem.Text = "Se você desativar essa opção, não poderá candidatar-se a vaga";
                }
                else
                {
                    lbl_mensagem.Text = "Se você desativar essa opção, não poderá criar eventos";
                }
            }
            catch (Exception)
            {
                Mensagem.aviso = "Erro ao conectar!";
                TelaMensagemAviso f = new TelaMensagemAviso();
                f.ShowDialog();
            }
        }

        public void Image()
        {
            try
            {
                var preferencia = bd.preferencia.Where(x => x.FK_usuario == id).FirstOrDefault();

                pb_privacidade.Image = Properties.Resources.selecionar3;
                if (Preferencias.priv == true)
                {
                    pb_privacidade.Image = Properties.Resources.selecionarDesativado;     //Preenchimento no banco notificação
                    Preferencias.priv = false;
                }
                else
                {
                    pb_privacidade.Image = Properties.Resources.selecionar3;
                    Preferencias.priv = true;                                   //Preenchimento no banco notificacao
                }

                preferencia.privacidade = Preferencias.priv;
                bd.preferencia.AddOrUpdate(preferencia);                      //salvamento
                bd.SaveChanges();
            }
            catch (Exception)
            {
                Mensagem.aviso = "Erro ao conectar!";
                TelaMensagemAviso f = new TelaMensagemAviso();
                f.ShowDialog();
            }
        }

        private void pb_privacidade_Click(object sender, EventArgs e)
        {
            Image();                                                  //privacidade click
        }

        private void pb_voltar_Click(object sender, EventArgs e)
        {
            this.Hide();
            TelaConfiguracao f = new TelaConfiguracao();
            f.Closed += (s, args) => this.Close();                  //Voltar para configurações
            f.ShowDialog();
        }

        private void pb_voltar_MouseEnter(object sender, EventArgs e)
        {
            pb_voltar.Image = Properties.Resources.VoltarRoxo;           //Animação de voltar 
        }

        private void pb_voltar_MouseLeave(object sender, EventArgs e)
        {
            pb_voltar.Image = Properties.Resources.voltar;              //Animação de voltar desativada 
        }

        private void p_barra_Paint(object sender, PaintEventArgs e)
        {
            int x = (p_barra.Size.Width - lbl_privacidade.Width) / 2;
            int y = (p_barra.Size.Height - lbl_privacidade.Height);       //Posição da label na barra

            lbl_privacidade.Location = new Point(x, y);
        }

        private void p_barra_Resize(object sender, EventArgs e)
        {
            int x = (p_barra.Size.Width - lbl_privacidade.Width) / 2;
            int y = (p_barra.Size.Height - lbl_privacidade.Height);       //Posição da label na barra ao maximizar e desmaximizar 

            lbl_privacidade.Location = new Point(x, y);
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
