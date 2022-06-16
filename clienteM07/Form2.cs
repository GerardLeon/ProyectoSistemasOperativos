using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace WindowsFormsApplication1
{
    public partial class Form2 : Form
    {
        int nForm;
        Socket server;
        string Teinvita;
        int id;
        string Tu;
        public Form2(int nForm, Socket server)
        {
            InitializeComponent();
            this.nForm = nForm;
            this.server = server;
        }
        public void MostrarInvitacion(byte[] msg2, string usuario)
        {
            string[] trozos = Encoding.ASCII.GetString(msg2).Split('/');
            int codigo = Convert.ToInt32(trozos[0]);
            Teinvita = trozos[1];
            id = Convert.ToInt32(trozos[2].Split('/')[0]);
            Tu = usuario;
            labelInfoPartida.Text = ("Te invita " + Teinvita + " en la partida con Id: " + id);
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            //labelInfoPartida.Text = nForm.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string mensaje = "9/" + nForm + "/" + Teinvita + "/" + Tu + "/" + id + "/1";
            // Enviamos al servidor el nombre tecleado
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
            this.Close();
        }

        private void btRechazar_Click(object sender, EventArgs e)
        {
            string mensaje = "9/" + nForm + "/" + Teinvita + "/" + Tu + "/" + id + "/0";
            // Enviamos al servidor el nombre tecleado
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
            this.Close();
        }

        private void labelInfoPartida_Click(object sender, EventArgs e)
        {

        }
    }
}
