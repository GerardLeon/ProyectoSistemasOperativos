using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Net.Sockets;

namespace WindowsFormsApplication1
{
    public partial class Form4 : Form
    {
        int nForm;
        Socket server;
        string Tu;
        public Form4(int nForm, Socket server)
        {
            InitializeComponent();
            this.nForm = nForm;
            this.server = server;
        }
        public void estadisticasjugador(string usuario)
        {
            Tu = usuario;
        }
        private void enviar_Click(object sender, EventArgs e)
        {
            if (numero_victorias.Checked)
            {
                string mensaje = "1/" + Tu;
                // Enviamos al servidor el nombre tecleado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            }
            if (escenarios_juntos.Checked)
            {
                string mensaje = "2/" + Tu + "/" + nombre2.Text;
                // Enviamos al servidor el nombre tecleado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);

            }
            if (mejor_escenario.Checked)
            {
                string mensaje = "3/" + Tu;
                // Enviamos al servidor el nombre tecleado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);

            }

            if (tablero_posiciones.Checked)
            {
                string mensaje = "4/" + Tu;
                // Enviamos al servidor el nombre tecleado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);

            }

        }
    }
}
