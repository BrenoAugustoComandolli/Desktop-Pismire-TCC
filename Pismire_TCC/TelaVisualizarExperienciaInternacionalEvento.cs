using Pismire_TCC.Resources;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Pismire_TCC
{
    public partial class TelaVisualizarExperienciaInternacionalEvento : Form
    {
        PismireEntities5 bd = new PismireEntities5();

        public TelaVisualizarExperienciaInternacionalEvento()
        {
            InitializeComponent();
            Maximizacao.verifique(this, pbMaximizar);   //Verifica se a tela está maximizada ou não

            try
            {
                var usuario = bd.usuario_empresa.Where(x => x.FK_usuario == UsuarioDados.Id).FirstOrDefault();
                var FK = bd.evento.Where(x => x.FK_usuario_empresa == usuario.cnpj).Max(x => x.idEvento);

                int qtd = Convert.ToInt16(bd.experiencia_internacional_evento.Count     //Número de idiomas
                (x => x.FK_evento == FK));

                try
                {
                    if (qtd != 0)
                    {
                        if (qtd == 1)
                        {
                            var expInt_Evento2 = bd.experiencia_internacional_evento.Where(y => y.FK_evento == FK).FirstOrDefault();

                            if (expInt_Evento2.cargoInternacionalEvento == "Nenhum" && expInt_Evento2.paisCargoInternacionalEvento == "Nenhum")
                            {
                                pbLixeira.Visible = false;
                                lblAviso.Visible = true;      //Verifica se evento não tem qualificação
                                pCabecalho.Visible = false;
                                panel2.Visible = false;
                                dt.Visible = false;
                            }
                            else
                            {
                                int max = bd.experiencia_internacional_evento.Max(x => x.idInternacionalEvento); //Maior ID

                                var dt1 = new DataTable();

                                dt1.Columns.Add("idInternacionalEvento");
                                dt1.Columns.Add("cargoInternacionalEvento");
                                dt1.Columns.Add("paisCargoInternacionalEvento");               //Cria as Colunas
                                dt1.Columns.Add("FK_evento");

                                for (int i = 1; i <= max; i++)
                                {
                                    var expInt_Evento = bd.experiencia_internacional_evento.Where(y => y.FK_evento ==
                                    FK).Where(x => x.idInternacionalEvento == i).FirstOrDefault();

                                    if (expInt_Evento != null)
                                    {
                                        dt1.Rows.Add(expInt_Evento.idInternacionalEvento,
                                        expInt_Evento.cargoInternacionalEvento,
                                        expInt_Evento.paisCargoInternacionalEvento, expInt_Evento.FK_evento);

                                        dt.DataSource = dt1; //Conecta com o GridView

                                        this.dt.Columns["idInternacionalEvento"].Visible = false;
                                        this.dt.Columns["FK_evento"].Visible = false;       //Tira as que não precisa

                                        this.dt.Columns["paisCargoInternacionalEvento"].FillWeight = 140;          //Ajusta o tamanho
                                        this.dt.Columns["cargoInternacionalEvento"].FillWeight = 140;

                                    }
                                }
                            }
                        }
                        else
                        {
                            int max = bd.experiencia_internacional_evento.Max(x => x.idInternacionalEvento); //Maior ID

                            var dt1 = new DataTable();

                            dt1.Columns.Add("idInternacionalEvento");
                            dt1.Columns.Add("cargoInternacionalEvento");
                            dt1.Columns.Add("paisCargoInternacionalEvento");               //Cria as Colunas
                            dt1.Columns.Add("FK_evento");

                            for (int i = 1; i <= max; i++)
                            {
                                var expInt_Evento = bd.experiencia_internacional_evento.Where(y => y.FK_evento ==
                                FK).Where(x => x.idInternacionalEvento == i).FirstOrDefault();

                                if (expInt_Evento != null)
                                {
                                    dt1.Rows.Add(expInt_Evento.idInternacionalEvento,
                                    expInt_Evento.cargoInternacionalEvento,
                                    expInt_Evento.paisCargoInternacionalEvento, expInt_Evento.FK_evento);

                                    dt.DataSource = dt1; //Conecta com o GridView

                                    this.dt.Columns["idInternacionalEvento"].Visible = false;
                                    this.dt.Columns["FK_evento"].Visible = false;       //Tira as que não precisa

                                    this.dt.Columns["paisCargoInternacionalEvento"].FillWeight = 140;          //Ajusta o tamanho
                                    this.dt.Columns["cargoInternacionalEvento"].FillWeight = 140;

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

        private void alinhamentoCabecalho()
        {
            int largura = pCabecalho.Size.Width;

            int tamanhoEspaco = largura / 2;

            lblCabecalho1.Size = new System.Drawing.Size(tamanhoEspaco, 43);
            lblCabecalho2.Size = new System.Drawing.Size(tamanhoEspaco, 43);

            lblCabecalho1.Location = new Point(2, 15);
            lblCabecalho2.Location = new Point(tamanhoEspaco + 2, 15);
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
            int x = (panel1.Size.Width - lblExperienciaInternacional.Width) / 2;
            int y = (panel1.Size.Height - lblExperienciaInternacional.Height);              //Posição da label na barra

            lblExperienciaInternacional.Location = new Point(x, y);
        }

        private void panel1_Resize(object sender, EventArgs e)
        {
            int x = (panel1.Size.Width - lblExperienciaInternacional.Width) / 2;
            int y = (panel1.Size.Height - lblExperienciaInternacional.Height);              //Posição da label na barra

            lblExperienciaInternacional.Location = new Point(x, y);
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

        private void pCabecalho_Paint(object sender, PaintEventArgs e)
        {
            alinhamentoCabecalho();
        }

        private void pCabecalho_Resize(object sender, EventArgs e)
        {
            alinhamentoCabecalho();
        }

        private void btCancelar1_Click_1(object sender, EventArgs e)
        {
            pLixeira.Visible = false;
            pbLixeira.Enabled = true;
            pb_voltar.Enabled = true;
            dt.Enabled = true;
        }

        private void pbLixeira_Click(object sender, EventArgs e)
        {
            pLixeira.Visible = true;
            pbLixeira.Enabled = false;
            pb_voltar.Enabled = false;
            dt.Enabled = false;
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

                    int qtd = Convert.ToInt16(bd.experiencia_internacional_evento.Count(x => x.FK_evento == FK));

                    if (qtd != 1)
                    {

                        PegarID.IDN = Convert.ToInt16(dt.CurrentRow.Cells[0].Value);

                        var expInt = bd.experiencia_internacional_evento.Where(Z => Z.idInternacionalEvento == PegarID.IDN).FirstOrDefault();

                        bd.experiencia_internacional_evento.Remove(expInt);

                        bd.SaveChanges();

                        try
                        {

                            int max = bd.experiencia_internacional_evento.Max(x => x.idInternacionalEvento);

                            var dt1 = new DataTable();

                            dt1.Columns.Add("idInternacionalEvento");
                            dt1.Columns.Add("cargoInternacionalEvento");
                            dt1.Columns.Add("paisCargoInternacionalEvento");               //Cria as Colunas
                            dt1.Columns.Add("FK_evento");

                            for (int i = 1; i <= max; i++)

                            {
                                var expInt_Evento2 = bd.experiencia_internacional_evento.Where(y => y.FK_evento ==
                                FK).Where(x => x.idInternacionalEvento == i).FirstOrDefault();

                                if (expInt_Evento2 == null)
                                {

                                }
                                else
                                {
                                    dt1.Rows.Add(expInt_Evento2.idInternacionalEvento,
                                    expInt_Evento2.cargoInternacionalEvento,
                                    expInt_Evento2.paisCargoInternacionalEvento, expInt_Evento2.FK_evento);

                                    dt.DataSource = dt1; //Conecta com o GridView

                                    this.dt.Columns["idInternacionalEvento"].Visible = false;
                                    this.dt.Columns["FK_evento"].Visible = false;       //Tira as que não precisa

                                    this.dt.Columns["paisCargoInternacionalEvento"].FillWeight = 140;          //Ajusta o tamanho
                                    this.dt.Columns["cargoInternacionalEvento"].FillWeight = 140;
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

                            var expInt = bd.experiencia_internacional_evento.Where(Z => Z.idInternacionalEvento == PegarID.IDN).FirstOrDefault();

                            bd.experiencia_internacional_evento.Remove(expInt);

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
