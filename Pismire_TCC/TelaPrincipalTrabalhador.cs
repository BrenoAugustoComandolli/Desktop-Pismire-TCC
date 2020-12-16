using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using Pismire_TCC.Resources;

namespace Pismire_TCC
{
    public partial class TelaPrincipalTrabalhador : Form
    {
        DateTime dataAtual = (DateTime.Today).Date;

        List<string> cargoSelecionar = new List<string>();
        List<string> areaSelecionar = new List<string>();
        List<string> salarioSelecionar = new List<string>();  
        List<string> empresaSelecionar = new List<string>();

        List<string> selecionadas = new List<string>();  
        List<string> temporario = new List<string>();    

        List<string> saudeSelecionar = new List<string>();
        List<string> odonSelecionar = new List<string>();
        List<string> alimSelecionar = new List<string>();
        List<string> culturaSelecionar = new List<string>();
        List<string> homeSelecionar = new List<string>();      
        List<string> viagemSelecionar = new List<string>();
        List<string> confSelecionar = new List<string>();
        List<string> bolsaSelecionar = new List<string>();

        PismireEntities5 bd = new PismireEntities5();

        double[] latvetor = new double[100];
        double[] logvetor = new double[100];
        double[] idvetor = new double[100];
        int[] ids = new int[100];

        bool saudeSelect = false;
        bool odonSelect = false;
        bool alimSelect = false;
        bool culturaSelect = false;              
        bool homeSelect = false;
        bool viagemSelect = false;
        bool conferenciaSelect = false;
        bool bolsaSelect = false;

        bool bloqRec = false;
        bool bloqInt = false;
        bool bloqIns = false;
        bool bloqNot = false;
        bool bloqChat = false;
        bool bloqConf = false;

        public void visibilidadeMenuTrue()
        {
            if (!TesteTutorial.entrou)
            {
                pbTutorial1.Visible = false;   //Tutorial 2
            }

            pbCriar.Visible = true;
            pnFiltro.Visible = false;    //Abre menu
            pnMenu.Visible = true;
            pnPismire.Visible = true;
            pbAbMenu.Visible = false;
            Pismire.Visible = false;
            pbCriar.Location = new Point(333, 14);
            pbPesquisar.Location = new Point(642, 14);
            txtPesquisa.Location = new Point(688, 24);
            pnPesquisa.Location = new Point(658, 70);
            Pismire.Location = new Point(359, 9);
            pbAbMenu.Location = new Point(333, 11);
        }

        public void LatLong()
        {
            try
            {
                var empresaTeste = bd.usuario_empresa.Where(x => x.FK_usuario != 0).FirstOrDefault();
                if (empresaTeste != null)
                {
                    var max = bd.usuario.Where(y => y.tipoUsuario == false).Max(x => x.idUsuario);
                    int v = 0;
                    for (int i = 1; i <= max; i++)
                    {
                        var algo = bd.usuario.Where(x => x.tipoUsuario == false).Where(y => y.idUsuario == i).FirstOrDefault(); //Pega latitude e Longitude 
                        if (algo != null)
                        {
                            latvetor[v] = Convert.ToDouble(algo.latitudeUsuario);
                            logvetor[v] = Convert.ToDouble(algo.longitudeUsuario);
                            idvetor[v] = algo.idUsuario;
                            v++;
                        }
                    }
                }
            }
            catch (Exception)
            {
                Mensagem.aviso = "Erro de conexão com o banco";    //Verificação de erro
                TelaMensagemAviso f = new TelaMensagemAviso();
                f.ShowDialog();
            }
        }

        public void visibilidadeMenuFalse()
        {
            if (!TesteTutorial.entrou)
            {
                pbTutorial1.Visible = true;      //Fecha tutorial 2 
            }

            pnFiltro.Visible = false;
            pnMenu.Visible = false;
            pnPismire.Visible = true;                //Fecha o menu
            Pismire.Visible = true;
            pbCriar.Location = new Point(123, 14);
            pbPesquisar.Location = new Point(602, 14);
            txtPesquisa.Location = new Point(648, 24);
            pnPesquisa.Location = new Point(618, 70);
            Pismire.Location = new Point(359, 9);
            pbAbMenu.Location = new Point(29, 11);
        }

        public void visibilidadeFiltroTrue()
        {
            pbCriar.Visible = false;
            pnMenu.Visible = false;
            pnFiltro.Visible = true;
            pbAbMenu.Visible = true;
            Pismire.Visible = false;
            pbCriar.Location = new Point(333, 14);
            pbPesquisar.Location = new Point(642, 14);
            txtPesquisa.Location = new Point(688, 24);
            pnPesquisa.Location = new Point(658, 70);      //Abre filtro
            Pismire.Location = new Point(359, 9);
            pbAbMenu.Location = new Point(333, 11);
        }

        public void visibilidadeFiltroFalse()
        {
            pbAbMenu.Visible = true;
            pbCriar.Visible = true;
            pnMenu.Visible = false;
            pnFiltro.Visible = false;
            Pismire.Visible = true;
            pbCriar.Location = new Point(123, 14);
            pbPesquisar.Location = new Point(602, 14);     //Fecha o filtro
            txtPesquisa.Location = new Point(648, 24);
            pnPesquisa.Location = new Point(618, 70);
            Pismire.Location = new Point(359, 9);
            pbAbMenu.Location = new Point(29, 11);

            if (pnMenu.Visible == false && pnFiltro.Visible == false)
            {
                pbAbMenu.Visible = true;
                pbCriar.Visible = true;
            }
        }

        public TelaPrincipalTrabalhador()
        {
            InitializeComponent();
            Maximizacao.verifique(this, pbMaximizar);   //Verifica se a tela está maximizada ou não

            try
            {
                if (!TesteTutorial.entrou)
                {
                    TesteTutorial.instrucao = false;        //Tutorial 1
                    bloquearComandos();
                    pbTutorial1.Visible = true;
                    pbBemVindo.Visible = true;
                    lblBemvindo.Visible = true;
                }
                else if (!TesteTutorial.instrucao)
                {
                    pbTutorial3.Visible = true;
                    bloquearComandos();
                    pbTutorial1.Visible = false;
                    pbBemVindo.Visible = true;                         //Tutoriais finais 
                    lblBemvindo.Visible = true;
                    pbBemVindo.Location = new Point(210, 500); ;
                    lblBemvindo.Text = "Algumas dicas para você";
                    lblBemvindo.Location = new Point(100, 400);
                    pbAbMenu.Enabled = false;
                }

                this.BackColor = Color.FromArgb(29, 29, 29);
                ConverteLatLong();
                LatLong();
                pbAbMenu.Click += PbAbMenu_Click;
                pbCriar.Click += AbreFiltro;
                mapa.OnMarkerClick += ClickMapa;
                mapaFiltro.OnMarkerClick += ClickMarker;
                pbSaude.Click += saude;
                pbOdontologico.Click += PbOdontologico_Click;
                pbAlimentacao.Click += PbAlimentacao_Click;    //Eventos de click 
                pbCultura.Click += PbCultura_Click;
                pbHomeOff.Click += PbHomeOff_Click;
                pbViagem.Click += PbViagem_Click;
                pbSalaConv.Click += PbSalaConv_Click;
                pbBolsa.Click += PbBolsa_Click;

                var usuario = bd.usuario.Where(x => x.idUsuario == UsuarioDados.Id).FirstOrDefault();

                if (Preferencias.local == false)
                {
                    mapaFiltro.Visible = false;
                    mapa.Visible = false;
                    lblAvisoLocalizacao.Visible = true;    //Configurações de local bloqueado
                }
                else
                {
                    mapaFiltro.Visible = true;
                    mapa.Visible = true;
                    lblAvisoLocalizacao.Visible = false;
                }
            }
            catch (Exception)
            {
                Mensagem.aviso = "Erro de conexão com o banco";    //Verificação de erro
                TelaMensagemAviso f = new TelaMensagemAviso();
                f.ShowDialog();
            }
        }
        private void ConverteLatLong()
        {
            try
            {
                var max = bd.usuario.Max(x => x.idUsuario);

                for (int i = 1; i <= max; i++)
                {
                    var usu2 = bd.usuario.Where(x => x.idUsuario == i).FirstOrDefault();
                    char[] Latitude = usu2.latitudeUsuario.ToCharArray();
                    char[] Longitude = usu2.longitudeUsuario.ToCharArray();

                    for (int b = 0; b < Latitude.Length; b++)
                    {
                        if (Latitude[b] == '.')
                        {
                            Latitude[b] = ',';
                        }
                    }

                    for (int c = 0; c < Longitude.Length; c++)
                    {
                        if (Longitude[c] == '.')
                        {
                            Longitude[c] = ',';
                        }
                    }

                    var usu = bd.usuario.Where(x => x.idUsuario == i).ToList();

                    usu.ForEach(x =>
                    {
                        x.latitudeUsuario = new string(Latitude);
                        x.longitudeUsuario = new string(Longitude);
                    });
                    bd.SaveChanges();
                }
            }
            catch (Exception)
            {
                Mensagem.aviso = "Erro de conexão com o banco!";
                TelaMensagemAviso f = new TelaMensagemAviso();
                f.ShowDialog();
            }
        }

        private void bloquearComandos()
        {
            btCurriculo.BackColor = Color.Red;
            mapa.Visible = false;
            mapaFiltro.Visible = false;
            bloqRec = true;
            bloqInt = true;
            bloqIns = true;
            bloqNot = true;
            bloqChat = true;             //Bloqueia comandos para o tutorial
            bloqConf = true;
            mapa.Enabled = false;
            pbCriar.Enabled = false;
            mapaFiltro.Enabled = false;
            pbPesquisar.Enabled = false;
            txtPesquisa.Visible = false;
        }

        private void desbloquearComandos()
        {
            btCurriculo.BackColor = Color.FromArgb(163, 160, 251);
            mapa.Visible = true;
            mapaFiltro.Visible = true;
            bloqRec = false;
            bloqInt = false;
            bloqIns = false;
            bloqNot = false;
            bloqChat = false;             //Desbloqueia comandos para o tutorial
            bloqConf = false;
            mapa.Enabled = true;
            pbCriar.Enabled = true;
            mapaFiltro.Enabled = true;
            pbPesquisar.Enabled = true;
            pbAbMenu.Enabled = true;
            txtPesquisa.Visible = true;
        }

        private void ClickMarker(GMapMarker item, MouseEventArgs e)
        {
            try
            {
                var VerificaUsuario = bd.usuario.Where(x => x.idUsuario.ToString() == item.Overlay.Id).FirstOrDefault();
                if (VerificaUsuario != null)
                {
                    PegarIDEmpresa.IDEmpresa = VerificaUsuario.idUsuario;
                    PegarIDEmpresa.latitude = Convert.ToDouble(VerificaUsuario.latitudeUsuario);
                    PegarIDEmpresa.longitude = Convert.ToDouble(VerificaUsuario.longitudeUsuario);   //Abre perfil empresa 
                }
                this.Hide();
                TelaVisualizacaoPerfilEmpresa f = new TelaVisualizacaoPerfilEmpresa();
                f.Closed += (s, args) => this.Close();
                f.ShowDialog();
            }
            catch (Exception)
            {
                Mensagem.aviso = "Erro de conexão com o banco";    //Verificação de erro
                TelaMensagemAviso f = new TelaMensagemAviso();
                f.ShowDialog();
            }
        }

        private void PbBolsa_Click(object sender, EventArgs e)
        {
            if (bolsaSelect == false)
            {
                pbBolsa.Image = Properties.Resources.verifica;
                bolsaSelect = true;
            }
            else
            {
                pbBolsa.Image = Properties.Resources.caixa_de_selecao__1_;
                bolsaSelect = false;
            }
        }

        private void PbSalaConv_Click(object sender, EventArgs e)
        {
            if (conferenciaSelect == false)
            {
                pbSalaConv.Image = Properties.Resources.verifica;
                conferenciaSelect = true;
            }
            else
            {
                pbSalaConv.Image = Properties.Resources.caixa_de_selecao__1_;
                conferenciaSelect = false;
            }
        }

        private void PbViagem_Click(object sender, EventArgs e)
        {
            if (viagemSelect == false)
            {
                pbViagem.Image = Properties.Resources.verifica;
                viagemSelect = true;
            }
            else
            {
                pbViagem.Image = Properties.Resources.caixa_de_selecao__1_;
                viagemSelect = false;
            }
        }

        private void PbHomeOff_Click(object sender, EventArgs e)
        {
            if (homeSelect == false)
            {
                pbHomeOff.Image = Properties.Resources.verifica;
                homeSelect = true;
            }
            else
            {
                pbHomeOff.Image = Properties.Resources.caixa_de_selecao__1_;
                homeSelect = false;
            }
        }

        private void PbCultura_Click(object sender, EventArgs e)
        {
            if (culturaSelect == false)
            {
                pbCultura.Image = Properties.Resources.verifica;
                culturaSelect = true;
            }
            else
            {
                pbCultura.Image = Properties.Resources.caixa_de_selecao__1_;             //Filtros de beneficios 
                culturaSelect = false;
            }
        }

        private void PbAlimentacao_Click(object sender, EventArgs e)
        {
            if (alimSelect == false)
            {
                pbAlimentacao.Image = Properties.Resources.verifica;
                alimSelect = true;
            }
            else
            {
                pbAlimentacao.Image = Properties.Resources.caixa_de_selecao__1_;
                alimSelect = false;
            }
        }

        private void PbOdontologico_Click(object sender, EventArgs e)
        {
            if (odonSelect == false)
            {
                pbOdontologico.Image = Properties.Resources.verifica;
                odonSelect = true;
            }
            else
            {
                pbOdontologico.Image = Properties.Resources.caixa_de_selecao__1_;
                odonSelect = false;
            }
        }

        private void saude(object sender, EventArgs e)
        {
            if (saudeSelect == false)
            {
                pbSaude.Image = Properties.Resources.verifica;
                saudeSelect = true;
            }
            else
            {
                pbSaude.Image = Properties.Resources.caixa_de_selecao__1_;
                saudeSelect = false;
            }
        }

        private void AbreFiltro(object sender, EventArgs e)
        {
            if (Preferencias.local == false)
            {
                Mensagem.aviso = "Acesso negado! habilite em configurações";    //Verificação de preferencias
                TelaMensagemAviso f = new TelaMensagemAviso();
                f.ShowDialog();
            }
            else
            {
                visibilidadeFiltroTrue();
            }

            if (!TesteTutorial.instrucao)
            {
                finalTutorial();
            }
        }

        private void ClickMapa(GMapMarker item, MouseEventArgs e)
        {
            try
            {
                var VerificaUsuario = bd.usuario.Where(x => x.idUsuario.ToString() == item.Overlay.Id).FirstOrDefault();
                if (VerificaUsuario != null)
                {
                    if(VerificaUsuario.tipoUsuario == false)
                    {
                        PegarIDEmpresa.IDEmpresa = VerificaUsuario.idUsuario;
                        PegarIDEmpresa.latitude = Convert.ToDouble(VerificaUsuario.latitudeUsuario);
                        PegarIDEmpresa.longitude = Convert.ToDouble(VerificaUsuario.longitudeUsuario);   //Abre perfil empresa

                        this.Hide();
                        TelaVisualizacaoPerfilEmpresa f = new TelaVisualizacaoPerfilEmpresa();
                        f.Closed += (s, args) => this.Close();
                        f.ShowDialog();
                    }
                    else
                    {
                        PegarID.ID = VerificaUsuario.idUsuario;
                        PegarIDEmpresa.latitude = Convert.ToDouble(VerificaUsuario.latitudeUsuario);
                        PegarIDEmpresa.longitude = Convert.ToDouble(VerificaUsuario.longitudeUsuario);   //Abre perfil empresa

                        this.Hide();
                        TelaVisualizacaoCurriculo f = new TelaVisualizacaoCurriculo();
                        f.Closed += (s, args) => this.Close();
                        f.ShowDialog();
                    }
                     
                }
            }
            catch (Exception)
            {
                Mensagem.aviso = "Erro de conexão com o banco";    //Verificação de erro
                TelaMensagemAviso f = new TelaMensagemAviso();
                f.ShowDialog();
            }
        }

        private void PbAbMenu_Click(object sender, EventArgs e)
        {
            visibilidadeMenuTrue();

            if (!TesteTutorial.instrucao)
            {
                finalTutorial();
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
            pbMaximizar.BackColor = Color.FromArgb(41, 41, 41);                  //Animações de botões 
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

        private void btCurriculo_Click(object sender, EventArgs e)
        {
            this.Hide();
            TelaVisualizacaoCurriculo f = new TelaVisualizacaoCurriculo();
            f.Closed += (s, args) => this.Close();
            f.ShowDialog();
        }

        private void btCurriculo_MouseEnter(object sender, EventArgs e)
        {
            if (TesteTutorial.entrou)
            {
                pbFachaCurriculo.Visible = true;
                btCurriculo.ForeColor = Color.FromArgb(163, 160, 251);
                btCurriculo.Image = Properties.Resources.candidatosteste1;
            }
            else
            {
                btCurriculo.ForeColor = Color.White;
            }
        }

        private void btCurriculo_MouseHover(object sender, EventArgs e)
        {
            if (TesteTutorial.entrou)
            {
                pbFachaCurriculo.Visible = true;
                btCurriculo.ForeColor = Color.FromArgb(163, 160, 251);
                btCurriculo.Image = Properties.Resources.candidatosteste1;
            }
            else
            {
                btCurriculo.ForeColor = Color.White;
            }
        }

        private void btCurriculo_MouseLeave(object sender, EventArgs e)
        {
            if (TesteTutorial.entrou)
            {
                pbFachaCurriculo.Visible = false;
                btCurriculo.ForeColor = Color.White;
                btCurriculo.Image = Properties.Resources.Candidatos;
            }
        }

        private void btRecomendacoes_Click(object sender, EventArgs e)
        {
            if (!bloqRec)
            {
                if (Preferencias.rec == true)
                {
                    this.Hide();
                    TelaRecomendacoes f = new TelaRecomendacoes();
                    f.Closed += (s, args) => this.Close();
                    f.ShowDialog();
                }
                else
                {
                    Mensagem.aviso = "Recomendações desativadas!";
                    TelaMensagemAviso f = new TelaMensagemAviso();
                    f.ShowDialog();
                }
            }
        }
        private void btRecomendacoes_MouseEnter(object sender, EventArgs e)
        {
            pbFachaRecomendacoes.Visible = true;
            btRecomendacoes.ForeColor = Color.FromArgb(163, 160, 251);
            btRecomendacoes.Image = Properties.Resources.recomendacoesTeste;
        }

        private void btRecomendacoes_MouseHover(object sender, EventArgs e)
        {
            pbFachaRecomendacoes.Visible = true;
            btRecomendacoes.ForeColor = Color.FromArgb(163, 160, 251);
            btRecomendacoes.Image = Properties.Resources.recomendacoesTeste;
        }

        private void btRecomendacoes_MouseLeave(object sender, EventArgs e)
        {
            pbFachaRecomendacoes.Visible = false;
            btRecomendacoes.ForeColor = Color.White;
            btRecomendacoes.Image = Properties.Resources.Recomendacoes1;
        }

        private void btInteresses_Click(object sender, EventArgs e)
        {
            if (!bloqInt)
            {
                bloqConf = true;
                this.Hide();
                TelaInteresses f = new TelaInteresses();
                f.Closed += (s, args) => this.Close();
                f.ShowDialog();
            }
        }

        private void btInteresses_MouseEnter(object sender, EventArgs e)
        {
            pbFachaInteresse.Visible = true;
            btInteresses.ForeColor = Color.FromArgb(163, 160, 251);
            btInteresses.Image = Properties.Resources.marca_paginas_roxo;
        }

        private void btInteresses_MouseHover(object sender, EventArgs e)
        {
            pbFachaInteresse.Visible = true;
            btInteresses.ForeColor = Color.FromArgb(163, 160, 251);
            btInteresses.Image = Properties.Resources.marca_paginas_roxo;
        }

        private void btInteresses_MouseLeave(object sender, EventArgs e)
        {
            pbFachaInteresse.Visible = false;
            btInteresses.ForeColor = Color.White;
            btInteresses.Image = Properties.Resources.marca_paginas;
        }

        private void btInscricoes_Click(object sender, EventArgs e)
        {
            if (!bloqIns)
            {
                this.Hide();
                TelaInscricoes f = new TelaInscricoes();
                f.Closed += (s, args) => this.Close();
                f.ShowDialog();
            }
        }

        private void btInscricoes_MouseEnter(object sender, EventArgs e)
        {
            pbFachaInscricoes.Visible = true;
            btInscricoes.ForeColor = Color.FromArgb(163, 160, 251);
            btInscricoes.Image = Properties.Resources.CalendarioTeste;
        }

        private void btInscricoes_MouseHover(object sender, EventArgs e)
        {
            pbFachaInscricoes.Visible = true;
            btInscricoes.ForeColor = Color.FromArgb(163, 160, 251);
            btInscricoes.Image = Properties.Resources.CalendarioTeste;
        }

        private void btInscricoes_MouseLeave(object sender, EventArgs e)
        {
            pbFachaInscricoes.Visible = false;
            btInscricoes.ForeColor = Color.White;
            btInscricoes.Image = Properties.Resources.unknown__7_;
        }

        private void btNotificacoes_Click(object sender, EventArgs e)
        {
            if (!bloqNot)
            {
                if (Preferencias.notf == true)
                {
                    this.Hide();
                    TelaNotificacao f = new TelaNotificacao();
                    f.Closed += (s, args) => this.Close();
                    f.ShowDialog();
                }
                else
                {
                    Mensagem.aviso = "Acesso negado! habilite em configurações";    //Verificação de preferencias
                    TelaMensagemAviso f = new TelaMensagemAviso();
                    f.ShowDialog();
                }
            }
        }

        private void btNotificacoes_MouseEnter(object sender, EventArgs e)
        {
            pbFachaNotificacao.Visible = true;
            btNotificacoes.ForeColor = Color.FromArgb(163, 160, 251);
            btNotificacoes.Image = Properties.Resources.sino_roxo;
        }

        private void btNotificacoes_MouseHover(object sender, EventArgs e)
        {
            pbFachaNotificacao.Visible = true;
            btNotificacoes.ForeColor = Color.FromArgb(163, 160, 251);
            btNotificacoes.Image = Properties.Resources.sino_roxo;
        }

        private void btNotificacoes_MouseLeave(object sender, EventArgs e)
        {
            pbFachaNotificacao.Visible = false;
            btNotificacoes.ForeColor = Color.White;
            btNotificacoes.Image = Properties.Resources.unknown__8_;
        }

        private void btChat_Click(object sender, EventArgs e)
        {
            if (!bloqChat)
            {
                this.Hide();
                TelaMensagemTrabalhador f = new TelaMensagemTrabalhador();
                f.Closed += (s, args) => this.Close();
                f.ShowDialog();
            }
        }

        private void btChat_MouseEnter(object sender, EventArgs e)
        {
            pbTeste5.Visible = true;
            btMensagem.ForeColor = Color.FromArgb(163, 160, 251);
            btMensagem.Image = Properties.Resources.bate_papo_roxo;
        }

        private void btChat_MouseHover(object sender, EventArgs e)
        {
            pbTeste5.Visible = true;
            btMensagem.ForeColor = Color.FromArgb(163, 160, 251);
            btMensagem.Image = Properties.Resources.bate_papo_roxo;
        }

        private void btChat_MouseLeave(object sender, EventArgs e)
        {
            pbTeste5.Visible = false;
            btMensagem.ForeColor = Color.White;
            btMensagem.Image = Properties.Resources.bate_papo;
        }

        private void btConfiguracoes_Click(object sender, EventArgs e)
        {
            if (!bloqConf)
            {
                this.Hide();
                TelaConfiguracao f = new TelaConfiguracao();
                f.Closed += (s, args) => this.Close();
                f.ShowDialog();
            }
        }

        private void btConfiguracoes_MouseEnter(object sender, EventArgs e)
        {
            pbFachaConfiguracoes.Visible = true;
            btConfiguracoes.ForeColor = Color.FromArgb(163, 160, 251);
            btConfiguracoes.Image = Properties.Resources.engrenagem_roxo;
        }

        private void btConfiguracoes_MouseHover(object sender, EventArgs e)
        {
            pbFachaConfiguracoes.Visible = true;
            btConfiguracoes.ForeColor = Color.FromArgb(163, 160, 251);
            btConfiguracoes.Image = Properties.Resources.engrenagem_roxo;
        }

        private void btConfiguracoes_MouseLeave(object sender, EventArgs e)
        {
            pbFachaConfiguracoes.Visible = false;
            btConfiguracoes.ForeColor = Color.White;
            btConfiguracoes.Image = Properties.Resources.engrenagem;
        }

        private void btSair_Click(object sender, EventArgs e)
        {
            this.Hide();
            TelaLogin f = new TelaLogin();
            f.Closed += (s, args) => this.Close();         //Abrir tela Login
            f.ShowDialog();
        }

        private void btSair_MouseEnter(object sender, EventArgs e)
        {
            pbTeste7.Visible = true;
            btSair.ForeColor = Color.FromArgb(163, 160, 251);
            btSair.Image = Properties.Resources.sair_roxo;
        }

        private void btSair_MouseHover(object sender, EventArgs e)
        {
            pbTeste7.Visible = true;
            btSair.ForeColor = Color.FromArgb(163, 160, 251);
            btSair.Image = Properties.Resources.sair_roxo;
        }

        private void btSair_MouseLeave(object sender, EventArgs e)
        {
            pbTeste7.Visible = false;
            btSair.ForeColor = Color.White;
            btSair.Image = Properties.Resources.unknown__13_;
        }

        GMapOverlay markers = new GMapOverlay("markers");
        private void TelaPrincipalTrabalhador_Load(object sender, EventArgs e)
        {
            try
            {
                if (TesteTutorial.entrou && TesteTutorial.instrucao)
                {
                    if (Preferencias.local == true)
                    {
                        GoogleMapProvider.Instance.ApiKey = "AIzaSyBMP0Effep3xeLHrxwJi6hmNcDUm6ze27g";
                        Bitmap image = Properties.Resources.Fumiguinha1;
                        mapa.Visible = false;
                        for (int i = 0; i < latvetor.Length; i++)
                        {
                            if (latvetor[i] != 0)
                            {
                                PointLatLng point = new PointLatLng(latvetor[i], logvetor[i]);
                                GMapMarker marker = new GMarkerGoogle(point, image);
                                markers = new GMapOverlay(idvetor[i].ToString());
                                markers.Markers.Add(marker);
                                mapa.Overlays.Add(markers);
                                mapa.Refresh();
                            }
                        }

                        mapa.Visible = true;
                        mapa.ShowCenter = false;
                        var count = bd.usuario.Where(x => x.tipoUsuario == false).Count();
                        var LatInicial = bd.usuario.Where(x => x.idUsuario == UsuarioDados.Id).FirstOrDefault();        //Carregamento do mapa 
                        double lat = Convert.ToDouble(LatInicial.latitudeUsuario);
                        double log = Convert.ToDouble(LatInicial.longitudeUsuario);
                        mapa.DragButton = MouseButtons.Left;
                        mapa.CanDragMap = true;
                        mapa.MapProvider = GMapProviders.GoogleMap;
                        mapa.Position = new PointLatLng(lat, log);
                        mapa.MinZoom = 0;
                        mapa.MaxZoom = 24;
                        mapa.Zoom = 15;
                        mapa.AutoScroll = true;
                        Bitmap tt = Properties.Resources.Bolinha21;
                        PointLatLng teste = new PointLatLng(lat, log);
                        GMapMarker mm = new GMarkerGoogle(teste, tt);
                        GMapOverlay mk = new GMapOverlay(UsuarioDados.Id.ToString());
                        mk.Markers.Add(mm);
                        mapa.Overlays.Add(mk);
                        mapa.Refresh();
                    }
                    else
                    {
                        mapa.Visible = false;
                        mapaFiltro.Visible = false;
                    }
                }
                else
                {
                    mapa.Visible = false;
                    mapaFiltro.Visible = false;
                }
            }
            catch (Exception)
            {
                Mensagem.aviso = "Erro ao carregar o mapa";    //Verificação de erro
                TelaMensagemAviso f = new TelaMensagemAviso();
                f.ShowDialog();
            }
        }

        private void btFiltro_Click(object sender, EventArgs e)        //Verifica se algum campo foi preenchido
        {
            cargoSelecionar.Clear();
            areaSelecionar.Clear();
            salarioSelecionar.Clear();      //Lista de selecionados pelo filtro
            empresaSelecionar.Clear();

            selecionadas.Clear();  //Lista definitiva
            temporario.Clear();    //Lista temporária

            saudeSelecionar.Clear();
            odonSelecionar.Clear();
            alimSelecionar.Clear();
            culturaSelecionar.Clear();
            homeSelecionar.Clear();        //Lista de beneficios
            viagemSelecionar.Clear();
            confSelecionar.Clear();
            bolsaSelecionar.Clear();

            if (txtCargo.Text == "" && txtArea.Text == "" && txtSalario.Text == "" && txtEmpresa.Text == "" && saudeSelect == false &&
                odonSelect == false && alimSelect == false && culturaSelect == false && homeSelect == false && viagemSelect == false &&
                conferenciaSelect == false && bolsaSelect == false)
            {
                Mensagem.aviso = "Preencha pelo menos um campo!";       //Verificação de campos vázios
                TelaMensagemAviso f = new TelaMensagemAviso();
                f.ShowDialog();
            }
            else
            {
                try
                {
                    var evento = bd.evento.Where(x => x.idEvento != 0)
                    .Where(x => x.dataFinalEvento >= dataAtual).FirstOrDefault();  //Verifica se há eventos

                    if (evento != null)
                    {
                        int max = bd.evento.Max(x => x.idEvento);
                        int maxBen = bd.beneficios.Max(x => x.idBeneficio);

                        var beneficios = bd.beneficios.Where(x => x.idBeneficio != 0).FirstOrDefault();  //Verifica se há eventos

                        if (beneficios != null)
                        {

                            if (txtCargo.Text != "")
                            {
                                for (int i = 0; i <= max; i++)                     //Verifica e anota as empresa com vaga igual
                                {
                                    var cargo = bd.evento.Where(x => x.vagaEvento.Contains(txtCargo.Text))
                                    .Where(x => x.idEvento == i).Where(x => x.dataFinalEvento >= dataAtual).FirstOrDefault();

                                    if (cargo != null)
                                    {
                                        cargoSelecionar.Add(cargo.FK_usuario_empresa);
                                    }
                                }
                            }

                            if (txtArea.Text != "")
                            {
                                for (int i = 0; i <= max; i++)
                                {
                                    var area = bd.evento.Where(x => x.areaEvento.Contains(txtArea.Text))
                                    .Where(x => x.idEvento == i).Where(x => x.dataFinalEvento >= dataAtual).FirstOrDefault();

                                    if (area != null)                                //Verifica e anota as empresa com area igual
                                    {
                                        areaSelecionar.Add(area.FK_usuario_empresa);
                                    }
                                }
                            }

                            if (txtSalario.Text != "")
                            {
                                string realSalario;

                                realSalario = txtSalario.Text.Replace(".", "");
                                realSalario = realSalario.Replace("R$:", "");
                                for (int i = 0; i <= max; i++)
                                {
                                    double txt = double.Parse(realSalario);
                                    var salario = bd.evento.Where(x => x.salario >= txt)
                                    .Where(x => x.idEvento == i).Where(x => x.dataFinalEvento >= dataAtual).FirstOrDefault();

                                    if (salario != null)         //Verifica e anota as empresa com salario igual
                                    {
                                        salarioSelecionar.Add(salario.FK_usuario_empresa);
                                    }
                                }
                            }

                            if (txtEmpresa.Text != "")
                            {
                                for (int i = 0; i <= max; i++)
                                {
                                    var usuario = bd.usuario.Where(x => x.nomeUsuario.Contains(txtEmpresa.Text)).FirstOrDefault();

                                    if (usuario != null)         //Verifica e anota as empresa com nome igual
                                    {
                                        var usuarioEmpresa = bd.usuario_empresa.Where(x => x.FK_usuario == usuario.idUsuario).FirstOrDefault();
                                        var empresa = bd.evento.Where(x => x.FK_usuario_empresa == usuarioEmpresa.cnpj)
                                        .Where(x => x.idEvento == i).Where(x => x.dataFinalEvento >= dataAtual).FirstOrDefault();

                                        if (empresa != null)
                                        {
                                            empresaSelecionar.Add(empresa.FK_usuario_empresa);
                                        }
                                    }
                                }
                            }

                            if (saudeSelect == true)
                            {
                                for (int i = 0; i <= maxBen; i++)
                                {
                                    var saude = bd.beneficios.Where(x => x.assistenciaSaude == true)
                                    .Where(x => x.idBeneficio == i).FirstOrDefault();

                                    if (saude != null)                                //Beneficio de saude 
                                    {
                                        var empresa = bd.evento.Where(x => x.idEvento == saude.FK_evento)
                                        .Where(x => x.dataFinalEvento >= dataAtual).FirstOrDefault();

                                        if (empresa != null)
                                        {
                                            saudeSelecionar.Add(empresa.FK_usuario_empresa);
                                        }
                                    }
                                }
                            }

                            if (odonSelect == true)
                            {
                                for (int i = 0; i <= maxBen; i++)
                                {
                                    var odon = bd.beneficios.Where(x => x.assistenciaOdontologica == true)
                                    .Where(x => x.idBeneficio == i).FirstOrDefault();

                                    if (odon != null)                                //Beneficio de odontologia 
                                    {
                                        var empresa = bd.evento.Where(x => x.idEvento == odon.FK_evento)
                                        .Where(x => x.dataFinalEvento >= dataAtual).FirstOrDefault();

                                        if (empresa != null)
                                        {
                                            odonSelecionar.Add(empresa.FK_usuario_empresa);
                                        }
                                    }
                                }
                            }

                            if (alimSelect == true)
                            {
                                for (int i = 0; i <= maxBen; i++)
                                {
                                    var alim = bd.beneficios.Where(x => x.valeAlimentacao == true)
                                    .Where(x => x.idBeneficio == i).FirstOrDefault();

                                    if (alim != null)                                //Vale alimentação 
                                    {
                                        var empresa = bd.evento.Where(x => x.idEvento == alim.FK_evento)
                                        .Where(x => x.dataFinalEvento >= dataAtual).FirstOrDefault();

                                        if (empresa != null)
                                        {
                                            alimSelecionar.Add(empresa.FK_usuario_empresa);
                                        }
                                    }
                                }
                            }

                            if (culturaSelect == true)
                            {
                                for (int i = 0; i <= maxBen; i++)
                                {
                                    var cultura = bd.beneficios.Where(x => x.valeCultura == true)
                                    .Where(x => x.idBeneficio == i).FirstOrDefault();

                                    if (cultura != null)                                //Vale cultura
                                    {
                                        var empresa = bd.evento.Where(x => x.idEvento == cultura.FK_evento)
                                        .Where(x => x.dataFinalEvento >= dataAtual).FirstOrDefault();

                                        if (empresa != null)
                                        {
                                            culturaSelecionar.Add(empresa.FK_usuario_empresa);
                                        }
                                    }
                                }
                            }

                            if (homeSelect == true)
                            {
                                for (int i = 0; i <= maxBen; i++)
                                {
                                    var home = bd.beneficios.Where(x => x.trabalhoHomeOffice == true)
                                    .Where(x => x.idBeneficio == i).FirstOrDefault();

                                    if (home != null)                                //Vale Home
                                    {
                                        var empresa = bd.evento.Where(x => x.idEvento == home.FK_evento)
                                        .Where(x => x.dataFinalEvento >= dataAtual).FirstOrDefault();

                                        if (empresa != null)
                                        {
                                            homeSelecionar.Add(empresa.FK_usuario_empresa);
                                        }
                                    }
                                }
                            }

                            if (viagemSelect == true)
                            {
                                for (int i = 0; i <= maxBen; i++)
                                {
                                    var viagem = bd.beneficios.Where(x => x.valeViagem == true)
                                    .Where(x => x.idBeneficio == i).FirstOrDefault();

                                    if (viagem != null)                                //Vale Viagem
                                    {
                                        var empresa = bd.evento.Where(x => x.idEvento == viagem.FK_evento)
                                        .Where(x => x.dataFinalEvento >= dataAtual).FirstOrDefault();

                                        if (empresa != null)
                                        {
                                            viagemSelecionar.Add(empresa.FK_usuario_empresa);
                                        }
                                    }
                                }
                            }

                            if (conferenciaSelect == true)
                            {
                                for (int i = 0; i <= maxBen; i++)
                                {
                                    var conf = bd.beneficios.Where(x => x.salasDeConferencias == true)
                                    .Where(x => x.idBeneficio == i).FirstOrDefault();

                                    if (conf != null)                                //Vale Conferencia
                                    {
                                        var empresa = bd.evento.Where(x => x.idEvento == conf.FK_evento)
                                        .Where(x => x.dataFinalEvento >= dataAtual).FirstOrDefault();

                                        if (empresa != null)
                                        {
                                            confSelecionar.Add(empresa.FK_usuario_empresa);
                                        }
                                    }
                                }
                            }

                            if (bolsaSelect == true)
                            {
                                for (int i = 0; i <= maxBen; i++)
                                {
                                    var bolsa = bd.beneficios.Where(x => x.bolsasDeEstudos == true)
                                    .Where(x => x.idBeneficio == i).FirstOrDefault();

                                    if (bolsa != null)                                //Vale Bolsa
                                    {
                                        var empresa = bd.evento.Where(x => x.idEvento == bolsa.FK_evento)
                                        .Where(x => x.dataFinalEvento >= dataAtual).FirstOrDefault();

                                        if (empresa != null)
                                        {
                                            bolsaSelecionar.Add(empresa.FK_usuario_empresa);
                                        }
                                    }
                                }
                            }

                            testarFiltro();

                            if (selecionadas.Count < 1)
                            {
                                Mensagem.aviso = "Nenhuma empresa encontrada!";           //Verificação de filtro 
                                TelaMensagemAviso f = new TelaMensagemAviso();
                                f.ShowDialog();
                            }
                            else
                            {
                                if (selecionadas.Count == 1)
                                {
                                    Mensagem.aviso = "Empresa encontrada!";           //Empresa encontrada  
                                    TelaMensagemAviso f = new TelaMensagemAviso();
                                    f.ShowDialog();
                                }
                                else
                                {
                                    Mensagem.aviso = "Empresas encontradas!";           //Empresa encontrada  
                                    TelaMensagemAviso f = new TelaMensagemAviso();
                                    f.ShowDialog();
                                }

                                mapaFiltro.Overlays.Clear();
                                for (int i = 0; i < selecionadas.Count(); i++)
                                {
                                    string cnpj = selecionadas.ElementAt(i).ToString();
                                    var empresa = bd.usuario_empresa.Where(x => x.cnpj.Equals(cnpj)).FirstOrDefault();
                                    if (empresa != null)
                                    {
                                        var usu = bd.usuario.Where(x => x.idUsuario == empresa.FK_usuario).FirstOrDefault();
                                        Bitmap image = Properties.Resources.Fumiguinha1;
                                        PointLatLng teste = new PointLatLng(Convert.ToDouble(usu.latitudeUsuario), Convert.ToDouble(usu.longitudeUsuario));
                                        GMapMarker marker = new GMarkerGoogle(teste, image);
                                        GMapOverlay ma = new GMapOverlay(usu.idUsuario.ToString());
                                        ma.Markers.Add(marker);
                                        mapaFiltro.Overlays.Add(ma);
                                        mapaFiltro.Refresh();
                                    }
                                }
                                mapaFiltro.ShowCenter = false;
                                var usuario = bd.usuario.Where(x => x.idUsuario == UsuarioDados.Id).FirstOrDefault();
                                double lat = Convert.ToDouble(usuario.latitudeUsuario);
                                double log = Convert.ToDouble(usuario.longitudeUsuario);
                                mapaFiltro.ShowCenter = false;
                                mapaFiltro.DragButton = MouseButtons.Left;
                                mapaFiltro.CanDragMap = true;
                                mapaFiltro.MapProvider = GMapProviders.GoogleMap;
                                mapaFiltro.Position = new PointLatLng(lat, log);
                                mapaFiltro.MinZoom = 0;
                                mapaFiltro.MaxZoom = 24;
                                mapaFiltro.Zoom = 15;
                                mapaFiltro.AutoScroll = true;
                                PointLatLng point = new PointLatLng(lat, log);
                                GMapMarker mm = new GMarkerGoogle(point, Properties.Resources.Bolinha21);
                                GMapOverlay mk = new GMapOverlay(UsuarioDados.Id.ToString());
                                mk.Markers.Add(mm);
                                mapaFiltro.Overlays.Add(mk);
                                mapaFiltro.Refresh();
                                mapaFiltro.Visible = true;
                                mapa.Visible = false;
                            }
                            //Selecionadas - Lista com emepresa do filtro
                        }
                        else
                        {
                            Mensagem.aviso = "Nenhuma empresa encontrada!";        //Verificação de se há evento
                            TelaMensagemAviso f = new TelaMensagemAviso();
                            f.ShowDialog();
                        }
                    }
                    else
                    {
                        Mensagem.aviso = "Nenhuma empresa encontrada!";        //Verificação de se há evento
                        TelaMensagemAviso f = new TelaMensagemAviso();
                        f.ShowDialog();
                    }
                }
                catch (Exception)
                {
                    Mensagem.aviso = "Erro ao filtrar!";                   //Verificação de ERRO
                    TelaMensagemAviso f = new TelaMensagemAviso();
                    f.ShowDialog();
                }
            }
        }

        private void filtroCargo()
        {
            temporario = new List<string>();
            bool passou;

            for (int i = 0; i < selecionadas.Count; i++)
            {
                passou = false;

                for (int j = 0; j < cargoSelecionar.Count; j++)
                {
                    if (selecionadas.ElementAt(i) == cargoSelecionar.ElementAt(j))
                    {
                        passou = true;
                        break;
                    }
                }
                if (passou)
                {
                    temporario.Add(selecionadas.ElementAt(i));
                }
            }

            selecionadas.Clear();
            if (temporario.Count > 0)
            {
                selecionadas = temporario;
            }
        }

        private void filtroArea()
        {
            temporario = new List<string>();
            bool passou;

            for (int i = 0; i < selecionadas.Count; i++)
            {
                passou = false;

                for (int j = 0; j < areaSelecionar.Count; j++)
                {
                    if (selecionadas.ElementAt(i) == areaSelecionar.ElementAt(j))
                    {
                        passou = true;
                        break;
                    }
                }
                if (passou)
                {
                    temporario.Add(selecionadas.ElementAt(i));
                }
            }

            selecionadas.Clear();
            if (temporario.Count > 0)
            {
                selecionadas = temporario;
            }
        }

        private void filtroSalario()                                                //Filtro de comparação entre listas 
        {
            temporario = new List<string>();
            bool passou;

            for (int i = 0; i < selecionadas.Count; i++)
            {
                passou = false;

                for (int j = 0; j < salarioSelecionar.Count; j++)
                {
                    if (selecionadas.ElementAt(i) == salarioSelecionar.ElementAt(j))
                    {
                        passou = true;
                        break;
                    }
                }
                if (passou)
                {
                    temporario.Add(selecionadas.ElementAt(i));
                }
            }

            selecionadas.Clear();
            if (temporario.Count > 0)
            {
                selecionadas = temporario;
            }
        }

        private void filtroEmpresa()
        {
            temporario = new List<string>();
            bool passou;

            for (int i = 0; i < selecionadas.Count; i++)
            {
                passou = false;

                for (int j = 0; j < empresaSelecionar.Count; j++)
                {
                    if (selecionadas.ElementAt(i) == empresaSelecionar.ElementAt(j))
                    {
                        passou = true;
                        break;
                    }
                }
                if (passou)
                {
                    temporario.Add(selecionadas.ElementAt(i));
                }
            }

            selecionadas.Clear();
            if (temporario.Count > 0)
            {
                selecionadas = temporario;
            }
        }

        private void filtroSaude()
        {
            temporario = new List<string>();
            bool passou;

            for (int i = 0; i < selecionadas.Count; i++)
            {
                passou = false;

                for (int j = 0; j < saudeSelecionar.Count; j++)
                {
                    if (selecionadas.ElementAt(i) == saudeSelecionar.ElementAt(j))
                    {
                        passou = true;
                        break;
                    }
                }
                if (passou)
                {
                    temporario.Add(selecionadas.ElementAt(i));
                }
            }

            selecionadas.Clear();
            if (temporario.Count > 0)
            {
                selecionadas = temporario;
            }
        }

        private void filtroOdon()
        {
            temporario = new List<string>();
            bool passou;

            for (int i = 0; i < selecionadas.Count; i++)
            {
                passou = false;

                for (int j = 0; j < odonSelecionar.Count; j++)
                {
                    if (selecionadas.ElementAt(i) == odonSelecionar.ElementAt(j))
                    {
                        passou = true;
                        break;
                    }
                }
                if (passou)
                {
                    temporario.Add(selecionadas.ElementAt(i));
                }
            }

            selecionadas.Clear();
            if (temporario.Count > 0)
            {
                selecionadas = temporario;
            }
        }

        private void filtroAlim()
        {
            temporario = new List<string>();
            bool passou;

            for (int i = 0; i < selecionadas.Count; i++)
            {
                passou = false;

                for (int j = 0; j < alimSelecionar.Count; j++)
                {
                    if (selecionadas.ElementAt(i) == alimSelecionar.ElementAt(j))
                    {
                        passou = true;
                        break;
                    }
                }
                if (passou)
                {
                    temporario.Add(selecionadas.ElementAt(i));
                }
            }

            selecionadas.Clear();
            if (temporario.Count > 0)
            {
                selecionadas = temporario;
            }
        }

        private void filtroCultura()
        {
            temporario = new List<string>();
            bool passou;

            for (int i = 0; i < selecionadas.Count; i++)
            {
                passou = false;

                for (int j = 0; j < culturaSelecionar.Count; j++)
                {
                    if (selecionadas.ElementAt(i) == culturaSelecionar.ElementAt(j))
                    {
                        passou = true;
                        break;
                    }
                }
                if (passou)
                {
                    temporario.Add(selecionadas.ElementAt(i));
                }
            }

            selecionadas.Clear();
            if (temporario.Count > 0)
            {
                selecionadas = temporario;
            }
        }

        private void filtroHome()
        {
            temporario = new List<string>();
            bool passou;

            for (int i = 0; i < selecionadas.Count; i++)
            {
                passou = false;

                for (int j = 0; j < homeSelecionar.Count; j++)
                {
                    if (selecionadas.ElementAt(i) == homeSelecionar.ElementAt(j))
                    {
                        passou = true;
                        break;
                    }
                }
                if (passou)
                {
                    temporario.Add(selecionadas.ElementAt(i));
                }
            }

            selecionadas.Clear();
            if (temporario.Count > 0)
            {
                selecionadas = temporario;
            }
        }

        private void filtroViagem()
        {
            temporario = new List<string>();
            bool passou;

            for (int i = 0; i < selecionadas.Count; i++)
            {
                passou = false;

                for (int j = 0; j < viagemSelecionar.Count; j++)
                {
                    if (selecionadas.ElementAt(i) == viagemSelecionar.ElementAt(j))
                    {
                        passou = true;
                        break;
                    }
                }
                if (passou)
                {
                    temporario.Add(selecionadas.ElementAt(i));
                }
            }

            selecionadas.Clear();
            if (temporario.Count > 0)
            {
                selecionadas = temporario;
            }
        }

        private void filtroConf()
        {
            temporario = new List<string>();
            bool passou;

            for (int i = 0; i < selecionadas.Count; i++)
            {
                passou = false;

                for (int j = 0; j < confSelecionar.Count; j++)
                {
                    if (selecionadas.ElementAt(i) == confSelecionar.ElementAt(j))
                    {
                        passou = true;
                        break;
                    }
                }
                if (passou)
                {
                    temporario.Add(selecionadas.ElementAt(i));
                }
            }

            selecionadas.Clear();
            if (temporario.Count > 0)
            {
                selecionadas = temporario;
            }
        }

        private void filtroBolsa()
        {
            temporario = new List<string>();
            bool passou;

            for (int i = 0; i < selecionadas.Count; i++)
            {
                passou = false;

                for (int j = 0; j < bolsaSelecionar.Count; j++)
                {
                    if (selecionadas.ElementAt(i) == bolsaSelecionar.ElementAt(j))
                    {
                        passou = true;
                        break;
                    }
                }
                if (passou)
                {
                    temporario.Add(selecionadas.ElementAt(i));
                }
            }

            selecionadas.Clear();
            if (temporario.Count > 0)
            {
                selecionadas = temporario;
            }
        }

        private void cargo()
        {
            if (cargoSelecionar.Count > 0)
            {
                filtroCargo();
            }
            else if (txtCargo.Text != "")        //Cargo
            {
                selecionadas.Clear();
            }
        }

        private void area()
        {
            if (areaSelecionar.Count > 0)
            {
                filtroArea();
            }
            else if (txtArea.Text != "")        //Area teste de preenchimento não encontrado
            {
                selecionadas.Clear();
            }
        }

        private void empresa()
        {

            if (empresaSelecionar.Count > 0)
            {
                filtroEmpresa();
            }
            else if (txtEmpresa.Text != "")     //Empresa teste de preenchimento não encontrado
            {
                selecionadas.Clear();
            }
        }

        private void salario()
        {
            if (salarioSelecionar.Count > 0)
            {
                filtroEmpresa();
            }
            else if (txtSalario.Text != "")   //Salario teste de preenchimento não encontrado
            {
                selecionadas.Clear();
            }
        }

        private void saude()
        {
            if (saudeSelecionar.Count > 0)
            {
                filtroSaude();
            }
            else if (saudeSelect == true)     //Ben - Saude teste de preenchimento não encontrado
            {
                selecionadas.Clear();
            }
        }

        private void odon()
        {
            if (odonSelecionar.Count > 0)
            {
                filtroOdon();
            }
            else if (odonSelect == true)     //Ben - Odon teste de preenchimento não encontrado
            {
                selecionadas.Clear();
            }
        }

        private void alim()
        {
            if (alimSelecionar.Count > 0)
            {
                filtroAlim();
            }
            else if (alimSelect == true)     //Ben - Alim teste de preenchimento não encontrado
            {
                selecionadas.Clear();
            }
        }

        private void cultura()
        {
            if (culturaSelecionar.Count > 0)
            {
                filtroCultura();
            }
            else if (culturaSelect == true)     //Ben - Cultura teste de preenchimento não encontrado
            {
                selecionadas.Clear();
            }
        }

        private void home()
        {
            if (homeSelecionar.Count > 0)
            {
                filtroHome();
            }
            else if (homeSelect == true)     //Ben - Home teste de preenchimento não encontrado
            {
                selecionadas.Clear();
            }
        }

        private void viagem()
        {
            if (viagemSelecionar.Count > 0)
            {
                filtroViagem();
            }
            else if (viagemSelect == true)     //Ben - Viagem teste de preenchimento não encontrado
            {
                selecionadas.Clear();
            }
        }

        private void conf()
        {
            if (confSelecionar.Count > 0)
            {
                filtroConf();
            }
            else if (conferenciaSelect == true)     //Ben - Conferecia teste de preenchimento não encontrado
            {
                selecionadas.Clear();
            }
        }

        private void bolsa()
        {
            if (bolsaSelecionar.Count > 0)
            {
                filtroBolsa();
            }
            else if (bolsaSelect == true)     //Ben - Bolsa teste de preenchimento não encontrado
            {
                selecionadas.Clear();
            }
        }

        private void testarFiltro()
        {
            if (cargoSelecionar.Count > 0)
            {
                selecionadas = cargoSelecionar;
            }
            else if (areaSelecionar.Count > 0)
            {
                selecionadas = areaSelecionar;
            }
            else if (salarioSelecionar.Count > 0)
            {
                selecionadas = salarioSelecionar;    //Pega alguma lista inicial para verificação posterior 
            }
            else if (empresaSelecionar.Count > 0)
            {
                selecionadas = empresaSelecionar;
            }
            else if (saudeSelecionar.Count > 0)
            {
                selecionadas = saudeSelecionar;
            }
            else if (odonSelecionar.Count > 0)
            {
                selecionadas = odonSelecionar;
            }
            else if (alimSelecionar.Count > 0)
            {
                selecionadas = alimSelecionar;
            }
            else if (culturaSelecionar.Count > 0)
            {
                selecionadas = culturaSelecionar;
            }
            else if (homeSelecionar.Count > 0)
            {
                selecionadas = homeSelecionar;
            }
            else if (viagemSelecionar.Count > 0)
            {
                selecionadas = viagemSelecionar;
            }
            else if (confSelecionar.Count > 0)
            {
                selecionadas = confSelecionar;
            }
            else if (bolsaSelecionar.Count > 0)
            {
                selecionadas = bolsaSelecionar;
            }

            if (cargoSelecionar.Count > 0)
            {
                area();
                salario();
                empresa();

                saude();
                odon();
                alim();
                cultura();
                home();
                viagem();
                conf();
                bolsa();
            }
            else if (areaSelecionar.Count > 0)
            {
                cargo();
                salario();
                empresa();

                saude();
                odon();
                alim();
                cultura();
                home();
                viagem();
                conf();
                bolsa();
            }
            else if (salarioSelecionar.Count > 0)
            {
                cargo();
                area();
                empresa();

                saude();
                odon();
                alim();
                cultura();
                home();
                viagem();
                conf();
                bolsa();
            }
            else if (empresaSelecionar.Count > 0)                              //Verificação de todos os campos
            {
                cargo();
                area();
                salario();

                saude();
                odon();
                alim();
                cultura();
                home();
                viagem();
                conf();
                bolsa();
            }
            else if (saudeSelecionar.Count > 0)
            {
                cargo();
                area();
                salario();
                empresa();

                odon();
                alim();
                cultura();
                home();
                viagem();
                conf();
                bolsa();
            }
            else if (odonSelecionar.Count > 0)
            {
                cargo();
                area();
                salario();
                empresa();

                saude();
                alim();
                cultura();
                home();
                viagem();
                conf();
                bolsa();
            }
            else if (alimSelecionar.Count > 0)
            {
                cargo();
                area();
                salario();
                empresa();

                saude();
                odon();
                cultura();
                home();
                viagem();
                conf();
                bolsa();
            }
            else if (culturaSelecionar.Count > 0)
            {
                cargo();
                area();
                salario();
                empresa();

                saude();
                odon();
                alim();
                home();
                viagem();
                conf();
                bolsa();
            }
            else if (homeSelecionar.Count > 0)
            {
                cargo();
                area();
                salario();
                empresa();

                saude();
                odon();
                alim();
                cultura();
                viagem();
                conf();
                bolsa();
            }
            else if (viagemSelecionar.Count > 0)
            {
                cargo();
                area();
                salario();
                empresa();

                saude();
                odon();
                alim();
                cultura();
                home();
                conf();
                bolsa();
            }
            else if (confSelecionar.Count > 0)
            {
                cargo();
                area();
                salario();
                empresa();

                saude();
                odon();
                alim();
                cultura();
                home();
                viagem();
                bolsa();
            }
            else if (bolsaSelecionar.Count > 0)
            {
                cargo();
                area();
                salario();
                empresa();

                saude();
                odon();
                alim();
                cultura();
                home();
                viagem();
                conf();
            }
        }

        private void txtPesquisa_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Back && txtPesquisa.TextLength > 0)
            {
                try
                {
                    bool passou = false;

                    int max = bd.usuario.Max(x => x.idUsuario);           //Busca as empresas digitadas na barra de pesquisa

                    var dt1 = new DataTable();

                    dt1.Columns.Add("CNPJ_Empresa");
                    dt1.Columns.Add("nomeEmpresa");
                    dt1.Columns.Add("areaEmpresa");               //Cria as Colunas

                    for (int i = 0; i <= max; i++)
                    {
                        var usuario = bd.usuario.Where(x => x.nomeUsuario.Contains(txtPesquisa.Text)).Where(x => x.idUsuario == i).FirstOrDefault();

                        if (usuario != null)
                        {
                            var empresa = bd.usuario_empresa.Where(x => x.FK_usuario == usuario.idUsuario).FirstOrDefault();

                            if (empresa != null)
                            {
                                passou = true;
                                dt1.Rows.Add(empresa.cnpj, usuario.nomeUsuario, empresa.areaEmpresa);
                            }
                        }
                    }

                    if (passou)
                    {
                        dtPesquisa.DataSource = dt1; //Conecta com o GridView

                        this.dtPesquisa.Columns["CNPJ_Empresa"].Visible = false;  //Tira as que não precisa

                        pnPesquisa.Visible = true;
                        pn_cabecalhoPesquisa.Visible = true;
                        dtPesquisa.Visible = true;
                        lblNaoEncontrado.Visible = false;
                    }
                    else
                    {
                        pn_cabecalhoPesquisa.Visible = false;
                        lblNaoEncontrado.Visible = true;
                        pnPesquisa.Visible = true;
                        dtPesquisa.Visible = false;

                    }
                }
                catch (Exception)
                {
                    pn_cabecalhoPesquisa.Visible = false;
                    lblNaoEncontrado.Visible = true;
                    pnPesquisa.Visible = true;
                    dtPesquisa.Visible = false;
                }
                txtPesquisa.Focus();
            }
        }

        private void panelPrincipal_Click(object sender, EventArgs e)
        {
            if (pnMenu.Visible == true || pnFiltro.Visible == true)
            {
                pnMenu.Visible = false;
                visibilidadeMenuFalse();
                visibilidadeFiltroFalse();
            }

            if (!TesteTutorial.instrucao)
            {
                finalTutorial();
            }
        }

        private void txtPesquisa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                if (txtPesquisa.TextLength > 1)
                {
                    try
                    {
                        bool passou = false;

                        int max = bd.usuario.Max(x => x.idUsuario);

                        var dt1 = new DataTable();

                        dt1.Columns.Add("CNPJ_Empresa");
                        dt1.Columns.Add("nomeEmpresa");
                        dt1.Columns.Add("areaEmpresa");               //Cria as Colunas

                        for (int i = 0; i <= max; i++)
                        {
                            string sTxt = txtPesquisa.Text;
                            int qtd = txtPesquisa.TextLength;

                            var usuario = bd.usuario.Where(x => x.nomeUsuario.Contains(sTxt.Remove(qtd - 1)))
                            .Where(x => x.idUsuario == i).FirstOrDefault();

                            if (usuario != null)
                            {
                                var empresa = bd.usuario_empresa.Where(x => x.FK_usuario == usuario.idUsuario).FirstOrDefault();

                                if (empresa != null)
                                {
                                    passou = true;
                                    dt1.Rows.Add(empresa.cnpj, usuario.nomeUsuario, empresa.areaEmpresa);
                                }
                            }
                        }

                        if (passou)
                        {
                            dtPesquisa.DataSource = dt1; //Conecta com o GridView

                            this.dtPesquisa.Columns["CNPJ_Empresa"].Visible = false;  //Tira as que não precisa

                            pnPesquisa.Visible = true;
                            pn_cabecalhoPesquisa.Visible = true;
                            dtPesquisa.Visible = true;
                            lblNaoEncontrado.Visible = false;
                        }
                        else
                        {
                            pn_cabecalhoPesquisa.Visible = false;
                            lblNaoEncontrado.Visible = true;
                            pnPesquisa.Visible = true;
                            dtPesquisa.Visible = false;
                        }
                    }
                    catch (Exception)
                    {
                        pn_cabecalhoPesquisa.Visible = false;
                        lblNaoEncontrado.Visible = true;
                        pnPesquisa.Visible = true;
                        dtPesquisa.Visible = false;
                    }
                }
                else
                {
                    pnPesquisa.Visible = false;
                }
                txtPesquisa.Focus();
            }
        }

        private void dtPesquisa_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string sTeste = Convert.ToString(dtPesquisa.CurrentRow.Cells[0].Value);
                var usuario_empresa = bd.usuario_empresa.Where(x => x.cnpj == sTeste).FirstOrDefault();
                var usuario = bd.usuario.Where(x => x.idUsuario == usuario_empresa.FK_usuario).FirstOrDefault();   //Barra de pesquisa 

                if (usuario != null)
                {
                    PegarIDEmpresa.IDEmpresa = usuario.idUsuario;
                }

                this.Hide();
                TelaVisualizacaoPerfilEmpresa f = new TelaVisualizacaoPerfilEmpresa();
                f.Closed += (s, args) => this.Close();
                f.ShowDialog();
            }
            catch (Exception)
            {
                Mensagem.aviso = "Erro de conexão com o banco";    //Verificação de erro
                TelaMensagemAviso f = new TelaMensagemAviso();
                f.ShowDialog();
            }
        }

        private void TelaPrincipalTrabalhador_Click(object sender, EventArgs e)
        {
            if (pnMenu.Visible == true || pnFiltro.Visible == true)
            {
                pnMenu.Visible = false;
                visibilidadeMenuFalse();
                visibilidadeFiltroFalse();
            }

            if (!TesteTutorial.instrucao)
            {
                finalTutorial();
            }
        }

        public void finalTutorial()
        {
            if (!TesteTutorial.instrucao)
            {
                if (pbTutorial3.Visible == true)
                {
                    pbTutorial3.Visible = false;
                    pbBemVindo.Visible = false;
                    lblBemvindo.Visible = false;
                    pbTutorial4.Visible = true;
                }
                else if (pbTutorial4.Visible == true)        //Troca de tutoriais finais 
                {
                    pbTutorial4.Visible = false;
                    pbTutorialCompleto.Visible = true;
                }
                else if (pbTutorialCompleto.Visible == true)
                {
                    pbTutorialCompleto.Visible = false;
                    desbloquearComandos();
                    TesteTutorial.instrucao = true;

                    this.Hide();
                    TelaPrincipalTrabalhador f = new TelaPrincipalTrabalhador();
                    f.Closed += (s, args) => this.Close();
                    f.ShowDialog();
                }
            }
        }

        private void TelaPrincipalTrabalhador_Paint(object sender, PaintEventArgs e)
        {
            int x = (this.Size.Width - lblAvisoLocalizacao.Width) / 2;
            int y = (this.Size.Height - lblAvisoLocalizacao.Height) / 2;              //Posição da label na barra

            lblAvisoLocalizacao.Location = new Point(x, y);
        }

        private void TelaPrincipalTrabalhador_Resize(object sender, EventArgs e)
        {
            int x = (this.Size.Width - lblAvisoLocalizacao.Width) / 2;
            int y = (this.Size.Height - lblAvisoLocalizacao.Height) / 2;

            lblAvisoLocalizacao.Location = new Point(x, y);
        }

        private void pbChat_Click(object sender, EventArgs e)
        {
            if (!bloqChat)
            {
                this.Hide();
                TelaMensagemTrabalhador f = new TelaMensagemTrabalhador();
                f.Closed += (s, args) => this.Close();
                f.ShowDialog();
            }

            if (!TesteTutorial.instrucao)
            {
                finalTutorial();
            }
        }

        private void pbChat_MouseEnter(object sender, EventArgs e)       //esse é o novo 
        {
            pbMensagem.Image = Properties.Resources.chatRoxo1;
        }

        private void pbChat_MouseLeave(object sender, EventArgs e)
        {
            pbMensagem.Image = Properties.Resources.chatAzul;
        }

        private void pbAbMenu_MouseEnter(object sender, EventArgs e)
        {
            pbAbMenu.Image = Properties.Resources.menuRoxo11;
        }

        private void pbAbMenu_MouseLeave(object sender, EventArgs e)
        {
            pbAbMenu.Image = Properties.Resources.menu5;
        }

        private void pbPesquisar_Click(object sender, EventArgs e)
        {
            if (!TesteTutorial.instrucao)
            {
                finalTutorial();
            }
        }

        private void pbTutorialCompleto_Click(object sender, EventArgs e)  //Fecha tutorial
        {
            if (!TesteTutorial.instrucao)
            {
                finalTutorial();
            }
        }

        private void pbCriar_MouseEnter(object sender, EventArgs e)
        {
            pbCriar.Image = Properties.Resources.FiltroRoxo;
        }

        private void pbCriar_MouseLeave(object sender, EventArgs e)
        {
            pbCriar.Image = Properties.Resources.Filtro;
        }

        private void txtSalario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                txtSalario.Clear();             //Limpar campo 
            }
            else if (e.KeyCode == Keys.Back)
            {
                txtSalario.Clear();
            }
        }

        private void txtSalario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8) { e.Handled = true; }

            if (char.IsNumber(e.KeyChar) == true)
            {
                switch (txtSalario.TextLength)
                {
                    case 0:                                                                //Máscara de salário
                        txtSalario.Text = "R$:" + txtSalario.Text + ",00";
                        txtSalario.SelectionStart = 3;
                        break;

                    case 7:
                        txtSalario.SelectionStart = 4;
                        break;

                    case 8:
                        txtSalario.SelectionStart = 5;
                        break;

                    case 9:
                        txtSalario.Text = txtSalario.Text.Insert(4, ".");
                        txtSalario.SelectionStart = 7;
                        break;

                    case 11:
                        txtSalario.Text = txtSalario.Text.Remove(4, 1);
                        txtSalario.Text = txtSalario.Text.Insert(5, ".");
                        txtSalario.Text = txtSalario.Text.Remove(8, 3);
                        txtSalario.Text = txtSalario.Text + ",00";
                        txtSalario.SelectionStart = 8;
                        break;

                    case 12:
                        txtSalario.Text = txtSalario.Text.Remove(5, 1);
                        txtSalario.Text = txtSalario.Text.Insert(6, ".");
                        txtSalario.Text = txtSalario.Text.Remove(9, 3);
                        txtSalario.Text = txtSalario.Text + ",00";
                        txtSalario.SelectionStart = 9;
                        break;

                    case 13:
                        txtSalario.Text = txtSalario.Text.Insert(4, ".");
                        txtSalario.Text = txtSalario.Text.Remove(7, 1);
                        txtSalario.Text = txtSalario.Text.Insert(8, ".");
                        txtSalario.Text = txtSalario.Text.Remove(11, 3);
                        txtSalario.Text = txtSalario.Text + ",00";
                        txtSalario.SelectionStart = 11;
                        break;
                }
            }
        }
    }
}

