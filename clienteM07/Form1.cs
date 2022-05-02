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
using System.Threading;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        Socket server;
        Thread atender;

        delegate void DelegadoParaEscribir(string mensaje);

        public Form1()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            

        }

        public void PonContador(string contador)
        {
            contLbl.Text = contador;
        }

        private void AtenderServidor()
        {
            while (true)
            {
                //Recibimos mensaje del servidor
                byte[] msg2 = new byte[180];
                server.Receive(msg2);
                string[] trozos = Encoding.ASCII.GetString(msg2).Split('/');
                int codigo = Convert.ToInt32(trozos[0]);
                string mensaje = trozos[1].Split('\0')[0];

                switch (codigo)
                {
                    case 1: //respuesta a numero de victorias
                        MessageBox.Show("El numero de victorias es: " + mensaje);
                        break;
                    case 2:  //respuesta a jugadores que han jugado juntos 
                        MessageBox.Show("Los jugadores han jugado juntos en:\n" + mensaje);
                        break;
                    case 3: //respuesta a escenario con más puntos
                        MessageBox.Show(mensaje);
                        break;
                    case 4:  //respuesta a tabla de posiciones
                        MessageBox.Show("Tabla de Posiciones: " + mensaje);
                        break;
                    case 5: //respuesta a login del usuario
                        MessageBox.Show(mensaje);
                        break;
                    case 6: //respuesta a registro del usuario
                        MessageBox.Show(mensaje);
                        break;
                    case 7: //recibimos notifcacion
                        //contLbl.Text = mensaje;
                        DelegadoParaEscribir delegado = new DelegadoParaEscribir(PonContador);
                        contLbl.Invoke(delegado, new object [] {mensaje});
                        break;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Creamos un IPEndPoint con el ip del servidor y puerto del servidor 
            //al que deseamos conectarnos
            IPAddress direc = IPAddress.Parse("192.168.56.102");
            IPEndPoint ipep = new IPEndPoint(direc, 9000);


            //Creamos el socket 
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                server.Connect(ipep);//Intentamos conectar el socket
                this.BackColor = Color.Green;
                MessageBox.Show("Conectado");

                //pongo en marcha el thread que atenderá los mensajes del servidor
                ThreadStart ts = delegate { AtenderServidor(); };
                atender = new Thread(ts);
                atender.Start();

            }
            catch (SocketException ex)
            {
                //Si hay excepcion imprimimos error y salimos del programa con return 
                MessageBox.Show("No he podido conectar con el servidor");
                return;
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {  //Mensaje de desconexión
            string mensaje = "0/";

            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

            // Nos desconectamos
            atender.Abort();
            this.BackColor = Color.Gray;
            server.Shutdown(SocketShutdown.Both);
            server.Close();
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (numero_victoria.Checked)
            {
                string mensaje = "1/" + nombre.Text;
                // Enviamos al servidor el nombre tecleado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            }
            if (P2.Checked)
            {
                string mensaje = "2/" + nombre.Text +"/"+ nombre2.Text;
                // Enviamos al servidor el nombre tecleado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);

            }
            if (P3.Checked)
            {
                string mensaje = "3/" + nombre.Text;
                // Enviamos al servidor el nombre tecleado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);

            }

            if (P4.Checked)
            {
                string mensaje = "4/" + nombre.Text;
                // Enviamos al servidor el nombre tecleado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string mensaje = "5/" + nombre.Text +"/" + contrasenya.Text;
            // Enviamos al servidor el nombre tecleado
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            string mensaje = "6/" + nombre.Text + "/" + contrasenya.Text;
            // Enviamos al servidor el nombre tecleado
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

        }

        private void P3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void contrasenya_TextChanged(object sender, EventArgs e)
        {

        }


    }
}
