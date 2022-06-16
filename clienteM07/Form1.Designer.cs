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
            this.BoxForm1 = new System.Windows.Forms.GroupBox();
            this.BotonInvitar2 = new System.Windows.Forms.Button();
            this.GridConectados = new System.Windows.Forms.DataGridView();
            this.Jugador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Conectados = new System.Windows.Forms.Label();
            this.ListaConectados = new System.Windows.Forms.Label();
            this.BotonChatear = new System.Windows.Forms.Button();
            this.NOMBREAUXILIAR = new System.Windows.Forms.Label();
            this.nombre2 = new System.Windows.Forms.TextBox();
            this.botonRegistrarse = new System.Windows.Forms.Button();
            this.BotonLogIn = new System.Windows.Forms.Button();
            this.tablero_posiciones = new System.Windows.Forms.RadioButton();
            this.mejor_escenario = new System.Windows.Forms.RadioButton();
            this.ESCENARIOJUNTOS = new System.Windows.Forms.RadioButton();
            this.numero_victoria = new System.Windows.Forms.RadioButton();
            this.contrasenya = new System.Windows.Forms.TextBox();
            this.contraseña = new System.Windows.Forms.Label();
            this.nombre = new System.Windows.Forms.TextBox();
            this.botonConsulta = new System.Windows.Forms.Button();
            this.Desconexion = new System.Windows.Forms.Button();
            this.botonConectarme = new System.Windows.Forms.Button();
            this.usuario = new System.Windows.Forms.Label();
            this.BoxForm1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridConectados)).BeginInit();
            this.SuspendLayout();
            // 
            // BoxForm1
            // 
            this.BoxForm1.Controls.Add(this.BotonInvitar2);
            this.BoxForm1.Controls.Add(this.GridConectados);
            this.BoxForm1.Controls.Add(this.Conectados);
            this.BoxForm1.Controls.Add(this.ListaConectados);
            this.BoxForm1.Controls.Add(this.BotonChatear);
            this.BoxForm1.Controls.Add(this.NOMBREAUXILIAR);
            this.BoxForm1.Controls.Add(this.nombre2);
            this.BoxForm1.Controls.Add(this.botonRegistrarse);
            this.BoxForm1.Controls.Add(this.BotonLogIn);
            this.BoxForm1.Controls.Add(this.tablero_posiciones);
            this.BoxForm1.Controls.Add(this.mejor_escenario);
            this.BoxForm1.Controls.Add(this.ESCENARIOJUNTOS);
            this.BoxForm1.Controls.Add(this.numero_victoria);
            this.BoxForm1.Controls.Add(this.contrasenya);
            this.BoxForm1.Controls.Add(this.contraseña);
            this.BoxForm1.Controls.Add(this.nombre);
            this.BoxForm1.Controls.Add(this.botonConsulta);
            this.BoxForm1.Controls.Add(this.Desconexion);
            this.BoxForm1.Controls.Add(this.botonConectarme);
            this.BoxForm1.Controls.Add(this.usuario);
            this.BoxForm1.Location = new System.Drawing.Point(12, 12);
            this.BoxForm1.Name = "BoxForm1";
            this.BoxForm1.Size = new System.Drawing.Size(751, 650);
            this.BoxForm1.TabIndex = 0;
            this.BoxForm1.TabStop = false;
            this.BoxForm1.Text = "Nobody\'s Table";
            this.BoxForm1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // BotonInvitar2
            // 
            this.BotonInvitar2.Location = new System.Drawing.Point(578, 406);
            this.BotonInvitar2.Name = "BotonInvitar2";
            this.BotonInvitar2.Size = new System.Drawing.Size(135, 36);
            this.BotonInvitar2.TabIndex = 31;
            this.BotonInvitar2.Text = "Invitar Jugador/es";
            this.BotonInvitar2.UseVisualStyleBackColor = true;
            this.BotonInvitar2.Click += new System.EventHandler(this.BotonInvitar2_Click);
            // 
            // GridConectados
            // 
            this.GridConectados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Jugador});
            this.GridConectados.Location = new System.Drawing.Point(459, 280);
            this.GridConectados.Name = "GridConectados";
            this.GridConectados.Size = new System.Drawing.Size(254, 120);
            this.GridConectados.TabIndex = 30;
            this.GridConectados.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridConectados_CellContentClick);
            // 
            // Jugador
            // 
            this.Jugador.HeaderText = "Jugador";
            this.Jugador.Name = "Jugador";
            // 
            // Conectados
            // 
            this.Conectados.AutoSize = true;
            this.Conectados.Location = new System.Drawing.Point(456, 248);
            this.Conectados.Name = "Conectados";
            this.Conectados.Size = new System.Drawing.Size(87, 17);
            this.Conectados.TabIndex = 16;
            this.Conectados.Text = "Conectados:";
            this.Conectados.Click += new System.EventHandler(this.label1_Click_2);
            // 
            // ListaConectados
            // 
            this.ListaConectados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ListaConectados.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListaConectados.Location = new System.Drawing.Point(26, 433);
            this.ListaConectados.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ListaConectados.Name = "ListaConectados";
            this.ListaConectados.Size = new System.Drawing.Size(197, 113);
            this.ListaConectados.TabIndex = 13;
            // 
            // BotonChatear
            // 
            this.BotonChatear.Location = new System.Drawing.Point(457, 406);
            this.BotonChatear.Name = "BotonChatear";
            this.BotonChatear.Size = new System.Drawing.Size(102, 36);
            this.BotonChatear.TabIndex = 15;
            this.BotonChatear.Text = "chatear";
            this.BotonChatear.UseVisualStyleBackColor = true;
            this.BotonChatear.Click += new System.EventHandler(this.Aceptar_Click);
            // 
            // NOMBREAUXILIAR
            // 
            this.NOMBREAUXILIAR.AutoSize = true;
            this.NOMBREAUXILIAR.Location = new System.Drawing.Point(456, 45);
            this.NOMBREAUXILIAR.Name = "NOMBREAUXILIAR";
            this.NOMBREAUXILIAR.Size = new System.Drawing.Size(133, 17);
            this.NOMBREAUXILIAR.TabIndex = 14;
            this.NOMBREAUXILIAR.Text = "NOMBRE AUXILIAR";
            // 
            // nombre2
            // 
            this.nombre2.Location = new System.Drawing.Point(595, 45);
            this.nombre2.Name = "nombre2";
            this.nombre2.Size = new System.Drawing.Size(134, 22);
            this.nombre2.TabIndex = 13;
            // 
            // botonRegistrarse
            // 
            this.botonRegistrarse.Location = new System.Drawing.Point(166, 214);
            this.botonRegistrarse.Name = "botonRegistrarse";
            this.botonRegistrarse.Size = new System.Drawing.Size(120, 51);
            this.botonRegistrarse.TabIndex = 12;
            this.botonRegistrarse.Text = "Registrarse";
            this.botonRegistrarse.UseVisualStyleBackColor = true;
            this.botonRegistrarse.Click += new System.EventHandler(this.Registro_Click);
            // 
            // BotonLogIn
            // 
            this.BotonLogIn.Location = new System.Drawing.Point(26, 214);
            this.BotonLogIn.Name = "BotonLogIn";
            this.BotonLogIn.Size = new System.Drawing.Size(120, 51);
            this.BotonLogIn.TabIndex = 11;
            this.BotonLogIn.Text = "Log In";
            this.BotonLogIn.UseVisualStyleBackColor = true;
            this.BotonLogIn.Click += new System.EventHandler(this.LogIn_Click);
            // 
            // tablero_posiciones
            // 
            this.tablero_posiciones.AutoSize = true;
            this.tablero_posiciones.Location = new System.Drawing.Point(457, 154);
            this.tablero_posiciones.Name = "tablero_posiciones";
            this.tablero_posiciones.Size = new System.Drawing.Size(170, 21);
            this.tablero_posiciones.TabIndex = 10;
            this.tablero_posiciones.TabStop = true;
            this.tablero_posiciones.Text = "Tablero de Posiciones";
            this.tablero_posiciones.UseVisualStyleBackColor = true;
            // 
            // mejor_escenario
            // 
            this.mejor_escenario.AutoSize = true;
            this.mejor_escenario.Location = new System.Drawing.Point(457, 127);
            this.mejor_escenario.Name = "mejor_escenario";
            this.mejor_escenario.Size = new System.Drawing.Size(131, 21);
            this.mejor_escenario.TabIndex = 9;
            this.mejor_escenario.TabStop = true;
            this.mejor_escenario.Text = "Mejor Escenario";
            this.mejor_escenario.UseVisualStyleBackColor = true;
            this.mejor_escenario.CheckedChanged += new System.EventHandler(this.P3_CheckedChanged);
            // 
            // ESCENARIOJUNTOS
            // 
            this.ESCENARIOJUNTOS.AutoSize = true;
            this.ESCENARIOJUNTOS.Location = new System.Drawing.Point(457, 100);
            this.ESCENARIOJUNTOS.Name = "ESCENARIOJUNTOS";
            this.ESCENARIOJUNTOS.Size = new System.Drawing.Size(145, 21);
            this.ESCENARIOJUNTOS.TabIndex = 8;
            this.ESCENARIOJUNTOS.TabStop = true;
            this.ESCENARIOJUNTOS.Text = "Escenarios Juntos";
            this.ESCENARIOJUNTOS.UseVisualStyleBackColor = true;
            // 
            // numero_victoria
            // 
            this.numero_victoria.AutoSize = true;
            this.numero_victoria.Location = new System.Drawing.Point(459, 73);
            this.numero_victoria.Name = "numero_victoria";
            this.numero_victoria.Size = new System.Drawing.Size(157, 21);
            this.numero_victoria.TabIndex = 7;
            this.numero_victoria.TabStop = true;
            this.numero_victoria.Text = "Numero de Victorias";
            this.numero_victoria.UseVisualStyleBackColor = true;
            // 
            // contrasenya
            // 
            this.contrasenya.Location = new System.Drawing.Point(114, 170);
            this.contrasenya.Name = "contrasenya";
            this.contrasenya.Size = new System.Drawing.Size(127, 22);
            this.contrasenya.TabIndex = 6;
            this.contrasenya.TextChanged += new System.EventHandler(this.contrasenya_TextChanged);
            // 
            // contraseña
            // 
            this.contraseña.AutoSize = true;
            this.contraseña.Location = new System.Drawing.Point(23, 170);
            this.contraseña.Name = "contraseña";
            this.contraseña.Size = new System.Drawing.Size(85, 17);
            this.contraseña.TabIndex = 5;
            this.contraseña.Text = "Contraseña:";
            // 
            // nombre
            // 
            this.nombre.Location = new System.Drawing.Point(114, 132);
            this.nombre.Name = "nombre";
            this.nombre.Size = new System.Drawing.Size(127, 22);
            this.nombre.TabIndex = 4;
            // 
            // botonConsulta
            // 
            this.botonConsulta.Location = new System.Drawing.Point(459, 181);
            this.botonConsulta.Name = "botonConsulta";
            this.botonConsulta.Size = new System.Drawing.Size(106, 47);
            this.botonConsulta.TabIndex = 3;
            this.botonConsulta.Text = "enviar";
            this.botonConsulta.UseVisualStyleBackColor = true;
            this.botonConsulta.Click += new System.EventHandler(this.Consulta_Click);
            // 
            // Desconexion
            // 
            this.Desconexion.Location = new System.Drawing.Point(144, 45);
            this.Desconexion.Name = "Desconexion";
            this.Desconexion.Size = new System.Drawing.Size(118, 52);
            this.Desconexion.TabIndex = 2;
            this.Desconexion.Text = "Desconectarme";
            this.Desconexion.UseVisualStyleBackColor = true;
            this.Desconexion.Click += new System.EventHandler(this.Desconexion_Click);
            // 
            // botonConectarme
            // 
            this.botonConectarme.Location = new System.Drawing.Point(26, 45);
            this.botonConectarme.Name = "botonConectarme";
            this.botonConectarme.Size = new System.Drawing.Size(103, 52);
            this.botonConectarme.TabIndex = 1;
            this.botonConectarme.Text = "Conectarme";
            this.botonConectarme.UseVisualStyleBackColor = true;
            this.botonConectarme.Click += new System.EventHandler(this.Conexion_Click);
            // 
            // usuario
            // 
            this.usuario.AutoSize = true;
            this.usuario.Location = new System.Drawing.Point(44, 132);
            this.usuario.Name = "usuario";
            this.usuario.Size = new System.Drawing.Size(61, 17);
            this.usuario.TabIndex = 0;
            this.usuario.Text = "Usuario:";
            this.usuario.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(776, 672);
            this.Controls.Add(this.BoxForm1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.BoxForm1.ResumeLayout(false);
            this.BoxForm1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridConectados)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox BoxForm1;
        private System.Windows.Forms.TextBox contrasenya;
        private System.Windows.Forms.Label contraseña;
        private System.Windows.Forms.TextBox nombre;
        private System.Windows.Forms.Button botonConsulta;
        private System.Windows.Forms.Button Desconexion;
        private System.Windows.Forms.Button botonConectarme;
        private System.Windows.Forms.Label usuario;
        private System.Windows.Forms.Button botonRegistrarse;
        private System.Windows.Forms.Button BotonLogIn;
        private System.Windows.Forms.RadioButton tablero_posiciones;
        private System.Windows.Forms.RadioButton mejor_escenario;
        private System.Windows.Forms.RadioButton ESCENARIOJUNTOS;
        private System.Windows.Forms.RadioButton numero_victoria;
        private System.Windows.Forms.Label NOMBREAUXILIAR;
        private System.Windows.Forms.TextBox nombre2;
        private System.Windows.Forms.Label ListaConectados;
        private System.Windows.Forms.Button BotonChatear;
        private System.Windows.Forms.Label Conectados;
        private System.Windows.Forms.DataGridView GridConectados;
        private System.Windows.Forms.DataGridViewTextBoxColumn Jugador;
        private System.Windows.Forms.Button BotonInvitar2;
    }
}

