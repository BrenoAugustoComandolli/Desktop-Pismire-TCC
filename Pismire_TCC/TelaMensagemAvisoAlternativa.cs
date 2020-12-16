using System;
using System.Drawing;
using System.Windows.Forms;

namespace Pismire_TCC
{
    public partial class TelaMensagemAvisoAlternativa : Form
    {
        public TelaMensagemAvisoAlternativa()
        {
            InitializeComponent();
            lbl_mensagem.Text = Mensagem.aviso;
            this.Focus();
        }
        
        private void bt_ok_Click(object sender, EventArgs e)
        {
            Mensagem.teste = false;
            Close();
        }

        private void bt_ok_MouseEnter(object sender, EventArgs e)
        {
            bt_ok.ForeColor = Color.Black;
        }

        private void bt_ok_MouseLeave(object sender, EventArgs e)
        {
            bt_ok.ForeColor = Color.White;
        }
    }
}
