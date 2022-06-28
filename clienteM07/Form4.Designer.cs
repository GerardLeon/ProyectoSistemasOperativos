namespace WindowsFormsApplication1
{
    partial class Form4
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
            this.enviar = new System.Windows.Forms.Button();
            this.numero_victorias = new System.Windows.Forms.RadioButton();
            this.escenarios_juntos = new System.Windows.Forms.RadioButton();
            this.mejor_escenario = new System.Windows.Forms.RadioButton();
            this.tablero_posiciones = new System.Windows.Forms.RadioButton();
            this.nombre_auxiliar = new System.Windows.Forms.Label();
            this.nombre2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // enviar
            // 
            this.enviar.Location = new System.Drawing.Point(221, 125);
            this.enviar.Name = "enviar";
            this.enviar.Size = new System.Drawing.Size(110, 71);
            this.enviar.TabIndex = 0;
            this.enviar.Text = "enviar";
            this.enviar.UseVisualStyleBackColor = true;
            this.enviar.Click += new System.EventHandler(this.enviar_Click);
            // 
            // numero_victorias
            // 
            this.numero_victorias.AutoSize = true;
            this.numero_victorias.Location = new System.Drawing.Point(26, 27);
            this.numero_victorias.Name = "numero_victorias";
            this.numero_victorias.Size = new System.Drawing.Size(157, 21);
            this.numero_victorias.TabIndex = 1;
            this.numero_victorias.TabStop = true;
            this.numero_victorias.Text = "Número de Victorias";
            this.numero_victorias.UseVisualStyleBackColor = true;
            // 
            // escenarios_juntos
            // 
            this.escenarios_juntos.AutoSize = true;
            this.escenarios_juntos.Location = new System.Drawing.Point(26, 54);
            this.escenarios_juntos.Name = "escenarios_juntos";
            this.escenarios_juntos.Size = new System.Drawing.Size(145, 21);
            this.escenarios_juntos.TabIndex = 2;
            this.escenarios_juntos.TabStop = true;
            this.escenarios_juntos.Text = "Escenarios Juntos";
            this.escenarios_juntos.UseVisualStyleBackColor = true;
            // 
            // mejor_escenario
            // 
            this.mejor_escenario.AutoSize = true;
            this.mejor_escenario.Location = new System.Drawing.Point(26, 98);
            this.mejor_escenario.Name = "mejor_escenario";
            this.mejor_escenario.Size = new System.Drawing.Size(152, 21);
            this.mejor_escenario.TabIndex = 3;
            this.mejor_escenario.TabStop = true;
            this.mejor_escenario.Text = "Tu Mejor Escenario";
            this.mejor_escenario.UseVisualStyleBackColor = true;
            // 
            // tablero_posiciones
            // 
            this.tablero_posiciones.AutoSize = true;
            this.tablero_posiciones.Location = new System.Drawing.Point(26, 125);
            this.tablero_posiciones.Name = "tablero_posiciones";
            this.tablero_posiciones.Size = new System.Drawing.Size(170, 21);
            this.tablero_posiciones.TabIndex = 4;
            this.tablero_posiciones.TabStop = true;
            this.tablero_posiciones.Text = "Tablero de Posiciones";
            this.tablero_posiciones.UseVisualStyleBackColor = true;
            // 
            // nombre_auxiliar
            // 
            this.nombre_auxiliar.AutoSize = true;
            this.nombre_auxiliar.Location = new System.Drawing.Point(55, 78);
            this.nombre_auxiliar.Name = "nombre_auxiliar";
            this.nombre_auxiliar.Size = new System.Drawing.Size(164, 17);
            this.nombre_auxiliar.TabIndex = 5;
            this.nombre_auxiliar.Text = "nombre del otro jugador:";
            // 
            // nombre2
            // 
            this.nombre2.Location = new System.Drawing.Point(221, 77);
            this.nombre2.Name = "nombre2";
            this.nombre2.Size = new System.Drawing.Size(111, 22);
            this.nombre2.TabIndex = 6;
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 261);
            this.Controls.Add(this.nombre2);
            this.Controls.Add(this.nombre_auxiliar);
            this.Controls.Add(this.tablero_posiciones);
            this.Controls.Add(this.mejor_escenario);
            this.Controls.Add(this.escenarios_juntos);
            this.Controls.Add(this.numero_victorias);
            this.Controls.Add(this.enviar);
            this.Name = "Form4";
            this.Text = "Form4";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button enviar;
        private System.Windows.Forms.RadioButton numero_victorias;
        private System.Windows.Forms.RadioButton escenarios_juntos;
        private System.Windows.Forms.RadioButton mejor_escenario;
        private System.Windows.Forms.RadioButton tablero_posiciones;
        private System.Windows.Forms.Label nombre_auxiliar;
        private System.Windows.Forms.TextBox nombre2;
    }
}