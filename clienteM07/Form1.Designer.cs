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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.BoxForm1 = new System.Windows.Forms.GroupBox();
            this.estadisticas = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.eliminar = new System.Windows.Forms.Button();
            this.BotonInvitar2 = new System.Windows.Forms.Button();
            this.GridConectados = new System.Windows.Forms.DataGridView();
            this.Jugador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Conectados = new System.Windows.Forms.Label();
            this.botonRegistrarse = new System.Windows.Forms.Button();
            this.BotonLogIn = new System.Windows.Forms.Button();
            this.contrasenya = new System.Windows.Forms.TextBox();
            this.contraseña = new System.Windows.Forms.Label();
            this.nombre = new System.Windows.Forms.TextBox();
            this.Desconexion = new System.Windows.Forms.Button();
            this.botonConectarme = new System.Windows.Forms.Button();
            this.usuario = new System.Windows.Forms.Label();
            this.BoxForm1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridConectados)).BeginInit();
            this.SuspendLayout();
            // 
            // BoxForm1
            // 
            this.BoxForm1.Controls.Add(this.estadisticas);
            this.BoxForm1.Controls.Add(this.button1);
            this.BoxForm1.Controls.Add(this.textBox1);
            this.BoxForm1.Controls.Add(this.richTextBox1);
            this.BoxForm1.Controls.Add(this.label1);
            this.BoxForm1.Controls.Add(this.eliminar);
            this.BoxForm1.Controls.Add(this.BotonInvitar2);
            this.BoxForm1.Controls.Add(this.GridConectados);
            this.BoxForm1.Controls.Add(this.Conectados);
            this.BoxForm1.Controls.Add(this.botonRegistrarse);
            this.BoxForm1.Controls.Add(this.BotonLogIn);
            this.BoxForm1.Controls.Add(this.contrasenya);
            this.BoxForm1.Controls.Add(this.contraseña);
            this.BoxForm1.Controls.Add(this.nombre);
            this.BoxForm1.Controls.Add(this.Desconexion);
            this.BoxForm1.Controls.Add(this.botonConectarme);
            this.BoxForm1.Controls.Add(this.usuario);
            this.BoxForm1.Location = new System.Drawing.Point(9, 10);
            this.BoxForm1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.BoxForm1.Name = "BoxForm1";
            this.BoxForm1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.BoxForm1.Size = new System.Drawing.Size(563, 528);
            this.BoxForm1.TabIndex = 0;
            this.BoxForm1.TabStop = false;
            this.BoxForm1.Text = "Nobody\'s Table";
            this.BoxForm1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // estadisticas
            // 
            this.estadisticas.Location = new System.Drawing.Point(20, 368);
            this.estadisticas.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.estadisticas.Name = "estadisticas";
            this.estadisticas.Size = new System.Drawing.Size(112, 54);
            this.estadisticas.TabIndex = 39;
            this.estadisticas.Text = "Mis Estadísticas";
            this.estadisticas.UseVisualStyleBackColor = true;
            this.estadisticas.Click += new System.EventHandler(this.estadisticas_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(280, 323);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(47, 19);
            this.button1.TabIndex = 38;
            this.button1.Text = "Enviar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(20, 323);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(256, 20);
            this.textBox1.TabIndex = 37;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(20, 243);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(306, 76);
            this.richTextBox1.TabIndex = 36;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 228);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 35;
            this.label1.Text = "Chat:";
            // 
            // eliminar
            // 
            this.eliminar.Location = new System.Drawing.Point(20, 435);
            this.eliminar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.eliminar.Name = "eliminar";
            this.eliminar.Size = new System.Drawing.Size(105, 46);
            this.eliminar.TabIndex = 32;
            this.eliminar.Text = "Eliminarme de la Base de Datos";
            this.eliminar.UseVisualStyleBackColor = true;
            this.eliminar.Click += new System.EventHandler(this.eliminar_Click);
            // 
            // BotonInvitar2
            // 
            this.BotonInvitar2.Location = new System.Drawing.Point(434, 330);
            this.BotonInvitar2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.BotonInvitar2.Name = "BotonInvitar2";
            this.BotonInvitar2.Size = new System.Drawing.Size(101, 29);
            this.BotonInvitar2.TabIndex = 31;
            this.BotonInvitar2.Text = "Invitar Jugador/es";
            this.BotonInvitar2.UseVisualStyleBackColor = true;
            this.BotonInvitar2.Click += new System.EventHandler(this.BotonInvitar2_Click);
            // 
            // GridConectados
            // 
            this.GridConectados.AllowUserToResizeColumns = false;
            this.GridConectados.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            this.GridConectados.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.GridConectados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.GridConectados.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.GridConectados.CausesValidation = false;
            this.GridConectados.ColumnHeadersVisible = false;
            this.GridConectados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Jugador});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GridConectados.DefaultCellStyle = dataGridViewCellStyle2;
            this.GridConectados.EnableHeadersVisualStyles = false;
            this.GridConectados.GridColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.GridConectados.Location = new System.Drawing.Point(344, 228);
            this.GridConectados.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.GridConectados.Name = "GridConectados";
            this.GridConectados.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridConectados.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.GridConectados.RowHeadersVisible = false;
            this.GridConectados.Size = new System.Drawing.Size(191, 98);
            this.GridConectados.TabIndex = 30;
            this.GridConectados.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridConectados_CellContentClick);
            // 
            // Jugador
            // 
            this.Jugador.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Jugador.HeaderText = "Jugador";
            this.Jugador.MinimumWidth = 70;
            this.Jugador.Name = "Jugador";
            this.Jugador.ReadOnly = true;
            this.Jugador.Width = 70;
            // 
            // Conectados
            // 
            this.Conectados.AutoSize = true;
            this.Conectados.Location = new System.Drawing.Point(342, 202);
            this.Conectados.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Conectados.Name = "Conectados";
            this.Conectados.Size = new System.Drawing.Size(67, 13);
            this.Conectados.TabIndex = 16;
            this.Conectados.Text = "Conectados:";
            this.Conectados.Click += new System.EventHandler(this.label1_Click_2);
            // 
            // botonRegistrarse
            // 
            this.botonRegistrarse.Location = new System.Drawing.Point(124, 174);
            this.botonRegistrarse.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.botonRegistrarse.Name = "botonRegistrarse";
            this.botonRegistrarse.Size = new System.Drawing.Size(90, 41);
            this.botonRegistrarse.TabIndex = 12;
            this.botonRegistrarse.Text = "Registrarse";
            this.botonRegistrarse.UseVisualStyleBackColor = true;
            this.botonRegistrarse.Click += new System.EventHandler(this.Registro_Click);
            // 
            // BotonLogIn
            // 
            this.BotonLogIn.Location = new System.Drawing.Point(20, 174);
            this.BotonLogIn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.BotonLogIn.Name = "BotonLogIn";
            this.BotonLogIn.Size = new System.Drawing.Size(90, 41);
            this.BotonLogIn.TabIndex = 11;
            this.BotonLogIn.Text = "Log In";
            this.BotonLogIn.UseVisualStyleBackColor = true;
            this.BotonLogIn.Click += new System.EventHandler(this.LogIn_Click);
            // 
            // contrasenya
            // 
            this.contrasenya.Location = new System.Drawing.Point(86, 138);
            this.contrasenya.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.contrasenya.Name = "contrasenya";
            this.contrasenya.Size = new System.Drawing.Size(96, 20);
            this.contrasenya.TabIndex = 6;
            this.contrasenya.TextChanged += new System.EventHandler(this.contrasenya_TextChanged);
            // 
            // contraseña
            // 
            this.contraseña.AutoSize = true;
            this.contraseña.Location = new System.Drawing.Point(17, 138);
            this.contraseña.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.contraseña.Name = "contraseña";
            this.contraseña.Size = new System.Drawing.Size(64, 13);
            this.contraseña.TabIndex = 5;
            this.contraseña.Text = "Contraseña:";
            // 
            // nombre
            // 
            this.nombre.Location = new System.Drawing.Point(86, 107);
            this.nombre.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.nombre.Name = "nombre";
            this.nombre.Size = new System.Drawing.Size(96, 20);
            this.nombre.TabIndex = 4;
            // 
            // Desconexion
            // 
            this.Desconexion.Location = new System.Drawing.Point(108, 37);
            this.Desconexion.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Desconexion.Name = "Desconexion";
            this.Desconexion.Size = new System.Drawing.Size(96, 42);
            this.Desconexion.TabIndex = 2;
            this.Desconexion.Text = "Desconectarme";
            this.Desconexion.UseVisualStyleBackColor = true;
            this.Desconexion.Click += new System.EventHandler(this.Desconexion_Click);
            // 
            // botonConectarme
            // 
            this.botonConectarme.Location = new System.Drawing.Point(20, 37);
            this.botonConectarme.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.botonConectarme.Name = "botonConectarme";
            this.botonConectarme.Size = new System.Drawing.Size(77, 42);
            this.botonConectarme.TabIndex = 1;
            this.botonConectarme.Text = "Conectarme";
            this.botonConectarme.UseVisualStyleBackColor = true;
            this.botonConectarme.Click += new System.EventHandler(this.Conexion_Click);
            // 
            // usuario
            // 
            this.usuario.AutoSize = true;
            this.usuario.Location = new System.Drawing.Point(33, 107);
            this.usuario.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.usuario.Name = "usuario";
            this.usuario.Size = new System.Drawing.Size(46, 13);
            this.usuario.TabIndex = 0;
            this.usuario.Text = "Usuario:";
            this.usuario.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 546);
            this.Controls.Add(this.BoxForm1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
        private System.Windows.Forms.Button Desconexion;
        private System.Windows.Forms.Button botonConectarme;
        private System.Windows.Forms.Label usuario;
        private System.Windows.Forms.Button botonRegistrarse;
        private System.Windows.Forms.Button BotonLogIn;
        private System.Windows.Forms.Label Conectados;
        private System.Windows.Forms.DataGridView GridConectados;
        private System.Windows.Forms.Button BotonInvitar2;
        private System.Windows.Forms.Button eliminar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Jugador;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button estadisticas;
    }
}

