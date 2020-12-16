using Pismire_TCC.Resources;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Pismire_TCC
{
    public partial class TelaVisualizacaoVagas : Form
    {
        PismireEntities5 bd = new PismireEntities5();
        byte passadasOrganizacao = 0;

        bool vira1 = false;         
        bool vira2 = false;
        bool vira3 = false;
        bool vira4 = false;
        bool testeAviso1 = true;
        bool testeAviso2 = true;
        bool testeAviso3 = true;
        bool testeAviso4 = true;
        bool JaPossui = true;

        public TelaVisualizacaoVagas()
        {
            InitializeComponent();
            label6.Text = "Deseja mesmo se desinscrever-se\n desta vaga?";
            pnIdioma.BorderStyle = BorderStyle.FixedSingle;
            pnCabecalhoIdioma.BorderStyle = BorderStyle.FixedSingle;

            pnQualificacao.BorderStyle = BorderStyle.FixedSingle;
            pnCabecalhoQualificacao.BorderStyle = BorderStyle.FixedSingle; //Bordas padrão

            pnExpProf.BorderStyle = BorderStyle.FixedSingle;
            pnCabecalhoExpProf.BorderStyle = BorderStyle.FixedSingle;

            pnExpInt.BorderStyle = BorderStyle.FixedSingle;
            pnCabecalhoExpInt.BorderStyle = BorderStyle.FixedSingle;

            padraoBotoes();         //Inicializa posição das gridviews

            Maximizacao.verifique(this, pbMaximizar);
            int id = PegarIDVaga.IDVaga;

            try
            {
                var evento = bd.evento.Where(x => x.idEvento == id).FirstOrDefault();

                if (evento != null)
                {
                    string txt = evento.salario.ToString();
                    int cont = txt.Length;

                    if (cont == 4)
                    {
                        txt = evento.salario.ToString();     //N.NNN
                        txt = txt.Insert(1, ".");
                    }
                    else if (cont == 5)
                    {
                        txt = evento.salario.ToString();     //NN.NNN
                        txt = txt.Insert(2, ".");
                    }
                    else if (cont == 6)
                    {
                        txt = evento.salario.ToString();     //NNN.NNN
                        txt = txt.Insert(3, ".");
                    }
                    else if (cont == 7)
                    {
                        txt = evento.salario.ToString();     //N.NNN.NNN
                        txt = txt.Insert(1, ".");
                        txt = txt.Insert(5, ".");
                    }
                    else if (cont == 8)
                    {
                        txt = evento.salario.ToString();     //NN.NNN.NNN                   //Máscara de salário
                        txt = txt.Insert(2, ".");
                        txt = txt.Insert(6, ".");
                    }
                    else if (cont == 9)
                    {
                        txt = evento.salario.ToString();     //NNN.NNN.NNN
                        txt = txt.Insert(3, ".");
                        txt = txt.Insert(7, ".");
                    }
                    else if (cont == 10)
                    {
                        txt = evento.salario.ToString();     //N.NNN.NNN.NNN
                        txt = txt.Insert(1, ".");
                        txt = txt.Insert(5, ".");
                        txt = txt.Insert(9, ".");
                    }

                    if (txt != null)
                    {
                        txt = txt + ",00";
                    }

                    lblVaga.Text = evento.vagaEvento;
                    lblSalario.Text = $"R$: {txt}";
                    lblTipoEmprego.Text = evento.tipoEmprego;
                    lblTurno.Text = evento.turno;

                    var usuarioEmpresa = bd.usuario_empresa.Where(x => x.cnpj == evento.FK_usuario_empresa).FirstOrDefault();
                    var usuario = bd.usuario.Where(x => x.idUsuario == usuarioEmpresa.FK_usuario).FirstOrDefault();
                    lblEmpresa.Text = usuario.nomeUsuario;

                    lblArea.Text = evento.areaEvento;
                    lblHorarioExpediente.Text = ("Entrada: " + evento.horarioInicialExpedienteEvento.ToString()
                    + " / Saída: " + evento.horarioFinalExpedienteEvento.ToString());

                    lblLocalizacao.Text = (evento.ruaEvento + ", " + evento.numeroEvento + " - " + evento.bairroEvento + ", "
                    + evento.cidadeEvento + " " + evento.estadoEvento + ", " + evento.cepEvento);

                    lblPrazo.Text = evento.dataFinalEvento.Day + "/" + evento.dataFinalEvento.Month + "/" + evento.dataFinalEvento.Year;

                    var beneficio = bd.beneficios.Where(x => x.FK_evento == evento.idEvento).FirstOrDefault();

                    if (beneficio != null)
                    {
                        lblTxt2.Visible = true;
                        pbLinha1.Visible = true;
                        passadasOrganizacao = 0;
                        bool passouSaude = false;
                        bool passouOdon = false;
                        bool passouAlim = false;
                        bool passouCultura = false;
                        bool passouHome = false;
                        bool passouViagem = false;
                        bool passouConv = false;
                        bool passouBolsa = false;

                        for (int i = 0; i < 8; i++)
                        {
                            if (beneficio.assistenciaSaude == true && passouSaude == false)
                            {
                                organizar("Assistência Saúde");
                                passouSaude = true;
                            }
                            else if (beneficio.assistenciaOdontologica == true && passouOdon == false)
                            {
                                organizar("Assistência Odontológica");
                                passouOdon = true;
                            }
                            else if (beneficio.valeAlimentacao == true && passouAlim == false)                //Adiciona os beneficios do evento
                            {
                                organizar("Vale - Alimentação");
                                passouAlim = true;
                            }
                            else if (beneficio.valeCultura == true && passouCultura == false)
                            {
                                organizar("Vale - Cultura");
                                passouCultura = true;
                            }
                            else if (beneficio.trabalhoHomeOffice == true && passouHome == false)
                            {
                                organizar("Trabalho Home-office");
                                passouHome = true;
                            }
                            else if (beneficio.valeViagem == true && passouViagem == false)
                            {
                                organizar("Vale - Viagem");
                                passouViagem = true;
                            }
                            else if (beneficio.salasDeConferencias == true && passouConv == false)
                            {
                                organizar("Salas de convivência");
                                passouConv = true;
                            }
                            else if (beneficio.bolsasDeEstudos == true && passouBolsa == false)
                            {
                                organizar("Bolsas de Estudo");
                                passouBolsa = true;
                            }
                        }
                    }

                    var teste_idioma = bd.idioma_evento.Where(x => x.idIdiomaEvento != 0).FirstOrDefault();

                    if (teste_idioma != null)
                    {
                        try
                        {
                            var dt1 = new DataTable();

                            dt1.Columns.Add("ID_Idioma");                           //Adicionando idioma na gridview
                            dt1.Columns.Add("idioma");
                            dt1.Columns.Add("nivel");
                            int max = bd.idioma_evento.Max(x => x.idIdiomaEvento);

                            for (int i = 0; i <= max; i++)
                            {
                                var idiomas = bd.idioma_evento.Where(x => x.FK_evento == PegarIDVaga.IDVaga).Where(y => y.idIdiomaEvento == i).FirstOrDefault();

                                if (idiomas != null)
                                {
                                    dt1.Rows.Add(idiomas.idIdiomaEvento, idiomas.linguaEvento,
                                    idiomas.nivelEvento);

                                    dtIdioma.DataSource = dt1; //Conecta com o GridView

                                    this.dtIdioma.Columns["ID_Idioma"].Visible = false; //Tira as que não precisa
                                    testeAviso1 = false;
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

                    var teste_qualificacao = bd.qualificacao_evento.Where(x => x.idQualificacaoEvento != 0).FirstOrDefault();

                    if (teste_qualificacao != null)
                    {
                        try
                        {
                            var dt1 = new DataTable();

                            dt1.Columns.Add("ID_Qualificacao");                           //Adicionando qualif na gridview
                            dt1.Columns.Add("NomeQualificacao");
                            dt1.Columns.Add("tipoQualificacao");
                            int max = bd.qualificacao_evento.Max(x => x.idQualificacaoEvento);

                            for (int i = 0; i <= max; i++)
                            {
                                var qualificacao = bd.qualificacao_evento.Where(x => x.FK_evento == PegarIDVaga.IDVaga).Where(y => y.idQualificacaoEvento == i).FirstOrDefault();

                                if (qualificacao != null)
                                {
                                    dt1.Rows.Add(qualificacao.idQualificacaoEvento, qualificacao.nomeQualificacaoEvento,
                                    qualificacao.tipoQualificacaoEvento);

                                    dtQualificacao.DataSource = dt1; //Conecta com o GridView

                                    this.dtQualificacao.Columns["ID_Qualificacao"].Visible = false; //Tira as que não precisa
                                    testeAviso2 = false;
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

                    var teste_experiencia_prof = bd.experiencia_profissional_evento.Where(x => x.idExperienciaEvento != 0).FirstOrDefault();

                    if (teste_experiencia_prof != null)
                    {
                        try
                        {
                            var dt1 = new DataTable();

                            dt1.Columns.Add("ID_Experiencia");                           //Adicionando exp prof na gridview
                            dt1.Columns.Add("NomeExperiencia");

                            int max = bd.experiencia_profissional_evento.Max(x => x.idExperienciaEvento);

                            for (int i = 0; i <= max; i++)
                            {
                                var experiencia = bd.experiencia_profissional_evento.Where(x => x.FK_evento == PegarIDVaga.IDVaga).Where(y => y.idExperienciaEvento == i).FirstOrDefault();

                                if (experiencia != null)
                                {
                                    dt1.Rows.Add(experiencia.idExperienciaEvento, experiencia.cargoExperienciaEvento);

                                    dtExpProf.DataSource = dt1; //Conecta com o GridView

                                    this.dtExpProf.Columns["ID_Experiencia"].Visible = false; //Tira as que não precisa
                                    testeAviso3 = false;
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
                    var teste_experiencia_int = bd.experiencia_internacional_evento.Where(x => x.idInternacionalEvento != 0).FirstOrDefault();

                    if (teste_experiencia_int != null)
                    {
                        try
                        {
                            var dt1 = new DataTable();

                            dt1.Columns.Add("ID_ExperienciaInt");                           //Adicionando exp int na gridview
                            dt1.Columns.Add("CargoExp");
                            dt1.Columns.Add("Pais");
                            int max = bd.experiencia_internacional_evento.Max(x => x.idInternacionalEvento);

                            for (int i = 0; i <= max; i++)
                            {
                                var experiencia_int = bd.experiencia_internacional_evento.Where(x => x.FK_evento == PegarIDVaga.IDVaga).Where(y => y.idInternacionalEvento == i).FirstOrDefault();

                                if (experiencia_int != null)
                                {
                                    dt1.Rows.Add(experiencia_int.idInternacionalEvento, experiencia_int.cargoInternacionalEvento, experiencia_int.paisCargoInternacionalEvento);

                                    dtExpInt.DataSource = dt1; //Conecta com o GridView

                                    this.dtExpInt.Columns["ID_ExperienciaInt"].Visible = false; //Tira as que não precisa
                                    testeAviso4 = false;
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

                    var verifica_usuario = bd.usuario_trabalhador.Where(x => x.FK_usuario == UsuarioDados.Id).FirstOrDefault();

                    if (verifica_usuario != null)
                    {
                        var verifica_evento = bd.candidatos.Where(x => x.FK_usuario_trabalhador == verifica_usuario.CPF).Where(y => y.FK_evento == PegarIDVaga.IDVaga).FirstOrDefault();

                        if (verifica_evento != null)
                        {
                            JaPossui = true;
                            lblInscricao.Text = "Inscrito";    //Verifica se o usuário já está inscrito
                            pbInscricao.Image = Properties.Resources.inscrito;
                            lblInscricao.BackColor = Color.FromArgb(89, 90, 99);
                        }
                        else
                        {
                            JaPossui = false;
                        }
                    }
                }
                else
                {
                    this.Hide();
                    TelaEventosCriados f = new TelaEventosCriados();  //Saida de erro
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

        private void organizar(string txt)
        {
            passadasOrganizacao++;

            if (passadasOrganizacao == 1)
            {
                pbEspaco1.Visible = true;
                lblEspaco1.Text = txt;
                lblEspaco1.Visible = true;
            }
            else if (passadasOrganizacao == 2)
            {
                pbEspaco2.Visible = true;
                lblEspaco2.Text = txt;
                lblEspaco2.Visible = true;
            }
            else if (passadasOrganizacao == 3)
            {
                pbEspaco3.Visible = true;
                lblEspaco3.Text = txt;
                lblEspaco3.Visible = true;
            }
            else if (passadasOrganizacao == 4)
            {
                pbEspaco4.Visible = true;
                lblEspaco4.Text = txt;
                lblEspaco4.Visible = true;
            }
            else if (passadasOrganizacao == 5)
            {
                pbEspaco5.Visible = true;
                lblEspaco5.Text = txt;
                lblEspaco5.Visible = true;
            }
            else if (passadasOrganizacao == 6)          //Preenche os benefi[ícios da vaga
            {
                pbEspaco6.Visible = true;
                lblEspaco6.Text = txt;
                lblEspaco6.Visible = true;
            }
            else if (passadasOrganizacao == 7)
            {
                pbEspaco7.Visible = true;
                lblEspaco7.Text = txt;
                lblEspaco7.Visible = true;
            }
            else if (passadasOrganizacao == 8)
            {
                pbEspaco8.Visible = true;
                lblEspaco8.Text = txt;
                lblEspaco8.Visible = true;
            }
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

        private void pbFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pbMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;    //Minimizar tela 
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

        private void pbVoltar_Click(object sender, EventArgs e)
        {
            if (VoltarTelaInteressado.bVoltar == true)
            {
                VoltarTelaInteressado.bVoltar = false;
                this.Hide();
                TelaInteresses f = new TelaInteresses();
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
            int x = (p_barra.Size.Width - lblVagas.Width) / 2;
            int y = (p_barra.Size.Height - lblVagas.Height);              //Posição da label na barra ao maximizar e desmaximizar 

            lblVagas.Location = new Point(x, y);
        }

        private void p_barra_Resize(object sender, EventArgs e)
        {
            int x = (p_barra.Size.Width - lblVagas.Width) / 2;
            int y = (p_barra.Size.Height - lblVagas.Height);              //Posição da label na barra ao maximizar e desmaximizar 

            lblVagas.Location = new Point(x, y);
        }

        private void testarVirar()
        {
            if (vira1 == true)
            {
                pbSetaIdioma.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                pbSetaIdioma.Refresh();
                vira1 = false;
            }

            if (vira2 == true)
            {
                pbSetaQualificacao.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                pbSetaQualificacao.Refresh();
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
        }

        private void padraoBotoes()
        {
            pnVisulIdioma.Location = new Point(50, 401);
            pnCabecalhoIdioma.Location = new Point(50, 431);
            pnIdioma.Location = new Point(50, 468);

            pnVisulQualificacao.Location = new Point(50, 430);
            pnCabecalhoQualificacao.Location = new Point(50, 460);
            pnQualificacao.Location = new Point(50, 498);

            pnVisulExpProf.Location = new Point(50, 460);
            pnCabecalhoExpProf.Location = new Point(50, 491);
            pnExpProf.Location = new Point(50, 528);

            pnVisulExpInt.Location = new Point(50, 488);                      //Localização inicial dos paineis 
            pnCabecalhoExpInt.Location = new Point(50, 519);
            pnExpInt.Location = new Point(50, 555);

            pnIdioma.Visible = false;
            pnQualificacao.Visible = false;
            pnExpProf.Visible = false;
            pnExpInt.Visible = false;

            pnCabecalhoIdioma.Visible = false;
            pnCabecalhoQualificacao.Visible = false;
            pnCabecalhoExpProf.Visible = false;
            pnCabecalhoExpInt.Visible = false;
        }

        public void GirarBotaoIdioma()
        {
            if (vira1 == false)
            {
                if (testeAviso1 == true)
                {
                    Label lblAviso = new Label();
                    lblAviso.Text = "Nenhum Idioma";
                    pnIdioma.Controls.Add(lblAviso);
                    pnIdioma.BackColor = Color.FromArgb(41, 41, 41);
                    dtIdioma.Visible = false;
                    lblAviso.Location = new Point(180, 30);
                    lblAviso.ForeColor = Color.White;
                    lblAviso.AutoSize = true;
                    lblAviso.Font = new Font("Myanmar Text", 14);
                }

                pbSetaIdioma.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                pbSetaIdioma.Refresh();

                testarVirar();
                vira1 = true;

                padraoBotoes();

                pnCabecalhoIdioma.Visible = true;  //Visualização 
                pnIdioma.Visible = true;

                pnVisulQualificacao.Location = new Point(50, 430 + pnCabecalhoIdioma.Height + pnIdioma.Height);
                pnCabecalhoQualificacao.Location = new Point(50, 460 + pnCabecalhoIdioma.Height + pnIdioma.Height);
                pnQualificacao.Location = new Point(50, 498 + pnCabecalhoIdioma.Height + pnIdioma.Height);
                pnVisulExpProf.Location = new Point(50, 460 + pnCabecalhoIdioma.Height + pnIdioma.Height);
                pnCabecalhoExpProf.Location = new Point(50, 491 + pnCabecalhoIdioma.Height + pnIdioma.Height);
                pnExpProf.Location = new Point(50, 528 + pnCabecalhoIdioma.Height + pnIdioma.Height);
                pnVisulExpInt.Location = new Point(50, 488 + pnCabecalhoIdioma.Height + pnIdioma.Height);
                pnCabecalhoExpInt.Location = new Point(50, 519 + pnCabecalhoIdioma.Height + pnIdioma.Height);
                pnExpInt.Location = new Point(50, 555 + pnCabecalhoIdioma.Height + pnIdioma.Height);
            }
            else
            {
                pbSetaIdioma.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                pbSetaIdioma.Refresh();
                vira1 = false;                                                       //Girar botão idioma

                padraoBotoes();
            }
        }

        public void GirarBotaoQualificacoes()
        {
            if (vira2 == false)
            {
                if (testeAviso2 == true)
                {
                    Label lblAviso = new Label();
                    lblAviso.Text = "Nenhuma Qualificação";
                    pnQualificacao.Controls.Add(lblAviso);
                    pnQualificacao.BackColor = Color.FromArgb(41, 41, 41);
                    dtQualificacao.Visible = false;
                    lblAviso.Location = new Point(150, 30);
                    lblAviso.ForeColor = Color.White;
                    lblAviso.AutoSize = true;
                    lblAviso.Font = new Font("Myanmar Text", 14);
                }

                pbSetaQualificacao.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                pbSetaQualificacao.Refresh();

                testarVirar();
                vira2 = true;

                padraoBotoes();

                pnCabecalhoQualificacao.Visible = true;                 //Girar botão qualificacao
                pnQualificacao.Visible = true;

                pnVisulQualificacao.Location = new Point(50, 430);
                pnCabecalhoQualificacao.Location = new Point(50, 460);
                pnQualificacao.Location = new Point(50, 498);
                pnVisulExpProf.Location = new Point(50, 460 + pnCabecalhoIdioma.Height + pnIdioma.Height);
                pnCabecalhoExpProf.Location = new Point(50, 491 + pnCabecalhoIdioma.Height + pnIdioma.Height);
                pnExpProf.Location = new Point(50, 528 + pnCabecalhoIdioma.Height + pnIdioma.Height);
                pnVisulExpInt.Location = new Point(50, 488 + pnCabecalhoIdioma.Height + pnIdioma.Height);
                pnCabecalhoExpInt.Location = new Point(50, 519 + pnCabecalhoIdioma.Height + pnIdioma.Height);
                pnExpInt.Location = new Point(50, 555 + pnCabecalhoIdioma.Height + pnIdioma.Height);
            }
            else
            {
                pbSetaQualificacao.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                pbSetaQualificacao.Refresh();
                vira2 = false;

                padraoBotoes();
            }
        }

        public void GirarBotaoExpProf()
        {
            if (vira3 == false)
            {
                if (testeAviso3 == true)
                {
                    Label lblAviso = new Label();
                    lblAviso.Text = "Nenhuma Experiência";
                    pnExpProf.Controls.Add(lblAviso);
                    pnExpProf.BackColor = Color.FromArgb(41, 41, 41);
                    dtExpProf.Visible = false;
                    lblAviso.Location = new Point(155, 30);
                    lblAviso.ForeColor = Color.White;
                    lblAviso.AutoSize = true;
                    lblAviso.Font = new Font("Myanmar Text", 14);
                }

                pbSetaExpProf.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                pbSetaExpProf.Refresh();

                testarVirar();
                vira3 = true;

                padraoBotoes();

                pnCabecalhoExpProf.Visible = true;          //Girar botão experiencia profissional
                pnExpProf.Visible = true;

                pnVisulQualificacao.Location = new Point(50, 430);
                pnCabecalhoQualificacao.Location = new Point(50, 460);
                pnQualificacao.Location = new Point(50, 498);
                pnVisulExpProf.Location = new Point(50, 460);
                pnCabecalhoExpProf.Location = new Point(50, 491);
                pnExpProf.Location = new Point(50, 528);
                pnVisulExpInt.Location = new Point(50, 488 + pnCabecalhoIdioma.Height + pnIdioma.Height);
                pnCabecalhoExpInt.Location = new Point(50, 519 + pnCabecalhoIdioma.Height + pnIdioma.Height);
                pnExpInt.Location = new Point(50, 555 + pnCabecalhoIdioma.Height + pnIdioma.Height);

            }
            else
            {
                pbSetaExpProf.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                pbSetaExpProf.Refresh();
                vira3 = false;

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
                    lblAviso.Text = "Nenhuma Experiência";
                    pnExpInt.Controls.Add(lblAviso);
                    pnExpInt.BackColor = Color.FromArgb(41, 41, 41);
                    dtExpInt.Visible = false;
                    lblAviso.Location = new Point(155, 30);
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
            }
            else
            {
                pbSetaExpInt.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                pbSetaExpInt.Refresh();
                vira4 = false;

                padraoBotoes();
            }
        }

        private void pnVisulIdioma_Click(object sender, EventArgs e)
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

        void InscreverNaVaga()
        {
            try
            {
                var usuario = bd.usuario_trabalhador.Where(x => x.FK_usuario == UsuarioDados.Id).FirstOrDefault();
                if (usuario != null)
                {
                    if (!JaPossui)
                    {
                        candidatos add = new candidatos();
                        DateTime thisDay = DateTime.Today;
                        add.dataInscricao = Convert.ToDateTime(thisDay.ToShortDateString());
                        add.horaInscricao = TimeSpan.Parse(DateTime.Now.ToString("HH:mm:ss"));
                        add.FK_evento = PegarIDVaga.IDVaga;
                        add.FK_usuario_trabalhador = usuario.CPF;
                        bd.candidatos.Add(add);
                        bd.SaveChanges();
                        Mensagem.aviso = "Inscrição realizada com sucesso!";
                        TelaMensagemAviso f = new TelaMensagemAviso();
                        f.ShowDialog();
                        lblInscricao.Text = "Inscrito";
                        pbInscricao.Image = Properties.Resources.inscrito;
                        lblInscricao.BackColor = Color.FromArgb(89, 90, 99);
                        JaPossui = true;
                    }
                    else
                    {
                        pLixeira.Visible = true;
                    }
                }
                else
                {
                    Mensagem.aviso = "Você não possui seu CPF cadastrado!";
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

        private void pbInscricao_Click(object sender, EventArgs e)
        {
            try
            {
                var preferencia = bd.preferencia.Where(x => x.FK_usuario == UsuarioDados.Id).FirstOrDefault();

                if (preferencia.privacidade == true)
                {
                    InscreverNaVaga();
                }
                else
                {
                    Mensagem.aviso = "Você desativou as inscrições!";
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

        private void lblVaga_Paint(object sender, PaintEventArgs e)
        {
            int x = (p_barra.Size.Width - lblVaga.Width) / 2;
            int y = (p_barra.Size.Height - lblVaga.Height);              //Posição da label no form

            lblVaga.Location = new Point(x, y);
        }

        private void lblVaga_Resize(object sender, EventArgs e)
        {
            int x = (p_barra.Size.Width - lblVaga.Width) / 2;
            int y = (p_barra.Size.Height - lblVaga.Height);              //Posição da label no form

            lblVaga.Location = new Point(x, y);
        }

        private void btConf_Click(object sender, EventArgs e)
        {
            try
            {
                var usuario = bd.usuario_trabalhador.Where(x => x.FK_usuario == UsuarioDados.Id).FirstOrDefault();

                if (usuario != null)
                {
                    var cand = bd.candidatos.Where(x => x.FK_usuario_trabalhador == usuario.CPF).Where(y => y.FK_evento == PegarIDVaga.IDVaga).FirstOrDefault();
                    bd.candidatos.Remove(cand);
                    bd.SaveChanges();
                }

                pLixeira.Visible = false;
                lblInscricao.Text = "Inscrever-se";
                pbInscricao.Image = Properties.Resources.inscricao;
                lblInscricao.BackColor = Color.FromArgb(92, 104, 225);

                Mensagem.aviso = "Desinscrição realizada com sucesso!";
                TelaMensagemAviso f = new TelaMensagemAviso();
                f.ShowDialog();

                JaPossui = false;
            }
            catch (Exception)
            {
                Mensagem.aviso = "Erro de conexão com o banco!";
                TelaMensagemAviso f = new TelaMensagemAviso();
                f.ShowDialog();
            }
        }

        private void btCancelar1_Click(object sender, EventArgs e)
        {
            pLixeira.Visible = false;
        }
    }
}
