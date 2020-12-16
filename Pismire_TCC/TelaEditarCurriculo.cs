using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Pismire_TCC.Resources;

namespace Pismire_TCC
{
    public partial class TelaEditarCurriculo : Form
    {
        PismireEntities5 bd = new PismireEntities5();

        bool bDeficiencia = false;
        bool bSituacao = false;
        bool clicou = false;
        bool clicou2 = false;
        bool salvou = false;
        bool bSalvou = false;
        bool vira = false;
        bool vira2 = false;
        bool vira3 = false;
        bool vira4 = false;
        bool vira5 = false;
        bool passouPag1 = false;
        bool passouPag2 = false;
        bool passouPag3 = false;
        bool ehEdicao = false;
        bool passou = false;

        public TelaEditarCurriculo()
        {
            InitializeComponent();
            PegarID.visualizar = false;

            pnIdiomas.BorderStyle = BorderStyle.FixedSingle;
            pnQualificacao.BorderStyle = BorderStyle.FixedSingle;
            pnExpProf.BorderStyle = BorderStyle.FixedSingle;           //Arruma as bordas
            pnExpInternacional.BorderStyle = BorderStyle.FixedSingle;
            pnTrabalhoVol.BorderStyle = BorderStyle.FixedSingle;
            padraoBotoes();

            Maximizacao.verifique(this, pbMaximizar);

            try
            {

                var usuario = bd.usuario_trabalhador.Where(x => x.FK_usuario == UsuarioDados.Id).FirstOrDefault();

                if (usuario != null)
                {
                    salvou = true;
                    CarregaDados();
                }

                var usu = bd.usuario.Where(x => x.idUsuario == UsuarioDados.Id).FirstOrDefault();
                tb_editarNome.Text = usu.nomeUsuario;
                tb_editarEmail.Text = usu.e_mailUsuario;
                tb_editarTelefone.Text = usu.telefoneUsuario;
            }
            catch (Exception)
            {
                Mensagem.aviso = "Erro ao abrir!";
                TelaMensagemAviso f = new TelaMensagemAviso();
                f.ShowDialog();
            }
        }

        private void CarregaDados()
        {
            passouPag1 = true;
            passouPag2 = true; //Avisa que é edição
            passouPag3 = true;
            ehEdicao = true;

            try
            {

                var usu = bd.usuario.Where(x => x.idUsuario == UsuarioDados.Id).FirstOrDefault();
                var usuario = bd.usuario_trabalhador.Where(x => x.FK_usuario == UsuarioDados.Id).FirstOrDefault();
                var curriculo = bd.curriculo.Where(x => x.FK_usuario_trabalhador == usuario.CPF).FirstOrDefault();

                tb_editarNome.Text = usu.nomeUsuario;
                tb_editarDataNascimento.Text = Convert.ToString(usuario.dataNascimento.ToShortDateString());
                tb_editarTelefone.Text = usu.telefoneUsuario;
                tb_editarRG.Text = usuario.RG;
                tb_editarCelular.Text = curriculo.celularTrabalhador;
                cbEstadoCivil.Text = curriculo.estadoCivil;
                tb_editarCPF.Text = usuario.CPF;
                cbGenero.Text = curriculo.generoTrabalhador;
                tb_editarEmail.Text = usu.e_mailUsuario;

                if (curriculo.fotoUsuario != null)
                {
                    byte[] ImageSource = curriculo.fotoUsuario;
                    pbFotoPerfil.Visible = true;

                    using (MemoryStream stream = new MemoryStream(ImageSource))   //Mostrando foto
                    {
                        pbFotoPerfil.Image = new Bitmap(stream);
                    }
                    bSalvou = true;
                }

                if (curriculo.deficienciaFisica)
                {
                    pb_editarSim.Image = Properties.Resources.verifica;
                    pb_editarNao.Image = Properties.Resources.caixa_de_selecao__1_;
                }
                else
                {
                    pb_editarNao.Image = Properties.Resources.verifica;
                    pb_editarSim.Image = Properties.Resources.caixa_de_selecao__1_;
                }

                tb_editarAreaAtuacao.Text = curriculo.areaAtuacao;
                tb_editarCargoAtual.Text = curriculo.cargoAtuacao;
                cbFormacaoAcademica.Text = curriculo.formacaoAcademica;
                tb_editarFacebook.Text = curriculo.facebookTrabalhador;

                if (curriculo.situacaoAtual)
                {
                    pb_SituacaoAtualSim.Image = Properties.Resources.verifica;
                    pb_SituacaoAtualNao.Image = Properties.Resources.caixa_de_selecao__1_;
                }
                else
                {
                    pb_SituacaoAtualSim.Image = Properties.Resources.caixa_de_selecao__1_;
                    pb_SituacaoAtualNao.Image = Properties.Resources.verifica;
                }

                tb_editarObjetivo.Text = curriculo.objetivo;
                tb_editarRua.Text = curriculo.ruaTrabalhador;
                tb_editarNumero.Text = curriculo.numeroTrabalhador;
                tb_editarBairro.Text = curriculo.bairroTrabalhador;
                tb_editarCidade.Text = curriculo.cidadeTrabalhador;
                cbEstado.Text = curriculo.estadoTrabalhador;
                tb_editarNacionalidade.Text = curriculo.nacionalidade;
                tb_editarCEP.Text = curriculo.cepTrabalhador;
            }
            catch (Exception)
            {
                Mensagem.aviso = "Erro ao conectar!";
                TelaMensagemAviso f = new TelaMensagemAviso();
                f.ShowDialog();
            }
        }

        private void p_barra_Paint(object sender, PaintEventArgs e)
        {
            int x = (p_barra.Size.Width - lb_curriculo.Width) / 2;
            int y = (p_barra.Size.Height - lb_curriculo.Height);              //Posição da label na barra

            lb_curriculo.Location = new Point(x, y);
        }

        private void p_barra_Resize(object sender, EventArgs e)
        {
            int x = (p_barra.Size.Width - lb_curriculo.Width) / 2;
            int y = (p_barra.Size.Height - lb_curriculo.Height);              //Posição da label na barra

            lb_curriculo.Location = new Point(x, y);
        }

        private void pb_voltar_Click(object sender, EventArgs e)
        {
            apagar();

            this.Hide();
            TelaVisualizacaoCurriculo f = new TelaVisualizacaoCurriculo();
            f.Closed += (s, args) => this.Close();
            f.ShowDialog();
        }

        private void pb_voltar_MouseEnter(object sender, EventArgs e)
        {
            pb_voltar.Image = Properties.Resources.VoltarRoxo;
        }

        private void pb_voltar_MouseHover(object sender, EventArgs e)
        {
            pb_voltar.Image = Properties.Resources.VoltarRoxo;
        }

        private void pb_voltar_MouseLeave(object sender, EventArgs e)
        {
            pb_voltar.Image = Properties.Resources.voltar;
        }

        private void pbFechar_Click(object sender, EventArgs e)
        {
            apagar();
            this.Close();
        }

        private void apagar()
        {
            try
            {
                if (!salvou)
                {
                    var usuario = bd.usuario_trabalhador.Where(x => x.FK_usuario == UsuarioDados.Id).FirstOrDefault();

                    if (usuario != null)
                    {
                        var usuario_cu = bd.curriculo.Where(x => x.FK_usuario_trabalhador == usuario.CPF).FirstOrDefault();

                        if (usuario_cu != null)
                        {
                            var idioma = bd.idioma_trabalhador.Where(x => x.FK_curriculo == usuario_cu.idCurriculo).FirstOrDefault();

                            if (idioma != null)
                            {
                                bd.idioma_trabalhador.Remove(idioma);
                            }

                            var quali = bd.qualificacao_trabalhador.Where(x => x.FK_curriculo == usuario_cu.idCurriculo).FirstOrDefault();

                            if (quali != null)
                            {
                                bd.qualificacao_trabalhador.Remove(quali);
                            }

                            var expProf = bd.experiencia_profissional_trabalhador.Where(x => x.FK_curriculo == usuario_cu.idCurriculo).FirstOrDefault();

                            if (expProf != null)
                            {
                                bd.experiencia_profissional_trabalhador.Remove(expProf);
                            }

                            var expInt = bd.experiencia_internacional_trabalhador.Where(x => x.FK_curriculo == usuario_cu.idCurriculo).FirstOrDefault();

                            if (expInt != null)
                            {
                                bd.experiencia_internacional_trabalhador.Remove(expInt);
                            }

                            var voluntario = bd.trabalho_voluntario_trabalhador.Where(x => x.FK_curriculo == usuario_cu.idCurriculo).FirstOrDefault();

                            if (voluntario != null)
                            {
                                bd.trabalho_voluntario_trabalhador.Remove(voluntario);
                            }

                            bd.curriculo.Remove(usuario_cu);
                        }

                        bd.usuario_trabalhador.Remove(usuario);
                        bd.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {
                Mensagem.aviso = "Erro ao apagar!";
                TelaMensagemAviso f = new TelaMensagemAviso();
                f.ShowDialog();
            }
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
            this.WindowState = FormWindowState.Minimized;
        }

        private void pbMinimizar_MouseEnter(object sender, EventArgs e)
        {
            pbMinimizar.BackColor = Color.FromArgb(41, 41, 41);
        }

        private void pbMinimizar_MouseHover(object sender, EventArgs e)
        {
            pbMinimizar.BackColor = Color.FromArgb(41, 41, 41);
        }

        private void pbMinimizar_MouseLeave(object sender, EventArgs e)
        {
            pbMinimizar.BackColor = Color.FromArgb(60, 62, 85);
        }

        private void pbMaximizar_MouseEnter(object sender, EventArgs e)
        {
            pbMaximizar.BackColor = Color.FromArgb(41, 41, 41);
        }

        private void pbMaximizar_MouseHover(object sender, EventArgs e)
        {
            pbMaximizar.BackColor = Color.FromArgb(41, 41, 41);
        }

        private void pbMaximizar_MouseLeave(object sender, EventArgs e)
        {
            pbMaximizar.BackColor = Color.FromArgb(60, 62, 85);
        }

        private void pbFechar_MouseEnter(object sender, EventArgs e)
        {
            pbFechar.BackColor = Color.Red;
        }

        private void pbFechar_MouseHover(object sender, EventArgs e)
        {
            pbFechar.BackColor = Color.Red;
        }

        private void pbFechar_MouseLeave(object sender, EventArgs e)
        {
            pbFechar.BackColor = Color.FromArgb(60, 62, 85);
        }

        private void pb_editarSim_Click(object sender, EventArgs e)
        {
            pb_editarSim.Image = Properties.Resources.verifica;
            pb_editarNao.Image = Properties.Resources.caixa_de_selecao__1_;
            bDeficiencia = true;
            clicou = true;
        }

        private void pb_editarNao_Click(object sender, EventArgs e)
        {
            pb_editarSim.Image = Properties.Resources.caixa_de_selecao__1_;
            pb_editarNao.Image = Properties.Resources.verifica;
            bDeficiencia = false;
            clicou = true;
        }

        private void pb_SituacaoAtualSim_Click(object sender, EventArgs e)
        {
            clicou2 = true;
            pb_SituacaoAtualSim.Image = Properties.Resources.verifica;
            pb_SituacaoAtualNao.Image = Properties.Resources.caixa_de_selecao__1_;
            bSituacao = true;
        }

        private void pb_SituacaoAtualNao_Click(object sender, EventArgs e)
        {
            clicou2 = true;
            pb_SituacaoAtualSim.Image = Properties.Resources.caixa_de_selecao__1_;
            pb_SituacaoAtualNao.Image = Properties.Resources.verifica;
            bSituacao = false;
        }

        private void bt_salvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (passouPag1 && passouPag2 && passouPag3)
                {
                    if (!clicou)
                    {
                        var usuarioTrab = bd.usuario_trabalhador.Where(x => x.FK_usuario == UsuarioDados.Id).FirstOrDefault();

                        if (usuarioTrab != null)
                        {
                            var curriculo = bd.curriculo.Where(x => x.FK_usuario_trabalhador == usuarioTrab.CPF).FirstOrDefault();

                            if (curriculo != null)
                            {
                                clicou = true;
                            }
                        }
                    }

                    if (!clicou2)
                    {
                        var usuarioTrab = bd.usuario_trabalhador.Where(x => x.FK_usuario == UsuarioDados.Id).FirstOrDefault();

                        if (usuarioTrab != null)
                        {
                            var curriculo = bd.curriculo.Where(x => x.FK_usuario_trabalhador == usuarioTrab.CPF).FirstOrDefault();

                            if (curriculo != null)
                            {
                                clicou2 = true;
                            }
                        }
                    }

                    bool aceito = false;
                    if ((tb_editarNome.Text != "" && tb_editarDataNascimento.Text != "" && tb_editarCPF.Text != "" && tb_editarRG.Text != "" &&
                      tb_editarTelefone.Text != "" && tb_editarCelular.Text != "" && cbEstadoCivil.Text != "" && cbGenero.Text != "" &&
                      tb_editarEmail.Text != "" && clicou && tb_editarRua.Text != "" && tb_editarNumero.Text != "" && tb_editarBairro.Text != "" && tb_editarCidade.Text != "" && cbEstado.Text != "" && tb_editarNacionalidade.Text != "" && tb_editarCEP.Text != ""
                        && tb_editarAreaAtuacao.Text != "" && tb_editarCargoAtual.Text != "" && cbFormacaoAcademica.Text != "" && tb_editarFacebook.Text != "" && clicou2 && tb_editarObjetivo.Text != ""))
                    {
                        if (bSalvou)
                        {
                            try
                            {
                                if (tb_editarCEP.Text.Length == 9)
                                {
                                    DateTime dataAtual = (DateTime.Today).Date;

                                    if (((Convert.ToDateTime(tb_editarDataNascimento.Text)).Year + 14) <= (dataAtual.Year))
                                    {
                                        if (((Convert.ToDateTime(tb_editarDataNascimento.Text)).Year + 14) == (dataAtual.Year))
                                        {
                                            if (((Convert.ToDateTime(tb_editarDataNascimento.Text)).Month) <= (dataAtual.Month))
                                            {
                                                if (((Convert.ToDateTime(tb_editarDataNascimento.Text)).Month) == (dataAtual.Month))
                                                {
                                                    if (((Convert.ToDateTime(tb_editarDataNascimento.Text)).Day) <= (dataAtual.Day))
                                                    {
                                                        aceito = true;
                                                    }
                                                    else
                                                    {
                                                        Mensagem.aviso = "Idade precisa ser acima de 14 anos!";
                                                        TelaMensagemAviso f = new TelaMensagemAviso();
                                                        f.ShowDialog();
                                                    }
                                                }
                                                else
                                                {
                                                    aceito = true;
                                                }
                                            }
                                            else
                                            {
                                                Mensagem.aviso = "Idade precisa ser acima de 14 anos!";
                                                TelaMensagemAviso f = new TelaMensagemAviso();
                                                f.ShowDialog();
                                            }
                                        }
                                        else
                                        {
                                            aceito = true;
                                        }

                                        if (aceito)
                                        {
                                            if (tb_editarRG.Text.Length < 9 || tb_editarCelular.Text.Length < 14 ||
                                                tb_editarTelefone.Text.Length < 13)
                                            {
                                                Mensagem.aviso = "Campo(s) inválido(s)!";
                                                TelaMensagemAviso f = new TelaMensagemAviso();
                                                f.ShowDialog();
                                            }
                                            else
                                            {
                                                if (tb_editarCPF.Text.Length < 14 || !validaCpf(tb_editarCPF.Text))
                                                {
                                                    Mensagem.aviso = "CPF inválido!";
                                                    TelaMensagemAviso f = new TelaMensagemAviso();
                                                    f.ShowDialog();
                                                }
                                                else
                                                {
                                                    var usuarioTrab = bd.usuario_trabalhador.Where(x => x.CPF == tb_editarCPF.Text).
                                                    FirstOrDefault();

                                                    if (usuarioTrab == null)
                                                    {
                                                        pnPag1.Visible = false;
                                                        pnPag2.Visible = true;
                                                        pnPag3.Visible = false;
                                                        pnPag4.Visible = false;                                   //Troca de tela pg 2             
                                                        pbPag2.Image = Properties.Resources.Verificado_evento;
                                                        pbPag3.Image = Properties.Resources._3_evento1;
                                                        pbPag4.Image = Properties.Resources._4_evento1;
                                                        passouPag1 = true;
                                                    }
                                                    else
                                                    {
                                                        var usuarioTrab2 = bd.usuario_trabalhador.Where(x => x.FK_usuario ==
                                                        UsuarioDados.Id).FirstOrDefault();

                                                        if (usuarioTrab2 == null)
                                                        {
                                                            Mensagem.aviso = "CPF já Cadastrado por outro usuário!";
                                                            TelaMensagemAviso f = new TelaMensagemAviso();
                                                            f.ShowDialog();
                                                        }
                                                        else
                                                        {
                                                            var usuario = bd.usuario.Where(x => x.idUsuario == UsuarioDados.Id).ToList();

                                                            usuario.ForEach(x =>
                                                            {
                                                                x.nomeUsuario = tb_editarNome.Text;
                                                                x.telefoneUsuario = tb_editarTelefone.Text;  //Atualiza
                                                            x.e_mailUsuario = tb_editarEmail.Text;
                                                            });

                                                            bd.SaveChanges();

                                                            var usuario_trabalhador = bd.usuario_trabalhador.Where(x => x.FK_usuario ==
                                                            UsuarioDados.Id).FirstOrDefault();

                                                            if (usuario_trabalhador != null)
                                                            {
                                                                var curriculo = bd.curriculo.Where(x => x.FK_usuario_trabalhador ==
                                                                usuario_trabalhador.CPF).FirstOrDefault();

                                                                if (curriculo != null)
                                                                {
                                                                    var usuariotrab = bd.usuario_trabalhador.Where(x => x.FK_usuario ==
                                                                    UsuarioDados.Id).ToList();
                                                                    var curriculo2 = bd.curriculo.Where(x => x.FK_usuario_trabalhador ==
                                                                    usuario_trabalhador.CPF).ToList();

                                                                    DateTime dataAtual2 = (DateTime.Today).Date;

                                                                    usuariotrab.ForEach(x =>
                                                                    {
                                                                        x.CPF = tb_editarCPF.Text;
                                                                        x.RG = tb_editarRG.Text;
                                                                        var dataFinal = Convert.ToDateTime(tb_editarDataNascimento.Text)
                                                                        .ToString("dd/MM/yyyy"); //Atualiza dados
                                                                    x.dataNascimento = Convert.ToDateTime(dataFinal);
                                                                    });
                                                                    bd.SaveChanges();

                                                                    curriculo2.ForEach(x =>
                                                                    {
                                                                        x.ruaTrabalhador = tb_editarRua.Text;
                                                                        x.numeroTrabalhador = tb_editarNumero.Text;
                                                                        x.bairroTrabalhador = tb_editarBairro.Text;
                                                                        x.cidadeTrabalhador = tb_editarCidade.Text;   //Atualiza dados
                                                                        x.celularTrabalhador = tb_editarCelular.Text;
                                                                        x.generoTrabalhador = cbGenero.Text;
                                                                        x.estadoCivil = cbEstadoCivil.Text;
                                                                        x.formacaoAcademica = cbFormacaoAcademica.Text;
                                                                        x.facebookTrabalhador = tb_editarFacebook.Text;
                                                                        x.deficienciaFisica = bDeficiencia;
                                                                        x.cargoAtuacao = tb_editarCargoAtual.Text;
                                                                        x.situacaoAtual = bSituacao;
                                                                        x.objetivo = tb_editarObjetivo.Text;
                                                                        x.estadoTrabalhador = cbEstado.Text;
                                                                        x.nacionalidade = tb_editarNacionalidade.Text;
                                                                        x.cepTrabalhador = tb_editarCEP.Text;
                                                                    });

                                                                    bd.SaveChanges();

                                                                    if (passou)
                                                                    {
                                                                        byte[] Foto;
                                                                        using (var ms = new MemoryStream())
                                                                        {
                                                                            pbFotoPerfil.Image.Save(ms, pbFotoPerfil.Image.RawFormat);
                                                                            Foto = ms.ToArray();
                                                                        }
                                                                        curriculo2.ForEach(x => { x.fotoUsuario = Foto; });
                                                                        bd.SaveChanges();
                                                                    }

                                                                    Mensagem.aviso = "Atualizado com sucesso!";
                                                                    TelaMensagemAviso f = new TelaMensagemAviso();
                                                                    f.ShowDialog();

                                                                    if (!TesteTutorial.entrou)
                                                                    {
                                                                        TesteTutorial.entrou = true;
                                                                        TesteTutorial.instrucao = false;
                                                                    }

                                                                    this.Hide();
                                                                    TelaVisualizacaoCurriculo f2 = new TelaVisualizacaoCurriculo();
                                                                    f2.Closed += (s, args) => this.Close();
                                                                    f2.ShowDialog();
                                                                }
                                                            }
                                                            else
                                                            {
                                                                SalvaSemCurriculo();
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Mensagem.aviso = "Idade precisa ser acima de 14 anos!";
                                            TelaMensagemAviso f = new TelaMensagemAviso();
                                            f.ShowDialog();
                                        }
                                    }
                                    else
                                    {
                                        Mensagem.aviso = "Idade precisa ser acima de 14 anos!";
                                        TelaMensagemAviso f = new TelaMensagemAviso();
                                        f.ShowDialog();
                                    }
                                }
                                else
                                {
                                    Mensagem.aviso = "CEP inválido!";
                                    TelaMensagemAviso f = new TelaMensagemAviso();
                                    f.ShowDialog();
                                }
                            }
                            catch (Exception)
                            {
                                Mensagem.aviso = "Erro ao salvar com banco de dados!";
                                TelaMensagemAviso f = new TelaMensagemAviso();
                                f.ShowDialog();
                            }
                        }
                        else
                        {
                            Mensagem.aviso = "Adicione uma imagem!";
                            TelaMensagemAviso f = new TelaMensagemAviso();
                            f.ShowDialog();
                        }
                    }
                    else
                    {
                        Mensagem.aviso = "Erro ao salvar, verifique os campos!";
                        TelaMensagemAviso f = new TelaMensagemAviso();
                        f.ShowDialog();
                    }
                }
                else
                {
                    Mensagem.aviso = "Erro ao avançar, verifique os campos!";
                    TelaMensagemAviso f = new TelaMensagemAviso();
                    f.ShowDialog();
                }
            }
            catch (Exception)
            {
                Mensagem.aviso = "Erro ao conectar com o banco!";
                TelaMensagemAviso f = new TelaMensagemAviso();
                f.ShowDialog();
            }
        }

        private void SalvaSemCurriculo()
        {
            try
            {
                usuario_trabalhador add = new usuario_trabalhador();
                add.CPF = tb_editarCPF.Text;
                add.RG = tb_editarRG.Text;
                add.dataNascimento = Convert.ToDateTime(tb_editarDataNascimento.Text);    //Salva a tabela usuario trabalhador
                add.FK_usuario = UsuarioDados.Id;
                bd.usuario_trabalhador.Add(add);
                bd.SaveChanges();

                curriculo curriculo = new curriculo();
                curriculo.generoTrabalhador = cbGenero.Text;
                curriculo.celularTrabalhador = tb_editarCelular.Text;
                curriculo.estadoCivil = cbEstadoCivil.Text;
                curriculo.nacionalidade = tb_editarNacionalidade.Text;
                curriculo.deficienciaFisica = bDeficiencia;
                curriculo.estadoTrabalhador = cbEstado.Text;
                curriculo.cidadeTrabalhador = tb_editarCidade.Text;
                curriculo.bairroTrabalhador = tb_editarBairro.Text;
                curriculo.ruaTrabalhador = tb_editarRua.Text;
                curriculo.numeroTrabalhador = tb_editarNumero.Text;
                curriculo.cepTrabalhador = tb_editarCEP.Text;
                curriculo.areaAtuacao = tb_editarAreaAtuacao.Text;
                curriculo.cargoAtuacao = tb_editarCargoAtual.Text;
                curriculo.objetivo = tb_editarObjetivo.Text;
                curriculo.formacaoAcademica = cbFormacaoAcademica.Text;
                curriculo.situacaoAtual = bSituacao;
                curriculo.facebookTrabalhador = tb_editarFacebook.Text;

                byte[] Foto;
                using (var ms = new MemoryStream())
                {
                    pbFotoPerfil.Image.Save(ms, pbFotoPerfil.Image.RawFormat);
                    Foto = ms.ToArray();
                }
                curriculo.fotoUsuario = Foto;

                var usuario_trab = bd.usuario_trabalhador.Where(x => x.FK_usuario == UsuarioDados.Id).FirstOrDefault();
                curriculo.FK_usuario_trabalhador = usuario_trab.CPF;

                bd.curriculo.Add(curriculo);
                bd.SaveChanges();
            }
            catch (Exception)
            {
                Mensagem.aviso = "Erro ao salvar!";
                TelaMensagemAviso f = new TelaMensagemAviso();
                f.ShowDialog();
            }
        }

        private void bt_editarIdioma_Click(object sender, EventArgs e)
        {
            try
            {
                var usuario = bd.usuario_trabalhador.Where(x => x.FK_usuario == UsuarioDados.Id).FirstOrDefault();

                if (usuario != null)
                {
                    var curriculo = bd.curriculo.Where(x => x.FK_usuario_trabalhador == usuario.CPF).FirstOrDefault();

                    if (curriculo != null)
                    {
                        if (tb_Idioma.Text != "" && cbNivel.Text != "")
                        {
                            idioma_trabalhador add = new idioma_trabalhador();
                            add.linguaTrabalhador = tb_Idioma.Text;
                            add.nivelTrabalhador = cbNivel.Text;
                            add.FK_curriculo = curriculo.idCurriculo;

                            bd.idioma_trabalhador.Add(add);
                            bd.SaveChanges();

                            Mensagem.aviso = "Idioma salvo com sucesso!";
                            TelaMensagemAviso f = new TelaMensagemAviso();
                            f.ShowDialog();

                            tb_Idioma.Clear();
                            cbNivel.Items.Clear();
                            cbNivel.Items.Add("Básico");
                            cbNivel.Items.Add("Intermediário");  //Limpa a lista e add novamente
                            cbNivel.Items.Add("Avançado");
                        }
                        else
                        {
                            Mensagem.aviso = "Preencha todos os campos necessarios!";
                            TelaMensagemAviso f = new TelaMensagemAviso();
                            f.ShowDialog();
                        }
                    }
                }
            }
            catch (Exception)
            {
                Mensagem.aviso = "Erro ao avançar, verifique os campos!";
                TelaMensagemAviso f = new TelaMensagemAviso();
                f.ShowDialog();
            }
        }

        private void bt_editarExperiencia_Click(object sender, EventArgs e)
        {
            try
            {
                var usuario = bd.usuario_trabalhador.Where(x => x.FK_usuario == UsuarioDados.Id).FirstOrDefault();

                if (usuario != null)
                {
                    var curriculo = bd.curriculo.Where(x => x.FK_usuario_trabalhador == usuario.CPF).FirstOrDefault();

                    if (curriculo != null)
                    {
                        if (tb_ExpProfEmpresa.Text != "" && tb_ExpProfCargo.Text != "" && tb_ExpProfDataEntrada.Text != "" &&
                           tb_ExpProfDataSaida.Text != "")
                        {
                            if (Convert.ToDateTime(tb_ExpProfDataEntrada.Text) < Convert.ToDateTime(tb_ExpProfDataSaida.Text))
                            {
                                experiencia_profissional_trabalhador add = new experiencia_profissional_trabalhador();
                                add.nomeEmpresaExperienciaTrabalhador = tb_ExpProfEmpresa.Text;
                                add.cargoExperienciaTrabalhador = tb_ExpProfCargo.Text;
                                var dataInicial = Convert.ToDateTime(tb_ExpProfDataEntrada.Text).ToString("dd/MM/yyyy");
                                add.dataEntradaExperienciaTrabalhador = Convert.ToDateTime(dataInicial);
                                var dataFinal = Convert.ToDateTime(tb_ExpProfDataSaida.Text).ToString("dd/MM/yyyy");
                                add.dataSaidaExperienciaTrabalhador = Convert.ToDateTime(dataFinal);
                                add.FK_curriculo = curriculo.idCurriculo;

                                bd.experiencia_profissional_trabalhador.Add(add);
                                bd.SaveChanges();

                                Mensagem.aviso = "Experiencia salvo com sucesso!";
                                TelaMensagemAviso f = new TelaMensagemAviso();
                                f.ShowDialog();

                                tb_ExpProfEmpresa.Clear();
                                tb_ExpProfCargo.Clear();
                                tb_ExpProfDataEntrada.Clear();
                                tb_ExpProfDataSaida.Clear();
                            }
                            else
                            {
                                Mensagem.aviso = "Data de saída não pode ser maior que a de entrada!";
                                TelaMensagemAviso f = new TelaMensagemAviso();
                                f.ShowDialog();
                            }
                        }
                        else
                        {
                            Mensagem.aviso = "Preencha todos os campos necessarios!";
                            TelaMensagemAviso f = new TelaMensagemAviso();
                            f.ShowDialog();
                        }
                    }
                }
            }
            catch (Exception)
            {
                Mensagem.aviso = "Erro ao avançar, verifique os campos!";
                TelaMensagemAviso f = new TelaMensagemAviso();
                f.ShowDialog();
            }
        }

        private void pbPag1_Click(object sender, EventArgs e)
        {
            bt_salvar.Visible = false;
            pnPag1.Visible = true;
            pnPag2.Visible = false;
            pnPag3.Visible = false;
            pnPag4.Visible = false;
            pbPag2.Image = Properties.Resources._2_evento1;          //Troca de tela pg 1
            pbPag3.Image = Properties.Resources._3_evento1;
            pbPag4.Image = Properties.Resources._4_evento1;
        }

        private void pbPag2_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ehEdicao)
                {
                    if (!clicou)
                    {
                        var usuarioTrab = bd.usuario_trabalhador.Where(x => x.FK_usuario == UsuarioDados.Id).FirstOrDefault();

                        if (usuarioTrab != null)
                        {
                            var curriculo = bd.curriculo.Where(x => x.FK_usuario_trabalhador == usuarioTrab.CPF).FirstOrDefault();

                            if (curriculo != null)
                            {
                                clicou = true;
                            }
                        }
                    }
                    bool aceito = false;
                    bt_salvar.Visible = false;
                    if (tb_editarNome.Text != "" && tb_editarDataNascimento.Text != "" && tb_editarCPF.Text != "" && tb_editarRG.Text != "" &&
                      tb_editarTelefone.Text != "" && tb_editarCelular.Text != "" && cbEstadoCivil.Text != "" && cbGenero.Text != "" &&
                      tb_editarEmail.Text != "" && clicou)
                    {
                        try
                        {

                            DateTime dataAtual = (DateTime.Today).Date;

                            if (((Convert.ToDateTime(tb_editarDataNascimento.Text)).Year + 14) <= (dataAtual.Year))
                            {
                                if (((Convert.ToDateTime(tb_editarDataNascimento.Text)).Year + 14) == (dataAtual.Year))
                                {
                                    if (((Convert.ToDateTime(tb_editarDataNascimento.Text)).Month) <= (dataAtual.Month))
                                    {
                                        if (((Convert.ToDateTime(tb_editarDataNascimento.Text)).Month) == (dataAtual.Month))
                                        {
                                            if (((Convert.ToDateTime(tb_editarDataNascimento.Text)).Day) <= (dataAtual.Day))
                                            {
                                                aceito = true;
                                            }
                                            else
                                            {
                                                Mensagem.aviso = "Idade precisa ser acima de 14 anos!";
                                                TelaMensagemAviso f = new TelaMensagemAviso();
                                                f.ShowDialog();
                                            }
                                        }
                                        else
                                        {
                                            aceito = true;
                                        }
                                    }
                                    else
                                    {
                                        Mensagem.aviso = "Idade precisa ser acima de 14 anos!";
                                        TelaMensagemAviso f = new TelaMensagemAviso();
                                        f.ShowDialog();
                                    }
                                }
                                else
                                {
                                    aceito = true;
                                }

                                if (aceito)
                                {
                                    if (tb_editarRG.Text.Length < 9 || tb_editarCelular.Text.Length < 14 ||
                                        tb_editarTelefone.Text.Length < 13)
                                    {
                                        Mensagem.aviso = "Campo(s) inválido(s)!";
                                        TelaMensagemAviso f = new TelaMensagemAviso();
                                        f.ShowDialog();
                                    }
                                    else
                                    {
                                        if (tb_editarCPF.Text.Length < 14 || !validaCpf(tb_editarCPF.Text))
                                        {
                                            Mensagem.aviso = "CPF inválido!";
                                            TelaMensagemAviso f = new TelaMensagemAviso();
                                            f.ShowDialog();
                                        }
                                        else
                                        {
                                            var usuarioTrab = bd.usuario_trabalhador.Where(x => x.CPF == tb_editarCPF.Text).
                                            FirstOrDefault();

                                            if (usuarioTrab == null)
                                            {
                                                pnPag1.Visible = false;
                                                pnPag2.Visible = true;
                                                pnPag3.Visible = false;
                                                pnPag4.Visible = false;                                   //Troca de tela pg 2             
                                                pbPag2.Image = Properties.Resources.Verificado_evento;
                                                pbPag3.Image = Properties.Resources._3_evento1;
                                                pbPag4.Image = Properties.Resources._4_evento1;
                                                passouPag1 = true;
                                            }
                                            else
                                            {
                                                var usuarioTrab2 = bd.usuario_trabalhador.Where(x => x.FK_usuario ==
                                                UsuarioDados.Id).FirstOrDefault();

                                                if (usuarioTrab2 == null)
                                                {
                                                    Mensagem.aviso = "CPF já Cadastrado por outro usuário!";
                                                    TelaMensagemAviso f = new TelaMensagemAviso();
                                                    f.ShowDialog();
                                                }
                                                else
                                                {
                                                    pnPag1.Visible = false;
                                                    pnPag2.Visible = true;
                                                    pnPag3.Visible = false;
                                                    pnPag4.Visible = false;                                   //Troca de tela pg 2             
                                                    pbPag2.Image = Properties.Resources.Verificado_evento;
                                                    pbPag3.Image = Properties.Resources._3_evento1;
                                                    pbPag4.Image = Properties.Resources._4_evento1;
                                                    passouPag1 = true;
                                                }
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    Mensagem.aviso = "Idade precisa ser acima de 14 anos!";
                                    TelaMensagemAviso f = new TelaMensagemAviso();
                                    f.ShowDialog();
                                }
                            }
                            else
                            {
                                Mensagem.aviso = "Idade precisa ser acima de 14 anos!";
                                TelaMensagemAviso f = new TelaMensagemAviso();
                                f.ShowDialog();
                            }

                        }
                        catch (Exception)
                        {
                            Mensagem.aviso = "Erro ao avançar, verifique os campos!";
                            TelaMensagemAviso f = new TelaMensagemAviso();
                            f.ShowDialog();
                        }
                    }
                    else
                    {
                        Mensagem.aviso = "Preencha todos os campos desta etapa para avançar!";
                        TelaMensagemAviso f = new TelaMensagemAviso();
                        f.ShowDialog();
                    }
                }
                else
                {
                    pnPag1.Visible = false;
                    pnPag2.Visible = true;
                    pnPag3.Visible = false;
                    pnPag4.Visible = false;                                   //Troca de tela pg 2             
                    pbPag2.Image = Properties.Resources.Verificado_evento;
                    pbPag3.Image = Properties.Resources._3_evento1;
                    pbPag4.Image = Properties.Resources._4_evento1;
                    passouPag1 = true;
                }
            }
            catch (Exception)
            {
                Mensagem.aviso = "Erro ao conectar com o banco!";
                TelaMensagemAviso f = new TelaMensagemAviso();
                f.ShowDialog();
            }
        }

        private bool validaCpf(String cpf)
        {
            int digito1 = Convert.ToInt32(cpf[0].ToString());
            int digito2 = Convert.ToInt32(cpf[1].ToString());
            int digito3 = Convert.ToInt32(cpf[2].ToString());
            int digito4 = Convert.ToInt32(cpf[4].ToString());
            int digito5 = Convert.ToInt32(cpf[5].ToString());                      // Validação de CPF
            int digito6 = Convert.ToInt32(cpf[6].ToString());
            int digito7 = Convert.ToInt32(cpf[8].ToString());
            int digito8 = Convert.ToInt32(cpf[9].ToString());
            int digito9 = Convert.ToInt32(cpf[10].ToString());
            int digito10 = Convert.ToInt32(cpf[12].ToString());
            int digito11 = Convert.ToInt32(cpf[13].ToString());

            if ((digito1 == digito2) && (digito2 == digito3) && (digito3 == digito4) && (digito4 == digito5)
                && (digito5 == digito6) && (digito6 == digito7) && (digito7 == digito8) && (digito8 == digito9)
                && (digito9 == digito10) && (digito10 == digito11))
            {
                return false;
            }
            else
            {
                int dgV1 = 11 - (((digito1 * 10) + (digito2 * 9) + (digito3 * 8) +
                   (digito4 * 7) + (digito5 * 6) + (digito6 * 5) +
                   (digito7 * 4) + (digito8 * 3) + (digito9 * 2)) % 11);

                if (dgV1 > 9)
                {
                    dgV1 = 0;
                }

                int dgV2 = 11 - (((digito1 * 11) + (digito2 * 10) + (digito3 * 9) +
                           (digito4 * 8) + (digito5 * 7) + (digito6 * 6) +
                           (digito7 * 5) + (digito8 * 4) + (digito9 * 3) + (dgV1 * 2)) % 11);

                if (dgV2 > 9)
                {
                    dgV2 = 0;
                }

                if (dgV1 == digito10 && dgV2 == digito11)
                {
                    return true;
                }
                return false;
            }
        }

        private void pbPag3_Click(object sender, EventArgs e)
        {
            if (!ehEdicao)
            {
                if (passouPag1)
                {
                    bt_salvar.Visible = false;
                    if (tb_editarRua.Text != "" && tb_editarNumero.Text != "" && tb_editarBairro.Text != "" && tb_editarCidade.Text != "" && cbEstado.Text != "" && tb_editarNacionalidade.Text != "" && tb_editarCEP.Text != "")
                    {
                        if (tb_editarCEP.Text.Length == 9)
                        {
                            pnPag1.Visible = false;
                            pnPag2.Visible = false;
                            pnPag3.Visible = true;
                            pnPag4.Visible = false;
                            pbPag2.Image = Properties.Resources.Verificado_evento;      //Troca de tela pg 3
                            pbPag3.Image = Properties.Resources.Verificado_evento;
                            pbPag4.Image = Properties.Resources._4_evento1;
                            passouPag2 = true;
                        }
                        else
                        {
                            Mensagem.aviso = "CEP inválido!";
                            TelaMensagemAviso f = new TelaMensagemAviso();
                            f.ShowDialog();
                        }
                    }
                    else
                    {
                        Mensagem.aviso = "Preencha todos os campos desta etapa para avançar!";
                        TelaMensagemAviso f = new TelaMensagemAviso();
                        f.ShowDialog();
                    }
                }
                else
                {
                    Mensagem.aviso = "Erro ao avançar, verifique os campos!";
                    TelaMensagemAviso f = new TelaMensagemAviso();
                    f.ShowDialog();
                }
            }
            else
            {
                pnPag1.Visible = false;
                pnPag2.Visible = false;
                pnPag3.Visible = true;
                pnPag4.Visible = false;
                pbPag2.Image = Properties.Resources.Verificado_evento;      //Troca de tela pg 3
                pbPag3.Image = Properties.Resources.Verificado_evento;
                pbPag4.Image = Properties.Resources._4_evento1;
                passouPag2 = true;
            }
        }

        private void pbPag4_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ehEdicao)
                {
                    if (passouPag1 && passouPag2)
                    {
                        if (!clicou2)
                        {
                            var usuarioTrab = bd.usuario_trabalhador.Where(x => x.FK_usuario == UsuarioDados.Id).FirstOrDefault();

                            if (usuarioTrab != null)
                            {
                                var curriculo = bd.curriculo.Where(x => x.FK_usuario_trabalhador == usuarioTrab.CPF).FirstOrDefault();

                                if (curriculo != null)
                                {
                                    clicou2 = true;
                                }
                            }
                        }

                        if (tb_editarAreaAtuacao.Text != "" && tb_editarCargoAtual.Text != "" && cbFormacaoAcademica.Text != "" && tb_editarFacebook.Text != "" &&
                           clicou2 && tb_editarObjetivo.Text != "")
                        {
                            bt_salvar.Visible = true;
                            pnPag1.Visible = false;
                            pnPag2.Visible = false;
                            pnPag3.Visible = false;
                            pnPag4.Visible = true;
                            pbPag2.Image = Properties.Resources.Verificado_evento;      //Troca de tela pg 4
                            pbPag3.Image = Properties.Resources.Verificado_evento;
                            pbPag4.Image = Properties.Resources.Verificado_evento;
                            passouPag3 = true;

                            var usuario = bd.usuario_trabalhador.Where(x => x.FK_usuario == UsuarioDados.Id).FirstOrDefault();

                            if (usuario == null)
                            {
                                SalvaSemCurriculo();
                            }
                        }
                        else
                        {
                            Mensagem.aviso = "Preencha todos os campos desta etapa para avançar!";
                            TelaMensagemAviso f = new TelaMensagemAviso();
                            f.ShowDialog();
                        }
                    }
                    else
                    {
                        Mensagem.aviso = "Erro ao avançar, verifique os campos!";
                        TelaMensagemAviso f = new TelaMensagemAviso();
                        f.ShowDialog();
                    }
                }
                else
                {
                    bt_salvar.Visible = true;
                    pnPag1.Visible = false;
                    pnPag2.Visible = false;
                    pnPag3.Visible = false;
                    pnPag4.Visible = true;
                    pbPag2.Image = Properties.Resources.Verificado_evento;      //Troca de tela pg 4
                    pbPag3.Image = Properties.Resources.Verificado_evento;
                    pbPag4.Image = Properties.Resources.Verificado_evento;
                    passouPag3 = true;
                }
            }
            catch (Exception)
            {
                Mensagem.aviso = "Erro ao conectar com o banco!";
                TelaMensagemAviso f = new TelaMensagemAviso();
                f.ShowDialog();
            }
        }

        private void tb_editarDataNascimento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8) { e.Handled = true; }

            if (char.IsNumber(e.KeyChar) == true)
            {
                switch (tb_editarDataNascimento.TextLength)
                {
                    case 0:
                        tb_editarDataNascimento.Text = "";
                        break;

                    case 2:
                        tb_editarDataNascimento.Text = tb_editarDataNascimento.Text + "/";        //Mascara data de nascimento
                        tb_editarDataNascimento.SelectionStart = 3;
                        break;

                    case 5:
                        tb_editarDataNascimento.Text = tb_editarDataNascimento.Text + "/";
                        tb_editarDataNascimento.SelectionStart = 6;
                        break;

                    case 8:
                        tb_editarDataNascimento.Text = tb_editarDataNascimento.Text + "";
                        tb_editarDataNascimento.SelectionStart = 10;
                        break;
                }
            }
        }

        private void tb_editarRG_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8) { e.Handled = true; }

            if (char.IsNumber(e.KeyChar) == true)
            {
                switch (tb_editarRG.TextLength)
                {
                    case 1:
                        tb_editarRG.Text = tb_editarRG.Text + ".";    //Máscara do RG
                        tb_editarRG.SelectionStart = 4;
                        break;

                    case 5:
                        tb_editarRG.Text = tb_editarRG.Text + ".";
                        tb_editarRG.SelectionStart = 8;
                        break;
                }
            }
        }

        private void tb_editarRG_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                tb_editarRG.Clear();             //Excluir RG
            }
            else if (e.KeyCode == Keys.Back)
            {
                tb_editarRG.Clear();
            }
        }

        private void tb_editarDataNascimento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                tb_editarDataNascimento.Clear();             //Limpar campo 
            }
            else if (e.KeyCode == Keys.Back)
            {
                tb_editarDataNascimento.Clear();
            }
        }

        private void tb_editarCEP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8) { e.Handled = true; }

            if (char.IsNumber(e.KeyChar) == true)
            {
                switch (tb_editarCEP.TextLength)
                {
                    case 0:                                        //Máscara de CEP
                        tb_editarCEP.Text = "";
                        break;

                    case 5:
                        tb_editarCEP.Text = tb_editarCEP.Text + "-";
                        tb_editarCEP.SelectionStart = 8;
                        break;
                }
            }
        }

        private void tb_editarCEP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                tb_editarCEP.Clear();             //Excluir CEP
            }
            else if (e.KeyCode == Keys.Back)
            {
                tb_editarCEP.Clear();
            }
        }

        private void tb_editarTelefone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8) { e.Handled = true; }

            if (char.IsNumber(e.KeyChar) == true)
            {
                switch (tb_editarTelefone.TextLength)
                {
                    case 0:                                        //Máscara de Telefone
                        tb_editarTelefone.Text = "";
                        break;

                    case 2:
                        tb_editarTelefone.Text = "(" + tb_editarTelefone.Text + ")";
                        tb_editarTelefone.SelectionStart = 7;
                        break;

                    case 8:
                        tb_editarTelefone.Text = tb_editarTelefone.Text + "-";
                        tb_editarTelefone.SelectionStart = 13;
                        break;
                }
            }
        }

        private void tb_editarTelefone_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                tb_editarTelefone.Clear();             //Excluir telefone
            }
            else if (e.KeyCode == Keys.Back)
            {
                tb_editarTelefone.Clear();
            }
        }

        private void tb_editarCelular_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8) { e.Handled = true; }

            if (char.IsNumber(e.KeyChar) == true)
            {
                switch (tb_editarCelular.TextLength)
                {
                    case 0:                                        //Máscara do Celular
                        tb_editarCelular.Text = "";
                        break;

                    case 2:
                        tb_editarCelular.Text = "(" + tb_editarCelular.Text + ")";
                        tb_editarCelular.SelectionStart = 10;
                        break;

                    case 9:
                        tb_editarCelular.Text = tb_editarCelular.Text + "-";
                        tb_editarCelular.SelectionStart = 14;
                        break;
                }
            }
        }

        private void tb_editarCelular_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                tb_editarCelular.Clear();             //Excluir Celular
            }
            else if (e.KeyCode == Keys.Back)
            {
                tb_editarCelular.Clear();
            }
        }

        private void tb_editarCPF_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8) { e.Handled = true; }

            if (char.IsNumber(e.KeyChar) == true)
            {
                switch (tb_editarCPF.TextLength)
                {
                    case 3:
                        tb_editarCPF.Text = tb_editarCPF.Text + ".";     //Máscara de CPF
                        tb_editarCPF.SelectionStart = 6;
                        break;

                    case 7:
                        tb_editarCPF.Text = tb_editarCPF.Text + ".";
                        tb_editarCPF.SelectionStart = 9;
                        break;

                    case 11:
                        tb_editarCPF.Text = tb_editarCPF.Text + "-";
                        tb_editarCPF.SelectionStart = 14;
                        break;
                }
            }
        }

        private void tb_editarCPF_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                tb_editarCPF.Clear();             //Excluir CPF
            }
            else if (e.KeyCode == Keys.Back)
            {
                tb_editarCPF.Clear();
            }
        }

        private void bt_Qualificacao_Click(object sender, EventArgs e)
        {
            try
            {
                var usuario = bd.usuario_trabalhador.Where(x => x.FK_usuario == UsuarioDados.Id).FirstOrDefault();

                if (usuario != null)
                {
                    var curriculo = bd.curriculo.Where(x => x.FK_usuario_trabalhador == usuario.CPF).FirstOrDefault();

                    if (curriculo != null)
                    {
                        if (tb_QualificacaoNome.Text != "" && tb_QualificacaoTipo.Text != "" && tb_QualificacaoArea.Text != "" &&
                           tb_QualificacaoInstituicao.Text != "" && tb_QualificacaoTipo.Text != "" && tb_QualificacaoDataInicial.Text != ""
                           && tb_QualificacaoDataFinal.Text != "")
                        {
                            if (Convert.ToDateTime(tb_QualificacaoDataInicial.Text) < Convert.ToDateTime(tb_QualificacaoDataFinal.Text))
                            {
                                qualificacao_trabalhador add = new qualificacao_trabalhador();
                                add.areaQualificacaoTrabalhador = tb_QualificacaoArea.Text;
                                add.nomeQualificacaoTrabalhador = tb_QualificacaoNome.Text;
                                add.instituicaoQualificacaoTrabalhador = tb_QualificacaoTipo.Text;
                                add.tipoQualificacaoTrabalhador = tb_QualificacaoTipo.Text;
                                var dataInicial = Convert.ToDateTime(tb_QualificacaoDataInicial.Text).ToString("dd/MM/yyyy");
                                add.dataInicioQualificacaoTrabalhador = Convert.ToDateTime(dataInicial);
                                var dataFinal = Convert.ToDateTime(tb_QualificacaoDataFinal.Text).ToString("dd/MM/yyyy");
                                add.dataFinalQualificacaoTrabalhador = Convert.ToDateTime(dataFinal);
                                add.FK_curriculo = curriculo.idCurriculo;

                                bd.qualificacao_trabalhador.Add(add);
                                bd.SaveChanges();

                                Mensagem.aviso = "Qualificacao salvo com sucesso!";
                                TelaMensagemAviso f = new TelaMensagemAviso();
                                f.ShowDialog();

                                tb_QualificacaoArea.Clear();
                                tb_QualificacaoNome.Clear();
                                tb_QualificacaoTipo.Clear();
                                tb_QualificacaoDataInicial.Clear();
                                tb_QualificacaoDataFinal.Clear();
                                tb_QualificacaoInstituicao.Clear();
                            }
                            else
                            {
                                Mensagem.aviso = "Data de saída não pode ser maior que a de entrada!";
                                TelaMensagemAviso f = new TelaMensagemAviso();
                                f.ShowDialog();
                            }
                        }
                        else
                        {
                            Mensagem.aviso = "Preencha todos os campos necessarios!";
                            TelaMensagemAviso f = new TelaMensagemAviso();
                            f.ShowDialog();
                        }
                    }
                }
            }
            catch (Exception)
            {
                Mensagem.aviso = "Erro ao avançar, verifique os campos!";
                TelaMensagemAviso f = new TelaMensagemAviso();
                f.ShowDialog();
            }
        }

        private void bt_ExperienciaInt_Click(object sender, EventArgs e)
        {
            try
            {
                var usuario = bd.usuario_trabalhador.Where(x => x.FK_usuario == UsuarioDados.Id).FirstOrDefault();

                if (usuario != null)
                {
                    var curriculo = bd.curriculo.Where(x => x.FK_usuario_trabalhador == usuario.CPF).FirstOrDefault();

                    if (curriculo != null)
                    {
                        if (tb_ExpIntEmpresa.Text != "" && tb_ExpIntCargo.Text != "" && tb_ExpIntPais.Text != "" && tb_ExpIntDataEntrada.Text != ""
                            && tb_ExpIntDataSaida.Text != "")
                        {
                            if (Convert.ToDateTime(tb_ExpIntDataEntrada.Text) < Convert.ToDateTime(tb_ExpIntDataSaida.Text))
                            {
                                experiencia_internacional_trabalhador add = new experiencia_internacional_trabalhador();
                                add.nomeEmpresaInternacionalTrabalhador = tb_ExpIntEmpresa.Text;
                                add.cargoInternacionalTrabalhador = tb_ExpIntCargo.Text;
                                add.paisInternacionalTrabalhador = tb_ExpIntPais.Text;
                                var dataInicial = Convert.ToDateTime(tb_ExpIntDataEntrada.Text).ToString("dd/MM/yyyy");
                                add.dataEntradaInternacionalTrabalhador = Convert.ToDateTime(dataInicial);
                                var dataFinal = Convert.ToDateTime(tb_ExpIntDataSaida.Text).ToString("dd/MM/yyyy");
                                add.dataSaidaInternacionalTrabalhador = Convert.ToDateTime(dataFinal);
                                add.FK_curriculo = curriculo.idCurriculo;


                                bd.experiencia_internacional_trabalhador.Add(add);
                                bd.SaveChanges();

                                Mensagem.aviso = "Experiencia salvo com sucesso!";
                                TelaMensagemAviso f = new TelaMensagemAviso();
                                f.ShowDialog();

                                tb_ExpIntEmpresa.Clear();
                                tb_ExpIntPais.Clear();
                                tb_ExpIntCargo.Clear();
                                tb_ExpIntDataEntrada.Clear();
                                tb_ExpIntDataSaida.Clear();
                            }
                            else
                            {
                                Mensagem.aviso = "Data de saída não pode ser maior que a de entrada!";
                                TelaMensagemAviso f = new TelaMensagemAviso();
                                f.ShowDialog();
                            }
                        }
                        else
                        {
                            Mensagem.aviso = "Preencha todos os campos necessarios!";
                            TelaMensagemAviso f = new TelaMensagemAviso();
                            f.ShowDialog();
                        }
                    }
                }
            }
            catch (Exception)
            {
                Mensagem.aviso = "Erro ao avançar, verifique os campos!";
                TelaMensagemAviso f = new TelaMensagemAviso();
                f.ShowDialog();
            }
        }

        private void pb_editarExperienciaInt_Click(object sender, EventArgs e)
        {
            TelaVisualizarExperienciaInternacionalTrabalhador f = new TelaVisualizarExperienciaInternacionalTrabalhador();
            f.ShowDialog();
        }

        private void pb_editarExperienciaProf_Click(object sender, EventArgs e)
        {
            TelaVisualizarExperienciaProfissionalTrabalhador f = new TelaVisualizarExperienciaProfissionalTrabalhador();
            f.ShowDialog();
        }

        private void pb_Qualificacao_Click(object sender, EventArgs e)
        {
            TelaVisualizarQualificacaoTrabalhador f = new TelaVisualizarQualificacaoTrabalhador();
            f.ShowDialog();
        }

        private void pb_editarIdioma_Click(object sender, EventArgs e)
        {
            TelaVisualizarIdiomaTrabalhador f = new TelaVisualizarIdiomaTrabalhador();
            f.ShowDialog();
        }

        private void bt_TrabalhoVol_Click(object sender, EventArgs e)
        {
            try
            {
                var usuario = bd.usuario_trabalhador.Where(x => x.FK_usuario == UsuarioDados.Id).FirstOrDefault();

                if (usuario != null)
                {
                    var curriculo = bd.curriculo.Where(x => x.FK_usuario_trabalhador == usuario.CPF).FirstOrDefault();

                    if (curriculo != null)
                    {
                        if (tb_Instituicao.Text != "" && tb_Responsavel.Text != "" && tb_DataEntrada.Text != "" && tb_DataSaida.Text != "")
                        {
                            if (Convert.ToDateTime(tb_DataEntrada.Text) < Convert.ToDateTime(tb_DataSaida.Text))
                            {
                                trabalho_voluntario_trabalhador add = new trabalho_voluntario_trabalhador();
                                add.instituicaoVoluntarioTrabalhador = tb_Instituicao.Text;
                                add.responsavelVoluntarioTrabalhador = tb_Responsavel.Text;
                                var dataInicial = Convert.ToDateTime(tb_DataEntrada.Text).ToString("dd/MM/yyyy");
                                add.dataEntradaVoluntarioTrabalhador = Convert.ToDateTime(dataInicial);
                                var dataFinal = Convert.ToDateTime(tb_DataSaida.Text).ToString("dd/MM/yyyy");
                                add.dataSaidaVoluntarioTrabalhador = Convert.ToDateTime(dataFinal);
                                add.FK_curriculo = curriculo.idCurriculo;


                                bd.trabalho_voluntario_trabalhador.Add(add);
                                bd.SaveChanges();

                                Mensagem.aviso = "Trabalho salvo com sucesso!";
                                TelaMensagemAviso f = new TelaMensagemAviso();
                                f.ShowDialog();

                                tb_Instituicao.Clear();
                                tb_Responsavel.Clear();
                                tb_DataEntrada.Clear();
                                tb_DataSaida.Clear();
                            }
                            else
                            {
                                Mensagem.aviso = "Data de saída não pode ser maior que a de entrada!";
                                TelaMensagemAviso f = new TelaMensagemAviso();
                                f.ShowDialog();
                            }
                        }
                        else
                        {
                            Mensagem.aviso = "Preencha todos os campos necessarios!";
                            TelaMensagemAviso f = new TelaMensagemAviso();
                            f.ShowDialog();
                        }
                    }
                }
            }
            catch (Exception)
            {
                Mensagem.aviso = "Erro ao avançar, verifique os campos!";
                TelaMensagemAviso f = new TelaMensagemAviso();
                f.ShowDialog();
            }
        }

        private void pb_TrabalhoVol_Click(object sender, EventArgs e)
        {
            TelaVisualizarTrabalhoVoluntarioTrabalhador f = new TelaVisualizarTrabalhoVoluntarioTrabalhador();
            f.ShowDialog();
        }

        private void pnVisuIdiomas_Click(object sender, EventArgs e)
        {
            if (vira == false)
            {
                pbSetaIdiomas.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                pbSetaIdiomas.Refresh();

                testarVirar();
                vira = true;

                padraoBotoes();

                pnVisuIdiomas.Visible = true;                 //Girar botão qualificacao
                pnIdiomas.Visible = true;

                pnVisulQualificacao.Location = new Point(344, 45 + pnIdiomas.Height);
                pnQualificacao.Location = new Point(344, 75 + pnIdiomas.Height);

                pnVisulExpProf.Location = new Point(344, 75 + pnIdiomas.Height);
                pnExpProf.Location = new Point(344, 105 + pnIdiomas.Height);

                pnVisulExpInt.Location = new Point(344, 105 + pnIdiomas.Height);
                pnExpInternacional.Location = new Point(344, 135 + pnIdiomas.Height);

                pnVisulTrabVol.Location = new Point(344, 135 + pnIdiomas.Height);
                pnTrabalhoVol.Location = new Point(344, 165 + pnIdiomas.Height);
            }
            else
            {
                pbSetaIdiomas.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                pbSetaIdiomas.Refresh();
                vira = false;

                padraoBotoes();
            }
        }

        private void pnVisulQualificacao_Click(object sender, EventArgs e)
        {
            if (vira2 == false)
            {
                pbSetaQualificacoes.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                pbSetaQualificacoes.Refresh();

                testarVirar();
                vira2 = true;

                padraoBotoes();

                pnVisulQualificacao.Visible = true;                 //Girar botão qualificacao
                pnQualificacao.Visible = true;

                pnVisulExpProf.Location = new Point(344, 75 + pnQualificacao.Height);
                pnExpProf.Location = new Point(344, 105 + pnQualificacao.Height);

                pnVisulExpInt.Location = new Point(344, 105 + pnQualificacao.Height);
                pnExpInternacional.Location = new Point(344, 135 + pnQualificacao.Height);

                pnVisulTrabVol.Location = new Point(344, 135 + pnQualificacao.Height);
                pnTrabalhoVol.Location = new Point(344, 165 + pnQualificacao.Height);
            }
            else
            {
                pbSetaQualificacoes.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                pbSetaQualificacoes.Refresh();
                vira2 = false;

                padraoBotoes();
            }
        }

        private void pnVisulExpProf_Click(object sender, EventArgs e)
        {
            if (vira3 == false)
            {
                pbSetaExpProf.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                pbSetaExpProf.Refresh();

                testarVirar();
                vira3 = true;

                padraoBotoes();

                pnVisulExpProf.Visible = true;                 //Girar botão qualificacao
                pnExpProf.Visible = true;

                pnVisulExpInt.Location = new Point(344, 105 + pnExpProf.Height);
                pnExpInternacional.Location = new Point(344, 135 + pnExpProf.Height);

                pnVisulTrabVol.Location = new Point(344, 135 + pnExpProf.Height);
                pnTrabalhoVol.Location = new Point(344, 165 + pnExpProf.Height);
            }
            else
            {
                pbSetaExpProf.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                pbSetaExpProf.Refresh();
                vira3 = false;

                padraoBotoes();
            }
        }

        private void pnVisulExpInt_Click(object sender, EventArgs e)
        {
            if (vira4 == false)
            {
                pbSetaExpInt.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                pbSetaExpInt.Refresh();

                testarVirar();
                vira4 = true;

                padraoBotoes();

                pnVisulExpInt.Visible = true;                 //Girar botão qualificacao
                pnExpInternacional.Visible = true;

                pnVisulTrabVol.Location = new Point(344, 135 + pnExpInternacional.Height);
                pnTrabalhoVol.Location = new Point(344, 165 + pnExpInternacional.Height);
            }
            else
            {
                pbSetaExpInt.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                pbSetaExpInt.Refresh();
                vira4 = false;

                padraoBotoes();
            }
        }

        private void pnVisulTrabVol_Click(object sender, EventArgs e)
        {
            if (vira5 == false)
            {
                pbSetaTrabalhoVol.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                pbSetaTrabalhoVol.Refresh();

                testarVirar();
                vira5 = true;

                padraoBotoes();

                pnVisulTrabVol.Visible = true;                 //Girar botão qualificacao
                pnTrabalhoVol.Visible = true;
            }
            else
            {
                pbSetaTrabalhoVol.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                pbSetaTrabalhoVol.Refresh();
                vira5 = false;

                padraoBotoes();
            }
        }

        private void testarVirar()
        {
            if (vira == true)
            {
                pbSetaIdiomas.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                pbSetaIdiomas.Refresh();
                vira = false;
            }

            if (vira2 == true)
            {
                pbSetaQualificacoes.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                pbSetaQualificacoes.Refresh();
                vira2 = false;
            }

            if (vira3 == true)
            {
                pbSetaExpProf.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                pbSetaExpProf.Refresh();
                vira3 = false;
            }

            if (vira4 == true)
            {
                pbSetaExpInt.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                pbSetaExpInt.Refresh();
                vira4 = false;
            }

            if (vira5 == true)
            {
                pbSetaTrabalhoVol.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                pbSetaTrabalhoVol.Refresh();
                vira5 = false;
            }
        }

        private void padraoBotoes()
        {
            pnVisuIdiomas.Location = new Point(344, 15);
            pnIdiomas.Location = new Point(344, 45);

            pnVisulQualificacao.Location = new Point(344, 45);
            pnQualificacao.Location = new Point(344, 75);

            pnVisulExpProf.Location = new Point(344, 75);
            pnExpProf.Location = new Point(344, 105);

            pnVisulExpInt.Location = new Point(344, 105);                      //Localização inicial dos paineis 
            pnExpInternacional.Location = new Point(344, 135);

            pnVisulTrabVol.Location = new Point(344, 135);
            pnTrabalhoVol.Location = new Point(344, 165);

            pnIdiomas.Visible = false;
            pnQualificacao.Visible = false;
            pnExpProf.Visible = false;
            pnExpInternacional.Visible = false;
            pnTrabalhoVol.Visible = false;
        }

        private void tb_QualificacaoDataInicial_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8) { e.Handled = true; }

            if (char.IsNumber(e.KeyChar) == true)
            {
                switch (tb_QualificacaoDataInicial.TextLength)
                {
                    case 0:
                        tb_QualificacaoDataInicial.Text = "";
                        break;

                    case 2:
                        tb_QualificacaoDataInicial.Text = tb_QualificacaoDataInicial.Text + "/";        //Mascara data de inicio do evento
                        tb_QualificacaoDataInicial.SelectionStart = 3;
                        break;

                    case 5:
                        tb_QualificacaoDataInicial.Text = tb_QualificacaoDataInicial.Text + "/";
                        tb_QualificacaoDataInicial.SelectionStart = 6;
                        break;

                    case 8:
                        tb_QualificacaoDataInicial.Text = tb_QualificacaoDataInicial.Text + "";
                        tb_QualificacaoDataInicial.SelectionStart = 10;
                        break;
                }
            }
        }

        private void tb_QualificacaoDataInicial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                tb_QualificacaoDataInicial.Clear();             //Limpar campo 
            }
            else if (e.KeyCode == Keys.Back)
            {
                tb_QualificacaoDataInicial.Clear();
            }
        }

        private void tb_QualificacaoDataFinal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8) { e.Handled = true; }

            if (char.IsNumber(e.KeyChar) == true)
            {
                switch (tb_QualificacaoDataFinal.TextLength)
                {
                    case 0:
                        tb_QualificacaoDataFinal.Text = "";
                        break;

                    case 2:
                        tb_QualificacaoDataFinal.Text = tb_QualificacaoDataFinal.Text + "/";        //Mascara data de inicio do evento
                        tb_QualificacaoDataFinal.SelectionStart = 3;
                        break;

                    case 5:
                        tb_QualificacaoDataFinal.Text = tb_QualificacaoDataFinal.Text + "/";
                        tb_QualificacaoDataFinal.SelectionStart = 6;
                        break;

                    case 8:
                        tb_QualificacaoDataFinal.Text = tb_QualificacaoDataFinal.Text + "";
                        tb_QualificacaoDataFinal.SelectionStart = 10;
                        break;
                }
            }
        }

        private void tb_QualificacaoDataFinal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                tb_QualificacaoDataFinal.Clear();             //Limpar campo 
            }
            else if (e.KeyCode == Keys.Back)
            {
                tb_QualificacaoDataFinal.Clear();
            }
        }

        private void tb_ExpProfDataEntrada_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8) { e.Handled = true; }

            if (char.IsNumber(e.KeyChar) == true)
            {
                switch (tb_ExpProfDataEntrada.TextLength)
                {
                    case 0:
                        tb_ExpProfDataEntrada.Text = "";
                        break;

                    case 2:
                        tb_ExpProfDataEntrada.Text = tb_ExpProfDataEntrada.Text + "/";        //Mascara data de inicio do evento
                        tb_ExpProfDataEntrada.SelectionStart = 3;
                        break;

                    case 5:
                        tb_ExpProfDataEntrada.Text = tb_ExpProfDataEntrada.Text + "/";
                        tb_ExpProfDataEntrada.SelectionStart = 6;
                        break;

                    case 8:
                        tb_ExpProfDataEntrada.Text = tb_ExpProfDataEntrada.Text + "";
                        tb_ExpProfDataEntrada.SelectionStart = 10;
                        break;
                }
            }
        }

        private void tb_ExpProfDataEntrada_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                tb_ExpProfDataEntrada.Clear();             //Limpar campo 
            }
            else if (e.KeyCode == Keys.Back)
            {
                tb_ExpProfDataEntrada.Clear();
            }
        }

        private void tb_ExpProfDataSaida_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8) { e.Handled = true; }

            if (char.IsNumber(e.KeyChar) == true)
            {
                switch (tb_ExpProfDataSaida.TextLength)
                {
                    case 0:
                        tb_ExpProfDataSaida.Text = "";
                        break;

                    case 2:
                        tb_ExpProfDataSaida.Text = tb_ExpProfDataSaida.Text + "/";        //Mascara data de inicio do evento
                        tb_ExpProfDataSaida.SelectionStart = 3;
                        break;

                    case 5:
                        tb_ExpProfDataSaida.Text = tb_ExpProfDataSaida.Text + "/";
                        tb_ExpProfDataSaida.SelectionStart = 6;
                        break;

                    case 8:
                        tb_ExpProfDataSaida.Text = tb_ExpProfDataSaida.Text + "";
                        tb_ExpProfDataSaida.SelectionStart = 10;
                        break;
                }
            }
        }

        private void tb_ExpProfDataSaida_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                tb_ExpProfDataSaida.Clear();             //Limpar campo 
            }
            else if (e.KeyCode == Keys.Back)
            {
                tb_ExpProfDataSaida.Clear();
            }
        }

        private void tb_ExpIntDataEntrada_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8) { e.Handled = true; }

            if (char.IsNumber(e.KeyChar) == true)
            {
                switch (tb_ExpIntDataEntrada.TextLength)
                {
                    case 0:
                        tb_ExpIntDataEntrada.Text = "";
                        break;

                    case 2:
                        tb_ExpIntDataEntrada.Text = tb_ExpIntDataEntrada.Text + "/";        //Mascara data de inicio do evento
                        tb_ExpIntDataEntrada.SelectionStart = 3;
                        break;

                    case 5:
                        tb_ExpIntDataEntrada.Text = tb_ExpIntDataEntrada.Text + "/";
                        tb_ExpIntDataEntrada.SelectionStart = 6;
                        break;

                    case 8:
                        tb_ExpIntDataEntrada.Text = tb_ExpIntDataEntrada.Text + "";
                        tb_ExpIntDataEntrada.SelectionStart = 10;
                        break;
                }
            }
        }

        private void tb_ExpIntDataEntrada_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                tb_ExpIntDataEntrada.Clear();             //Limpar campo 
            }
            else if (e.KeyCode == Keys.Back)
            {
                tb_ExpIntDataEntrada.Clear();
            }
        }

        private void tb_ExpIntDataSaida_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8) { e.Handled = true; }

            if (char.IsNumber(e.KeyChar) == true)
            {
                switch (tb_ExpIntDataSaida.TextLength)
                {
                    case 0:
                        tb_ExpIntDataSaida.Text = "";
                        break;

                    case 2:
                        tb_ExpIntDataSaida.Text = tb_ExpIntDataSaida.Text + "/";        //Mascara data de inicio do evento
                        tb_ExpIntDataSaida.SelectionStart = 3;
                        break;

                    case 5:
                        tb_ExpIntDataSaida.Text = tb_ExpIntDataSaida.Text + "/";
                        tb_ExpIntDataSaida.SelectionStart = 6;
                        break;

                    case 8:
                        tb_ExpIntDataSaida.Text = tb_ExpIntDataSaida.Text + "";
                        tb_ExpIntDataSaida.SelectionStart = 10;
                        break;
                }
            }
        }

        private void tb_ExpIntDataSaida_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                tb_ExpIntDataSaida.Clear();             //Limpar campo 
            }
            else if (e.KeyCode == Keys.Back)
            {
                tb_ExpIntDataSaida.Clear();
            }
        }

        private void tb_DataEntrada_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8) { e.Handled = true; }

            if (char.IsNumber(e.KeyChar) == true)
            {
                switch (tb_DataEntrada.TextLength)
                {
                    case 0:
                        tb_DataEntrada.Text = "";
                        break;

                    case 2:
                        tb_DataEntrada.Text = tb_DataEntrada.Text + "/";        //Mascara data de inicio do evento
                        tb_DataEntrada.SelectionStart = 3;
                        break;

                    case 5:
                        tb_DataEntrada.Text = tb_DataEntrada.Text + "/";
                        tb_DataEntrada.SelectionStart = 6;
                        break;

                    case 8:
                        tb_DataEntrada.Text = tb_DataEntrada.Text + "";
                        tb_DataEntrada.SelectionStart = 10;
                        break;
                }
            }
        }

        private void tb_DataEntrada_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                tb_DataEntrada.Clear();             //Limpar campo 
            }
            else if (e.KeyCode == Keys.Back)
            {
                tb_DataEntrada.Clear();
            }
        }

        private void tb_DataSaida_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8) { e.Handled = true; }

            if (char.IsNumber(e.KeyChar) == true)
            {
                switch (tb_DataSaida.TextLength)
                {
                    case 0:
                        tb_DataSaida.Text = "";
                        break;

                    case 2:
                        tb_DataSaida.Text = tb_DataSaida.Text + "/";        //Mascara data de inicio do evento
                        tb_DataSaida.SelectionStart = 3;
                        break;

                    case 5:
                        tb_DataSaida.Text = tb_DataSaida.Text + "/";
                        tb_DataSaida.SelectionStart = 6;
                        break;

                    case 8:
                        tb_DataSaida.Text = tb_DataSaida.Text + "";
                        tb_DataSaida.SelectionStart = 10;
                        break;
                }
            }
        }

        private void tb_DataSaida_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                tb_DataSaida.Clear();             //Limpar campo 
            }
            else if (e.KeyCode == Keys.Back)
            {
                tb_DataSaida.Clear();
            }
        }

        private void pbFotoPerfil_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.FileName = "";
                openFileDialog1.Filter = "png| *.png| jpg| *.jpg| jpeg| *.jpeg";    //Puxa a foto dos arquivos 
                openFileDialog1.Title = "Selecione uma imagem";
                DialogResult dr = openFileDialog1.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    pbFotoPerfil.Image = Image.FromFile(openFileDialog1.FileName);
                }
                bSalvou = true;
                passou = true;
            }
            catch (Exception)
            {
                Mensagem.aviso = "Erro ao carregar foto!";
                TelaMensagemAviso f = new TelaMensagemAviso();
                f.ShowDialog();
            }
        }

        private void pb_TrabalhoVol_MouseEnter(object sender, EventArgs e)
        {
            pb_TrabalhoVol.Image = Properties.Resources.visaoRoxo1;
        }

        private void pb_TrabalhoVol_MouseLeave(object sender, EventArgs e)
        {
            pb_TrabalhoVol.Image = Properties.Resources.visao;
        }

        private void pb_editarExperienciaProf_MouseEnter(object sender, EventArgs e)
        {
            pb_editarExperienciaProf.Image = Properties.Resources.visaoRoxo1;
        }

        private void pb_editarExperienciaProf_MouseLeave(object sender, EventArgs e)
        {
            pb_editarExperienciaProf.Image = Properties.Resources.visao;
        }

        private void pb_Qualificacao_MouseEnter(object sender, EventArgs e)
        {
            pb_Qualificacao.Image = Properties.Resources.visaoRoxo1;
        }

        private void pb_Qualificacao_MouseLeave(object sender, EventArgs e)
        {
            pb_Qualificacao.Image = Properties.Resources.visao;
        }

        private void pb_editarExperienciaInt_MouseEnter(object sender, EventArgs e)
        {
            pb_editarExperienciaInt.Image = Properties.Resources.visaoRoxo1;

        }

        private void pb_editarExperienciaInt_MouseLeave(object sender, EventArgs e)
        {
            pb_editarExperienciaInt.Image = Properties.Resources.visao;
        }

        private void pb_editarIdioma_MouseEnter(object sender, EventArgs e)
        {
            pb_editarIdioma.Image = Properties.Resources.visaoRoxo1;
        }

        private void pb_editarIdioma_MouseLeave(object sender, EventArgs e)
        {
            pb_editarIdioma.Image = Properties.Resources.visao;
        }
    }
}
