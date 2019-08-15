namespace Client
{
    partial class MainForm
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
            this.Logout = new System.Windows.Forms.Button();
            this.cuvantprimit = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.IdJucatorLabel = new System.Windows.Forms.Label();
            this.StartButton = new System.Windows.Forms.Button();
            this.OkButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Logout
            // 
            this.Logout.Location = new System.Drawing.Point(580, 340);
            this.Logout.Name = "Logout";
            this.Logout.Size = new System.Drawing.Size(181, 59);
            this.Logout.TabIndex = 0;
            this.Logout.Text = "Logout";
            this.Logout.UseVisualStyleBackColor = true;
            this.Logout.Click += new System.EventHandler(this.Logout_Click);
            // 
            // cuvantprimit
            // 
            this.cuvantprimit.Location = new System.Drawing.Point(185, 94);
            this.cuvantprimit.Name = "cuvantprimit";
            this.cuvantprimit.Size = new System.Drawing.Size(233, 49);
            this.cuvantprimit.TabIndex = 1;
            this.cuvantprimit.Text = "cuvantprimit";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(188, 206);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(338, 42);
            this.textBox1.TabIndex = 2;
            // 
            // IdJucatorLabel
            // 
            this.IdJucatorLabel.AutoSize = true;
            this.IdJucatorLabel.Location = new System.Drawing.Point(612, 25);
            this.IdJucatorLabel.Name = "IdJucatorLabel";
            this.IdJucatorLabel.Size = new System.Drawing.Size(66, 17);
            this.IdJucatorLabel.TabIndex = 3;
            this.IdJucatorLabel.Text = "IdJucator";
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(603, 120);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(75, 23);
            this.StartButton.TabIndex = 4;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // OkButton
            // 
            this.OkButton.Location = new System.Drawing.Point(603, 206);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(75, 23);
            this.OkButton.TabIndex = 5;
            this.OkButton.Text = "Ok";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.IdJucatorLabel);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.cuvantprimit);
            this.Controls.Add(this.Logout);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Logout;
        private System.Windows.Forms.Label cuvantprimit;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label IdJucatorLabel;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Button OkButton;
    }
}