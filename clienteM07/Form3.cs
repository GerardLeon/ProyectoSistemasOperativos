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
    public partial class Form3 : Form
    {
        // Variables
        int nForm;
        string host;
        Socket server;
        string Teinvita;
        int id;
        string Tu;
        String Jugador1;
        String Jugador2;
        String Jugador3;
        String Jugador4;
        int tiempoinvitacion = 15;
        int tiempoiniciopartida = 20;

        //Variables Partida
        List<Point> posiciones = new List<Point>();
        List<Point> posicionesgris = new List<Point>();
        List<Point> posicionesazul = new List<Point>();
        List<Point> posicionesnaranja = new List<Point>();
        List<string> conectados = new List<string>();
        List<string> invitados = new List<string>();
        string eselturnode;
        int clickcont;
        Random rand = new Random();
        int cont = 0;
        int contgris = 0;
        int contazul = 0;
        int contnaranja = 0;
        int turno = 0;

        public int pos = 0;
        public int posazul = 0;
        public int posgris = 0;
        public int posnaranja = 0;


        int puntos;
        int puntuacionmax;
        string ganador;

        int preguntasacertadas = 0;

        //Funciones
        public Form3(int nForm, Socket server)
        {
            InitializeComponent();
            this.nForm = nForm;
            this.server = server;
        }

        /*public void MostrarInvitacion(string mensaje, string usuario)
        {
            string[] nombres = mensaje.Split('/');
            Teinvita = nombres[0];
            id = Convert.ToInt32(nombres[1]);
            Tu = usuario;
            label4.Text = ("Te invita " + nombres[0] + " en la partida con Id: " + nombres[1]);
        }*/

        public void AsignarJugadores(string Jugador1, string Jugador2, string Jugador3, string Jugador4, string usuario)
        {
            Tu = usuario;

            invitados.Add(Jugador1);
            invitados.Add(Jugador2);
            invitados.Add(Jugador3);
            invitados.Add(Jugador4);

            turnoLbl.Text = invitados[turno];
        }

        /*public void Jugada(string turnode)
        {
            this.eselturnode = turnode;
            turnoLbl.Text = "Turno de " + turnode;

            clickcont = 0;

            if (turnode == Tu)
            {

                //pictureBox18.Enabled = true;
            }
            else
            {
                //pictureBox18.Enabled = false;

            }
        }
         */


        private void Form3_Load(object sender, EventArgs e)
        {
            //ganador = Tu;
            puntos = 0;
            puntuacionmax = 100;


            Label nombreRojo = new Label();

            nombreRojo.BackColor = Color.Transparent;
            nombreRojo.Font = new Font("Arial", 24, FontStyle.Bold);
            nombreRojo.Size = new Size(200, 50);
            nombreRojo.Location = new Point(106, 20);
            nombreRojo.Text = Jugador1;

            Label nombreVerde = new Label();

            nombreVerde.BackColor = Color.Transparent;
            nombreVerde.Font = new Font("Arial", 24, FontStyle.Bold);
            nombreVerde.Size = new Size(200, 50);
            nombreVerde.Location = new Point(637,30);
            nombreVerde.Text = Jugador2;


            Label nombreAzul = new Label();

            nombreAzul.BackColor = Color.Transparent;
            nombreAzul.Font = new Font("Arial", 24, FontStyle.Bold);
            nombreAzul.Size = new Size(200, 50);
            nombreAzul.Location = new Point(121, 627);
            nombreAzul.Text = Jugador3;


            Label nombreAmarillo = new Label();

            nombreAmarillo.BackColor = Color.Transparent;
            nombreAmarillo.Font = new Font("Arial", 24, FontStyle.Bold);
            nombreAmarillo.Size = new Size(200, 50);
            nombreAmarillo.Location = new Point(646, 637);
            nombreAmarillo.Text = Jugador4;

            

            //coordenadas amarillo
            posiciones.Add(new Point(669, 610));
            posiciones.Add(new Point(604, 610));
            posiciones.Add(new Point(539, 610));
            posiciones.Add(new Point(476, 610));
            posiciones.Add(new Point(407, 610));
            posiciones.Add(new Point(345, 610));
            posiciones.Add(new Point(276, 610));
            posiciones.Add(new Point(208, 610));
            posiciones.Add(new Point(142, 610));
            posiciones.Add(new Point(50, 610));
            posiciones.Add(new Point(50, 539));
            posiciones.Add(new Point(50, 485));
            posiciones.Add(new Point(50, 431));
            posiciones.Add(new Point(50, 381));
            posiciones.Add(new Point(50, 325));
            posiciones.Add(new Point(50, 272));
            posiciones.Add(new Point(50, 217));
            posiciones.Add(new Point(50, 163));
            posiciones.Add(new Point(50, 111));
            posiciones.Add(new Point(50, 40));
            posiciones.Add(new Point(142, 40));
            posiciones.Add(new Point(208, 40));
            posiciones.Add(new Point(276, 40));
            posiciones.Add(new Point(345, 40));
            posiciones.Add(new Point(407, 40));
            posiciones.Add(new Point(476, 40));
            posiciones.Add(new Point(539, 40));
            posiciones.Add(new Point(604, 40));
            posiciones.Add(new Point(670, 40));
            posiciones.Add(new Point(720, 40));
            posiciones.Add(new Point(720, 111));
            posiciones.Add(new Point(720, 163));
            posiciones.Add(new Point(720, 217));
            posiciones.Add(new Point(720, 272));
            posiciones.Add(new Point(720, 325));
            posiciones.Add(new Point(720, 381));
            posiciones.Add(new Point(720, 431));
            posiciones.Add(new Point(720, 385));
            posiciones.Add(new Point(720, 539));
            posiciones.Add(new Point(720, 610));
            //coordenadas gris
            posicionesgris.Add(new Point(669, 600));
            posicionesgris.Add(new Point(604, 600));
            posicionesgris.Add(new Point(539, 600));
            posicionesgris.Add(new Point(476, 600));
            posicionesgris.Add(new Point(407, 600));
            posicionesgris.Add(new Point(345, 600));
            posicionesgris.Add(new Point(276, 600));
            posicionesgris.Add(new Point(208, 600));
            posicionesgris.Add(new Point(142, 600));
            posicionesgris.Add(new Point(35, 600));
            posicionesgris.Add(new Point(35, 539));
            posicionesgris.Add(new Point(35, 485));
            posicionesgris.Add(new Point(35, 431));
            posicionesgris.Add(new Point(35, 381));
            posicionesgris.Add(new Point(35, 325));
            posicionesgris.Add(new Point(35, 272));
            posicionesgris.Add(new Point(35, 217));
            posicionesgris.Add(new Point(35, 163));
            posicionesgris.Add(new Point(35, 111));
            posicionesgris.Add(new Point(35, 35));
            posicionesgris.Add(new Point(142, 25));
            posicionesgris.Add(new Point(208, 25));
            posicionesgris.Add(new Point(276, 25));
            posicionesgris.Add(new Point(345, 25));
            posicionesgris.Add(new Point(407, 25));
            posicionesgris.Add(new Point(476, 25));
            posicionesgris.Add(new Point(539, 25));
            posicionesgris.Add(new Point(604, 25));
            posicionesgris.Add(new Point(670, 25));
            posicionesgris.Add(new Point(740, 25));
            posicionesgris.Add(new Point(740, 111));
            posicionesgris.Add(new Point(740, 163));
            posicionesgris.Add(new Point(740, 217));
            posicionesgris.Add(new Point(740, 272));
            posicionesgris.Add(new Point(740, 325));
            posicionesgris.Add(new Point(740, 381));
            posicionesgris.Add(new Point(740, 431));
            posicionesgris.Add(new Point(740, 385));
            posicionesgris.Add(new Point(740, 539));
            posicionesgris.Add(new Point(740, 610));

            //coordenadas azul
            posicionesazul.Add(new Point(669, 580));
            posicionesazul.Add(new Point(604, 580));
            posicionesazul.Add(new Point(539, 580));
            posicionesazul.Add(new Point(476, 580));
            posicionesazul.Add(new Point(407, 580));
            posicionesazul.Add(new Point(345, 580));
            posicionesazul.Add(new Point(276, 580));
            posicionesazul.Add(new Point(208, 580));
            posicionesazul.Add(new Point(142, 580));
            posicionesazul.Add(new Point(20, 580));
            posicionesazul.Add(new Point(20, 539));
            posicionesazul.Add(new Point(20, 485));
            posicionesazul.Add(new Point(20, 431));
            posicionesazul.Add(new Point(20, 381));
            posicionesazul.Add(new Point(20, 325));
            posicionesazul.Add(new Point(20, 272));
            posicionesazul.Add(new Point(20, 217));
            posicionesazul.Add(new Point(20, 163));
            posicionesazul.Add(new Point(20, 111));
            posicionesazul.Add(new Point(50, 60));
            posicionesazul.Add(new Point(142, 60));
            posicionesazul.Add(new Point(208, 60));
            posicionesazul.Add(new Point(276, 60));
            posicionesazul.Add(new Point(345, 60));
            posicionesazul.Add(new Point(407, 60));
            posicionesazul.Add(new Point(476, 60));
            posicionesazul.Add(new Point(539, 60));
            posicionesazul.Add(new Point(604, 60));
            posicionesazul.Add(new Point(670, 60));
            posicionesazul.Add(new Point(760, 60));
            posicionesazul.Add(new Point(760, 111));
            posicionesazul.Add(new Point(760, 163));
            posicionesazul.Add(new Point(760, 217));
            posicionesazul.Add(new Point(760, 272));
            posicionesazul.Add(new Point(760, 325));
            posicionesazul.Add(new Point(760, 381));
            posicionesazul.Add(new Point(760, 431));
            posicionesazul.Add(new Point(760, 385));
            posicionesazul.Add(new Point(760, 539));
            posicionesazul.Add(new Point(760, 610));

            //coordenadas naranja
            posicionesnaranja.Add(new Point(669, 630));
            posicionesnaranja.Add(new Point(604, 630));
            posicionesnaranja.Add(new Point(539, 630));
            posicionesnaranja.Add(new Point(476, 630));
            posicionesnaranja.Add(new Point(407, 630));
            posicionesnaranja.Add(new Point(345, 630));
            posicionesnaranja.Add(new Point(276, 630));
            posicionesnaranja.Add(new Point(208, 630));
            posicionesnaranja.Add(new Point(142, 630));
            posicionesnaranja.Add(new Point(65, 630));
            posicionesnaranja.Add(new Point(65, 539));
            posicionesnaranja.Add(new Point(65, 485));
            posicionesnaranja.Add(new Point(65, 431));
            posicionesnaranja.Add(new Point(65, 381));
            posicionesnaranja.Add(new Point(65, 325));
            posicionesnaranja.Add(new Point(65, 272));
            posicionesnaranja.Add(new Point(65, 217));
            posicionesnaranja.Add(new Point(65, 163));
            posicionesnaranja.Add(new Point(65, 111));
            posicionesnaranja.Add(new Point(65, 10));
            posicionesnaranja.Add(new Point(142, 10));
            posicionesnaranja.Add(new Point(208, 10));
            posicionesnaranja.Add(new Point(276, 10));
            posicionesnaranja.Add(new Point(345, 10));
            posicionesnaranja.Add(new Point(407, 10));
            posicionesnaranja.Add(new Point(476, 10));
            posicionesnaranja.Add(new Point(539, 10));
            posicionesnaranja.Add(new Point(604, 10));
            posicionesnaranja.Add(new Point(670, 10));
            posicionesnaranja.Add(new Point(780, 10));
            posicionesnaranja.Add(new Point(780, 111));
            posicionesnaranja.Add(new Point(780, 163));
            posicionesnaranja.Add(new Point(780, 217));
            posicionesnaranja.Add(new Point(780, 272));
            posicionesnaranja.Add(new Point(780, 325));
            posicionesnaranja.Add(new Point(780, 381));
            posicionesnaranja.Add(new Point(780, 431));
            posicionesnaranja.Add(new Point(780, 385));
            posicionesnaranja.Add(new Point(780, 539));
            posicionesnaranja.Add(new Point(780, 610));



            tablero.BackgroundImageLayout = ImageLayout.Stretch;
            numeroLbl.Text = "?";
            groupBox1.Visible = true;
        }


        /*public int RealizarJugada(int pos, string jugadorjugada)
        {
            int acertado = 0;
            int puntuacionmax =0;
            this.puntuacionmax = puntuacionmax;

            pos = cont - 1;
            posgris = contgris - 1;
            posazul = contazul - 1;
            posnaranja = contnaranja - 1;



            if ((cont - 1) == 1)
            {
                var result = MessageBox.Show("¿La mano es la  parte del cuerpo tiene veinte y siete huesos y treinta y cinco músculos?", "Titulo del Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    Puntos = Puntos + 5;
                    acertado = 1;
                    this.Close();

                }
                else
                    this.Close();
            }


            if ((cont - 1) == 2)
            {
                var result2 = MessageBox.Show("¿HCL es la fórmula química del ácido clorhídrico?", "Titulo del Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result2 == DialogResult.Yes)
                {
                    Puntos = Puntos + 5;
                    acertado = 1;
                    this.Close();

                }

                else
                    this.Close();
            }

            if ((cont - 1) == 3)
            {
                var result21 = MessageBox.Show("¿trescientas  personas podrían morir por un solo gramo de veneno de la cobra?", "Titulo del Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result21 == DialogResult.Yes)
                {
                    Puntos = Puntos + 5;
                    acertado = 1;
                    this.Close();
                }


                else
                    this.Close();
            }

            if ((cont - 1) == 4)
            {
                var result4 = MessageBox.Show("¿Diez  equivale al dieciseis en hexadecimal?", "Titulo del Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result4 == DialogResult.Yes)
                {
                    Puntos = Puntos + 5;
                    acertado = 1;
                    this.Close();
                }


                else
                    this.Close();
            }

            if ((cont - 1) == 5)
            {
                var result5 = MessageBox.Show("¿Treinta i tres  vertebras forman la columna vertebral humana?", "Titulo del Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result5 == DialogResult.Yes)
                {
                    Puntos = Puntos + 5;
                    acertado = 1;
                    this.Close();
                }


                else
                    this.Close();
            }

            if ((cont - 1) == 6)
            {
                var result6 = MessageBox.Show("¿Gracias al oido  puedes descodificar vibraciones en el aire?", "Titulo del Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result6 == DialogResult.Yes)
                {
                    Puntos = Puntos + 5;
                    acertado = 1;
                    this.Close();
                }


                else
                    this.Close();
            }

            if ((cont - 1) == 7)
            {
                var result7 = MessageBox.Show("¿Los aracnidos tienen ocho patas?", "Titulo del Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result7 == DialogResult.Yes)
                {
                    Puntos = Puntos + 5;
                    acertado = 1;
                    this.Close();
                }


                else
                    this.Close();
            }

            if ((cont - 1) == 8)
            {
                var result8 = MessageBox.Show("¿ciento veinte minutos es la duración tiene un partido de fútbol que llega a la tanda de penaltis?", "Titulo del Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result8 == DialogResult.Yes)
                {
                    Puntos = Puntos + 5;
                    acertado = 1;
                    this.Close();
                }


                else
                    this.Close();
            }

            if ((cont - 1) == 9)
            {
                var result9 = MessageBox.Show("Aitor Osa es un famoso waterpolista?", "Titulo del Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result9 == DialogResult.Yes)
                {
                    Puntos = Puntos + 5;
                    acertado = 1;
                    this.Close();
                }


                else
                    this.Close();
            }

            if ((cont - 1) == 10)
            {
                var result10 = MessageBox.Show("¿ Alexis Sanchez  fue el primer jugador que recibió la distinción de Mejor Jugador del Siglo?", "Titulo del Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result10 == DialogResult.Yes)
                {
                    Puntos = Puntos + 5;
                    acertado = 1;
                    this.Close();
                }


                else
                    this.Close();
            }

            if ((cont - 1) == 11)
            {
                var result11 = MessageBox.Show("¿ Touchdown es Cómo se llama la anotación de un tanto en el fútbol americano?", "Titulo del Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result11 == DialogResult.Yes)
                {
                    Puntos = Puntos + 5;
                    acertado = 1;
                    this.Close();
                }


                else
                    this.Close();
            }

            if ((cont - 1) == 12)
            {
                var result12 = MessageBox.Show("¿ una pierna es lo qué perdió el soldadito de plomo?", "Titulo del Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result12 == DialogResult.Yes)
                {
                    Puntos = Puntos + 5;
                    acertado = 1;
                    this.Close();
                }

                else
                    this.Close();
            }

            if ((cont - 1) == 13)
            {
                var result13 = MessageBox.Show("¿ Brasil fue el pais En qué  nació Jorge Luis Borges?", "Titulo del Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result13 == DialogResult.No)
                {
                    Puntos = Puntos + 5;
                    acertado = 1;
                    this.Close();
                }


                else
                    this.Close();
            }

            if ((cont - 1) == 14)
            {
                var result14 = MessageBox.Show("¿Dalí pintó Los relojes derretidos?", "Titulo del Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result14 == DialogResult.Yes)
                {
                    Puntos = Puntos + 5;
                    acertado = 1;
                    this.Close();
                }


                else
                    this.Close();
            }

            if ((cont - 1) == 15)
            {
                var result15 = MessageBox.Show("¿ Dumas es el apellido del escritor del Conde de Montecristo?", "Titulo del Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result15 == DialogResult.Yes)
                {
                    Puntos = Puntos + 5;
                    acertado = 1;
                    this.Close();
                }


                else
                    this.Close();
            }

            if ((cont - 1) == 16)
            {
                var result16 = MessageBox.Show("¿Naruto es el primer super saiyajin que se convierte en dios?", "Titulo del Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result16 == DialogResult.No)
                {
                    Puntos = Puntos + 5;
                    acertado = 1;
                    this.Close();
                }


                else
                    this.Close();
            }

            if ((cont - 1) == 17)
            {
                var result17 = MessageBox.Show("¿AC/DC es grupo musical  que cantaba Mamma Mía?", "Titulo del Mensaje", MessageBoxButtons.YesNo);
                if (result17 == DialogResult.No)
                {
                    Puntos = Puntos + 5;
                    acertado = 1;
                    this.Close();
                }


                else
                    this.Close();
            }

            if ((cont - 1) == 18)
            {
                var result18 = MessageBox.Show("¿ Aliya Mustafina és una gimnasta Rusa?", "Titulo del Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result18 == DialogResult.Yes)
                {
                    Puntos = Puntos + 5;
                    acertado = 1;
                    this.Close();
                }


                else
                    this.Close();
            }

            if ((cont - 1) == 19)
            {
                var result19 = MessageBox.Show("¿ Luigi es Cómo se llama el hermano menor de Mario Bros?", "Titulo del Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result19 == DialogResult.Yes)
                {
                    Puntos = Puntos + 5;
                    acertado = 1;
                    this.Close();
                }


                else
                    this.Close();
            }

            if ((cont - 1) == 20)
            {
                var result20 = MessageBox.Show("¿Botones es Cómo se llama el amigo inseparable de Dora la Exploradora?", "Titulo del Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result20 == DialogResult.No)
                {
                    Puntos = Puntos + 5;
                    acertado = 1;
                    this.Close();
                }


                else
                    this.Close();
            }

            if ((cont - 1) == 21)
            {
                var result21 = MessageBox.Show("¿Rusia  es famoso por su October Fest?", "Titulo del Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result21 == DialogResult.No)
                {
                    Puntos = Puntos + 5;
                    acertado = 1;
                    this.Close();
                }


                else
                    this.Close();
            }

            if ((cont - 1) == 22)
            {
                var result22 = MessageBox.Show("¿Turin es la ciudad de la que proviene el equipo de fútbol Juventus?", "Titulo del Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result22 == DialogResult.Yes)
                {
                    Puntos = Puntos + 5;
                    acertado = 1;
                    this.Close();
                }


                else
                    this.Close();
            }

            if ((cont - 1) == 23)
            {
                var result23 = MessageBox.Show("¿Argentina es dónde se encuentra la Cueva del Milodón?", "Titulo del Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result23 == DialogResult.No)
                {
                    Puntos = Puntos + 5;
                    acertado = 1;
                    this.Close();
                }


                else
                    this.Close();
            }

            if ((cont - 1) == 24)
            {
                var result24 = MessageBox.Show("¿Desde Barcelona  puedes ver el monte llamado Mujer Muerta Jebel Musa?", "Titulo del Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result24 == DialogResult.No)
                {
                    Puntos = Puntos + 5;
                    acertado = 1;
                    this.Close();
                }

                else
                    this.Close();
            }

            if ((cont - 1) == 25)
            {
                var result25 = MessageBox.Show("¿París es Dónde está el palacio de Versalles?", "Titulo del Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result25 == DialogResult.Yes)
                {
                    Puntos = Puntos + 5;
                    acertado = 1;
                    this.Close();
                }

                else
                    this.Close();
            }

            if ((cont - 1) == 26)
            {
                var result26 = MessageBox.Show("¿turquia  es el nombre actual del antiguo Imperio Otomano?", "Titulo del Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result26 == DialogResult.Yes)
                {
                    Puntos = Puntos + 5;
                    acertado = 1;
                    this.Close();
                }

                else
                    this.Close();
            }

            if ((cont - 1) == 27)
            {
                var result27 = MessageBox.Show("¿Atenea es la diosa  a la que está dedicado el Partenón?", "Titulo del Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result27 == DialogResult.Yes)
                {
                    Puntos = Puntos + 5;
                    acertado = 1;
                    this.Close();
                }

                else
                    this.Close();
            }

            if ((cont - 1) == 28)
            {
                var result28 = MessageBox.Show("¿Dartañan es Cómo se llama el burro de Sancho Panza?", "Titulo del Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result28 == DialogResult.No)
                {
                    Puntos = Puntos + 5;
                    acertado = 1;
                    this.Close();
                }

                else
                    this.Close();
            }

            if ((cont - 1) == 29)
            {
                var result29 = MessageBox.Show("¿Cadiz es la ciudad en qué  se promulgó la  primera constitución española?", "Titulo del Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result29 == DialogResult.Yes)
                {
                    Puntos = Puntos + 5;
                    acertado = 1;
                    this.Close();
                }

                else
                    this.Close();
            }

            if ((cont - 1) == 30)
            {
                var result30 = MessageBox.Show("¿Madrid es la  ciudad española en la que  tuvo lugar el motín de Godoy?", "Titulo del Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result30 == DialogResult.No)
                {
                    Puntos = Puntos + 5;
                    acertado = 1;
                    this.Close();
                }

                else
                    this.Close();
            }

            if ((cont - 1) == 31)
            {
                var result31 = MessageBox.Show("¿dos a la siete da los mismo que siete al quadrado?", "Titulo del Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result31 == DialogResult.No)
                {
                    Puntos = Puntos + 5;
                    acertado = 1;
                    this.Close();
                }

                else
                    this.Close();
            }

            if ((cont - 1) == 32)
            {
                var result32 = MessageBox.Show(" La propiedad commutativa es una propiedad de la suma?", "Titulo del Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result32 == DialogResult.No)
                {
                    Puntos = Puntos + 5;
                    acertado = 1;
                    this.Close();
                }

                else
                    this.Close();
            }

            if ((cont - 1) == 33)
            {
                var result33 = MessageBox.Show("¿Sheldon Cooper es el nombre de uno de los personajes principales de the big bang theory?", "Titulo del Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result33 == DialogResult.Yes)
                {
                    Puntos = Puntos + 5;
                    acertado = 1;
                    this.Close();
                }

                else
                    this.Close();
            }

            if ((cont - 1) == 34)
            {
                var result34 = MessageBox.Show("¿Kratos es el protagonista de la saga de dragon ball?", "Titulo del Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result34 == DialogResult.No)
                {
                    Puntos = Puntos + 5;
                    acertado = 1;
                    this.Close();
                }

                else
                    this.Close();
            }

            if ((cont - 1) == 35)
            {
                var result35 = MessageBox.Show("¿España gano el mundial en sudafrica?", "Titulo del Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result35 == DialogResult.Yes)
                {
                    Puntos = Puntos + 5;
                    this.Close();
                    acertado = 1;
                }

                else
                    this.Close();
            }

            if ((cont - 1) == 36)
            {
                var result36 = MessageBox.Show("¿Ariel Winter es la actriz de alex dunphy en modern family?", "Titulo del Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result36 == DialogResult.Yes)
                {
                    Puntos = Puntos + 5;
                    acertado = 1;
                    this.Close();
                }

                else
                    this.Close();
            }

            if ((cont - 1) == 37)
            {
                var result37 = MessageBox.Show("¿Fifa es el juego del qual messi fue portada en dos mil quinze?", "Titulo del Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result37 == DialogResult.Yes)
                {
                    Puntos = Puntos + 5;
                    acertado = 1;
                    this.Close();
                }

                else
                    this.Close();
            }

            if ((cont - 1) == 38)
            {
                var result38 = MessageBox.Show("¿Axel Blaze es el protagonista de las primeras temporadas de inazuma eleven?", "Titulo del Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result38 == DialogResult.No)
                {
                    Puntos = Puntos + 5;
                    acertado = 1;
                    this.Close();
                }

                else
                    this.Close();
            }

            if ((cont - 1) == 39)
            {
                var result39 = MessageBox.Show("¿Tu suegra es la madre de tu pareja?", "Titulo del Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result39 == DialogResult.Yes)
                {
                    Puntos = Puntos + 5;
                    acertado = 1;
                    this.Close();
                }

                else
                    this.Close();
            }

            if ((cont - 1) == 40)
            {
                var result40 = MessageBox.Show("¿EL padre de tu abuelo es tu bisabuelo?", "Titulo del Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result40 == DialogResult.Yes)
                {
                    Puntos = Puntos + 5;
                    acertado = 1;
                    this.Close();
                }

                else
                    this.Close();
            }

            puntuacionmax = puntuacionmax + Puntos;
            if (acertado == 1)
            {
                preguntasacertadas = preguntasacertadas + 1;
                if (preguntasacertadas == 10)
                {
                    MessageBox.Show("Fin de la partida, ha ganado " + ganador + " con " + puntuacionmax + " puntos");
                }
            }
            else if (acertado == 0)
            {
                System.Threading.Thread.Sleep(3000);

            }

        }

       /* private void EnviarJugada(string carta1, string carta2, string pos1, int acertado)
        {
            if (acertado == 1)
            {
                puntos = puntos + 5;
          
                preguntasacertadas = preguntasacertadas + 1;
                //label7.Text = "Tus puntos: " + puntos;

                if (puntos > puntuacionmax)
                {
                    puntuacionmax = puntos;
                    ganador = Tu;

                    //label9.Text = ganador;
                    //  label12.Text = Convert.ToString(puntuacionmax);
                }

                string mensaje = "11/" + nForm + "/" + Tu + "/" + id + "/" + pos1 + "/" + "1" + "/" + puntuacionmax + "/" + ganador;
                // Enviamos al servidor el mensaje
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
                System.Threading.Thread.Sleep(500);
                //this.IniciarPartida();

            }
            else
            {
                string mensaje = "11/" + nForm + "/" + Tu + "/" + id + "/" + pos1 + "/" + "0" + "/" + puntuacionmax + "/" + ganador;

                // Enviamos al servidor el mensaje
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
                System.Threading.Thread.Sleep(500);
                //this.IniciarPartida();
            }

            if (preguntasacertadas == 10)
            {
                MessageBox.Show("Fin de la partida, ha ganado " + ganador + " con " + puntuacionmax + " puntos");
            }

        }
        */

        private void tablero_MouseMove(object sender, MouseEventArgs e)
        {
            label2.Text = e.X.ToString() + "," + e.Y.ToString();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void turnoLbl_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (invitados[turno] != Tu)
            {
                MessageBox.Show("No es tu turno");
            }
            else
            {
                numeroLbl.Text = "?";
                timer1.Interval = 1000;
                timer1.Start();
                int num = timer1_Tick(sender, e);
                string mensaje = "11/" + nForm + "/" + Tu + "/" + id + "/" + num;
                // Enviamos al servidor el mensaje
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
                //System.Threading.Thread.Sleep(500);
            }
        }

        private int timer1_Tick(object sender, EventArgs e)
        {
            int num = rand.Next(1, 7);
            numeroLbl.Text = num.ToString();

            timer1.Stop();
            if (invitados[turno] == Jugador1)
            {
                cont = cont + num;
                if (cont > 40)
                {
                    cont = cont - 40;
                }

                amarilloLbl.Location = posiciones[cont - 1];
            }
            if (invitados[turno] == Jugador2)
            {
                contgris = contgris + num;
                if (contgris > 40)
                {
                    contgris = contgris - 40;
                }

                gris.Location = posicionesgris[contgris - 1];
            }

            if (invitados[turno] == Jugador3)
            {
                contazul = contazul + num;
                if (contazul > 40)
                {
                    contazul = contazul - 40;
                }

                azul.Location = posicionesazul[contazul - 1];
            }

            if (invitados[turno] == Jugador4)
            {
                contnaranja = contnaranja + num;
                if (contnaranja > 40)
                {
                    contnaranja = contnaranja - 40;
                }

                naranja.Location = posicionesnaranja[contnaranja - 1];

            }
            turno = (turno + 1) % 4;
            turnoLbl.Text = invitados[turno];
            return num;
        }

        public void recibirJugada(string nombreJugador, int num)
        {
            timer1.Stop();
            if (nombreJugador == Jugador1)
            {
                cont = cont + num;
                if (cont > 40)
                {
                    cont = cont - 40;
                }

                amarilloLbl.Location = posiciones[cont - 1];
            }
            if (nombreJugador == Jugador2)
            {
                contgris = contgris + num;
                if (contgris > 40)
                {
                    contgris = contgris - 40;
                }

                gris.Location = posicionesgris[contgris - 1];
            }

            if (nombreJugador == Jugador3)
            {
                contazul = contazul + num;
                if (contazul > 40)
                {
                    contazul = contazul - 40;
                }

                azul.Location = posicionesazul[contazul - 1];
            }

            if (nombreJugador == Jugador4)
            {
                contnaranja = contnaranja + num;
                if (contnaranja > 40)
                {
                    contnaranja = contnaranja - 40;
                }

                naranja.Location = posicionesnaranja[contnaranja - 1];

            }
            turno = (turno + 1) % 4;
            turnoLbl.Text = invitados[turno];
        }



        private void azul_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void tablero_Paint(object sender, PaintEventArgs e)
        {

        }

    }
   

}
     
    
