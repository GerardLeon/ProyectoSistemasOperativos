namespace WindowsFormsApplication1
{
    partial class Form2
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
            this.labelInfoPartida = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BtAceptar = new System.Windows.Forms.Button();
            this.btRechazar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelInfoPartida
            // 
            this.labelInfoPartida.BackColor = System.Drawing.Color.Black;
            this.labelInfoPartida.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelInfoPartida.Location = new System.Drawing.Point(47, 38);
            this.labelInfoPartida.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelInfoPartida.Name = "labelInfoPartida";
            this.labelInfoPartida.Size = new System.Drawing.Size(564, 81);
            this.labelInfoPartida.TabIndex = 0;
            this.labelInfoPartida.Text = "Información de la partida";
            this.labelInfoPartida.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelInfoPartida.Click += new System.EventHandler(this.labelInfoPartida_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(0, -2);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 41);
            this.label2.TabIndex = 3;
            // 
            // BtAceptar
            // 
            this.BtAceptar.Location = new System.Drawing.Point(149, 155);
            this.BtAceptar.Margin = new System.Windows.Forms.Padding(4);
            this.BtAceptar.Name = "BtAceptar";
            this.BtAceptar.Size = new System.Drawing.Size(165, 58);
            this.BtAceptar.TabIndex = 4;
            this.BtAceptar.Text = "Aceptar";
            this.BtAceptar.UseVisualStyleBackColor = true;
            this.BtAceptar.Click += new System.EventHandler(this.button1_Click);
            // 
            // btRechazar
            // 
            this.btRechazar.Location = new System.Drawing.Point(365, 155);
            this.btRechazar.Margin = new System.Windows.Forms.Padding(4);
            this.btRechazar.Name = "btRechazar";
            this.btRechazar.Size = new System.Drawing.Size(165, 57);
            this.btRechazar.TabIndex = 5;
            this.btRechazar.Text = "Rechazar";
            this.btRechazar.UseVisualStyleBackColor = true;
            this.btRechazar.Click += new System.EventHandler(this.btRechazar_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(657, 242);
            this.Controls.Add(this.btRechazar);
            this.Controls.Add(this.BtAceptar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelInfoPartida);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelInfoPartida;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtAceptar;
        private System.Windows.Forms.Button btRechazar;
    }
}