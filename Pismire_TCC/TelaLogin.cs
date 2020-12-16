using Pismire_TCC.Resources;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.NetworkInformation;

namespace Pismire_TCC 
{
    public partial class TelaLogin : Form
    {
        PismireEntities5 bd = new PismireEntities5();

        [System.Runtime.InteropServices.DllImport("wininet.dll")]        //Status de conexão com a rede 
        private static extern bool InternetGetConnectedState(out int Description, int ReservedValue);

        public TelaLogin()
        {
            InitializeComponent();
        }

        public void entrar()
        {
            int desc;
            bool hasConnection = InternetGetConnectedState(out desc, 0);  //Status de conexao com a rede

            try
            {
                hasConnection = (new Ping().Send("www.google.com").Status == IPStatus.Success) ? true : false;

                string login = txtLogin.Text;
                string senha = txtSenha.Text;

                try
                {
                    var entrada = bd.usuario.FirstOrDefault(p => p.e_mailUsuario.Equals(login) && p.senhaUsuario.Equals(senha));

                    if (entrada != null)
                    {
                        var usuario = bd.usuario.Where(p => p.e_mailUsuario.Equals(login)).SingleOrDefault();

                        UsuarioDados.Id = usuario.idUsuario;

                        if ((usuario.e_mailUsuario == "central.pismire@gmail.com") && (usuario.senhaUsuario == "00000000"))
                        {
                            UsuarioDados.Id = usuario.idUsuario;
                            this.Hide();
                            TelaNotificacaoADM f = new TelaNotificacaoADM();       //Entrada do perfil ADM
                            f.Closed += (s, args) => this.Close();
                            f.ShowDialog();
                        }
                        else if (usuario.tipoUsuario == true)
                        {
                            var usuarioTrab = bd.usuario_trabalhador.Where(x => x.FK_usuario == UsuarioDados.Id).FirstOrDefault();

                            if (usuarioTrab != null)
                            {
                                var curriculo = bd.curriculo.Where(x => x.FK_usuario_trabalhador == usuarioTrab.CPF).FirstOrDefault();

                                if(curriculo != null)
                                {
                                    TesteTutorial.entrou = true;            //Entra no usuário trabalhador
                                    TesteTutorial.instrucao = true;
                                }
                                else
                                {
                                    TesteTutorial.entrou = false;
                                    TesteTutorial.instrucao = false;
                                }
                            }
                            else
                            {
                                TesteTutorial.entrou = false;
                                TesteTutorial.instrucao = false;
                            }

                            var preferencia = bd.preferencia.Where(x => x.FK_usuario == UsuarioDados.Id).FirstOrDefault();

                            if (preferencia == null)
                            {
                                preferencia add = new preferencia();
                                add.receberNotificacao = true;
                                add.receberRecomendacoes = true;
                                add.privacidade = true;                  //Atribui primeira vez as opções de preferencia
                                add.localizacao = true;
                                add.FK_usuario = UsuarioDados.Id;
                                bd.preferencia.Add(add);
                                bd.SaveChanges();
                                Preferencias.notf = true;
                                Preferencias.rec = true;
                                Preferencias.priv = true;
                                Preferencias.salvar = true;
                                Preferencias.local = true;
                            }
                            else
                            {
                                Preferencias.notf = preferencia.receberNotificacao;
                                Preferencias.rec = preferencia.receberRecomendacoes;
                                Preferencias.priv = preferencia.privacidade;
                                Preferencias.local = preferencia.localizacao;
                            }

                            this.Hide();
                            TelaPrincipalTrabalhador f = new TelaPrincipalTrabalhador();
                            f.Closed += (s, args) => this.Close();
                            f.ShowDialog();
                        }
                        else
                        {
                            var usuarioEmp = bd.usuario_empresa.Where(x => x.FK_usuario == UsuarioDados.Id).FirstOrDefault();

                            if (usuarioEmp != null)
                            {
                                var perfil = bd.perfil_empresa.Where(x => x.FK_usuario_empresa == usuarioEmp.cnpj).FirstOrDefault();

                                if (perfil != null)
                                {
                                    TesteTutorial.entrou = true;        //Entra no usuário empresa
                                    TesteTutorial.instrucao = true;
                                }
                                else
                                {
                                    TesteTutorial.entrou = false;
                                    TesteTutorial.instrucao = false;
                                }
                            }
                            else
                            {
                                TesteTutorial.entrou = false;
                                TesteTutorial.instrucao = false;
                            }

                            var preferencia = bd.preferencia.Where(x => x.FK_usuario == UsuarioDados.Id).FirstOrDefault();

                            if (preferencia == null)
                            {
                                preferencia add = new preferencia();
                                add.receberNotificacao = true;
                                add.receberRecomendacoes = true;
                                add.privacidade = true;                  //Atribui primeira vez as opções de preferencia
                                add.localizacao = false;
                                add.FK_usuario = UsuarioDados.Id;
                                bd.preferencia.Add(add);
                                bd.SaveChanges();
                                Preferencias.notf = true;
                                Preferencias.rec = true;
                                Preferencias.priv = true;
                                Preferencias.salvar = true;
                                Preferencias.local = false;
                            }
                            else
                            {
                                Preferencias.notf = preferencia.receberNotificacao;
                                Preferencias.rec = preferencia.receberRecomendacoes;
                                Preferencias.priv = preferencia.privacidade;
                                Preferencias.local = preferencia.localizacao;
                            }

                            this.Hide();
                            TelaPrincipalEmpresa f = new TelaPrincipalEmpresa();
                            f.Closed += (s, args) => this.Close();
                            f.ShowDialog();
                        }
                    }
                    else
                    {
                        Mensagem.aviso = "Usuário não encontrado!";
                        TelaMensagemAvisoAlternativa f = new TelaMensagemAvisoAlternativa();  //Verificação de campos
                        f.ShowDialog();
                    }
                }
                catch (Exception)
                {
                    Mensagem.aviso = "Erro de conexão com o banco!";
                    TelaMensagemAvisoAlternativa f = new TelaMensagemAvisoAlternativa();  //Verificação de conexao
                    f.ShowDialog();
                    this.Close();
                }
            }
            catch
            {
                Mensagem.aviso = "Conexão expirada, por favor verifique seu acesso a Internet.";
                TelaMensagemAvisoAlternativa f = new TelaMensagemAvisoAlternativa();
                f.ShowDialog();

                this.Close(); //Fecha o programa
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

        private void pbMaximizar_MouseEnter(object sender, EventArgs e)    //Animação de botões 
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

        private void pbMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;    //Minimizar tela
        }

        private async void TelaLogin_LoadAsync(object sender, EventArgs e)
        {
            if (UsuarioDados.Id == 0)
            {
                long lContador = 0;
                for (long l = 0; l < 7; l++)
                {
                    await Task.Delay(500);
                    if (l == lContador + 3)
                    {
                        label4.Text = "";
                        lContador += 3;                   //Animação de entrada 
                        --l;
                    }
                    else
                    {
                        label4.Text += "•";
                    }
                }

                label4.Visible = false;
                pbAnimacao.Visible = false;
            }
            else
            {
                label4.Visible = false;
                pbAnimacao.Visible = false;
            }
        }

        private void btEntrar_Click(object sender, EventArgs e)          //Entrada no sistema
        {
            entrar();
        }

        private void TelaLogin_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                entrar();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.linkLabel1.LinkVisited = true;

            System.Diagnostics.Process.Start("http://localhost:8080/cadastro");  //Link site 
        }

        private void btEntrar_MouseEnter(object sender, EventArgs e)
        {
            btEntrar.Image = Properties.Resources.ButtonTeste3Roxo;
        }

        private void btEntrar_MouseLeave(object sender, EventArgs e)
        {
            btEntrar.Image = Properties.Resources.ButtonTeste3;
        }
    }
}
