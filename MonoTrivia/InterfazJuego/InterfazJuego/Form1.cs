using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace InterfazJuego
{
    public partial class Form1 : Form
    {
        List<Point> posiciones = new List<Point>();
        List<string> conectados = new List<string>();
        List<string> invitados = new List<string>();
        Random rand = new Random();
        int cont = 0;
        int turno = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {


            posiciones.Add(new Point(490, 655));
            posiciones.Add(new Point(490, 621));
            posiciones.Add(new Point(490, 587));
            posiciones.Add(new Point(490, 552));
            posiciones.Add(new Point(490, 519));
            posiciones.Add(new Point(490, 482));
            posiciones.Add(new Point(490, 457));
            posiciones.Add(new Point(490, 417));
            posiciones.Add(new Point(513, 391));
            posiciones.Add(new Point(558, 391));
            posiciones.Add(new Point(595, 391));
            posiciones.Add(new Point(640, 391));
            posiciones.Add(new Point(676, 391));
            posiciones.Add(new Point(717, 391));
            posiciones.Add(new Point(759, 391));
            posiciones.Add(new Point(808, 391));

            conectados.Add("Juan");
            conectados.Add("Miguel");
            conectados.Add("Gerard");
            conectados.Add("David");
            conectados.Add("Ana");
            conectados.Add("Rosa");




            tablero.BackgroundImageLayout = ImageLayout.Stretch;
            numeroLbl.Text = "?";
            groupBox1.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (invitados[turno] != "Tu")
                MessageBox.Show("No es tu turno");
            numeroLbl.Text = "?";
            timer1.Interval = 1000;
            timer1.Start();
   
        }

     
        private void timer1_Tick(object sender, EventArgs e)
        {
            int num = rand.Next(1, 7);
            numeroLbl.Text = num.ToString();
        
            timer1.Stop();
            if (invitados[turno] == "Tu")
            {

                cont = cont + num;
                amarilloLbl.Location = posiciones[cont - 1];
            }
            turno= (turno+1)%4;
            turnoLbl.Text = invitados[turno];
        }

    


        private void tablero_MouseMove(object sender, MouseEventArgs e)
        {
            label2.Text = e.X.ToString() + "," + e.Y.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conectadosGrid.ColumnCount = 1;
            conectadosGrid.RowCount = conectados.Count;
            for (int i = 0; i < conectados.Count; i++)
                conectadosGrid.Rows[i].Cells[0].Value = conectados[i];

        }

        private void conectadosGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int fila = e.RowIndex;
            invitadosBox.AppendText(conectados[fila] + Environment.NewLine);
            invitados.Add(conectados[fila]);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Aqui se pondría en marcha en protocolo de invitación. Suponemos que todos aceptan la partida");
            invitados.Add("Tu");
            turnoLbl.Text = invitados[turno];

            groupBox1.Visible = true;
            Label nombreRojo = new Label();
       
            nombreRojo.BackColor = Color.Transparent;
            nombreRojo.Font = new Font("Arial", 24, FontStyle.Bold);
            nombreRojo.Size = new Size(200, 50);
            nombreRojo.Location = new Point(106, 20);
            nombreRojo.Text = invitados[0];
            
            Label nombreVerde = new Label();

            nombreVerde.BackColor = Color.Transparent;
            nombreVerde.Font = new Font("Arial", 24, FontStyle.Bold);
            nombreVerde.Size = new Size(200, 50);
            nombreVerde.Location = new Point(637,30);
            nombreVerde.Text = invitados[1];
           

            Label nombreAzul = new Label();

            nombreAzul.BackColor = Color.Transparent;
            nombreAzul.Font = new Font("Arial", 24, FontStyle.Bold);
            nombreAzul.Size = new Size(200, 50);
            nombreAzul.Location = new Point(121, 627);
            nombreAzul.Text = invitados[2];
           

            Label nombreAmarillo = new Label();

            nombreAmarillo.BackColor = Color.Transparent;
            nombreAmarillo.Font = new Font("Arial", 24, FontStyle.Bold);
            nombreAmarillo.Size = new Size(200, 50);
            nombreAmarillo.Location = new Point(646, 637);
            nombreAmarillo.Text = invitados[3];
            
        }

       
      

     
    }
}
