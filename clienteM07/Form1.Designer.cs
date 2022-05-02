namespace WindowsFormsApplication1
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.nombre2 = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.P4 = new System.Windows.Forms.RadioButton();
            this.P3 = new System.Windows.Forms.RadioButton();
            this.P2 = new System.Windows.Forms.RadioButton();
            this.numero_victoria = new System.Windows.Forms.RadioButton();
            this.contrasenya = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.nombre = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.contLbl = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.nombre2);
            this.groupBox1.Controls.Add(this.button5);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.P4);
            this.groupBox1.Controls.Add(this.P3);
            this.groupBox1.Controls.Add(this.P2);
            this.groupBox1.Controls.Add(this.numero_victoria);
            this.groupBox1.Controls.Add(this.contrasenya);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.nombre);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(735, 406);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "PETICION";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 17);
            this.label3.TabIndex = 14;
            this.label3.Text = "NOMBRE AUXILIAR";
            // 
            // nombre2
            // 
            this.nombre2.Location = new System.Drawing.Point(182, 105);
            this.nombre2.Name = "nombre2";
            this.nombre2.Size = new System.Drawing.Size(156, 22);
            this.nombre2.TabIndex = 13;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(232, 166);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(128, 60);
            this.button5.TabIndex = 12;
            this.button5.Text = "Registrarse";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(62, 175);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(120, 51);
            this.button4.TabIndex = 11;
            this.button4.Text = "Log In";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // P4
            // 
            this.P4.AutoSize = true;
            this.P4.Location = new System.Drawing.Point(432, 244);
            this.P4.Name = "P4";
            this.P4.Size = new System.Drawing.Size(170, 21);
            this.P4.TabIndex = 10;
            this.P4.TabStop = true;
            this.P4.Text = "Tablero de Posiciones";
            this.P4.UseVisualStyleBackColor = true;
            // 
            // P3
            // 
            this.P3.AutoSize = true;
            this.P3.Location = new System.Drawing.Point(429, 205);
            this.P3.Name = "P3";
            this.P3.Size = new System.Drawing.Size(131, 21);
            this.P3.TabIndex = 9;
            this.P3.TabStop = true;
            this.P3.Text = "Mejor Escenario";
            this.P3.UseVisualStyleBackColor = true;
            this.P3.CheckedChanged += new System.EventHandler(this.P3_CheckedChanged);
            // 
            // P2
            // 
            this.P2.AutoSize = true;
            this.P2.Location = new System.Drawing.Point(427, 167);
            this.P2.Name = "P2";
            this.P2.Size = new System.Drawing.Size(145, 21);
            this.P2.TabIndex = 8;
            this.P2.TabStop = true;
            this.P2.Text = "Escenarios Juntos";
            this.P2.UseVisualStyleBackColor = true;
            // 
            // numero_victoria
            // 
            this.numero_victoria.AutoSize = true;
            this.numero_victoria.Location = new System.Drawing.Point(420, 122);
            this.numero_victoria.Name = "numero_victoria";
            this.numero_victoria.Size = new System.Drawing.Size(157, 21);
            this.numero_victoria.TabIndex = 7;
            this.numero_victoria.TabStop = true;
            this.numero_victoria.Text = "Numero de Victorias";
            this.numero_victoria.UseVisualStyleBackColor = true;
            // 
            // contrasenya
            // 
            this.contrasenya.Location = new System.Drawing.Point(527, 53);
            this.contrasenya.Name = "contrasenya";
            this.contrasenya.Size = new System.Drawing.Size(195, 22);
            this.contrasenya.TabIndex = 6;
            this.contrasenya.TextChanged += new System.EventHandler(this.contrasenya_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(409, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Contraseña";
            // 
            // nombre
            // 
            this.nombre.Location = new System.Drawing.Point(126, 57);
            this.nombre.Name = "nombre";
            this.nombre.Size = new System.Drawing.Size(223, 22);
            this.nombre.TabIndex = 4;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(437, 297);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(106, 47);
            this.button3.TabIndex = 3;
            this.button3.Text = "enviar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(217, 292);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(143, 57);
            this.button2.TabIndex = 2;
            this.button2.Text = "DESCONECTAR";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(47, 292);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(144, 64);
            this.button1.TabIndex = 1;
            this.button1.Text = "CONECTAR";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "NOMBRE";
            // 
            // contLbl
            // 
            this.contLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.contLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contLbl.Location = new System.Drawing.Point(765, 305);
            this.contLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.contLbl.Name = "contLbl";
            this.contLbl.Size = new System.Drawing.Size(197, 113);
            this.contLbl.TabIndex = 13;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(993, 493);
            this.Controls.Add(this.contLbl);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox contrasenya;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nombre;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.RadioButton P4;
        private System.Windows.Forms.RadioButton P3;
        private System.Windows.Forms.RadioButton P2;
        private System.Windows.Forms.RadioButton numero_victoria;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox nombre2;
        private System.Windows.Forms.Label contLbl;
    }
}

