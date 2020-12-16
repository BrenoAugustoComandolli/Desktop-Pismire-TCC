using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Pismire_TCC.Resources;
using System.IO;

namespace Pismire_TCC
{
    public partial class TelaPrincipalEmpresa : Form
    {
        DateTime dataAtual = (DateTime.Today).Date;
        PismireEntities5 bd = new PismireEntities5();                

        int indice = 0;
        int indice2 = 0;                  
        int indice3 = 0;
        int indice4 = 0;

        bool bloqCad = false;
        bool bloqInt = false;
        bool bloqEve = false;
        bool bloqNot = false;
        bool bloqChat = false;
        bool bloqConf = false;
        bool bloqAva = false;

        public TelaPrincipalEmpresa()
        {
            InitializeComponent();

            try
            {
                if (!TesteTutorial.entrou)
                {
                    TesteTutorial.instrucao = false;  
                    bloquearComandos();
                    pbTutorial1.Visible = true;
                    pbBemVindo.Visible = true;        //Primeira parte do tutorial
                    lblBemvindo.Visible = true;  
                }
                else if (!TesteTutorial.instrucao)
                {
                    bloquearComandos();                    
                    pbTutorial1.Visible = false;
                    pbBemVindo.Visible = true;
                    lblBemvindo.Visible = true;
                    lblBemvindo.Text = "Algumas dicas para você";    //Segunda parte do tutorial
                    lblBemvindo.Location = new Point(725, 292);
                    pbBemVindo.Location = new Point(850, 400);
                    pbTutorial3.Visible = true;
                    pbAbMenu.Enabled = false;
                }

                Maximizacao.verifique(this, pbMaximizar);   //Verifica se a tela está maximizada ou não

                if (TesteTutorial.entrou && TesteTutorial.instrucao)
                {
                    DateTime dataAtual2 = (DateTime.Today).Date;

                    if (dataAtual2.Day == 5 || dataAtual2.Day == 10 || dataAtual2.Day == 15
                    || dataAtual2.Day == 20 || dataAtual2.Day == 25 || dataAtual2.Day == 30)
                    {
                        var empresa2 = bd.usuario_empresa.Where(x => x.FK_usuario == UsuarioDados.Id).FirstOrDefault();
                        var recomendados = bd.recomendados_empresa.Where(x => x.IdRecomendadosEmpresa != 0).FirstOrDefault();

                        if (recomendados != null)
                        {
                            int max = bd.recomendados_empresa.Max(x => x.IdRecomendadosEmpresa);  //Remoção automática de recomendados

                            for (int i = 1; i <= max; i++)
                            {
                                var recomendados2 = bd.recomendados_empresa.Where(x => x.FK_usuario_empresa == empresa2.cnpj).
                                Where(x => x.IdRecomendadosEmpresa == i).FirstOrDefault();

                                if (recomendados2 != null)
                                {
                                    bd.recomendados_empresa.Remove(recomendados2);
                                    bd.SaveChanges();
                                }
                            }
                        }
                    }
                    carregarRecomendados();
                }

                pbCriar.Click += evento;
                btPerfil.Click += perfil;
                btCandidatos.Click += candidatos;
                btInteresse.Click += interesses;            //Botões do menu 
                btEventos.Click += eventoscriados;
                btNotificacoes.Click += notificacoes;
                btChat.Click += chat;
                btConf.Click += configuracoes;
                btAvaliacao.Click += avaliacao;
                btSair.Click += sair;
            }
            catch (Exception)
            {
                Mensagem.aviso = "Erro ao conectar o banco";     //Erro de conexão 
                TelaMensagemAviso f = new TelaMensagemAviso();
                f.ShowDialog();
            }
        }

        public void nenhumRecomendado()
        {
            pnVazio.Visible = true;
            pnVazio2.Visible = true;         //Visualização de nenhum recomendado
            pnVazio3.Visible = true;
            pnVazio4.Visible = true;
        }

        public void carregarRecomendados()
        {
            try
            {
                var preferencias = bd.preferencia.Where(x => x.FK_usuario == UsuarioDados.Id).FirstOrDefault();

                if (preferencias.receberRecomendacoes == true)
                {
                    try          //Verificação de erros 
                    {
                        int id = UsuarioDados.Id;    //ID do usuário

                        var empresa = bd.usuario_empresa.Where         //Dados do usuario_empresa
                        (x => x.FK_usuario == id).FirstOrDefault();

                        var curr = bd.curriculo.Where(x => x.idCurriculo != 0).FirstOrDefault();
                        if (curr == null)
                        {
                            nenhumRecomendado();
                        }
                        else
                        {
                            var eventoTeste = bd.evento.Where(x => x.idEvento != 0).
                            Where(x => x.dataFinalEvento >= dataAtual).FirstOrDefault();

                            if (eventoTeste != null)
                            {
                                int max = bd.curriculo.Max(x => x.idCurriculo); //Pega o último evento

                                var eventoTeste2 = bd.evento.Where(y => y.FK_usuario_empresa == empresa.cnpj).
                                    Where(x => x.idEvento > 0).Where(x => x.dataFinalEvento >= dataAtual).FirstOrDefault();

                                if (eventoTeste2 != null)
                                {
                                    int maxEvento = bd.evento.Where(y => y.
                                    FK_usuario_empresa == empresa.cnpj).Where(x => x.dataFinalEvento >= dataAtual)
                                    .Max(x => x.idEvento);    //Maior evento 

                                    if (maxEvento != 0)
                                    {
                                        var evento = bd.evento.Where(y => y.idEvento == maxEvento).FirstOrDefault();   //Acha o último evento da empresa
                                        List<int> recomendados = new List<int>();  //Cria a lista de recomendados 

                                        for (int i = 1; i <= max; i++)  //Percorre do primeiro ao último currículo
                                        {
                                            var curriculo = bd.curriculo.Where(x => x.areaAtuacao.Contains(evento.areaEvento)).
                                            Where(y => y.estadoTrabalhador.Contains(evento.estadoEvento)).     //Bateria de verificação 
                                            Where(x => x.cargoAtuacao.Contains(evento.vagaEvento)).Where(x => x.idCurriculo == i).FirstOrDefault();

                                            if (curriculo != null)    //verifica se a bateria está certa
                                            {
                                                recomendados.Add(curriculo.idCurriculo);
                                            }
                                        }

                                        Random rand = new Random();
                                        List<int> aleatorios = new List<int>();

                                        if (recomendados.Count >= 4)
                                        {
                                            while (aleatorios.Count < 4)
                                            {
                                                int teste = rand.Next(0, recomendados.Count);

                                                if (aleatorios.IndexOf(teste) < 0)
                                                {                                               //Recomendados chamada 1
                                                    aleatorios.Add(teste);
                                                }
                                            }

                                            indice = recomendados[aleatorios[0]];
                                            indice2 = recomendados[aleatorios[1]];
                                            indice3 = recomendados[aleatorios[2]];
                                            indice4 = recomendados[aleatorios[3]];
                                        }
                                        else
                                        {
                                            if (recomendados.Count == 1)
                                            {
                                                indice = recomendados[0];
                                            }
                                            else if (recomendados.Count == 2)
                                            {
                                                indice = recomendados[0];
                                                indice2 = recomendados[1];
                                            }
                                            else if (recomendados.Count == 3)
                                            {
                                                indice = recomendados[0];
                                                indice2 = recomendados[1];                 //Verifica se há algum recomendado  
                                                indice3 = recomendados[2];
                                            }
                                            else
                                            {
                                                for (int i = 0; i <= max; i++)
                                                {
                                                    var rec = bd.curriculo.Where(x => x.idCurriculo == i).FirstOrDefault();

                                                    if (rec != null)
                                                    {                                            //Adiiona todos os currículos a lista 
                                                        recomendados.Add(rec.idCurriculo);
                                                    }
                                                }

                                                if (recomendados.Count >= 4)
                                                {
                                                    while (aleatorios.Count < 4)
                                                    {
                                                        int teste = rand.Next(0, recomendados.Count);

                                                        if (aleatorios.IndexOf(teste) < 0)
                                                        {                                               //Recomendados aleatórios 4
                                                            aleatorios.Add(teste);
                                                        }
                                                    }

                                                    indice = recomendados[aleatorios[0]];
                                                    indice2 = recomendados[aleatorios[1]];
                                                    indice3 = recomendados[aleatorios[2]];
                                                    indice4 = recomendados[aleatorios[3]];
                                                }
                                                else if (recomendados.Count == 3)
                                                {
                                                    indice = recomendados[0];
                                                    indice2 = recomendados[1];           //Recomendados aleatórios 3
                                                    indice3 = recomendados[2];
                                                }
                                                else if (recomendados.Count == 2)
                                                {
                                                    indice = recomendados[0];
                                                    indice2 = recomendados[1];                  //Recomendados aleatórios 2 
                                                }
                                                else
                                                {
                                                    indice = recomendados[0];           //Recomendados aleatórios 1
                                                }
                                            }
                                        }

                                        if (indice != 0)
                                        {
                                            //Recomendados 1
                                            var rec1 = bd.curriculo.Where(x => x.idCurriculo == indice).FirstOrDefault();

                                            var usuarioTrabalhador = bd.usuario_trabalhador.
                                            Where(x => x.CPF == rec1.FK_usuario_trabalhador).FirstOrDefault();
                                            var usuario = bd.usuario.Where(x => x.idUsuario == usuarioTrabalhador.FK_usuario)
                                            .FirstOrDefault();
                                            var idioma = bd.idioma_trabalhador.Where(x => x.FK_curriculo == rec1.idCurriculo)
                                            .FirstOrDefault();
                                            var qualificacao = bd.qualificacao_trabalhador.Where(x => x.FK_curriculo ==
                                            rec1.idCurriculo).FirstOrDefault();
                                            var experiencia = bd.experiencia_profissional_trabalhador.
                                            Where(x => x.FK_curriculo == rec1.idCurriculo).FirstOrDefault();

                                            if (idioma != null)
                                            {
                                                lblIdioma.Text = idioma.linguaTrabalhador;
                                            }
                                            else
                                            {
                                                lblIdioma.Text = "Nenhum";
                                            }

                                            if (qualificacao != null)
                                            {
                                                lblQualificacao.Text = qualificacao.nomeQualificacaoTrabalhador;//Mostra terceiro recomendado
                                            }
                                            else
                                            {
                                                lblQualificacao.Text = "Nenhuma";
                                            }

                                            if (experiencia != null)
                                            {
                                                lblExperiencia.Text = experiencia.cargoExperienciaTrabalhador;
                                            }
                                            else
                                            {
                                                lblExperiencia.Text = "Nenhuma";
                                            }

                                            lblNome.Text = usuario.nomeUsuario;     //Mostra primeiro recomendado 
                                            lblCargo.Text = rec1.areaAtuacao;

                                            if (rec1.fotoUsuario != null)
                                            {
                                                byte[] ImageSource = rec1.fotoUsuario;
                                                pbFoto1.Visible = true;
                                                using (MemoryStream stream = new MemoryStream(ImageSource))
                                                {
                                                    pbFoto1.Image = new Bitmap(stream);
                                                }
                                            }
                                            salvarRecomendados(indice);
                                        }
                                        else
                                        {
                                            pnVazio.Visible = true; //Vazio recomendados 1
                                        }

                                        if (indice2 != 0)
                                        {
                                            //Recomendados 2

                                            var rec2 = bd.curriculo.Where(x => x.idCurriculo == indice2).FirstOrDefault();

                                            var usuarioTrabalhador2 = bd.usuario_trabalhador.
                                            Where(x => x.CPF == rec2.FK_usuario_trabalhador).FirstOrDefault();
                                            var usuario2 = bd.usuario.Where(x => x.idUsuario
                                            == usuarioTrabalhador2.FK_usuario).FirstOrDefault();
                                            var idioma2 = bd.idioma_trabalhador.Where(x => x.FK_curriculo 
                                            == rec2.idCurriculo).FirstOrDefault();
                                            var qualificacao2 = bd.qualificacao_trabalhador.Where(x => x.FK_curriculo 
                                            == rec2.idCurriculo).FirstOrDefault();
                                            var experiencia2 = bd.experiencia_profissional_trabalhador.
                                            Where(x => x.FK_curriculo == rec2.idCurriculo).FirstOrDefault();

                                            if (idioma2 != null)
                                            {
                                                lblIdioma2.Text = idioma2.linguaTrabalhador;
                                            }
                                            else
                                            {
                                                lblIdioma2.Text = "Nenhum";
                                            }

                                            if (qualificacao2 != null)
                                            {
                                                lblQualificacao2.Text = qualificacao2.nomeQualificacaoTrabalhador;
                                                //Mostra terceiro recomendado
                                            }
                                            else
                                            {
                                                lblQualificacao2.Text = "Nenhuma";
                                            }

                                            if (experiencia2 != null)
                                            {
                                                lblExperiencia2.Text = experiencia2.cargoExperienciaTrabalhador;
                                            }
                                            else
                                            {
                                                lblExperiencia2.Text = "Nenhuma";
                                            }

                                            lblNome2.Text = usuario2.nomeUsuario;                      //Mostra primeiro recomendado 
                                            lblCargo2.Text = rec2.areaAtuacao;

                                            if (rec2.fotoUsuario != null)
                                            {
                                                byte[] ImageSource = rec2.fotoUsuario;
                                                pbFoto2.Visible = true;
                                                using (MemoryStream stream = new MemoryStream(ImageSource))
                                                {
                                                    pbFoto2.Image = new Bitmap(stream);
                                                }
                                            }
                                            salvarRecomendados(indice2);
                                        }
                                        else
                                        {
                                            pnVazio2.Visible = true; //Vazio recomendados 2
                                        }

                                        if (indice3 != 0)
                                        {
                                            //Recomendados 3

                                            var rec3 = bd.curriculo.Where(x => x.idCurriculo == indice3).FirstOrDefault();

                                            var usuarioTrabalhador3 = bd.usuario_trabalhador.
                                            Where(x => x.CPF == rec3.FK_usuario_trabalhador).FirstOrDefault();
                                            var usuario3 = bd.usuario.Where(x => x.idUsuario == usuarioTrabalhador3.FK_usuario)
                                                .FirstOrDefault();
                                            var idioma3 = bd.idioma_trabalhador.Where(x => x.FK_curriculo == rec3.idCurriculo)
                                                .FirstOrDefault();
                                            var qualificacao3 = bd.qualificacao_trabalhador.Where(x => x.FK_curriculo == 
                                            rec3.idCurriculo).FirstOrDefault();
                                            var experiencia3 = bd.experiencia_profissional_trabalhador.
                                            Where(x => x.FK_curriculo == rec3.idCurriculo).FirstOrDefault();

                                            if (idioma3 != null)
                                            {
                                                lblIdioma3.Text = idioma3.linguaTrabalhador;
                                            }
                                            else
                                            {
                                                lblIdioma3.Text = "Nenhum";
                                            }

                                            if (qualificacao3 != null)
                                            {
                                                lblQualificacao3.Text = qualificacao3.nomeQualificacaoTrabalhador;
                                                //Mostra terceiro recomendado
                                            }
                                            else
                                            {
                                                lblQualificacao3.Text = "Nenhuma";
                                            }

                                            if (experiencia3 != null)
                                            {
                                                lblExperiencia3.Text = experiencia3.cargoExperienciaTrabalhador;
                                            }
                                            else
                                            {
                                                lblExperiencia3.Text = "Nenhuma";
                                            }

                                            lblNome3.Text = usuario3.nomeUsuario;                 //Mostra primeiro recomendado 
                                            lblCargo3.Text = rec3.areaAtuacao;

                                            if (rec3.fotoUsuario != null)
                                            {
                                                byte[] ImageSource = rec3.fotoUsuario;
                                                pbFoto3.Visible = true;
                                                using (MemoryStream stream = new MemoryStream(ImageSource))
                                                {
                                                    pbFoto3.Image = new Bitmap(stream);
                                                }
                                            }
                                            salvarRecomendados(indice3);
                                        }
                                        else
                                        {
                                            pnVazio3.Visible = true; //Vazio recomendados 3
                                        }

                                        if (indice4 != 0)
                                        {
                                            //Recomendados 4

                                            var rec4 = bd.curriculo.Where(x => x.idCurriculo == indice4).FirstOrDefault();

                                            var usuarioTrabalhador4 = bd.usuario_trabalhador.
                                            Where(x => x.CPF == rec4.FK_usuario_trabalhador).FirstOrDefault();
                                            var usuario4 = bd.usuario.Where(x => x.idUsuario == usuarioTrabalhador4.FK_usuario)
                                                .FirstOrDefault();
                                            var idioma4 = bd.idioma_trabalhador.Where(x => x.FK_curriculo == rec4.idCurriculo)
                                                .FirstOrDefault();
                                            var qualificacao4 = bd.qualificacao_trabalhador.Where(x => x.FK_curriculo == 
                                            rec4.idCurriculo).FirstOrDefault();
                                            var experiencia4 = bd.experiencia_profissional_trabalhador.
                                            Where(x => x.FK_curriculo == rec4.idCurriculo).FirstOrDefault();

                                            if (idioma4 != null)
                                            {
                                                lblIdioma4.Text = idioma4.linguaTrabalhador;
                                            }
                                            else
                                            {
                                                lblIdioma4.Text = "Nenhum";
                                            }

                                            if (qualificacao4 != null)
                                            {
                                                lblQualificacao4.Text = qualificacao4.nomeQualificacaoTrabalhador;  
                                                //Mostra terceiro recomendado
                                            }
                                            else
                                            {
                                                lblQualificacao4.Text = "Nenhuma";
                                            }

                                            if (experiencia4 != null)
                                            {
                                                lblExperiencia4.Text = experiencia4.cargoExperienciaTrabalhador;
                                            }
                                            else
                                            {
                                                lblExperiencia4.Text = "Nenhuma";
                                            }

                                            lblNome4.Text = usuario4.nomeUsuario;             //Mostra primeiro recomendado 
                                            lblCargo4.Text = rec4.areaAtuacao;

                                            if (rec4.fotoUsuario != null)
                                            {
                                                byte[] ImageSource = rec4.fotoUsuario;
                                                pbFoto4.Visible = true;
                                                using (MemoryStream stream = new MemoryStream(ImageSource))
                                                {
                                                    pbFoto4.Image = new Bitmap(stream);
                                                }
                                            }
                                            salvarRecomendados(indice4);
                                        }
                                        else
                                        {
                                            pnVazio4.Visible = true; //Vazio recomendados 4
                                        }
                                    }
                                    else
                                    {
                                        nenhumRecomendado();
                                    }
                                }
                                else
                                {
                                    nenhumRecomendado();
                                }
                            }
                            else
                            {
                                nenhumRecomendado();
                            }
                        }
                    }
                    catch (Exception)
                    {
                        nenhumRecomendado();  //Sem recomendados
                    }
                }
                else
                {
                    pnRec1.Visible = false;
                    pnRec2.Visible = false;
                    pnRec3.Visible = false;
                    pnRec4.Visible = false;
                    pnVazio.Visible = false;
                    pnVazio2.Visible = false;
                    pnVazio3.Visible = false;
                    pnVazio4.Visible = false;
                    lblRec.Visible = false;
                    lblAviso.Visible = true;
                }
            }
            catch (Exception)
            {
                Mensagem.aviso = "Erro ao conectar o banco";     //Erro de conexão 
                TelaMensagemAviso f = new TelaMensagemAviso();
                f.ShowDialog();
            }
        }

        public void salvarRecomendados(int i)
        {
            try
            {
                var usuarioEmpresa = bd.usuario_empresa.Where(x => x.FK_usuario == UsuarioDados.Id).FirstOrDefault();

                var teste = bd.recomendados_empresa.Where(x => x.FK_curriculo == i).
                Where(x => x.FK_usuario_empresa == usuarioEmpresa.cnpj).FirstOrDefault();

                if (teste == null)
                {
                    recomendados_empresa add = new recomendados_empresa();
                    add.FK_curriculo = i;
                    add.FK_usuario_empresa = usuarioEmpresa.cnpj;

                    bd.recomendados_empresa.Add(add);
                    bd.SaveChanges();
                }
            }
            catch (Exception)
            {
                Mensagem.aviso = "Erro ao conectar o banco";     //Erro de conexão 
                TelaMensagemAviso f = new TelaMensagemAviso();
                f.ShowDialog();
            }
        }

        public void limparRecomendados()
        {
            try
            {
                var max = bd.recomendados_empresa.Max(x => x.IdRecomendadosEmpresa);
                for (int i = 1; i <= max; i++)
                {
                    var recomendados = bd.recomendados_empresa.Where(x => x.IdRecomendadosEmpresa == i).FirstOrDefault();

                    if (recomendados != null)
                    {
                        bd.recomendados_empresa.Remove(recomendados);
                        bd.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {
                Mensagem.aviso = "Erro ao conectar o banco";     //Erro de conexão 
                TelaMensagemAviso f = new TelaMensagemAviso();
                f.ShowDialog();
            }
        }

        public void visibilidadeMenuTrue()
        {
            if (!TesteTutorial.entrou)
            {
                pbTutorial1.Visible = false;
            }

            if (Maximizacao.contadorMax == true)
            {
                pnMenu.Visible = true;
                pnPismire.Visible = true;               
                lblRec.Location = new Point(340, 101);
                pbCriar.Location = new Point(370, 4);
                int largura = pnRecomendacao.Location.X;
                int altura = pnRecomendacao.Location.Y;
                largura = largura + 190;                                   //Visibilidade de menu
                pnRecomendacao.Location = new Point(largura, altura);
                pnVazio2.Location = new Point(560, 32);
                pnRec2.Location = new Point(560, 32);
                pnVazio4.Location = new Point(560, 312);
                pnRec4.Location = new Point(560, 312);
            }
            else
            {
                pnMenu.Visible = true;
                pnPismire.Visible = true;
                lblRec.Location = new Point(340, 101);
                pbCriar.Location = new Point(370, 4);
                pnRecomendacao.Location = new Point(330, 144);
                pnVazio2.Location = new Point(560, 32);
                pnRec2.Location = new Point(560, 32);
                pnVazio4.Location = new Point(560, 312);
                pnRec4.Location = new Point(560, 312);
            }
        }

        public void visibilidadeMenuFalse()
        {
            if (!TesteTutorial.entrou)
            {
                pbTutorial1.Visible = true;
            }

            if (Maximizacao.contadorMax == true && pnMenu.Visible == true)
            {
                pnMenu.Visible = false;
                pnPismire.Visible = false;
                lblRec.Location = new Point(20, 101);
                pbCriar.Location = new Point(111, 4);
                int largura = pnRecomendacao.Location.X;                  //Visualização menu desativado
                int altura = pnRecomendacao.Location.Y;
                largura = largura - 190;
                pnRecomendacao.Location = new Point(largura, altura);
                pnVazio2.Location = new Point(608, 32);
                pnRec2.Location = new Point(608, 32);
                pnVazio4.Location = new Point(608, 312);
                pnRec4.Location = new Point(608, 312);
            }
            else if (pnMenu.Visible == true)
            {
                pnMenu.Visible = false;
                pnPismire.Visible = false;
                pnRecomendacao.Location = new Point(175, 144);
                lblRec.Location = new Point(20, 101);
                pbCriar.Location = new Point(111, 4);
                pnVazio2.Location = new Point(608, 32);
                pnRec2.Location = new Point(608, 32);
                pnVazio4.Location = new Point(608, 312);
                pnRec4.Location = new Point(608, 312);
            }
        }

        private void bloquearComandos()
        {
            btPerfil.BackColor = Color.Red;   //Marca a opção de vermelho 
            bloqCad = true;
            bloqInt = true;
            bloqEve = true;
            bloqNot = true;      //Bloqueia os comandos 
            bloqChat = true;
            bloqConf = true;
            bloqAva = true;
            pbPesquisa.Enabled = false;
            pnPesquisa.Visible = false;   //Bloqueia a barra de pesquisa
            pnRec1.Visible = false;
            pnRec2.Visible = false;  
            pnRec3.Visible = false;
            pnRec4.Visible = false;
            pnVazio.Visible = false;
            pnVazio2.Visible = false;     //Tira os recomendados
            pnVazio3.Visible = false;
            pnVazio4.Visible = false;
            lblRec.Visible = false;     
        }

        private void desbloquearComandos()
        {
            btPerfil.BackColor = Color.Transparent;
            bloqCad = false;
            bloqInt = false;
            bloqEve = false;
            bloqNot = false;
            bloqChat = false;
            bloqConf = false;
            bloqAva = false;
            pbCriar.Enabled = true;
            pbPesquisa.Enabled = true;       //Desbloqueia comandos pós tutorial
            pnPesquisa.Enabled = true;
            pbAbMenu.Enabled = true;
            pnRec1.Visible = true;
            pnRec2.Visible = true;
            pnRec3.Visible = true;
            pnRec4.Visible = true;
            pnVazio.Visible = true;
            pnVazio2.Visible = true;
            pnVazio3.Visible = true;
            pnVazio4.Visible = true;
            lblRec.Visible = true;
        }

        private void evento(object sender, EventArgs e)
        {
            if (TesteTutorial.entrou && TesteTutorial.instrucao)
            {
                try
                {
                    var preferencias = bd.preferencia.Where(x => x.FK_usuario == UsuarioDados.Id).FirstOrDefault();

                    if (preferencias.privacidade == true)
                    {
                        this.Hide();
                        TelaEvento f = new TelaEvento();
                        f.Closed += (s, args) => this.Close();            //Abrir tela Evento
                        f.ShowDialog();
                    }
                    else
                    {
                        Mensagem.aviso = "Acesso negado! habilite em configurações";    //Verificação de campos 
                        TelaMensagemAviso f = new TelaMensagemAviso();
                        f.ShowDialog();
                    }
                }
                catch (Exception)
                {
                    Mensagem.aviso = "Erro ao conectar o banco";     //Erro de conexão 
                    TelaMensagemAviso f = new TelaMensagemAviso();
                    f.ShowDialog();
                }
            }
            finalTutorial();
        }

        private void perfil(object sender, EventArgs e)
        {
            PegarIDEmpresa.visualizacao = false;
            this.Hide();
            TelaVisualizacaoPerfilEmpresa f = new TelaVisualizacaoPerfilEmpresa();       //Abrir tela Perfil empresa
            f.Closed += (s, args) => this.Close();
            f.ShowDialog();
        }

        private void candidatos(object sender, EventArgs e)
        {
            if (!bloqCad)
            {
                this.Hide();
                TelaCandidatos f = new TelaCandidatos();               //Abrir tela Candidatos
                f.Closed += (s, args) => this.Close();
                f.ShowDialog();
            }
        }

        private void interesses(object sender, EventArgs e)
        {
            if (!bloqInt)
            {
                this.Hide();
                TelaInteressados f = new TelaInteressados();
                f.Closed += (s, args) => this.Close();              //Abrir tela Interessados 
                f.ShowDialog();
            }
        }

        private void eventoscriados(object sender, EventArgs e)
        {
            try
            {
                if (!bloqEve)
                {
                    var preferencias = bd.preferencia.Where(x => x.FK_usuario == UsuarioDados.Id).FirstOrDefault();

                    if (preferencias.privacidade == true)
                    {
                        this.Hide();
                        TelaEventosCriados f = new TelaEventosCriados();
                        f.Closed += (s, args) => this.Close();            //Abrir tela Evento criados
                        f.ShowDialog();
                    }
                    else
                    {
                        Mensagem.aviso = "Acesso negado! habilite em configurações";    //Verificação de campos 
                        TelaMensagemAviso f = new TelaMensagemAviso();
                        f.ShowDialog();
                    }
                }
            }
            catch (Exception)
            {
                Mensagem.aviso = "Erro ao conectar o banco";     //Erro de conexão 
                TelaMensagemAviso f = new TelaMensagemAviso();
                f.ShowDialog();
            }
        }

        private void notificacoes(object sender, EventArgs e)
        {
            try
            {
                if (!bloqNot)
                {
                    var preferencias = bd.preferencia.Where(x => x.FK_usuario == UsuarioDados.Id).FirstOrDefault();

                    if (preferencias.receberNotificacao == true)
                    {
                        this.Hide();
                        TelaNotificacao f = new TelaNotificacao();
                        f.Closed += (s, args) => this.Close();            //Abrir tela Notificação
                        f.ShowDialog();
                    }
                    else
                    {
                        Mensagem.aviso = "Acesso negado! habilite em configurações";    //Verificação de preferencia 
                        TelaMensagemAviso f = new TelaMensagemAviso();
                        f.ShowDialog();
                    }
                }
            }
            catch (Exception)
            {
                Mensagem.aviso = "Erro ao conectar o banco";     //Erro de conexão 
                TelaMensagemAviso f = new TelaMensagemAviso();
                f.ShowDialog();
            }
        }

        private void chat(object sender, EventArgs e)
        {
            finalTutorial();
            if (!bloqChat)
            {
                this.Hide();
                TelaMensagemEmpresa f = new TelaMensagemEmpresa();               //Abrir tela Empresa
                f.Closed += (s, args) => this.Close();
                f.ShowDialog();
            }
        }

        private void configuracoes(object sender, EventArgs e)
        {
            if (!bloqConf)
            {
                this.Hide();
                TelaConfiguracao f = new TelaConfiguracao();               //Abrir tela Configurações
                f.Closed += (s, args) => this.Close();
                f.ShowDialog();
            }
        }

        private void avaliacao(object sender, EventArgs e)
        {
            if (!bloqAva)
            {
                this.Hide();
                TelaAvaliacao f = new TelaAvaliacao();            //Abrir tela Avaliação
                f.Closed += (s, args) => this.Close();
                f.ShowDialog();
            }
        }

        private void sair(object sender, EventArgs e)
        {
            this.Hide();
            TelaLogin f = new TelaLogin();
            f.Closed += (s, args) => this.Close();         //Abrir tela Login
            f.ShowDialog();
        }

        private void TelaPrincipalEmpresa_Click(object sender, EventArgs e)
        {
            visibilidadeMenuFalse();
            finalTutorial();
        }

        public void finalTutorial()
        {
            if (!TesteTutorial.instrucao)
            {
                if (pbTutorial3.Visible == true)
                {
                    pbTutorial3.Visible = false;
                    pbBemVindo.Visible = false;
                    lblBemvindo.Visible = false;
                    pbTutorial4.Visible = true;
                }
                else if (pbTutorial4.Visible == true)
                {
                    pbTutorial4.Visible = false;
                    pbTutorialCompleto.Visible = true;
                }
                else if (pbTutorialCompleto.Visible == true)
                {
                    pbTutorialCompleto.Visible = false;
                    desbloquearComandos();
                    TesteTutorial.instrucao = true;
                    this.Hide();
                    TelaPrincipalEmpresa f = new TelaPrincipalEmpresa();
                    f.Closed += (s, args) => this.Close();
                    f.ShowDialog();
                }
            }
        }

        private void btPerfil_MouseHover(object sender, EventArgs e)
        {
            if (TesteTutorial.entrou)
            {
                pbTeste.Visible = true;
                btPerfil.ForeColor = Color.FromArgb(163, 160, 251);
                btPerfil.Image = Properties.Resources.construcao;
            }
            else
            {
                btPerfil.ForeColor = Color.White;
            }
        }

        private void btPerfil_MouseLeave(object sender, EventArgs e)
        {
            if (TesteTutorial.entrou)
            {
                pbTeste.Visible = false;
                btPerfil.ForeColor = Color.White;
                btPerfil.Image = Properties.Resources.unknown__4_;
            }
        }

        private void btPerfil_MouseEnter(object sender, EventArgs e)
        {
            if (TesteTutorial.entrou)
            {
                pbTeste.Visible = true;
                btPerfil.ForeColor = Color.FromArgb(163, 160, 251);
                btPerfil.Image = Properties.Resources.construcao;
            }
            else
            {
                btPerfil.ForeColor = Color.White;
            }
        }

        private void btCandidatos_MouseEnter(object sender, EventArgs e)
        {
            btCandidatos.ForeColor = Color.FromArgb(163, 160, 251);
            btCandidatos.Image = Properties.Resources.cadidatoRoxo;
            pbTeste1.Visible = true;
        }

        private void btCandidatos_MouseHover(object sender, EventArgs e)
        {
            btCandidatos.ForeColor = Color.FromArgb(163, 160, 251);
            btCandidatos.Image = Properties.Resources.cadidatoRoxo;
            pbTeste1.Visible = true;
        }

        private void btCandidatos_MouseLeave(object sender, EventArgs e)
        {
            btCandidatos.ForeColor = Color.White;
            btCandidatos.Image = Properties.Resources.candidato;
            pbTeste1.Visible = false;
        }

        private void btInteresses_MouseEnter(object sender, EventArgs e)
        {
            btInteresse.ForeColor = Color.FromArgb(163, 160, 251);
            btInteresse.Image = Properties.Resources.marca_paginas_roxo;
            pbTeste2.Visible = true;
        }

        private void btInteresses_MouseHover(object sender, EventArgs e)
        {
            btInteresse.ForeColor = Color.FromArgb(163, 160, 251);
            btInteresse.Image = Properties.Resources.marca_paginas_roxo;
            pbTeste2.Visible = true;
        }

        private void btInteresses_MouseLeave(object sender, EventArgs e)
        {
            btInteresse.ForeColor = Color.White;
            btInteresse.Image = Properties.Resources.marca_paginas;
            pbTeste2.Visible = false;
        }

        private void btEventos_MouseEnter(object sender, EventArgs e)
        {
            btEventos.ForeColor = Color.FromArgb(163, 160, 251);
            btEventos.Image = Properties.Resources.eventoRoxo;
            pbTeste3.Visible = true;
        }

        private void btEventos_MouseHover(object sender, EventArgs e)
        {
            btEventos.ForeColor = Color.FromArgb(163, 160, 251);
            btEventos.Image = Properties.Resources.eventoRoxo;
            pbTeste3.Visible = true;
        }

        private void btEventos_MouseLeave(object sender, EventArgs e)
        {
            btEventos.ForeColor = Color.White;
            btEventos.Image = Properties.Resources.unknown__7_;
            pbTeste3.Visible = false;
        }

        private void btNotificacoes_MouseEnter(object sender, EventArgs e)
        {
            btNotificacoes.ForeColor = Color.FromArgb(163, 160, 251);
            btNotificacoes.Image = Properties.Resources.sino_roxo;
            pbTeste4.Visible = true;
        }

        private void btNotificacoes_MouseHover(object sender, EventArgs e)
        {
            btNotificacoes.ForeColor = Color.FromArgb(163, 160, 251);
            btNotificacoes.Image = Properties.Resources.sino_roxo;
            pbTeste4.Visible = true;
        }

        private void btNotificacoes_MouseLeave(object sender, EventArgs e)
        {
            btNotificacoes.ForeColor = Color.White;
            btNotificacoes.Image = Properties.Resources.unknown__8_;
            pbTeste4.Visible = false;
        }

        private void btChat_MouseEnter(object sender, EventArgs e)
        {
            btChat.ForeColor = Color.FromArgb(163, 160, 251);
            btChat.Image = Properties.Resources.bate_papo_roxo;
            pbTeste5.Visible = true;
        }

        private void btChat_MouseHover(object sender, EventArgs e)
        {
            btChat.ForeColor = Color.FromArgb(163, 160, 251);
            btChat.Image = Properties.Resources.bate_papo_roxo;
            pbTeste5.Visible = true;
        }

        private void btChat_MouseLeave(object sender, EventArgs e)
        {
            btChat.ForeColor = Color.White;
            btChat.Image = Properties.Resources.bate_papo;
            pbTeste5.Visible = false;
        }

        private void btConfiguracoes_MouseEnter(object sender, EventArgs e)
        {
            btConf.ForeColor = Color.FromArgb(163, 160, 251);
            btConf.Image = Properties.Resources.engrenagem_roxo;
            pbTeste7.Visible = true;
        }

        private void btConfiguracoes_MouseHover(object sender, EventArgs e)
        {
            btConf.ForeColor = Color.FromArgb(163, 160, 251);
            btConf.Image = Properties.Resources.engrenagem_roxo;
            pbTeste7.Visible = true;
        }

        private void btConfiguracoes_MouseLeave(object sender, EventArgs e)
        {
            btConf.ForeColor = Color.White;
            btConf.Image = Properties.Resources.engrenagem;
            pbTeste7.Visible = false;
        }

        private void btAvaliacao_MouseEnter(object sender, EventArgs e)
        {
            btAvaliacao.ForeColor = Color.FromArgb(163, 160, 251);
            btAvaliacao.Image = Properties.Resources.revisar;
            pbTeste8.Visible = true;
        }

        private void btAvaliacao_MouseHover(object sender, EventArgs e)
        {
            btAvaliacao.ForeColor = Color.FromArgb(163, 160, 251);
            btAvaliacao.Image = Properties.Resources.revisar;
            pbTeste8.Visible = true;
        }

        private void btAvaliacao_MouseLeave(object sender, EventArgs e)
        {
            btAvaliacao.ForeColor = Color.White;
            btAvaliacao.Image = Properties.Resources.unknown__12_;
            pbTeste8.Visible = false;
        }

        private void btSair_MouseEnter(object sender, EventArgs e)
        {
            btSair.ForeColor = Color.FromArgb(163, 160, 251);
            btSair.Image = Properties.Resources.sair_roxo;
            pbTeste9.Visible = true;
        }

        private void btSair_MouseHover(object sender, EventArgs e)
        {
            btSair.ForeColor = Color.FromArgb(163, 160, 251);
            btSair.Image = Properties.Resources.sair_roxo;
            pbTeste9.Visible = true;
        }

        private void btSair_MouseLeave(object sender, EventArgs e)
        {
            btSair.ForeColor = Color.White;
            btSair.Image = Properties.Resources.unknown__13_;
            pbTeste9.Visible = false;
        }

        private void txtCPF_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (tbCPF.Text != "")
                    {
                        string CPF = tbCPF.Text;

                        var curriculo = bd.curriculo.Where(y => y.FK_usuario_trabalhador == CPF).FirstOrDefault();

                        if (curriculo != null)
                        {
                            //Buscar usuário
                            Pesquisa.ID = curriculo.idCurriculo;
                            PegarID.Identificar = 4;

                            this.Hide();
                            TelaVisualizacaoCurriculo f = new TelaVisualizacaoCurriculo();
                            f.Closed += (s, args) => this.Close();
                            f.ShowDialog();
                        }
                        else
                        {
                            Mensagem.aviso = "Usuário não encontrado!";    //Verificação de campos 
                            TelaMensagemAviso f = new TelaMensagemAviso();
                            f.ShowDialog();
                            tbCPF.Clear();
                            tbCPF.Focus();
                        }
                    }
                }
            }
            catch (Exception)
            {
                Mensagem.aviso = "Erro ao conectar o banco";     //Erro de conexão 
                TelaMensagemAviso f = new TelaMensagemAviso();
                f.ShowDialog();
            }
        }

        private void p_barra_Paint(object sender, PaintEventArgs e)
        {
            int x = (p_barra.Size.Width - lbl_pismire.Width) / 2;
            int y = (p_barra.Size.Height - lbl_pismire.Height);              //Posição da label na barra

            lbl_pismire.Location = new Point(x, y);
        }

        private void p_barra_Resize(object sender, EventArgs e)
        {
            int x = (p_barra.Size.Width - lbl_pismire.Width) / 2;
            int y = (p_barra.Size.Height - lbl_pismire.Height);       //Posição da label na barra ao maximizar e desmaximizar 

            lbl_pismire.Location = new Point(x, y);
        }

        private void txtCPF_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8) { e.Handled = true; }

            if (char.IsNumber(e.KeyChar) == true)
            {
                switch (tbCPF.TextLength)
                {
                    case 0:                                        //Máscara de CPF
                        tbCPF.Text = "";
                        break;

                    case 3:
                        tbCPF.Text = tbCPF.Text + ".";
                        tbCPF.SelectionStart = 6;
                        break;

                    case 7:
                        tbCPF.Text = tbCPF.Text + ".";
                        tbCPF.SelectionStart = 9;
                        break;

                    case 11:
                        tbCPF.Text = tbCPF.Text + "-";
                        tbCPF.SelectionStart = 14;
                        break;
                }
            }
        }

        private void txtCPF_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                tbCPF.Clear();
            }                                                           //Limpar todo o CPF ao apgar com o BackSpace
            else if (e.KeyCode == Keys.Back)
            {
                tbCPF.Clear();
            }
        }

        private void pbAbMenu_Click(object sender, EventArgs e)
        {
            visibilidadeMenuTrue();                              //Visialização do menu
            finalTutorial();
        }

        private void p_barra_Click(object sender, EventArgs e)
        {
            visibilidadeMenuFalse();
            finalTutorial();
        }

        private void pb_chat_Click(object sender, EventArgs e)
        {
            if (!bloqChat)
            {
                this.Hide();
                TelaMensagemEmpresa f = new TelaMensagemEmpresa();                  //Abrir a chat 
                f.Closed += (s, args) => this.Close();
                f.ShowDialog();
            }
            finalTutorial();
        }

        private void pbChat_MouseEnter(object sender, EventArgs e)
        {
            pbChat.Image = Properties.Resources.chatRoxo1;
        }

        private void pbChat_MouseLeave(object sender, EventArgs e)
        {
            pbChat.Image = Properties.Resources.chatAzul;
        }

        private void pbCriar_MouseEnter(object sender, EventArgs e)
        {
            pbCriar.Image = Properties.Resources.criarEventoRoxo;
        }

        private void pbCriar_MouseLeave(object sender, EventArgs e)
        {
            pbCriar.Image = Properties.Resources.criarEvento3;
        }

        private void pnRec2_MouseEnter(object sender, EventArgs e)
        {
            pnRec2.BackColor = Color.FromArgb(66, 66, 92);
        }

        private void pnRec2_MouseLeave(object sender, EventArgs e)
        {
            pnRec2.BackColor = Color.FromArgb(41, 41, 41);
        }

        private void pnRec4_MouseEnter(object sender, EventArgs e)
        {
            pnRec4.BackColor = Color.FromArgb(66, 66, 92);
        }

        private void pnRec4_MouseLeave(object sender, EventArgs e)
        {
            pnRec4.BackColor = Color.FromArgb(41, 41, 41);
        }

        private void pnRec1_MouseEnter(object sender, EventArgs e)
        {
            pnRec1.BackColor = Color.FromArgb(66, 66, 92);
        }

        private void pnRec1_MouseLeave(object sender, EventArgs e)
        {
            pnRec1.BackColor = Color.FromArgb(41, 41, 41);
        }

        private void pnRec3_MouseEnter(object sender, EventArgs e)
        {                                                                           //Efeito de passar por cima do icones
            pnRec3.BackColor = Color.FromArgb(66, 66, 92);
        }

        private void pnRec3_MouseLeave(object sender, EventArgs e)
        {
            pnRec3.BackColor = Color.FromArgb(41, 41, 41);
        }

        private void pbAbMenu_MouseEnter(object sender, EventArgs e)
        {
            pbAbMenu.Image = Properties.Resources.menuRoxo11;
        }

        private void pbAbMenu_MouseLeave(object sender, EventArgs e)
        {
            pbAbMenu.Image = Properties.Resources.menu5;
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
        {                                                                              //Efeito de opções no menu 
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

        private void pnRec1_Click(object sender, EventArgs e)
        {
            try
            {
                var curriculo = bd.curriculo.Where(x => x.idCurriculo == indice).FirstOrDefault();
                var trab = bd.usuario_trabalhador.Where(x => x.CPF == curriculo.FK_usuario_trabalhador).FirstOrDefault();
                var usuario = bd.usuario.Where(x => x.idUsuario == trab.FK_usuario).FirstOrDefault();
                int id = usuario.idUsuario;

                Pesquisa.ID = curriculo.idCurriculo;  //Pega o id ao clicar em um recomendado

                PegarID.Identificar = 1;

                this.Hide();
                TelaVisualizacaoCurriculo f = new TelaVisualizacaoCurriculo();
                f.Closed += (s, args) => this.Close();
                f.ShowDialog();
            }
            catch (Exception)
            {
                Mensagem.aviso = "Erro ao conectar o banco";     //Erro de conexão 
                TelaMensagemAviso f = new TelaMensagemAviso();
                f.ShowDialog();
            }
        }

        private void pnRec2_Click(object sender, EventArgs e)
        {
            try
            {
                var curriculo2 = bd.curriculo.Where(x => x.idCurriculo == indice2).FirstOrDefault();
                var trab2 = bd.usuario_trabalhador.Where(x => x.CPF == curriculo2.FK_usuario_trabalhador).FirstOrDefault();
                var usuario2 = bd.usuario.Where(x => x.idUsuario == trab2.FK_usuario).FirstOrDefault();
                int id2 = usuario2.idUsuario;

                Pesquisa.ID = curriculo2.idCurriculo;   //Pega o id ao clicar em um recomendado

                PegarID.Identificar = 1;

                this.Hide();
                TelaVisualizacaoCurriculo f = new TelaVisualizacaoCurriculo();
                f.Closed += (s, args) => this.Close();
                f.ShowDialog();
            }
            catch (Exception)
            {
                Mensagem.aviso = "Erro ao conectar o banco";     //Erro de conexão 
                TelaMensagemAviso f = new TelaMensagemAviso();
                f.ShowDialog();
            }
        }

        private void pnRec3_Click(object sender, EventArgs e)
        {
            try
            {
                var curriculo3 = bd.curriculo.Where(x => x.idCurriculo == indice3).FirstOrDefault();
                var trab3 = bd.usuario_trabalhador.Where(x => x.CPF == curriculo3.FK_usuario_trabalhador).FirstOrDefault();
                var usuario3 = bd.usuario.Where(x => x.idUsuario == trab3.FK_usuario).FirstOrDefault();
                int id3 = usuario3.idUsuario;

                Pesquisa.ID = curriculo3.idCurriculo;   //Pega o id ao clicar em um recomendado

                PegarID.Identificar = 1;

                this.Hide();
                TelaVisualizacaoCurriculo f = new TelaVisualizacaoCurriculo();
                f.Closed += (s, args) => this.Close();
                f.ShowDialog();
            }
            catch (Exception)
            {
                Mensagem.aviso = "Erro ao conectar o banco";     //Erro de conexão 
                TelaMensagemAviso f = new TelaMensagemAviso();
                f.ShowDialog();
            }
        }

        private void pnRec4_Click(object sender, EventArgs e)
        {
            try
            {
                var curriculo4 = bd.curriculo.Where(x => x.idCurriculo == indice4).FirstOrDefault();
                var trab4 = bd.usuario_trabalhador.Where(x => x.CPF == curriculo4.FK_usuario_trabalhador).FirstOrDefault();
                var usuario4 = bd.usuario.Where(x => x.idUsuario == trab4.FK_usuario).FirstOrDefault();
                int id4 = usuario4.idUsuario;

                Pesquisa.ID = curriculo4.idCurriculo;   //Pega o id ao clicar em um recomendado

                PegarID.Identificar = 1;

                this.Hide();
                TelaVisualizacaoCurriculo f = new TelaVisualizacaoCurriculo();
                f.Closed += (s, args) => this.Close();
                f.ShowDialog();
            }
            catch (Exception)
            {
                Mensagem.aviso = "Erro ao conectar o banco";     //Erro de conexão 
                TelaMensagemAviso f = new TelaMensagemAviso();
                f.ShowDialog();
            }
        }

        private void pnRecomendacao_Click(object sender, EventArgs e)
        {
            visibilidadeMenuFalse();          //Fechar menu 
        }

        private void pbTutorial4_Click(object sender, EventArgs e)
        {
            finalTutorial();
        }

        private void lblBemvindo_Click(object sender, EventArgs e)
        {
            finalTutorial();
        }                                                               

        private void pbPesquisa_Click(object sender, EventArgs e)
        {
            finalTutorial();
        }

        private void lbl_pismire_Click(object sender, EventArgs e)
        {
            finalTutorial();
        }
    }
}
