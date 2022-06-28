namespace WindowsFormsApplication1
{
    partial class Form3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            this.tablero = new System.Windows.Forms.Panel();
            this.azul = new System.Windows.Forms.Label();
            this.naranja = new System.Windows.Forms.Label();
            this.gris = new System.Windows.Forms.Label();
            this.amarilloLbl = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.numeroLbl = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.turnoLbl = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tablero.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tablero
            // 
            this.tablero.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tablero.BackgroundImage")));
            this.tablero.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tablero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tablero.Controls.Add(this.azul);
            this.tablero.Controls.Add(this.naranja);
            this.tablero.Controls.Add(this.gris);
            this.tablero.Controls.Add(this.amarilloLbl);
            this.tablero.Location = new System.Drawing.Point(185, 12);
            this.tablero.Margin = new System.Windows.Forms.Padding(4);
            this.tablero.Name = "tablero";
            this.tablero.Size = new System.Drawing.Size(1101, 833);
            this.tablero.TabIndex = 0;
            this.tablero.Paint += new System.Windows.Forms.PaintEventHandler(this.tablero_Paint);
            this.tablero.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tablero_MouseMove);
            // 
            // azul
            // 
            this.azul.BackColor = System.Drawing.Color.Cyan;
            this.azul.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.azul.Location = new System.Drawing.Point(1001, 720);
            this.azul.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.azul.Name = "azul";
            this.azul.Size = new System.Drawing.Size(32, 30);
            this.azul.TabIndex = 3;
            this.azul.Click += new System.EventHandler(this.azul_Click);
            // 
            // naranja
            // 
            this.naranja.BackColor = System.Drawing.Color.DarkOrange;
            this.naranja.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.naranja.Location = new System.Drawing.Point(1041, 750);
            this.naranja.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.naranja.Name = "naranja";
            this.naranja.Size = new System.Drawing.Size(32, 30);
            this.naranja.TabIndex = 2;
            // 
            // gris
            // 
            this.gris.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.gris.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gris.Location = new System.Drawing.Point(961, 750);
            this.gris.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.gris.Name = "gris";
            this.gris.Size = new System.Drawing.Size(32, 30);
            this.gris.TabIndex = 1;
            // 
            // amarilloLbl
            // 
            this.amarilloLbl.BackColor = System.Drawing.Color.Yellow;
            this.amarilloLbl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.amarilloLbl.Location = new System.Drawing.Point(1001, 783);
            this.amarilloLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.amarilloLbl.Name = "amarilloLbl";
            this.amarilloLbl.Size = new System.Drawing.Size(32, 30);
            this.amarilloLbl.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Location = new System.Drawing.Point(1023, 866);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(157, 112);
            this.button1.TabIndex = 1;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(109, 750);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 17);
            this.label1.TabIndex = 2;
            // 
            // numeroLbl
            // 
            this.numeroLbl.BackColor = System.Drawing.Color.Transparent;
            this.numeroLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numeroLbl.ForeColor = System.Drawing.Color.White;
            this.numeroLbl.Location = new System.Drawing.Point(1263, 866);
            this.numeroLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.numeroLbl.Name = "numeroLbl";
            this.numeroLbl.Size = new System.Drawing.Size(121, 112);
            this.numeroLbl.TabIndex = 3;
            this.numeroLbl.Text = "0";
            this.numeroLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 80);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 31);
            this.label2.TabIndex = 0;
            this.label2.Text = "label2";
            this.label2.Click += new System.EventHandler(this.label2_Click);
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
            this.groupBox1.Location = new System.Drawing.Point(0, -1);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(1461, 990);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Partida";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Wide Latin", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(1211, 866);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(251, 26);
            this.label6.TabIndex = 6;
            this.label6.Text = "MOVIMIENTOS";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Wide Latin", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(36, 910);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(298, 33);
            this.label5.TabIndex = 5;
            this.label5.Text = "TURNO DE:";
            // 
            // turnoLbl
            // 
            this.turnoLbl.BackColor = System.Drawing.Color.Transparent;
            this.turnoLbl.Font = new System.Drawing.Font("Showcard Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.turnoLbl.ForeColor = System.Drawing.Color.White;
            this.turnoLbl.Location = new System.Drawing.Point(372, 887);
            this.turnoLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.turnoLbl.Name = "turnoLbl";
            this.turnoLbl.Size = new System.Drawing.Size(432, 73);
            this.turnoLbl.TabIndex = 4;
            this.turnoLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.turnoLbl.Click += new System.EventHandler(this.turnoLbl_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 985);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 13, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1464, 22);
            this.statusStrip1.TabIndex = 12;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1464, 1007);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form3";
            this.Text = "♣";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.tablero.ResumeLayout(false);
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
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label turnoLbl;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label gris;
        private System.Windows.Forms.Label azul;
        private System.Windows.Forms.Label naranja;
        private System.Windows.Forms.StatusStrip statusStrip1;
    }
}

