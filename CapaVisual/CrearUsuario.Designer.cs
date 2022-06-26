namespace CapaVisual
{
    partial class CrearUsuario
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TextBoxNombre = new System.Windows.Forms.TextBox();
            this.TextBoxPassoword = new System.Windows.Forms.TextBox();
            this.BotonCrear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Usuario";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password";
            // 
            // TextBoxNombre
            // 
            this.TextBoxNombre.Location = new System.Drawing.Point(61, 6);
            this.TextBoxNombre.Name = "TextBoxNombre";
            this.TextBoxNombre.Size = new System.Drawing.Size(100, 20);
            this.TextBoxNombre.TabIndex = 2;
            // 
            // TextBoxPassoword
            // 
            this.TextBoxPassoword.Location = new System.Drawing.Point(61, 32);
            this.TextBoxPassoword.Name = "TextBoxPassoword";
            this.TextBoxPassoword.PasswordChar = '*';
            this.TextBoxPassoword.Size = new System.Drawing.Size(100, 20);
            this.TextBoxPassoword.TabIndex = 3;
            // 
            // BotonCrear
            // 
            this.BotonCrear.Location = new System.Drawing.Point(86, 58);
            this.BotonCrear.Name = "BotonCrear";
            this.BotonCrear.Size = new System.Drawing.Size(75, 23);
            this.BotonCrear.TabIndex = 4;
            this.BotonCrear.Text = "Crear Usuario";
            this.BotonCrear.UseVisualStyleBackColor = true;
            this.BotonCrear.Click += new System.EventHandler(this.BotonCrear_Click);
            // 
            // CrearUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(212, 103);
            this.Controls.Add(this.BotonCrear);
            this.Controls.Add(this.TextBoxPassoword);
            this.Controls.Add(this.TextBoxNombre);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "CrearUsuario";
            this.Text = "CrearUsuario";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TextBoxNombre;
        private System.Windows.Forms.TextBox TextBoxPassoword;
        private System.Windows.Forms.Button BotonCrear;
    }
}