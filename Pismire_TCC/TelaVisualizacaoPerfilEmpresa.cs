using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Pismire_TCC.Resources;

namespace Pismire_TCC
{
    public partial class TelaVisualizacaoPerfilEmpresa : Form
    {
        PismireEntities5 bd = new PismireEntities5();

        public TelaVisualizacaoPerfilEmpresa()
        {
            InitializeComponent();

            try
            {
                if (!TesteTutorial.entrou)
                {
                    pbTutorial2.Visible = true;
                }
                else
                {
                    pbTutorial2.Visible = false;
                }

                Maximizacao.verifique(this, pbMaximizar);   //Verifica se a tela está maximizada ou não

                var usu = bd.usuario.Where(x => x.idUsuario == UsuarioDados.Id).Where(y => y.tipoUsuario == false).FirstOrDefault();
                if (usu != null)
                {
                    pbEditarPerfil.Visible = true;
                    pbTutorial2.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                }
                else
                {
                    pbEditarPerfil.Visible = false;
                }
                var fk = bd.usuario_empresa.Where(x => x.FK_usuario == UsuarioDados.Id).FirstOrDefault();
                if (fk != null)
                {
                    CarregarDadosEmpresa();
                }
                else
                {
                    var teste = bd.usuario_empresa.Where(x => x.FK_usuario == PegarIDEmpresa.IDEmpresa).FirstOrDefault();
                    if (teste != null)
                    {
                        CarregarDadosTrabalhador();
                    }
                }
            }
            catch (Exception)
            {
                Mensagem.aviso = "Erro de conexão com o banco!";
                TelaMensagemAviso f = new TelaMensagemAviso();
                f.ShowDialog();
            }
        }

        private void CarregarDadosEmpresa()
        {
            try
            {
                var empresa = bd.usuario_empresa
                    .Where(x => x.FK_usuario == UsuarioDados.Id)
                    .FirstOrDefault();
                if (empresa != null)
                {
                    var perfil_empresa = bd.perfil_empresa
                    .Where(x => x.FK_usuario_empresa == empresa.cnpj)
                    .FirstOrDefault();
                    if (perfil_empresa != null)
                    {
                        var usu = bd.usuario.Where(x => x.idUsuario == UsuarioDados.Id).FirstOrDefault();
                        pbAviso.Visible = false;
                        lbl_aviso.Visible = false;
                        pbLocal.Visible = true;
                        lblArea.Visible = true;
                        pbFone.Visible = true;
                        lblTelefone.Visible = true;
                        pbSite.Visible = true;
                        lblSite.Visible = true;
                        pbArea.Visible = true;
                        lblArea.Visible = true;
                        gpRedes.Visible = true;
                        gpDesc.Visible = true;
                        lblLocal.Visible = true;
                        lblLocal.Text = $"Rua: {perfil_empresa.ruaEmpresa}, {perfil_empresa.numeroEmpresa} - {perfil_empresa.bairroEmpresa}, {perfil_empresa.cidadeEmpresa},{perfil_empresa.estadoEmpresa}, {perfil_empresa.cepEmpresa}";
                        lblTelefone.Text = $"{usu.telefoneUsuario}";
                        lblArea.Text = $"{empresa.areaEmpresa}";
                        lblGmail.Text = $"{usu.e_mailUsuario}";
                        lblFace.Text = $"{perfil_empresa.facebookEmpresa}";
                        lblinsta.Text = $"{perfil_empresa.instagram}";
                        lblTwitter.Text = $"{perfil_empresa.twitter}";
                        lblDesc.Text = $"{perfil_empresa.descricaoEmpresa}";
                        lblSite.Text = $"{perfil_empresa.site}";

                        byte[] ImageSource = perfil_empresa.fotoEmpresa;
                        pbFoto.Visible = true;
                        pbFotoPerfil.Visible = false;
                        using (MemoryStream stream = new MemoryStream(ImageSource))
                        {
                            pbFoto.Image = new Bitmap(stream);
                        }

                        if (lblDesc.Text == "")
                        {
                            gpDesc.Visible = false;
                        }
                        else
                        {
                            gpDesc.Visible = true;
                        }

                        if (lblinsta.Text == "")
                        {
                            lblinsta.Text = "Não possui";
                        }
                        if (lblTwitter.Text == "")
                        {
                            lblTwitter.Text = "Não possui";
                        }
                        if (lblFace.Text == "")
                        {
                            lblFace.Text = "Não possui";
                        }
                    }
                    var qtd = bd.evento.Where(x => x.idEvento != 0).Count();
                    if (qtd != 0)
                    {
                        pnVagas.Visible = true;
                    }
                    else
                    {
                        pnVagas.Visible = false;
                    }
                    return;
                }
            }
            catch (Exception)
            {
                Mensagem.aviso = "Erro de conexão com o banco!";
                TelaMensagemAviso f = new TelaMensagemAviso();
                f.ShowDialog();
            }
        }

        private void CarregarDadosTrabalhador()
        {
            try
            {
                var empresa = bd.usuario_empresa
                    .Where(x => x.FK_usuario == PegarIDEmpresa.IDEmpresa)
                    .FirstOrDefault();
                if (empresa != null)
                {
                    var perfil_empresa = bd.perfil_empresa
                    .Where(x => x.FK_usuario_empresa == empresa.cnpj)
                    .FirstOrDefault();
                    if (perfil_empresa != null)
                    {
                        var usu = bd.usuario.Where(x => x.idUsuario == PegarIDEmpresa.IDEmpresa).FirstOrDefault();
                        pbAviso.Visible = false;
                        lbl_aviso.Visible = false;
                        pbLocal.Visible = true;
                        lblArea.Visible = true;
                        pbFone.Visible = true;
                        lblTelefone.Visible = true;
                        pbSite.Visible = true;
                        lblSite.Visible = true;
                        pbArea.Visible = true;
                        lblArea.Visible = true;
                        gpRedes.Visible = true;
                        gpDesc.Visible = true;
                        lblLocal.Visible = true;
                        lblLocal.Text = $"Rua: {perfil_empresa.ruaEmpresa}, {perfil_empresa.numeroEmpresa} - {perfil_empresa.bairroEmpresa}, {perfil_empresa.cidadeEmpresa},{perfil_empresa.estadoEmpresa}, {perfil_empresa.cepEmpresa}";
                        lblTelefone.Text = $"{usu.telefoneUsuario}";
                        lblArea.Text = $"{empresa.areaEmpresa}";
                        lblGmail.Text = $"{usu.e_mailUsuario}";
                        lblFace.Text = $"{perfil_empresa.facebookEmpresa}";
                        lblinsta.Text = $"{perfil_empresa.instagram}";
                        lblTwitter.Text = $"{perfil_empresa.twitter}";
                        lblDesc.Text = $"{perfil_empresa.descricaoEmpresa}";
                        lblSite.Text = $"{perfil_empresa.site}";

                        byte[] ImageSource = perfil_empresa.fotoEmpresa;
                        pbFoto.Visible = true;
                        pbFotoPerfil.Visible = false;
                        using (MemoryStream stream = new MemoryStream(ImageSource))
                        {
                            pbFoto.Image = new Bitmap(stream);
                        }

                        if (lblDesc.Text == "")
                        {
                            gpDesc.Visible = false;
                        }
                        else
                        {
                            gpDesc.Visible = true;
                        }

                        if (lblinsta.Text == "")
                        {
                            lblinsta.Text = "Não possui";
                        }
                        if (lblTwitter.Text == "")
                        {
                            lblTwitter.Text = "Não possui";
                        }
                        if (lblFace.Text == "")
                        {
                            lblFace.Text = "Não possui";
                        }
                    }
                    var qtd = bd.evento.Where(x => x.idEvento != 0).Count();
                    if (qtd != 0)
                    {
                        pnVagas.Visible = true;
                    }
                    else
                    {
                        pnVagas.Visible = false;
                    }
                    return;
                }
            }
            catch (Exception)
            {
                Mensagem.aviso = "Erro de conexão com o banco!";
                TelaMensagemAviso f = new TelaMensagemAviso();
                f.ShowDialog();
            }
        }
        private void p_barra_Paint(object sender, PaintEventArgs e)
        {
            int x = (p_barra.Size.Width - lbl_perfil.Width) / 2;
            int y = (p_barra.Size.Height - lbl_perfil.Height);              //Posição da label na barra

            lbl_perfil.Location = new Point(x, y);
        }

        private void p_barra_Resize(object sender, EventArgs e)
        {
            int x = (p_barra.Size.Width - lbl_perfil.Width) / 2;
            int y = (p_barra.Size.Height - lbl_perfil.Height);              //Posição da label na barra ao maximizar e desmaximizar 

            lbl_perfil.Location = new Point(x, y);
        }

        private void pb_voltar_Click(object sender, EventArgs e)
        {
            try
            {
                var voltar = bd.usuario.Where(x => x.idUsuario == UsuarioDados.Id).Where(y => y.tipoUsuario == false).FirstOrDefault();

                if (voltar != null)
                {
                    if (PegarIDEmpresa.visualizacao == true)
                    {
                        PegarIDEmpresa.visualizacao = false;
                        this.Close();
                    }
                    else
                    {
                        this.Hide();
                        TelaPrincipalEmpresa f = new TelaPrincipalEmpresa();
                        f.Closed += (s, args) => this.Close();
                        f.ShowDialog();
                    }
                }
                else
                {
                    if (PegarIDEmpresa.visualizacao == true)
                    {
                        PegarIDEmpresa.visualizacao = false;
                        this.Close();
                    }
                    else if (VoltarTelaRecomendacao.bVoltar == true)
                    {
                        VoltarTelaRecomendacao.bVoltar = false;
                        this.Hide();
                        TelaRecomendacoes d = new TelaRecomendacoes();
                        d.Closed += (s, args) => this.Close();
                        d.ShowDialog();
                    }
                    else
                    {
                        this.Hide();
                        TelaPrincipalTrabalhador f = new TelaPrincipalTrabalhador();
                        f.Closed += (s, args) => this.Close();
                        f.ShowDialog();
                    }
                }
            }
            catch (Exception)
            {
                Mensagem.aviso = "Erro de conexão com o banco!";
                TelaMensagemAviso f = new TelaMensagemAviso();
                f.ShowDialog();
            }
        }

        private void pb_voltar_MouseEnter(object sender, EventArgs e)
        {
            pb_voltar.Image = Properties.Resources.VoltarRoxo;         //Animação do botão voltar 
        }

        private void pb_voltar_MouseLeave(object sender, EventArgs e)
        {
            pb_voltar.Image = Properties.Resources.voltar;
        }

        private void pbEditarPerfil_MouseEnter(object sender, EventArgs e)
        {
            pbEditarPerfil.Image = Properties.Resources.pessoa;
        }

        private void pbEditarPerfil_MouseLeave(object sender, EventArgs e)
        {
            pbEditarPerfil.Image = Properties.Resources.botaoEditar;
        }

        private void pbEditarPerfil_Click(object sender, EventArgs e)
        {
            this.Hide();
            TelaEditarPerfil f = new TelaEditarPerfil();        //Volta para tela principal 
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
            pbMaximizar.BackColor = Color.FromArgb(60, 62, 85);          //Efeito de opções no menu 
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

        private void pnVagas_MouseEnter(object sender, EventArgs e)
        {
            pbVagas.Image = Properties.Resources.emprego3;
            lblVagas.ForeColor = Color.FromArgb(192, 189, 251);
        }

        private void pnVagas_MouseLeave(object sender, EventArgs e)
        {
            pbVagas.Image = Properties.Resources.emprego;
            lblVagas.ForeColor = Color.White;
        }

        private void pnVagas_Click(object sender, EventArgs e)
        {
            LiberaBotaoVagas();
        }

        private void lblVagas_Click(object sender, EventArgs e)
        {
            LiberaBotaoVagas();
        }

        private void LiberaBotaoVagas()
        {
            try
            {
                var voltar = bd.usuario.Where(x => x.idUsuario == UsuarioDados.Id).Where(y => y.tipoUsuario == true).FirstOrDefault();
                if (voltar != null)
                {
                    this.Hide();
                    TelaEventosCriados f = new TelaEventosCriados();
                    f.Closed += (s, args) => this.Close();
                    f.ShowDialog();
                }
                else
                {
                    this.Hide();
                    TelaVisualizacaoVagas f = new TelaVisualizacaoVagas();
                    f.Closed += (s, args) => this.Close();
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

        private void pbVagas_Click(object sender, EventArgs e)
        {
            LiberaBotaoVagas();
        }
    }
}

