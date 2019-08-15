namespace Client
{
    partial class LogForm
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
            this.Username_Box = new System.Windows.Forms.TextBox();
            this.Password_Box = new System.Windows.Forms.TextBox();
            this.Login = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(119, 174);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(207, 86);
            this.label1.TabIndex = 0;
            this.label1.Text = "Username";
            // 
            // Username_Box
            // 
            this.Username_Box.Location = new System.Drawing.Point(377, 174);
            this.Username_Box.Multiline = true;
            this.Username_Box.Name = "Username_Box";
            this.Username_Box.Size = new System.Drawing.Size(282, 49);
            this.Username_Box.TabIndex = 2;
            // 
            // Password_Box
            // 
            this.Password_Box.Location = new System.Drawing.Point(377, 260);
            this.Password_Box.Multiline = true;
            this.Password_Box.Name = "Password_Box";
            this.Password_Box.PasswordChar = '*';
            this.Password_Box.Size = new System.Drawing.Size(282, 46);
            this.Password_Box.TabIndex = 3;
            // 
            // Login
            // 
            this.Login.Location = new System.Drawing.Point(266, 355);
            this.Login.Name = "Login";
            this.Login.Size = new System.Drawing.Size(234, 78);
            this.Login.TabIndex = 4;
            this.Login.Text = "Login";
            this.Login.UseVisualStyleBackColor = true;
            this.Login.Click += new System.EventHandler(this.Login_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(119, 260);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(207, 86);
            this.label2.TabIndex = 5;
            this.label2.Text = "Password";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(267, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(296, 86);
            this.label3.TabIndex = 6;
            this.label3.Text = "Va rog dati-mi 5 Application";
            // 
            // LogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 482);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Login);
            this.Controls.Add(this.Password_Box);
            this.Controls.Add(this.Username_Box);
            this.Controls.Add(this.label1);
            this.Name = "LogForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Username_Box;
        private System.Windows.Forms.TextBox Password_Box;
        private System.Windows.Forms.Button Login;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

