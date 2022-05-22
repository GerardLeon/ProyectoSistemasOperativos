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
            posiciones.Add(new Point(50, 35));
            posiciones.Add(new Point(142, 35));
            posiciones.Add(new Point(208, 35));
            posiciones.Add(new Point(276, 35));
            posiciones.Add(new Point(345, 35));
            posiciones.Add(new Point(407, 35));
            posiciones.Add(new Point(476, 35));
            posiciones.Add(new Point(539, 35));
            posiciones.Add(new Point(604, 35));
            posiciones.Add(new Point(670, 35));
            posiciones.Add(new Point(760, 35));
            posiciones.Add(new Point(760, 111));
            posiciones.Add(new Point(760, 163));
            posiciones.Add(new Point(760, 217));
            posiciones.Add(new Point(760, 272));
            posiciones.Add(new Point(760, 325));
            posiciones.Add(new Point(760, 381));
            posiciones.Add(new Point(760, 431));
            posiciones.Add(new Point(760, 385));
            posiciones.Add(new Point(760, 539));
            posiciones.Add(new Point(760, 610));

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
