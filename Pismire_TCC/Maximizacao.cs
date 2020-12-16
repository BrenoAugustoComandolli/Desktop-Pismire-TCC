using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pismire_TCC
{
    class Maximizacao
    {
        public static bool contadorMax { get; set; }

        public static void verifique(Form f,PictureBox pb)
        {
            if (contadorMax == true)
            {
                pb.Image = Properties.Resources.maximizar;
                f.WindowState = FormWindowState.Maximized;
            }
        } 
    }
}
