using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Pismire_TCC.Resources;

namespace Pismire_TCC
{
    public partial class TelaEditarPerfil : Form
    {
        PismireEntities5 bd = new PismireEntities5();   //Propriedades 

        List<usuario> usuarios = new List<usuario>();
        bool passou = false;
        bool bTrocouImagem = false;

        public TelaEditarPerfil()
        {
            InitializeComponent();
            Maximizacao.verifique(this, pbMaximizar);   //Verifica se a tela está maximizada ou não

            try
            {
                var usuario = bd.usuario.Where(x => x.idUsuario == UsuarioDados.Id).FirstOrDefault();
                txtNome.Text = usuario.nomeUsuario.ToString();
                txtEmail.Text = usuario.e_mailUsuario.ToString();   //Informações prévias 
                txtTelefone.Text = usuario.telefoneUsuario.ToString();

                btSalvar.Click += salvar;             //Abrir métodos 
                pbFotoPerfil.Click += carregarFoto;


                var empresa = bd.usuario_empresa.Where(x => x.FK_usuario == UsuarioDados.Id).FirstOrDefault();

                if (empresa != null)
                {
                    if (empresa.cnpj != "")
                    {
                        txtCNPJ.Enabled = false;
                        txtCNPJ.Text = empresa.cnpj;
                    }

                    var perfil = bd.perfil_empresa.Where(x => x.FK_usuario_empresa == empresa.cnpj).FirstOrDefault();

                    if (perfil != null)
                    {
                        txtSite.Text = perfil.site;
                        txtArea.Text = empresa.areaEmpresa;
                        txtCNPJ.Text = empresa.cnpj;
                        txtInsta.Text = perfil.instagram;
                        txtTwitter.Text = perfil.twitter;
                        txtFacebook.Text = perfil.facebookEmpresa;   //Mostrando dados 
                        cbEstado.Text = perfil.estadoEmpresa;
                        txtCidade.Text = perfil.cidadeEmpresa;
                        txtBairro.Text = perfil.bairroEmpresa;
                        txtRua.Text = perfil.ruaEmpresa;
                        txtNumero.Text = perfil.numeroEmpresa;
                        txtNome.Text = usuario.nomeUsuario;

                        byte[] ImageSource = perfil.fotoEmpresa;
                        pbFotoPerfil.Visible = true;

                        using (MemoryStream stream = new MemoryStream(ImageSource))   //Mostrando foto
                        {
                            pbFotoPerfil.Image = new Bitmap(stream);
                        }

                        txtCEP.Text = perfil.cepEmpresa;          //Mostrando dados 
                        txtDesc.Text = perfil.descricaoEmpresa;
                    }
                }
            }
            catch (Exception)
            {
                Mensagem.aviso = "Erro ao conectar!";
                TelaMensagemAviso f = new TelaMensagemAviso();
                f.ShowDialog();
            }
        }

        private void carregarFoto(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.FileName = "";
                openFileDialog1.Filter = "png| *.png| jpg| *.jpg| jpeg| *.jpeg";    //Puxa a foto dos arquivos 
                openFileDialog1.Title = "Selecione uma imagem";
                DialogResult dr = openFileDialog1.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    pbFotoPerfil.Image = Image.FromFile(openFileDialog1.FileName);
                }
                bTrocouImagem = true;
                passou = true;
            }
            catch (Exception)
            {
                Mensagem.aviso = "Erro ao carregar foto!";
                TelaMensagemAviso f = new TelaMensagemAviso();
                f.ShowDialog();
            }
        }

        private void salvar(object sender, EventArgs e)
        {
            try
            {
                var usuarioEmp = bd.usuario_empresa.Where(x => x.FK_usuario == UsuarioDados.Id).FirstOrDefault();

                if(usuarioEmp != null)
                {
                    var perfil = bd.perfil_empresa.Where(x => x.FK_usuario_empresa == usuarioEmp.cnpj).FirstOrDefault();

                    if(perfil.fotoEmpresa != null)
                    {
                        bTrocouImagem = true;
                    }
                }

                if (txtCNPJ.Text != "" && txtArea.Text != "" && txtSite.Text != "" && cbEstado.Text != "" && txtCidade.Text != "" && txtBairro.Text != "" && txtRua.Text != "" && txtNumero.Text != "" && txtCEP.Text != "" && txtCNPJ.Text != "")
                {
                    if (testeCNPJ(txtCNPJ.Text))
                    {
                        if (bTrocouImagem)
                        {
                            if (txtCEP.Text.Length == 9)
                            {
                                var usuEmp = bd.usuario_empresa.Where(x => x.FK_usuario == UsuarioDados.Id).FirstOrDefault();

                                if (usuEmp != null)
                                {
                                    try
                                    {
                                        var empresa = bd.usuario_empresa.Where(x => x.FK_usuario == UsuarioDados.Id).FirstOrDefault();

                                        if (empresa != null)
                                        {
                                            var perfil_empresa = bd.perfil_empresa.
                                            Where(x => x.FK_usuario_empresa == empresa.cnpj).FirstOrDefault();

                                            if (perfil_empresa != null)
                                            {
                                                var lista = bd.perfil_empresa.Where(x => x.FK_usuario_empresa == empresa.cnpj).ToList();
                                                var usuario = bd.usuario.Where(x => x.idUsuario == UsuarioDados.Id).ToList();
                                                var empresa2 = bd.usuario_empresa.Where(x => x.FK_usuario == UsuarioDados.Id).ToList();

                                                if (bTrocouImagem)
                                                {
                                                    byte[] Foto;
                                                    if (passou)
                                                    {
                                                        using (var ms = new MemoryStream())
                                                        {
                                                            pbFotoPerfil.Image.Save(ms, pbFotoPerfil.Image.RawFormat);
                                                            Foto = ms.ToArray();
                                                        }
                                                        lista.ForEach(x => { x.fotoEmpresa = Foto; });
                                                        bd.SaveChanges();
                                                    }
                                                    
                                                    usuario.ForEach(y =>
                                                    {
                                                        y.nomeUsuario = txtNome.Text;
                                                        y.telefoneUsuario = txtTelefone.Text;
                                                        y.e_mailUsuario = txtEmail.Text;        //Salvar dados de perfil 
                                                    });
                                                    bd.SaveChanges();

                                                    lista.ForEach(x =>
                                                    {
                                                        x.site = txtSite.Text;
                                                        x.instagram = txtInsta.Text;
                                                        x.twitter = txtTwitter.Text;
                                                        x.facebookEmpresa = txtFacebook.Text;
                                                        x.estadoEmpresa = cbEstado.Text;
                                                        x.cidadeEmpresa = txtCidade.Text;
                                                        x.bairroEmpresa = txtBairro.Text;
                                                        x.ruaEmpresa = txtRua.Text;
                                                        x.numeroEmpresa = txtNumero.Text;
                                                        x.cepEmpresa = txtCEP.Text;
                                                        x.FK_usuario_empresa = empresa.cnpj;
                                                        x.descricaoEmpresa = txtDesc.Text;
                                                        x.cidadeEmpresa = txtCidade.Text;
                                                    });

                                                    bd.SaveChanges();

                                                    empresa2.ForEach(y =>
                                                    {
                                                        y.areaEmpresa = txtArea.Text;
                                                    });

                                                    bd.SaveChanges();

                                                    Mensagem.aviso = "Salvo com sucesso!";
                                                    TelaMensagemAviso f = new TelaMensagemAviso();
                                                    f.ShowDialog();

                                                    if (!TesteTutorial.entrou)
                                                    {
                                                        TesteTutorial.entrou = true;
                                                        TesteTutorial.instrucao = false;
                                                    }

                                                    this.Hide();
                                                    TelaVisualizacaoPerfilEmpresa f2 = new TelaVisualizacaoPerfilEmpresa();   //Volta
                                                    f2.Closed += (s, args) => this.Close();
                                                    f2.ShowDialog();
                                                }
                                                else
                                                {
                                                    Mensagem.aviso = "Adicione uma imagem!";
                                                    TelaMensagemAviso f = new TelaMensagemAviso();
                                                    f.ShowDialog();
                                                }
                                            }
                                            else
                                            {
                                                carregarInicial();
                                            }
                                        }
                                        else
                                        {
                                            carregarInicial();
                                        }
                                    }
                                    catch (Exception)
                                    {
                                        Mensagem.aviso = "Erro ao salvar!";
                                        TelaMensagemAviso f = new TelaMensagemAviso();
                                        f.ShowDialog();
                                    }
                                }
                                else
                                {
                                    carregarInicial();
                                }
                            }
                            else
                            {
                                Mensagem.aviso = "CEP inválido!";
                                TelaMensagemAviso g = new TelaMensagemAviso();
                                g.ShowDialog();
                            }
                        }
                        else
                        {
                            Mensagem.aviso = "Insira uma imagem de perfil!";
                            TelaMensagemAviso g = new TelaMensagemAviso();
                            g.ShowDialog();
                        }
                    }
                    else
                    {
                        Mensagem.aviso = "CNPJ inválido!";
                        TelaMensagemAviso g = new TelaMensagemAviso();
                        g.ShowDialog();
                    }
                }
                else
                {
                    Mensagem.aviso = "Alguns campos não foram preenchidos!";
                    TelaMensagemAviso f = new TelaMensagemAviso();
                    f.ShowDialog();
                }
            }
            catch (Exception)
            {
                Mensagem.aviso = "Erro ao salvar!";
                TelaMensagemAviso f = new TelaMensagemAviso();
                f.ShowDialog();
            }
        }

        private void carregarInicial()
        {
            try
            {
                if (txtCNPJ.Text != "" && txtArea.Text != "" && txtSite.Text != "" && cbEstado.Text != "" && txtCidade.Text != "" && txtBairro.Text != "" && txtRua.Text != "" && txtNumero.Text != "" && txtCEP.Text != "" && txtCNPJ.Text != "")
                {
                    if (testeCNPJ(txtCNPJ.Text))
                    {
                        if (txtCEP.Text.Length == 9)
                        {
                            try
                            {
                                var empresa = bd.usuario_empresa.Where(x => x.FK_usuario == UsuarioDados.Id).FirstOrDefault();

                                if (empresa == null)
                                {
                                    byte[] FotoArr;
                                    using (var ms = new MemoryStream())
                                    {
                                        pbFotoPerfil.Image.Save(ms, pbFotoPerfil.Image.RawFormat);     //Insere o perfil pela primeira vez
                                        FotoArr = ms.ToArray();
                                    }

                                    bool bExisteCNPJ = false;

                                    var teste = bd.usuario_empresa.Where(x => x.FK_usuario != 0).FirstOrDefault();

                                    if (teste != null)
                                    {
                                        int max = bd.usuario_empresa.Max(x => x.FK_usuario);
                                        for (int idx = 0; idx <= max; idx++)
                                        {
                                            var verifica = bd.usuario_empresa.Where(x => x.FK_usuario == idx).
                                                Where(x => x.cnpj == txtCNPJ.Text).FirstOrDefault();

                                            if (verifica != null)
                                            {
                                                bExisteCNPJ = true;
                                            }
                                        }
                                    }

                                    if (!bExisteCNPJ)
                                    {
                                        usuario_empresa add = new usuario_empresa();
                                        add.cnpj = txtCNPJ.Text;
                                        add.areaEmpresa = txtArea.Text;
                                        add.FK_usuario = UsuarioDados.Id;

                                        bd.usuario_empresa.Add(add);
                                        bd.SaveChanges();

                                        perfil_empresa add2 = new perfil_empresa();
                                        add2.site = txtSite.Text;
                                        add2.instagram = txtInsta.Text;
                                        add2.twitter = txtTwitter.Text;
                                        add2.facebookEmpresa = txtFacebook.Text;
                                        add2.estadoEmpresa = cbEstado.Text;
                                        add2.cidadeEmpresa = txtCidade.Text;
                                        add2.bairroEmpresa = txtBairro.Text;
                                        add2.ruaEmpresa = txtRua.Text;
                                        add2.numeroEmpresa = txtNumero.Text;
                                        add2.cepEmpresa = txtCEP.Text;
                                        add2.FK_usuario_empresa = txtCNPJ.Text;
                                        add2.fotoEmpresa = FotoArr;
                                        add2.descricaoEmpresa = txtDesc.Text;

                                        bd.perfil_empresa.Add(add2);
                                        bd.SaveChanges();

                                        var teste2 = bd.usuario.Where(x => x.idUsuario == UsuarioDados.Id).ToList();

                                        teste2.ForEach(x =>
                                        {
                                            x.e_mailUsuario = txtEmail.Text;
                                            x.telefoneUsuario = txtTelefone.Text;
                                            x.nomeUsuario = txtNome.Text;
                                        });
                                        bd.SaveChanges();

                                        Mensagem.aviso = "Salvo com sucesso!";
                                        TelaMensagemAviso f = new TelaMensagemAviso();
                                        f.ShowDialog();

                                        if (!TesteTutorial.entrou)
                                        {
                                            TesteTutorial.entrou = true;
                                            TesteTutorial.instrucao = false;
                                        }

                                        this.Hide();
                                        TelaVisualizacaoPerfilEmpresa f2 = new TelaVisualizacaoPerfilEmpresa();   //Volta para tela principal
                                        f2.Closed += (s, args) => this.Close();
                                        f2.ShowDialog();
                                    }
                                    else
                                    {
                                        Mensagem.aviso = "CNPJ Já cadastrado!";
                                        TelaMensagemAviso f = new TelaMensagemAviso();
                                        f.ShowDialog();
                                    }
                                }
                            }
                            catch (Exception)
                            {
                                Mensagem.aviso = "Erro ao salvar!";
                                TelaMensagemAviso f = new TelaMensagemAviso();
                                f.ShowDialog();
                            }
                        }
                        else
                        {
                            Mensagem.aviso = "CEP inválido!";
                            TelaMensagemAviso g = new TelaMensagemAviso();
                            g.ShowDialog();
                        }
                    }
                    else
                    {
                        Mensagem.aviso = "CNPJ inválido!";
                        TelaMensagemAviso g = new TelaMensagemAviso();
                        g.ShowDialog();
                    }
                }
                else
                {
                    Mensagem.aviso = "Alguns campos não foram preenchidos!";
                    TelaMensagemAviso f = new TelaMensagemAviso();
                    f.ShowDialog();
                }
            }
            catch (Exception)
            {
                Mensagem.aviso = "Erro ao conectar!";
                TelaMensagemAviso f = new TelaMensagemAviso();
                f.ShowDialog();
            }
        }

        private void txtCNPJ_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8) { e.Handled = true; }

            if (char.IsNumber(e.KeyChar) == true)
            {
                switch (txtCNPJ.TextLength)
                {
                    case 0:                                        //Máscara de CNPJ
                        txtCNPJ.Text = "";
                        break;

                    case 2:
                        txtCNPJ.Text = txtCNPJ.Text + ".";
                        txtCNPJ.SelectionStart = 6;
                        break;

                    case 6:
                        txtCNPJ.Text = txtCNPJ.Text + ".";
                        txtCNPJ.SelectionStart = 10;
                        break;

                    case 10:
                        txtCNPJ.Text = txtCNPJ.Text + "/";
                        txtCNPJ.SelectionStart = 15;
                        break;

                    case 15:
                        txtCNPJ.Text = txtCNPJ.Text + "-";
                        txtCNPJ.SelectionStart = 17;
                        break;
                }
            }
        }

        private void txtTelefone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8) { e.Handled = true; }

            if (char.IsNumber(e.KeyChar) == true)
            {
                switch (txtTelefone.TextLength)
                {
                    case 0:                                        //Máscara de telefone
                        txtTelefone.Text = "";
                        break;

                    case 2:
                        txtTelefone.Text = "(" + txtTelefone.Text + ")";
                        txtTelefone.SelectionStart = 10;
                        break;

                    case 8:
                        txtTelefone.Text = txtTelefone.Text + "-";
                        txtTelefone.SelectionStart = 14;
                        break;
                }
            }
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

        private void pbMinimizar_MouseEnter(object sender, EventArgs e)       //Animação do botões
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

        private void p_barra_Paint(object sender, PaintEventArgs e)
        {
            int x = (p_barra.Size.Width - lbl_perfil.Width) / 2;
            int y = (p_barra.Size.Height - lbl_perfil.Height);       //Posição da label na barra ao maximizar e desmaximizar 

            lbl_perfil.Location = new Point(x, y);
        }

        private void p_barra_Resize(object sender, EventArgs e)
        {
            int x = (p_barra.Size.Width - lbl_perfil.Width) / 2;
            int y = (p_barra.Size.Height - lbl_perfil.Height);       //Posição da label na barra ao maximizar e desmaximizar 

            lbl_perfil.Location = new Point(x, y);
        }

        private void pb_voltar_Click(object sender, EventArgs e)
        {
            this.Hide();
            TelaVisualizacaoPerfilEmpresa f = new TelaVisualizacaoPerfilEmpresa();   //Volta para tela principal
            f.Closed += (s, args) => this.Close();
            f.ShowDialog();
        }

        private void pb_voltar_MouseEnter(object sender, EventArgs e)
        {
            pb_voltar.Image = Properties.Resources.VoltarRoxo;        //Animação do botão voltar
        }

        private void pb_voltar_MouseLeave(object sender, EventArgs e)
        {
            pb_voltar.Image = Properties.Resources.voltar;
        }

        private void txtCNPJ_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                txtCNPJ.Clear();             //Limpar campo 
            }
            else if (e.KeyCode == Keys.Back)
            {
                txtCNPJ.Clear();
            }
        }

        private void txtTelefone_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                txtTelefone.Clear();             //Limpar campo 
            }
            else if (e.KeyCode == Keys.Back)
            {
                txtTelefone.Clear();
            }
        }

        private void txtCEP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8) { e.Handled = true; }

            if (char.IsNumber(e.KeyChar) == true)
            {
                switch (txtCEP.TextLength)
                {
                    case 0:                                        //Máscara de CEP
                        txtCEP.Text = "";
                        break;

                    case 5:
                        txtCEP.Text = txtCEP.Text + "-";
                        txtCEP.SelectionStart = 8;
                        break;
                }
            }
        }

        private void txtCEP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                txtCEP.Clear();             //Limpar campo 
            }
            else if (e.KeyCode == Keys.Back)
            {
                txtCEP.Clear();
            }
        }

        private bool testeCNPJ(string cnpj)
        {
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            int somador;
            int resto;
            string digito;
            string cnpjAux;
            cnpj = cnpj.Trim();

            cnpj = cnpj.Remove(2, 1);
            cnpj = cnpj.Remove(5, 1);
            cnpj = cnpj.Remove(8, 1);
            cnpj = cnpj.Remove(12, 1);

            if (cnpj.Length != 14)
            {
                return false;
            }
            else
            {
                cnpjAux = cnpj.Substring(0, 12);
                somador = 0;
                for (int i = 0; i < 12; i++)
                {
                    somador += int.Parse(cnpjAux[i].ToString()) * multiplicador1[i];
                }
                resto = (somador % 11);
                if (resto < 2)
                    resto = 0;
                else
                    resto = 11 - resto;
                digito = resto.ToString();
                cnpjAux = cnpjAux + digito;
                somador = 0;

                for (int i = 0; i < 13; i++)
                {
                    somador += int.Parse(cnpjAux[i].ToString()) * multiplicador2[i];
                }
                resto = (somador % 11);
                if (resto < 2)
                    resto = 0;
                else
                    resto = 11 - resto;
                digito = digito + resto.ToString();
                return cnpj.EndsWith(digito);
            }
        }
    }
}
