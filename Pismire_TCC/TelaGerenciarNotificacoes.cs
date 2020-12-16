using Pismire_TCC.Resources;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Pismire_TCC
{
    public partial class TelaGerenciarNotificacoes : Form
    {
        PismireEntities5 bd = new PismireEntities5();

        public TelaGerenciarNotificacoes()
        {
            InitializeComponent();
            Maximizacao.verifique(this, pbMaximizar);   //Verifica se a tela está maximizada ou não

            try
            {

                int qtd = Convert.ToInt32(bd.notificacao.Count
                (x => x.FK_usuario == UsuarioDados.Id));

                if (qtd != 0)
                {

                    try
                    {
                        int max = bd.notificacao.Max(x => x.idNotificacao);

                        var dt1 = new DataTable();

                        dt1.Columns.Add("ID_Notificacao");
                        dt1.Columns.Add("Título");
                        dt1.Columns.Add("Texto");
                        dt1.Columns.Add("Data");
                        dt1.Columns.Add("Horário");                                      //Carrega todas as notificações do sistema
                        dt1.Columns.Add("situacaoNotificacao");
                        dt1.Columns.Add("FK_usuario");

                        for (int i = 1; i <= max; i++)
                        {
                            var notificacao = bd.notificacao.Where(y => y.FK_usuario ==
                            UsuarioDados.Id).Where(x => x.idNotificacao == i).FirstOrDefault();

                            if (notificacao != null)
                            {
                                dt1.Rows.Add(notificacao.idNotificacao, notificacao.tituloNotificacao,
                                notificacao.textoNotificacao, notificacao.dataNotificacao,
                                notificacao.horarioNotificacao, notificacao.situacaoNotificacao,
                                notificacao.FK_usuario);

                                dt.DataSource = dt1;

                                this.dt.Columns["ID_Notificacao"].Visible = false;
                                this.dt.Columns["situacaoNotificacao"].Visible = false;
                                this.dt.Columns["FK_usuario"].Visible = false;

                                this.dt.Columns["Título"].FillWeight = 60;
                                this.dt.Columns["Texto"].FillWeight = 100;
                                this.dt.Columns["Data"].FillWeight = 20;
                                this.dt.Columns["Horário"].FillWeight = 15;
                            }

                        }
                    }
                    catch (Exception)
                    {
                        Mensagem.aviso = "Erro ao se conectar com o banco!";    //Verificação do banco 
                        TelaMensagemAviso f = new TelaMensagemAviso();
                        f.ShowDialog();
                    }
                }
                else
                {
                    lblAviso.Visible = true;
                    pbLixeira.Visible = false;
                    btLimpar.Visible = false;
                }
            }
            catch (Exception)
            {
                Mensagem.aviso = "Erro ao conectar com o banco!";
                TelaMensagemAviso f = new TelaMensagemAviso();
                f.ShowDialog();
            }
        }

        private void pbLixeira_Click(object sender, EventArgs e)
        {
            if (lblAviso.Visible == false)
            {
                pLixeira.Visible = true;
                pbLixeira.Enabled = false;                 //Abre o panel lixeira 
                btLimpar.Enabled = false;
                pb_voltar.Enabled = false;
                dt.Enabled = false;
            }
        }

        private void btLimpar_Click(object sender, EventArgs e)
        {
            if (lblAviso.Visible == false)
            {
                pLimparAberto1.Visible = true;
                pbLixeira.Enabled = false;
                btLimpar.Enabled = false;           //Abre o painel limpar
                pb_voltar.Enabled = false;
                dt.Enabled = false;
            }
        }

        private void btCancelar1_Click(object sender, EventArgs e)
        {
            pLixeira.Visible = false;
            pbLixeira.Enabled = true;
            btLimpar.Enabled = true;
            pb_voltar.Enabled = true;
            dt.Enabled = true;
        }

        private void btLimparAberto_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblAviso.Visible == false)
                {
                    try
                    {
                        int max = bd.notificacao.Max(x => x.idNotificacao);

                        for (int i = 1; i <= max; i++)
                        {
                            var n = bd.notificacao.Where(x => x.idNotificacao == i).FirstOrDefault();

                            if (n != null)
                            {                             //Confirmação de limpeza de notificações  
                                bd.notificacao.Remove(n);

                                bd.SaveChanges();
                                dt.Columns.Clear();
                                lblAviso.Visible = true;
                            }
                        }
                        pLimparAberto1.Visible = false;
                        pbLixeira.Enabled = true;
                        btLimpar.Enabled = true;
                        pb_voltar.Enabled = true;
                        dt.Enabled = true;
                        Mensagem.aviso = "Excluido com sucesso!";
                        TelaMensagemAviso f = new TelaMensagemAviso();
                        f.ShowDialog();
                        lblAviso.Visible = true;
                        pbLixeira.Visible = false;
                        btLimpar.Visible = false;
                    }
                    catch (Exception)
                    {
                        pLimparAberto1.Visible = false;
                        pbLixeira.Enabled = true;
                        btLimpar.Enabled = true;
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
                Mensagem.aviso = "Erro ao conectar com o banco!";
                TelaMensagemAviso f = new TelaMensagemAviso();
                f.ShowDialog();
            }
        }

        private void btCancelarAberto_Click(object sender, EventArgs e)
        {
            pLimparAberto1.Visible = false;
            pbLixeira.Enabled = true;
            btLimpar.Enabled = true;                             //cancelar exclusão
            pb_voltar.Enabled = true;
            dt.Enabled = true;
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

        private void p_barra_Paint(object sender, PaintEventArgs e)
        {
            int x = (p_barra.Size.Width - lbl_notificacoes.Width) / 2;
            int y = (p_barra.Size.Height - lbl_notificacoes.Height);       //Posição da label na barra

            lbl_notificacoes.Location = new Point(x, y);
        }

        private void p_barra_Resize(object sender, EventArgs e)
        {

            int x = (p_barra.Size.Width - lbl_notificacoes.Width) / 2;
            int y = (p_barra.Size.Height - lbl_notificacoes.Height);       //Posição da label na barra ao maximizar

            lbl_notificacoes.Location = new Point(x, y);
        }

        private void pb_voltar_MouseEnter(object sender, EventArgs e)
        {
            pb_voltar.Image = Properties.Resources.VoltarRoxo;                       //Animação dos icones
        }

        private void pb_voltar_MouseLeave(object sender, EventArgs e)
        {
            pb_voltar.Image = Properties.Resources.VoltarRoxo;
        }

        private void pb_voltar_Click(object sender, EventArgs e)
        {
            this.Hide();
            TelaNotificacaoADM f = new TelaNotificacaoADM();             //Voltar para a tela anterior 
            f.Closed += (s, args) => this.Close();
            f.ShowDialog();
        }

        private void btConfirmar2_MouseEnter(object sender, EventArgs e)
        {
            btConfirmar2.ForeColor = Color.Black;
        }

        private void btConfirmar2_MouseLeave(object sender, EventArgs e)
        {
            btConfirmar2.ForeColor = Color.White;
        }

        private void btCancelar2_MouseEnter(object sender, EventArgs e)
        {
            btCancelar2.ForeColor = Color.Black;
        }

        private void btCancelar2_MouseLeave(object sender, EventArgs e)
        {
            btCancelar2.ForeColor = Color.White;
        }

        private void btConfirmar_MouseEnter(object sender, EventArgs e)
        {
            btConfirmar.ForeColor = Color.Black;
        }

        private void btConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblAviso.Visible == false)
                {
                    int qtd = Convert.ToInt32(bd.notificacao.Count(x => x.FK_usuario == UsuarioDados.Id));

                    if (qtd != 0)
                    {
                        int max2 = bd.notificacao.Max(x => x.FK_usuario);
                        int id = Convert.ToInt32(dt.CurrentRow.Cells[0].Value);
                        var notfPrincipal = bd.notificacao.Where(Z => Z.idNotificacao == id).FirstOrDefault();
                        string titulo = notfPrincipal.tituloNotificacao.ToString();

                        for (int i = 1; i <= max2; i++)
                        {
                            var notf = bd.notificacao.Where(x => x.tituloNotificacao == titulo).Where(y => y.FK_usuario == i).FirstOrDefault();

                            if (notf != null)
                            {
                                bd.notificacao.Remove(notf);
                                bd.SaveChanges();
                            }

                        }

                        try
                        {
                            int qtd2 = bd.notificacao.Count(x => x.FK_usuario == UsuarioDados.Id);
                            if (qtd2 == 0)
                            {
                                dt.Columns.Clear();
                                pLixeira.Visible = false;
                                pbLixeira.Enabled = true;
                                btLimpar.Enabled = true;
                                pb_voltar.Enabled = true;
                                dt.Enabled = true;
                                Mensagem.aviso = "Excluido com sucesso!";
                                TelaMensagemAviso f = new TelaMensagemAviso();
                                f.ShowDialog();
                                lblAviso.Visible = true;
                                pbLixeira.Visible = false;
                                btLimpar.Visible = false;
                            }
                            else
                            {
                                int max = bd.notificacao.Max(x => x.idNotificacao);

                                var dt1 = new DataTable();

                                dt1.Columns.Add("ID_Notificacao");
                                dt1.Columns.Add("Título");
                                dt1.Columns.Add("Texto");
                                dt1.Columns.Add("Data");
                                dt1.Columns.Add("Horário");                    //Novo carregamento
                                dt1.Columns.Add("situacaoVisualizar");
                                dt1.Columns.Add("FK_usuario");

                                for (int i = 1; i <= max; i++)

                                {
                                    var notificacao = bd.notificacao.Where(y => y.FK_usuario ==
                                    UsuarioDados.Id).Where(x => x.idNotificacao == i).FirstOrDefault();

                                    if (notificacao != null)
                                    {
                                        dt1.Rows.Add(notificacao.idNotificacao, notificacao.tituloNotificacao,
                                        notificacao.textoNotificacao, notificacao.dataNotificacao,
                                        notificacao.horarioNotificacao, notificacao.situacaoNotificacao,
                                        notificacao.FK_usuario);

                                        dt.DataSource = dt1;

                                        this.dt.Columns["ID_Notificacao"].Visible = false;
                                        this.dt.Columns["FK_usuario"].Visible = false;
                                        this.dt.Columns["situacaoVisualizar"].Visible = false;
                                    }

                                }
                                pLixeira.Visible = false;
                                pbLixeira.Enabled = true;
                                btLimpar.Enabled = true;
                                pb_voltar.Enabled = true;
                                dt.Enabled = true;
                                Mensagem.aviso = "Excluido com sucesso!";
                                TelaMensagemAviso f = new TelaMensagemAviso();
                                f.ShowDialog();
                            }
                        }
                        catch (Exception)
                        {
                            pLixeira.Visible = false;
                            pbLixeira.Enabled = true;
                            btLimpar.Enabled = true;
                            pb_voltar.Enabled = true;
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
                            PegarID.IDN = Convert.ToInt16(dt.CurrentRow.Cells[0].Value);

                            var notf = bd.notificacao.Where(Z => Z.idNotificacao == PegarID.IDN).FirstOrDefault();

                            bd.notificacao.Remove(notf);

                            bd.SaveChanges();

                            dt.Columns.Clear();
                            pLixeira.Visible = false;
                            pbLixeira.Enabled = true;
                            btLimpar.Enabled = true;
                            pb_voltar.Enabled = true;
                            dt.Enabled = true;
                            Mensagem.aviso = "Excluido com sucesso!";
                            TelaMensagemAviso f = new TelaMensagemAviso();
                            f.ShowDialog();

                            lblAviso.Visible = true;
                            pbLixeira.Visible = false;
                            btLimpar.Visible = false;
                        }
                        catch
                        {
                            pLixeira.Visible = false;
                            pbLixeira.Enabled = true;
                            btLimpar.Enabled = true;
                            pb_voltar.Enabled = true;
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

        private void btConfirmar_MouseLeave(object sender, EventArgs e)
        {
            btConfirmar.ForeColor = Color.White;
        }

        private void btCancelar_MouseEnter(object sender, EventArgs e)
        {
            btCancelar.ForeColor = Color.Black;                                //Animação de botões
        }

        private void btCancelar_MouseLeave(object sender, EventArgs e)
        {
            btCancelar.ForeColor = Color.White;
        }
    }
}
