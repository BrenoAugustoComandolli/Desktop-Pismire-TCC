using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Pismire_TCC.Resources;

namespace Pismire_TCC
{
    public partial class TelaMensagemEmpresa : Form
    {
        PismireEntities5 bd = new PismireEntities5();
        public bool contCand = false;
        public bool contInt = false;                           
        public bool contRec = false;
        public int trabSelecionado;

        public TelaMensagemEmpresa()
        {
            InitializeComponent();
            Maximizacao.verifique(this, pbMaximizar);   //Verifica se a tela está maximizada ou não

            int idSelecionado = PegarID.IDN; //ID clicado na gridview

            int tipoUsuario = PegarID.Identificar;  //Tipo do usuario clicado

            try
            {

                var empresa = bd.usuario_empresa.Where(x => x.FK_usuario == UsuarioDados.Id).FirstOrDefault();

                int qtd = Convert.ToInt16(bd.recomendados_empresa.Count     //Número de notificações
                (x => x.FK_usuario_empresa == empresa.cnpj));

                if (qtd != 0)      //Verifica quantidade de ids
                {
                    try
                    {
                        int max = bd.recomendados_empresa.Max(x => x.IdRecomendadosEmpresa);    //Maior ID

                        var dt1 = new DataTable();

                        dt1.Columns.Add("ID_recomendados");
                        dt1.Columns.Add("Nome"); //Adicionando colunas na tabela

                        for (int i = 1; i <= max; i++)
                        {
                            var recomendado = bd.recomendados_empresa.Where(y => y.FK_usuario_empresa ==
                            empresa.cnpj).Where(x => x.IdRecomendadosEmpresa == i).FirstOrDefault();

                            if (recomendado != null)
                            {
                                var curriculo = bd.curriculo.Where(x => x.idCurriculo == recomendado.FK_curriculo).FirstOrDefault();
                                var usuarioTrab = bd.usuario_trabalhador.Where(x => x.CPF == curriculo.FK_usuario_trabalhador)
                                .FirstOrDefault();
                                var usuario = bd.usuario.Where(x => x.idUsuario == usuarioTrab.FK_usuario).FirstOrDefault();

                                dt1.Rows.Add(recomendado.IdRecomendadosEmpresa, usuario.nomeUsuario);       //Carrega os recomendados 

                                dtRecomendados.DataSource = dt1; //Conecta com o GridView

                                this.dtRecomendados.Columns["ID_recomendados"].Visible = false;
                            }

                        }
                    }
                    catch (Exception)
                    {
                        Mensagem.aviso = "Erro ao se conectar com o banco!";    //Verificação de campos 
                        TelaMensagemAviso f = new TelaMensagemAviso();
                        f.ShowDialog();
                    }
                }
                else
                {
                    dtRecomendados.Visible = false;
                }

                //-------------------

                int qtd2 = Convert.ToInt16(bd.interessados_empresa.Count     //Número de interessados
                (x => x.FK_usuario_empresa == empresa.cnpj));

                if (qtd2 != 0)      //Verifica quantidade de ids
                {

                    try
                    {
                        int max2 = bd.interessados_empresa.Max(x => x.idInteressadosEmpresa);    //Maior ID

                        var dt1 = new DataTable();

                        dt1.Columns.Add("ID_interessados");
                        dt1.Columns.Add("Nome"); //Adicionando colunas na tabela

                        for (int i = 1; i <= max2; i++)
                        {
                            var interessado = bd.interessados_empresa.Where(y => y.FK_usuario_empresa ==
                            empresa.cnpj).Where(x => x.idInteressadosEmpresa == i).FirstOrDefault();

                            if (interessado != null)          //Carrega os interessados
                            {
                                var curriculo2 = bd.curriculo.Where(x => x.idCurriculo == interessado.FK_curriculo).FirstOrDefault();
                                var usuarioTrab2 = bd.usuario_trabalhador.Where(x => x.CPF == curriculo2.FK_usuario_trabalhador).FirstOrDefault();
                                var usuario2 = bd.usuario.Where(x => x.idUsuario == usuarioTrab2.FK_usuario).FirstOrDefault();

                                dt1.Rows.Add(interessado.idInteressadosEmpresa, usuario2.nomeUsuario);

                                dtInteressados.DataSource = dt1; //Conecta com o GridView

                                this.dtInteressados.Columns["ID_interessados"].Visible = false;
                            }

                        }
                    }
                    catch (Exception)
                    {
                        Mensagem.aviso = "Erro ao se conectar com o banco!";    //Verificação de campos 
                        TelaMensagemAviso f = new TelaMensagemAviso();
                        f.ShowDialog();
                    }
                }
                else
                {
                    dtInteressados.Visible = false;
                }

                //-----------------

                try
                {
                    int teste1 = bd.evento.Select(x => x.idEvento).FirstOrDefault();  //Verifica se há eventos no banco

                    if (teste1 != 0)
                    {
                        var maxEvento = bd.evento.Max(x => x.idEvento); //Maior evento

                        int teste2 = bd.candidatos.Select(x => x.idCandidatos).FirstOrDefault();  //Verifica se há candidatos no banco

                        if (teste2 != 0)
                        {
                            var max3 = bd.candidatos.Max(x => x.idCandidatos);  //Maior candidato

                            var dt1 = new DataTable();

                            dt1.Columns.Add("ID_candidatos");
                            dt1.Columns.Add("Nome");     //Adicionando colunas na tabela

                            bool passou = false;

                            for (int i = 1; i <= maxEvento; i++)
                            {
                                var evento = bd.evento.Where(x => x.FK_usuario_empresa == empresa.cnpj).
                                Where(x => x.idEvento == i).FirstOrDefault();

                                if (evento != null)                                //Carrega os candidatos
                                {
                                    for (int j = 1; j <= max3; j++)
                                    {
                                        var candidato = bd.candidatos.Where(y => y.FK_evento == i).
                                        Where(x => x.idCandidatos == j).FirstOrDefault();

                                        if (candidato != null)          //Carrega os interessados
                                        {
                                            var usuarioTrab3 = bd.usuario_trabalhador
                                            .Where(x => x.CPF == candidato.FK_usuario_trabalhador).FirstOrDefault();
                                            var usuario3 = bd.usuario.Where(x => x.idUsuario == usuarioTrab3.FK_usuario).FirstOrDefault();

                                            dt1.Rows.Add(candidato.idCandidatos, usuario3.nomeUsuario);

                                            dtCandidatos.DataSource = dt1; //Conecta com o GridView

                                            this.dtCandidatos.Columns["ID_candidatos"].Visible = false;
                                            passou = true;
                                        }
                                    }
                                }
                            }
                            if (!passou)
                            {
                                dtCandidatos.Visible = false;
                            }
                        }
                        else
                        {
                            dtCandidatos.Visible = false;
                        }
                    }
                    else
                    {
                        dtCandidatos.Visible = false;
                    }
                }
                catch (Exception)
                {
                    Mensagem.aviso = "Erro ao se conectar com o banco!";    //Verificação de campos 
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

        public void testeGirarCandidato()
        {
            if (pnCand.Visible == true)
            {                                                                     //Teste de flip candidatos
                pbSeta1.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                pbSeta1.Refresh();
                contCand = false;
            }

        }

        public void testeGirarInteressados()
        {
            if (pnInt.Visible == true)
            {                                                                   //Teste de flip interessados
                pbSeta2.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                pbSeta2.Refresh();
                contInt = false;
            }

        }

        public void testeGirarRecomendados()
        {
            if (pnRec.Visible == true)
            {
                pbSeta3.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                pbSeta3.Refresh();                                                  //Teste de flip recomendados
                contRec = false;
            }

        }

        public void listarInteressados()
        {
            if (contInt == false)
            {
                pbSeta2.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                pbSeta2.Refresh();
                pnRecomendados.Location = new Point(1, 428);
                pnInt.Visible = true;
                contInt = true;

            }                                                                  //Mostrar painel interessados
            else if (contInt == true)
            {
                pbSeta2.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                pbSeta2.Refresh();
                pnRecomendados.Location = new Point(1, 196);
                pnInt.Visible = false;
                contInt = false;
            }
        }

        public void listarRecomendados()
        {
            if (contRec == false)
            {
                pbSeta3.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                pbSeta3.Refresh();                                               //Mostrar painel recomendados
                pnRec.Visible = true;
                contRec = true;
            }
            else if (contRec == true)
            {
                pbSeta3.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                pbSeta3.Refresh();
                pnRec.Visible = false;
                contRec = false;
            }
        }

        public void listarCandidatos()
        {
            if (contCand == false)
            {
                pbSeta1.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                pbSeta1.Refresh();
                pnInteressados.Location = new Point(1, 330);
                pnRecomendados.Location = new Point(1, 428);
                pnCand.Visible = true;
                contCand = true;                                                 //mostrar painel candidatos
            }
            else if (contCand == true)
            {
                pbSeta1.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                pbSeta1.Refresh();
                pnInteressados.Location = new Point(1, 98);
                pnRecomendados.Location = new Point(1, 196);
                pnCand.Visible = false;
                contCand = false;
            }
        }

        public void limparConf()
        {
            pnInteressados.Location = new Point(1, 98);
            pnRecomendados.Location = new Point(1, 196);
            pnCand.Visible = false;                              //Limpar configurações (Deixar tudo como no inicio)
            pnInt.Visible = false;
            pnRec.Visible = false;
        }

        private void pbVoltar_Click(object sender, EventArgs e)
        {
            this.Hide();
            TelaPrincipalEmpresa f = new TelaPrincipalEmpresa();      //Voltar para menu principal
            f.Closed += (s, args) => this.Close();
            f.ShowDialog();
        }

        private void pbVoltar_MouseEnter(object sender, EventArgs e)
        {
            pbVoltar.Image = Properties.Resources.VoltarRoxo;
        }

        private void pbVoltar_MouseLeave(object sender, EventArgs e)
        {
            pbVoltar.Image = Properties.Resources.voltar;
        }

        private void pnCandidatos_Click(object sender, EventArgs e)
        {
            testeGirarInteressados();
            testeGirarRecomendados();
            limparConf();                                       //Abrir candidatos
            listarCandidatos();
        }

        private void pnRecomendados_Click(object sender, EventArgs e)
        {
            testeGirarCandidato();
            testeGirarInteressados();                         //Abrir recomendados
            limparConf();
            listarRecomendados();
        }

        private void pbInteressados_Click(object sender, EventArgs e)
        {
            testeGirarCandidato();
            testeGirarRecomendados();                        //Abrir interessados
            limparConf();
            listarInteressados();
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
            pbMaximizar.BackColor = Color.FromArgb(41, 41, 41);                 //Efeito de opções no menu 
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

        private void dtCandidatos_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    int id = Convert.ToInt32(dtCandidatos.CurrentRow.Cells[0].Value);         //Pega as informações do usuário ao clicar

                    var candidatos = bd.candidatos.Where(y => y.idCandidatos == id).FirstOrDefault();
                    var trab = bd.usuario_trabalhador.Where(x => x.CPF == candidatos.FK_usuario_trabalhador).FirstOrDefault();
                    var usuario = bd.usuario.Where(x => x.idUsuario == trab.FK_usuario).FirstOrDefault();

                    trabSelecionado = usuario.idUsuario;

                    pbAviso.Visible = false;
                    lblAviso.Visible = false;
                    dt.Visible = true;
                    pnEnvio.Visible = true;
                    pbLixeira.Visible = true;
                    carregarMensagens(usuario.idUsuario);
                }
            }
            catch (Exception)
            {
                Mensagem.aviso = "Erro ao encontrar usuário!";    //Verificação de campos 
                TelaMensagemAviso f = new TelaMensagemAviso();
                f.ShowDialog();
            }
        }

        private void dtCandidatos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(dtCandidatos.CurrentRow.Cells[0].Value);      //pega as informações do usuario ao clicar

                var candidatos = bd.candidatos.Where(y => y.idCandidatos == id).FirstOrDefault();
                var trab = bd.usuario_trabalhador.Where(x => x.CPF == candidatos.FK_usuario_trabalhador).FirstOrDefault();
                var usuario = bd.usuario.Where(x => x.idUsuario == trab.FK_usuario).FirstOrDefault();

                trabSelecionado = usuario.idUsuario;

                pbAviso.Visible = false;
                lblAviso.Visible = false;
                dt.Visible = true;
                pnEnvio.Visible = true;
                pbLixeira.Visible = true;
                carregarMensagens(usuario.idUsuario);
            }
            catch (Exception)
            {
                Mensagem.aviso = "Erro ao encontrar usuário!";    //Verificação de campos 
                TelaMensagemAviso f = new TelaMensagemAviso();
                f.ShowDialog();
            }
        }

        private void dtInteressados_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    int id = Convert.ToInt32(dtInteressados.CurrentRow.Cells[0].Value);         //Pega as informações do usuário ao clicar

                    var interessados = bd.interessados_empresa.Where(y => y.idInteressadosEmpresa == id).FirstOrDefault();
                    var curriculo = bd.curriculo.Where(x => x.idCurriculo == interessados.FK_curriculo).FirstOrDefault();
                    var trab = bd.usuario_trabalhador.Where(x => x.CPF == curriculo.FK_usuario_trabalhador).FirstOrDefault();
                    var usuario = bd.usuario.Where(x => x.idUsuario == trab.FK_usuario).FirstOrDefault();

                    trabSelecionado = usuario.idUsuario;

                    pbAviso.Visible = false;
                    lblAviso.Visible = false;
                    dt.Visible = true;
                    pnEnvio.Visible = true;
                    pbLixeira.Visible = true;
                    carregarMensagens(usuario.idUsuario);
                }
            }
            catch (Exception)
            {
                Mensagem.aviso = "Erro ao encontrar usuário!";    //Verificação de campos 
                TelaMensagemAviso f = new TelaMensagemAviso();
                f.ShowDialog();
            }
        }

        private void dtInteressados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(dtInteressados.CurrentRow.Cells[0].Value);         //Pega as informações do usuário ao clicar

                var interessados = bd.interessados_empresa.Where(y => y.idInteressadosEmpresa == id).FirstOrDefault();
                var curriculo = bd.curriculo.Where(x => x.idCurriculo == interessados.FK_curriculo).FirstOrDefault();
                var trab = bd.usuario_trabalhador.Where(x => x.CPF == curriculo.FK_usuario_trabalhador).FirstOrDefault();
                var usuario = bd.usuario.Where(x => x.idUsuario == trab.FK_usuario).FirstOrDefault();

                trabSelecionado = usuario.idUsuario;

                pbAviso.Visible = false;
                lblAviso.Visible = false;
                dt.Visible = true;
                pnEnvio.Visible = true;
                pbLixeira.Visible = true;
                carregarMensagens(usuario.idUsuario);
            }
            catch (Exception)
            {
                Mensagem.aviso = "Erro ao encontrar usuário!";    //Verificação de campos 
                TelaMensagemAviso f = new TelaMensagemAviso();
                f.ShowDialog();
            }
        }

        private void dtRecomendados_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    int id = Convert.ToInt32(dtRecomendados.CurrentRow.Cells[0].Value);         //Pega as informações do usuário ao clicar

                    var recomendados = bd.recomendados_empresa.Where(y => y.IdRecomendadosEmpresa == id).FirstOrDefault();
                    var curriculo = bd.curriculo.Where(x => x.idCurriculo == recomendados.FK_curriculo).FirstOrDefault();
                    var trab = bd.usuario_trabalhador.Where(x => x.CPF == curriculo.FK_usuario_trabalhador).FirstOrDefault();
                    var usuario = bd.usuario.Where(x => x.idUsuario == trab.FK_usuario).FirstOrDefault();

                    trabSelecionado = usuario.idUsuario;

                    pbAviso.Visible = false;
                    lblAviso.Visible = false;
                    dt.Visible = true;
                    pnEnvio.Visible = true;
                    pbLixeira.Visible = true;
                    carregarMensagens(usuario.idUsuario);
                }
            }
            catch (Exception)
            {
                Mensagem.aviso = "Erro ao encontrar usuário!";    //Verificação de campos 
                TelaMensagemAviso f = new TelaMensagemAviso();
                f.ShowDialog();
            }
        }

        private void dtRecomendados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(dtRecomendados.CurrentRow.Cells[0].Value);         //Pega as informações do usuário ao clicar

                var recomendados = bd.recomendados_empresa.Where(y => y.IdRecomendadosEmpresa == id).FirstOrDefault();
                var curriculo = bd.curriculo.Where(x => x.idCurriculo == recomendados.FK_curriculo).FirstOrDefault();
                var trab = bd.usuario_trabalhador.Where(x => x.CPF == curriculo.FK_usuario_trabalhador).FirstOrDefault();
                var usuario = bd.usuario.Where(x => x.idUsuario == trab.FK_usuario).FirstOrDefault();

                trabSelecionado = usuario.idUsuario;

                pbAviso.Visible = false;
                lblAviso.Visible = false;
                dt.Visible = true;
                pnEnvio.Visible = true;
                pbLixeira.Visible = true;
                carregarMensagens(usuario.idUsuario);
            }
            catch (Exception)
            {
                Mensagem.aviso = "Erro ao encontrar usuário!";    //Verificação de campos 
                TelaMensagemAviso f = new TelaMensagemAviso();
                f.ShowDialog();
            }
        }

        private void dt_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dt.CurrentCell != null)
            {
                PegarID.IDN = Convert.ToInt32(dt.CurrentRow.Cells[0].Value);   //Abre a notificação

                this.Hide();
                TelaMensagemAberta g = new TelaMensagemAberta();
                g.Closed += (s, args) => this.Close();
                g.ShowDialog();
            }
            else
            {
                Mensagem.aviso = "Selecione uma mensagem primeiro!";    //Verificação de campos 
                TelaMensagemAviso f = new TelaMensagemAviso();
                f.ShowDialog();
            }
        }

        private void dt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (dt.CurrentCell != null)
                {
                    PegarID.IDN = Convert.ToInt32(dt.CurrentRow.Cells[0].Value);   //Abre a notificação

                    this.Hide();
                    TelaMensagemAberta g = new TelaMensagemAberta();
                    g.Closed += (s, args) => this.Close();
                    g.ShowDialog();
                }
                else
                {
                    Mensagem.aviso = "Selecione uma mensagem primeiro!";    //Verificação de campos 
                    TelaMensagemAviso f = new TelaMensagemAviso();
                    f.ShowDialog();
                }
            }
        }

        public void carregarMensagens(int idTrab)
        {
            Maximizacao.verifique(this, pbMaximizar);   //Verifica se a tela está maximizada ou não

            try
            {

                var testeQtd = bd.mensagem.Where(x => x.FK_usuario == idTrab).Where
                          (x => x.destinatarioMensagem == UsuarioDados.Id).FirstOrDefault();

                if (testeQtd != null)                                      //Verifica quantidade de ids
                {
                    try
                    {
                        int max = bd.mensagem.Max(x => x.idMensagem);    //Maior ID

                        var dt1 = new DataTable();

                        dt1.Columns.Add("Id_mensagem");
                        dt1.Columns.Add("Mensagem");              //Cria as Colunas
                        dt1.Columns.Add("Data");
                        dt1.Columns.Add("Horario");

                        for (int i = 1; i <= max; i++)
                        {
                            var mensagem = bd.mensagem.Where(y => y.destinatarioMensagem ==
                            UsuarioDados.Id).Where(x => x.FK_usuario == idTrab).Where(x => x.idMensagem == i).FirstOrDefault();

                            if (mensagem != null)
                            {
                                dt1.Rows.Add(mensagem.idMensagem, mensagem.textoMensagem, mensagem.dataMensagem.ToShortDateString(), mensagem.horarioMensagem);

                                dt.DataSource = dt1; //Conecta com o GridView

                                this.dt.Columns["Id_mensagem"].Visible = false;   //Tira as que não precisa

                                this.dt.Columns["mensagem"].FillWeight = 110;        //Ajusta o tamanho
                                this.dt.Columns["Data"].FillWeight = 20;
                                this.dt.Columns["Horario"].FillWeight = 20;
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
            }
            catch (Exception)
            {
                Mensagem.aviso = "Erro de conexão com o banco!";
                TelaMensagemAviso f = new TelaMensagemAviso();
                f.ShowDialog();
            }
        }

        private void pbLixeira_MouseEnter(object sender, EventArgs e)
        {
            pbLixeira.Image = Properties.Resources.excluirRoxo;
        }

        private void pbLixeira_MouseLeave(object sender, EventArgs e)
        {
            pbLixeira.Image = Properties.Resources.excluir;
        }

        private void pbAtualizar_MouseEnter(object sender, EventArgs e)
        {
            pbAtualizar.Image = Properties.Resources.AtualizaçãoRoxo2;
        }

        private void pbAtualizar_MouseLeave(object sender, EventArgs e)
        {
            pbAtualizar.Image = Properties.Resources.AtualizaçãoBranco;
        }

        private void pbEnviar_MouseEnter(object sender, EventArgs e)
        {
            pbEnviar.Image = Properties.Resources.enviarRoxo;
        }

        private void pbEnviar_MouseLeave(object sender, EventArgs e)
        {
            pbEnviar.Image = Properties.Resources.enviar;
        }

        private void pbBarra_Paint(object sender, PaintEventArgs e)
        {
            int x = (pbBarra.Size.Width - lblMensagem.Width) / 2;
            int y = (pbBarra.Size.Height - lblMensagem.Height);              //Posição da label na barra ao maximizar e desmaximizar 

            lblMensagem.Location = new Point(x, y);
        }

        private void pbBarra_Resize(object sender, EventArgs e)
        {
            int x = (pbBarra.Size.Width - lblMensagem.Width) / 2;
            int y = (pbBarra.Size.Height - lblMensagem.Height);              //Posição da label na barra ao maximizar e desmaximizar 

            lblMensagem.Location = new Point(x, y);
        }

        private void pbEnviar_Click(object sender, EventArgs e)
        {
            if (ctMessagem.Text == "")
            {
                Mensagem.aviso = "Campo de texto vazío!";
                TelaMensagemAviso f = new TelaMensagemAviso();
                f.ShowDialog();
            }
            else
            {
                try
                {
                    string data = (DateTime.Now.ToShortDateString()).ToString();    //Data Atual
                    string horario = (DateTime.Now.ToShortTimeString()).ToString(); //Horário Atual

                    mensagem add = new mensagem();
                    add.destinatarioMensagem = trabSelecionado;            //Enviar notificacao
                    add.textoMensagem = ctMessagem.Text;
                    add.dataMensagem = DateTime.Parse(data);
                    add.horarioMensagem = TimeSpan.Parse(horario);
                    add.FK_usuario = UsuarioDados.Id;
                    bd.mensagem.Add(add);
                    bd.SaveChanges();

                    Mensagem.aviso = "Mensagem enviada com sucesso!";    //Mensagem de sucesso
                    TelaMensagemAviso f = new TelaMensagemAviso();
                    f.ShowDialog();
                    ctMessagem.Clear();
                }
                catch (Exception)
                {
                    Mensagem.aviso = "Erro ao enviar!";                 //Mensagem de erro 
                    TelaMensagemAviso f = new TelaMensagemAviso();
                    f.ShowDialog();
                }
            }
        }

        private void pbAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = 0;
                string cpf = "";

                if (dtCandidatos.CurrentRow != null)
                {
                    id = Convert.ToInt32(dtCandidatos.CurrentRow.Cells[0].Value);
                    var candidatos = bd.candidatos.Where(x => x.idCandidatos == id).FirstOrDefault();
                    cpf = candidatos.FK_usuario_trabalhador;
                }
                else if (dtInteressados.CurrentRow != null)
                {
                    id = Convert.ToInt32(dtInteressados.CurrentRow.Cells[0].Value);    //Pega as informações do usuário ao clicar
                    var interessados = bd.interessados_empresa.Where(x => x.idInteressadosEmpresa == id).FirstOrDefault();
                    var curriculo = bd.curriculo.Where(x => x.idCurriculo == interessados.FK_curriculo).FirstOrDefault();
                    cpf = curriculo.FK_usuario_trabalhador;
                }
                else if (dtRecomendados.CurrentRow != null)
                {
                    id = Convert.ToInt32(dtRecomendados.CurrentRow.Cells[0].Value);
                    var recomendados = bd.recomendados_empresa.Where(x => x.IdRecomendadosEmpresa == id).FirstOrDefault();
                    var curriculo = bd.curriculo.Where(x => x.idCurriculo == recomendados.FK_curriculo).FirstOrDefault();
                    cpf = curriculo.FK_usuario_trabalhador;
                }

                if(id != 0)
                {
                    var usuarioTrab = bd.usuario_trabalhador.Where(x => x.CPF == cpf).FirstOrDefault();
                    trabSelecionado = usuarioTrab.FK_usuario;

                    dt.Visible = true;
                    pnEnvio.Visible = true;
                    pbLixeira.Visible = true;
                    carregarMensagens(usuarioTrab.FK_usuario);
                }
                else
                {
                    Mensagem.aviso = "Selecione um usuário!";       //Verificação de campos 
                    TelaMensagemAviso f = new TelaMensagemAviso();
                    f.ShowDialog();
                }
            }
            catch (Exception)
            {
                Mensagem.aviso = "Erro ao encontrar usuário!";    //Verificação de campos 
                TelaMensagemAviso f = new TelaMensagemAviso();
                f.ShowDialog();
            }
        }

        private void pbLixeira_Click(object sender, EventArgs e)
        {
            if (dt.CurrentCell != null)
            {
                pbLixeira.Enabled = false;           //Abre confimação de exclusão 
                pbVoltar.Enabled = false;
                dtRecomendados.Enabled = true;
                dtInteressados.Enabled = true;
                dtCandidatos.Enabled = true;
                dt.Enabled = false;
                pLimparAberto.Visible = true;
                ctMessagem.Enabled = false;
                pbAtualizar.Enabled = false;
                pbEnviar.Enabled = false;
            }
            else
            {
                Mensagem.aviso = "Selecione uma mensagem primeiro!";    //Verificação de campos 
                TelaMensagemAviso f = new TelaMensagemAviso();
                f.ShowDialog();
            }
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            pbLixeira.Enabled = true;           //Abre confimação de exclusão 
            pbVoltar.Enabled = true;
            dtRecomendados.Enabled = true;
            dtInteressados.Enabled = true;
            dtCandidatos.Enabled = true;
            dt.Enabled = true;
            pLimparAberto.Visible = false;
            ctMessagem.Enabled = true;
            pbAtualizar.Enabled = true;
            pbEnviar.Enabled = true;
        }

        private void btConfirmar2_Click(object sender, EventArgs e)
        {
            try
            {
                int qtd = Convert.ToInt32(bd.mensagem.Count(x => x.destinatarioMensagem == UsuarioDados.Id));

                if (qtd != 1)
                {
                    PegarID.IDN = Convert.ToInt32(dt.CurrentRow.Cells[0].Value);

                    var notf = bd.mensagem.Where(Z => Z.idMensagem == PegarID.IDN).FirstOrDefault();

                    bd.mensagem.Remove(notf);

                    bd.SaveChanges();

                    pbLixeira.Enabled = true;
                    pbVoltar.Enabled = true;
                    dtRecomendados.Enabled = true;
                    dtInteressados.Enabled = true;
                    dtCandidatos.Enabled = true;
                    dt.Enabled = true;
                    pLimparAberto.Visible = false;
                    ctMessagem.Enabled = true;
                    pbAtualizar.Enabled = true;
                    pbEnviar.Enabled = true;
                    Mensagem.aviso = "Excluído com sucesso!";
                    TelaMensagemAviso f = new TelaMensagemAviso();
                    f.ShowDialog();

                    try
                    {
                        int max = bd.mensagem.Max(x => x.idMensagem);    //Maior ID

                        var dt1 = new DataTable();

                        dt1.Columns.Add("Id_mensagem");
                        dt1.Columns.Add("Mensagem");              //Cria as Colunas
                        dt1.Columns.Add("Data");
                        dt1.Columns.Add("Horario");

                        for (int i = 1; i <= max; i++)
                        {
                            var mensagem = bd.mensagem.Where(y => y.destinatarioMensagem ==
                            UsuarioDados.Id).Where(x => x.FK_usuario == trabSelecionado).Where(x => x.idMensagem == i).FirstOrDefault();

                            if (mensagem != null)
                            {
                                dt1.Rows.Add(mensagem.idMensagem, mensagem.textoMensagem, mensagem.dataMensagem.ToShortDateString(), mensagem.horarioMensagem);

                                dt.DataSource = dt1; //Conecta com o GridView

                                this.dt.Columns["Id_mensagem"].Visible = false;   //Tira as que não precisa

                                this.dt.Columns["mensagem"].FillWeight = 110;        //Ajusta o tamanho
                                this.dt.Columns["Data"].FillWeight = 20;
                                this.dt.Columns["Horario"].FillWeight = 20;
                            }
                        }
                    }
                    catch (Exception)
                    {
                        pbLixeira.Enabled = true;
                        pbVoltar.Enabled = true;
                        dtRecomendados.Enabled = true;
                        dtInteressados.Enabled = true;
                        dtCandidatos.Enabled = true;
                        dt.Enabled = true;
                        pLimparAberto.Visible = false;
                        ctMessagem.Enabled = true;
                        pbAtualizar.Enabled = true;
                        pbEnviar.Enabled = true;
                        Mensagem.aviso = "Erro ao excluir!";
                        TelaMensagemAviso f2 = new TelaMensagemAviso();
                        f2.ShowDialog();
                    }
                }
                else
                {
                    try
                    {
                        PegarID.IDN = Convert.ToInt32(dt.CurrentRow.Cells[0].Value);

                        var notf = bd.mensagem.Where(Z => Z.idMensagem == PegarID.IDN).FirstOrDefault();

                        bd.mensagem.Remove(notf);

                        bd.SaveChanges();

                        dt.Columns.Clear();
                        pbLixeira.Enabled = true;
                        pbVoltar.Enabled = true;
                        dtRecomendados.Enabled = true;
                        dtInteressados.Enabled = true;
                        dtCandidatos.Enabled = true;
                        dt.Enabled = true;
                        pLimparAberto.Visible = false;
                        ctMessagem.Enabled = true;
                        pbAtualizar.Enabled = true;
                        pbEnviar.Enabled = true;
                        pbEnviar.Visible = false;
                        pnEnvio.Visible = false;
                        Mensagem.aviso = "Excluído com sucesso!";
                        TelaMensagemAviso f = new TelaMensagemAviso();
                        f.ShowDialog();

                        var empresa = bd.usuario_empresa.Where(x => x.FK_usuario == UsuarioDados.Id).FirstOrDefault();

                        int qtd2 = Convert.ToInt16(bd.recomendados_empresa.Count     //Número de notificações
                        (x => x.FK_usuario_empresa == empresa.cnpj));

                        if (qtd2 != 0)      //Verifica quantidade de ids
                        {

                            try
                            {
                                int max = bd.recomendados_empresa.Max(x => x.IdRecomendadosEmpresa);    //Maior ID

                                var dt1 = new DataTable();

                                dt1.Columns.Add("ID_recomendados");
                                dt1.Columns.Add("Nome"); //Adicionando colunas na tabela

                                for (int i = 1; i <= max; i++)
                                {
                                    var recomendado = bd.recomendados_empresa.Where(y => y.FK_usuario_empresa ==
                                    empresa.cnpj).Where(x => x.IdRecomendadosEmpresa == i).FirstOrDefault();

                                    if (recomendado != null)
                                    {
                                        var curriculo = bd.curriculo.Where(x => x.idCurriculo == recomendado.FK_curriculo).FirstOrDefault();
                                        var usuarioTrab = bd.usuario_trabalhador.Where(x => x.CPF == curriculo.FK_usuario_trabalhador).FirstOrDefault();
                                        var usuario = bd.usuario.Where(x => x.idUsuario == usuarioTrab.FK_usuario).FirstOrDefault();

                                        dt1.Rows.Add(recomendado.IdRecomendadosEmpresa, usuario.nomeUsuario);       //Carrega os recomendados 

                                        dtRecomendados.DataSource = dt1; //Conecta com o GridView

                                        this.dtRecomendados.Columns["ID_recomendados"].Visible = false;
                                    }

                                }
                            }
                            catch (Exception)
                            {
                                Mensagem.aviso = "Erro ao se conectar com o banco!";    //Verificação de campos 
                                TelaMensagemAviso f2 = new TelaMensagemAviso();
                                f2.ShowDialog();
                            }
                        }
                        else
                        {
                            dtRecomendados.Visible = false;
                        }

                        //-------------------

                        int qtd3 = Convert.ToInt16(bd.interessados_empresa.Count     //Número de interessados
                        (x => x.FK_usuario_empresa == empresa.cnpj));

                        if (qtd3 != 0)      //Verifica quantidade de ids
                        {

                            try
                            {
                                int max2 = bd.interessados_empresa.Max(x => x.idInteressadosEmpresa);    //Maior ID

                                var dt1 = new DataTable();

                                dt1.Columns.Add("ID_interessados");
                                dt1.Columns.Add("Nome"); //Adicionando colunas na tabela

                                for (int i = 1; i <= max2; i++)
                                {
                                    var interessado = bd.interessados_empresa.Where(y => y.FK_usuario_empresa ==
                                    empresa.cnpj).Where(x => x.idInteressadosEmpresa == i).FirstOrDefault();

                                    if (interessado != null)          //Carrega os interessados
                                    {
                                        var curriculo2 = bd.curriculo.Where(x => x.idCurriculo == interessado.FK_curriculo).FirstOrDefault();
                                        var usuarioTrab2 = bd.usuario_trabalhador.Where(x => x.CPF == curriculo2.FK_usuario_trabalhador).FirstOrDefault();
                                        var usuario2 = bd.usuario.Where(x => x.idUsuario == usuarioTrab2.FK_usuario).FirstOrDefault();

                                        dt1.Rows.Add(interessado.idInteressadosEmpresa, usuario2.nomeUsuario);

                                        dtInteressados.DataSource = dt1; //Conecta com o GridView

                                        this.dtInteressados.Columns["ID_interessados"].Visible = false;
                                    }

                                }
                            }
                            catch (Exception)
                            {
                                Mensagem.aviso = "Erro ao se conectar com o banco!";    //Verificação de campos 
                                TelaMensagemAviso f2 = new TelaMensagemAviso();
                                f2.ShowDialog();
                            }
                        }
                        else
                        {
                            dtInteressados.Visible = false;
                        }

                        //-----------------

                        try
                        {
                            int teste1 = bd.evento.Select(x => x.idEvento).FirstOrDefault();  //Verifica se há eventos no banco

                            if (teste1 != 0)
                            {
                                var maxEvento = bd.evento.Max(x => x.idEvento); //Maior evento

                                int teste2 = bd.candidatos.Select(x => x.idCandidatos).FirstOrDefault();  //Verifica se há candidatos no banco

                                if (teste2 != 0)
                                {
                                    var max3 = bd.candidatos.Max(x => x.idCandidatos);  //Maior candidato

                                    var dt1 = new DataTable();

                                    dt1.Columns.Add("ID_candidatos");
                                    dt1.Columns.Add("Nome");     //Adicionando colunas na tabela

                                    for (int i = 1; i <= maxEvento; i++)
                                    {
                                        var evento = bd.evento.Where(x => x.FK_usuario_empresa == empresa.cnpj).
                                        Where(x => x.idEvento == i).FirstOrDefault();

                                        if (evento != null)                                //Carrega os candidatos
                                        {
                                            for (int j = 1; j <= max3; j++)
                                            {
                                                var candidato = bd.candidatos.Where(y => y.FK_evento == i).
                                                Where(x => x.idCandidatos == j).FirstOrDefault();

                                                if (candidato != null)          //Carrega os interessados
                                                {
                                                    var usuarioTrab3 = bd.usuario_trabalhador
                                                    .Where(x => x.CPF == candidato.FK_usuario_trabalhador).FirstOrDefault();
                                                    var usuario3 = bd.usuario.Where(x => x.idUsuario == usuarioTrab3.FK_usuario).
                                                    FirstOrDefault();

                                                    dt1.Rows.Add(candidato.idCandidatos, usuario3.nomeUsuario);

                                                    dtCandidatos.DataSource = dt1; //Conecta com o GridView

                                                    this.dtCandidatos.Columns["ID_candidatos"].Visible = false;
                                                }
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    dtCandidatos.Visible = false;
                                }
                            }
                            else
                            {
                                dtCandidatos.Visible = false;
                            }
                        }
                        catch (Exception)
                        {
                            Mensagem.aviso = "Erro ao se conectar com o banco!";    //Verificação de campos 
                            TelaMensagemAviso f2 = new TelaMensagemAviso();
                            f2.ShowDialog();
                        }
                    }
                    catch (Exception)
                    {
                        Mensagem.aviso = "Erro ao excluir!";    //Verificação de campos 
                        TelaMensagemAviso f2 = new TelaMensagemAviso();
                        f2.ShowDialog();
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

        private void btConfirmar2_MouseEnter(object sender, EventArgs e)
        {
            btConfirmar2.ForeColor = Color.Black;
        }

        private void btConfirmar2_MouseLeave(object sender, EventArgs e)
        {
            btCancelar.ForeColor = Color.Black;
        }

        private void btCancelar_MouseEnter(object sender, EventArgs e)
        {
            btConfirmar2.ForeColor = Color.White;
        }

        private void btCancelar_MouseLeave(object sender, EventArgs e)
        {
            btCancelar.ForeColor = Color.White;
        }
    }
}
