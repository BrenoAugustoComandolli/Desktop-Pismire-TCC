using System;
using System.Data;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Pismire_TCC.Resources;

namespace Pismire_TCC
{
    public partial class TelaConfiguracaoNotificacao : Form
    {
        PismireEntities5 bd = new PismireEntities5();     
        int id = UsuarioDados.Id;

        public TelaConfiguracaoNotificacao()
        {
            InitializeComponent();
            Maximizacao.verifique(this, pbMaximizar);   //Verifica se a tela está maximizada ou não

            if (Preferencias.notf == true)
            {
                pbNotificacao.Image = Properties.Resources.selecionar3;
            }
            else                                                               //Seleção de opção notificaoes
            {
                pbNotificacao.Image = Properties.Resources.selecionarDesativado;
            }

            if (Preferencias.rec == true)
            {
                pbCandidato.Image = Properties.Resources.selecionar3;
            }
            else                                                               //Seleção de opção recomendações
            {
                pbCandidato.Image = Properties.Resources.selecionarDesativado;
            }
        }

        public void Image1()
        {
            try
            {
                var preferencia = bd.preferencia.Where(x => x.FK_usuario == id).FirstOrDefault();

                pbNotificacao.Image = Properties.Resources.selecionar3;
                if (Preferencias.notf == true)
                {
                    pbNotificacao.Image = Properties.Resources.selecionarDesativado;     //Preenchimento no banco notificação
                    Preferencias.notf = false;
                }
                else
                {
                    pbNotificacao.Image = Properties.Resources.selecionar3;
                    Preferencias.notf = true;                                   //Preenchimento no banco notificacao
                }

                preferencia.receberNotificacao = Preferencias.notf;
                bd.preferencia.AddOrUpdate(preferencia);                   //salvamento
                bd.SaveChanges();
            }
            catch (Exception)
            {
                Mensagem.aviso = "Erro ao conectar!";
                TelaMensagemAviso f = new TelaMensagemAviso();
                f.ShowDialog();
            }
        }

        public void Image2()
        {
            try
            {
                var preferencia = bd.preferencia.Where(x => x.FK_usuario == id).FirstOrDefault();

                pbCandidato.Image = Properties.Resources.selecionar3;
                if (Preferencias.rec == true)
                {                                                                            //Preenchimento no banco recomendacoes
                    pbCandidato.Image = Properties.Resources.selecionarDesativado;
                    Preferencias.rec = false;
                }

                else
                {
                    pbCandidato.Image = Properties.Resources.selecionar3;                     //Preenchimento no banco recomendacoes
                    Preferencias.rec = true;
                }
                preferencia.receberRecomendacoes = Preferencias.rec;
                bd.preferencia.AddOrUpdate(preferencia);
                bd.SaveChanges();                                         //Salvamento
            }
            catch (Exception)
            {
                Mensagem.aviso = "Erro ao conectar!";
                TelaMensagemAviso f = new TelaMensagemAviso();
                f.ShowDialog();
            }
        }

        private void pb_voltar_Click(object sender, EventArgs e)
        {
            this.Hide();
            TelaConfiguracao f = new TelaConfiguracao();               //Voltar para a tela configurações
            f.Closed += (s, args) => this.Close();
            f.ShowDialog();
        }

        private void pb_voltar_MouseEnter(object sender, EventArgs e)
        {
            pb_voltar.Image = Properties.Resources.VoltarRoxo;         //Animação de voltar 
        }

        private void pb_voltar_MouseLeave(object sender, EventArgs e)
        {
            pb_voltar.Image = Properties.Resources.voltar;             //Animação pode voltar 
        }

        private void pbNotificacao_Click(object sender, EventArgs e)
        {
            Image1();                                                  //Click no botão notificação
        }

        private void pbCandidato_Click(object sender, EventArgs e)
        {
            Image2();                                                  //Click no botão candidatos
        }

        private void p_barra_Paint(object sender, PaintEventArgs e)
        {
            int x = (p_barra.Size.Width - lbl_confNotificacao.Width) / 2;
            int y = (p_barra.Size.Height - lbl_confNotificacao.Height);              //Posição da label na barra

            lbl_confNotificacao.Location = new Point(x, y);
        }

        private void TelaConfNotificacao_Resize(object sender, EventArgs e)
        {
            int x = (p_barra.Size.Width - lbl_confNotificacao.Width) / 2;
            int y = (p_barra.Size.Height - lbl_confNotificacao.Height);       //Posição da label na barra ao maximizar e desmaximizar 

            lbl_confNotificacao.Location = new Point(x, y);
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
