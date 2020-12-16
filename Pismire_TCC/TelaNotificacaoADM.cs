using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Pismire_TCC.Resources
{
    public partial class TelaNotificacaoADM : Form
    {
        PismireEntities5 bd = new PismireEntities5();  //Conexão com o Banco

        public TelaNotificacaoADM()
        {
            InitializeComponent();
            Maximizacao.verifique(this, pbMaximizar);   //Verifica se a tela está maximizada ou não
        }

        private void btEnviar_Click(object sender, EventArgs e)
        {
            if ((tbTitulo.Text == "") && (tbTexto.Text == ""))
            {
                Mensagem.aviso = "Preencha todos os campos!";    //Verificação de campos 
                TelaMensagemAviso f = new TelaMensagemAviso();
                f.ShowDialog();
            }                            
            else if (tbTitulo.Text == "")
            {
                Mensagem.aviso = "Campo de título não preenchido!";    //Verificação de campos 
                TelaMensagemAviso f = new TelaMensagemAviso();
                f.ShowDialog();
            }
            else if (tbTexto.Text == "")
            {
                Mensagem.aviso = "Campo de texto não preenchido!";    //Verificação de campos 
                TelaMensagemAviso f = new TelaMensagemAviso();
                f.ShowDialog();
            }
            else
            {
                try
                {
                    string data = (DateTime.Now.ToShortDateString()).ToString();    //Data Atual
                    string horario = (DateTime.Now.ToShortTimeString()).ToString(); //Horário Atual
                    
                    int max = bd.usuario.Max(x => x.idUsuario); //Maior ID usuário
                       
                    for (int i = 1; i <= max; i++)
                    {
                        var usuario = bd.usuario.Where(x => x.idUsuario == i).FirstOrDefault();

                        if (usuario != null)
                        {
                            notificacao add2 = new notificacao();
                            add2.tituloNotificacao = tbTitulo.Text;               //Enviar notificacao
                            add2.textoNotificacao = tbTexto.Text;
                            add2.dataNotificacao = data;
                            add2.horarioNotificacao = horario;
                            add2.situacaoNotificacao = false;
                            add2.FK_usuario = i;
                            bd.notificacao.Add(add2);
                            bd.SaveChanges();
                        }
                    }

                    Mensagem.aviso = "Notificação enviada com sucesso!";    //Mensagem de sucesso
                    TelaMensagemAviso f = new TelaMensagemAviso();
                    f.ShowDialog();
                    tbTitulo.Clear();
                    tbTexto.Clear();
                    tbTitulo.Focus();
                }
                catch (Exception)
                {
                    Mensagem.aviso = "Erro ao enviar!";                 //Mensagem de erro 
                    TelaMensagemAviso f = new TelaMensagemAviso();
                    f.ShowDialog();
                }
            }
        }

        private void btEditar_Click(object sender, EventArgs e)
        {
            this.Hide();
            TelaGerenciarNotificacoes f = new TelaGerenciarNotificacoes();    //Aberte todas as notificacoes
            f.Closed += (s, args) => this.Close();
            f.ShowDialog();
        }

        private void p_barra_Paint(object sender, PaintEventArgs e)
        {
            int x = (p_barra.Size.Width - lbl_notificacoesADM.Width) / 2;
            int y = (p_barra.Size.Height - lbl_notificacoesADM.Height);

            lbl_notificacoesADM.Location = new Point(x, y);
        }                                                                    

        private void p_barra_Resize(object sender, EventArgs e)
        {
            int x = (p_barra.Size.Width - lbl_notificacoesADM.Width) / 2;
            int y = (p_barra.Size.Height - lbl_notificacoesADM.Height);

            lbl_notificacoesADM.Location = new Point(x, y);
        }

        private void pb_voltar_MouseEnter(object sender, EventArgs e)
        {
            pb_voltar.Image = Properties.Resources.VoltarRoxo;
        }
                                                                          
        private void pb_voltar_MouseLeave(object sender, EventArgs e)
        {
            pb_voltar.Image = Properties.Resources.voltar;
        }

        private void pb_voltar_Click(object sender, EventArgs e)
        {
            this.Hide();
            TelaLogin f = new TelaLogin();
            f.Closed += (s, args) => this.Close();       //Volta para tela de login
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
