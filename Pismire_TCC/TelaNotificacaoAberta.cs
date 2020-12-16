using Pismire_TCC.Resources;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Pismire_TCC
{
    public partial class TelaNotificacaoAberta : Form
    {
        PismireEntities5 bd = new PismireEntities5();

        public TelaNotificacaoAberta()
        {
            InitializeComponent();
            Maximizacao.verifique(this, pbMaximizar);   //Verifica se a tela está maximizada ou não

            try
            {
                var notificacao = bd.notificacao.Where(y => y.FK_usuario ==
                UsuarioDados.Id).Where(x => x.idNotificacao == PegarID.IDN).FirstOrDefault();

                lblTitulo.Text = notificacao.tituloNotificacao;
                lblTexto.Text = notificacao.textoNotificacao;
                lblData.Text = notificacao.dataNotificacao;
                lblHorario.Text = notificacao.horarioNotificacao;
            }
            catch (Exception)
            {
                Mensagem.aviso = "Erro de conexão com o banco!";
                TelaMensagemAviso f = new TelaMensagemAviso();
                f.ShowDialog();
            }
        }

        private void pbLixeira_Click(object sender, EventArgs e)
        {
            pLixeiraAberta.Visible = true;
            pbVoltar.Enabled = false;
            pbLixeira.Enabled = false;
        }

        private void btConf_Click(object sender, EventArgs e)
        {
            try
            {
                int qtd = Convert.ToInt32(bd.notificacao.Count(x => x.FK_usuario == UsuarioDados.Id));

                if (qtd != 1)
                {
                    var notf = bd.notificacao.Where(Z => Z.idNotificacao == PegarID.IDN).FirstOrDefault();

                    bd.notificacao.Remove(notf);
                    bd.SaveChanges();

                    try
                    {
                        int max = bd.notificacao.Max(x => x.idNotificacao);

                        var dt1 = new DataTable();

                        dt1.Columns.Add("ID_Notificacao");
                        dt1.Columns.Add("Título");
                        dt1.Columns.Add("Texto");
                        dt1.Columns.Add("Data");
                        dt1.Columns.Add("Horário");
                        dt1.Columns.Add("FK_usuario");

                        for (int i = 1; i <= max; i++)
                        {
                            var notificacao = bd.notificacao.Where(y => y.FK_usuario ==
                            UsuarioDados.Id).Where(x => x.idNotificacao == i).FirstOrDefault();

                            if (notificacao != null)
                            {
                                TelaNotificacao f = new TelaNotificacao();
                                dt1.Rows.Add(notificacao.idNotificacao, notificacao.tituloNotificacao,
                                notificacao.textoNotificacao, notificacao.dataNotificacao,
                                notificacao.horarioNotificacao, notificacao.FK_usuario);

                                f.dt.DataSource = dt1;

                                f.dt.Columns["ID_Notificacao"].Visible = false;
                                f.dt.Columns["FK_usuario"].Visible = false;
                            }
                        }

                        pLixeiraAberta.Visible = false;
                        pbVoltar.Enabled = true;
                        pbLixeira.Enabled = true;
                        Mensagem.aviso = "Excluído com sucesso!";
                        TelaMensagemAviso m = new TelaMensagemAviso();
                        m.ShowDialog();

                        this.Hide();
                        TelaNotificacao u = new TelaNotificacao();
                        u.Closed += (s, args) => this.Close();
                        u.ShowDialog();
                    }
                    catch (Exception)
                    {
                        pLixeiraAberta.Visible = false;
                        pbVoltar.Enabled = true;
                        pbLixeira.Enabled = true;
                        Mensagem.aviso = "Erro ao excluir!";
                        TelaMensagemAviso m = new TelaMensagemAviso();
                        m.ShowDialog();
                    }
                }
                else
                {
                    try
                    {
                        TelaNotificacao f = new TelaNotificacao();
                        var notf = bd.notificacao.Where(Z => Z.idNotificacao == PegarID.IDN).FirstOrDefault();

                        bd.notificacao.Remove(notf);

                        bd.SaveChanges();

                        f.dt.Columns.Clear();
                        pLixeiraAberta.Visible = false;
                        pbVoltar.Enabled = true;
                        pbLixeira.Enabled = true;
                        Mensagem.aviso = "Excluído com sucesso!";
                        TelaMensagemAviso m = new TelaMensagemAviso();
                        m.ShowDialog();

                        f.lblAviso.Visible = true;


                        this.Hide();
                        TelaNotificacao g = new TelaNotificacao();
                        g.Closed += (s, args) => this.Close();
                        g.ShowDialog();

                    }
                    catch
                    {
                        pLixeiraAberta.Visible = false;
                        pbVoltar.Enabled = true;
                        pbLixeira.Enabled = true;
                        Mensagem.aviso = "Erro ao excluir!";
                        TelaMensagemAviso m = new TelaMensagemAviso();
                        m.ShowDialog();
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

        private void btCancelar1_Click(object sender, EventArgs e)
        {
            pLixeiraAberta.Visible = false;
            pbVoltar.Enabled = true;
            pbLixeira.Enabled = true;
        }

        private void pbLixeira_MouseEnter(object sender, EventArgs e)
        {
            pbLixeira.Image = Properties.Resources.excluirRoxo;
        }

        private void pbLixeira_MouseLeave(object sender, EventArgs e)
        {
            pbLixeira.Image = Properties.Resources.excluir;                       //Animação dos icones
        }

        private void pbVoltar_MouseEnter(object sender, EventArgs e)
        {
            pbVoltar.Image = Properties.Resources.VoltarRoxo;
        }

        private void pbVoltar_MouseLeave(object sender, EventArgs e)
        {
            pbVoltar.Image = Properties.Resources.voltar;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            int x = (p_barra.Size.Width - lbl_notificacao.Width) / 2;
            int y = (p_barra.Size.Height - lbl_notificacao.Height);              //Posição da label na barra

            lbl_notificacao.Location = new Point(x, y);
        }

        private void p_barra_Resize(object sender, EventArgs e)
        {
            int x = (p_barra.Size.Width - lbl_notificacao.Width) / 2;
            int y = (p_barra.Size.Height - lbl_notificacao.Height);              //Posição da label na barra

            lbl_notificacao.Location = new Point(x, y);
        }

        private void pbVoltar_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            TelaNotificacao f = new TelaNotificacao();
            f.Closed += (s, args) => this.Close();            //Volta para tela notificacao
            f.ShowDialog();
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
            btCancelar.ForeColor = Color.Black;
        }

        private void btCancelar_MouseLeave(object sender, EventArgs e)
        {
            btCancelar.ForeColor = Color.White;
        }
    }
}
