using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Pismire_TCC.Resources;

namespace Pismire_TCC
{
    public partial class TelaVisualizacaoCurriculo : Form
    {
        PismireEntities5 bd = new PismireEntities5();

        int idSelecionado = Pesquisa.ID;  //ID usuario selecionado para visualizacao

        bool vira3 = false;
        bool vira = false;          //Propriedades
        bool vira2 = false;
        bool vira4 = false;
        bool vira5 = false;
        bool testeAviso1 = false;
        bool testeAviso2 = false;
        bool testeAviso3 = false;
        bool testeAviso4 = false;
        bool testeAviso5 = false;

        public TelaVisualizacaoCurriculo()
        {
            InitializeComponent();
            PegarID.visualizar = true;

            if (!TesteTutorial.entrou)
            {
               pbTutorial2.Visible = true;
            }
            else
            {
                pbTutorial2.Visible = false;
            }

            pnIdioma.BorderStyle = BorderStyle.FixedSingle;
            pnCabecalhoIdioma.BorderStyle = BorderStyle.FixedSingle;

            pnQualificacoes.BorderStyle = BorderStyle.FixedSingle;
            pnCabecalhoQualificacao.BorderStyle = BorderStyle.FixedSingle; //Bordas padrão

            pnExperiencia.BorderStyle = BorderStyle.FixedSingle;
            pnCabecalhoExpProf.BorderStyle = BorderStyle.FixedSingle;

            pnExpInt.BorderStyle = BorderStyle.FixedSingle;
            pnCabecalhoExpInt.BorderStyle = BorderStyle.FixedSingle;

            pnTrabVol.BorderStyle = BorderStyle.FixedSingle;
            pnCabecalhoTrabVol.BorderStyle = BorderStyle.FixedSingle;

            Maximizacao.verifique(this, pbMaximizar);   //Verifica se a tela está maximizada ou não

            try
            {

                var usuario = bd.usuario.Where(x => x.idUsuario == UsuarioDados.Id).FirstOrDefault();
                if (usuario.tipoUsuario == false)
                {
                    pbEditarCurriculo.Visible = false;
                    carregarInformacoes();
                    padraoBotoes();
                }
                else
                {
                    pbEditarCurriculo.Visible = true;
                    pbTutorial2.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    PegarID.ID = UsuarioDados.Id;
                    var usu_trab = bd.usuario_trabalhador.Where(x => x.FK_usuario == UsuarioDados.Id).FirstOrDefault();

                    if (usu_trab != null)
                    {
                        var usuario_trabalhador = bd.curriculo.Where(x => x.FK_usuario_trabalhador == usu_trab.CPF).FirstOrDefault();

                        if (usuario_trabalhador != null)
                        {
                            CarregarInformacoesTrabalhador();
                            padraoBotoes();
                            pbChat.Visible = false;
                            btInteressado.Visible = false;
                        }
                        else
                        {
                            rpbFoto.Visible = false;
                            pnPGs.Visible = false;
                            pnAviso.Visible = true;
                            pnPag1.Visible = false;
                            pnPag2.Visible = false;
                            pnPag3.Visible = false;
                            pnPag4.Visible = false;
                            pbChat.Visible = false;
                            btInteressado.Visible = false;
                        }
                    }
                    else
                    {
                        rpbFoto.Visible = false;
                        pnPGs.Visible = false;
                        pnAviso.Visible = true;
                        pnPag1.Visible = false;
                        pnPag2.Visible = false;
                        pnPag3.Visible = false;
                        pnPag4.Visible = false;
                        pbChat.Visible = false;
                        btInteressado.Visible = false;
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

        private void CarregarInformacoesTrabalhador()
        {
            try
            {
                var usuario = bd.usuario.Where(x => x.idUsuario == UsuarioDados.Id).FirstOrDefault();
                var trabalhador = bd.usuario_trabalhador.Where(x => x.FK_usuario == UsuarioDados.Id).FirstOrDefault();
                var curriculo = bd.curriculo.Where(x => x.FK_usuario_trabalhador == trabalhador.CPF).FirstOrDefault();

                lblNomeAdicionar.Text = usuario.nomeUsuario;
                lblDataAdicionar.Text = Convert.ToString(trabalhador.dataNascimento.ToShortDateString());
                lblTelefoneAdicionar.Text = usuario.telefoneUsuario;
                lblRGAdicionar.Text = trabalhador.RG;
                lblCelularAdicionar.Text = curriculo.celularTrabalhador;
                lblEstadoCivilAdicionar.Text = curriculo.estadoCivil;
                lblCPFAdicionar.Text = trabalhador.CPF;                         //Carregamento da primeira tela 
                lblGeneroAdicionar.Text = curriculo.generoTrabalhador;
                lblEmailAdicionar.Text = usuario.e_mailUsuario;

                if (curriculo.deficienciaFisica == true)
                {
                    lblDeficienciaAdicionar.Text = "Possui deficiência física";
                }

                if (curriculo.fotoUsuario != null)
                {
                    byte[] ImageSource = curriculo.fotoUsuario;
                    using (MemoryStream stream = new MemoryStream(ImageSource))
                    {
                        rpbFoto.Image = new Bitmap(stream);
                    }
                }

                //----

                lblRuaAdicionar.Text = curriculo.ruaTrabalhador;
                lblNumeroAdicionar.Text = curriculo.numeroTrabalhador;
                lblBairroAdicionar.Text = curriculo.bairroTrabalhador;
                lblCidadeAdicionar.Text = curriculo.cidadeTrabalhador;
                lblEstadoAdicionar.Text = curriculo.estadoTrabalhador;              //Carregamento da segunda tela 
                lblNacionalidadeAdicionar.Text = curriculo.nacionalidade;
                lblCEPAdicionar.Text = curriculo.cepTrabalhador;

                lblAreaAdicionar.Text = curriculo.areaAtuacao;
                lblCargoAdicionar.Text = curriculo.cargoAtuacao;
                lblFacebookAdicionar.Text = curriculo.facebookTrabalhador;
                lblObjetivoAdicionar.Text = curriculo.objetivo;

                if (curriculo.situacaoAtual == true)
                {
                    lblFormAcademicaAdicionar.Text = curriculo.formacaoAcademica + " - Estudando atualmente";
                }
                else
                {
                    lblFormAcademicaAdicionar.Text = curriculo.formacaoAcademica + " - Concluído";
                }

                //----

                int qtd = Convert.ToInt32(bd.avaliacao.Count     //Número de avaliacoes
                (x => x.FK_curriculo == curriculo.idCurriculo));

                if (qtd != 0)                               //Verifica quantidade de ids
                {
                    try
                    {
                        int max = bd.avaliacao.Max(x => x.idAvaliacao);    //Maior ID

                        var dt1 = new DataTable();

                        dt1.Columns.Add("ID_Avaliacao");
                        dt1.Columns.Add("NomeEmpresa");              //Cria as Colunas

                        for (int i = 1; i <= max; i++)
                        {
                            var avaliacao = bd.avaliacao.Where(y => y.FK_curriculo ==
                            curriculo.idCurriculo).Where(x => x.idAvaliacao == i).FirstOrDefault();    //Carregar avaliações

                            if (avaliacao != null)
                            {
                                var empresa = bd.usuario_empresa.Where(x => x.cnpj == avaliacao.FK_usuario_empresa).FirstOrDefault();
                                var usuEmp = bd.usuario.Where(x => x.idUsuario == empresa.FK_usuario).FirstOrDefault();

                                dt1.Rows.Add(avaliacao.idAvaliacao, usuEmp.nomeUsuario);

                                dtAvaliacao.DataSource = dt1; //Conecta com o GridView

                                this.dtAvaliacao.Columns["ID_Avaliacao"].Visible = false; //Tira as que não precisa
                            }

                        }
                    }
                    catch (Exception)
                    {
                        Mensagem.aviso = "Erro ao se conectar com o banco!";
                        TelaMensagemAviso f = new TelaMensagemAviso();
                        f.ShowDialog();
                    }
                }
                else
                {
                    lblAviso.Visible = true;
                    dtAvaliacao.Visible = false;
                    pnCabecalhoAvaliacao.Visible = false;
                    lblNotas.Visible = false;
                    pbEstrela1.Visible = false;
                    pbEstrela2.Visible = false;
                    pbEstrela3.Visible = false;
                    pbEstrela4.Visible = false;
                    pbEstrela5.Visible = false;
                    lblComentarioAdicionar.Visible = false;
                }

                //--

                int qtdIdioma = Convert.ToInt32(bd.idioma_trabalhador.Count     //Número de idiomas
                (x => x.FK_curriculo == curriculo.idCurriculo));

                if (qtdIdioma != 0)                               //Verifica quantidade de ids
                {
                    try
                    {
                        int max = bd.idioma_trabalhador.Max(x => x.idIdiomaTrabalhador);    //Maior ID

                        var dt1 = new DataTable();

                        dt1.Columns.Add("ID_Idioma");
                        dt1.Columns.Add("idioma");
                        dt1.Columns.Add("nivel");              //Cria as Colunas

                        for (int i = 1; i <= max; i++)
                        {
                            var idioma = bd.idioma_trabalhador.Where(y => y.FK_curriculo ==
                            curriculo.idCurriculo).Where(x => x.idIdiomaTrabalhador == i).FirstOrDefault();

                            //Carregar idioma

                            if (idioma != null)
                            {
                                dt1.Rows.Add(idioma.idIdiomaTrabalhador, idioma.linguaTrabalhador,
                                idioma.nivelTrabalhador);

                                dtIdioma.DataSource = dt1; //Conecta com o GridView

                                this.dtIdioma.Columns["ID_Idioma"].Visible = false; //Tira as que não precisa
                            }
                        }
                    }
                    catch (Exception)
                    {
                        Mensagem.aviso = "Erro ao se conectar com o banco!";
                        TelaMensagemAviso f = new TelaMensagemAviso();
                        f.ShowDialog();
                    }
                }
                else
                {
                    testeAviso1 = true;
                }

                //--

                int qtdQualificacao = Convert.ToInt32(bd.qualificacao_trabalhador.Count     //Número de idiomas
                (x => x.FK_curriculo == curriculo.idCurriculo));

                if (qtdQualificacao != 0)                               //Verifica quantidade de ids
                {
                    try
                    {
                        int max = bd.qualificacao_trabalhador.Max(x => x.idQualificacaoTrabalhador);    //Maior ID

                        var dt1 = new DataTable();

                        dt1.Columns.Add("ID_Qualificacao");
                        dt1.Columns.Add("nome");
                        dt1.Columns.Add("tipo");              //Cria as Colunas

                        for (int i = 1; i <= max; i++)
                        {
                            var qualificacao = bd.qualificacao_trabalhador.Where(y => y.FK_curriculo ==
                            curriculo.idCurriculo).Where(x => x.idQualificacaoTrabalhador == i).FirstOrDefault();

                            //Carregar idioma

                            if (qualificacao != null)
                            {
                                dt1.Rows.Add(qualificacao.idQualificacaoTrabalhador,
                                qualificacao.nomeQualificacaoTrabalhador,
                                qualificacao.tipoQualificacaoTrabalhador);

                                dtQualificacoes.DataSource = dt1; //Conecta com o GridView

                                this.dtQualificacoes.Columns["ID_Qualificacao"].Visible = false; //Tira as que não precisa
                            }
                        }
                    }
                    catch (Exception)
                    {
                        Mensagem.aviso = "Erro ao se conectar com o banco!";
                        TelaMensagemAviso f = new TelaMensagemAviso();
                        f.ShowDialog();
                    }
                }
                else
                {
                    testeAviso3 = true;
                }

                //--

                int qtdExpProf = Convert.ToInt32(bd.experiencia_profissional_trabalhador.Count     //Número de idiomas
                (x => x.FK_curriculo == curriculo.idCurriculo));

                if (qtdExpProf != 0)                               //Verifica quantidade de ids
                {
                    try
                    {
                        int max = bd.experiencia_profissional_trabalhador.Max(x => x.idExperienciaTrabalhador);    //Maior ID

                        var dt1 = new DataTable();

                        dt1.Columns.Add("ID_ExpProf");
                        dt1.Columns.Add("cargo");
                        dt1.Columns.Add("empresa");              //Cria as Colunas

                        for (int i = 1; i <= max; i++)
                        {
                            var expProf = bd.experiencia_profissional_trabalhador.Where(y => y.FK_curriculo ==
                            curriculo.idCurriculo).Where(x => x.idExperienciaTrabalhador == i).FirstOrDefault();

                            //Carregar idioma

                            if (expProf != null)
                            {
                                dt1.Rows.Add(expProf.idExperienciaTrabalhador,
                                expProf.cargoExperienciaTrabalhador,
                                expProf.nomeEmpresaExperienciaTrabalhador);

                                dtExpProf.DataSource = dt1; //Conecta com o GridView

                                this.dtExpProf.Columns["ID_ExpProf"].Visible = false; //Tira as que não precisa
                            }
                        }
                    }
                    catch (Exception)
                    {
                        Mensagem.aviso = "Erro ao se conectar com o banco!";
                        TelaMensagemAviso f = new TelaMensagemAviso();
                        f.ShowDialog();
                    }
                }
                else
                {
                    testeAviso2 = true;
                }

                //--

                int qtdExpInt = Convert.ToInt32(bd.experiencia_internacional_trabalhador.Count     //Número de idiomas
                (x => x.FK_curriculo == curriculo.idCurriculo));

                if (qtdExpInt != 0)                               //Verifica quantidade de ids
                {
                    try
                    {
                        int max = bd.experiencia_internacional_trabalhador.Max(x => x.idInternacionalTrabalhador);    //Maior ID

                        var dt1 = new DataTable();

                        dt1.Columns.Add("ID_ExpInt");
                        dt1.Columns.Add("cargo");
                        dt1.Columns.Add("empresa");              //Cria as Colunas

                        for (int i = 1; i <= max; i++)
                        {
                            var expInt = bd.experiencia_internacional_trabalhador.Where(y => y.FK_curriculo ==
                            curriculo.idCurriculo).Where(x => x.idInternacionalTrabalhador == i).FirstOrDefault();

                            //Carregar idioma

                            if (expInt != null)
                            {
                                dt1.Rows.Add(expInt.idInternacionalTrabalhador,
                                expInt.cargoInternacionalTrabalhador,
                                expInt.nomeEmpresaInternacionalTrabalhador);

                                dtExpInt.DataSource = dt1; //Conecta com o GridView

                                this.dtExpInt.Columns["ID_ExpInt"].Visible = false; //Tira as que não precisa
                            }
                        }
                    }
                    catch (Exception)
                    {
                        Mensagem.aviso = "Erro ao se conectar com o banco!";
                        TelaMensagemAviso f = new TelaMensagemAviso();
                        f.ShowDialog();
                    }
                }
                else
                {
                    testeAviso4 = true;
                }

                //---

                int qtdTrabVol = Convert.ToInt32(bd.trabalho_voluntario_trabalhador.Count     //Número de idiomas
                    (x => x.FK_curriculo == curriculo.idCurriculo));

                if (qtdTrabVol != 0)                               //Verifica quantidade de ids
                {
                    try
                    {
                        int max = bd.trabalho_voluntario_trabalhador.Max(x => x.idVoluntarioTrabalhador);    //Maior ID

                        var dt1 = new DataTable();

                        dt1.Columns.Add("ID_TrabVol");
                        dt1.Columns.Add("instituicao");
                        dt1.Columns.Add("responsavel");              //Cria as Colunas

                        for (int i = 1; i <= max; i++)
                        {
                            var expInt = bd.trabalho_voluntario_trabalhador.Where(y => y.FK_curriculo ==
                            curriculo.idCurriculo).Where(x => x.idVoluntarioTrabalhador == i).FirstOrDefault();

                            //Carregar trab vol

                            if (expInt != null)
                            {
                                dt1.Rows.Add(expInt.idVoluntarioTrabalhador,
                                expInt.instituicaoVoluntarioTrabalhador,
                                expInt.responsavelVoluntarioTrabalhador);

                                dtTrabalhoVoluntario.DataSource = dt1; //Conecta com o GridView

                                this.dtTrabalhoVoluntario.Columns["ID_TrabVol"].Visible = false; //Tira as que não precisa
                            }
                        }
                    }
                    catch (Exception)
                    {
                        Mensagem.aviso = "Erro ao se conectar com o banco!";
                        TelaMensagemAviso f = new TelaMensagemAviso();
                        f.ShowDialog();
                    }
                }
                else
                {
                    testeAviso5 = true;
                }
            }
            catch (Exception)
            {
                Mensagem.aviso = "Erro ao se conectar com o banco!";
                TelaMensagemAviso f = new TelaMensagemAviso();
                f.ShowDialog();
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

            if (vira3 == true)
            {
                pbSetaQualificacoes.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                pbSetaQualificacoes.Refresh();
                vira3 = false;
            }

            if (vira2 == true)
            {
                pbSetaExpProf.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                pbSetaExpProf.Refresh();
                vira2 = false;
            }

            if (vira4 == true)
            {
                pbSetaExpInt.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                pbSetaExpInt.Refresh();
                vira4 = false;
            }

            if (vira5 == true)
            {
                pbSetaTrabVol.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                pbSetaTrabVol.Refresh();
                vira5 = false;
            }
        }

        private void padraoBotoes()
        {
            pnVisuIdiomas.Location = new Point(938, 70);
            pnVisulQualificacao.Location = new Point(938, 99);
            pnVisulExpProf.Location = new Point(938, 128);        //PnVisul
            pnVisulExpInt.Location = new Point(938, 156);
            pnVisulTrabVol.Location = new Point(938, 184);

            pnCabecalhoIdioma.Location = new Point(938, 100);
            pnCabecalhoQualificacao.Location = new Point(938, 129);
            pnCabecalhoExpProf.Location = new Point(938, 157);            //PnCabecalho
            pnCabecalhoExpInt.Location = new Point(938, 185);
            pnCabecalhoTrabVol.Location = new Point(938, 213);

            pnIdioma.Location = new Point(938, 133);
            pnQualificacoes.Location = new Point(938, 162);
            pnExperiencia.Location = new Point(938, 189);
            pnExpInt.Location = new Point(938, 218);         //Localização inicial dos paineis 
            pnTrabVol.Location = new Point(938, 246);

            pnIdioma.Visible = false;
            pnQualificacoes.Visible = false;
            pnExperiencia.Visible = false;
            pnExpInt.Visible = false;
            pnTrabVol.Visible = false;

            pnCabecalhoIdioma.Visible = false;
            pnCabecalhoQualificacao.Visible = false;
            pnCabecalhoExpProf.Visible = false;
            pnCabecalhoExpInt.Visible = false;
            pnCabecalhoTrabVol.Visible = false;
        }

        private void carregarInformacoes()
        {
            try
            {
                var curriculo = bd.curriculo.Where(x => x.idCurriculo == idSelecionado).FirstOrDefault();
                var trabalhador = bd.usuario_trabalhador.Where(x => x.CPF == curriculo.FK_usuario_trabalhador).FirstOrDefault();
                var usuario = bd.usuario.Where(x => x.idUsuario == trabalhador.FK_usuario).FirstOrDefault();
                PegarID.ID = usuario.idUsuario;

                lblNomeAdicionar.Text = usuario.nomeUsuario;
                lblDataAdicionar.Text = Convert.ToString(trabalhador.dataNascimento.ToShortDateString());
                lblTelefoneAdicionar.Text = usuario.telefoneUsuario;
                lblRGAdicionar.Text = trabalhador.RG;
                lblCelularAdicionar.Text = curriculo.celularTrabalhador;
                lblEstadoCivilAdicionar.Text = curriculo.estadoCivil;
                lblCPFAdicionar.Text = trabalhador.CPF;                         //Carregamento da primeira tela 
                lblGeneroAdicionar.Text = curriculo.generoTrabalhador;
                lblEmailAdicionar.Text = usuario.e_mailUsuario;

                if (curriculo.deficienciaFisica == true)
                {
                    lblDeficienciaAdicionar.Text = "Possui deficiência física";
                }

                if (curriculo.fotoUsuario != null)
                {
                    byte[] ImageSource = curriculo.fotoUsuario;
                    using (MemoryStream stream = new MemoryStream(ImageSource))
                    {
                        rpbFoto.Image = new Bitmap(stream);
                    }
                }

                //----

                lblRuaAdicionar.Text = curriculo.ruaTrabalhador;
                lblNumeroAdicionar.Text = curriculo.numeroTrabalhador;
                lblBairroAdicionar.Text = curriculo.bairroTrabalhador;
                lblCidadeAdicionar.Text = curriculo.cidadeTrabalhador;
                lblEstadoAdicionar.Text = curriculo.estadoTrabalhador;              //Carregamento da segunda tela 
                lblNacionalidadeAdicionar.Text = curriculo.nacionalidade;
                lblCEPAdicionar.Text = curriculo.cepTrabalhador;

                lblAreaAdicionar.Text = curriculo.areaAtuacao;
                lblCargoAdicionar.Text = curriculo.cargoAtuacao;
                lblFacebookAdicionar.Text = curriculo.facebookTrabalhador;
                lblObjetivoAdicionar.Text = curriculo.objetivo;

                if (curriculo.situacaoAtual == true)
                {
                    lblFormAcademicaAdicionar.Text = curriculo.formacaoAcademica + " - Estudando atualmente";
                }
                else
                {
                    lblFormAcademicaAdicionar.Text = curriculo.formacaoAcademica + " - Concluído";
                }

                //----

                int qtd = Convert.ToInt32(bd.avaliacao.Count     //Número de avaliacoes
                (x => x.FK_curriculo == curriculo.idCurriculo));

                if (qtd != 0)                               //Verifica quantidade de ids
                {
                    try
                    {
                        int max = bd.avaliacao.Max(x => x.idAvaliacao);    //Maior ID

                        var dt1 = new DataTable();

                        dt1.Columns.Add("ID_Avaliacao");
                        dt1.Columns.Add("NomeEmpresa");              //Cria as Colunas

                        for (int i = 1; i <= max; i++)
                        {
                            var avaliacao = bd.avaliacao.Where(y => y.FK_curriculo ==
                            curriculo.idCurriculo).Where(x => x.idAvaliacao == i).FirstOrDefault();    //Carregar avaliações

                            if (avaliacao != null)
                            {
                                var empresa = bd.usuario_empresa.Where(x => x.cnpj == avaliacao.FK_usuario_empresa).FirstOrDefault();
                                var usuEmp = bd.usuario.Where(x => x.idUsuario == empresa.FK_usuario).FirstOrDefault();

                                dt1.Rows.Add(avaliacao.idAvaliacao, usuEmp.nomeUsuario);

                                dtAvaliacao.DataSource = dt1; //Conecta com o GridView

                                this.dtAvaliacao.Columns["ID_Avaliacao"].Visible = false; //Tira as que não precisa
                            }

                        }
                    }
                    catch (Exception)
                    {
                        Mensagem.aviso = "Erro ao se conectar com o banco!";
                        TelaMensagemAviso f = new TelaMensagemAviso();
                        f.ShowDialog();
                    }
                }
                else
                {
                    lblAviso.Visible = true;
                    dtAvaliacao.Visible = false;
                    pnCabecalhoAvaliacao.Visible = false;
                    lblNotas.Visible = false;
                    pbEstrela1.Visible = false;
                    pbEstrela2.Visible = false;
                    pbEstrela3.Visible = false;
                    pbEstrela4.Visible = false;
                    pbEstrela5.Visible = false;
                    lblComentarioAdicionar.Visible = false;
                }

                //--

                int qtdIdioma = Convert.ToInt32(bd.idioma_trabalhador.Count     //Número de idiomas
                (x => x.FK_curriculo == curriculo.idCurriculo));

                if (qtdIdioma != 0)                               //Verifica quantidade de ids
                {
                    try
                    {
                        int max = bd.idioma_trabalhador.Max(x => x.idIdiomaTrabalhador);    //Maior ID

                        var dt1 = new DataTable();

                        dt1.Columns.Add("ID_Idioma");
                        dt1.Columns.Add("idioma");
                        dt1.Columns.Add("nivel");              //Cria as Colunas

                        for (int i = 1; i <= max; i++)
                        {
                            var idioma = bd.idioma_trabalhador.Where(y => y.FK_curriculo ==
                            curriculo.idCurriculo).Where(x => x.idIdiomaTrabalhador == i).FirstOrDefault();

                            //Carregar idioma

                            if (idioma != null)
                            {
                                dt1.Rows.Add(idioma.idIdiomaTrabalhador, idioma.linguaTrabalhador,
                                idioma.nivelTrabalhador);

                                dtIdioma.DataSource = dt1; //Conecta com o GridView

                                this.dtIdioma.Columns["ID_Idioma"].Visible = false; //Tira as que não precisa
                            }
                        }
                    }
                    catch (Exception)
                    {
                        Mensagem.aviso = "Erro ao se conectar com o banco!";
                        TelaMensagemAviso f = new TelaMensagemAviso();
                        f.ShowDialog();
                    }
                }
                else
                {
                    testeAviso1 = true;
                }

                //--

                int qtdQualificacao = Convert.ToInt32(bd.qualificacao_trabalhador.Count     //Número de idiomas
                (x => x.FK_curriculo == curriculo.idCurriculo));

                if (qtdQualificacao != 0)                               //Verifica quantidade de ids
                {
                    try
                    {
                        int max = bd.qualificacao_trabalhador.Max(x => x.idQualificacaoTrabalhador);    //Maior ID

                        var dt1 = new DataTable();

                        dt1.Columns.Add("ID_Qualificacao");
                        dt1.Columns.Add("nome");
                        dt1.Columns.Add("tipo");              //Cria as Colunas

                        for (int i = 1; i <= max; i++)
                        {
                            var qualificacao = bd.qualificacao_trabalhador.Where(y => y.FK_curriculo ==
                            curriculo.idCurriculo).Where(x => x.idQualificacaoTrabalhador == i).FirstOrDefault();

                            //Carregar idioma

                            if (qualificacao != null)
                            {
                                dt1.Rows.Add(qualificacao.idQualificacaoTrabalhador,
                                qualificacao.nomeQualificacaoTrabalhador,
                                qualificacao.tipoQualificacaoTrabalhador);

                                dtQualificacoes.DataSource = dt1; //Conecta com o GridView

                                this.dtQualificacoes.Columns["ID_Qualificacao"].Visible = false; //Tira as que não precisa
                            }
                        }
                    }
                    catch (Exception)
                    {
                        Mensagem.aviso = "Erro ao se conectar com o banco!";
                        TelaMensagemAviso f = new TelaMensagemAviso();
                        f.ShowDialog();
                    }
                }
                else
                {
                    testeAviso3 = true;
                }

                //--

                int qtdExpProf = Convert.ToInt32(bd.experiencia_profissional_trabalhador.Count     //Número de idiomas
                (x => x.FK_curriculo == curriculo.idCurriculo));

                if (qtdExpProf != 0)                               //Verifica quantidade de ids
                {
                    try
                    {
                        int max = bd.experiencia_profissional_trabalhador.Max(x => x.idExperienciaTrabalhador);    //Maior ID

                        var dt1 = new DataTable();

                        dt1.Columns.Add("ID_ExpProf");
                        dt1.Columns.Add("cargo");
                        dt1.Columns.Add("empresa");              //Cria as Colunas

                        for (int i = 1; i <= max; i++)
                        {
                            var expProf = bd.experiencia_profissional_trabalhador.Where(y => y.FK_curriculo ==
                            curriculo.idCurriculo).Where(x => x.idExperienciaTrabalhador == i).FirstOrDefault();

                            //Carregar idioma

                            if (expProf != null)
                            {
                                dt1.Rows.Add(expProf.idExperienciaTrabalhador,
                                expProf.cargoExperienciaTrabalhador,
                                expProf.nomeEmpresaExperienciaTrabalhador);

                                dtExpProf.DataSource = dt1; //Conecta com o GridView

                                this.dtExpProf.Columns["ID_ExpProf"].Visible = false; //Tira as que não precisa
                            }
                        }
                    }
                    catch (Exception)
                    {
                        Mensagem.aviso = "Erro ao se conectar com o banco!";
                        TelaMensagemAviso f = new TelaMensagemAviso();
                        f.ShowDialog();
                    }
                }
                else
                {
                    testeAviso2 = true;
                }

                //--

                int qtdExpInt = Convert.ToInt32(bd.experiencia_internacional_trabalhador.Count     //Número de idiomas
                (x => x.FK_curriculo == curriculo.idCurriculo));

                if (qtdExpInt != 0)                               //Verifica quantidade de ids
                {
                    try
                    {
                        int max = bd.experiencia_internacional_trabalhador.Max(x => x.idInternacionalTrabalhador);    //Maior ID

                        var dt1 = new DataTable();

                        dt1.Columns.Add("ID_ExpInt");
                        dt1.Columns.Add("cargo");
                        dt1.Columns.Add("empresa");              //Cria as Colunas

                        for (int i = 1; i <= max; i++)
                        {
                            var expInt = bd.experiencia_internacional_trabalhador.Where(y => y.FK_curriculo ==
                            curriculo.idCurriculo).Where(x => x.idInternacionalTrabalhador == i).FirstOrDefault();

                            //Carregar idioma

                            if (expInt != null)
                            {
                                dt1.Rows.Add(expInt.idInternacionalTrabalhador,
                                expInt.cargoInternacionalTrabalhador,
                                expInt.nomeEmpresaInternacionalTrabalhador);

                                dtExpInt.DataSource = dt1; //Conecta com o GridView

                                this.dtExpInt.Columns["ID_ExpInt"].Visible = false; //Tira as que não precisa
                            }
                        }
                    }
                    catch (Exception)
                    {
                        Mensagem.aviso = "Erro ao se conectar com o banco!";
                        TelaMensagemAviso f = new TelaMensagemAviso();
                        f.ShowDialog();
                    }
                }
                else
                {
                    testeAviso4 = true;
                }

                //---

                int qtdTrabVol = Convert.ToInt32(bd.trabalho_voluntario_trabalhador.Count     //Número de idiomas
                    (x => x.FK_curriculo == curriculo.idCurriculo));

                if (qtdTrabVol != 0)                               //Verifica quantidade de ids
                {
                    try
                    {
                        int max = bd.trabalho_voluntario_trabalhador.Max(x => x.idVoluntarioTrabalhador);    //Maior ID

                        var dt1 = new DataTable();

                        dt1.Columns.Add("ID_TrabVol");
                        dt1.Columns.Add("instituicao");
                        dt1.Columns.Add("responsavel");              //Cria as Colunas

                        for (int i = 1; i <= max; i++)
                        {
                            var expInt = bd.trabalho_voluntario_trabalhador.Where(y => y.FK_curriculo ==
                            curriculo.idCurriculo).Where(x => x.idVoluntarioTrabalhador == i).FirstOrDefault();

                            //Carregar trab vol

                            if (expInt != null)
                            {
                                dt1.Rows.Add(expInt.idVoluntarioTrabalhador,
                                expInt.instituicaoVoluntarioTrabalhador,
                                expInt.responsavelVoluntarioTrabalhador);

                                dtTrabalhoVoluntario.DataSource = dt1; //Conecta com o GridView

                                this.dtTrabalhoVoluntario.Columns["ID_TrabVol"].Visible = false; //Tira as que não precisa
                            }
                        }
                    }
                    catch (Exception)
                    {
                        Mensagem.aviso = "Erro ao se conectar com o banco!";
                        TelaMensagemAviso f = new TelaMensagemAviso();
                        f.ShowDialog();
                    }
                }
                else
                {
                    testeAviso5 = true;
                }
            }
            catch (Exception)
            {
                Mensagem.aviso = "Erro ao se conectar com o banco!";
                TelaMensagemAviso f = new TelaMensagemAviso();
                f.ShowDialog();
            }
        }

        private void pbPag2_Click(object sender, EventArgs e)
        {
            pnPag1.Visible = false;
            pnPag2.Visible = true;
            pnPag3.Visible = false;
            pnPag4.Visible = false;                                //Troca de tela pg 2             
            pbPag2.Image = Properties.Resources.Verificado_evento;
            pbPag3.Image = Properties.Resources._3_evento1;
            pbPag4.Image = Properties.Resources._4_evento1;
        }

        private void pbPag3_Click(object sender, EventArgs e)
        {
            pnPag1.Visible = false;
            pnPag2.Visible = false;
            pnPag3.Visible = true;
            pnPag4.Visible = false;
            pbPag2.Image = Properties.Resources.Verificado_evento;  //Troca de tela pg 3
            pbPag3.Image = Properties.Resources.Verificado_evento;
            pbPag4.Image = Properties.Resources._4_evento1;
        }

        private void pbPag4_Click(object sender, EventArgs e)
        {
            pnPag1.Visible = false;
            pnPag2.Visible = false;
            pnPag3.Visible = false;
            pnPag4.Visible = true;
            pbPag2.Image = Properties.Resources.Verificado_evento; //Troca de tela pg 4
            pbPag3.Image = Properties.Resources.Verificado_evento;
            pbPag4.Image = Properties.Resources.Verificado_evento;
        }

        private void pbPag1_Click(object sender, EventArgs e)
        {
            pnPag1.Visible = true;
            pnPag2.Visible = false;
            pnPag3.Visible = false;
            pnPag4.Visible = false;
            pbPag2.Image = Properties.Resources._2_evento1;       //Troca de tela pg 1
            pbPag3.Image = Properties.Resources._3_evento1;
            pbPag4.Image = Properties.Resources._4_evento1;
        }

        public void GirarBotaoIdioma()
        {
            if (vira == false)
            {
                if (testeAviso1 == true)
                {
                    Label lblAviso = new Label();
                    lblAviso.Text = "Nenhum Idioma";
                    pnIdioma.Controls.Add(lblAviso);
                    dtIdioma.Visible = false;
                    lblAviso.Location = new Point(125, 45);
                    lblAviso.ForeColor = Color.White;
                    lblAviso.AutoSize = true;
                    lblAviso.Font = new Font("Myanmar Text", 14);
                }

                pbSetaIdiomas.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                pbSetaIdiomas.Refresh();

                testarVirar();
                vira = true;

                padraoBotoes();

                pnCabecalhoIdioma.Visible = true;  //Visualização
                pnIdioma.Visible = true;

                pnVisulQualificacao.Location = new Point(938, 99 + pnCabecalhoIdioma.Height + pnIdioma.Height);
                pnCabecalhoQualificacao.Location = new Point(938, 129 + pnCabecalhoIdioma.Height + pnIdioma.Height);
                pnQualificacoes.Location = new Point(938, 162 + pnCabecalhoIdioma.Height + pnIdioma.Height);

                pnVisulExpProf.Location = new Point(938, 128 + pnCabecalhoIdioma.Height + pnIdioma.Height);
                pnCabecalhoExpProf.Location = new Point(938, 157 + pnCabecalhoIdioma.Height + pnIdioma.Height);
                pnExperiencia.Location = new Point(938, 189 + pnCabecalhoIdioma.Height + pnIdioma.Height);

                pnVisulExpInt.Location = new Point(938, 156 + pnCabecalhoIdioma.Height + pnIdioma.Height);     
                pnCabecalhoExpInt.Location = new Point(938, 185 + pnCabecalhoIdioma.Height + pnIdioma.Height);
                pnExpInt.Location = new Point(938, 218 + pnCabecalhoIdioma.Height + pnIdioma.Height);

                pnVisulTrabVol.Location = new Point(938, 184 + pnCabecalhoIdioma.Height + pnIdioma.Height);
                pnCabecalhoTrabVol.Location = new Point(938, 213 + pnCabecalhoIdioma.Height + pnIdioma.Height);
                pnTrabVol.Location = new Point(938, 246 + pnCabecalhoIdioma.Height + pnIdioma.Height);
            }
            else
            {
                pbSetaIdiomas.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                pbSetaIdiomas.Refresh();
                vira = false;                                                       //Girar botão idioma

                padraoBotoes();
            }

        }

        public void GirarBotaoQualificacoes()
        {
            if (vira3 == false)
            {
                if (testeAviso3 == true)
                {
                    Label lblAviso = new Label();
                    lblAviso.Text = "Nenhuma Qualificação";
                    pnQualificacoes.Controls.Add(lblAviso);
                    dtQualificacoes.Visible = false;
                    lblAviso.Location = new Point(95, 45);
                    lblAviso.ForeColor = Color.White;
                    lblAviso.AutoSize = true;
                    lblAviso.Font = new Font("Myanmar Text", 14);
                }

                pbSetaQualificacoes.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                pbSetaQualificacoes.Refresh();

                testarVirar();
                vira3 = true;

                padraoBotoes();

                pnCabecalhoQualificacao.Visible = true;                 //Girar botão qualificacao
                pnQualificacoes.Visible = true;

                pnVisulQualificacao.Location = new Point(938, 99);
                pnCabecalhoQualificacao.Location = new Point(938, 129);
                pnQualificacoes.Location = new Point(938, 162);

                pnVisulExpProf.Location = new Point(938, 128 + pnCabecalhoIdioma.Height + pnIdioma.Height);
                pnCabecalhoExpProf.Location = new Point(938, 157 + pnCabecalhoIdioma.Height + pnIdioma.Height);
                pnExperiencia.Location = new Point(938, 189 + pnCabecalhoIdioma.Height + pnIdioma.Height);

                pnVisulExpInt.Location = new Point(938, 156 + pnCabecalhoIdioma.Height + pnIdioma.Height);
                pnCabecalhoExpInt.Location = new Point(938, 185 + pnCabecalhoIdioma.Height + pnIdioma.Height);
                pnExpInt.Location = new Point(938, 218 + pnCabecalhoIdioma.Height + pnIdioma.Height);

                pnVisulTrabVol.Location = new Point(938, 184 + pnCabecalhoIdioma.Height + pnIdioma.Height);
                pnCabecalhoTrabVol.Location = new Point(938, 213 + pnCabecalhoIdioma.Height + pnIdioma.Height);
                pnTrabVol.Location = new Point(938, 246 + pnCabecalhoIdioma.Height + pnIdioma.Height);
            }
            else
            {
                pbSetaQualificacoes.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                pbSetaQualificacoes.Refresh();
                vira3 = false;

                padraoBotoes();
            }
        }

        public void GirarBotaoExpProf()
        {
            if (vira2 == false)
            {
                if (testeAviso2 == true)
                {
                    Label lblAviso = new Label();
                    lblAviso.Text = "Nenhuma Experiência";
                    pnExperiencia.Controls.Add(lblAviso);
                    dtExpProf.Visible = false;
                    lblAviso.Location = new Point(100, 45);
                    lblAviso.ForeColor = Color.White;
                    lblAviso.AutoSize = true;
                    lblAviso.Font = new Font("Myanmar Text", 14);
                }

                pbSetaExpProf.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                pbSetaExpProf.Refresh();

                testarVirar();
                vira2 = true;

                padraoBotoes();

                pnCabecalhoExpProf.Visible = true;          //Girar botão experiencia profissional
                pnExperiencia.Visible = true;

                pnVisulQualificacao.Location = new Point(938, 99);
                pnCabecalhoQualificacao.Location = new Point(938, 129);
                pnQualificacoes.Location = new Point(938, 162);

                pnVisulExpProf.Location = new Point(938, 128);
                pnCabecalhoExpProf.Location = new Point(938, 157);
                pnExperiencia.Location = new Point(938, 189);

                pnVisulExpInt.Location = new Point(938, 156 + pnCabecalhoIdioma.Height + pnIdioma.Height);
                pnCabecalhoExpInt.Location = new Point(938, 185 + pnCabecalhoIdioma.Height + pnIdioma.Height);
                pnExpInt.Location = new Point(938, 218 + pnCabecalhoIdioma.Height + pnIdioma.Height);

                pnVisulTrabVol.Location = new Point(938, 184 + pnCabecalhoIdioma.Height + pnIdioma.Height);
                pnCabecalhoTrabVol.Location = new Point(938, 213 + pnCabecalhoIdioma.Height + pnIdioma.Height);
                pnTrabVol.Location = new Point(938, 246 + pnCabecalhoIdioma.Height + pnIdioma.Height);
            }
            else
            {
                pbSetaExpProf.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                pbSetaExpProf.Refresh();
                vira2 = false;

                padraoBotoes();
            }
        }

        public void GirarBotaoExpInt()
        {
            if (vira4 == false)
            {
                if (testeAviso4 == true)
                {
                    Label lblAviso = new Label();
                    lblAviso.Text = "Nenhuma Experiência Internacional";
                    pnExpInt.Controls.Add(lblAviso);
                    dtExpInt.Visible = false;
                    lblAviso.Location = new Point(45, 45);
                    lblAviso.ForeColor = Color.White;
                    lblAviso.AutoSize = true;
                    lblAviso.Font = new Font("Myanmar Text", 14);
                }

                pbSetaExpInt.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                pbSetaExpInt.Refresh();

                testarVirar();
                vira4 = true;

                padraoBotoes();

                pnCabecalhoExpInt.Visible = true;           //Girar botão Experiencia internacional
                pnExpInt.Visible = true;

                pnVisulQualificacao.Location = new Point(938, 99);
                pnCabecalhoQualificacao.Location = new Point(938, 129);
                pnQualificacoes.Location = new Point(938, 162);

                pnVisulExpProf.Location = new Point(938, 128);
                pnCabecalhoExpProf.Location = new Point(938, 157);
                pnExperiencia.Location = new Point(938, 189);

                pnVisulExpInt.Location = new Point(938, 156);
                pnCabecalhoExpInt.Location = new Point(938, 185);
                pnExpInt.Location = new Point(938, 218);

                pnVisulTrabVol.Location = new Point(938, 184 + pnCabecalhoIdioma.Height + pnIdioma.Height);
                pnCabecalhoTrabVol.Location = new Point(938, 213 + pnCabecalhoIdioma.Height + pnIdioma.Height);
                pnTrabVol.Location = new Point(938, 246 + pnCabecalhoIdioma.Height + pnIdioma.Height);
            }
            else
            {
                pbSetaExpInt.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                pbSetaExpInt.Refresh();
                vira4 = false;

                padraoBotoes();
            }
        }

        public void GirarBotaoTrabVol()
        {
            if (vira5 == false)
            {
                if (testeAviso5 == true)
                {
                    Label lblAviso = new Label();
                    lblAviso.Text = "Nenhum Trabalho Voluntário";
                    pnTrabVol.Controls.Add(lblAviso);
                    dtTrabalhoVoluntario.Visible = false;
                    lblAviso.Location = new Point(70, 45);
                    lblAviso.ForeColor = Color.White;
                    lblAviso.AutoSize = true;
                    lblAviso.Font = new Font("Myanmar Text", 14);
                }

                pbSetaTrabVol.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                pbSetaTrabVol.Refresh();

                testarVirar();
                vira5 = true;

                padraoBotoes();

                pnCabecalhoTrabVol.Visible = true;           //Girar botão Experiencia internacional
                pnTrabVol.Visible = true;
            }
            else
            {
                pbSetaTrabVol.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                pbSetaTrabVol.Refresh();
                vira5 = false;

                padraoBotoes();
            }
        }

        private void pbChat_MouseEnter(object sender, EventArgs e)
        {
            pbChat.Image = Properties.Resources.chatRoxo1;      //Animação do chat
        }

        private void pbChat_MouseLeave(object sender, EventArgs e)
        {
            pbChat.Image = Properties.Resources.chatAzul;       //Animação do chat
        }

        private void p_barra_Paint(object sender, PaintEventArgs e)
        {
            int x = (p_barra.Size.Width - lbl_curriculo.Width) / 2;
            int y = (p_barra.Size.Height - lbl_curriculo.Height);     //Alinhamento da barra

            lbl_curriculo.Location = new Point(x, y);
        }

        private void p_barra_Resize(object sender, EventArgs e)
        {
            int x = (p_barra.Size.Width - lbl_curriculo.Width) / 2;
            int y = (p_barra.Size.Height - lbl_curriculo.Height);    //Alinhamento da barra ao maximizar

            lbl_curriculo.Location = new Point(x, y);
        }

        private void pb_voltar_MouseEnter(object sender, EventArgs e)
        {
            pb_voltar.Image = Properties.Resources.VoltarRoxo;     //Animação do botão voltar
        }

        private void pb_voltar_MouseLeave(object sender, EventArgs e)
        {
            pb_voltar.Image = Properties.Resources.voltar;
        }

        private void pb_voltar_Click(object sender, EventArgs e)
        {
            var usuario = bd.usuario.Where(x => x.idUsuario == UsuarioDados.Id).FirstOrDefault();
            if (usuario.tipoUsuario == false)
            {
                this.Hide();
                TelaPrincipalEmpresa f = new TelaPrincipalEmpresa();
                f.Closed += (s, args) => this.Close();
                f.ShowDialog();
            }
            else
            {
                this.Hide();
                TelaPrincipalTrabalhador f = new TelaPrincipalTrabalhador();
                f.Closed += (s, args) => this.Close();
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
            pbMaximizar.BackColor = Color.FromArgb(41, 41, 41);                  //Efeito de opções no menu 
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

        private void dtAvaliacao_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            PegarID.IDN = Convert.ToInt32(dtAvaliacao.CurrentRow.Cells[0].Value);

            try
            {
                var avaliacao = bd.avaliacao.Where(Z => Z.idAvaliacao == PegarID.IDN).FirstOrDefault();

                if (avaliacao.nota == 1)
                {
                    pbEstrela1.Image = Properties.Resources.Estrela21;
                    pbEstrela2.Image = Properties.Resources.estrela;
                    pbEstrela3.Image = Properties.Resources.estrela;           //Nota 1
                    pbEstrela4.Image = Properties.Resources.estrela;
                    pbEstrela5.Image = Properties.Resources.estrela;
                }
                else if (avaliacao.nota == 2)
                {
                    pbEstrela1.Image = Properties.Resources.Estrela21;
                    pbEstrela2.Image = Properties.Resources.Estrela21;
                    pbEstrela3.Image = Properties.Resources.estrela;
                    pbEstrela4.Image = Properties.Resources.estrela;           //Nota 2
                    pbEstrela5.Image = Properties.Resources.estrela;
                }
                else if (avaliacao.nota == 3)
                {
                    pbEstrela1.Image = Properties.Resources.Estrela21;
                    pbEstrela2.Image = Properties.Resources.Estrela21;
                    pbEstrela3.Image = Properties.Resources.Estrela21;         //Nota 3
                    pbEstrela4.Image = Properties.Resources.estrela;
                    pbEstrela5.Image = Properties.Resources.estrela;
                }
                else if (avaliacao.nota == 4)
                {
                    pbEstrela1.Image = Properties.Resources.Estrela21;
                    pbEstrela2.Image = Properties.Resources.Estrela21;
                    pbEstrela3.Image = Properties.Resources.Estrela21;         //Nota 4
                    pbEstrela4.Image = Properties.Resources.Estrela21;
                    pbEstrela5.Image = Properties.Resources.estrela;
                }
                else if (avaliacao.nota == 5)
                {
                    pbEstrela1.Image = Properties.Resources.Estrela21;
                    pbEstrela2.Image = Properties.Resources.Estrela21;
                    pbEstrela3.Image = Properties.Resources.Estrela21;         //Nota 5
                    pbEstrela4.Image = Properties.Resources.Estrela21;
                    pbEstrela5.Image = Properties.Resources.Estrela21;
                }

                if (avaliacao.comentario != null)
                {
                    lblComentarioAdicionar.Text = "Comentário: " + avaliacao.comentario;
                }
                else
                {
                    lblComentarioAdicionar.Text = "Nenhum comentário da empresa para esse funcionário!";
                }
            }
            catch (Exception)
            {
                Mensagem.aviso = "Erro de conexão com o banco!";
                TelaMensagemAviso f = new TelaMensagemAviso();
                f.ShowDialog();
            }
        }

        private void btInteressado_Click(object sender, EventArgs e)
        {
            try
            {
                var curriculo = bd.curriculo.Where(x => x.idCurriculo == idSelecionado).FirstOrDefault();
                var usuEmp = bd.usuario_empresa.Where(x => x.FK_usuario == UsuarioDados.Id).FirstOrDefault();
                var interessado = bd.interessados_empresa.Where(x => x.FK_curriculo == curriculo.idCurriculo).
                Where(x => x.FK_usuario_empresa == usuEmp.cnpj).FirstOrDefault();

                if (interessado == null)
                {
                    interessados_empresa add = new interessados_empresa();
                    add.FK_curriculo = curriculo.idCurriculo;
                    add.FK_usuario_empresa = usuEmp.cnpj;

                    bd.interessados_empresa.Add(add);
                    bd.SaveChanges();
                    Mensagem.aviso = "Currículo foi adicionado aos interessados!";
                    TelaMensagemAviso f = new TelaMensagemAviso();
                    f.ShowDialog();
                }
                else
                {
                    Mensagem.aviso = "Currículo já adicionado aos interessados!";
                    TelaMensagemAviso f = new TelaMensagemAviso();
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

        private void pbChat_Click(object sender, EventArgs e)
        {
            try
            {
                var curriculo = bd.curriculo.Where(x => x.idCurriculo == Pesquisa.ID).FirstOrDefault();  //Abre a conversa com o usuário

                var usuarioTrab = bd.usuario_trabalhador.Where(x => x.CPF == curriculo.FK_usuario_trabalhador).FirstOrDefault();
                var usuario = bd.usuario.Where(x => x.idUsuario == usuarioTrab.FK_usuario).FirstOrDefault();

                var empresa = bd.usuario_empresa.Where(x => x.FK_usuario == UsuarioDados.Id).FirstOrDefault();

                if (PegarID.Identificar == 1)
                {
                    var recomendados = bd.recomendados_empresa.Where(x => x.FK_curriculo == curriculo.idCurriculo).FirstOrDefault();
                    PegarID.IDN = recomendados.IdRecomendadosEmpresa;
                }
                else if (PegarID.Identificar == 2)
                {
                    var interessados = bd.interessados_empresa.Where(x => x.FK_curriculo == curriculo.idCurriculo).FirstOrDefault();
                    PegarID.IDN = interessados.idInteressadosEmpresa;
                }
                else if (PegarID.Identificar == 3)
                {
                    var trab = bd.usuario_trabalhador.Where(x => x.CPF == curriculo.FK_usuario_trabalhador).FirstOrDefault();
                    var candidatos = bd.candidatos.Where(x => x.FK_usuario_trabalhador == trab.CPF).FirstOrDefault();
                    PegarID.IDN = candidatos.idCandidatos;
                }
                else if (PegarID.Identificar == 4)
                {
                    var interessados = bd.interessados_empresa.Where(x => x.FK_curriculo == curriculo.idCurriculo).FirstOrDefault();

                    if (interessados == null)
                    {
                        interessados_empresa add = new interessados_empresa();
                        add.FK_curriculo = curriculo.idCurriculo;
                        add.FK_usuario_empresa = empresa.cnpj;

                        bd.interessados_empresa.Add(add);
                        bd.SaveChanges();

                        var interessados2 = bd.interessados_empresa.Where(x => x.FK_curriculo == curriculo.idCurriculo).FirstOrDefault();

                        PegarID.IDN = interessados2.idInteressadosEmpresa;
                    }
                    else
                    {
                        PegarID.IDN = interessados.idInteressadosEmpresa;
                    }
                }

                this.Hide();
                TelaMensagemEmpresa f = new TelaMensagemEmpresa();
                f.Closed += (s, args) => this.Close();
                f.ShowDialog();
            }
            catch (Exception)
            {
                Mensagem.aviso = "Erro de conexão com o banco!";
                TelaMensagemAviso f = new TelaMensagemAviso();
                f.ShowDialog();
            }
        }

        private void pnVisuIdiomas_Click(object sender, EventArgs e)
        {
            GirarBotaoIdioma();
        }

        private void pnVisulQualificacao_Click(object sender, EventArgs e)
        {
            GirarBotaoQualificacoes();
        }

        private void pnVisulExpProf_Click(object sender, EventArgs e)
        {
            GirarBotaoExpProf();
        }

        private void pnVisulExpInt_Click(object sender, EventArgs e)
        {
            GirarBotaoExpInt();
        }

        private void pbEditarCurriculo_Click(object sender, EventArgs e)
        {
            this.Hide();
            TelaEditarCurriculo f = new TelaEditarCurriculo();
            f.Closed += (s, args) => this.Close();
            f.ShowDialog();
        }

        private void dtAvaliacao_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var usuario = bd.usuario.Where(x => x.idUsuario == UsuarioDados.Id).FirstOrDefault();

                if (usuario.tipoUsuario == false)
                {
                    int id = Convert.ToInt32(dtAvaliacao.CurrentRow.Cells[0].Value);    //Abre o curriculo selecionado

                    var curriculo = bd.curriculo.Where(x => x.idCurriculo == idSelecionado).FirstOrDefault();
                    var avaliacao = bd.avaliacao.Where(x => x.FK_curriculo == curriculo.idCurriculo).FirstOrDefault();
                    var usuEmpresa = bd.usuario_empresa.Where(x => x.cnpj == avaliacao.FK_usuario_empresa).FirstOrDefault();

                    PegarIDEmpresa.IDEmpresa = usuEmpresa.FK_usuario;
                    PegarIDEmpresa.visualizacao = true;

                    TelaVisualizacaoPerfilEmpresa f = new TelaVisualizacaoPerfilEmpresa();
                    f.ShowDialog();
                }
                else
                {
                    int id = Convert.ToInt32(dtAvaliacao.CurrentRow.Cells[0].Value);    //Abre o curriculo selecionado

                    var usuTrab = bd.usuario_trabalhador.Where(x => x.FK_usuario == UsuarioDados.Id).FirstOrDefault();
                    var curriculo = bd.curriculo.Where(x => x.FK_usuario_trabalhador == usuTrab.CPF).FirstOrDefault();
                    var avaliacao = bd.avaliacao.Where(x => x.FK_curriculo == curriculo.idCurriculo).FirstOrDefault();
                    var usuEmpresa = bd.usuario_empresa.Where(x => x.cnpj == avaliacao.FK_usuario_empresa).FirstOrDefault();

                    PegarIDEmpresa.IDEmpresa = usuEmpresa.FK_usuario;
                    PegarIDEmpresa.visualizacao = true;

                    TelaVisualizacaoPerfilEmpresa f = new TelaVisualizacaoPerfilEmpresa();
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

        private void pbEditarCurriculo_MouseEnter(object sender, EventArgs e)
        {
            pbEditarCurriculo.Image = Properties.Resources.EditarCurriculoRoxo;
        }

        private void pbEditarCurriculo_MouseLeave(object sender, EventArgs e)
        {
            pbEditarCurriculo.Image = Properties.Resources.EditarCurriculo;
        }

        private void dtIdioma_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            TelaVisualizarIdiomaTrabalhador f = new TelaVisualizarIdiomaTrabalhador();
            f.ShowDialog();
        }

        private void dtIdioma_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)   //Abre a visualização do curriculo
            {
                TelaVisualizarIdiomaTrabalhador f = new TelaVisualizarIdiomaTrabalhador();
                f.ShowDialog();
            }
        }

        private void dtQualificacoes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            TelaVisualizarQualificacaoTrabalhador f = new TelaVisualizarQualificacaoTrabalhador();
            f.ShowDialog();
        }

        private void dtQualificacoes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)   //Abre a visualização do curriculo
            {
                TelaVisualizarQualificacaoTrabalhador f = new TelaVisualizarQualificacaoTrabalhador();
                f.ShowDialog();
            }
        }

        private void dtExpProf_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            TelaVisualizarExperienciaProfissionalTrabalhador f = new TelaVisualizarExperienciaProfissionalTrabalhador();
            f.ShowDialog();
        }

        private void dtExpProf_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)   //Abre a visualização do curriculo
            {
                TelaVisualizarExperienciaProfissionalTrabalhador f = new TelaVisualizarExperienciaProfissionalTrabalhador();
                f.ShowDialog();
            }
        }

        private void dtExpInt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)   //Abre a visualização do curriculo
            {
                TelaVisualizarExperienciaInternacionalTrabalhador f = new TelaVisualizarExperienciaInternacionalTrabalhador();
                f.ShowDialog();
            }
        }

        private void dtExpInt_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            TelaVisualizarExperienciaInternacionalTrabalhador f = new TelaVisualizarExperienciaInternacionalTrabalhador();
            f.ShowDialog();
        }

        private void dtTrabalhoVoluntario_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            TelaVisualizarTrabalhoVoluntarioTrabalhador f = new TelaVisualizarTrabalhoVoluntarioTrabalhador();
            f.ShowDialog();
        }

        private void dtTrabalhoVoluntario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)   //Abre a visualização do curriculo
            {
                TelaVisualizarTrabalhoVoluntarioTrabalhador f = new TelaVisualizarTrabalhoVoluntarioTrabalhador();
                f.ShowDialog();
            }
        }

        private void pnVisulTrabVol_Click(object sender, EventArgs e)
        {
            GirarBotaoTrabVol();
        }
    }
}


