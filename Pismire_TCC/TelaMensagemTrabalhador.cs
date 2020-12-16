using Pismire_TCC.Resources;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Pismire_TCC
{
    public partial class TelaMensagemTrabalhador : Form
    {
        PismireEntities5 bd = new PismireEntities5();

        public bool contCand = false;
        public bool contInt = false;         //Propriedades
        public bool contRec = false;
        public int empresaSelecionada;

        List<string> empresas = new List<string>();

        public TelaMensagemTrabalhador()
        {
            InitializeComponent();
            Maximizacao.verifique(this, pbMaximizar);   //Verifica se a tela está maximizada ou não

            try
            {
                Maximizacao.verifique(this, pbMaximizar);   //Verifica se a tela está maximizada ou não

                int idSelecionado = PegarID.IDN; //ID clicado na gridview

                int tipoUsuario = PegarID.Identificar;  //Tipo do usuario clicado

                var trabalhador = bd.usuario_trabalhador.Where(x => x.FK_usuario == UsuarioDados.Id).FirstOrDefault();

                var mensagemTeste = bd.mensagem.Where(x => x.FK_usuario != 0).FirstOrDefault();

                if (mensagemTeste != null)
                {
                    int max = bd.mensagem.Max(x => x.idMensagem);

                    for (int i = 1; i <= max; i++)
                    {
                        var mensagem = bd.mensagem.Where(x => x.destinatarioMensagem == UsuarioDados.Id).FirstOrDefault();

                        if (mensagem != null)
                        {
                            var empresa = bd.usuario_empresa.Where(x => x.FK_usuario == mensagem.FK_usuario).FirstOrDefault();
                            if (!empresas.Contains(empresa.cnpj))
                            {
                                empresas.Add(empresa.cnpj);
                            }
                        }
                    }
                }

                if (empresas.Count > 0)
                {
                    try
                    {
                        int max = bd.usuario_empresa.Max(x => x.FK_usuario);    //Maior ID

                        var dt1 = new DataTable();

                        dt1.Columns.Add("cnpj_empresa");
                        dt1.Columns.Add("Nome");               //Adicionando colunas na tabela

                        for (int i = 0; i < empresas.Count; i++)
                        {
                            string cnpj = empresas.ElementAt(i).ToString();
                            var usuEmpresa = bd.usuario_empresa.Where(x => x.cnpj.Equals(cnpj)).FirstOrDefault();

                            if (usuEmpresa != null)
                            {
                                var usuario = bd.usuario.Where(x => x.idUsuario == usuEmpresa.FK_usuario).FirstOrDefault();

                                dt1.Rows.Add(usuEmpresa.cnpj, usuario.nomeUsuario);       //Carrega os recomendados 

                                dtEmpresas.DataSource = dt1; //Conecta com o GridView

                                this.dtEmpresas.Columns["cnpj_empresa"].Visible = false;
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
                    pnMenssagens.Visible = false;
                    pnEnvio.Visible = false;
                    dtEmpresas.Visible = false;
                    pnDesign.Visible = false;
                    pnCabecalho.Visible = false;
                }
            }
            catch (Exception)
            {
                Mensagem.aviso = "Erro ao se conectar com o banco!";    //Verificação de campos 
                TelaMensagemAviso f = new TelaMensagemAviso();
                f.ShowDialog();
            }
        }

        private void dtEmpresas_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                string id = Convert.ToString(dtEmpresas.CurrentRow.Cells[0].Value);              //Pega as informações do usuário ao clicar
                var usuEmpresa = bd.usuario_empresa.Where(x => x.cnpj == id).FirstOrDefault();
                var usuario = bd.usuario.Where(x => x.idUsuario == usuEmpresa.FK_usuario).FirstOrDefault();

                empresaSelecionada = usuario.idUsuario;

                pbAviso2.Visible = false;
                lblAviso2.Visible = false;
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

        private void dtEmpresas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string id = Convert.ToString(dtEmpresas.CurrentRow.Cells[0].Value);              //Pega as informações do usuário ao clicar
                var usuEmpresa = bd.usuario_empresa.Where(x => x.cnpj == id).FirstOrDefault();
                var usuario = bd.usuario.Where(x => x.idUsuario == usuEmpresa.FK_usuario).FirstOrDefault();

                empresaSelecionada = usuario.idUsuario;

                pbAviso2.Visible = false;
                lblAviso2.Visible = false;
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

        public void carregarMensagens(int idEmpresa)
        {
            Maximizacao.verifique(this, pbMaximizar);   //Verifica se a tela está maximizada ou não

            try
            {

                var testeQtd = bd.mensagem.Where(x => x.FK_usuario == idEmpresa).Where
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
                            UsuarioDados.Id).Where(x => x.FK_usuario == idEmpresa).Where(x => x.idMensagem == i).FirstOrDefault();

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

        private void pbBarra_Resize_1(object sender, EventArgs e)
        {
            int x = (pbBarra.Size.Width - lblMensagem.Width) / 2;
            int y = (pbBarra.Size.Height - lblMensagem.Height);              //Posição da label na barra ao maximizar e desmaximizar 

            lblMensagem.Location = new Point(x, y);
        }

        private void pb_voltar_MouseEnter(object sender, EventArgs e)
        {
            pbVoltar.Image = Properties.Resources.VoltarRoxo;
        }

        private void pb_voltar_MouseLeave(object sender, EventArgs e)
        {
            pbVoltar.Image = Properties.Resources.voltar;
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
                    add.destinatarioMensagem = empresaSelecionada;            //Enviar notificacao
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
                string id = Convert.ToString(dtEmpresas.CurrentRow.Cells[0].Value);              //Pega as informações do usuário ao clicar
                var usuEmpresa = bd.usuario_empresa.Where(x => x.cnpj == id).FirstOrDefault();
                var usuario = bd.usuario.Where(x => x.idUsuario == usuEmpresa.FK_usuario).FirstOrDefault();

                empresaSelecionada = usuario.idUsuario;

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

        private void pbLixeira_Click(object sender, EventArgs e)
        {
            if (dt.CurrentCell != null)
            {
                pbLixeira.Enabled = false;           //Abre confimação de exclusão 
                pbVoltar.Enabled = false;
                dtEmpresas.Enabled = false;
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
            dtEmpresas.Enabled = true;
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
                    dtEmpresas.Enabled = true;
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
                            UsuarioDados.Id).Where(x => x.FK_usuario == empresaSelecionada).Where(x => x.idMensagem == i).FirstOrDefault();

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
                        dtEmpresas.Enabled = true;
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
                        dtEmpresas.Enabled = true;
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

                        try
                        {
                            int tipoUsuario = PegarID.Identificar;  //Tipo do usuario clicado

                            var trabalhador = bd.usuario_trabalhador.Where(x => x.FK_usuario == UsuarioDados.Id).FirstOrDefault();

                            var mensagemTeste = bd.mensagem.Where(x => x.FK_usuario != 0).FirstOrDefault();

                            empresas.Clear();

                            if (mensagemTeste != null)
                            {
                                int max = bd.mensagem.Max(x => x.idMensagem);

                                for (int i = 1; i <= max; i++)
                                {
                                    var mensagem = bd.mensagem.Where(x => x.destinatarioMensagem == UsuarioDados.Id).FirstOrDefault();

                                    if (mensagem != null)
                                    {
                                        var empresa = bd.usuario_empresa.Where(x => x.FK_usuario == mensagem.FK_usuario).FirstOrDefault();
                                        if (!empresas.Contains(empresa.cnpj))
                                        {
                                            empresas.Add(empresa.cnpj);
                                        }
                                    }
                                }
                            }

                            if (empresas.Count > 0)
                            {
                                try
                                {
                                    int max = bd.usuario_empresa.Max(x => x.FK_usuario);    //Maior ID

                                    var dt1 = new DataTable();

                                    dt1.Columns.Add("cnpj_empresa");
                                    dt1.Columns.Add("Nome");               //Adicionando colunas na tabela

                                    for (int i = 0; i < empresas.Count; i++)
                                    {
                                        string cnpj = empresas.ElementAt(i).ToString();
                                        var usuEmpresa = bd.usuario_empresa.Where(x => x.cnpj.Equals(cnpj)).FirstOrDefault();

                                        if (usuEmpresa != null)
                                        {
                                            var usuario = bd.usuario.Where(x => x.idUsuario == usuEmpresa.FK_usuario).FirstOrDefault();

                                            dt1.Rows.Add(usuEmpresa.cnpj, usuario.nomeUsuario);       //Carrega os recomendados 

                                            dtEmpresas.DataSource = dt1; //Conecta com o GridView

                                            this.dtEmpresas.Columns["cnpj_empresa"].Visible = false;
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
                                pnMenssagens.Visible = false;
                                pnEnvio.Visible = false;
                                dtEmpresas.Visible = false;
                                pnDesign.Visible = false;
                                pnCabecalho.Visible = false;
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

        private void btCancelar_MouseEnter(object sender, EventArgs e)
        {
            btCancelar.ForeColor = Color.Black;
        }

        private void btConfirmar2_MouseLeave(object sender, EventArgs e)
        {
            btConfirmar2.ForeColor = Color.White;
        }

        private void btCancelar_MouseLeave(object sender, EventArgs e)
        {
            btCancelar.ForeColor = Color.White;
        }

        private void dt_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dt.CurrentCell != null)
            {
                PegarID.IDN = Convert.ToInt32(dt.CurrentRow.Cells[0].Value);                          //Abre a notificação

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

        private void pbBarra_Paint(object sender, PaintEventArgs e)
        {
            int x = (pbBarra.Size.Width - lblMensagem.Width) / 2;
            int y = (pbBarra.Size.Height - lblMensagem.Height);              //Posição da label na barra ao maximizar e desmaximizar 

            lblMensagem.Location = new Point(x, y);
        }

        private void pbVoltar_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            TelaPrincipalTrabalhador f = new TelaPrincipalTrabalhador();
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

        private void pbBarra_Resize(object sender, EventArgs e)
        {
            int x = (pbBarra.Size.Width - lblMensagem.Width) / 2;
            int y = (pbBarra.Size.Height - lblMensagem.Height);              //Posição da label na barra ao maximizar e desmaximizar 

            lblMensagem.Location = new Point(x, y);
        }
    }
}
