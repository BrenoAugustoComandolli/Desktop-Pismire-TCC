using Pismire_TCC.Resources;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Pismire_TCC
{
    public partial class TelaRecomendacoes : Form
    {
        PismireEntities5 bd = new PismireEntities5();
        List<string> cnpj = new List<string>();
        DateTime dataAtual = (DateTime.Today).Date;

        public TelaRecomendacoes()
        {
            InitializeComponent();
            Maximizacao.verifique(this, pbMaximizar);
            CarregaGrid();
        }

        private void esconde()
        {
            dtRecomendacoes.Visible = false;
            pCabecalho.Visible = false;
            pnGrid.Visible = false;
            pbChat.Visible = false;
            lblAviso.Visible = true;
        }
        private void CarregaGrid()
        {
            try
            {
                var usuario = bd.usuario_trabalhador.Where(x => x.FK_usuario == UsuarioDados.Id).FirstOrDefault();
                if (usuario != null)
                {
                    var curriculo = bd.curriculo.Where(x => x.FK_usuario_trabalhador == usuario.CPF).FirstOrDefault();
                    if (curriculo != null)
                    {
                        var evento = bd.evento.Where(x => x.idEvento != 0).FirstOrDefault();
                        if (evento != null)
                        {
                            var max = bd.evento.Max(x => x.idEvento);

                            for (int i = 1; i <= max; i++)
                            {
                                var eve = bd.evento.Where(x => x.vagaEvento.Contains(curriculo.cargoAtuacao)).
                                    Where(y => y.areaEvento.Contains(curriculo.areaAtuacao)).
                                    Where(a => a.estadoEvento.Contains(curriculo.estadoTrabalhador)).
                                    Where(b => b.idEvento == i).
                                    Where(c => c.dataFinalEvento >= dataAtual).FirstOrDefault();

                                if (eve != null)
                                {
                                    cnpj.Add(eve.FK_usuario_empresa);
                                }
                            }

                            if (cnpj.Count > 0)
                            {
                                var dt1 = new DataTable();

                                dt1.Columns.Add("CNPJ_Empresa");                           //Adicionando recomendacoes na gridview
                                dt1.Columns.Add("NomeEmpresa");
                                dt1.Columns.Add("Cargo");
                                dt1.Columns.Add("Salario");
                                dt1.Columns.Add("Turno");

                                int maxx = bd.evento.Max(x => x.idEvento);

                                for (int i = 1; i <= cnpj.Count; i++)
                                {
                                    string C_Empresa = cnpj.ElementAt(i - 1).ToString();
                                    var evento2 = bd.evento.Where(x => x.FK_usuario_empresa.Equals(C_Empresa)).FirstOrDefault();

                                    if (evento2 != null)
                                    {
                                        var usuarioempresa = bd.usuario_empresa.Where(x => x.cnpj.Equals(C_Empresa)).FirstOrDefault();
                                        var usuario2 = bd.usuario.Where(x => x.idUsuario == usuarioempresa.FK_usuario).FirstOrDefault();

                                        string txt = evento2.salario.ToString();
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

                                        dt1.Rows.Add(evento2.FK_usuario_empresa, usuario2.nomeUsuario, evento2.vagaEvento, $"R$: {txt}", evento2.turno);

                                        dtRecomendacoes.DataSource = dt1; //Conecta com o GridView

                                        this.dtRecomendacoes.Columns["CNPJ_Empresa"].Visible = false; //Tira as que não precisa
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
                Mensagem.aviso = "Erro ao se conectar com o banco!";
                TelaMensagemAviso f = new TelaMensagemAviso();
                f.ShowDialog();
            }
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

        private void pbFechar_MouseEnter(object sender, EventArgs e)
        {
            pbFechar.BackColor = Color.Red;
        }

        private void pbFechar_MouseLeave(object sender, EventArgs e)
        {
            pbFechar.BackColor = Color.FromArgb(60, 62, 85);
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

        private void p_barra_Paint(object sender, PaintEventArgs e)
        {
            int x = (p_barra.Size.Width - lb_recomendacoes.Width) / 2;
            int y = (p_barra.Size.Height - lb_recomendacoes.Height);              //Posição da label na barra

            lb_recomendacoes.Location = new Point(x, y);
        }

        private void p_barra_Resize(object sender, EventArgs e)
        {
            int x = (p_barra.Size.Width - lb_recomendacoes.Width) / 2;
            int y = (p_barra.Size.Height - lb_recomendacoes.Height);              //Posição da label na barra

            lb_recomendacoes.Location = new Point(x, y);
        }

        private void pbChat_Click(object sender, EventArgs e)
        {
            this.Hide();
            TelaMensagemTrabalhador f = new TelaMensagemTrabalhador();
            f.Closed += (s, args) => this.Close();
            f.ShowDialog();
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

        private void dtRecomendacoes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try {
                string sTeste = Convert.ToString(dtRecomendacoes.CurrentRow.Cells[0].Value);
                var usuario_empresa = bd.usuario_empresa.Where(x => x.cnpj == sTeste).FirstOrDefault();
                var usuario = bd.usuario.Where(x => x.idUsuario == usuario_empresa.FK_usuario).FirstOrDefault();

                if (usuario != null)
                {
                    PegarIDEmpresa.IDEmpresa = usuario.idUsuario;
                }

                VoltarTelaRecomendacao.bVoltar = true;
                this.Hide();
                TelaVisualizacaoPerfilEmpresa f = new TelaVisualizacaoPerfilEmpresa();
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
}
