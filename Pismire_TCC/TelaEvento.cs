using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Pismire_TCC.Resources;

namespace Pismire_TCC
{
    public partial class TelaEvento : Form
    {
        PismireEntities5 bd = new PismireEntities5();

        bool saude = false;
        bool odon = false;
        bool alim = false;
        bool cultura = false;              //Testadores lógicos dos beneficios
        bool home = false;
        bool viagem = false;
        bool convivencia = false;
        bool bolsa = false;
        bool testePassou = false;
        bool testePassou2 = false;
        string realSalario = "";

        public TelaEvento()
        {
            InitializeComponent();
            EditarEvento.passou = false;

            Maximizacao.verifique(this, pbMaximizar);   //Verifica se a tela está maximizada ou não
            txtInicioEvento.Enabled = false;

            try
            {
                if (EditarEvento.ID != 0)
                {
                    var empresa = bd.usuario_empresa.Where(x => x.FK_usuario == UsuarioDados.Id).FirstOrDefault();

                    var evento = bd.evento.Where(y => y.FK_usuario_empresa ==
                    empresa.cnpj).Where(x => x.idEvento == EditarEvento.ID).FirstOrDefault(); //Carregamento das informações

                    txtVagaProp.Text = evento.vagaEvento;
                    txtArea.Text = evento.areaEvento;
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

                    string salario = "R$: " + (txt);
                    txtSalario.Text = salario;
                    cbTurno.Text = evento.turno;
                    txtHorarioInicial.Text = evento.horarioInicialExpedienteEvento.ToString();     //Página 1
                    txtHorarioFinal.Text = evento.horarioFinalExpedienteEvento.ToString();
                    txtTelefone.Text = evento.telefoneEvento;
                    cbTipoEmprego.Text = evento.tipoEmprego;
                    txtInicioEvento.Text = evento.dataInicialEvento.ToShortDateString();
                    txtFinalEvento.Text = evento.dataFinalEvento.ToShortDateString();
                    //----------------------
                    txtRua.Text = evento.ruaEvento;
                    txtNumero.Text = evento.numeroEvento;
                    txtBairro.Text = evento.bairroEvento;   //Página 2
                    txtCidade.Text = evento.cidadeEvento;
                    cbEstado.Text = evento.estadoEvento;
                    txtCEP.Text = evento.cepEvento;
                    //----------------------
                    var beneficios = bd.beneficios.Where(x => x.FK_evento == EditarEvento.ID).FirstOrDefault();

                    if (beneficios.assistenciaSaude == false)
                    {
                        pbSaude.Image = Properties.Resources.caixa_de_selecao__1_;            //Seleção Beneficio Saude
                        saude = false;
                    }
                    else
                    {
                        pbSaude.Image = Properties.Resources.verifica;
                        saude = true;
                    }

                    if (beneficios.assistenciaOdontologica == false)
                    {
                        pbOdontologica.Image = Properties.Resources.caixa_de_selecao__1_;     //Seleção Beneficio Odontologico
                        odon = false;
                    }
                    else
                    {
                        pbOdontologica.Image = Properties.Resources.verifica;
                        odon = true;
                    }

                    if (beneficios.valeAlimentacao == false)
                    {
                        pbAlimentacao.Image = Properties.Resources.caixa_de_selecao__1_;  //Seleção Beneficio Alimentação
                        alim = false;
                    }
                    else
                    {
                        pbAlimentacao.Image = Properties.Resources.verifica;
                        alim = true;
                    }

                    if (beneficios.valeCultura == false)
                    {
                        pbCultura.Image = Properties.Resources.caixa_de_selecao__1_;     //Seleção Beneficio Cultura
                        cultura = false;
                    }
                    else
                    {
                        pbCultura.Image = Properties.Resources.verifica;
                        cultura = true;
                    }

                    if (beneficios.trabalhoHomeOffice == false)
                    {
                        pbHomeOffice.Image = Properties.Resources.caixa_de_selecao__1_;   //Seleção Beneficio Home Office
                        home = false;
                    }
                    else
                    {
                        pbHomeOffice.Image = Properties.Resources.verifica;
                        home = true;
                    }

                    if (beneficios.valeViagem == false)
                    {
                        pbViagem.Image = Properties.Resources.caixa_de_selecao__1_;      //Seleção Beneficio Viagem
                        viagem = false;
                    }
                    else
                    {
                        pbViagem.Image = Properties.Resources.verifica;
                        viagem = true;
                    }

                    if (beneficios.salasDeConferencias == false)
                    {
                        pbConvivencia.Image = Properties.Resources.caixa_de_selecao__1_;    //Seleção Beneficio Convivencia
                        convivencia = false;
                    }
                    else
                    {
                        pbConvivencia.Image = Properties.Resources.verifica;
                        convivencia = true;
                    }

                    if (beneficios.bolsasDeEstudos == false)
                    {
                        pbBolsa.Image = Properties.Resources.caixa_de_selecao__1_;              //Seleção Beneficio Bolsa de Estudos
                        bolsa = false;
                    }
                    else
                    {
                        pbBolsa.Image = Properties.Resources.verifica;
                        bolsa = true;
                    }
                    txtInicioEvento.Enabled = false;
                }
                else if (txtInicioEvento.Text == "")
                {
                    DateTime dataAtual = (DateTime.Today).Date;    //Insere data atual
                    txtInicioEvento.Text = dataAtual.ToShortDateString();
                }
            }
            catch (Exception)
            {
                Mensagem.aviso = "Erro ao conectar!";
                TelaMensagemAviso f = new TelaMensagemAviso();
                f.ShowDialog();
            }
        }

        private void PreencheAba2()
        {
            var id = bd.usuario_empresa.Where(x => x.FK_usuario == UsuarioDados.Id).FirstOrDefault();
            if (id != null)
            {
                var complemento = bd.perfil_empresa.Where(x => x.FK_usuario_empresa == id.cnpj).FirstOrDefault();

                if (complemento != null)
                {
                    txtRua.Text = complemento.ruaEmpresa;
                    txtCidade.Text = complemento.cidadeEmpresa;
                    txtNumero.Text = complemento.numeroEmpresa;
                    cbEstado.SelectedItem = complemento.estadoEmpresa;
                    txtBairro.Text = complemento.bairroEmpresa;
                    txtCEP.Text = complemento.cepEmpresa;
                }

            }
        }

        private void pbSaude_Click(object sender, EventArgs e)
        {
            if (saude == false)
            {
                pbSaude.Image = Properties.Resources.verifica;            //Seleção Beneficio Saude
                saude = true;
            }
            else
            {
                pbSaude.Image = Properties.Resources.caixa_de_selecao__1_;
                saude = false;
            }
        }

        private void pbOdontologica_Click(object sender, EventArgs e)
        {
            if (odon == false)
            {
                pbOdontologica.Image = Properties.Resources.verifica;     //Seleção Beneficio Odontologico
                odon = true;
            }
            else
            {
                pbOdontologica.Image = Properties.Resources.caixa_de_selecao__1_;
                odon = false;
            }
        }

        private void pbAlimentacao_Click(object sender, EventArgs e)
        {
            if (alim == false)
            {
                pbAlimentacao.Image = Properties.Resources.verifica;  //Seleção Beneficio Alimentação
                alim = true;
            }
            else
            {
                pbAlimentacao.Image = Properties.Resources.caixa_de_selecao__1_;
                alim = false;
            }
        }

        private void pbCultura_Click(object sender, EventArgs e)
        {
            if (cultura == false)
            {
                pbCultura.Image = Properties.Resources.verifica;     //Seleção Beneficio Cultura
                cultura = true;
            }
            else
            {
                pbCultura.Image = Properties.Resources.caixa_de_selecao__1_;
                cultura = false;
            }
        }

        private void pbHomeOff_Click(object sender, EventArgs e)
        {
            if (home == false)
            {
                pbHomeOffice.Image = Properties.Resources.verifica;   //Seleção Beneficio Home Office
                home = true;
            }
            else
            {
                pbHomeOffice.Image = Properties.Resources.caixa_de_selecao__1_;
                home = false;
            }
        }

        private void pbViagem_Click(object sender, EventArgs e)
        {
            if (viagem == false)
            {
                pbViagem.Image = Properties.Resources.verifica;      //Seleção Beneficio Viagem
                viagem = true;
            }
            else
            {
                pbViagem.Image = Properties.Resources.caixa_de_selecao__1_;
                viagem = false;
            }
        }

        private void pbConvivencia_Click(object sender, EventArgs e)
        {
            if (convivencia == false)
            {
                pbConvivencia.Image = Properties.Resources.verifica;    //Seleção Beneficio Convivencia
                convivencia = true;
            }
            else
            {
                pbConvivencia.Image = Properties.Resources.caixa_de_selecao__1_;
                convivencia = false;
            }
        }

        private void pbBolsa_Click(object sender, EventArgs e)
        {
            if (bolsa == false)
            {
                pbBolsa.Image = Properties.Resources.verifica;              //Seleção Beneficio Bolsa de Estudos
                bolsa = true;
            }
            else
            {
                pbBolsa.Image = Properties.Resources.caixa_de_selecao__1_;
                bolsa = false;
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

        private void p_barra_Paint(object sender, PaintEventArgs e)
        {
            int x = (p_barra.Size.Width - lbl_evento.Width) / 2;
            int y = (p_barra.Size.Height - lbl_evento.Height);       //Posição da label na barra

            lbl_evento.Location = new Point(x, y);
        }

        private void p_barra_Resize(object sender, EventArgs e)
        {
            int x = (p_barra.Size.Width - lbl_evento.Width) / 2;
            int y = (p_barra.Size.Height - lbl_evento.Height);       //Posição da label na barra

            lbl_evento.Location = new Point(x, y);
        }

        private void pb_voltar_Click(object sender, EventArgs e)
        {
            try
            {
                if (EditarEvento.ID == 0 && EditarEvento.passou)
                {
                    var evento = bd.evento.Where(x => x.idEvento == PegarIDEvento.IDEvento).FirstOrDefault();

                    //Exclui o evento

                    if (evento != null)
                    {
                        var idioma = bd.idioma_evento.Where(x => x.FK_evento == PegarIDEvento.IDEvento).FirstOrDefault();

                        if (idioma != null)
                        {
                            int idiomaMax = bd.idioma_evento.Max(x => x.idIdiomaEvento);

                            for (int i = 1; i <= idiomaMax; i++)
                            {
                                var idiomaSel = bd.idioma_evento.Where(x => x.FK_evento == PegarIDEvento.IDEvento).   //Exclui todos os idiomas do evento
                                Where(x => x.idIdiomaEvento == i).FirstOrDefault();

                                if (idiomaSel != null)
                                {
                                    bd.idioma_evento.Remove(idiomaSel);
                                    bd.SaveChanges();
                                }
                            }
                        }

                        var exp = bd.experiencia_profissional_evento.Where(x => x.FK_evento == PegarIDEvento.IDEvento).FirstOrDefault();

                        if (exp != null)
                        {
                            int expMax = bd.experiencia_profissional_evento.Max(x => x.idExperienciaEvento);

                            for (int i = 1; i <= expMax; i++)
                            {
                                var ExpSel = bd.experiencia_profissional_evento.Where(x => x.FK_evento == PegarIDEvento.IDEvento).   //Exclui todas as exp do evento
                                Where(x => x.idExperienciaEvento == i).FirstOrDefault();

                                if (ExpSel != null)
                                {
                                    bd.experiencia_profissional_evento.Remove(ExpSel);
                                    bd.SaveChanges();
                                }
                            }
                        }

                        var expInt = bd.experiencia_internacional_evento.Where(x => x.FK_evento == PegarIDEvento.IDEvento).FirstOrDefault();

                        if (expInt != null)
                        {
                            int expIntMax = bd.experiencia_internacional_evento.Max(x => x.idInternacionalEvento);

                            for (int i = 1; i <= expIntMax; i++)
                            {
                                var ExpIntSel = bd.experiencia_internacional_evento.Where(x => x.FK_evento ==
                                PegarIDEvento.IDEvento).Where(x => x.idInternacionalEvento == i).FirstOrDefault(); //Exclui todas as exp int do evento

                                if (ExpIntSel != null)
                                {
                                    bd.experiencia_internacional_evento.Remove(ExpIntSel);
                                    bd.SaveChanges();
                                }
                            }
                        }

                        var qua = bd.qualificacao_evento.Where(x => x.FK_evento == PegarIDEvento.IDEvento).FirstOrDefault();

                        if (qua != null)
                        {
                            int quaMax = bd.qualificacao_evento.Max(x => x.idQualificacaoEvento);

                            for (int i = 1; i <= quaMax; i++)
                            {
                                var quaSel = bd.qualificacao_evento.Where(x => x.FK_evento ==
                                PegarIDEvento.IDEvento).Where(x => x.idQualificacaoEvento == i).FirstOrDefault();

                                //Exclui todas as qualificoes do evento

                                if (quaSel != null)
                                {
                                    bd.qualificacao_evento.Remove(quaSel);
                                    bd.SaveChanges();
                                }
                            }
                        }

                        var beneficios = bd.beneficios.Where(x => x.FK_evento == PegarIDEvento.IDEvento).FirstOrDefault();

                        if (beneficios != null)
                        {
                            int beneficiosMax = bd.beneficios.Max(x => x.idBeneficio);
                            for (int i = 1; i <= beneficiosMax; i++)
                            {
                                var beneficioSel = bd.beneficios.Where(x => x.FK_evento ==
                                PegarIDEvento.IDEvento).Where(x => x.idBeneficio == i).FirstOrDefault(); //Exclui todas as qualificoes do evento

                                if (beneficioSel != null)
                                {
                                    bd.beneficios.Remove(beneficioSel);
                                    bd.SaveChanges();
                                }
                            }
                        }

                        var candidatos = bd.candidatos.Where(x => x.FK_evento == PegarIDEvento.IDEvento).FirstOrDefault();

                        if (candidatos != null)
                        {
                            int candidatosMax = bd.candidatos.Max(x => x.idCandidatos);
                            for (int i = 1; i <= candidatosMax; i++)
                            {
                                var candidatoSel = bd.candidatos.Where(x => x.FK_evento ==
                                PegarIDEvento.IDEvento).Where(x => x.idCandidatos == i).FirstOrDefault(); //Exclui todas as qualificoes do evento

                                if (candidatoSel != null)
                                {
                                    bd.candidatos.Remove(candidatoSel);
                                    bd.SaveChanges();
                                }
                            }
                        }

                        bd.evento.Remove(evento);
                        bd.SaveChanges();
                    }

                    EditarEvento.ID = 0;
                    EditarEvento.passou = false;

                    this.Hide();
                    TelaPrincipalEmpresa f2 = new TelaPrincipalEmpresa();
                    f2.Closed += (s, args) => this.Close();                    //Volta para tela principal
                    f2.ShowDialog();
                }
                else
                {
                    if (EditarEvento.passouEvento)
                    {
                        try
                        {
                            DateTime dataInicial2 = new DateTime();
                            dataInicial2 = Convert.ToDateTime(txtInicioEvento.Text);     //Validação de data

                            DateTime dataFinal2 = new DateTime();
                            dataFinal2 = Convert.ToDateTime(txtFinalEvento.Text);        //Click Pagina 2

                            if (dataFinal2 > dataInicial2)
                            {
                                var evento = bd.evento.Where(x => x.idEvento == EditarEvento.ID).ToList();

                                if (evento != null)
                                {
                                    evento.ForEach(x =>
                                    {                                                   //Salva o evento 
                                        x.vagaEvento = txtVagaProp.Text;
                                        x.areaEvento = txtArea.Text;
                                        realSalario = txtSalario.Text.Replace(".", "");
                                        realSalario = realSalario.Replace("R$:", "");
                                        x.salario = Convert.ToDouble(realSalario);
                                        x.turno = cbTurno.Text;
                                        var horarioInicial = TimeSpan.Parse(txtHorarioInicial.Text);
                                        x.horarioInicialExpedienteEvento = horarioInicial;
                                        var horarioFinal = TimeSpan.Parse(txtHorarioFinal.Text);
                                        x.horarioFinalExpedienteEvento = horarioFinal;
                                        x.telefoneEvento = txtTelefone.Text;
                                        x.tipoEmprego = cbTipoEmprego.Text;
                                        var dataInicial = Convert.ToDateTime(txtInicioEvento.Text).ToString("dd/MM/yyyy");
                                        x.dataInicialEvento = Convert.ToDateTime(dataInicial);
                                        var dataFinal = Convert.ToDateTime(txtFinalEvento.Text).ToString("dd/MM/yyyy");
                                        x.dataFinalEvento = Convert.ToDateTime(dataFinal);

                                        x.ruaEvento = txtRua.Text;
                                        x.numeroEvento = txtNumero.Text;
                                        x.bairroEvento = txtBairro.Text;
                                        x.cidadeEvento = txtCidade.Text;
                                        x.estadoEvento = cbEstado.Text;
                                        x.cepEvento = txtCEP.Text;
                                    });
                                    bd.SaveChanges();

                                    var beneficio = bd.beneficios.Where(x => x.FK_evento == EditarEvento.ID).ToList();

                                    if (beneficio != null)
                                    {
                                        beneficio.ForEach(x =>
                                        {
                                            if (saude == true)
                                            {
                                                x.assistenciaSaude = true;                    //Adiciona Beneficio Saude
                                            }
                                            else
                                            {
                                                x.assistenciaSaude = false;
                                            }
                                            if (odon == true)
                                            {
                                                x.assistenciaOdontologica = true;             //Adiciona Beneficio Odontologico
                                            }
                                            else
                                            {
                                                x.assistenciaOdontologica = false;
                                            }
                                            if (alim == true)
                                            {
                                                x.valeAlimentacao = true;                    //Adiciona beneficio Alimentacao
                                            }
                                            else
                                            {
                                                x.valeAlimentacao = false;
                                            }
                                            if (cultura == true)
                                            {
                                                x.valeCultura = true;                       //Adiciona beneficio vale cultura
                                            }
                                            else
                                            {
                                                x.valeCultura = false;
                                            }
                                            if (home == true)
                                            {
                                                x.trabalhoHomeOffice = true;               //Adiciona beneficio home office
                                            }
                                            else
                                            {
                                                x.trabalhoHomeOffice = false;
                                            }
                                            if (viagem == true)
                                            {
                                                x.valeViagem = true;                      //Adiciona beneficio Vale viagem
                                            }
                                            else
                                            {
                                                x.valeViagem = false;
                                            }
                                            if (convivencia == true)
                                            {
                                                x.salasDeConferencias = true;              //Adiciona beneficio sala de convivencia
                                            }
                                            else
                                            {
                                                x.salasDeConferencias = false;
                                            }
                                            if (bolsa == true)
                                            {
                                                x.bolsasDeEstudos = true;                 //Adiciona beneficio bolsa de estudos
                                            }
                                            else
                                            {
                                                x.bolsasDeEstudos = false;
                                            }
                                        });
                                        bd.SaveChanges();
                                    }

                                    EditarEvento.passouEvento = false;

                                    Mensagem.aviso = "Evento editado com sucesso!";
                                    TelaMensagemAviso f3 = new TelaMensagemAviso();
                                    f3.ShowDialog();
                                    EditarEvento.ID = 0;

                                    this.Hide();
                                    TelaEventosCriados f4 = new TelaEventosCriados();
                                    f4.Closed += (s, args) => this.Close();                    //Volta para eventos criados
                                    f4.ShowDialog();
                                }
                            }
                            else
                            {
                                Mensagem.aviso = "Data inicial não pode ser maior ou igual a final!";
                                TelaMensagemAviso f3 = new TelaMensagemAviso();
                                f3.ShowDialog();
                            }
                        }
                        catch (Exception)
                        {
                            Mensagem.aviso = "Erro ao editar evento!";
                            TelaMensagemAviso f3 = new TelaMensagemAviso();
                            f3.ShowDialog();
                            EditarEvento.ID = 0;

                            this.Hide();
                            TelaEventosCriados f4 = new TelaEventosCriados();
                            f4.Closed += (s, args) => this.Close();                    //Volta para eventos criados
                            f4.ShowDialog();
                        }
                    }
                    else
                    {
                        EditarEvento.passouEvento = false;
                        this.Hide();
                        TelaPrincipalEmpresa f = new TelaPrincipalEmpresa();
                        f.Closed += (s, args) => this.Close();                    //Volta para eventos criados
                        f.ShowDialog();
                    }
                }
            }
            catch (Exception)
            {
                Mensagem.aviso = "Erro ao conectar com o banco!";
                TelaMensagemAviso f = new TelaMensagemAviso();
                f.ShowDialog();
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
            if (EditarEvento.ID == 0)
            {
                var evento = bd.evento.Where(x => x.idEvento == PegarIDEvento.IDEvento).FirstOrDefault();
                var idioma = bd.idioma_evento.Where(x => x.FK_evento == PegarIDEvento.IDEvento).FirstOrDefault();
                var exp = bd.experiencia_profissional_evento.Where(x => x.FK_evento == PegarIDEvento.IDEvento).FirstOrDefault();
                var expInt = bd.experiencia_internacional_evento.Where(x => x.FK_evento == PegarIDEvento.IDEvento).FirstOrDefault();
                var qua = bd.qualificacao_evento.Where(x => x.FK_evento == PegarIDEvento.IDEvento).FirstOrDefault();
                var beneficios = bd.beneficios.Where(x => x.FK_evento == PegarIDEvento.IDEvento).FirstOrDefault();

                //Exclui o evento

                if (evento != null)
                {
                    if (idioma != null)
                    {
                        int idiomaMax = bd.idioma_evento.Max(x => x.idIdiomaEvento);

                        for (int i = 1; i <= idiomaMax; i++)
                        {
                            var idiomaSel = bd.idioma_evento.Where(x => x.FK_evento == PegarIDEvento.IDEvento).   //Exclui todos os idiomas do evento
                            Where(x => x.idIdiomaEvento == i).FirstOrDefault();

                            if (idiomaSel != null)
                            {
                                bd.idioma_evento.Remove(idiomaSel);
                                bd.SaveChanges();
                            }
                        }
                    }

                    if (exp != null)
                    {
                        int expMax = bd.experiencia_profissional_evento.Max(x => x.idExperienciaEvento);

                        for (int i = 1; i <= expMax; i++)
                        {
                            var ExpSel = bd.experiencia_profissional_evento.Where(x => x.FK_evento == PegarIDEvento.IDEvento).   //Exclui todas as exp do evento
                            Where(x => x.idExperienciaEvento == i).FirstOrDefault();

                            if (ExpSel != null)
                            {
                                bd.experiencia_profissional_evento.Remove(ExpSel);
                                bd.SaveChanges();
                            }
                        }
                    }

                    if (expInt != null)
                    {
                        int expIntMax = bd.experiencia_internacional_evento.Max(x => x.idInternacionalEvento);

                        for (int i = 1; i <= expIntMax; i++)
                        {
                            var ExpIntSel = bd.experiencia_internacional_evento.Where(x => x.FK_evento ==
                            PegarIDEvento.IDEvento).Where(x => x.idInternacionalEvento == i).FirstOrDefault(); //Exclui todas as exp int do evento

                            if (ExpIntSel != null)
                            {
                                bd.experiencia_internacional_evento.Remove(ExpIntSel);
                                bd.SaveChanges();
                            }
                        }
                    }

                    if (qua != null)
                    {
                        int quaMax = bd.qualificacao_evento.Max(x => x.idQualificacaoEvento);

                        for (int i = 1; i <= quaMax; i++)
                        {
                            var quaSel = bd.qualificacao_evento.Where(x => x.FK_evento ==
                            PegarIDEvento.IDEvento).Where(x => x.idQualificacaoEvento == i).FirstOrDefault();

                            //Exclui todas as qualificoes do evento

                            if (quaSel != null)
                            {
                                bd.qualificacao_evento.Remove(quaSel);
                                bd.SaveChanges();
                            }
                        }
                    }

                    if (beneficios != null)
                    {
                        int beneficiosMax = bd.beneficios.Max(x => x.idBeneficio);
                        for (int i = 1; i <= beneficiosMax; i++)
                        {
                            var beneficioSel = bd.beneficios.Where(x => x.FK_evento ==
                            PegarIDEvento.IDEvento).Where(x => x.idBeneficio == i).FirstOrDefault(); //Exclui todas as qualificoes do evento

                            if (beneficioSel != null)
                            {
                                bd.beneficios.Remove(beneficioSel);
                                bd.SaveChanges();
                            }
                        }
                    }
                    bd.evento.Remove(evento);
                    bd.SaveChanges();
                }
                EditarEvento.ID = 0;
                this.Close();
            }
            else
            {
                try
                {
                    DateTime dataInicial2 = new DateTime();
                    dataInicial2 = Convert.ToDateTime(txtInicioEvento.Text);     //Validação de data

                    DateTime dataFinal2 = new DateTime();
                    dataFinal2 = Convert.ToDateTime(txtFinalEvento.Text);        //Click Pagina 2

                    if (dataFinal2 > dataInicial2)
                    {
                        var evento = bd.evento.Where(x => x.idEvento == EditarEvento.ID).ToList();

                        if (evento != null)
                        {
                            evento.ForEach(x =>
                            {                                                   //Salva o evento 
                                x.vagaEvento = txtVagaProp.Text;
                                x.areaEvento = txtArea.Text;
                                realSalario = txtSalario.Text.Replace(".", "");
                                realSalario = realSalario.Replace("R$:", "");
                                x.salario = Convert.ToDouble(realSalario);
                                x.turno = cbTurno.Text;
                                var horarioInicial = TimeSpan.Parse(txtHorarioInicial.Text);
                                x.horarioInicialExpedienteEvento = horarioInicial;
                                var horarioFinal = TimeSpan.Parse(txtHorarioFinal.Text);
                                x.horarioFinalExpedienteEvento = horarioFinal;
                                x.telefoneEvento = txtTelefone.Text;
                                x.tipoEmprego = cbTipoEmprego.Text;
                                var dataInicial = Convert.ToDateTime(txtInicioEvento.Text).ToString("dd/MM/yyyy");
                                x.dataInicialEvento = Convert.ToDateTime(dataInicial);
                                var dataFinal = Convert.ToDateTime(txtFinalEvento.Text).ToString("dd/MM/yyyy");
                                x.dataFinalEvento = Convert.ToDateTime(dataFinal);

                                x.ruaEvento = txtRua.Text;
                                x.numeroEvento = txtNumero.Text;
                                x.bairroEvento = txtBairro.Text;
                                x.cidadeEvento = txtCidade.Text;
                                x.estadoEvento = cbEstado.Text;
                                x.cepEvento = txtCEP.Text;
                            });
                            bd.SaveChanges();

                            var beneficio = bd.beneficios.Where(x => x.FK_evento == EditarEvento.ID).ToList();

                            if (beneficio != null)
                            {
                                beneficio.ForEach(x =>
                                {
                                    if (saude == true)
                                    {
                                        x.assistenciaSaude = true;                    //Adiciona Beneficio Saude
                                        }
                                    else
                                    {
                                        x.assistenciaSaude = false;
                                    }
                                    if (odon == true)
                                    {
                                        x.assistenciaOdontologica = true;             //Adiciona Beneficio Odontologico
                                        }
                                    else
                                    {
                                        x.assistenciaOdontologica = false;
                                    }
                                    if (alim == true)
                                    {
                                        x.valeAlimentacao = true;                    //Adiciona beneficio Alimentacao
                                        }
                                    else
                                    {
                                        x.valeAlimentacao = false;
                                    }
                                    if (cultura == true)
                                    {
                                        x.valeCultura = true;                       //Adiciona beneficio vale cultura
                                        }
                                    else
                                    {
                                        x.valeCultura = false;
                                    }
                                    if (home == true)
                                    {
                                        x.trabalhoHomeOffice = true;               //Adiciona beneficio home office
                                        }
                                    else
                                    {
                                        x.trabalhoHomeOffice = false;
                                    }
                                    if (viagem == true)
                                    {
                                        x.valeViagem = true;                      //Adiciona beneficio Vale viagem
                                        }
                                    else
                                    {
                                        x.valeViagem = false;
                                    }
                                    if (convivencia == true)
                                    {
                                        x.salasDeConferencias = true;              //Adiciona beneficio sala de convivencia
                                        }
                                    else
                                    {
                                        x.salasDeConferencias = false;
                                    }
                                    if (bolsa == true)
                                    {
                                        x.bolsasDeEstudos = true;                 //Adiciona beneficio bolsa de estudos
                                        }
                                    else
                                    {
                                        x.bolsasDeEstudos = false;
                                    }
                                });
                                bd.SaveChanges();
                            }

                            Mensagem.aviso = "Evento editado com sucesso!";
                            TelaMensagemAviso f3 = new TelaMensagemAviso();
                            f3.ShowDialog();
                            EditarEvento.ID = 0;
                            this.Close();
                        }
                    }
                    else
                    {
                        Mensagem.aviso = "Data inicial não pode ser maior ou igual a final!";
                        TelaMensagemAviso f3 = new TelaMensagemAviso();
                        f3.ShowDialog();
                    }
                }
                catch (Exception)
                {
                    Mensagem.aviso = "Erro ao editar evento!";
                    TelaMensagemAviso f3 = new TelaMensagemAviso();
                    f3.ShowDialog();
                }
            }

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

        private void pbPag1_Click(object sender, EventArgs e)
        {
            pnImg1.Visible = true;
            pnImg2.Visible = false;
            pnImg3.Visible = false;
            pnImg4.Visible = false;
            pbPag1.Image = Properties.Resources.Verificado_evento;
            pbPag2.Image = Properties.Resources._2_evento1;                //Click Pagina 1
            pbPag3.Image = Properties.Resources._3_evento1;
            pbPag4.Image = Properties.Resources._4_evento1;
            btSalvar.Visible = false;
        }

        private void pbPag2_Click(object sender, EventArgs e)
        {
            if (txtVagaProp.Text != "" && txtArea.Text != "" && txtSalario.Text != "" && cbTurno.Text != "" &&
            txtHorarioInicial.Text != "" && txtHorarioFinal.Text != "" && txtTelefone.Text != "" && cbTipoEmprego.Text != "" &&
            txtInicioEvento.Text != "" && txtFinalEvento.Text != "")
            {
                try
                {
                    PreencheAba2();

                    DateTime dataInicial = new DateTime();
                    dataInicial = Convert.ToDateTime(txtInicioEvento.Text);     //Validação de data

                    DateTime dataFinal = new DateTime();
                    dataFinal = Convert.ToDateTime(txtFinalEvento.Text);        //Click Pagina 2

                    DateTime dataAtual = (DateTime.Today).Date;        //Data atual

                    if (dataInicial < dataFinal)
                    {
                        if (EditarEvento.ID == 0)
                        {
                            if (dataInicial >= dataAtual && dataFinal > dataAtual)
                            {
                                try
                                {
                                    TimeSpan horarioInicial = new TimeSpan();
                                    TimeSpan horarioFinal = new TimeSpan();         //Verificação de horário

                                    horarioInicial = Convert.ToDateTime(txtHorarioInicial.Text).TimeOfDay;
                                    horarioFinal = Convert.ToDateTime(txtHorarioFinal.Text).TimeOfDay;

                                    verificacaoParte2(horarioInicial, horarioFinal);
                                }
                                catch (Exception)
                                {
                                    Mensagem.aviso = "Insira um horário válido!";
                                    TelaMensagemAviso f2 = new TelaMensagemAviso();
                                    f2.ShowDialog();
                                }
                            }
                            else
                            {
                                Mensagem.aviso = "Insira uma data válida!";
                                TelaMensagemAviso f2 = new TelaMensagemAviso();
                                f2.ShowDialog();
                            }
                        }
                        else
                        {
                            if (dataFinal > dataAtual)
                            {
                                try
                                {
                                    TimeSpan horarioInicial = new TimeSpan();
                                    TimeSpan horarioFinal = new TimeSpan();         //Verificação de horário

                                    horarioInicial = Convert.ToDateTime(txtHorarioInicial.Text).TimeOfDay;
                                    horarioFinal = Convert.ToDateTime(txtHorarioFinal.Text).TimeOfDay;

                                    verificacaoParte2(horarioInicial, horarioFinal);
                                }
                                catch (Exception)
                                {
                                    Mensagem.aviso = "Insira um horário válido!";
                                    TelaMensagemAviso f2 = new TelaMensagemAviso();
                                    f2.ShowDialog();
                                }
                            }
                            else
                            {
                                Mensagem.aviso = "Insira uma data válida!";
                                TelaMensagemAviso f2 = new TelaMensagemAviso();
                                f2.ShowDialog();
                            }
                        }
                    }
                    else
                    {
                        Mensagem.aviso = "Data inicial não pode ser maior nem igual a final!";
                        TelaMensagemAviso f2 = new TelaMensagemAviso();
                        f2.ShowDialog();
                    }
                }
                catch (Exception)
                {
                    Mensagem.aviso = "Insira uma data válida!";
                    TelaMensagemAviso f2 = new TelaMensagemAviso();
                    f2.ShowDialog();
                }
            }
            else
            {
                Mensagem.aviso = "Preencha todos os campos desta etapa para avançar!";
                TelaMensagemAviso f2 = new TelaMensagemAviso();
                f2.ShowDialog();
            }
        }

        private void verificacaoParte2(TimeSpan t1, TimeSpan t2)
        {
            try
            {                                  //Validação da hora
                if (t1.Hours < t2.Hours)
                {
                    pnImg1.Visible = false;
                    pnImg2.Visible = true;
                    pnImg3.Visible = false;
                    pnImg4.Visible = false;
                    pbPag1.Image = Properties.Resources.Verificado_evento;
                    pbPag2.Image = Properties.Resources.Verificado_evento;              //Pagina 2
                    pbPag3.Image = Properties.Resources._3_evento1;
                    pbPag4.Image = Properties.Resources._4_evento1;
                    btSalvar.Visible = false;
                }
                else
                {
                    if (t1.Hours == t2.Hours)
                    {
                        if (t1.Minutes < t2.Minutes)
                        {
                            pnImg1.Visible = false;    //Validação dos minutos
                            pnImg2.Visible = true;
                            pnImg3.Visible = false;
                            pnImg4.Visible = false;
                            pbPag1.Image = Properties.Resources.Verificado_evento;
                            pbPag2.Image = Properties.Resources.Verificado_evento;
                            pbPag3.Image = Properties.Resources._3_evento1;
                            pbPag4.Image = Properties.Resources._4_evento1;
                            btSalvar.Visible = false;
                        }
                        else
                        {
                            Mensagem.aviso = "Horário inicial não pode ser maior nem igual ao final!";
                            TelaMensagemAviso f2 = new TelaMensagemAviso();
                            f2.ShowDialog();
                        }
                    }
                    else
                    {
                        Mensagem.aviso = "Horário inicial não pode ser maior nem igual ao final!";
                        TelaMensagemAviso f2 = new TelaMensagemAviso();
                        f2.ShowDialog();
                    }
                }
            }
            catch (Exception)
            {
                Mensagem.aviso = "Insira um horário válido!";
                TelaMensagemAviso f2 = new TelaMensagemAviso();
                f2.ShowDialog();
            }
        }

        private void pbPag3_Click(object sender, EventArgs e)
        {
            if (txtVagaProp.Text != "" && txtArea.Text != "" && txtSalario.Text != "" && cbTurno.Text != "" &&
            txtHorarioInicial.Text != "" && txtHorarioFinal.Text != "" && txtTelefone.Text != "" && cbTipoEmprego.Text != "" &&
            txtInicioEvento.Text != "" && txtFinalEvento.Text != "" && txtRua.Text != "" && txtNumero.Text != ""
            && txtBairro.Text != "" && txtCidade.Text != "" && cbEstado.Text != "" && txtCEP.Text != "")
            {
                pbPag1.Image = Properties.Resources.Verificado_evento;
                pbPag2.Image = Properties.Resources.Verificado_evento;
                pbPag3.Image = Properties.Resources.Verificado_evento;
                pbPag4.Image = Properties.Resources._4_evento1;
                btSalvar.Visible = false;
                pnImg1.Visible = false;
                pnImg2.Visible = false;                                       //Click Pagina 3
                pnImg3.Visible = true;
                pnImg4.Visible = false;
                testePassou = true;
            }
            else
            {
                Mensagem.aviso = "Preencha todos os campos desta etapa para avançar!";
                TelaMensagemAviso f2 = new TelaMensagemAviso();
                f2.ShowDialog();
            }
        }

        private void pbPag4_Click(object sender, EventArgs e)
        {
            if (txtVagaProp.Text != "" && txtArea.Text != "" && txtSalario.Text != "" && cbTurno.Text != "" &&
           txtHorarioInicial.Text != "" && txtHorarioFinal.Text != "" && txtTelefone.Text != "" && cbTipoEmprego.Text != "" &&
           txtInicioEvento.Text != "" && txtFinalEvento.Text != "" && txtRua.Text != "" && txtNumero.Text != ""
           && txtBairro.Text != "" && txtCidade.Text != "" && cbEstado.Text != "" && txtCEP.Text != "" && testePassou == true)
            {
                pnImg1.Visible = false;
                pnImg2.Visible = false;
                pnImg3.Visible = false;
                pnImg4.Visible = true;
                EditarEvento.passou = true;

                pbPag1.Image = Properties.Resources.Verificado_evento;
                pbPag2.Image = Properties.Resources.Verificado_evento;
                pbPag3.Image = Properties.Resources.Verificado_evento;
                pbPag4.Image = Properties.Resources.Verificado_evento;         //Click Pagina 4
                btSalvar.Visible = true;

                if (testePassou2 == false)
                {
                    try
                    {
                        if (EditarEvento.ID == 0)
                        {
                            evento add = new evento();     //Adiciona um novo Evento

                            //----------------------------------

                            testePassou2 = true;  // já passou 

                            add.vagaEvento = txtVagaProp.Text;
                            add.areaEvento = txtArea.Text;
                            realSalario = txtSalario.Text.Replace(".", "");
                            realSalario = realSalario.Replace("R$:", "");
                            add.salario = Convert.ToDouble(realSalario);
                            add.turno = cbTurno.Text;

                            var horarioInicial = TimeSpan.Parse(txtHorarioInicial.Text);
                            add.horarioInicialExpedienteEvento = horarioInicial;              //Página 1
                            var horarioFinal = TimeSpan.Parse(txtHorarioFinal.Text);
                            add.horarioFinalExpedienteEvento = horarioFinal;

                            var dataInicial = Convert.ToDateTime(txtInicioEvento.Text).ToString("dd/MM/yyyy");
                            add.dataInicialEvento = Convert.ToDateTime(dataInicial);
                            var dataFinal = Convert.ToDateTime(txtFinalEvento.Text).ToString("dd/MM/yyyy");
                            add.dataFinalEvento = Convert.ToDateTime(dataFinal);

                            add.telefoneEvento = txtTelefone.Text;
                            add.tipoEmprego = cbTipoEmprego.Text;

                            //---------------------------------

                            add.ruaEvento = txtRua.Text;
                            add.numeroEvento = txtNumero.Text;
                            add.bairroEvento = txtBairro.Text;
                            add.cidadeEvento = txtCidade.Text;        //Página 2
                            add.estadoEvento = cbEstado.Text;
                            add.cepEvento = txtCEP.Text;

                            //---------------------------------

                            var usuarioEmp = bd.usuario_empresa.Where(x => x.FK_usuario == UsuarioDados.Id).FirstOrDefault();

                            add.FK_usuario_empresa = usuarioEmp.cnpj; // FK evento

                            bd.evento.Add(add);                                                           //Página 3
                            bd.SaveChanges();

                            var FK = bd.evento.Where(x => x.FK_usuario_empresa == usuarioEmp.cnpj).Max(x => x.idEvento);

                            PegarIDEvento.IDEvento = FK; //Armazena o FK evento

                            beneficios beneficio = new beneficios(); //Adiciona beneficios

                            if (saude == true)
                            {
                                beneficio.assistenciaSaude = true;                    //Adiciona Beneficio Saude
                            }
                            else
                            {
                                beneficio.assistenciaSaude = false;
                            }
                            if (odon == true)
                            {
                                beneficio.assistenciaOdontologica = true;             //Adiciona Beneficio Odontologico
                            }
                            else
                            {
                                beneficio.assistenciaOdontologica = false;
                            }
                            if (alim == true)
                            {
                                beneficio.valeAlimentacao = true;                    //Adiciona beneficio Alimentacao
                            }
                            else
                            {
                                beneficio.valeAlimentacao = false;
                            }
                            if (cultura == true)
                            {
                                beneficio.valeCultura = true;                       //Adiciona beneficio vale cultura
                            }
                            else
                            {
                                beneficio.valeCultura = false;
                            }
                            if (home == true)
                            {
                                beneficio.trabalhoHomeOffice = true;               //Adiciona beneficio home office
                            }
                            else
                            {
                                beneficio.trabalhoHomeOffice = false;
                            }
                            if (viagem == true)
                            {
                                beneficio.valeViagem = true;                      //Adiciona beneficio Vale viagem
                            }
                            else
                            {
                                beneficio.valeViagem = false;
                            }
                            if (convivencia == true)
                            {
                                beneficio.salasDeConferencias = true;              //Adiciona beneficio sala de convivencia
                            }
                            else
                            {
                                beneficio.salasDeConferencias = false;
                            }
                            if (bolsa == true)
                            {
                                beneficio.bolsasDeEstudos = true;                 //Adiciona beneficio bolsa de estudos
                            }
                            else
                            {
                                beneficio.bolsasDeEstudos = false;
                            }

                            beneficio.FK_evento = PegarIDEvento.IDEvento;

                            bd.beneficios.Add(beneficio);
                            bd.SaveChanges();
                        }
                    }
                    catch (Exception)
                    {
                        Mensagem.aviso = "Erro ao cadastrar evento!";
                        TelaMensagemAviso f2 = new TelaMensagemAviso();
                        f2.ShowDialog();

                        this.Hide();
                        TelaPrincipalEmpresa f = new TelaPrincipalEmpresa();
                        f.Closed += (s, args) => this.Close();                    //Volta para tela principal
                        f.ShowDialog();
                    }
                }
                else
                {
                    try
                    {
                        if (EditarEvento.ID == 0)
                        {
                            var evento = bd.evento.Where(x => x.idEvento == PegarIDEvento.IDEvento).ToList();

                            if (evento != null)
                            {
                                evento.ForEach(x =>
                                {                                                   //Salva o evento 
                                    x.vagaEvento = txtVagaProp.Text;
                                    x.areaEvento = txtArea.Text;
                                    realSalario = txtSalario.Text.Replace(".", "");
                                    realSalario = realSalario.Replace("R$:", "");
                                    x.salario = Convert.ToDouble(realSalario);
                                    x.turno = cbTurno.Text;
                                    var horarioInicial = TimeSpan.Parse(txtHorarioInicial.Text);
                                    x.horarioInicialExpedienteEvento = horarioInicial;
                                    var horarioFinal = TimeSpan.Parse(txtHorarioFinal.Text);
                                    x.horarioFinalExpedienteEvento = horarioFinal;
                                    x.telefoneEvento = txtTelefone.Text;
                                    x.tipoEmprego = cbTipoEmprego.Text;
                                    var dataInicial = Convert.ToDateTime(txtInicioEvento.Text).ToString("dd/MM/yyyy");
                                    x.dataInicialEvento = Convert.ToDateTime(dataInicial);
                                    var dataFinal = Convert.ToDateTime(txtFinalEvento.Text).ToString("dd/MM/yyyy");
                                    x.dataFinalEvento = Convert.ToDateTime(dataFinal);

                                    x.ruaEvento = txtRua.Text;
                                    x.numeroEvento = txtNumero.Text;
                                    x.bairroEvento = txtBairro.Text;
                                    x.cidadeEvento = txtCidade.Text;
                                    x.estadoEvento = cbEstado.Text;
                                    x.cepEvento = txtCEP.Text;
                                });
                                bd.SaveChanges();

                                var beneficio = bd.beneficios.Where(x => x.FK_evento == PegarIDEvento.IDEvento).ToList();

                                if (beneficio != null)
                                {
                                    beneficio.ForEach(x =>
                                    {
                                        if (saude == true)
                                        {
                                            x.assistenciaSaude = true;                    //Adiciona Beneficio Saude
                                        }
                                        else
                                        {
                                            x.assistenciaSaude = false;
                                        }
                                        if (odon == true)
                                        {
                                            x.assistenciaOdontologica = true;             //Adiciona Beneficio Odontologico
                                        }
                                        else
                                        {
                                            x.assistenciaOdontologica = false;
                                        }
                                        if (alim == true)
                                        {
                                            x.valeAlimentacao = true;                    //Adiciona beneficio Alimentacao
                                        }
                                        else
                                        {
                                            x.valeAlimentacao = false;
                                        }
                                        if (cultura == true)
                                        {
                                            x.valeCultura = true;                       //Adiciona beneficio vale cultura
                                        }
                                        else
                                        {
                                            x.valeCultura = false;
                                        }
                                        if (home == true)
                                        {
                                            x.trabalhoHomeOffice = true;               //Adiciona beneficio home office
                                        }
                                        else
                                        {
                                            x.trabalhoHomeOffice = false;
                                        }
                                        if (viagem == true)
                                        {
                                            x.valeViagem = true;                      //Adiciona beneficio Vale viagem
                                        }
                                        else
                                        {
                                            x.valeViagem = false;
                                        }
                                        if (convivencia == true)
                                        {
                                            x.salasDeConferencias = true;              //Adiciona beneficio sala de convivencia
                                        }
                                        else
                                        {
                                            x.salasDeConferencias = false;
                                        }
                                        if (bolsa == true)
                                        {
                                            x.bolsasDeEstudos = true;                 //Adiciona beneficio bolsa de estudos
                                        }
                                        else
                                        {
                                            x.bolsasDeEstudos = false;
                                        }
                                    });
                                    bd.SaveChanges();
                                }
                            }
                        }
                    }
                    catch (Exception)
                    {
                        Mensagem.aviso = "Erro ao cadastrar evento!";
                        TelaMensagemAviso f2 = new TelaMensagemAviso();
                        f2.ShowDialog();

                        this.Hide();
                        TelaPrincipalEmpresa f = new TelaPrincipalEmpresa();
                        f.Closed += (s, args) => this.Close();                    //Volta para tela principal
                        f.ShowDialog();
                    }
                }
            }
            else
            {
                Mensagem.aviso = "Preencha todos os campos desta etapa para avançar!";
                TelaMensagemAviso f2 = new TelaMensagemAviso();
                f2.ShowDialog();
            }
        }

        private void txtHorarioInicial_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8) { e.Handled = true; }

            if (char.IsNumber(e.KeyChar) == true)
            {
                switch (txtHorarioInicial.TextLength)
                {
                    case 0:
                        txtHorarioInicial.Text = "";                        //Mascara horário inicial do evento
                        break;

                    case 2:
                        txtHorarioInicial.Text = txtHorarioInicial.Text + ":";
                        txtHorarioInicial.SelectionStart = 3;
                        break;
                }
            }
        }

        private void txtHorarioFinal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8) { e.Handled = true; }

            if (char.IsNumber(e.KeyChar) == true)
            {
                switch (txtHorarioFinal.TextLength)
                {
                    case 0:
                        txtHorarioFinal.Text = "";                        //Mascara horário final do evento
                        break;

                    case 2:
                        txtHorarioFinal.Text = txtHorarioFinal.Text + ":";
                        txtHorarioFinal.SelectionStart = 3;
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

        private void txtInicioEvento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8) { e.Handled = true; }

            if (char.IsNumber(e.KeyChar) == true)
            {
                switch (txtInicioEvento.TextLength)
                {
                    case 0:
                        txtInicioEvento.Text = "";
                        break;

                    case 2:
                        txtInicioEvento.Text = txtInicioEvento.Text + "/";        //Mascara data de inicio do evento
                        txtInicioEvento.SelectionStart = 3;
                        break;

                    case 5:
                        txtInicioEvento.Text = txtInicioEvento.Text + "/";
                        txtInicioEvento.SelectionStart = 6;
                        break;

                    case 8:
                        txtInicioEvento.Text = txtInicioEvento.Text + "";
                        txtInicioEvento.SelectionStart = 10;
                        break;
                }
            }
        }

        private void txtFinalEvento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8) { e.Handled = true; }

            if (char.IsNumber(e.KeyChar) == true)
            {
                switch (txtFinalEvento.TextLength)
                {
                    case 0:
                        txtFinalEvento.Text = "";
                        break;

                    case 2:
                        txtFinalEvento.Text = txtFinalEvento.Text + "/";        //Mascara data de final do evento
                        txtFinalEvento.SelectionStart = 3;
                        break;

                    case 5:
                        txtFinalEvento.Text = txtFinalEvento.Text + "/";
                        txtFinalEvento.SelectionStart = 6;
                        break;

                    case 8:
                        txtFinalEvento.Text = txtFinalEvento.Text + "";
                        txtFinalEvento.SelectionStart = 10;
                        break;
                }
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

        private void pbIdioma_MouseEnter(object sender, EventArgs e)
        {
            pbIdioma.Image = Properties.Resources.visaoRoxo1;
        }

        private void pbIdioma_MouseLeave(object sender, EventArgs e)
        {
            pbIdioma.Image = Properties.Resources.visao;
        }

        private void pbExperiencia_MouseEnter(object sender, EventArgs e)
        {
            pbExperiencia.Image = Properties.Resources.visaoRoxo1;
        }

        private void pbExperiencia_MouseLeave(object sender, EventArgs e)
        {
            pbExperiencia.Image = Properties.Resources.visao;
        }

        private void pbExperienciaInt_MouseEnter(object sender, EventArgs e)
        {
            pbExperienciaInt.Image = Properties.Resources.visaoRoxo1;                  //Animação dos botões 
        }

        private void pbExperienciaInt_MouseLeave(object sender, EventArgs e)
        {
            pbExperienciaInt.Image = Properties.Resources.visao;
        }

        private void pbQualificacao_MouseEnter(object sender, EventArgs e)
        {
            pbQualificacao.Image = Properties.Resources.visaoRoxo1;
        }

        private void pbQualificacao_MouseLeave(object sender, EventArgs e)
        {
            pbQualificacao.Image = Properties.Resources.visao;
        }

        private void txtSalario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                txtSalario.Clear();             //Limpar campo 
            }
            else if (e.KeyCode == Keys.Back)
            {
                txtSalario.Clear();
            }
        }

        private void txtHorarioInicial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                txtHorarioInicial.Clear();             //Limpar campo 
            }
            else if (e.KeyCode == Keys.Back)
            {
                txtHorarioInicial.Clear();
            }
        }

        private void txtHorarioFinal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                txtHorarioFinal.Clear();             //Limpar campo 
            }
            else if (e.KeyCode == Keys.Back)
            {
                txtHorarioFinal.Clear();
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

        private void txtInicioEvento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                txtInicioEvento.Clear();             //Limpar campo 
            }
            else if (e.KeyCode == Keys.Back)
            {
                txtInicioEvento.Clear();
            }
        }

        private void txtFinalEvento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                txtFinalEvento.Clear();             //Limpar campo 
            }
            else if (e.KeyCode == Keys.Back)
            {
                txtFinalEvento.Clear();
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

        private void btSalvar_Click(object sender, EventArgs e)
        {
            if (EditarEvento.ID == 0)
            {
                Mensagem.aviso = "Evento cadastrado com sucesso!";
                TelaMensagemAviso f2 = new TelaMensagemAviso();
                f2.ShowDialog();

                this.Hide();
                TelaPrincipalEmpresa f3 = new TelaPrincipalEmpresa();
                f3.Closed += (s, args) => this.Close();                    //Volta para tela principal
                f3.ShowDialog();
            }
            else
            {
                try
                {
                    var evento = bd.evento.Where(x => x.idEvento == EditarEvento.ID).ToList();

                    if (evento != null)
                    {
                        evento.ForEach(x =>
                        {                                                   //Salva o evento 
                            x.vagaEvento = txtVagaProp.Text;
                            x.areaEvento = txtArea.Text;
                            realSalario = txtSalario.Text.Replace(".", "");
                            realSalario = realSalario.Replace("R$:", "");
                            x.salario = Convert.ToDouble(realSalario);
                            x.turno = cbTurno.Text;
                            var horarioInicial = TimeSpan.Parse(txtHorarioInicial.Text);
                            x.horarioInicialExpedienteEvento = horarioInicial;
                            var horarioFinal = TimeSpan.Parse(txtHorarioFinal.Text);
                            x.horarioFinalExpedienteEvento = horarioFinal;
                            x.telefoneEvento = txtTelefone.Text;
                            x.tipoEmprego = cbTipoEmprego.Text;
                            var dataInicial = Convert.ToDateTime(txtInicioEvento.Text).ToString("dd/MM/yyyy");
                            x.dataInicialEvento = Convert.ToDateTime(dataInicial);
                            var dataFinal = Convert.ToDateTime(txtFinalEvento.Text).ToString("dd/MM/yyyy");
                            x.dataFinalEvento = Convert.ToDateTime(dataFinal);

                            x.ruaEvento = txtRua.Text;
                            x.numeroEvento = txtNumero.Text;
                            x.bairroEvento = txtBairro.Text;
                            x.cidadeEvento = txtCidade.Text;
                            x.estadoEvento = cbEstado.Text;
                            x.cepEvento = txtCEP.Text;
                        });
                        bd.SaveChanges();

                        var beneficio = bd.beneficios.Where(x => x.FK_evento == EditarEvento.ID).ToList();

                        if (beneficio != null)
                        {
                            beneficio.ForEach(x =>
                            {
                                if (saude == true)
                                {
                                    x.assistenciaSaude = true;                    //Adiciona Beneficio Saude
                                }
                                else
                                {
                                    x.assistenciaSaude = false;
                                }
                                if (odon == true)
                                {
                                    x.assistenciaOdontologica = true;             //Adiciona Beneficio Odontologico
                                }
                                else
                                {
                                    x.assistenciaOdontologica = false;
                                }
                                if (alim == true)
                                {
                                    x.valeAlimentacao = true;                    //Adiciona beneficio Alimentacao
                                }
                                else
                                {
                                    x.valeAlimentacao = false;
                                }
                                if (cultura == true)
                                {
                                    x.valeCultura = true;                       //Adiciona beneficio vale cultura
                                }
                                else
                                {
                                    x.valeCultura = false;
                                }
                                if (home == true)
                                {
                                    x.trabalhoHomeOffice = true;               //Adiciona beneficio home office
                                }
                                else
                                {
                                    x.trabalhoHomeOffice = false;
                                }
                                if (viagem == true)
                                {
                                    x.valeViagem = true;                      //Adiciona beneficio Vale viagem
                                }
                                else
                                {
                                    x.valeViagem = false;
                                }
                                if (convivencia == true)
                                {
                                    x.salasDeConferencias = true;              //Adiciona beneficio sala de convivencia
                                }
                                else
                                {
                                    x.salasDeConferencias = false;
                                }
                                if (bolsa == true)
                                {
                                    x.bolsasDeEstudos = true;                 //Adiciona beneficio bolsa de estudos
                                }
                                else
                                {
                                    x.bolsasDeEstudos = false;
                                }
                            });
                            bd.SaveChanges();
                        }

                        Mensagem.aviso = "Evento editado com sucesso!";
                        TelaMensagemAviso f2 = new TelaMensagemAviso();
                        f2.ShowDialog();

                        this.Hide();
                        TelaEventosCriados f3 = new TelaEventosCriados();
                        f3.Closed += (s, args) => this.Close();                    //Volta para eventos criados
                        f3.ShowDialog();
                    }
                }
                catch (Exception)
                {
                    Mensagem.aviso = "Erro ao editar evento!";
                    TelaMensagemAviso f2 = new TelaMensagemAviso();
                    f2.ShowDialog();

                    this.Hide();
                    TelaEventosCriados f3 = new TelaEventosCriados();
                    f3.Closed += (s, args) => this.Close();                    //Volta para eventos criados
                    f3.ShowDialog();
                }
            }
            EditarEvento.ID = 0;
        }

        private void pbIdioma_Click(object sender, EventArgs e)
        {
            TelaVisualizarIdiomaEvento f = new TelaVisualizarIdiomaEvento();      //Abre a tela de visualização
            f.ShowDialog();
        }

        private void btIdioma_Click(object sender, EventArgs e)
        {
            int FK = 0;

            if (EditarEvento.ID != 0)
            {
                FK = EditarEvento.ID;
            }
            else
            {
                FK = PegarIDEvento.IDEvento;
            }

            if (txtIdioma.Text != "" && cbNivel.Text != "")
            {
                idioma_evento f = new idioma_evento();
                f.linguaEvento = txtIdioma.Text;
                f.nivelEvento = cbNivel.Text;                  //Adicionar idioma 
                f.FK_evento = FK;

                bd.idioma_evento.Add(f);
                bd.SaveChanges();

                txtIdioma.Clear();
                cbNivel.Items.Clear();
                cbNivel.Items.Add("Básico");
                cbNivel.Items.Add("Intermediário");  //Limpa a lista e add novamente
                cbNivel.Items.Add("Avançado");

                Mensagem.aviso = "Idioma cadastrado com sucesso!";
                TelaMensagemAviso f2 = new TelaMensagemAviso();
                f2.ShowDialog();
            }
            else
            {
                Mensagem.aviso = "Preencha as informações!";
                TelaMensagemAviso f2 = new TelaMensagemAviso();
                f2.ShowDialog();
            }
        }

        private void pbExperiencia_Click(object sender, EventArgs e)
        {
            TelaVisualizarExperienciaProfissionalEvento f = new TelaVisualizarExperienciaProfissionalEvento();
            f.ShowDialog();                                           //Abre a tela de visualização 
        }

        private void btExperiencia_Click(object sender, EventArgs e)
        {
            int FK = 0;

            if (EditarEvento.ID != 0)
            {
                FK = EditarEvento.ID;
            }
            else
            {
                FK = PegarIDEvento.IDEvento;
            }

            if (txtCargoProf.Text != "")
            {
                experiencia_profissional_evento f = new experiencia_profissional_evento();
                f.cargoExperienciaEvento = txtCargoProf.Text;
                f.FK_evento = FK;                 //Adicionar experiencia profissional

                bd.experiencia_profissional_evento.Add(f);
                bd.SaveChanges();

                Mensagem.aviso = "Experiência profissional cadastrado com sucesso!";
                TelaMensagemAviso f2 = new TelaMensagemAviso();
                f2.ShowDialog();

                txtCargoProf.Clear();
            }
            else
            {
                Mensagem.aviso = "Preencha as informações!";
                TelaMensagemAviso f2 = new TelaMensagemAviso();
                f2.ShowDialog();
            }
        }

        private void pbExperienciaInt_Click(object sender, EventArgs e)
        {
            TelaVisualizarExperienciaInternacionalEvento f = new TelaVisualizarExperienciaInternacionalEvento();    //Abre a tela de visualização
            f.ShowDialog();
        }

        private void btExperienciaInt_Click(object sender, EventArgs e)
        {
            int FK = 0;

            if (EditarEvento.ID != 0)
            {
                FK = EditarEvento.ID;
            }
            else
            {
                FK = PegarIDEvento.IDEvento;
            }

            if (txtCargoInt.Text != "" && txtExpPais.Text != "")
            {
                experiencia_internacional_evento f = new experiencia_internacional_evento();
                f.cargoInternacionalEvento = txtCargoInt.Text;
                f.paisCargoInternacionalEvento = txtExpPais.Text;    //Adicionar experiencia internacional
                f.FK_evento = FK;

                bd.experiencia_internacional_evento.Add(f);
                bd.SaveChanges();

                Mensagem.aviso = "Experiência internacional cadastrado com sucesso!";
                TelaMensagemAviso f2 = new TelaMensagemAviso();
                f2.ShowDialog();

                txtCargoInt.Clear();
                txtExpPais.Clear();
            }
            else
            {
                Mensagem.aviso = "Preencha as informações!";
                TelaMensagemAviso f2 = new TelaMensagemAviso();
                f2.ShowDialog();
            }
        }

        private void pbQualificacao_Click(object sender, EventArgs e)
        {
            TelaVisualizarQualificacaoEvento f = new TelaVisualizarQualificacaoEvento();           //Abre a tela de visualização
            f.ShowDialog();
        }

        private void btQualificacao_Click(object sender, EventArgs e)
        {
            int FK = 0;

            if (EditarEvento.ID != 0)
            {
                FK = EditarEvento.ID;
            }
            else
            {
                FK = PegarIDEvento.IDEvento;
            }

            if (txtQuaNome.Text != "" && txtQuaTipo.Text != "")
            {
                qualificacao_evento f = new qualificacao_evento();
                f.nomeQualificacaoEvento = txtQuaNome.Text;
                f.tipoQualificacaoEvento = txtQuaTipo.Text;         //Adicionar qualificacao
                f.FK_evento = FK;

                bd.qualificacao_evento.Add(f);
                bd.SaveChanges();

                Mensagem.aviso = "Qualificação cadastrado com sucesso!";
                TelaMensagemAviso f2 = new TelaMensagemAviso();
                f2.ShowDialog();

                txtQuaNome.Clear();
                txtQuaTipo.Clear();
            }
            else
            {
                Mensagem.aviso = "Preencha as informações!";
                TelaMensagemAviso f2 = new TelaMensagemAviso();
                f2.ShowDialog();
            }
        }

        private void txtSalario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8) { e.Handled = true; }

            if (char.IsNumber(e.KeyChar) == true)
            {
                switch (txtSalario.TextLength)
                {
                    case 0:                                                                //Máscara de salário
                        txtSalario.Text = "R$:" + txtSalario.Text + ",00";
                        txtSalario.SelectionStart = 3;
                        break;

                    case 7:
                        txtSalario.SelectionStart = 4;
                        break;

                    case 8:
                        txtSalario.SelectionStart = 5;
                        break;

                    case 9:
                        txtSalario.Text = txtSalario.Text.Insert(4, ".");
                        txtSalario.SelectionStart = 7;
                        break;

                    case 11:
                        txtSalario.Text = txtSalario.Text.Remove(4, 1);
                        txtSalario.Text = txtSalario.Text.Insert(5, ".");
                        txtSalario.Text = txtSalario.Text.Remove(8, 3);
                        txtSalario.Text = txtSalario.Text + ",00";
                        txtSalario.SelectionStart = 8;
                        break;

                    case 12:
                        txtSalario.Text = txtSalario.Text.Remove(5, 1);
                        txtSalario.Text = txtSalario.Text.Insert(6, ".");
                        txtSalario.Text = txtSalario.Text.Remove(9, 3);
                        txtSalario.Text = txtSalario.Text + ",00";
                        txtSalario.SelectionStart = 9;
                        break;

                    case 13:
                        txtSalario.Text = txtSalario.Text.Insert(4, ".");
                        txtSalario.Text = txtSalario.Text.Remove(7, 1);
                        txtSalario.Text = txtSalario.Text.Insert(8, ".");
                        txtSalario.Text = txtSalario.Text.Remove(11, 3);
                        txtSalario.Text = txtSalario.Text + ",00";
                        txtSalario.SelectionStart = 11;
                        break;
                }
            }
        }
    }
}

