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
        Thread atender2;
        string Teinvita;
        int id;
        string Tu;
        int nForm;
        int logueado = 0;
        string chat;

        delegate void DelegadoParaEscribir(string mensaje);
        List<Form2> formularios = new List<Form2>();

        public Form1()
        {
            InitializeComponent();
            //CheckForIllegalCrossThreadCalls = false; //Necesario para que los elementos de los formularios puedan ser
            //accedidos desde threads diferentes a los que los crearon
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            

        }

        public void PonContador(string contador)
        {
            ListaConectados.Text = contador;
        }

        private void AtenderServidor()
        {
            string lista = null;
            while (true)
            {
                //Recibimos mensaje del servidor
                byte[] msg2 = new byte[180];
                server.Receive(msg2);

                //Solo para Debugging
                //string debug = Encoding.ASCII.GetString(msg2);
                //string mensajedeb = "99/" + debug;
               // byte[] msg3 = System.Text.Encoding.ASCII.GetBytes(mensajedeb);
                //server.Send(msg3);
               

                string[] trozos = Encoding.ASCII.GetString(msg2).Split('/');
                int codigo = Convert.ToInt32(trozos[0]);
                string mensaje = "0";

                if (codigo <= 100)
                {
                    mensaje = trozos[1].Split('\0')[0];
                }

                int nForm;
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
                    case 51: //respuesta a login del usuario
                        MessageBox.Show(mensaje);
                        logueado = 1;
                        break;
                    case 52: //respuesta a login del usuario
                        MessageBox.Show(mensaje);
                        logueado = 0;
                        break;
                    case 6: //respuesta a registro del usuario
                        MessageBox.Show(mensaje);
                        break;
                    case 7: //recibimos notifcacion
                        //ListaConectados.Text = mensaje;
                        this.Invoke(new Action(() =>
                        {
                            lista = null;
                            string[] nombres = mensaje.Split('-');
                            GridConectados.Rows.Clear();
                            int i = 0;
                            while (i < (nombres.Length))
                            {
                                try
                                {
                                    nombres[i] = Convert.ToString(nombres[i]).Replace("7/", String.Empty);
                                    GridConectados.Rows.Add(Convert.ToString(nombres[i]));
                                }
                                catch
                                {
                                }
                                lista = lista + Convert.ToString(nombres[i]) + "\n";
                                i++;
                            }
                            ListaConectados.Text = lista;
                        }));
                        
                        break;

                    case 8: //Abre formulario invitación
                         this.Invoke(new Action(() =>
                        {
                            if (trozos[1] != nombre.Text)
                            {
  
                                //ThreadStart ts = delegate { PonerEnMarchaFormulario(); };
                                //Thread T = new Thread(ts);
                                //T.Start();
                                int cont = formularios.Count;
                                Form2 f = new Form2(cont, server);
                                formularios.Add(f);
                                formularios[cont].MostrarInvitacion(msg2, nombre.Text);
                                f.ShowDialog();
                                mensaje = "Esperando resolucion de invitacion";
                                ListaConectados.Text = mensaje;
                                //int cont= formularios.Count;
                            }
                        }));
                        break;

                    case 9://Acepta o no
                        this.Invoke(new Action(() =>
                        {
                        nForm = Convert.ToInt32(trozos[1]);
                        mensaje = trozos[2].Split('\0')[0];
                        ListaConectados.Text = mensaje;
                        if (trozos[2].Split('\0')[0] == "SI")
                        {
                            MessageBox.Show("Ha aceptado la invitación");
                        }
                        else
                        {
                            MessageBox.Show("Ha rechazado la invitación");
                        }
                        }));
                        break;
                    case 90: //respuesta al eliminar usuario
                        MessageBox.Show(mensaje);
                        logueado = 0;
                        break;
                    case 10: // Chat
                        this.Invoke(new Action(() =>
                        {
                            string remitente;
                            string cuerpo;
                            string lineachat;
                            remitente = trozos[1].Split('\0')[0];
                            cuerpo = trozos[2].Split('\0')[0];
                            lineachat = remitente + ": " + cuerpo + "\n";
                            chat = chat + lineachat;
                            ActualizaChat(chat);
                        }));
                        break;

                }
            }
        }

        private void Conexion_Click(object sender, EventArgs e)
        {
            //Creamos un IPEndPoint con el ip del servidor y puerto del servidor 
            //al que deseamos conectarnos
            IPAddress direc = IPAddress.Parse("192.168.56.102");
            IPEndPoint ipep = new IPEndPoint(direc, 9050);


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

        private void Desconexion_Click(object sender, EventArgs e)
        {  //Mensaje de desconexión
            string mensaje;
            if (logueado == 1)
            {
                mensaje = "0/" + nombre.Text + "/" + contrasenya.Text;
            }
            else
            {
                mensaje = "0/" + "not_logged_user";
            }
                

            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

            richTextBox1.Clear();

            // Nos desconectamos
            atender.Abort();

            ListaConectados.Text = ("Conéctate para ver los usuarios conectados");
            GridConectados.Rows.Clear();
            this.BackColor = Color.Gray;
            server.Shutdown(SocketShutdown.Both);
            server.Close();
            logueado = 0;
           
        }

        /*private void Debugging(object sender, EventArgs e)
        {
            string mensaje = "99/" + msg2;
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
        }*/


        private void Consulta_Click(object sender, EventArgs e)
        {
            if (numero_victoria.Checked)
            {
                string mensaje = "1/" + nombre.Text;
                // Enviamos al servidor el nombre tecleado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            }
            if (ESCENARIOJUNTOS.Checked)
            {
                string mensaje = "2/" + nombre.Text +"/"+ nombre2.Text;
                // Enviamos al servidor el nombre tecleado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);

            }
            if (mejor_escenario.Checked)
            {
                string mensaje = "3/" + nombre.Text;
                // Enviamos al servidor el nombre tecleado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);

            }

            if (tablero_posiciones.Checked)
            {
                string mensaje = "4/" + nombre.Text;
                // Enviamos al servidor el nombre tecleado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);

            }
        }

        private void LogIn_Click(object sender, EventArgs e)
        {
            if (logueado == 0)
            {
                string mensaje = "5/" + nombre.Text + "/" + contrasenya.Text;
                // Enviamos al servidor el nombre tecleado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
                //logueado = 1;
            }
        }

        private void Registro_Click(object sender, EventArgs e)
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
        private void PonerEnMarchaFormulario()
        {
            int cont = formularios.Count;
            Form2 f = new Form2(cont, server);
            formularios.Add(f);
            f.ShowDialog();
            cont = formularios.Count;
        }

        private void Aceptar_Click(object sender, EventArgs e)
        {
            ThreadStart ts = delegate { PonerEnMarchaFormulario(); };
            Thread t = new Thread(ts);
            t.Start();
        }


       private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }

        private void Aceptar_Click_1(object sender, EventArgs e)
        {

        }

        private void GridConectados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BotonInvitar2_Click(object sender, EventArgs e)
        {
            string invitados = null;
            int i = 0;
            bool invito = true;
            int numinvitados = GridConectados.SelectedCells.Count;
            ListaConectados.Text = "Numero de Invitados: " + numinvitados;
            while (i < GridConectados.Rows.Count)
            {
                if (GridConectados.Rows[i].Cells[0].Selected)
                {
                    if (GridConectados.Rows[i].Cells[0].Value == null)
                    {
                        MessageBox.Show("Tienes que seleccionar un jugador existente, no puedes invitar a una casilla en blanco.");
                        invito = false;
                        break;
                    }
                    else if (GridConectados.Rows[i].Cells[0].Value.ToString() == nombre.Text)
                    {
                        MessageBox.Show("Te estás invitando a ti mismo, intenta invitar a otros jugadores.");
                        invito = false;
                        break;
                    }
                    else
                    {
                        invitados = invitados + "/";
                        invitados = invitados + GridConectados.Rows[i].Cells[0].Value.ToString();
                        //invitados = invitados + "/";
                        i = i + 1;
                    }
                }
                else
                {
                    i = i + 1;
                }

            }

            if (invito == true)
            {
                string mensaje = "8/" + nombre.Text + "/" + Convert.ToString(numinvitados) + invitados;
                // Enviamos al servidor el nombre introducido
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
                MessageBox.Show("Has invitado a los jugadores");
            }
        }

      

        private void eliminar_Click(object sender, EventArgs e)
        {
            if (logueado == 1)
            {
                string mensaje = "90/" + nombre.Text + "/" + contrasenya.Text;
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
                logueado = 0;
                richTextBox1.Clear();
            }
            else
            {
                
            }
        }
    

        private void botonChatear_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string mensaje = "10/" + nombre.Text + "/" + textBox1.Text;
            // Enviamos al servidor el mensaje
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

            textBox1.Clear();
        }

        public void ActualizaChat(string chat)
        {
            richTextBox1.Text = chat;
        }
    }
}
