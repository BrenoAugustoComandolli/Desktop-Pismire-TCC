using Pismire_TCC.Resources;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Pismire_TCC
{
    public partial class TelaMensagemAberta : Form
    {
        PismireEntities5 bd = new PismireEntities5();
        public TelaMensagemAberta()
        {
            InitializeComponent();

            try
            {
                Maximizacao.verifique(this, pbMaximizar);   //Verifica se a tela está maximizada ou não

                var mensagem = bd.mensagem.Where(y => y.destinatarioMensagem ==
                UsuarioDados.Id).Where(x => x.idMensagem == PegarID.IDN).FirstOrDefault();

                var usuario = bd.usuario.Where(x => x.idUsuario == mensagem.FK_usuario).FirstOrDefault();
                
                if (usuario.tipoUsuario == true)
                {
                    pbFoto.Visible = false;
                    var trab = bd.usuario_trabalhador.Where(x => x.FK_usuario == usuario.idUsuario).FirstOrDefault();
                    var curriculo = bd.curriculo.Where(x => x.FK_usuario_trabalhador == trab.CPF).FirstOrDefault();

                    if (curriculo.fotoUsuario != null)
                    {
                        byte[] ImageSource = curriculo.fotoUsuario;
                        pbFotoTrab.Visible = true;
                        using (MemoryStream stream = new MemoryStream(ImageSource))
                        {
                            pbFotoTrab.Image = new Bitmap(stream);
                        }
                    }
                }
                else
                {
                    pbFotoTrab.Visible = false;
                    var empresa = bd.usuario_empresa.Where(x => x.FK_usuario == usuario.idUsuario).FirstOrDefault();
                    var perfil = bd.perfil_empresa.Where(x => x.FK_usuario_empresa == empresa.cnpj).FirstOrDefault();

                    if (perfil.fotoEmpresa != null)
                    {
                        byte[] ImageSource = perfil.fotoEmpresa;
                        pbFoto.Visible = true;
                        using (MemoryStream stream = new MemoryStream(ImageSource))
                        {
                            pbFoto.Image = new Bitmap(stream);
                        }
                    }
                }

                lbl_mensagem.Text = usuario.nomeUsuario;
                lblTexto.Text = mensagem.textoMensagem;
                lblData.Text = mensagem.dataMensagem.ToShortDateString();
                lblHorario.Text = mensagem.horarioMensagem.ToString();
            }
            catch (Exception)
            {
                Mensagem.aviso = "Erro ao carregar mensagem!";
                TelaMensagemAviso f = new TelaMensagemAviso();  //Verificação de campos
                f.ShowDialog();
            }
        }

        private void pbVoltar_Click(object sender, EventArgs e)
        {
            var usu = bd.usuario.Where(x => x.idUsuario == UsuarioDados.Id).FirstOrDefault();
            if(usu.tipoUsuario == true)
            {
                this.Hide();
                TelaMensagemTrabalhador g = new TelaMensagemTrabalhador();
                g.Closed += (s, args) => this.Close();
                g.ShowDialog();
            }
            else
            {
                this.Hide();
                TelaMensagemEmpresa g = new TelaMensagemEmpresa();
                g.Closed += (s, args) => this.Close();
                g.ShowDialog();
            }
            
        }

        private void pbLixeira_Click(object sender, EventArgs e)
        {
            pLixeiraAberta.Visible = true;
            pbVoltar.Enabled = false;
            pbLixeira.Enabled = false;
        }

        private void btConfirmar_Click(object sender, EventArgs e)
        {
            var mensagem = bd.mensagem.Where(x => x.idMensagem == PegarID.IDN).FirstOrDefault();

            if (mensagem != null)
            {
                int max = bd.mensagem.Where(x => x.destinatarioMensagem == UsuarioDados.Id).Where
                    (x => x.FK_usuario == mensagem.FK_usuario).Max(x => x.idMensagem);

                if (max != 1)
                {
                    try
                    {
                        var notf = bd.mensagem.Where(Z => Z.idMensagem == PegarID.IDN).FirstOrDefault();

                        bd.mensagem.Remove(notf);
                        bd.SaveChanges();

                        pLixeiraAberta.Visible = false;
                        pbVoltar.Enabled = true;
                        pbLixeira.Enabled = true;
                        Mensagem.aviso = "Excluído com sucesso!";
                        TelaMensagemAviso m = new TelaMensagemAviso();
                        m.ShowDialog();

                        this.Hide();
                        TelaMensagemTrabalhador g = new TelaMensagemTrabalhador();
                        g.Closed += (s, args) => this.Close();
                        g.ShowDialog();
                    }
                    catch (Exception)
                    {
                        pLixeiraAberta.Visible = false;
                        pbVoltar.Enabled = true;
                        pbLixeira.Enabled = true;
                        Mensagem.aviso = "Erro ao excluir!";
                        TelaMensagemAviso m = new TelaMensagemAviso();
                        m.ShowDialog();
                    }
                }
                else
                {
                    try
                    {
                        var notf = bd.notificacao.Where(Z => Z.idNotificacao == PegarID.IDN).FirstOrDefault();

                        bd.notificacao.Remove(notf);

                        bd.SaveChanges();

                        pLixeiraAberta.Visible = false;
                        pbVoltar.Enabled = true;
                        pbLixeira.Enabled = true;
                        Mensagem.aviso = "Excluído com sucesso!";
                        TelaMensagemAviso m = new TelaMensagemAviso();
                        m.ShowDialog();

                        this.Hide();
                        TelaMensagemTrabalhador g = new TelaMensagemTrabalhador();
                        g.Closed += (s, args) => this.Close();
                        g.ShowDialog();
                    }
                    catch
                    {
                        pLixeiraAberta.Visible = false;
                        pbVoltar.Enabled = true;
                        pbLixeira.Enabled = true;
                        Mensagem.aviso = "Erro ao excluir!";
                        TelaMensagemAviso m = new TelaMensagemAviso();
                        m.ShowDialog();
                    }
                }
            }
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            pLixeiraAberta.Visible = false;
            pbVoltar.Enabled = true;
            pbLixeira.Enabled = true;
        }

        private void pbLixeira_MouseEnter(object sender, EventArgs e)
        {
            pbLixeira.Image = Properties.Resources.excluirRoxo;
        }

        private void pbLixeira_MouseLeave(object sender, EventArgs e)
        {
            pbLixeira.Image = Properties.Resources.excluir;                       //Animação dos icones
        }

        private void pbVoltar_MouseEnter(object sender, EventArgs e)
        {
            pbVoltar.Image = Properties.Resources.VoltarRoxo;
        }

        private void pbVoltar_MouseLeave(object sender, EventArgs e)
        {
            pbVoltar.Image = Properties.Resources.voltar;
        }

        private void p_barra_Paint(object sender, PaintEventArgs e)
        {
            int x = (p_barra.Size.Width - lbl_mensagem.Width) / 2;
            int y = (p_barra.Size.Height - lbl_mensagem.Height);              //Posição da label na barra

            lbl_mensagem.Location = new Point(x, y);
        }

        private void p_barra_Resize(object sender, EventArgs e)
        {
            int x = (p_barra.Size.Width - lbl_mensagem.Width) / 2;
            int y = (p_barra.Size.Height - lbl_mensagem.Height);              //Posição da label na barra

            lbl_mensagem.Location = new Point(x, y);
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

        private void btConfirmar_MouseEnter(object sender, EventArgs e)
        {
            btConfirmar.ForeColor = Color.Black;
        }

        private void btConfirmar_MouseLeave(object sender, EventArgs e)
        {
            btConfirmar.ForeColor = Color.White;
        }

        private void btCancelar_MouseEnter(object sender, EventArgs e)
        {
            btCancelar.ForeColor = Color.Black;
        }

        private void btCancelar_MouseLeave(object sender, EventArgs e)
        {
            btCancelar.ForeColor = Color.White;
        }
    }
}
