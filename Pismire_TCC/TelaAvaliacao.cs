using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Pismire_TCC.Resources;
using System.Data.Entity.Migrations;

namespace Pismire_TCC
{
    public partial class TelaAvaliacao : Form
    {
        PismireEntities5 bd = new PismireEntities5();  

        int nota = 0;                                       
        int teste = 0;

        public TelaAvaliacao()
        {
            InitializeComponent();                      
            Maximizacao.verifique(this,pbMaximizar);    //Verifica se a tela está maximizada ou não
            Mensagem.teste = false;
        }


        private void pb_estrela1_Click(object sender, EventArgs e)
        {
            pb_estrela1.Image = Properties.Resources.Estrela21;
            this.nota = 1;
            teste = 1;                                                        //Click Estrela 1
            pb_estrela2.Image = Properties.Resources.estrela;
            pb_estrela3.Image = Properties.Resources.estrela;
            pb_estrela4.Image = Properties.Resources.estrela;
            pb_estrela5.Image = Properties.Resources.estrela;
        }

        private void pb_estrela2_Click(object sender, EventArgs e)
        {
            pb_estrela1.Image = Properties.Resources.Estrela21;
            pb_estrela2.Image = Properties.Resources.Estrela21; 
            this.nota = 2;                                                    //Click Estrela 2
            teste = 2;
            pb_estrela3.Image = Properties.Resources.estrela;
            pb_estrela4.Image = Properties.Resources.estrela;
            pb_estrela5.Image = Properties.Resources.estrela;
        }

        private void pb_estrela3_Click(object sender, EventArgs e)
        {
            pb_estrela1.Image = Properties.Resources.Estrela21;
            pb_estrela2.Image = Properties.Resources.Estrela21;
            pb_estrela3.Image = Properties.Resources.Estrela21;
            this.nota = 3;                                                    //Click Estrela 3
            teste = 3;
            pb_estrela4.Image = Properties.Resources.estrela;
            pb_estrela5.Image = Properties.Resources.estrela;
        }                           

        private void pb_estrela4_Click(object sender, EventArgs e)
        {
            pb_estrela1.Image = Properties.Resources.Estrela21;
            pb_estrela2.Image = Properties.Resources.Estrela21;
            pb_estrela3.Image = Properties.Resources.Estrela21;
            pb_estrela4.Image = Properties.Resources.Estrela21;
            this.nota = 4;                                                    //Click Estrela 4
            teste = 4;
            pb_estrela5.Image = Properties.Resources.estrela;
        }

        private void pb_estrela5_Click(object sender, EventArgs e)
        {
            pb_estrela1.Image = Properties.Resources.Estrela21;
            pb_estrela2.Image = Properties.Resources.Estrela21;
            pb_estrela3.Image = Properties.Resources.Estrela21;
            pb_estrela4.Image = Properties.Resources.Estrela21;
            pb_estrela5.Image = Properties.Resources.Estrela21;
            this.nota = 5;                                                    //Click Estrela 5
            teste = 5;
        }

        private void pb_voltar_Click(object sender, EventArgs e)
        {
            this.Hide();
            TelaPrincipalEmpresa f = new TelaPrincipalEmpresa();              //Voltar para o menu
            f.Closed += (s, args) => this.Close();
            f.ShowDialog();
        }

        private void bt_enviar_Click(object sender, EventArgs e)
        {
            if (Mensagem.teste != true)
            {
                Mensagem.teste = true;
                if (txtCPF.Text == "" && teste == 0)
                {
                    Mensagem.aviso = "Campos de CPF e nota não prenchidos!";   
                    TelaMensagemAviso f = new TelaMensagemAviso();
                    f.ShowDialog();
                    txtCPF.Focus();
                }
                else if (txtCPF.Text == "")
                {
                    Mensagem.aviso = "Campo de CPF não prenchido!";             //Verificação de campos
                    TelaMensagemAviso f = new TelaMensagemAviso();
                    f.ShowDialog();
                    txtCPF.Focus();
                }
                else if (teste == 0)
                {
                    Mensagem.aviso = "Nota não atribuida!";                    
                    TelaMensagemAviso f = new TelaMensagemAviso();
                    f.ShowDialog();
                    txtCPF.Focus();
                }
                else
                {
                    try
                    {
                        string CPF = txtCPF.Text;
                        string comentario = tb_caixaTexto.Text;

                        var curriculo = bd.curriculo.Where(y => y.FK_usuario_trabalhador == CPF).FirstOrDefault();

                        if (curriculo != null)
                        {

                            int id = UsuarioDados.Id;
                            var empresa = bd.usuario_empresa.Where(x => x.FK_usuario == id).FirstOrDefault();

                            var trabalhador = bd.usuario_trabalhador.Where(x => x.CPF == CPF).FirstOrDefault();
                            var usuario = bd.usuario.Where(y => y.idUsuario == trabalhador.FK_usuario).FirstOrDefault();

                            var avaliacao = bd.avaliacao.Where(x => x.FK_curriculo == curriculo.idCurriculo)
                            .Where(y => y.FK_usuario_empresa == empresa.cnpj).FirstOrDefault();

                            if (avaliacao == null)
                            {
                                avaliacao add = new avaliacao();
                                add.nota = this.nota;
                                add.FK_curriculo = curriculo.idCurriculo;
                                add.FK_usuario_empresa = empresa.cnpj;
                                add.destinatarioAvaliacao = usuario.nomeUsuario;

                                if (comentario != "")                                          //Envio de avaliação
                                {
                                    add.comentario = comentario;
                                }

                                bd.avaliacao.Add(add);
                                bd.SaveChanges();

                                Mensagem.aviso = "Avaliação feita com sucesso!";
                                TelaMensagemAviso f = new TelaMensagemAviso();
                                f.ShowDialog();
                                txtCPF.Focus();
                                lbl_mensagem.Visible = false;
                            }
                            else
                            {
                                var idv = bd.avaliacao.Where(x => x.FK_curriculo == curriculo.idCurriculo)
                                .Where(y => y.FK_usuario_empresa == empresa.cnpj).Select(x => x.idAvaliacao).FirstOrDefault();

                                var ava = bd.avaliacao.Where(x => x.idAvaliacao == idv).FirstOrDefault();

                                ava.nota = nota;

                                if (comentario != "")
                                {
                                    ava.comentario = comentario;
                                }

                                bd.avaliacao.AddOrUpdate(ava);                              //Ediação de avaliação
                                bd.SaveChanges();

                                Mensagem.aviso = "Avaliação editada com sucesso!";
                                TelaMensagemAviso f = new TelaMensagemAviso();
                                f.ShowDialog();
                                txtCPF.Focus();
                                lbl_mensagem.Visible = false;
                            }

                            txtCPF.Clear();
                            tb_caixaTexto.Clear();
                            pb_estrela1.Image = Properties.Resources.estrela;
                            pb_estrela2.Image = Properties.Resources.estrela;
                            pb_estrela3.Image = Properties.Resources.estrela;
                            pb_estrela4.Image = Properties.Resources.estrela;
                            pb_estrela5.Image = Properties.Resources.estrela;
                            lbl_mensagem.Visible = false;
                            teste = 0;
                        }
                        else
                        {
                            Mensagem.aviso = "Usuário não encontrado!";
                            TelaMensagemAviso f = new TelaMensagemAviso();
                            f.ShowDialog();
                            txtCPF.Clear();                                       //Usuário não encontrado
                            txtCPF.Focus();
                            lbl_mensagem.Visible = false;
                        }
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

        private void p_barra_Paint(object sender, PaintEventArgs e)
        {
            int x = (p_barra.Size.Width - lbl_avaliacao.Width) / 2;
            int y = (p_barra.Size.Height - lbl_avaliacao.Height);              //Posição da label na barra

            lbl_avaliacao.Location = new Point(x, y);
        }

        private void txtCPF_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8) { e.Handled = true; }

            if (char.IsNumber(e.KeyChar) == true)
            {
                switch (txtCPF.TextLength)
                {
                    case 0:                                        //Máscara de CPF
                        txtCPF.Text = "";
                        bt_excluir.Visible = false;
                        break;

                    case 3:
                        txtCPF.Text = txtCPF.Text + ".";
                        txtCPF.SelectionStart = 6;
                        break;

                    case 7:
                        txtCPF.Text = txtCPF.Text + ".";
                        txtCPF.SelectionStart = 9;
                        break;

                    case 11:
                        txtCPF.Text = txtCPF.Text + "-";
                        txtCPF.SelectionStart = 14;
                        break;
                }
            } 
        }              

        private void txtCPF_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                txtCPF.Clear();
                bt_excluir.Visible = false;
                lbl_mensagem.Visible = false;             //Visualização de pesquisa
            }
            else if (e.KeyCode == Keys.Back)
            {
                txtCPF.Clear();
                bt_excluir.Visible = false;
                lbl_mensagem.Visible = false;
            }
        }

        private void pb_voltar_MouseEnter(object sender, EventArgs e)
        {
            pb_voltar.Image = Properties.Resources.VoltarRoxo;               //Animação de voltar
        }

        private void pb_voltar_MouseLeave(object sender, EventArgs e)
        {
            pb_voltar.Image = Properties.Resources.voltar;                   //Animação de voltar desfeita
        }

        private void pb_estrela1_MouseEnter(object sender, EventArgs e)
        {
            pb_estrela1.Image = Properties.Resources.Estrela21;
            pb_estrela2.Image = Properties.Resources.estrela;
            pb_estrela3.Image = Properties.Resources.estrela;               //Animação de estrela ao passar o mouse - Estrela 1
            pb_estrela4.Image = Properties.Resources.estrela;
            pb_estrela5.Image = Properties.Resources.estrela;
        }

        private void pb_estrela2_MouseEnter(object sender, EventArgs e)
        {
            pb_estrela1.Image = Properties.Resources.Estrela21;
            pb_estrela2.Image = Properties.Resources.Estrela21;
            pb_estrela3.Image = Properties.Resources.estrela;              //Animação de estrela ao passar o mouse - Estrela 2
            pb_estrela4.Image = Properties.Resources.estrela;
            pb_estrela5.Image = Properties.Resources.estrela;
        }

        private void pb_estrela3_MouseEnter(object sender, EventArgs e)
        {
            pb_estrela1.Image = Properties.Resources.Estrela21;
            pb_estrela2.Image = Properties.Resources.Estrela21;
            pb_estrela3.Image = Properties.Resources.Estrela21;           //Animação de estrela ao passar o mouse - Estrela 3
            pb_estrela4.Image = Properties.Resources.estrela;
            pb_estrela5.Image = Properties.Resources.estrela;
        }

        private void pb_estrela4_MouseEnter(object sender, EventArgs e)
        {
            pb_estrela1.Image = Properties.Resources.Estrela21;
            pb_estrela2.Image = Properties.Resources.Estrela21; 
            pb_estrela3.Image = Properties.Resources.Estrela21;           //Animação de estrela ao passar o mouse - Estrela 4
            pb_estrela4.Image = Properties.Resources.Estrela21;
            pb_estrela5.Image = Properties.Resources.estrela; 
        }

        private void pb_estrela5_MouseEnter(object sender, EventArgs e)
        {
            pb_estrela1.Image = Properties.Resources.Estrela21;
            pb_estrela2.Image = Properties.Resources.Estrela21;
            pb_estrela3.Image = Properties.Resources.Estrela21;           //Animação de estrela ao passar o mouse - Estrela 5
            pb_estrela4.Image = Properties.Resources.Estrela21;
            pb_estrela5.Image = Properties.Resources.Estrela21; 
        }

        private void TelaAvaliacao_MouseEnter(object sender, EventArgs e)
        {
            if (teste == 0)
            {
                pb_estrela1.Image = Properties.Resources.estrela;
                pb_estrela2.Image = Properties.Resources.estrela;
                pb_estrela3.Image = Properties.Resources.estrela;         //Animação de estrela ao passar o mouse desfeita - Estrela 0
                pb_estrela4.Image = Properties.Resources.estrela;
                pb_estrela5.Image = Properties.Resources.estrela;
            }
            else if (teste == 1)
            {
                pb_estrela1.Image = Properties.Resources.Estrela21;
                pb_estrela2.Image = Properties.Resources.estrela;
                pb_estrela3.Image = Properties.Resources.estrela;         //Animação de estrela ao passar o mouse desfeita - Estrela 1
                pb_estrela4.Image = Properties.Resources.estrela;
                pb_estrela5.Image = Properties.Resources.estrela;
            }
            else if (teste == 2)
            {
                pb_estrela1.Image = Properties.Resources.Estrela21;
                pb_estrela2.Image = Properties.Resources.Estrela21;
                pb_estrela3.Image = Properties.Resources.estrela;         //Animação de estrela ao passar o mouse desfeita - Estrela 2
                pb_estrela4.Image = Properties.Resources.estrela;
                pb_estrela5.Image = Properties.Resources.estrela;
            }
            else if (teste == 3)
            {
                pb_estrela1.Image = Properties.Resources.Estrela21;
                pb_estrela2.Image = Properties.Resources.Estrela21;
                pb_estrela3.Image = Properties.Resources.Estrela21;       //Animação de estrela ao passar o mouse desfeita - Estrela 3
                pb_estrela4.Image = Properties.Resources.estrela;
                pb_estrela5.Image = Properties.Resources.estrela;
            }
            else if (teste == 4)
            {
                pb_estrela1.Image = Properties.Resources.Estrela21;
                pb_estrela2.Image = Properties.Resources.Estrela21;
                pb_estrela3.Image = Properties.Resources.Estrela21;       //Animação de estrela ao passar o mouse desfeita - Estrela 4
                pb_estrela4.Image = Properties.Resources.Estrela21;
                pb_estrela5.Image = Properties.Resources.estrela;
            }
            else if (teste == 5)
            {
                pb_estrela1.Image = Properties.Resources.Estrela21;
                pb_estrela2.Image = Properties.Resources.Estrela21;
                pb_estrela3.Image = Properties.Resources.Estrela21;       //Animação de estrela ao passar o mouse desfeita - Estrela 5
                pb_estrela4.Image = Properties.Resources.Estrela21;
                pb_estrela5.Image = Properties.Resources.Estrela21;
            }
        }

        private void txtCPF_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (txtCPF.TextLength == 14)
                {
                    string CPF = txtCPF.Text;
                    var curriculo = bd.curriculo.Where(x => x.FK_usuario_trabalhador == CPF).FirstOrDefault();

                    if (curriculo != null)
                    {
                        int id = UsuarioDados.Id;
                        var empresa = bd.usuario_empresa.Where(x => x.FK_usuario == id).FirstOrDefault();

                        var avaliacao = bd.avaliacao.Where(x => x.FK_curriculo == curriculo.idCurriculo)
                        .Where(y => y.FK_usuario_empresa == empresa.cnpj).FirstOrDefault();

                        int idUsuario = empresa.FK_usuario;
                        var trabalhador = bd.usuario_trabalhador.Where(x => x.CPF == curriculo.FK_usuario_trabalhador).FirstOrDefault();
                        var usuario = bd.usuario.Where(x => x.idUsuario == trabalhador.FK_usuario).FirstOrDefault();
                        string nome = usuario.nomeUsuario;
                        lbl_mensagem.Visible = true;

                        if (avaliacao != null)                              //Pesquisa automatica ao escrever CPF
                        {
                            bt_excluir.Visible = true;
                            lbl_mensagem.Text = "O usuário " + nome + " já possui uma avaliação";
                        }
                        else
                        {
                            lbl_mensagem.Text = "Avaliação será feita ao usuário: " + nome;
                        }
                    }
                    else
                    {
                        lbl_mensagem.Visible = true;
                        lbl_mensagem.Text = "O usuário inexistente";
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

        private void bt_excluir_Click(object sender, EventArgs e)
        {
            try
            { 
                string CPF = txtCPF.Text;
                var curriculo = bd.curriculo.Where(y => y.FK_usuario_trabalhador == CPF).FirstOrDefault();

                int id = UsuarioDados.Id;
                var empresa = bd.usuario_empresa.Where(x => x.FK_usuario == id).FirstOrDefault();

                var avaliacao = bd.avaliacao.Where(x => x.FK_curriculo == curriculo.idCurriculo)       
                .Where(y => y.FK_usuario_empresa == empresa.cnpj).FirstOrDefault();

                bd.avaliacao.Remove(avaliacao);
                bd.SaveChanges();
                bt_excluir.Visible = false;                    //Excluir avaliação

                txtCPF.Clear();
                tb_caixaTexto.Clear();
                pb_estrela1.Image = Properties.Resources.estrela;
                pb_estrela2.Image = Properties.Resources.estrela;
                pb_estrela3.Image = Properties.Resources.estrela;
                pb_estrela4.Image = Properties.Resources.estrela;
                pb_estrela5.Image = Properties.Resources.estrela;

                Mensagem.aviso = "Excluído com sucesso!";
                TelaMensagemAviso f = new TelaMensagemAviso();
                f.ShowDialog();
                txtCPF.Focus();
                lbl_mensagem.Visible = false;              //Com sucesso
            }
            catch (Exception)
            { 
                txtCPF.Clear();
                tb_caixaTexto.Clear();
                pb_estrela1.Image = Properties.Resources.estrela;
                pb_estrela2.Image = Properties.Resources.estrela;
                pb_estrela3.Image = Properties.Resources.estrela;
                pb_estrela4.Image = Properties.Resources.estrela;
                pb_estrela5.Image = Properties.Resources.estrela;

                Mensagem.aviso = "Erro ao excluir!";
                TelaMensagemAviso f = new TelaMensagemAviso();     //Com erro
                f.ShowDialog();
                txtCPF.Focus();
            }
        }

        private void TelaAvaliacao_Resize(object sender, EventArgs e)
        {
            int x = (p_barra.Size.Width - lbl_avaliacao.Width) / 2;
            int y = (p_barra.Size.Height - lbl_avaliacao.Height);       //Posição da label na barra ao maximizar e desmaximizar 

            lbl_avaliacao.Location = new Point(x, y);
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
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
