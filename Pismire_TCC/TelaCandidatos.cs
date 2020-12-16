using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Pismire_TCC.Resources;

namespace Pismire_TCC
{
    public partial class TelaCandidatos : Form
    {
        PismireEntities5 bd = new PismireEntities5();

        public TelaCandidatos()
        {
            InitializeComponent();
            Maximizacao.verifique(this, pbMaximizar);   //Verifica se a tela está maximizada ou não

            try
            {
                var usuEmp = bd.usuario_empresa.Where(x => x.FK_usuario == UsuarioDados.Id).FirstOrDefault();
                string FK = usuEmp.cnpj;

                int testeEvento = bd.evento.Count(x => x.FK_usuario_empresa == usuEmp.cnpj);

                if (testeEvento != 0)
                {
                    int max = bd.evento.Max(x => x.idEvento);
                    int qtd = 0;                                              //Carrega todos os canditados da empresa

                    for (int i = 1; i <= max; i++)
                    {
                        var empresa = bd.usuario_empresa.Where(x => x.FK_usuario == UsuarioDados.Id).FirstOrDefault();
                        var evento = bd.evento.Where(x => x.FK_usuario_empresa == empresa.cnpj).Where(x => x.idEvento == i).FirstOrDefault();

                        if (evento != null)
                        {
                            qtd = qtd + Convert.ToInt32(bd.candidatos.Count(x => x.FK_evento == evento.idEvento));
                        }
                    }

                    if (qtd != 0)
                    {
                        int max2 = Convert.ToInt32(bd.candidatos.Max(x => x.idCandidatos));

                        var empresa = bd.usuario_empresa.Where(x => x.FK_usuario == UsuarioDados.Id).FirstOrDefault();
                        var evento = bd.evento.Select(x => x.FK_usuario_empresa == empresa.cnpj);

                        if (evento != null)
                        {
                            var dt1 = new DataTable();

                            dt1.Columns.Add("ID_candidatos");
                            dt1.Columns.Add("Nome");
                            dt1.Columns.Add("Qualificacao");               //Cria as Colunas
                            dt1.Columns.Add("Idioma");
                            dt1.Columns.Add("Vaga");

                            int maxEvento = bd.evento.Max(x => x.idEvento);

                            try
                            {
                                for (int i = 1; i <= maxEvento; i++)
                                {
                                    var eventoEmp = bd.evento.Where(x => x.FK_usuario_empresa == empresa.cnpj).FirstOrDefault();

                                    if (eventoEmp != null)
                                    {
                                        for (int j = 1; j <= max2; j++)
                                        {
                                            var candidatos = bd.candidatos.Where(x => x.FK_evento == i)
                                            .Where(x => x.idCandidatos == j).FirstOrDefault();

                                            if (candidatos != null)
                                            {
                                                var curriculo = bd.curriculo.Where(x => x.FK_usuario_trabalhador
                                                == candidatos.FK_usuario_trabalhador).FirstOrDefault();
                                                var usuarioTrab = bd.usuario_trabalhador.Where(x => x.CPF
                                                == curriculo.FK_usuario_trabalhador).FirstOrDefault();
                                                var usuario = bd.usuario.Where(x => x.idUsuario == usuarioTrab.FK_usuario).FirstOrDefault();

                                                List<string> listIdioma = new List<string>();      //Lista de idiomas mais importantes

                                                listIdioma.Add("Inglês"); listIdioma.Add("Espanhol"); listIdioma.Add("Mandarim");
                                                listIdioma.Add("Francês");
                                                listIdioma.Add("Japonês"); listIdioma.Add("Alemão"); listIdioma.Add("Árabe");
                                                listIdioma.Add("Russo");
                                                listIdioma.Add("Hindi"); listIdioma.Add("Italiano"); listIdioma.Add("Holandês");
                                                listIdioma.Add("Turco");

                                                var verificaEsse = bd.idioma_trabalhador.Where(x => x.idIdiomaTrabalhador > 0).FirstOrDefault();

                                                int num = -1;
                                                int geral = -1;
                                                string idiomaSel;

                                                if (verificaEsse != null)
                                                {
                                                    int maxIdioma = bd.idioma_trabalhador.Max(x => x.idIdiomaTrabalhador);

                                                    for (int l = 1; l <= maxIdioma; l++)
                                                    {
                                                        var ling = bd.idioma_trabalhador.Where(x => x.FK_curriculo == curriculo.idCurriculo)
                                                        .Where(y => y.idIdiomaTrabalhador == l).FirstOrDefault();

                                                        if (ling != null)
                                                        {
                                                            for (int u = 0; u < listIdioma.Count; u++)
                                                            {
                                                                if (listIdioma.ElementAt(u).Equals(ling.linguaTrabalhador))
                                                                {
                                                                    if (num == -1)
                                                                    {         //Verifica se o usuário possui algum idioma da lista e faz um rank
                                                                        geral = u;
                                                                    }
                                                                    num = u;
                                                                }
                                                            }
                                                            if (num < geral)
                                                            {
                                                                geral = num;
                                                            }
                                                        }
                                                    }

                                                    var idioma = bd.idioma_trabalhador.Where(y => y.FK_curriculo ==
                                                    curriculo.idCurriculo).FirstOrDefault();

                                                    if (geral != -1)
                                                    {
                                                        idiomaSel = listIdioma.ElementAt(geral);
                                                    }
                                                    else
                                                    {
                                                        idiomaSel = idioma.linguaTrabalhador;
                                                    }
                                                }
                                                else
                                                {
                                                    idiomaSel = "Nenhum";
                                                }

                                                string qualificacaoSel;
                                                var qualificacao = bd.qualificacao_trabalhador.Where(y => y.FK_curriculo ==
                                                curriculo.idCurriculo).FirstOrDefault();

                                                if (qualificacao != null)
                                                {
                                                    qualificacaoSel = qualificacao.nomeQualificacaoTrabalhador;
                                                }
                                                else
                                                {
                                                    qualificacaoSel = "Nenhuma";
                                                }

                                                dt1.Rows.Add(candidatos.idCandidatos, usuario.nomeUsuario, qualificacaoSel, idiomaSel,
                                                eventoEmp.vagaEvento);

                                                dt.DataSource = dt1; //Conecta com o GridView

                                                this.dt.Columns["ID_candidatos"].Visible = false;
                                            }
                                        }
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
                            pCabecalho.Visible = false;
                            panel2.Visible = false;
                            dt.Visible = false;
                            lblAviso.Visible = true;
                            pb_chat.Visible = false;
                            pnLixeira.Visible = false;
                            pbLixeira.Visible = false;
                        }
                    }
                    else
                    {
                        pCabecalho.Visible = false;
                        panel2.Visible = false;
                        dt.Visible = false;
                        lblAviso.Visible = true;
                        pb_chat.Visible = false;
                        pnLixeira.Visible = false;
                        pbLixeira.Visible = false;
                    }
                }
                else
                {
                    pCabecalho.Visible = false;
                    panel2.Visible = false;
                    dt.Visible = false;
                    lblAviso.Visible = true;
                    pb_chat.Visible = false;
                    pnLixeira.Visible = false;
                    pbLixeira.Visible = false;
                }
            }
            catch (Exception)
            {
                Mensagem.aviso = "Erro ao se conectar com o banco!";
                TelaMensagemAviso f = new TelaMensagemAviso();
                f.ShowDialog();
            }
        }

        private void pbVoltar_Click(object sender, EventArgs e)
        {
            this.Hide();
            TelaPrincipalEmpresa f = new TelaPrincipalEmpresa();   //Volta para tela principal 
            f.Closed += (s, args) => this.Close();
            f.ShowDialog();
        }

        private void pbVoltar_MouseEnter(object sender, EventArgs e)
        {
            pb_voltar.Image = Properties.Resources.VoltarRoxo;
        }

        private void pbVoltar_MouseLeave(object sender, EventArgs e)
        {
            pb_voltar.Image = Properties.Resources.voltar;
        }

        private void alinhamentoCabecalho()
        {
            int largura = pCabecalho.Size.Width;

            int tamanhoEspaco = largura / 4;

            lblCabecalho1.Size = new System.Drawing.Size(tamanhoEspaco, 43);
            lblCabecalho2.Size = new System.Drawing.Size(tamanhoEspaco, 43);
            lblCabecalho3.Size = new System.Drawing.Size(tamanhoEspaco, 43);
            lblCabecalho4.Size = new System.Drawing.Size(tamanhoEspaco, 43);    //Alinhamento do cabeçalho

            lblCabecalho1.Location = new Point(2, 15);
            lblCabecalho2.Location = new Point(tamanhoEspaco + 2, 15);
            lblCabecalho3.Location = new Point(((tamanhoEspaco * 2) + 2), 15);
            lblCabecalho4.Location = new Point(((tamanhoEspaco * 3) + 2), 15);
        }

        private void pCabecalho_Resize(object sender, EventArgs e)
        {
            alinhamentoCabecalho();
        }

        private void pCabecalho_Paint(object sender, PaintEventArgs e)
        {
            alinhamentoCabecalho();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            int x = (p_barra.Size.Width - lblCandidatos.Width) / 2;
            int y = (p_barra.Size.Height - lblCandidatos.Height);              //Posição da label na barra

            lblCandidatos.Location = new Point(x, y);
        }

        private void p_barra_Resize(object sender, EventArgs e)
        {
            int x = (p_barra.Size.Width - lblCandidatos.Width) / 2;
            int y = (p_barra.Size.Height - lblCandidatos.Height);              //Posição da label na barra

            lblCandidatos.Location = new Point(x, y);
        }

        private void pbChat_MouseEnter(object sender, EventArgs e)
        {
            pb_chat.Image = Properties.Resources.chatRoxo1;
        }

        private void pbChat_MouseLeave(object sender, EventArgs e)
        {
            pb_chat.Image = Properties.Resources.chatAzul;
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
            pbMaximizar.BackColor = Color.FromArgb(60, 62, 85);                  //Efeito de opções no menu 
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

        private void pLixeira_Click(object sender, EventArgs e)
        {
            pLimparAberto.Visible = true;
            pbLixeira.Enabled = false;                  //Abre confimação de exclusão 
            pb_voltar.Enabled = false;
            dt.Enabled = false;
            pb_chat.Enabled = false;
            pnLixeira.Enabled = false;
        }

        private void btCancelar_MouseEnter(object sender, EventArgs e)
        {
            btCancelar.ForeColor = Color.Black;
        }

        private void btCancelar_MouseLeave(object sender, EventArgs e)
        {
            btCancelar.ForeColor = Color.White;                          //Animação dos botões
        }

        private void btConfirmar_MouseEnter(object sender, EventArgs e)
        {
            btConfirmar.ForeColor = Color.Black;
        }

        private void btConfirmar_MouseLeave(object sender, EventArgs e)
        {
            btConfirmar.ForeColor = Color.White;
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            pLimparAberto.Visible = false;
            pbLixeira.Enabled = true;                  //Cancela a exclusão
            pb_voltar.Enabled = true;
            dt.Enabled = true;
            pb_chat.Enabled = true;
            pnLixeira.Enabled = true;
        }

        private void btConfirmar_Click(object sender, EventArgs e)
        {
            int max = bd.evento.Max(x => x.idEvento);
            int qtd = 0;

            try
            {

                for (int i = 1; i <= max; i++)
                {

                    var empresa = bd.usuario_empresa.Where(x => x.FK_usuario == UsuarioDados.Id).FirstOrDefault();
                    var evento = bd.evento.Where(x => x.FK_usuario_empresa == empresa.cnpj).Where(x => x.idEvento == i).FirstOrDefault();

                    if (evento != null)
                    {
                        qtd = qtd + Convert.ToInt32(bd.candidatos.Count(x => x.FK_evento == evento.idEvento));
                    }
                }

                if (qtd != 1)
                {

                    PegarID.IDN = Convert.ToInt32(dt.CurrentRow.Cells[0].Value);

                    var cand = bd.candidatos.Where(Z => Z.idCandidatos == PegarID.IDN).FirstOrDefault();

                    bd.candidatos.Remove(cand);
                    bd.SaveChanges();

                    pLimparAberto.Visible = false;
                    pnLixeira.Enabled = true;
                    pbLixeira.Enabled = true;
                    pb_chat.Enabled = true;
                    pb_voltar.Enabled = true;
                    dt.Enabled = true;
                    Mensagem.aviso = "Excluído com sucesso!";
                    TelaMensagemAviso f = new TelaMensagemAviso();
                    f.ShowDialog();

                    var usuEmp = bd.usuario_empresa.Where(x => x.FK_usuario == UsuarioDados.Id).FirstOrDefault();
                    string FK = usuEmp.cnpj;

                    var qtd2 = bd.candidatos.Select(x => x.idCandidatos);

                    if (qtd2 != null)
                    {
                        int max2 = bd.candidatos.Max(x => x.idCandidatos);

                        var empresa = bd.usuario_empresa.Where(x => x.FK_usuario == UsuarioDados.Id).FirstOrDefault();
                        var evento = bd.evento.Select(x => x.FK_usuario_empresa == empresa.cnpj);

                        if (evento != null)
                        {
                            var dt1 = new DataTable();

                            dt1.Columns.Add("ID_candidatos");
                            dt1.Columns.Add("Nome");
                            dt1.Columns.Add("Qualificacao");               //Cria as Colunas
                            dt1.Columns.Add("Idioma");
                            dt1.Columns.Add("Vaga");

                            int maxEvento = bd.evento.Max(x => x.idEvento);

                            try
                            {
                                for (int i = 1; i <= maxEvento; i++)
                                {
                                    var eventoEmp = bd.evento.Where(x => x.FK_usuario_empresa == empresa.cnpj).FirstOrDefault();

                                    if (eventoEmp != null)
                                    {

                                        for (int j = 1; j <= max2; j++)
                                        {
                                            var candidatos2 = bd.candidatos.Where(x => x.FK_evento == i)
                                            .Where(x => x.idCandidatos == j).FirstOrDefault();

                                            if (candidatos2 != null)
                                            {
                                                var curriculo = bd.curriculo.Where(x => x.FK_usuario_trabalhador 
                                                ==candidatos2.FK_usuario_trabalhador).FirstOrDefault();
                                                var usuarioTrab = bd.usuario_trabalhador.Where(x => x.CPF 
                                                == curriculo.FK_usuario_trabalhador).FirstOrDefault();
                                                var usuario = bd.usuario.Where(x => x.idUsuario == usuarioTrab.FK_usuario).FirstOrDefault();

                                                List<string> listIdioma = new List<string>();      //Lista de idiomas mais importantes

                                                listIdioma.Add("Inglês"); listIdioma.Add("Espanhol"); listIdioma.Add("Mandarim"); listIdioma.Add("Francês");
                                                listIdioma.Add("Japonês"); listIdioma.Add("Alemão"); listIdioma.Add("Árabe"); listIdioma.Add("Russo");
                                                listIdioma.Add("Hindi"); listIdioma.Add("Italiano"); listIdioma.Add("Holandês"); listIdioma.Add("Turco");

                                                int maxIdioma = bd.idioma_trabalhador.Max(x => x.idIdiomaTrabalhador);

                                                int num = -1;
                                                int geral = -1;

                                                for (int l = 1; l <= maxIdioma; l++)
                                                {
                                                    var ling = bd.idioma_trabalhador.Where(x => x.FK_curriculo == curriculo.idCurriculo)
                                                    .Where(y => y.idIdiomaTrabalhador == l).FirstOrDefault();

                                                    if (ling != null)
                                                    {
                                                        for (int u = 0; u < listIdioma.Count; u++)
                                                        {
                                                            if (listIdioma.ElementAt(u).Equals(ling.linguaTrabalhador))
                                                            {
                                                                if (num == -1)
                                                                {                  //Verifica se o usuário possui algum idioma da lista e faz um rank
                                                                    geral = u;
                                                                }
                                                                num = u;
                                                            }
                                                        }
                                                        if (num < geral)
                                                        {
                                                            geral = num;
                                                        }
                                                    }
                                                }

                                                var qualificacao = bd.qualificacao_trabalhador.Where(y => y.FK_curriculo 
                                                == curriculo.idCurriculo).FirstOrDefault();
                                                var idioma = bd.idioma_trabalhador.Where(y => y.FK_curriculo == curriculo.idCurriculo).FirstOrDefault();
                                                var experiencia = bd.experiencia_profissional_trabalhador.Where(y => y.FK_curriculo 
                                                == curriculo.idCurriculo).FirstOrDefault();

                                                string idiomaSel;

                                                if (geral != -1)
                                                {
                                                    idiomaSel = listIdioma.ElementAt(geral);
                                                }
                                                else                                                           //Apagar candidatos
                                                {
                                                    idiomaSel = idioma.linguaTrabalhador;
                                                }

                                                if (qualificacao != null && idioma != null && experiencia != null)
                                                {
                                                    dt1.Rows.Add(candidatos2.idCandidatos, usuario.nomeUsuario,
                                                    qualificacao.nomeQualificacaoTrabalhador, idiomaSel,
                                                    eventoEmp.vagaEvento);

                                                    dt.DataSource = dt1; //Conecta com o GridView

                                                    this.dt.Columns["ID_candidatos"].Visible = false;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            catch (Exception)
                            {
                                Mensagem.aviso = "Erro ao se conectar com o banco!";
                                TelaMensagemAviso f2 = new TelaMensagemAviso();
                                f2.ShowDialog();
                            }
                        }
                        else
                        {
                            pCabecalho.Visible = false;
                            panel2.Visible = false;
                            dt.Visible = false;
                            lblAviso.Visible = true;
                            pb_chat.Visible = false;
                            pnLixeira.Visible = false;
                            pbLixeira.Visible = false;
                        }
                    }
                    else
                    {
                        pCabecalho.Visible = false;
                        panel2.Visible = false;
                        dt.Visible = false;
                        lblAviso.Visible = true;
                        pb_chat.Visible = false;
                        pnLixeira.Visible = false;
                        pbLixeira.Visible = false;
                    }
                }
                else
                {
                    try
                    {
                        PegarID.IDN = Convert.ToInt32(dt.CurrentRow.Cells[0].Value);
                        var cand = bd.candidatos.Where(Z => Z.idCandidatos == PegarID.IDN).FirstOrDefault();

                        bd.candidatos.Remove(cand);
                        bd.SaveChanges();

                        pLimparAberto.Visible = false;
                        pnLixeira.Enabled = true;
                        pbLixeira.Enabled = true;
                        pb_chat.Enabled = true;                    //Apagar ultimo candidato
                        pb_voltar.Enabled = true;
                        dt.Enabled = true;

                        dt.Columns.Clear();
                        Mensagem.aviso = "Excluído com sucesso!";
                        TelaMensagemAviso f = new TelaMensagemAviso();
                        f.ShowDialog();

                        lblAviso.Visible = true;
                        pbLixeira.Visible = false;
                        pnLixeira.Visible = false;
                        pb_chat.Visible = false;
                        dt.Visible = false;
                        pCabecalho.Visible = false;
                        panel2.Visible = false;
                    }
                    catch
                    {
                        pLimparAberto.Visible = false;
                        pnLixeira.Enabled = true;
                        pbLixeira.Enabled = true;
                        pb_chat.Enabled = true;
                        pb_voltar.Enabled = true;
                        dt.Enabled = true;
                        Mensagem.aviso = "Erro ao excluir!";
                        TelaMensagemAviso f = new TelaMensagemAviso();
                        f.ShowDialog();
                    }
                }
            }
            catch (Exception)
            {
                Mensagem.aviso = "Erro ao excluir!";
                TelaMensagemAviso f = new TelaMensagemAviso();
                f.ShowDialog();
            }
        }

        private void pb_chat_Click(object sender, EventArgs e)
        {
            try
            {
                var empresa = bd.usuario_empresa.Where(x => x.FK_usuario == UsuarioDados.Id).FirstOrDefault();

                PegarID.IDN = Convert.ToInt32(dt.CurrentRow.Cells[0].Value);                               //Abre a conversa com o usuário
                var candidato = bd.candidatos.Where(x => x.idCandidatos == PegarID.IDN).FirstOrDefault();
                PegarID.Identificar = 3;

                var usuarioTrab = bd.usuario_trabalhador.Where(x => x.CPF == candidato.FK_usuario_trabalhador).FirstOrDefault();
                var usuario = bd.usuario.Where(x => x.idUsuario == usuarioTrab.FK_usuario).FirstOrDefault();

                this.Hide();
                TelaMensagemEmpresa f = new TelaMensagemEmpresa();
                f.Closed += (s, args) => this.Close();
                f.ShowDialog();
            }
            catch (Exception)
            {
                Mensagem.aviso = "Erro ao abrir!";
                TelaMensagemAviso f = new TelaMensagemAviso();
                f.ShowDialog();
            }
        }

        private void abrirCurriculo()
        {
            try
            {
                var empresa = bd.usuario_empresa.Where(x => x.FK_usuario == UsuarioDados.Id).FirstOrDefault();

                int id = Convert.ToInt32(dt.CurrentRow.Cells[0].Value);    //Abre o curriculo selecionado

                var candidato = bd.candidatos.Where(x => x.idCandidatos == id).FirstOrDefault();
                var trab = bd.usuario_trabalhador.Where(x => x.CPF == candidato.FK_usuario_trabalhador).FirstOrDefault();
                var curriculo = bd.curriculo.Where(x => x.FK_usuario_trabalhador == trab.CPF).FirstOrDefault();

                Pesquisa.ID = curriculo.idCurriculo;

                this.Hide();
                TelaVisualizacaoCurriculo f = new TelaVisualizacaoCurriculo();
                f.Closed += (s, args) => this.Close();
                f.ShowDialog();
            }
            catch (Exception)
            {
                Mensagem.aviso = "Erro ao abrir!";
                TelaMensagemAviso f = new TelaMensagemAviso();
                f.ShowDialog();
            }
        }

        private void dt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)   //Abre a visualização do curriculo
            {
                abrirCurriculo();
            }
        }

        private void dt_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            abrirCurriculo();  //Abre a visualização do currículo
        }
    }
}
