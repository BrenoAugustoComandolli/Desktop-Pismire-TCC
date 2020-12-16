using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Windows.Forms;
using System.Net;
using Pismire_TCC.Resources;
using System.Data.Entity.Migrations;

namespace Pismire_TCC
{
    public partial class TelaSeguranca : Form
    {
        PismireEntities5 bd = new PismireEntities5();
        int codigo = 0;                                     

        public TelaSeguranca()
        {
            InitializeComponent();
            Maximizacao.verifique(this, pbMaximizar);   //Verifica se a tela está maximizada ou não
        }

        private void bloquear()
        {
            pb_voltar.Enabled = false;
            tb_sen.Enabled = false;
            tb_nov.Enabled = false;              //Bloquear comandos
            tb_rep.Enabled = false;
            tb_sen.Clear();
            tb_nov.Clear();
            tb_rep.Clear();
        }

        private void desbloquear()
        {
            pb_voltar.Enabled = true;
            tb_sen.Enabled = true;
            tb_nov.Enabled = true;             //Desbloquear comandos
            tb_rep.Enabled = true;
            tbEmail.Clear();
            tbCodigo.Clear();
        }

        private void lbl_esqueceu_MouseEnter(object sender, EventArgs e)
        {
            lbl_esqueceu.ForeColor = Color.FromArgb(197, 189, 251);
        }
       
        private void lbl_esqueceu_MouseLeave(object sender, EventArgs e)
        {
            lbl_esqueceu.ForeColor = Color.White;
        }

        private void p_barra_Paint(object sender, PaintEventArgs e)
        {
            int x = (p_barra.Size.Width - lbl_senha.Width) / 2;
            int y = (p_barra.Size.Height - lbl_senha.Height);              //Posição da label na barra

            lbl_senha.Location = new Point(x, y);
            tb_sen.Focus();
        }

        private void p_barra_Resize(object sender, EventArgs e)
        {
            int x = (p_barra.Size.Width - lbl_senha.Width) / 2;
            int y = (p_barra.Size.Height - lbl_senha.Height);              //Posição da label na barra ao maximizar e desmaximizar 

            lbl_senha.Location = new Point(x, y);
        }

        private void pb_voltar_MouseEnter(object sender, EventArgs e)
        {
            pb_voltar.Image = Properties.Resources.VoltarRoxo;               //Animação de voltar
        }

        private void pb_voltar_MouseLeave(object sender, EventArgs e)
        {
            pb_voltar.Image = Properties.Resources.voltar;                   //Animação de voltar desfeita
        }

        private void pb_voltar_Click(object sender, EventArgs e)
        {
            this.Hide();
            TelaConfiguracao f = new TelaConfiguracao();
            f.Closed += (s, args) => this.Close();                  //Voltar para tela cofiguração
            f.ShowDialog();
        }

        private void lbl_esqueceu_Click(object sender, EventArgs e)
        {
            tbEmail.Focus();
            bloquear();                                          //Botão de esquecer a senha 
            pEmail.Visible = true;
        }

        private void btCancelar1_Click(object sender, EventArgs e)
        {
            p_codigo.Visible = false;                                //Cancelar a janela de código
            desbloquear();
        }

        private void btConfirmar1_Click(object sender, EventArgs e)
        {
            if (tbCodigo.Text.Equals(codigo.ToString()))
            {
                p_codigo.Visible = false;
                p_mensagem.Visible = true;
                tb_senha.Focus();
                bloquear();
            }                                                //Confirmação de código 
            else
            {
                p_codigo.Visible = false;
                Mensagem.aviso = "Código inválido!";
                TelaMensagemAviso f = new TelaMensagemAviso();
                f.ShowDialog();
                tbCodigo.Clear();
                p_codigo.Visible = true;
            }
        }

        private void btCancelar2_Click(object sender, EventArgs e)
        {
            p_mensagem.Visible = false;                                 //Cancelar código
            desbloquear();
        }

        private void btConfirmar2_Click(object sender, EventArgs e)
        {
            try
            {
                if (tb_senha.Text != "" && tb_repita.Text != "")
                {
                    var usuario = bd.usuario.Where(x => x.idUsuario == UsuarioDados.Id).FirstOrDefault();   //Troca de senha 

                    if (tb_senha.Text.Equals(tb_repita.Text))
                    {
                        usuario.senhaUsuario = tb_senha.Text;
                        bd.usuario.AddOrUpdate(usuario);
                        bd.SaveChanges();

                        p_mensagem.Visible = false;
                        Mensagem.aviso = "Senha trocada com sucesso!";
                        TelaMensagemAviso f = new TelaMensagemAviso();              //Erro ao salvar
                        f.ShowDialog();
                        p_mensagem.Visible = true;

                        tb_senha.Clear();
                        tb_repita.Clear();

                        p_mensagem.Visible = false;
                        desbloquear();

                        this.Hide();
                        TelaLogin form = new TelaLogin();
                        form.Closed += (s, args) => this.Close();                  //Pela segurança o usuario volta para tela de login
                        form.ShowDialog();
                    }
                    else
                    {
                        p_mensagem.Visible = false;
                        Mensagem.aviso = "Senhas não correspondentes!";
                        TelaMensagemAviso f = new TelaMensagemAviso();              //Erro ao salvar
                        f.ShowDialog();
                        p_mensagem.Visible = true;

                        tb_senha.Clear();
                        tb_repita.Clear();
                    }
                }
                else
                {
                    p_mensagem.Visible = false;
                    Mensagem.aviso = "Preencha todos os campos!";
                    TelaMensagemAviso f = new TelaMensagemAviso();              //Erro ao salvar
                    f.ShowDialog();
                    p_mensagem.Visible = true;
                }                                                         //Confirmação de código
            }
            catch (Exception)
            {
                Mensagem.aviso = "Erro de conexão com o banco!";
                TelaMensagemAviso f = new TelaMensagemAviso();
                f.ShowDialog();
            }
        }

        private void btConfirmar1_MouseEnter(object sender, EventArgs e)
        {
            btConfirmar1.ForeColor = Color.Black;
        }

        private void btConfirmar1_MouseLeave(object sender, EventArgs e)
        {
            btConfirmar1.ForeColor = Color.White;
        }

        private void btCancelar1_MouseEnter(object sender, EventArgs e)
        {
            btCancelar1.ForeColor = Color.Black;
        }

        private void btCancelar1_MouseLeave(object sender, EventArgs e)
        {
            btCancelar1.ForeColor = Color.White;
        }                                                                           

        private void btConfirmar2_MouseEnter(object sender, EventArgs e)
        {
            btConfirmar2.ForeColor = Color.Black;
        }

        private void btConfirmar2_MouseLeave(object sender, EventArgs e)
        {
            btConfirmar2.ForeColor = Color.White;
        }

        private void btCancelar2_MouseEnter(object sender, EventArgs e)
        {
            btCancelar2.ForeColor = Color.Black;
        }

        private void btCancelar2_MouseLeave(object sender, EventArgs e)
        {
            btCancelar2.ForeColor = Color.White;
        }

        private void btConfirmar3_Click(object sender, EventArgs e)
        {
            try
            {
                var usuario = bd.usuario.Where(x => x.idUsuario == UsuarioDados.Id).FirstOrDefault();
                string nome = usuario.nomeUsuario;
                string emailUsuario = usuario.e_mailUsuario;

                if (tbEmail.Text == emailUsuario)
                {
                    Random rand = new Random();
                    this.codigo = Convert.ToInt32(rand.NextDouble() * 1000000);

                    string senderEmail = "central.pismire@gmail.com";                              //Confirmar envio de e-mail
                    string message = "[" + this.codigo + "]";

                    SmtpClient client = new SmtpClient();
                    client.Host = "smtp.gmail.com";
                    client.EnableSsl = true;
                    client.Port = 587;
                    client.Credentials = new NetworkCredential("central.pismire@gmail.com", "tcctatop");
                    MailMessage mail = new MailMessage();
                    mail.Sender = new MailAddress("central.pismire@gmail.com", "Pimsire");
                    mail.From = new MailAddress("central.pismire@gmail.com", "Pismire");
                    mail.To.Add(new MailAddress(tbEmail.Text, nome));
                    mail.Subject = "CÓDIGO DE VERIFICAÇÃO";
                    mail.Body = "Olá " + nome + ", você está recebendo este e-mail pois perdeu sua senha, " +
                        "porém não se preocupe, nós da Pismire prezamos pela segurança de nossos usuários! Confirme seu e-mail" +
                        " para que possamos resgatar sua conta.<br/><br/> Email de contato: "
                        + senderEmail + " <br/><br/><b>CÓGIDO DE RECUPERAÇÃO: " + message + "</b><br/><br/>Atenciosamente Central Pismire!";
                    mail.IsBodyHtml = true;
                    mail.Priority = MailPriority.High;

                    try
                    {
                        client.Send(mail);
                    }
                    catch (System.Exception erro)
                    {
                        //trata erro
                        MessageBox.Show("erro: " + erro);
                    }
                    finally
                    {
                        mail = null;
                    }

                    pEmail.Visible = false;
                    p_codigo.Visible = true;
                }
                else
                {
                    pEmail.Visible = false;
                    Mensagem.aviso = "E-mail incompatível!";
                    TelaMensagemAviso f = new TelaMensagemAviso();              //Erro ao enviar
                    f.ShowDialog();
                    tbEmail.Clear();
                    pEmail.Visible = true;
                }
            }
            catch (Exception)
            {
                Mensagem.aviso = "Erro ao enviar!";
                TelaMensagemAviso f = new TelaMensagemAviso();
                f.ShowDialog();
            }
        }

        private void btCancelar3_Click(object sender, EventArgs e)
        {
            pEmail.Visible = false;
            desbloquear();                                           //cancelar janela código
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
            this.WindowState = FormWindowState.Minimized;             //Minimizar tela 
        }

        private void bt_salvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (tb_sen.Text != "" && tb_nov.Text != "" && tb_rep.Text != "")
                {
                    var usuario = bd.usuario.Where(x => x.idUsuario == UsuarioDados.Id).FirstOrDefault();
                    var senha = usuario.senhaUsuario;
                    //Troca de senha 
                    if (senha.Equals(tb_sen.Text))
                    {
                        if (tb_nov.Text.Equals(tb_rep.Text))
                        {
                            usuario.senhaUsuario = tb_nov.Text;
                            bd.usuario.AddOrUpdate(usuario);
                            bd.SaveChanges();

                            Mensagem.aviso = "Senha trocada com sucesso!";
                            TelaMensagemAviso f = new TelaMensagemAviso();              //Erro ao salvar
                            f.ShowDialog();

                            tb_sen.Clear();
                            tb_nov.Clear();
                            tb_rep.Clear();

                            this.Hide();
                            TelaLogin form = new TelaLogin();
                            form.Closed += (s, args) => this.Close();                  //Pela segurança o usuario volta para tela de login
                            form.ShowDialog();
                        }
                        else
                        {
                            Mensagem.aviso = "Senhas não correspondentes!";
                            TelaMensagemAviso f = new TelaMensagemAviso();              //Erro ao salvar
                            f.ShowDialog();
                            tb_nov.Clear();
                            tb_rep.Clear();
                        }
                    }
                    else
                    {
                        Mensagem.aviso = "Senha atual incorreta!";
                        TelaMensagemAviso f = new TelaMensagemAviso();              //Erro ao salvar
                        f.ShowDialog();
                        tb_sen.Clear();
                    }
                }
                else
                {
                    Mensagem.aviso = "Preencha todos os campos!";
                    TelaMensagemAviso f = new TelaMensagemAviso();              //Erro ao salvar
                    f.ShowDialog();
                }
            }
            catch (Exception)
            {
                Mensagem.aviso = "Erro de conexão com o banco!";
                TelaMensagemAviso f = new TelaMensagemAviso();
                f.ShowDialog();
            }
        }

        private void btConfirmar3_MouseEnter(object sender, EventArgs e)
        {
            btConfirmar3.ForeColor = Color.Black;
        }

        private void btConfirmar3_MouseLeave(object sender, EventArgs e)
        {
            btConfirmar3.ForeColor = Color.White;
        }                                                                      

        private void btCancelar3_MouseEnter(object sender, EventArgs e)
        {
            btCancelar3.ForeColor = Color.Black;
        }

        private void btCancelar3_MouseLeave(object sender, EventArgs e)
        {
            btCancelar3.ForeColor = Color.White;
        }
    }
}
