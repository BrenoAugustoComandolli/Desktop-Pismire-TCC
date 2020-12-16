using Pismire_TCC.Resources;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Pismire_TCC
{
    public partial class TelaVisualizarIdiomaTrabalhador : Form
    {
        PismireEntities5 bd = new PismireEntities5();

        public TelaVisualizarIdiomaTrabalhador()
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
                        int qtdIdioma = Convert.ToInt32(bd.idioma_trabalhador.Count     //Número de idiomas
                            (x => x.FK_curriculo == curriculo.idCurriculo));

                        if (qtdIdioma > 0)                               //Verifica quantidade de ids
                        {
                            try
                            {
                                int max = bd.idioma_trabalhador.Max(x => x.idIdiomaTrabalhador);    //Maior ID

                                var dt1 = new DataTable();

                                dt1.Columns.Add("ID_Idioma");
                                dt1.Columns.Add("idioma");
                                dt1.Columns.Add("nivel");              //Cria as Colunas

                                for (int i = 1; i <= max; i++)
                                {
                                    var idioma = bd.idioma_trabalhador.Where(y => y.FK_curriculo ==
                                    curriculo.idCurriculo).Where(x => x.idIdiomaTrabalhador == i).FirstOrDefault();

                                    //Carregar idioma

                                    if (idioma != null)
                                    {
                                        dt1.Rows.Add(idioma.idIdiomaTrabalhador, idioma.linguaTrabalhador,
                                        idioma.nivelTrabalhador);

                                        dtIdioma.DataSource = dt1; //Conecta com o GridView

                                        this.dtIdioma.Columns["ID_Idioma"].Visible = false; //Tira as que não precisa
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
                            dtIdioma.Enabled = true;
                            lblAviso.Visible = true;
                            pCabecalho.Visible = false;
                            panel2.Visible = false;
                            dtIdioma.Visible = false;
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
            int x = (p_barra.Size.Width - lbl_idioma.Width) / 2;
            int y = (p_barra.Size.Height - lbl_idioma.Height);       //Posição da label na barra

            lbl_idioma.Location = new Point(x, y);
        }

        private void p_barra_Paint(object sender, PaintEventArgs e)
        {
            int x = (p_barra.Size.Width - lbl_idioma.Width) / 2;
            int y = (p_barra.Size.Height - lbl_idioma.Height);       //Posição da label na barra

            lbl_idioma.Location = new Point(x, y);
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

        private void btConfirmar2_Click(object sender, EventArgs e)
        {
            try
            {
                var usuario = bd.usuario_trabalhador.Where(x => x.FK_usuario == PegarID.ID).FirstOrDefault();
                var FK = bd.curriculo.Where(x => x.FK_usuario_trabalhador == usuario.CPF).Max(x => x.idCurriculo);

                int qtd = Convert.ToInt32(bd.idioma_trabalhador.Count(x => x.FK_curriculo == FK));

                if (qtd != 1)
                {
                    PegarID.IDN = Convert.ToInt32(dtIdioma.CurrentRow.Cells[0].Value);

                    var idiomaTrabalhador = bd.idioma_trabalhador.Where(Z => Z.idIdiomaTrabalhador == PegarID.IDN).FirstOrDefault();

                    bd.idioma_trabalhador.Remove(idiomaTrabalhador);

                    bd.SaveChanges();

                    try
                    {
                        int max = bd.idioma_trabalhador.Max(x => x.idIdiomaTrabalhador);

                        if (max != 0)
                        {
                            var dt1 = new DataTable();

                            dt1.Columns.Add("ID_IdiomaTrabalhador");
                            dt1.Columns.Add("LinguaIdioma");
                            dt1.Columns.Add("NivelIdioma");              //Cria as Colunas

                            for (int i = 1; i <= max; i++)
                            {
                                var idiomaTrab = bd.idioma_trabalhador.Where(y => y.FK_curriculo == FK)
                                    .Where(x => x.idIdiomaTrabalhador == i).FirstOrDefault();

                                if (idiomaTrab != null)
                                {
                                    dt1.Rows.Add(idiomaTrab.idIdiomaTrabalhador,
                                        idiomaTrab.linguaTrabalhador,
                                        idiomaTrab.nivelTrabalhador);

                                    dtIdioma.DataSource = dt1; //Conecta com o GridView

                                    this.dtIdioma.Columns["ID_IdiomaTrabalhador"].Visible = false;

                                    this.dtIdioma.Columns["LinguaIdioma"].FillWeight = 140;          //Ajusta o tamanho
                                    this.dtIdioma.Columns["NivelIdioma"].FillWeight = 140;
                                }

                            }
                            pLixeira.Visible = false;
                            pbLixeira.Enabled = true;
                            pb_voltar.Enabled = true;
                            dtIdioma.Enabled = true;
                            Mensagem.aviso = "Excluído com sucesso!";
                            TelaMensagemAviso f2 = new TelaMensagemAviso();
                            f2.ShowDialog();
                        }
                        else
                        {
                            pLixeira.Visible = false;
                            pbLixeira.Enabled = true;
                            pb_voltar.Enabled = true;
                            dtIdioma.Enabled = true;
                        }
                    }
                    catch (Exception)
                    {
                        pLixeira.Visible = false;
                        pbLixeira.Enabled = true;
                        pb_voltar.Enabled = true;
                        dtIdioma.Enabled = true;
                        Mensagem.aviso = "Erro ao excluir!";
                        TelaMensagemAviso f2 = new TelaMensagemAviso();
                        f2.ShowDialog();
                    }
                }
                else
                {
                    var idiomaTrabalhador = bd.idioma_trabalhador.Where(Z => Z.FK_curriculo == FK).FirstOrDefault();

                    bd.idioma_trabalhador.Remove(idiomaTrabalhador);

                    bd.SaveChanges();

                    dtIdioma.Columns.Clear();
                    pLixeira.Visible = false;
                    pbLixeira.Enabled = true;
                    pb_voltar.Enabled = true;
                    dtIdioma.Enabled = true;
                    lblAviso.Visible = true;
                    pCabecalho.Visible = false;
                    panel2.Visible = false;
                    dtIdioma.Visible = false;
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

        private void btCancelar_Click(object sender, EventArgs e)
        {
            pLixeira.Visible = false;
        }

        private void btConfirmar2_MouseEnter(object sender, EventArgs e)
        {
            btConfirmar2.ForeColor = Color.Black;
        }

        private void btConfirmar2_MouseLeave(object sender, EventArgs e)
        {
            btConfirmar2.ForeColor = Color.White;
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
