using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Pismire_TCC.Resources;

namespace Pismire_TCC
{
    public partial class TelaEventosCriados : Form
    {
        PismireEntities5 bd = new PismireEntities5();

        public TelaEventosCriados()
        {
            InitializeComponent();
            Maximizacao.verifique(this, pbMaximizar);   //Verifica se a tela está maximizada ou não

            try
            {
                var usu = bd.usuario.Where(x => x.idUsuario == UsuarioDados.Id).FirstOrDefault();

                if (usu.tipoUsuario == true)
                {
                    pbEdicao.Visible = false;
                    pbLixeira.Visible = false;
                    lb_eventosCriados.Text = "Vagas";
                    pbInteressado.Location = new Point(1282, 671);
                    var usuario = bd.usuario_empresa.Where(x => x.FK_usuario == PegarIDEmpresa.IDEmpresa).FirstOrDefault();
                    var FK = usuario.cnpj;

                    int qtd = Convert.ToInt32(bd.evento.Count     //Número de idiomas
                    (x => x.FK_usuario_empresa == FK.ToString()));

                    if (qtd != 0)
                    {
                        try
                        {
                            int max = bd.evento.Max(x => x.idEvento); //Maior ID

                            var dt1 = new DataTable();

                            dt1.Columns.Add("ID_evento");
                            dt1.Columns.Add("Expiração");
                            dt1.Columns.Add("Área");           //Cria as Colunas
                            dt1.Columns.Add("Vaga");
                            dt1.Columns.Add("Salário");
                            dt1.Columns.Add("Turno");


                            for (int i = 1; i <= max; i++)
                            {
                                var evento = bd.evento.Where(y => y.FK_usuario_empresa ==
                                FK).Where(x => x.idEvento == i).FirstOrDefault();

                                if (evento != null)
                                {
                                    DateTime inicial = Convert.ToDateTime(evento.dataInicialEvento);

                                    DateTime final = Convert.ToDateTime(evento.dataFinalEvento);

                                    DateTime dataAtual = (DateTime.Today).Date;

                                    System.TimeSpan expiracao = final.Subtract(dataAtual);              //Carregamento de eventos

                                    String data = expiracao.ToString();

                                    String resultado;

                                    if (evento.dataFinalEvento > dataAtual)
                                    {
                                        if (data.StartsWith(((data.Substring(0, 1)).ToString()) + "."))
                                        {
                                            if (data.StartsWith("1."))
                                            {
                                                resultado = ("1 dia");
                                            }
                                            else
                                            {
                                                resultado = (data.Substring(0, 1).ToString()) + " dias";
                                            }
                                        }
                                        else
                                        {
                                            if (data.StartsWith(((data.Substring(0, 2)).ToString()) + "."))
                                            {
                                                resultado = (data.Substring(0, 2).ToString()) + " dias";
                                            }
                                            else
                                            {
                                                if (data.StartsWith(((data.Substring(0, 3)).ToString()) + "."))
                                                {
                                                    resultado = (data.Substring(0, 3).ToString()) + " dias";
                                                }
                                                else
                                                {
                                                    resultado = expiracao.ToString();
                                                }
                                            }
                                        }
                                    }
                                    else if (evento.dataFinalEvento == dataAtual)
                                    {
                                        resultado = "Termina hoje";
                                    }
                                    else
                                    {
                                        resultado = "Expirado";
                                    }

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

                                    string salario = "R$: " + (txt);

                                    dt1.Rows.Add(evento.idEvento, resultado, evento.areaEvento,
                                    evento.vagaEvento, salario, evento.turno);

                                    dt.DataSource = dt1; //Conecta com o GridView

                                    this.dt.Columns["ID_evento"].Visible = false;
                                }
                            }
                        }
                        catch (Exception)
                        {
                            Mensagem.aviso = "Erro ao carregar!";
                            TelaMensagemAviso f = new TelaMensagemAviso();
                            f.ShowDialog();
                        }
                    }
                    else
                    {
                        lblAviso.Visible = true;
                        pbEdicao.Enabled = false;
                        pbLixeira.Enabled = false;
                        dt.Visible = false;
                        pbLixeira.Visible = false;
                        pbEdicao.Visible = false;
                        pCabecalho.Visible = false;
                    }
                }
                else
                {
                    var usuario = bd.usuario_empresa.Where(x => x.FK_usuario == UsuarioDados.Id).FirstOrDefault();
                    var FK = usuario.cnpj;
                    pbInteressado.Visible = false;
                    int qtd = Convert.ToInt32(bd.evento.Count     //Número de idiomas
                    (x => x.FK_usuario_empresa == FK.ToString()));

                    if (qtd != 0)
                    {
                        try
                        {
                            int max = bd.evento.Max(x => x.idEvento); //Maior ID

                            var dt1 = new DataTable();

                            dt1.Columns.Add("ID_evento");
                            dt1.Columns.Add("Expiração");
                            dt1.Columns.Add("Área");           //Cria as Colunas
                            dt1.Columns.Add("Vaga");
                            dt1.Columns.Add("Salário");
                            dt1.Columns.Add("Turno");


                            for (int i = 1; i <= max; i++)
                            {
                                var evento = bd.evento.Where(y => y.FK_usuario_empresa ==
                                FK).Where(x => x.idEvento == i).FirstOrDefault();

                                if (evento != null)
                                {
                                    DateTime inicial = Convert.ToDateTime(evento.dataInicialEvento);

                                    DateTime final = Convert.ToDateTime(evento.dataFinalEvento);

                                    DateTime dataAtual = (DateTime.Today).Date;

                                    System.TimeSpan expiracao = final.Subtract(dataAtual);              //Carregamento de eventos

                                    String data = expiracao.ToString();

                                    String resultado;

                                    if (evento.dataFinalEvento > dataAtual)
                                    {
                                        if (data.StartsWith(((data.Substring(0, 1)).ToString()) + "."))
                                        {
                                            if (data.StartsWith("1."))
                                            {
                                                resultado = ("1 dia");
                                            }
                                            else
                                            {
                                                resultado = (data.Substring(0, 1).ToString()) + " dias";
                                            }
                                        }
                                        else
                                        {
                                            if (data.StartsWith(((data.Substring(0, 2)).ToString()) + "."))
                                            {
                                                resultado = (data.Substring(0, 2).ToString()) + " dias";
                                            }
                                            else
                                            {
                                                if (data.StartsWith(((data.Substring(0, 3)).ToString()) + "."))
                                                {
                                                    resultado = (data.Substring(0, 3).ToString()) + " dias";
                                                }
                                                else
                                                {
                                                    resultado = expiracao.ToString();
                                                }
                                            }
                                        }
                                    }
                                    else if (evento.dataFinalEvento == dataAtual)
                                    {
                                        resultado = "Termina hoje";
                                    }
                                    else
                                    {
                                        resultado = "Expirado";
                                    }

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

                                    string salario = "R$: " + (txt);

                                    dt1.Rows.Add(evento.idEvento, resultado, evento.areaEvento,
                                    evento.vagaEvento, salario, evento.turno);

                                    dt.DataSource = dt1; //Conecta com o GridView

                                    this.dt.Columns["ID_evento"].Visible = false;
                                }
                            }
                        }
                        catch (Exception)
                        {
                            Mensagem.aviso = "Erro ao carregar!";
                            TelaMensagemAviso f = new TelaMensagemAviso();
                            f.ShowDialog();
                        }
                    }
                    else
                    {
                        lblAviso.Visible = true;
                        pbEdicao.Enabled = false;
                        pbLixeira.Enabled = false;
                        dt.Visible = false;
                        pbLixeira.Visible = false;
                        pbEdicao.Visible = false;
                        pCabecalho.Visible = false;
                    }
                }
            }
            catch (Exception)
            {
                Mensagem.aviso = "Erro ao conectar com o banco!";
                TelaMensagemAviso f = new TelaMensagemAviso();
                f.ShowDialog();
            }
        }

        private void pb_apagar_Click(object sender, EventArgs e)
        {
            if (pLixeira.Visible == false)
            {
                //Teste para situação vazia

                pLixeira.Visible = true;
                pbLixeira.Enabled = false;
                pbEdicao.Enabled = false;
                pbVoltar.Enabled = false;
                dt.Enabled = false;
            }
        }

        private void pb_voltar_Click(object sender, EventArgs e)
        {
            var usuario = bd.usuario.Where(x => x.idUsuario == UsuarioDados.Id).Where(y => y.tipoUsuario == true).FirstOrDefault();
            if (usuario != null)
            {
                this.Hide();
                TelaPrincipalTrabalhador f = new TelaPrincipalTrabalhador();   //Voltar para tela principal trabalhador
                f.Closed += (s, args) => this.Close();
                f.ShowDialog();
            }
            else
            {
                this.Hide();
                TelaPrincipalEmpresa f = new TelaPrincipalEmpresa();   //Voltar para tela principal empresa
                f.Closed += (s, args) => this.Close();
                f.ShowDialog();
            }
            
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            pLixeira.Visible = false;
            pbLixeira.Enabled = true;
            pbEdicao.Enabled = true;
            pbVoltar.Enabled = true;         //Cancelar exclusão
            dt.Enabled = true;
        }

        private void btConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblAviso.Visible == false)
                {
                    //Teste para situação vazia

                    var usuario = bd.usuario_empresa.Where(x => x.FK_usuario == UsuarioDados.Id).FirstOrDefault();
                    var FK = usuario.cnpj;

                    int qtd = Convert.ToInt32(bd.evento.Count(x => x.FK_usuario_empresa == FK));

                    if (qtd != 1)
                    {
                        PegarID.IDN = Convert.ToInt32(dt.CurrentRow.Cells[0].Value);

                        var evento = bd.evento.Where(x => x.idEvento == PegarID.IDN).FirstOrDefault();
                        var idioma = bd.idioma_evento.Where(x => x.FK_evento == PegarID.IDN).FirstOrDefault();
                        var exp = bd.experiencia_profissional_evento.Where(x => x.FK_evento == PegarID.IDN).FirstOrDefault();
                        var expInt = bd.experiencia_internacional_evento.Where(x => x.FK_evento == PegarID.IDN).FirstOrDefault();
                        var qua = bd.qualificacao_evento.Where(x => x.FK_evento == PegarID.IDN).FirstOrDefault();
                        var beneficios = bd.beneficios.Where(x => x.FK_evento == PegarID.IDN).FirstOrDefault();
                        var recoendacoes = bd.recomendados_empresa.Where(x => x.FK_usuario_empresa == evento.FK_usuario_empresa)
                        .FirstOrDefault();
                        var recoendacoes2 = bd.recomendados_trabalhador.Where(x => x.FK_usuario_empresa == evento.FK_usuario_empresa).FirstOrDefault();
                        var interresados = bd.interessados_trabalhador.Where(x => x.FK_evento == PegarID.IDN).FirstOrDefault();
                        //Exclui o evento

                        if (evento != null)
                        {
                            if (idioma != null)
                            {
                                int idiomaMax = bd.idioma_evento.Max(x => x.idIdiomaEvento);

                                for (int i = 1; i <= idiomaMax; i++)
                                {
                                    var idiomaSel = bd.idioma_evento.Where(x => x.FK_evento == PegarID.IDN).   //Exclui todos os idiomas do evento
                                    Where(x => x.idIdiomaEvento == i).FirstOrDefault();

                                    if (idiomaSel != null)
                                    {
                                        bd.idioma_evento.Remove(idiomaSel);
                                        bd.SaveChanges();
                                    }
                                }
                            }

                            if (exp != null)
                            {
                                int expMax = bd.experiencia_profissional_evento.Max(x => x.idExperienciaEvento);

                                for (int i = 1; i <= expMax; i++)
                                {
                                    var ExpSel = bd.experiencia_profissional_evento.Where(x => x.FK_evento == PegarID.IDN).   //Exclui todas as exp do evento
                                    Where(x => x.idExperienciaEvento == i).FirstOrDefault();

                                    if (ExpSel != null)
                                    {
                                        bd.experiencia_profissional_evento.Remove(ExpSel);
                                        bd.SaveChanges();
                                    }
                                }
                            }

                            if (expInt != null)
                            {
                                int expIntMax = bd.experiencia_internacional_evento.Max(x => x.idInternacionalEvento);

                                for (int i = 1; i <= expIntMax; i++)
                                {
                                    var ExpIntSel = bd.experiencia_internacional_evento.Where(x => x.FK_evento ==
                                    PegarID.IDN).Where(x => x.idInternacionalEvento == i).FirstOrDefault(); //Exclui todas as exp int do evento

                                    if (ExpIntSel != null)
                                    {
                                        bd.experiencia_internacional_evento.Remove(ExpIntSel);
                                        bd.SaveChanges();
                                    }
                                }
                            }

                            if (qua != null)
                            {
                                int quaMax = bd.qualificacao_evento.Max(x => x.idQualificacaoEvento);

                                for (int i = 1; i <= quaMax; i++)
                                {
                                    var quaSel = bd.qualificacao_evento.Where(x => x.FK_evento ==
                                    PegarID.IDN).Where(x => x.idQualificacaoEvento == i).FirstOrDefault();

                                    //Exclui todas as qualificoes do evento

                                    if (quaSel != null)
                                    {
                                        bd.qualificacao_evento.Remove(quaSel);
                                        bd.SaveChanges();
                                    }
                                }
                            }

                            if (beneficios != null)
                            {
                                bd.beneficios.Remove(beneficios);
                                bd.SaveChanges();
                            }

                            var testeCand = bd.candidatos.Where(x => x.FK_evento == PegarID.IDN).FirstOrDefault();

                            if (testeCand != null)
                            {
                                int maxCand = Convert.ToInt32(bd.candidatos.Max(x => x.idCandidatos));

                                for (int i = 1; i <= maxCand; i++)
                                {
                                    var candidatos = bd.candidatos.Where(x => x.FK_evento == PegarID.IDN).Where(x => x.idCandidatos == i).FirstOrDefault();

                                    if (candidatos != null)
                                    {
                                        bd.candidatos.Remove(candidatos);
                                        bd.SaveChanges();
                                    }
                                }
                            }

                            var testeRec = bd.recomendados_empresa.Where(x => x.FK_usuario_empresa == evento.FK_usuario_empresa).FirstOrDefault();

                            if (testeRec != null)
                            {
                                int maxRec = Convert.ToInt32(bd.recomendados_empresa.Max(x => x.IdRecomendadosEmpresa));

                                for (int i = 1; i <= maxRec; i++)
                                {
                                    var recomendados = bd.recomendados_empresa.Where(x => x.FK_usuario_empresa == evento.FK_usuario_empresa)
                                    .Where(x => x.IdRecomendadosEmpresa == i).FirstOrDefault();

                                    if (recomendados != null)
                                    {
                                        bd.recomendados_empresa.Remove(recomendados);
                                        bd.SaveChanges();
                                    }
                                }
                            }

                            var testeRec2 = bd.recomendados_trabalhador.Where(x => x.FK_usuario_empresa == evento.FK_usuario_empresa).FirstOrDefault();

                            if (testeRec2 != null)
                            {
                                int maxRec2 = Convert.ToInt32(bd.recomendados_trabalhador.Max(x => x.idRecomendadosTrabalhador));

                                for (int i = 1; i <= maxRec2; i++)
                                {
                                    var recomendados2 = bd.recomendados_trabalhador.Where(x => x.FK_usuario_empresa == evento.FK_usuario_empresa)
                                    .Where(x => x.idRecomendadosTrabalhador == i).FirstOrDefault();

                                    if (recomendados2 != null)
                                    {
                                        bd.recomendados_trabalhador.Remove(recomendados2);
                                        bd.SaveChanges();
                                    }
                                }
                            }

                            var testeInt = bd.interessados_trabalhador.Where(x => x.FK_evento == PegarID.IDN).FirstOrDefault();

                            if (testeInt != null)
                            {
                                int maxInt = Convert.ToInt32(bd.interessados_trabalhador.Max(x => x.idInteressadosTrabalhador));

                                for (int i = 1; i <= maxInt; i++)
                                {
                                    var interessados = bd.interessados_trabalhador.Where(x => x.FK_evento == PegarID.IDN)
                                    .Where(x => x.idInteressadosTrabalhador == i).FirstOrDefault();

                                    if (interessados != null)
                                    {
                                        bd.interessados_trabalhador.Remove(interessados);
                                        bd.SaveChanges();
                                    }
                                }
                            }
                        }

                        try
                        {

                            int max = bd.evento.Max(x => x.idEvento);

                            var dt1 = new DataTable();

                            dt1.Columns.Add("idEvento");
                            dt1.Columns.Add("expiracao");
                            dt1.Columns.Add("areaEvento");           //Cria as Colunas
                            dt1.Columns.Add("vagaEvento");
                            dt1.Columns.Add("salario");
                            dt1.Columns.Add("turno");
                            dt1.Columns.Add("FK_usuario_empresa");

                            for (int i = 1; i <= max; i++)

                            {
                                var evento2 = bd.evento.Where(y => y.FK_usuario_empresa ==
                                FK).Where(x => x.idEvento == i).FirstOrDefault();

                                if (evento2 != null)
                                {
                                    DateTime inicial = Convert.ToDateTime(evento.dataInicialEvento);

                                    DateTime final = Convert.ToDateTime(evento.dataFinalEvento);

                                    DateTime dataAtual = (DateTime.Today).Date;  //Carregamento dos eventos

                                    System.TimeSpan expiracao = final.Subtract(dataAtual);

                                    String data = expiracao.ToString();

                                    String resultado;

                                    if (evento.dataFinalEvento > dataAtual)
                                    {
                                        if (data.StartsWith(((data.Substring(0, 1)).ToString()) + "."))
                                        {
                                            if (data.StartsWith("1."))
                                            {
                                                resultado = ("1 dia");
                                            }
                                            else
                                            {
                                                resultado = (data.Substring(0, 1).ToString()) + " dias";
                                            }
                                        }
                                        else
                                        {
                                            if (data.StartsWith(((data.Substring(0, 2)).ToString()) + "."))
                                            {
                                                resultado = (data.Substring(0, 2).ToString()) + " dias";
                                            }
                                            else
                                            {
                                                if (data.StartsWith(((data.Substring(0, 3)).ToString()) + "."))
                                                {
                                                    resultado = (data.Substring(0, 3).ToString()) + " dias";
                                                }
                                                else
                                                {
                                                    resultado = expiracao.ToString();
                                                }
                                            }
                                        }
                                    }
                                    else if (evento.dataFinalEvento == dataAtual)
                                    {
                                        resultado = "Termina hoje";
                                    }
                                    else
                                    {
                                        resultado = "Expirado";
                                    }

                                    string salario = "R$: " + (evento.salario.ToString());

                                    dt1.Rows.Add(evento2.idEvento, resultado, evento2.areaEvento,
                                    evento2.vagaEvento, salario, evento2.turno, evento2.FK_usuario_empresa);

                                    dt.DataSource = dt1; //Conecta com o GridView

                                    this.dt.Columns["idEvento"].Visible = false;
                                    this.dt.Columns["FK_usuario_empresa"].Visible = false;               //Tira as que não precisa

                                    this.dt.Columns["expiracao"].FillWeight = 70;
                                    this.dt.Columns["areaEvento"].FillWeight = 70;
                                    this.dt.Columns["vagaEvento"].FillWeight = 70;
                                    this.dt.Columns["salario"].FillWeight = 70;      //Ajusta o tamanho
                                    this.dt.Columns["turno"].FillWeight = 70;

                                }
                            }

                            pLixeira.Visible = false;
                            pbLixeira.Enabled = true;
                            pbEdicao.Enabled = true;
                            pbVoltar.Enabled = true;
                            dt.Enabled = true;
                            Mensagem.aviso = "Excluído com sucesso!";
                            TelaMensagemAviso f = new TelaMensagemAviso();
                            f.ShowDialog();

                        }
                        catch (Exception)
                        {
                            pLixeira.Visible = false;
                            pbLixeira.Enabled = true;
                            pbEdicao.Enabled = true;
                            pbVoltar.Enabled = true;
                            dt.Enabled = true;
                            Mensagem.aviso = "Erro ao excluir!";
                            TelaMensagemAviso f = new TelaMensagemAviso();
                            f.ShowDialog();
                        }
                    }
                    else
                    {
                        try
                        {
                            PegarID.IDN = Convert.ToInt32(dt.CurrentRow.Cells[0].Value);

                            var evento = bd.evento.Where(x => x.idEvento == PegarID.IDN).FirstOrDefault();
                            var idioma = bd.idioma_evento.Where(x => x.FK_evento == PegarID.IDN).FirstOrDefault();
                            var exp = bd.experiencia_profissional_evento.Where(x => x.FK_evento == PegarID.IDN).FirstOrDefault();
                            var expInt = bd.experiencia_internacional_evento.Where(x => x.FK_evento == PegarID.IDN).FirstOrDefault();
                            var qua = bd.qualificacao_evento.Where(x => x.FK_evento == PegarID.IDN).FirstOrDefault();
                            var beneficios = bd.beneficios.Where(x => x.FK_evento == PegarID.IDN).FirstOrDefault();
                            var recoendacoes = bd.recomendados_empresa.Where(x => x.FK_usuario_empresa ==
                            evento.FK_usuario_empresa).FirstOrDefault();
                            var recoendacoes2 = bd.recomendados_trabalhador.Where(x => x.FK_usuario_empresa ==
                            evento.FK_usuario_empresa).FirstOrDefault();
                            var interresados = bd.interessados_trabalhador.Where(x => x.FK_evento == PegarID.IDN).FirstOrDefault();

                            //Exclui o evento

                            if (evento != null)
                            {
                                if (idioma != null)
                                {
                                    int idiomaMax = bd.idioma_evento.Max(x => x.idIdiomaEvento);

                                    for (int i = 1; i <= idiomaMax; i++)
                                    {
                                        var idiomaSel = bd.idioma_evento.Where(x => x.FK_evento == PegarID.IDN).   //Exclui todos os idiomas do evento
                                        Where(x => x.idIdiomaEvento == i).FirstOrDefault();

                                        if (idiomaSel != null)
                                        {
                                            bd.idioma_evento.Remove(idiomaSel);
                                            bd.SaveChanges();
                                        }
                                    }
                                }

                                if (exp != null)
                                {
                                    int expMax = bd.experiencia_profissional_evento.Max(x => x.idExperienciaEvento);

                                    for (int i = 1; i <= expMax; i++)
                                    {
                                        var ExpSel = bd.experiencia_profissional_evento.Where(x => x.FK_evento == PegarID.IDN).   //Exclui todas as exp do evento
                                        Where(x => x.idExperienciaEvento == i).FirstOrDefault();

                                        if (ExpSel != null)
                                        {
                                            bd.experiencia_profissional_evento.Remove(ExpSel);
                                            bd.SaveChanges();
                                        }
                                    }
                                }

                                if (expInt != null)
                                {
                                    int expIntMax = bd.experiencia_internacional_evento.Max(x => x.idInternacionalEvento);

                                    for (int i = 1; i <= expIntMax; i++)
                                    {
                                        var ExpIntSel = bd.experiencia_internacional_evento.Where(x => x.FK_evento ==
                                        PegarID.IDN).Where(x => x.idInternacionalEvento == i).FirstOrDefault(); //Exclui todas as exp int do evento

                                        if (ExpIntSel != null)
                                        {
                                            bd.experiencia_internacional_evento.Remove(ExpIntSel);
                                            bd.SaveChanges();
                                        }
                                    }
                                }

                                if (qua != null)
                                {
                                    int quaMax = bd.qualificacao_evento.Max(x => x.idQualificacaoEvento);

                                    for (int i = 1; i <= quaMax; i++)
                                    {
                                        var quaSel = bd.qualificacao_evento.Where(x => x.FK_evento ==
                                        PegarID.IDN).Where(x => x.idQualificacaoEvento == i).FirstOrDefault();

                                        //Exclui todas as qualificoes do evento

                                        if (quaSel != null)
                                        {
                                            bd.qualificacao_evento.Remove(quaSel);
                                            bd.SaveChanges();
                                        }
                                    }
                                }

                                if (beneficios != null)
                                {
                                    bd.beneficios.Remove(beneficios);
                                    bd.SaveChanges();
                                }

                                var testeCand = bd.candidatos.Where(x => x.FK_evento == PegarID.IDN).FirstOrDefault();

                                if (testeCand != null)
                                {
                                    int maxCand = Convert.ToInt32(bd.candidatos.Max(x => x.idCandidatos));

                                    for (int i = 1; i <= maxCand; i++)
                                    {
                                        var candidatos = bd.candidatos.Where(x => x.FK_evento == PegarID.IDN).Where(x => x.idCandidatos == i).FirstOrDefault();

                                        if (candidatos != null)
                                        {
                                            bd.candidatos.Remove(candidatos);
                                            bd.SaveChanges();
                                        }
                                    }
                                }

                                var testeRec = bd.recomendados_empresa.Where(x => x.FK_usuario_empresa == evento.FK_usuario_empresa).FirstOrDefault();

                                if (testeRec != null)
                                {
                                    int maxRec = Convert.ToInt32(bd.recomendados_empresa.Max(x => x.IdRecomendadosEmpresa));

                                    for (int i = 1; i <= maxRec; i++)
                                    {
                                        var recomendados = bd.recomendados_empresa.Where(x => x.FK_usuario_empresa == evento.FK_usuario_empresa)
                                        .Where(x => x.IdRecomendadosEmpresa == i).FirstOrDefault();

                                        if (recomendados != null)
                                        {
                                            bd.recomendados_empresa.Remove(recomendados);
                                            bd.SaveChanges();
                                        }
                                    }
                                }

                                var testeRec2 = bd.recomendados_trabalhador.Where(x => x.FK_usuario_empresa == evento.FK_usuario_empresa).FirstOrDefault();

                                if (testeRec2 != null)
                                {
                                    int maxRec2 = Convert.ToInt32(bd.recomendados_trabalhador.Max(x => x.idRecomendadosTrabalhador));

                                    for (int i = 1; i <= maxRec2; i++)
                                    {
                                        var recomendados2 = bd.recomendados_trabalhador.Where(x => x.FK_usuario_empresa == evento.FK_usuario_empresa)
                                        .Where(x => x.idRecomendadosTrabalhador == i).FirstOrDefault();

                                        if (recomendados2 != null)
                                        {
                                            bd.recomendados_trabalhador.Remove(recomendados2);
                                            bd.SaveChanges();
                                        }
                                    }
                                }

                                var testeInt = bd.interessados_trabalhador.Where(x => x.FK_evento == PegarID.IDN).FirstOrDefault();

                                if (testeInt != null)
                                {
                                    int maxInt = Convert.ToInt32(bd.interessados_trabalhador.Max(x => x.idInteressadosTrabalhador));

                                    for (int i = 1; i <= maxInt; i++)
                                    {
                                        var interessados = bd.interessados_trabalhador.Where(x => x.FK_evento == PegarID.IDN)
                                        .Where(x => x.idInteressadosTrabalhador == i).FirstOrDefault();

                                        if (interessados != null)
                                        {
                                            bd.interessados_trabalhador.Remove(interessados);
                                            bd.SaveChanges();
                                        }
                                    }
                                }

                                bd.evento.Remove(evento);
                                bd.SaveChanges();
                            }

                            dt.Columns.Clear();
                            pLixeira.Visible = false;
                            pbLixeira.Enabled = true;
                            pbEdicao.Enabled = true;
                            pbVoltar.Enabled = true;
                            dt.Enabled = true;
                            pbLixeira.Visible = false;
                            pbEdicao.Visible = false;
                            dt.Visible = false;
                            lblAviso.Visible = true;
                            pCabecalho.Visible = false;
                            Mensagem.aviso = "Excluído com sucesso!";
                            TelaMensagemAviso f = new TelaMensagemAviso();
                            f.ShowDialog();
                        }
                        catch
                        {
                            pLixeira.Visible = false;
                            pbLixeira.Enabled = true;
                            pbEdicao.Enabled = true;
                            pbVoltar.Enabled = true;
                            dt.Enabled = true;
                            Mensagem.aviso = "Erro ao excluir!";
                            TelaMensagemAviso f = new TelaMensagemAviso();
                            f.ShowDialog();
                        }
                    }
                }
            }
            catch (Exception)
            {
                Mensagem.aviso = "Erro ao conectar com o banco!";
                TelaMensagemAviso f = new TelaMensagemAviso();
                f.ShowDialog();
            }
        }

        private void pVoltar_MouseEnter(object sender, EventArgs e)
        {
            pbVoltar.Image = Properties.Resources.VoltarRoxo;               //Animações de voltar
        }

        private void pVoltar_MouseLeave(object sender, EventArgs e)
        {
            pbVoltar.Image = Properties.Resources.voltar;
        }

        private void alinhamentoCabecalho()
        {
            int largura = pCabecalho.Size.Width;

            int tamanhoEspaco = largura / 5;

            lblCabecalho1.Size = new System.Drawing.Size(tamanhoEspaco, 43);
            lblCabecalho2.Size = new System.Drawing.Size(tamanhoEspaco, 43);        //Alinhamento da grid -> cabeçalho
            lblCabecalho3.Size = new System.Drawing.Size(tamanhoEspaco, 43);
            lblCabecalho4.Size = new System.Drawing.Size(tamanhoEspaco, 43);
            lblCabecalho5.Size = new System.Drawing.Size(tamanhoEspaco, 43);

            lblCabecalho1.Location = new Point(2, 15);
            lblCabecalho2.Location = new Point(tamanhoEspaco + 2, 15);
            lblCabecalho3.Location = new Point(((tamanhoEspaco * 2) + 2), 15);
            lblCabecalho4.Location = new Point(((tamanhoEspaco * 3) + 2), 15);
            lblCabecalho5.Location = new Point(((tamanhoEspaco * 4) + 2), 15);
        }

        private void pCabecalho_Paint(object sender, PaintEventArgs e)
        {
            alinhamentoCabecalho();
        }

        private void pCabecalho_Resize(object sender, EventArgs e)
        {
            alinhamentoCabecalho();
        }

        private void lb_eventosCriados_Resize(object sender, EventArgs e)
        {
            int x = (p_barra.Size.Width - lb_eventosCriados.Width) / 2;
            int y = (p_barra.Size.Height - lb_eventosCriados.Height);              //Posição da label na barra

            lb_eventosCriados.Location = new Point(x, y);
        }

        private void pbEdicao_MouseEnter(object sender, EventArgs e)
        {
            pbEdicao.Image = Properties.Resources.editarRoxo;
        }     

        private void pbEdicao_MouseLeave(object sender, EventArgs e)
        {
            pbEdicao.Image = Properties.Resources.editar1;
        }

        private void pbLixeira_MouseEnter(object sender, EventArgs e)
        {
            pbLixeira.Image = Properties.Resources.excluirRoxo;
        }

        private void pbLixeira_MouseLeave(object sender, EventArgs e)
        {
            pbLixeira.Image = Properties.Resources.excluir;
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
            btCancelar.ForeColor = Color.Black;                                    //Animação de botões
        }

        private void btCancelar_MouseLeave(object sender, EventArgs e)
        {
            btCancelar.ForeColor = Color.White;
        }

        private void dt_KeyDown(object sender, KeyEventArgs e)
        {
            var usuario = bd.usuario.Where(x => x.idUsuario == UsuarioDados.Id).Where(y => y.tipoUsuario == true).FirstOrDefault();
            if (usuario != null)
            {
                VisualizarEvento();
            }
            else
            {
                abrirEvento();
            }
        }

        private void dt_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var usuario = bd.usuario.Where(x => x.idUsuario == UsuarioDados.Id).Where(y => y.tipoUsuario == true).FirstOrDefault();
            if (usuario != null)
            {
                VisualizarEvento();
            }
            else
            {
                abrirEvento();
            }
        }

        private void VisualizarEvento()
        {
            try
            {
                var empresa = bd.usuario_empresa.Where(x => x.FK_usuario == PegarIDEmpresa.IDEmpresa).FirstOrDefault();

                PegarIDVaga.IDVaga = Convert.ToInt32(dt.CurrentRow.Cells[0].Value);    //Abre o evento para edição
                var evento = bd.evento.Where(y => y.FK_usuario_empresa == empresa.cnpj).Where(x => x.idEvento == PegarIDVaga.IDVaga).FirstOrDefault();

                this.Hide();
                TelaVisualizacaoVagas f = new TelaVisualizacaoVagas();
                f.Closed += (s, args) => this.Close();
                f.ShowDialog();
            }
            catch (Exception)
            {
                Mensagem.aviso = "Erro ao conectar com o banco!";
                TelaMensagemAviso f = new TelaMensagemAviso();
                f.ShowDialog();
            }
        }

        private void pbEdicao_Click(object sender, EventArgs e)
        {
            abrirEvento();
        }

        private void abrirEvento()
        {
            try
            {
                var empresa = bd.usuario_empresa.Where(x => x.FK_usuario == UsuarioDados.Id).FirstOrDefault();

                EditarEvento.ID = Convert.ToInt32(dt.CurrentRow.Cells[0].Value);    //Abre o evento para edição
                var evento = bd.evento.Where(y => y.FK_usuario_empresa ==
                empresa.cnpj).Where(x => x.idEvento == EditarEvento.ID).FirstOrDefault();

                EditarEvento.passouEvento = true;

                this.Hide();
                TelaEvento f = new TelaEvento();
                f.Closed += (s, args) => this.Close();
                f.ShowDialog();
            }
            catch (Exception)
            {
                Mensagem.aviso = "Erro ao conectar com o banco!";
                TelaMensagemAviso f = new TelaMensagemAviso();
                f.ShowDialog();
            }
        }

        private void p_barra_Resize(object sender, EventArgs e)
        {
            int x = (p_barra.Size.Width - lb_eventosCriados.Width) / 2;
            int y = (p_barra.Size.Height - lb_eventosCriados.Height);              //Posição da label na barra ao maximizar

            lb_eventosCriados.Location = new Point(x, y);
        }

        private void p_barra_Paint(object sender, PaintEventArgs e)
        {
            int x = (p_barra.Size.Width - lb_eventosCriados.Width) / 2;
            int y = (p_barra.Size.Height - lb_eventosCriados.Height);              //Posição da label na barra

            lb_eventosCriados.Location = new Point(x, y);
        }

        private void pbInteressado_Click(object sender, EventArgs e)
        {
            var usuario = bd.usuario_trabalhador.Where(x => x.FK_usuario == UsuarioDados.Id).FirstOrDefault();
            if (usuario != null)
            {
                int FK_Evento = Convert.ToInt32(dt.CurrentRow.Cells[0].Value);
                var interesse = bd.interessados_trabalhador.Where(x => x.FK_evento == FK_Evento).Where(y => y.FK_usuario_trabalhador == usuario.CPF).FirstOrDefault();
                if (interesse == null)
                {
                    interessados_trabalhador f = new interessados_trabalhador();
                    f.FK_usuario_trabalhador = usuario.CPF;
                    f.FK_evento = FK_Evento;

                    bd.interessados_trabalhador.Add(f);
                    bd.SaveChanges();

                    Mensagem.aviso = "Salvo com sucesso!";
                    TelaMensagemAviso t = new TelaMensagemAviso();
                    t.ShowDialog();
                }
                else
                {
                    Mensagem.aviso = "Você ja possui esse evento salvo!";
                    TelaMensagemAviso t = new TelaMensagemAviso();
                    t.ShowDialog();
                }
            }
            else
            {
                Mensagem.aviso = "Você não possui um curriculo cadastrado!";
                TelaMensagemAviso f = new TelaMensagemAviso();
                f.ShowDialog();
            }
        }

        private void pbInteressado_MouseEnter(object sender, EventArgs e)
        {
            pbInteressado.Image = Properties.Resources.interessado_roxo;
        }

        private void pbInteressado_MouseHover(object sender, EventArgs e)
        {
            pbInteressado.Image = Properties.Resources.interessado_roxo;
        }

        private void pbInteressado_MouseLeave(object sender, EventArgs e)
        {
            pbInteressado.Image = Properties.Resources.interessados;
        }
    }
}
