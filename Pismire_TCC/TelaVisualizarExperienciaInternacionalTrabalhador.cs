using Pismire_TCC.Resources;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Pismire_TCC
{
    public partial class TelaVisualizarExperienciaInternacionalTrabalhador : Form
    {
        PismireEntities5 bd = new PismireEntities5();

        public TelaVisualizarExperienciaInternacionalTrabalhador()
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
                        int expInt = Convert.ToInt32(bd.experiencia_internacional_trabalhador.Count     //Número de idiomas
                            (x => x.FK_curriculo == curriculo.idCurriculo));

                        if (expInt > 0)                               //Verifica quantidade de ids
                        {
                            try
                            {
                                int max = bd.experiencia_internacional_trabalhador.Max(x => x.idInternacionalTrabalhador);    //Maior ID

                                var dt1 = new DataTable();

                                dt1.Columns.Add("ID_ExperienciaInternacional");
                                dt1.Columns.Add("NomeEmpresaInternacional");
                                dt1.Columns.Add("CargoExperiencia");              //Cria as Colunas
                                dt1.Columns.Add("PaisInternacional");
                                dt1.Columns.Add("DataEntradaExperiencia");
                                dt1.Columns.Add("DataSaidaExperiencia");


                                for (int i = 1; i <= max; i++)
                                {
                                    var exp = bd.experiencia_internacional_trabalhador.Where(y => y.FK_curriculo ==
                                    curriculo.idCurriculo).Where(x => x.idInternacionalTrabalhador == i).FirstOrDefault();

                                    //Carregar idioma

                                    if (exp != null)
                                    {
                                        dt1.Rows.Add(exp.idInternacionalTrabalhador,
                                            exp.nomeEmpresaInternacionalTrabalhador,
                                            exp.cargoInternacionalTrabalhador,
                                            exp.paisInternacionalTrabalhador,
                                            Convert.ToDateTime(exp.dataEntradaInternacionalTrabalhador).ToString("dd/MM/yyyy"),
                                            Convert.ToDateTime(exp.dataSaidaInternacionalTrabalhador).ToString("dd/MM/yyyy"));

                                        dtExpInter.DataSource = dt1; //Conecta com o GridView

                                        this.dtExpInter.Columns["ID_ExperienciaInternacional"].Visible = false; //Tira as que não precisa
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
                            dtExpInter.Enabled = true;
                            lblAviso.Visible = true;
                            pCabecalho.Visible = false;
                            panel2.Visible = false;
                            dtExpInter.Visible = false;
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

        private void pbMaximizar_MouseLeave(object sender, EventArgs e)
        {
            pbMaximizar.BackColor = Color.FromArgb(60, 62, 85);
        }

        private void pbFechar_MouseEnter(object sender, EventArgs e)
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

        private void pbLixeira_MouseLeave(object sender, EventArgs e)
        {
            pbLixeira.Image = Properties.Resources.excluir;
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

        private void alinhamentoCabecalho()
        {
            int largura = pCabecalho.Size.Width;

            int tamanhoEspaco = largura / 5;

            lblCabecalho1.Size = new System.Drawing.Size(tamanhoEspaco, 43);
            lblCabecalho2.Size = new System.Drawing.Size(tamanhoEspaco, 43);
            lblCabecalho3.Size = new System.Drawing.Size(tamanhoEspaco, 43);
            lblCabecalho4.Size = new System.Drawing.Size(tamanhoEspaco, 43);
            lblCabecalho5.Size = new System.Drawing.Size(tamanhoEspaco, 43);

            lblCabecalho1.Location = new Point(2, 15);
            lblCabecalho2.Location = new Point(tamanhoEspaco + 2, 15);
            lblCabecalho3.Location = new Point(((tamanhoEspaco * 2) + 2), 15);
            lblCabecalho4.Location = new Point(((tamanhoEspaco * 3) + 2), 15);
            lblCabecalho5.Location = new Point(((tamanhoEspaco * 4) + 2), 15);
        }

        private void pCabecalho_Paint(object sender, PaintEventArgs e)
        {
            alinhamentoCabecalho();
        }

        private void pCabecalho_Resize(object sender, EventArgs e)
        {
            alinhamentoCabecalho();
        }

        private void pb_voltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btConf_Click(object sender, EventArgs e)
        {
            try
            {
                var usuario = bd.usuario_trabalhador.Where(x => x.FK_usuario == PegarID.ID).FirstOrDefault();
                var FK = bd.curriculo.Where(x => x.FK_usuario_trabalhador == usuario.CPF).Max(x => x.idCurriculo);

                int qtd = Convert.ToInt16(bd.experiencia_internacional_trabalhador.Count(x => x.FK_curriculo == FK));

                if (qtd != 1)
                {
                    PegarID.IDN = Convert.ToInt16(dtExpInter.CurrentRow.Cells[0].Value);

                    var expInt = bd.experiencia_internacional_trabalhador.Where(Z => Z.idInternacionalTrabalhador == PegarID.IDN).FirstOrDefault();

                    bd.experiencia_internacional_trabalhador.Remove(expInt);

                    bd.SaveChanges();

                    try
                    {
                        int max = bd.experiencia_internacional_trabalhador.Max(x => x.idInternacionalTrabalhador);

                        if (max != 0)
                        {
                            var dt1 = new DataTable();

                            dt1.Columns.Add("ID_ExperienciaInternacional");
                            dt1.Columns.Add("NomeEmpresaInternacional");
                            dt1.Columns.Add("CargoExperiencia");              //Cria as Colunas
                            dt1.Columns.Add("PaisInternacional");
                            dt1.Columns.Add("DataEntradaExperiencia");
                            dt1.Columns.Add("DataSaidaExperiencia");


                            for (int i = 1; i <= max; i++)
                            {
                                var exp = bd.experiencia_internacional_trabalhador.Where(y => y.FK_curriculo ==
                                FK).Where(x => x.idInternacionalTrabalhador == i).FirstOrDefault();

                                //Carregar idioma

                                if (exp != null)
                                {
                                    dt1.Rows.Add(exp.idInternacionalTrabalhador,
                                        exp.nomeEmpresaInternacionalTrabalhador,
                                        exp.cargoInternacionalTrabalhador,
                                        exp.paisInternacionalTrabalhador,
                                        Convert.ToDateTime(exp.dataEntradaInternacionalTrabalhador).ToString("dd/MM/yyyy"),
                                        Convert.ToDateTime(exp.dataSaidaInternacionalTrabalhador).ToString("dd/MM/yyyy"));

                                    dtExpInter.DataSource = dt1; //Conecta com o GridView

                                    this.dtExpInter.Columns["ID_ExperienciaInternacional"].Visible = false; //Tira as que não precisa

                                    this.dtExpInter.Columns["NomeEmpresaInternacional"].FillWeight = 140;          //Ajusta o tamanho
                                    this.dtExpInter.Columns["CargoExperiencia"].FillWeight = 140;
                                    this.dtExpInter.Columns["PaisInternacional"].FillWeight = 140;          //Ajusta o tamanho
                                    this.dtExpInter.Columns["DataEntradaExperiencia"].FillWeight = 140;
                                    this.dtExpInter.Columns["DataSaidaExperiencia"].FillWeight = 140;          //Ajusta o tamanho
                                }
                            }
                            pLixeira.Visible = false;
                            pbLixeira.Enabled = true;
                            pb_voltar.Enabled = true;
                            dtExpInter.Enabled = true;
                            Mensagem.aviso = "Excluído com sucesso!";
                            TelaMensagemAviso f2 = new TelaMensagemAviso();
                            f2.ShowDialog();
                        }
                        else
                        {
                            pLixeira.Visible = false;
                            pbLixeira.Enabled = true;
                            pb_voltar.Enabled = true;
                            dtExpInter.Enabled = true;
                        }
                    }
                    catch (Exception)
                    {
                        pLixeira.Visible = false;
                        pbLixeira.Enabled = true;
                        pb_voltar.Enabled = true;
                        dtExpInter.Enabled = true;
                        Mensagem.aviso = "Erro ao excluir!";
                        TelaMensagemAviso f2 = new TelaMensagemAviso();
                        f2.ShowDialog();
                    }
                }
                else
                {
                    var exp2 = bd.experiencia_internacional_trabalhador.Where(Z => Z.FK_curriculo == FK).FirstOrDefault();

                    bd.experiencia_internacional_trabalhador.Remove(exp2);

                    bd.SaveChanges();

                    dtExpInter.Columns.Clear();
                    pLixeira.Visible = false;
                    pbLixeira.Enabled = true;
                    pb_voltar.Enabled = true;
                    dtExpInter.Enabled = true;
                    lblAviso.Visible = true;
                    pCabecalho.Visible = false;
                    panel2.Visible = false;
                    dtExpInter.Visible = false;
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

        private void pbLixeira_Click(object sender, EventArgs e)
        {
            pLixeira.Visible = true;
        }

        private void btCancelar1_Click(object sender, EventArgs e)
        {
            pLixeira.Visible = false;
        }
    }
}
