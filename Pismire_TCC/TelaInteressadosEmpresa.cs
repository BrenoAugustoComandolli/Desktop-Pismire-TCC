using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Pismire_TCC.Resources;

namespace Pismire_TCC
{

    public partial class TelaInteressados : Form
    {
        PismireEntities5 bd = new PismireEntities5();  
        public TelaInteressados()
        {
            InitializeComponent();
            Maximizacao.verifique(this, pbMaximizar);   //Verifica se a tela está maximizada ou não

            try
            {
                var usuEmp = bd.usuario_empresa.Where(x => x.FK_usuario == UsuarioDados.Id).FirstOrDefault();
                string FK = usuEmp.cnpj;

                int qtd = Convert.ToInt32(bd.interessados_empresa.Count     //Número de interessados
               (x => x.FK_usuario_empresa == FK));

                if (qtd != 0)
                {
                    try
                    {
                        int max = bd.interessados_empresa.Max(x => x.idInteressadosEmpresa);

                        var dt1 = new DataTable();

                        dt1.Columns.Add("ID_interessados");
                        dt1.Columns.Add("Nome");
                        dt1.Columns.Add("Qualificacao");               //Cria as Colunas
                        dt1.Columns.Add("Idioma");
                        dt1.Columns.Add("Cargo");

                        for (int i = 1; i <= max; i++)
                        {
                            var interassados = bd.interessados_empresa.Where(x => x.FK_usuario_empresa == FK)
                            .Where(x => x.idInteressadosEmpresa == i).FirstOrDefault();

                            if (interassados != null)
                            {
                                int idcurriculo = Convert.ToInt32(interassados.FK_curriculo);

                                var curriculo = bd.curriculo.Where(x => x.idCurriculo == idcurriculo).FirstOrDefault();
                                var usuarioTrab = bd.usuario_trabalhador.Where(x => x.CPF == curriculo.FK_usuario_trabalhador).FirstOrDefault();
                                var usuario = bd.usuario.Where(x => x.idUsuario == usuarioTrab.FK_usuario).FirstOrDefault();

                                List<string> listIdioma = new List<string>();      //Lista de idiomas mais importantes

                                listIdioma.Add("Inglês"); listIdioma.Add("Espanhol"); listIdioma.Add("Mandarim"); listIdioma.Add("Francês");
                                listIdioma.Add("Japonês"); listIdioma.Add("Alemão"); listIdioma.Add("Árabe"); listIdioma.Add("Russo");
                                listIdioma.Add("Hindi"); listIdioma.Add("Italiano"); listIdioma.Add("Holandês"); listIdioma.Add("Turco");

                                var testeIdioma = bd.idioma_trabalhador.Where(x => x.idIdiomaTrabalhador != 0).FirstOrDefault();

                                int num = -1;
                                int geral = -1;

                                if (testeIdioma != null)
                                {
                                    int maxIdioma = bd.idioma_trabalhador.Max(x => x.idIdiomaTrabalhador);

                                    for (int l = 1; l <= maxIdioma; l++)
                                    {
                                        var ling = bd.idioma_trabalhador.Where(x => x.FK_curriculo == idcurriculo)
                                        .Where(y => y.idIdiomaTrabalhador == l).FirstOrDefault();

                                        if (ling != null)
                                        {
                                            for (int j = 0; j < listIdioma.Count; j++)
                                            {
                                                if (listIdioma.ElementAt(j).Equals(ling.linguaTrabalhador))
                                                {
                                                    if (num == -1)
                                                    {                  //Verifica se o usuário possui algum idioma da lista e faz um rank
                                                        geral = j;
                                                    }
                                                    num = j;
                                                }
                                            }
                                            if (num < geral)
                                            {
                                                geral = num;
                                            }
                                        }
                                    }
                                }

                                var qualificacao = bd.qualificacao_trabalhador.Where(y => y.FK_curriculo == idcurriculo).FirstOrDefault();
                                var idioma = bd.idioma_trabalhador.Where(y => y.FK_curriculo == idcurriculo).FirstOrDefault();

                                string idiomaSel = "Nenhum";
                                string qualificacaoSel = "";

                                if (testeIdioma != null)
                                {
                                    if (geral != -1)
                                    {
                                        idiomaSel = listIdioma.ElementAt(geral);
                                    }
                                    else
                                    {
                                        idiomaSel = idioma.linguaTrabalhador;
                                    }
                                }

                                if (qualificacao == null)
                                {
                                    qualificacaoSel = "Nenhuma";
                                }
                                else
                                {
                                    qualificacaoSel = qualificacao.nomeQualificacaoTrabalhador;
                                }

                                if (idioma == null)
                                {
                                    idiomaSel = "Nenhum";
                                }

                                dt1.Rows.Add(interassados.idInteressadosEmpresa, usuario.nomeUsuario, qualificacaoSel, idiomaSel,
                                    curriculo.cargoAtuacao);

                                dt.DataSource = dt1; //Conecta com o GridView

                                this.dt.Columns["ID_interessados"].Visible = false;
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
                    pbLixeira.Visible = false;
                    pnLixeira.Enabled = false;
                }
            }
            catch (Exception)
            {
                Mensagem.aviso = "Erro de conexão com o banco!";
                TelaMensagemAviso f = new TelaMensagemAviso();
                f.ShowDialog();
            }
        }

        private void pb_voltar_Click(object sender, EventArgs e)
        {
            this.Hide();
            TelaPrincipalEmpresa f = new TelaPrincipalEmpresa();        //Volta para tela principal
            f.Closed += (s, args) => this.Close();
            f.ShowDialog();
        }

        private void pb_voltar_MouseEnter(object sender, EventArgs e)
        {
            pb_voltar.Image = Properties.Resources.VoltarRoxo;            //Animação do botão voltar
        }

        private void pb_voltar_MouseLeave(object sender, EventArgs e)
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
            lblCabecalho4.Size = new System.Drawing.Size(tamanhoEspaco, 43);            //Alinhamento do cabelhado a gridview

            lblCabecalho1.Location = new Point(2, 15);
            lblCabecalho2.Location = new Point(tamanhoEspaco + 2, 15);
            lblCabecalho3.Location = new Point(((tamanhoEspaco * 2) + 2), 15);
            lblCabecalho4.Location = new Point(((tamanhoEspaco * 3) + 2), 15);
        }

        private void pCabecalho_Paint(object sender, PaintEventArgs e)
        {
            alinhamentoCabecalho();
        }

        private void pCabecalho_Resize(object sender, EventArgs e)
        {
            alinhamentoCabecalho();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            int x = (panel1.Size.Width - lb_interessados.Width) / 2;
            int y = (panel1.Size.Height - lb_interessados.Height);              //Posição da label na barra

            lb_interessados.Location = new Point(x, y);
        }

        private void panel1_Resize(object sender, EventArgs e)
        {
            int x = (panel1.Size.Width - lb_interessados.Width) / 2;
            int y = (panel1.Size.Height - lb_interessados.Height);              //Posição da label na barra

            lb_interessados.Location = new Point(x, y);
        }

        private void pb_chat_MouseEnter(object sender, EventArgs e)
        {
            pb_chat.Image = Properties.Resources.chatRoxo1;
        }

        private void pb_chat_MouseLeave(object sender, EventArgs e)
        {
            pb_chat.Image = Properties.Resources.chatAzul;                 //Animação dos icones
        }

        private void pbLixeira_MouseEnter(object sender, EventArgs e)
        {
            pbLixeira.Image = Properties.Resources.excluirRoxo;
        }

        private void pbLixeira_MouseLeave(object sender, EventArgs e)
        {
            pbLixeira.Image = Properties.Resources.excluir;
        }

        private void pnLixeira_MouseEnter(object sender, EventArgs e)
        {
            pbLixeira.Image = Properties.Resources.excluirRoxo;
        }

        private void pnLixeira_MouseLeave(object sender, EventArgs e)
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

        private void pbLixeira_Click(object sender, EventArgs e)
        {
            pLimparAberto.Visible = true;
            pbLixeira.Enabled = false;                  //Abre confimação de exclusão 
            pb_voltar.Enabled = false;
            dt.Enabled = false;
            pb_chat.Enabled = false;
            pnLixeira.Enabled = false;
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            pLimparAberto.Visible = false;
            pbLixeira.Enabled = true;
            pb_voltar.Enabled = true;               //Cancela a exclusão
            dt.Enabled = true;
            pb_chat.Enabled = true;
            pnLixeira.Enabled = true;
        }

        private void btConfirmar_MouseEnter(object sender, EventArgs e)
        {
            btConfirmar.ForeColor = Color.Black;
        }

        private void btConfirmar_MouseLeave(object sender, EventArgs e)
        {
            btConfirmar.ForeColor = Color.White;                              //Animação de botões
        }

        private void btCancelar_MouseEnter(object sender, EventArgs e)
        {
            btCancelar.ForeColor = Color.Black;
        }

        private void btCancelar_MouseLeave(object sender, EventArgs e)
        {
            btCancelar.ForeColor = Color.White;
        }

        private void btConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                var empresa = bd.usuario_empresa.Where(x => x.FK_usuario == UsuarioDados.Id).FirstOrDefault();
                int qtd = Convert.ToInt32(bd.interessados_empresa.Count(x => x.FK_usuario_empresa == empresa.cnpj));

                if (qtd != 1)
                {
                    PegarID.IDN = Convert.ToInt32(dt.CurrentRow.Cells[0].Value);

                    var interessados = bd.interessados_empresa.Where(Z => Z.idInteressadosEmpresa == PegarID.IDN).FirstOrDefault();

                    bd.interessados_empresa.Remove(interessados);        //Apagando interessados
                    bd.SaveChanges();
                    pLimparAberto.Visible = false;
                    pbLixeira.Enabled = true;
                    pb_voltar.Enabled = true;
                    dt.Enabled = true;
                    pb_chat.Enabled = true;
                    pnLixeira.Enabled = true;

                    Mensagem.aviso = "Excluído com sucesso!";
                    TelaMensagemAviso f = new TelaMensagemAviso();
                    f.ShowDialog();

                    try
                    {
                        int max = bd.interessados_empresa.Max(x => x.idInteressadosEmpresa);

                        var dt1 = new DataTable();

                        dt1.Columns.Add("ID_interessados");
                        dt1.Columns.Add("Nome");
                        dt1.Columns.Add("Qualificacao");               //Cria as Colunas
                        dt1.Columns.Add("Idioma");
                        dt1.Columns.Add("Cargo");

                        for (int i = 1; i <= max; i++)
                        {
                            var empresa2 = bd.usuario_empresa.Where(x => x.FK_usuario == UsuarioDados.Id).FirstOrDefault();
                            var interassados = bd.interessados_empresa.Where(x => x.FK_usuario_empresa == empresa2.cnpj)
                            .Where(x => x.idInteressadosEmpresa == i).FirstOrDefault();

                            if (interassados != null)
                            {
                                int idcurriculo = Convert.ToInt32(interassados.FK_curriculo);

                                var curriculo = bd.curriculo.Where(x => x.idCurriculo == idcurriculo).FirstOrDefault();
                                var usuarioTrab = bd.usuario_trabalhador.Where(x => x.CPF == curriculo.FK_usuario_trabalhador).FirstOrDefault();
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
                                    var ling = bd.idioma_trabalhador.Where(x => x.FK_curriculo == idcurriculo)
                                    .Where(y => y.idIdiomaTrabalhador == l).FirstOrDefault();

                                    if (ling != null)
                                    {
                                        for (int j = 0; j < listIdioma.Count; j++)
                                        {
                                            if (listIdioma.ElementAt(j).Equals(ling.linguaTrabalhador))
                                            {
                                                if (num == -1)
                                                {                  //Verifica se o usuário possui algum idioma da lista e faz um rank
                                                    geral = j;
                                                }
                                                num = j;
                                            }
                                        }
                                        if (num < geral)
                                        {
                                            geral = num;
                                        }
                                    }
                                }

                                var qualificacao = bd.qualificacao_trabalhador.Where(y => y.FK_curriculo == idcurriculo).FirstOrDefault();
                                var idioma = bd.idioma_trabalhador.Where(y => y.FK_curriculo == idcurriculo).FirstOrDefault();
                                var experiencia = bd.experiencia_profissional_trabalhador.Where(y => y.FK_curriculo == idcurriculo).FirstOrDefault();

                                string idiomaSel;

                                if (geral != -1)
                                {
                                    idiomaSel = listIdioma.ElementAt(geral);
                                }
                                else
                                {
                                    idiomaSel = idioma.linguaTrabalhador;
                                }

                                if (qualificacao != null && idioma != null && experiencia != null)
                                {
                                    dt1.Rows.Add(interassados.idInteressadosEmpresa, usuario.nomeUsuario,
                                    qualificacao.nomeQualificacaoTrabalhador, idiomaSel,
                                    curriculo.cargoAtuacao);

                                    dt.DataSource = dt1; //Conecta com o GridView

                                    this.dt.Columns["ID_interessados"].Visible = false;
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
                    try
                    {
                        PegarID.IDN = Convert.ToInt32(dt.CurrentRow.Cells[0].Value);

                        var interessados = bd.interessados_empresa.Where(Z => Z.idInteressadosEmpresa == PegarID.IDN).FirstOrDefault();

                        bd.interessados_empresa.Remove(interessados);
                        bd.SaveChanges();

                        pLimparAberto.Visible = false;
                        Mensagem.aviso = "Excluído com sucesso!";
                        TelaMensagemAviso f = new TelaMensagemAviso();
                        f.ShowDialog();

                        pCabecalho.Visible = false;
                        panel2.Visible = false;
                        dt.Visible = false;
                        lblAviso.Visible = true;
                        pb_chat.Visible = false;
                        pbLixeira.Visible = false;
                        pnLixeira.Visible = false;
                        pb_voltar.Enabled = true;
                        dt.Enabled = true;

                    }
                    catch (Exception)
                    {
                        pLimparAberto.Visible = false;
                        pbLixeira.Enabled = true;
                        pb_voltar.Enabled = true;
                        pnLixeira.Enabled = true;
                        dt.Enabled = true;
                        Mensagem.aviso = "Erro ao excluir!";
                        TelaMensagemAviso f = new TelaMensagemAviso();
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

        private void pb_chat_Click(object sender, EventArgs e)
        {
            try
            {
                var empresa = bd.usuario_empresa.Where(x => x.FK_usuario == UsuarioDados.Id).FirstOrDefault();

                PegarID.IDN = Convert.ToInt32(dt.CurrentRow.Cells[0].Value);                        //Abre a conversa com o usuário
                var interessado = bd.interessados_empresa.Where(y => y.FK_usuario_empresa ==
                empresa.cnpj).Where(x => x.idInteressadosEmpresa == PegarID.IDN).FirstOrDefault();
                PegarID.Identificar = 2;

                var curriculo = bd.curriculo.Where(x => x.idCurriculo == interessado.FK_curriculo).FirstOrDefault();
                var usuarioTrab = bd.usuario_trabalhador.Where(x => x.CPF == curriculo.FK_usuario_trabalhador).FirstOrDefault();
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
                var interessado = bd.interessados_empresa.Where(y => y.FK_usuario_empresa ==
                empresa.cnpj).Where(x => x.idInteressadosEmpresa == id).FirstOrDefault();

                var curriculo = bd.curriculo.Where(x => x.idCurriculo == interessado.FK_curriculo).FirstOrDefault();
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
            if (e.KeyCode == Keys.Enter)
            {
                abrirCurriculo();
            }
        }

        private void dt_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            abrirCurriculo();
        }
    }
}

