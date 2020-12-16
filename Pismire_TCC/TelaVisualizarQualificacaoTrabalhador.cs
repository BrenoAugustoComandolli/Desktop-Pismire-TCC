using Pismire_TCC.Resources;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Pismire_TCC
{
    public partial class TelaVisualizarQualificacaoTrabalhador : Form
    {
        PismireEntities5 bd = new PismireEntities5();

        public TelaVisualizarQualificacaoTrabalhador()
        {
            InitializeComponent();

            try
            {
                if (!PegarID.visualizar)
                {
                    pbLixeira.Visible = true;
                }
                else
                {
                    pbLixeira.Visible = false;
                }

                Maximizacao.verifique(this, pbMaximizar);

                var usuario = bd.usuario.Where(x => x.idUsuario == PegarID.ID).FirstOrDefault();
                var trabalhador = bd.usuario_trabalhador.Where(x => x.FK_usuario == PegarID.ID).FirstOrDefault();

                if (trabalhador != null)
                {
                    var curriculo = bd.curriculo.Where(x => x.FK_usuario_trabalhador == trabalhador.CPF).FirstOrDefault();

                    if (curriculo != null)
                    {
                        int qtdIdioma = Convert.ToInt32(bd.qualificacao_trabalhador.Count     //Número de idiomas
                            (x => x.FK_curriculo == curriculo.idCurriculo));

                        if (qtdIdioma > 0)                               //Verifica quantidade de ids
                        {
                            try
                            {
                                int max = bd.qualificacao_trabalhador.Max(x => x.idQualificacaoTrabalhador);    //Maior ID

                                var dt1 = new DataTable();

                                dt1.Columns.Add("ID_Qualificacao");
                                dt1.Columns.Add("NomeQualificacao");
                                dt1.Columns.Add("TipoQualificacao");              //Cria as Colunas
                                dt1.Columns.Add("AreaQualificacao");
                                dt1.Columns.Add("InstituicaoQualificacao");



                                for (int i = 1; i <= max; i++)
                                {
                                    var qualificacao = bd.qualificacao_trabalhador.Where(y => y.FK_curriculo ==
                                    curriculo.idCurriculo).Where(x => x.idQualificacaoTrabalhador == i).FirstOrDefault();

                                    //Carregar idioma

                                    if (qualificacao != null)
                                    {
                                        dt1.Rows.Add(qualificacao.idQualificacaoTrabalhador,
                                            qualificacao.nomeQualificacaoTrabalhador,
                                            qualificacao.tipoQualificacaoTrabalhador,
                                            qualificacao.areaQualificacaoTrabalhador,
                                            qualificacao.instituicaoQualificacaoTrabalhador);


                                        dtQualificacao.DataSource = dt1; //Conecta com o GridView

                                        this.dtQualificacao.Columns["ID_Qualificacao"].Visible = false; //Tira as que não precisa
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
                            pLixeira.Visible = false;
                            pbLixeira.Enabled = true;
                            pb_voltar.Enabled = true;
                            dtQualificacao.Enabled = true;
                            lblAviso.Visible = true;
                            pCabecalho.Visible = false;
                            panel2.Visible = false;
                            dtQualificacao.Visible = false;
                            pbLixeira.Visible = false;
                        }
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

        private void pb_voltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void p_barra_Resize(object sender, EventArgs e)
        {
            int x = (p_barra.Size.Width - lbl_qualificacao.Width) / 2;
            int y = (p_barra.Size.Height - lbl_qualificacao.Height);       //Posição da label na barra (Trocar o lbl_idioma para demais tela)

            lbl_qualificacao.Location = new Point(x, y);
        }

        private void p_barra_Paint(object sender, PaintEventArgs e)
        {
            int x = (p_barra.Size.Width - lbl_qualificacao.Width) / 2;
            int y = (p_barra.Size.Height - lbl_qualificacao.Height);       //Posição da label na barra (Trocar o lbl_idioma para demais tela)

            lbl_qualificacao.Location = new Point(x, y);
        }

        private void pb_voltar_MouseLeave(object sender, EventArgs e)
        {
            pb_voltar.Image = Properties.Resources.voltar;
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

        private void pbLixeira_Click(object sender, EventArgs e)
        {
            pLixeira.Visible = true;
        }

        private void btCancelar1_Click(object sender, EventArgs e)
        {
            pLixeira.Visible = false;
        }

        private void btConf_Click(object sender, EventArgs e)
        {
            try
            {
                //Teste para situação vazia
                var usuario = bd.usuario_trabalhador.Where(x => x.FK_usuario == PegarID.ID).FirstOrDefault();
                var FK = bd.curriculo.Where(x => x.FK_usuario_trabalhador == usuario.CPF).Max(x => x.idCurriculo);

                int qtd = Convert.ToInt16(bd.qualificacao_trabalhador.Count(x => x.FK_curriculo == FK));

                if (qtd != 1)
                {
                    PegarID.IDN = Convert.ToInt16(dtQualificacao.CurrentRow.Cells[0].Value);

                    var qualificacao = bd.qualificacao_trabalhador.Where(Z => Z.idQualificacaoTrabalhador == PegarID.IDN).FirstOrDefault();

                    bd.qualificacao_trabalhador.Remove(qualificacao);

                    bd.SaveChanges();

                    try
                    {
                        var verifica = bd.qualificacao_trabalhador.Where(x => x.idQualificacaoTrabalhador != 0).FirstOrDefault();

                        if (verifica == null)
                        {
                            int max = bd.qualificacao_trabalhador.Max(x => x.idQualificacaoTrabalhador);

                            var dt1 = new DataTable();

                            dt1.Columns.Add("ID_Qualificacao");
                            dt1.Columns.Add("NomeQualificacao");
                            dt1.Columns.Add("TipoQualificacao");              //Cria as Colunas
                            dt1.Columns.Add("AreaQualificacao");
                            dt1.Columns.Add("InstituicaoQualificacao");
                            dt1.Columns.Add("DataEntradaQualificacao");
                            dt1.Columns.Add("DataSaidaQualificacao");


                            for (int i = 1; i <= max; i++)
                            {
                                var qualifica = bd.qualificacao_trabalhador.Where(y => y.FK_curriculo ==
                                FK).Where(x => x.idQualificacaoTrabalhador == i).FirstOrDefault();

                                if (qualifica != null)
                                {
                                    dt1.Rows.Add(qualifica.idQualificacaoTrabalhador,
                                                qualifica.nomeQualificacaoTrabalhador,
                                                qualifica.tipoQualificacaoTrabalhador,
                                                qualifica.areaQualificacaoTrabalhador,
                                                qualifica.instituicaoQualificacaoTrabalhador,
                                                qualifica.dataInicioQualificacaoTrabalhador,
                                                qualifica.dataFinalQualificacaoTrabalhador);

                                    dtQualificacao.DataSource = dt1; //Conecta com o GridView

                                    this.dtQualificacao.Columns["ID_Qualificacao"].Visible = false;

                                    this.dtQualificacao.Columns["NomeQualificacao"].FillWeight = 140;          //Ajusta o tamanho
                                    this.dtQualificacao.Columns["TipoQualificacao"].FillWeight = 140;
                                    this.dtQualificacao.Columns["AreaQualificacao"].FillWeight = 140;
                                    this.dtQualificacao.Columns["InstituicaoQualificacao"].FillWeight = 140;
                                    this.dtQualificacao.Columns["DataEntradaQualificacao"].FillWeight = 140;
                                    this.dtQualificacao.Columns["DataSaidaQualificacao"].FillWeight = 140;
                                }

                            }
                            pLixeira.Visible = false;
                            pbLixeira.Enabled = true;
                            pb_voltar.Enabled = true;
                            dtQualificacao.Enabled = true;
                            Mensagem.aviso = "Excluído com sucesso!";
                            TelaMensagemAviso f2 = new TelaMensagemAviso();
                            f2.ShowDialog();
                        }
                        else
                        {
                            pLixeira.Visible = false;
                            pbLixeira.Enabled = true;
                            pb_voltar.Enabled = true;
                            dtQualificacao.Enabled = true;
                        }
                    }
                    catch (Exception)
                    {
                        pLixeira.Visible = false;
                        pbLixeira.Enabled = true;
                        pb_voltar.Enabled = true;
                        dtQualificacao.Enabled = true;
                        Mensagem.aviso = "Erro ao excluir!";
                        TelaMensagemAviso f2 = new TelaMensagemAviso();
                        f2.ShowDialog();
                    }
                }
                else
                {
                    var idioma = bd.qualificacao_trabalhador.Where(Z => Z.FK_curriculo == FK).FirstOrDefault();

                    bd.qualificacao_trabalhador.Remove(idioma);

                    bd.SaveChanges();

                    dtQualificacao.Columns.Clear();
                    pLixeira.Visible = false;
                    pbLixeira.Enabled = true;
                    pb_voltar.Enabled = true;
                    dtQualificacao.Enabled = true;
                    lblAviso.Visible = true;
                    pCabecalho.Visible = false;
                    panel2.Visible = false;
                    dtQualificacao.Visible = false;
                    pbLixeira.Visible = false;
                    Mensagem.aviso = "Excluído com sucesso!";
                    TelaMensagemAviso f2 = new TelaMensagemAviso();
                    f2.ShowDialog();
                }
            }
            catch (Exception)
            {
                Mensagem.aviso = "Erro de conexão com o banco!";
                TelaMensagemAviso f = new TelaMensagemAviso();
                f.ShowDialog();
            }
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

        private void pCabecalho_Paint(object sender, PaintEventArgs e)
        {
            alinhamentoCabecalho();
        }

        private void pCabecalho_Resize(object sender, EventArgs e)
        {
            alinhamentoCabecalho();
        }

        private void btConf_MouseEnter(object sender, EventArgs e)
        {
            btConf.ForeColor = Color.Black;
        }

        private void btConf_MouseLeave(object sender, EventArgs e)
        {
            btConf.ForeColor = Color.White;
        }

        private void btCancelar1_MouseEnter(object sender, EventArgs e)
        {
            btCancelar1.ForeColor = Color.Black;
        }

        private void btCancelar1_MouseLeave(object sender, EventArgs e)
        {
            btCancelar1.ForeColor = Color.White;
        }

        private void pb_voltar_MouseEnter(object sender, EventArgs e)
        {
            pb_voltar.Image = Properties.Resources.VoltarRoxo;
        }

        private void pb_voltar_MouseLeave_1(object sender, EventArgs e)
        {
            pb_voltar.Image = Properties.Resources.voltar;
        }
    }
}
