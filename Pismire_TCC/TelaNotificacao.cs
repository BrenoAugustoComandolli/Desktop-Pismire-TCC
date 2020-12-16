using Pismire_TCC.Resources;
using System;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Pismire_TCC
{
    public partial class TelaNotificacao : Form
    {
        PismireEntities5 bd = new PismireEntities5();

        public TelaNotificacao()
        {
            InitializeComponent();
            Maximizacao.verifique(this, pbMaximizar);   //Verifica se a tela está maximizada ou não

            try
            {
                int qtd = Convert.ToInt32(bd.notificacao.Count     //Número de notificações
                (x => x.FK_usuario == UsuarioDados.Id));

                if (qtd != 0)                                      //Verifica quantidade de ids
                {
                    try
                    {
                        int max = bd.notificacao.Max(x => x.idNotificacao);    //Maior ID

                        var dt1 = new DataTable();

                        dt1.Columns.Add("ID_Notificacao");
                        dt1.Columns.Add("Título");
                        dt1.Columns.Add("Texto");               //Cria as Colunas
                        dt1.Columns.Add("Data");
                        dt1.Columns.Add("Horário");
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

                                dt.DataSource = dt1; //Conecta com o GridView

                                this.dt.Columns["ID_Notificacao"].Visible = false;
                                this.dt.Columns["situacaoNotificacao"].Visible = false;  //Tira as que não precisa
                                this.dt.Columns["FK_usuario"].Visible = false;

                                this.dt.Columns["Título"].FillWeight = 60;
                                this.dt.Columns["Texto"].FillWeight = 100;
                                this.dt.Columns["Data"].FillWeight = 20;          //Ajusta o tamanho
                                this.dt.Columns["Horário"].FillWeight = 15;

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
                    lblAviso.Visible = true;          //Nenhuma notificação
                    lblAtivado.Visible = false;
                    lblDesativado.Visible = false;
                    dt.Visible = false;
                    pbLixeira.Visible = false;
                    btLimpar.Visible = false;
                }
            }
            catch (Exception)
            {
                Mensagem.aviso = "Erro de conexão com o banco!";
                TelaMensagemAviso f = new TelaMensagemAviso();
                f.ShowDialog();
            }
        }

        private void dt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    PegarID.IDN = Convert.ToInt16(dt.CurrentRow.Cells[0].Value);    //Abre a notificação
                    var notificacao = bd.notificacao.Where(y => y.FK_usuario ==
                    UsuarioDados.Id).Where(x => x.idNotificacao == PegarID.IDN).FirstOrDefault();

                    if (notificacao.situacaoNotificacao == false)
                    {
                        notificacao.situacaoNotificacao = true;
                        bd.SaveChanges();
                    }

                    this.Hide();
                    TelaNotificacaoAberta f = new TelaNotificacaoAberta();
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
        }

        private void dt_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            PegarID.IDN = Convert.ToInt16(dt.CurrentRow.Cells[0].Value);   //Abre a notificação
            var notificacao = bd.notificacao.Where(y => y.FK_usuario ==
                UsuarioDados.Id).Where(x => x.idNotificacao == PegarID.IDN).FirstOrDefault();

            if (notificacao.situacaoNotificacao == false)
            {
                notificacao.situacaoNotificacao = true;
                bd.SaveChanges();
            }

            this.Hide();
            TelaNotificacaoAberta f = new TelaNotificacaoAberta();
            f.Closed += (s, args) => this.Close();
            f.ShowDialog();
        }

        private void pbLixeira_Click(object sender, EventArgs e)
        {
            pLixeira.Visible = true;
            pbLixeira.Enabled = false;                  //Abre confimação de exclusão 
            btLimpar.Enabled = false;
            pb_voltar.Enabled = false;
            pbLixeira.Enabled = false;
            dt.Enabled = false;
        }

        private void btLimpar_Click(object sender, EventArgs e)
        {
            pLimparAberto.Visible = true;
            pbLixeira.Enabled = false;
            btLimpar.Enabled = false;               //Abre confirmação de limpar tudo
            pb_voltar.Enabled = false;
            dt.Enabled = false;
        }

        private void dt_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            PegarID.IDN = Convert.ToInt32(dt.CurrentRow.Cells[0].Value);

            var notf = bd.notificacao.Where(Z => Z.idNotificacao == PegarID.IDN).FirstOrDefault();

            if (notf.situacaoNotificacao == true)
            {
                lblAtivado.Visible = true;                         //Abre a notificação
                lblDesativado.Visible = false;
            }
            else
            {
                lblAtivado.Visible = false;
                lblDesativado.Visible = true;
            }
        }

        private void p_barra_Paint(object sender, PaintEventArgs e)
        {
            int x = (p_barra.Size.Width - lbl_notificacao.Width) / 2;
            int y = (p_barra.Size.Height - lbl_notificacao.Height);              //Posição da label na barra

            lbl_notificacao.Location = new Point(x, y);
        }

        private void p_barra_Resize(object sender, EventArgs e)
        {
            int x = (p_barra.Size.Width - lbl_notificacao.Width) / 2;
            int y = (p_barra.Size.Height - lbl_notificacao.Height);       //Posição da label na barra ao maximizar e desmaximizar 

            lbl_notificacao.Location = new Point(x, y);
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            pLimparAberto.Visible = false;
            pbLixeira.Enabled = true;
            btLimpar.Enabled = true;
            pb_voltar.Enabled = true;               //Cancela a exclusão
            dt.Enabled = true;
        }

        private void btCancelar2_Click(object sender, EventArgs e)
        {
            pLixeira.Visible = false;
            pbLixeira.Enabled = true;
            btLimpar.Enabled = true;         //Cancela a exclusão
            pb_voltar.Enabled = true;
            dt.Enabled = true;
        }

        private void btConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                int qtd = Convert.ToInt32(bd.notificacao.Count(x => x.FK_usuario == UsuarioDados.Id));

                if (qtd != 1)
                {

                    PegarID.IDN = Convert.ToInt32(dt.CurrentRow.Cells[0].Value);

                    var notf = bd.notificacao.Where(Z => Z.idNotificacao == PegarID.IDN).FirstOrDefault();

                    bd.notificacao.Remove(notf);

                    bd.SaveChanges();

                    try
                    {
                        int max = bd.notificacao.Max(x => x.idNotificacao);

                        var dt1 = new DataTable();

                        dt1.Columns.Add("ID_Notificacao");                                //Confirmação de exclusão de mensagem
                        dt1.Columns.Add("Título");
                        dt1.Columns.Add("Texto");
                        dt1.Columns.Add("Data");
                        dt1.Columns.Add("Horário");
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
                        Mensagem.aviso = "Excluído com sucesso!";
                        TelaMensagemAviso f = new TelaMensagemAviso();
                        f.ShowDialog();

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
                        dt.Visible = false;
                        lblAviso.Visible = true;
                        lblDesativado.Visible = false;
                        lblAtivado.Visible = false;
                        pbLixeira.Visible = false;
                        btLimpar.Visible = false;
                        Mensagem.aviso = "Excluído com sucesso!";
                        TelaMensagemAviso f = new TelaMensagemAviso();
                        f.ShowDialog();
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
            catch (Exception)
            {
                Mensagem.aviso = "Erro de conexão com o banco!";
                TelaMensagemAviso f = new TelaMensagemAviso();
                f.ShowDialog();
            }
        }

        private void btConfirmar2_Click(object sender, EventArgs e)
        {
            try
            {
                int max = bd.notificacao.Max(x => x.idNotificacao);

                for (int i = 1; i <= max; i++)
                {
                    var n = bd.notificacao.Where(y => y.FK_usuario == UsuarioDados.Id).Where(x => x.idNotificacao == i).FirstOrDefault();

                    if (n != null)
                    {
                        bd.notificacao.Remove(n);             //Confirmação de exclusão de todas as mensagens

                        bd.SaveChanges();
                        dt.Columns.Clear();
                        lblAviso.Visible = true;
                        lblAtivado.Visible = false;
                        lblDesativado.Visible = false;
                        pbLixeira.Visible = false;
                        btLimpar.Visible = false;
                    }
                }
                pLimparAberto.Visible = false;
                pbLixeira.Enabled = true;
                btLimpar.Enabled = true;
                pb_voltar.Enabled = true;
                dt.Enabled = true;
                dt.Visible = false;
                Mensagem.aviso = "Excluído com sucesso!";
                TelaMensagemAviso f = new TelaMensagemAviso();
                f.ShowDialog();
            }
            catch (Exception)
            {
                pLimparAberto.Visible = false;
                pbLixeira.Enabled = true;
                btLimpar.Enabled = true;
                pb_voltar.Enabled = true;
                dt.Enabled = true;
                Mensagem.aviso = "Erro ao excluir!";
                TelaMensagemAviso f = new TelaMensagemAviso();
                f.ShowDialog();
            }
        }

        private void pbVoltar_MouseEnter(object sender, EventArgs e)
        {
            pb_voltar.Image = Properties.Resources.VoltarRoxo;
        }

        private void pbVoltar_MouseLeave(object sender, EventArgs e)
        {
            pb_voltar.Image = Properties.Resources.voltar;
        }

        private void pbLixeira_MouseEnter(object sender, EventArgs e)
        {
            pbLixeira.Image = Properties.Resources.excluirRoxo;
        }                                                                        

        private void pbLixeira_MouseLeave(object sender, EventArgs e)
        {
            pbLixeira.Image = Properties.Resources.excluir;
        }

        private void pb_voltar_MouseEnter(object sender, EventArgs e)
        {
            pb_voltar.Image = Properties.Resources.VoltarRoxo;
        }

        private void pb_voltar_MouseLeave(object sender, EventArgs e)
        {
            pb_voltar.Image = Properties.Resources.voltar;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            int x = (p_barra.Size.Width - lbl_notificacao.Width) / 2;
            int y = (p_barra.Size.Height - lbl_notificacao.Height);              //Posição da label na barra ao maximizar e desmaximizar 

            lbl_notificacao.Location = new Point(x, y);
        }

        private void p_barra_Resize_1(object sender, EventArgs e)
        {
            int x = (p_barra.Size.Width - lbl_notificacao.Width) / 2;
            int y = (p_barra.Size.Height - lbl_notificacao.Height);              //Posição da label na barra ao maximizar e desmaximizar 

            lbl_notificacao.Location = new Point(x, y);
        }

        private void pb_voltar_Click(object sender, EventArgs e)
        {
            var voltar = bd.usuario.Where(x => x.idUsuario == UsuarioDados.Id).Where(y => y.tipoUsuario == false).FirstOrDefault();
            if (voltar != null)
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

        private void btConfirmar2_MouseEnter(object sender, EventArgs e)
        {
            btConfirmar2.ForeColor = Color.Black;
        }

        private void btCancelar_MouseEnter(object sender, EventArgs e)
        {
            btCancelar.ForeColor = Color.Black;
        }                                                                

        private void btCancelar2_MouseEnter(object sender, EventArgs e)
        {
            btCancelar2.ForeColor = Color.Black;
        }

        private void btConfirmar_MouseEnter(object sender, EventArgs e)
        {
            btConfirmar.ForeColor = Color.Black;
        }

        private void btConfirmar2_MouseLeave(object sender, EventArgs e)
        {
            btConfirmar2.ForeColor = Color.White;
        }

        private void btCancelar_MouseLeave(object sender, EventArgs e)
        {
            btCancelar.ForeColor = Color.White;
        }

        private void btConfirmar_MouseLeave(object sender, EventArgs e)
        {
            btConfirmar.ForeColor = Color.White;
        }

        private void btCancelar2_MouseLeave(object sender, EventArgs e)
        {
            btCancelar2.ForeColor = Color.White;
        }
    }
}

