using Pismire_TCC.Resources;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Pismire_TCC
{
    public partial class TelaVisualizarExperienciaProfissionalEvento : Form
    {
        PismireEntities5 bd = new PismireEntities5();

        public TelaVisualizarExperienciaProfissionalEvento()
        {
            InitializeComponent();
            Maximizacao.verifique(this, pbMaximizar);   //Verifica se a tela está maximizada ou não

            try
            {
                var usuario = bd.usuario_empresa.Where(x => x.FK_usuario == UsuarioDados.Id).FirstOrDefault();
                var FK = bd.evento.Where(x => x.FK_usuario_empresa == usuario.cnpj).Max(x => x.idEvento);

                int qtd = Convert.ToInt16(bd.experiencia_profissional_evento.Count     //Número de idiomas
                (x => x.FK_evento == FK));

                try
                {
                    if (qtd != 0)
                    {
                        if (qtd == 1)
                        {
                            var exp2 = bd.experiencia_profissional_evento.Where(y => y.FK_evento == FK).FirstOrDefault();

                            if (exp2.cargoExperienciaEvento == "Nenhum")
                            {
                                pbLixeira.Visible = false;
                                lblAviso.Visible = true;      //Verifica se evento não tem idioma
                                pCabecalho.Visible = false;
                                panel2.Visible = false;
                                dt.Visible = false;
                            }
                            else
                            {
                                int max = bd.experiencia_profissional_evento.Max(x => x.idExperienciaEvento); //Maior ID

                                var dt1 = new DataTable();

                                dt1.Columns.Add("idExperienciaEvento");
                                dt1.Columns.Add("cargoExperienciaEvento");   //Cria as Colunas
                                dt1.Columns.Add("FK_evento");

                                for (int i = 1; i <= max; i++)
                                {
                                    var exp = bd.experiencia_profissional_evento.Where(y => y.FK_evento ==
                                    FK).Where(x => x.idExperienciaEvento == i).FirstOrDefault();

                                    if (exp != null)
                                    {
                                        dt1.Rows.Add(exp.idExperienciaEvento,
                                        exp.cargoExperienciaEvento, exp.FK_evento);

                                        dt.DataSource = dt1; //Conecta com o GridView

                                        this.dt.Columns["idExperienciaEvento"].Visible = false;
                                        this.dt.Columns["FK_evento"].Visible = false;       //Tira as que não precisa

                                        this.dt.Columns["cargoExperienciaEvento"].FillWeight = 200;

                                    }
                                }
                            }
                        }
                        else
                        {
                            int max = bd.experiencia_profissional_evento.Max(x => x.idExperienciaEvento); //Maior ID

                            var dt1 = new DataTable();

                            dt1.Columns.Add("idExperienciaEvento");
                            dt1.Columns.Add("cargoExperienciaEvento");   //Cria as Colunas
                            dt1.Columns.Add("FK_evento");

                            for (int i = 1; i <= max; i++)
                            {
                                var exp = bd.experiencia_profissional_evento.Where(y => y.FK_evento ==
                                FK).Where(x => x.idExperienciaEvento == i).FirstOrDefault();

                                if (exp != null)
                                {
                                    dt1.Rows.Add(exp.idExperienciaEvento,
                                    exp.cargoExperienciaEvento, exp.FK_evento);

                                    dt.DataSource = dt1; //Conecta com o GridView

                                    this.dt.Columns["idExperienciaEvento"].Visible = false;
                                    this.dt.Columns["FK_evento"].Visible = false;       //Tira as que não precisa

                                    this.dt.Columns["cargoExperienciaEvento"].FillWeight = 200;

                                }
                            }
                        }
                    }
                    else
                    {
                        lblAviso.Visible = true;
                        pCabecalho.Visible = false;
                        panel2.Visible = false;
                        dt.Visible = false;
                        pbLixeira.Visible = false;
                    }
                }
                catch (Exception)
                {
                    Mensagem.aviso = "Erro ao carregar!";
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

        private void pbLixeira_Click(object sender, EventArgs e)
        {
            pLixeira.Visible = true;
            pbLixeira.Enabled = false;
            pb_voltar.Enabled = false;
            dt.Enabled = false;
        }

        private void btCancelar1_Click(object sender, EventArgs e)
        {
            pLixeira.Visible = false;
            pbLixeira.Enabled = true;
            pb_voltar.Enabled = true;
            dt.Enabled = true;
        }

        private void btConf_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblAviso.Visible == false)
                {
                    //Teste para situação vazia

                    var usuario = bd.usuario_empresa.Where(x => x.FK_usuario == UsuarioDados.Id).FirstOrDefault();
                    var FK = bd.evento.Where(x => x.FK_usuario_empresa == usuario.cnpj).Max(x => x.idEvento);

                    int qtd = Convert.ToInt16(bd.experiencia_profissional_evento.Count(x => x.FK_evento == FK));

                    if (qtd != 1)
                    {

                        PegarID.IDN = Convert.ToInt16(dt.CurrentRow.Cells[0].Value);

                        var exp = bd.experiencia_profissional_evento.Where(Z => Z.idExperienciaEvento == PegarID.IDN).FirstOrDefault();

                        bd.experiencia_profissional_evento.Remove(exp);

                        bd.SaveChanges();

                        try
                        {
                            int max = bd.experiencia_profissional_evento.Max(x => x.idExperienciaEvento);

                            var dt1 = new DataTable();

                            dt1.Columns.Add("idExperienciaEvento");
                            dt1.Columns.Add("cargoExperienciaEvento");   //Cria as Colunas
                            dt1.Columns.Add("FK_evento");

                            for (int i = 1; i <= max; i++)

                            {
                                var exp2 = bd.experiencia_profissional_evento.Where(y => y.FK_evento ==
                                FK).Where(x => x.idExperienciaEvento == i).FirstOrDefault();

                                if (exp2 != null)
                                {
                                    dt1.Rows.Add(exp2.idExperienciaEvento,
                                    exp2.cargoExperienciaEvento, exp2.FK_evento);

                                    dt.DataSource = dt1; //Conecta com o GridView

                                    this.dt.Columns["idExperienciaEvento"].Visible = false;
                                    this.dt.Columns["FK_evento"].Visible = false;       //Tira as que não precisa

                                    this.dt.Columns["cargoExperienciaEvento"].FillWeight = 200;          //Ajusta o tamanho
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
                        try
                        {

                            PegarID.IDN = Convert.ToInt16(dt.CurrentRow.Cells[0].Value);

                            var exp = bd.experiencia_profissional_evento.Where(Z => Z.idExperienciaEvento == PegarID.IDN).FirstOrDefault();

                            bd.experiencia_profissional_evento.Remove(exp);

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
                        catch
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
                }
            }
            catch (Exception)
            {
                Mensagem.aviso = "Erro de conexão com o banco!";
                TelaMensagemAviso f = new TelaMensagemAviso();
                f.ShowDialog();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            int x = (panel1.Size.Width - lblExperienciaProfissional.Width) / 2;
            int y = (panel1.Size.Height - lblExperienciaProfissional.Height);              //Posição da label na barra

            lblExperienciaProfissional.Location = new Point(x, y);
        }

        private void panel1_Resize(object sender, EventArgs e)
        {
            int x = (panel1.Size.Width - lblExperienciaProfissional.Width) / 2;
            int y = (panel1.Size.Height - lblExperienciaProfissional.Height);              //Posição da label na barra

            lblExperienciaProfissional.Location = new Point(x, y);
        }

        private void pCabecalho_Paint(object sender, PaintEventArgs e)
        {
            int x = (pCabecalho.Size.Width - lblCargo.Width) / 2;
            int y = (pCabecalho.Size.Height - lblCargo.Height);              //Posição da label na barra grid

            lblCargo.Location = new Point(x, y);
        }

        private void pCabecalho_Resize(object sender, EventArgs e)
        {
            int x = (pCabecalho.Size.Width - lblCargo.Width) / 2;
            int y = (pCabecalho.Size.Height - lblCargo.Height);              //Posição da label na barra do grid

            lblCargo.Location = new Point(x, y);
        }

        private void pb_voltar_MouseEnter(object sender, EventArgs e)
        {
            pb_voltar.Image = Properties.Resources.VoltarRoxo;
        }

        private void pb_voltar_MouseLeave(object sender, EventArgs e)
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
            pbMaximizar.BackColor = Color.FromArgb(41, 41, 41);                 //Animação dos botões da barra
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

        private void pb_voltar_Click(object sender, EventArgs e)
        {
            this.Close();
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
    }
}
