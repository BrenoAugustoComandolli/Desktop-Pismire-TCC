using Pismire_TCC.Resources;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Pismire_TCC
{
    public partial class TelaVisualizarTrabalhoVoluntarioTrabalhador : Form
    {
        PismireEntities5 bd = new PismireEntities5();

        public TelaVisualizarTrabalhoVoluntarioTrabalhador()
        {
            InitializeComponent();
            Maximizacao.verifique(this, pbMaximizar);

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

                var usuario = bd.usuario.Where(x => x.idUsuario == PegarID.ID).FirstOrDefault();
                var trabalhador = bd.usuario_trabalhador.Where(x => x.FK_usuario == PegarID.ID).FirstOrDefault();

                if (trabalhador != null)
                {
                    var curriculo = bd.curriculo.Where(x => x.FK_usuario_trabalhador == trabalhador.CPF).FirstOrDefault();

                    if (curriculo != null)
                    {
                        int qtdIdioma = Convert.ToInt32(bd.trabalho_voluntario_trabalhador.Count     //Número de idiomas
                            (x => x.FK_curriculo == curriculo.idCurriculo));

                        if (qtdIdioma > 0)                               //Verifica quantidade de ids
                        {
                            try
                            {
                                int max = bd.trabalho_voluntario_trabalhador.Max(x => x.idVoluntarioTrabalhador);    //Maior ID

                                var dt1 = new DataTable();

                                dt1.Columns.Add("ID_TrabalhoVol");
                                dt1.Columns.Add("InstituicaoTrabalhoVol");
                                dt1.Columns.Add("ResponsavelTrabalhoVol");              //Cria as Colunas
                                dt1.Columns.Add("DataEntradaTrabalhoVol");
                                dt1.Columns.Add("DataSaidaTrabalhoVol");


                                for (int i = 1; i <= max; i++)
                                {
                                    var exp = bd.trabalho_voluntario_trabalhador.Where(y => y.FK_curriculo ==
                                    curriculo.idCurriculo).Where(x => x.idVoluntarioTrabalhador == i).FirstOrDefault();

                                    //Carregar idioma

                                    if (exp != null)
                                    {
                                        dt1.Rows.Add(exp.idVoluntarioTrabalhador,
                                            exp.instituicaoVoluntarioTrabalhador,
                                            exp.responsavelVoluntarioTrabalhador,
                                            Convert.ToDateTime(exp.dataEntradaVoluntarioTrabalhador).ToString("dd/MM/yyyy"),
                                            Convert.ToDateTime(exp.dataSaidaVoluntarioTrabalhador).ToString("dd/MM/yyyy"));

                                        dt.DataSource = dt1; //Conecta com o GridView

                                        this.dt.Columns["ID_TrabalhoVol"].Visible = false; //Tira as que não precisa
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
                            dt.Enabled = true;
                            lblAviso.Visible = true;
                            pCabecalho.Visible = false;
                            panel2.Visible = false;
                            dt.Visible = false;
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

        private void pb_voltar_MouseEnter(object sender, EventArgs e)
        {
            pb_voltar.Image = Properties.Resources.VoltarRoxo;
        }

        private void pb_voltar_MouseLeave(object sender, EventArgs e)
        {
            pb_voltar.Image = Properties.Resources.voltar;
        }

        private void pbMinimizar_MouseEnter(object sender, EventArgs e)
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

        private void pbFechar_MouseEnter(object sender, EventArgs e)
        {
            pbFechar.BackColor = Color.Red;
        }

        private void pbMaximizar_MouseLeave(object sender, EventArgs e)
        {
            pbMaximizar.BackColor = Color.FromArgb(60, 62, 85);
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

        private void pbMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pbLixeira_MouseEnter(object sender, EventArgs e)
        {
            pbLixeira.Image = Properties.Resources.excluirRoxo;
        }

        private void pbLixeira_MouseLeave(object sender, EventArgs e)
        {
            pbLixeira.Image = Properties.Resources.excluir;
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

        private void btConf_Click(object sender, EventArgs e)
        {
            try
            {
                var usuario = bd.usuario_trabalhador.Where(x => x.FK_usuario == PegarID.ID).FirstOrDefault();
                var FK = bd.curriculo.Where(x => x.FK_usuario_trabalhador == usuario.CPF).Max(x => x.idCurriculo);

                int qtd = Convert.ToInt16(bd.trabalho_voluntario_trabalhador.Count(x => x.FK_curriculo == FK));

                if (qtd != 1)
                {
                    PegarID.IDN = Convert.ToInt16(dt.CurrentRow.Cells[0].Value);

                    var qualificacao = bd.trabalho_voluntario_trabalhador.Where(Z => Z.idVoluntarioTrabalhador == PegarID.IDN).FirstOrDefault();

                    bd.trabalho_voluntario_trabalhador.Remove(qualificacao);

                    bd.SaveChanges();

                    try
                    {
                        int max = bd.trabalho_voluntario_trabalhador.Max(x => x.idVoluntarioTrabalhador);

                        if (max != 0)
                        {
                            var dt1 = new DataTable();

                            dt1.Columns.Add("ID_TrabalhoVol");
                            dt1.Columns.Add("InstituicaoTrabalhoVol");
                            dt1.Columns.Add("ResponsavelTrabalhoVol");              //Cria as Colunas
                            dt1.Columns.Add("DataEntradaTrabalhoVol");
                            dt1.Columns.Add("DataSaidaTrabalhoVol");

                            for (int i = 1; i <= max; i++)
                            {
                                var exp = bd.trabalho_voluntario_trabalhador.Where(y => y.FK_curriculo == FK)
                                    .Where(x => x.idVoluntarioTrabalhador == i).FirstOrDefault();

                                if (exp != null)
                                {
                                    dt1.Rows.Add(exp.idVoluntarioTrabalhador,
                                            exp.instituicaoVoluntarioTrabalhador,
                                            exp.responsavelVoluntarioTrabalhador,
                                            Convert.ToDateTime(exp.dataEntradaVoluntarioTrabalhador).ToString("dd/MM/yyyy"),
                                            Convert.ToDateTime(exp.dataSaidaVoluntarioTrabalhador).ToString("dd/MM/yyyy"));

                                    dt.DataSource = dt1; //Conecta com o GridView

                                    this.dt.Columns["ID_ExperienciaProfissional"].Visible = false;

                                    this.dt.Columns["InstituicaoTrabalhoVol"].FillWeight = 140;          //Ajusta o tamanho
                                    this.dt.Columns["ResponsavelTrabalhoVol"].FillWeight = 140;
                                    this.dt.Columns["DataEntradaTrabalhoVol"].FillWeight = 140;
                                    this.dt.Columns["DataSaidaTrabalhoVol"].FillWeight = 140;
                                }

                            }
                            pLixeira.Visible = false;
                            pbLixeira.Enabled = true;
                            pb_voltar.Enabled = true;
                            dt.Enabled = true;
                            Mensagem.aviso = "Excluído com sucesso!";
                            TelaMensagemAviso f2 = new TelaMensagemAviso();
                            f2.ShowDialog();
                        }
                        else
                        {
                            pLixeira.Visible = false;
                            pbLixeira.Enabled = true;
                            pb_voltar.Enabled = true;
                            dt.Enabled = true;
                        }
                    }
                    catch (Exception)
                    {
                        pLixeira.Visible = false;
                        pbLixeira.Enabled = true;
                        pb_voltar.Enabled = true;
                        dt.Enabled = true;
                        Mensagem.aviso = "Erro ao excluir!";
                        TelaMensagemAviso f2 = new TelaMensagemAviso();
                        f2.ShowDialog();
                    }
                }
                else
                {
                    var idioma = bd.trabalho_voluntario_trabalhador.Where(Z => Z.FK_curriculo == FK).FirstOrDefault();

                    bd.trabalho_voluntario_trabalhador.Remove(idioma);

                    bd.SaveChanges();

                    dt.Columns.Clear();
                    pLixeira.Visible = false;
                    pbLixeira.Enabled = true;
                    pb_voltar.Enabled = true;
                    dt.Enabled = true;
                    lblAviso.Visible = true;
                    pCabecalho.Visible = false;
                    panel2.Visible = false;
                    dt.Visible = false;
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

        private void pb_voltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pbLixeira_Click(object sender, EventArgs e)
        {
            pLixeira.Visible = true;
        }

        private void btCancelar1_Click(object sender, EventArgs e)
        {
            pLixeira.Visible = false;
        }

        private void p_barra_Paint(object sender, PaintEventArgs e)
        {
            int x = (p_barra.Size.Width - lbl_voluntario.Width) / 2;
            int y = (p_barra.Size.Height - lbl_voluntario.Height);       //Posição da label na barra 

            lbl_voluntario.Location = new Point(x, y);
        }

        private void p_barra_Resize(object sender, EventArgs e)
        {
            int x = (p_barra.Size.Width - lbl_voluntario.Width) / 2;
            int y = (p_barra.Size.Height - lbl_voluntario.Height);       //Posição da label na barra 

            lbl_voluntario.Location = new Point(x, y);
        }

        private void pCabecalho_Resize(object sender, EventArgs e)
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
    }
}
