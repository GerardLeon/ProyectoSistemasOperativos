namespace InterfazJuego
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tablero = new System.Windows.Forms.Panel();
            this.amarilloLbl = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.numeroLbl = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.conectadosGrid = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.invitadosBox = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.turnoLbl = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tablero.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.conectadosGrid)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tablero
            // 
            this.tablero.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tablero.BackgroundImage")));
            this.tablero.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tablero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tablero.Controls.Add(this.amarilloLbl);
            this.tablero.Location = new System.Drawing.Point(139, 10);
            this.tablero.Name = "tablero";
            this.tablero.Size = new System.Drawing.Size(826, 677);
            this.tablero.TabIndex = 0;
            this.tablero.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tablero_MouseMove);
            // 
            // amarilloLbl
            // 
            this.amarilloLbl.BackColor = System.Drawing.Color.Yellow;
            this.amarilloLbl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.amarilloLbl.Location = new System.Drawing.Point(675, 534);
            this.amarilloLbl.Name = "amarilloLbl";
            this.amarilloLbl.Size = new System.Drawing.Size(28, 29);
            this.amarilloLbl.TabIndex = 0;
            this.amarilloLbl.Click += new System.EventHandler(this.amarilloLbl_Click);
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Location = new System.Drawing.Point(767, 704);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(118, 91);
            this.button1.TabIndex = 1;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(82, 609);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 2;
            // 
            // numeroLbl
            // 
            this.numeroLbl.BackColor = System.Drawing.Color.Transparent;
            this.numeroLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numeroLbl.ForeColor = System.Drawing.Color.White;
            this.numeroLbl.Location = new System.Drawing.Point(947, 704);
            this.numeroLbl.Name = "numeroLbl";
            this.numeroLbl.Size = new System.Drawing.Size(91, 91);
            this.numeroLbl.TabIndex = 3;
            this.numeroLbl.Text = "0";
            this.numeroLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(49, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "label2";
            // 
            // conectadosGrid
            // 
            this.conectadosGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.conectadosGrid.ColumnHeadersVisible = false;
            this.conectadosGrid.Location = new System.Drawing.Point(12, 55);
            this.conectadosGrid.Name = "conectadosGrid";
            this.conectadosGrid.RowHeadersVisible = false;
            this.conectadosGrid.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.conectadosGrid.Size = new System.Drawing.Size(103, 137);
            this.conectadosGrid.TabIndex = 4;
            this.conectadosGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.conectadosGrid_CellClick);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 26);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(103, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Dame conectados";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(154, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Partida con....";
            // 
            // invitadosBox
            // 
            this.invitadosBox.Location = new System.Drawing.Point(157, 55);
            this.invitadosBox.Multiline = true;
            this.invitadosBox.Name = "invitadosBox";
            this.invitadosBox.Size = new System.Drawing.Size(100, 100);
            this.invitadosBox.TabIndex = 8;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(157, 169);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 23);
            this.button3.TabIndex = 9;
            this.button3.Text = "Invitar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("groupBox1.BackgroundImage")));
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.turnoLbl);
            this.groupBox1.Controls.Add(this.tablero);
            this.groupBox1.Controls.Add(this.numeroLbl);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(418, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1096, 804);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Partida";
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Wide Latin", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(908, 704);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(188, 21);
            this.label6.TabIndex = 6;
            this.label6.Text = "MOVIMIENTOS";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Wide Latin", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(27, 739);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(232, 26);
            this.label5.TabIndex = 5;
            this.label5.Text = "TURNO DE:";
            // 
            // turnoLbl
            // 
            this.turnoLbl.BackColor = System.Drawing.Color.Transparent;
            this.turnoLbl.Font = new System.Drawing.Font("Showcard Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.turnoLbl.ForeColor = System.Drawing.Color.White;
            this.turnoLbl.Location = new System.Drawing.Point(279, 721);
            this.turnoLbl.Name = "turnoLbl";
            this.turnoLbl.Size = new System.Drawing.Size(324, 59);
            this.turnoLbl.TabIndex = 4;
            this.turnoLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "label4";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1609, 825);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.invitadosBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.conectadosGrid);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tablero.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.conectadosGrid)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel tablero;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label numeroLbl;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label amarilloLbl;
        private System.Windows.Forms.DataGridView conectadosGrid;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox invitadosBox;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label turnoLbl;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
    }
}

