using Pismire_TCC.Resources;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Pismire_TCC
{
    public partial class TelaInteresses : Form
    {
        PismireEntities5 bd = new PismireEntities5();
        public TelaInteresses()
        {
            InitializeComponent();
            Maximizacao.verifique(this, pbMaximizar);
            CarregaDados();
        }

        private void CarregaDados()
        {
            try
            {
                var usuario = bd.usuario_trabalhador.Where(x => x.FK_usuario == UsuarioDados.Id).FirstOrDefault();
                if (usuario != null)
                {
                    var verifica = bd.interessados_trabalhador.Where(x => x.idInteressadosTrabalhador != 0).FirstOrDefault();
                    if (verifica != null)
                    {
                        int max = bd.interessados_trabalhador.Max(x => x.idInteressadosTrabalhador);

                        var dt1 = new DataTable();

                        dt1.Columns.Add("idEmpresa");                           //Adicionando interessados na gridview
                        dt1.Columns.Add("NomeEmpresa");
                        dt1.Columns.Add("Cargo");
                        dt1.Columns.Add("Salario");
                        dt1.Columns.Add("Turno");

                        for (int i = 1; i <= max; i++)
                        {
                            var interesse = bd.interessados_trabalhador.Where(x => x.FK_usuario_trabalhador == usuario.CPF).Where(y => y.idInteressadosTrabalhador == i).FirstOrDefault();

                            if (interesse != null)
                            {
                                var evento = bd.evento.Where(x => x.idEvento == interesse.FK_evento).FirstOrDefault();
                                var empresa = bd.usuario_empresa.Where(x => x.cnpj == evento.FK_usuario_empresa).FirstOrDefault();
                                var usuario2 = bd.usuario.Where(x => x.idUsuario == empresa.FK_usuario).FirstOrDefault();

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
                                dt1.Rows.Add(evento.idEvento, usuario2.nomeUsuario, evento.vagaEvento, $"R$: {txt}", evento.turno);

                                dtInteressados.DataSource = dt1;

                                this.dtInteressados.Columns["idEmpresa"].Visible = false;
                            }
                        }
                    }
                    else
                    {
                        esconde();
                    }
                }
                else
                {
                    esconde();
                }
            }
            catch (Exception)
            {
                Mensagem.aviso = "Erro ao conectar com o banco!";
                TelaMensagemAviso f = new TelaMensagemAviso();
                f.ShowDialog();
            }
        }

        private void esconde()
        {
            lblAviso.Visible = true;
            dtInteressados.Visible = false;
            panel2.Visible = false;
            pbChat.Visible = false;
            pnLixeira.Visible = false;
            pCabecalho.Visible = false;
        }

        private void pb_voltar_Click(object sender, EventArgs e)
        {
            this.Hide();
            TelaPrincipalTrabalhador f = new TelaPrincipalTrabalhador();
            f.Closed += (s, args) => this.Close();
            f.ShowDialog();
        }

        private void pb_voltar_MouseEnter(object sender, EventArgs e)
        {
            pb_voltar.Image = Properties.Resources.VoltarRoxo;
        }

        private void pb_voltar_MouseHover(object sender, EventArgs e)
        {
            pb_voltar.Image = Properties.Resources.VoltarRoxo;
        }

        private void pb_voltar_MouseLeave(object sender, EventArgs e)
        {
            pb_voltar.Image = Properties.Resources.voltar;
        }

        private void p_barra_Paint(object sender, PaintEventArgs e)
        {
            int x = (p_barra.Size.Width - lb_interessados.Width) / 2;
            int y = (p_barra.Size.Height - lb_interessados.Height);              //Posição da label na barra

            lb_interessados.Location = new Point(x, y);
        }

        private void p_barra_Resize(object sender, EventArgs e)
        {
            int x = (p_barra.Size.Width - lb_interessados.Width) / 2;
            int y = (p_barra.Size.Height - lb_interessados.Height);              //Posição da label na barra

            lb_interessados.Location = new Point(x, y);
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
            this.WindowState = FormWindowState.Minimized;
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

        private void pbLixeira_MouseEnter(object sender, EventArgs e)
        {
            pbLixeira.Image = Properties.Resources.excluirRoxo;
        }

        private void pbLixeira_MouseHover(object sender, EventArgs e)
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

        private void pnLixeira_MouseHover(object sender, EventArgs e)
        {
            pbLixeira.Image = Properties.Resources.excluirRoxo;
        }

        private void pnLixeira_MouseLeave(object sender, EventArgs e)
        {
            pbLixeira.Image = Properties.Resources.excluir;
        }

        private void lblAviso_Paint(object sender, PaintEventArgs e)
        {
            int x = (this.Size.Width - lblAviso.Width) / 2;
            int y = (this.Size.Height - lblAviso.Height) / 2;              //Posição da label no form

            lblAviso.Location = new Point(x, y);
        }

        private void lblAviso_Resize(object sender, EventArgs e)
        {
            int x = (this.Size.Width - lblAviso.Width) / 2;
            int y = (this.Size.Height - lblAviso.Height) / 2;              //Posição da label no form

            lblAviso.Location = new Point(x, y);
        }

        private void pnLixeira_Click(object sender, EventArgs e)
        {
            pLimparAberto.Visible = true;
        }

        private void pbLixeira_Click(object sender, EventArgs e)
        {
            pLimparAberto.Visible = true;
        }

        private void btConfirmar2_Click(object sender, EventArgs e)
        {
            try
            {
                int idEvento = Convert.ToInt32(dtInteressados.CurrentRow.Cells[0].Value);

                var evento = bd.interessados_trabalhador.Where(x => x.FK_evento == idEvento).FirstOrDefault();

                bd.interessados_trabalhador.Remove(evento);
                bd.SaveChanges();

                pLimparAberto.Visible = false;
                Mensagem.aviso = "Excluido com sucesso!";
                TelaMensagemAviso f = new TelaMensagemAviso();
                f.ShowDialog();

                CarregaDados();
            }
            catch (Exception)
            {
                Mensagem.aviso = "Erro de conexão com o banco!";
                TelaMensagemAviso f = new TelaMensagemAviso();
                f.ShowDialog();
            }
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            pLimparAberto.Visible = false;
        }

        private void pbChat_Click(object sender, EventArgs e)
        {
            this.Hide();
            TelaMensagemTrabalhador f = new TelaMensagemTrabalhador();
            f.Closed += (s, args) => this.Close();
            f.ShowDialog();
        }

        private void dtInteressados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            PegarIDVaga.IDVaga = Convert.ToInt32(dtInteressados.CurrentRow.Cells[0].Value);

            VoltarTelaInteressado.bVoltar = true;

            this.Hide();
            TelaVisualizacaoVagas f = new TelaVisualizacaoVagas();
            f.Closed += (s, args) => this.Close();
            f.ShowDialog();
        }

        private void pbChat_MouseEnter(object sender, EventArgs e)
        {
            pbChat.Image = Properties.Resources.chatRoxo1;
        }

        private void pbChat_MouseLeave(object sender, EventArgs e)
        {
            pbChat.Image = Properties.Resources.chatAzul;
        }
    }
}
