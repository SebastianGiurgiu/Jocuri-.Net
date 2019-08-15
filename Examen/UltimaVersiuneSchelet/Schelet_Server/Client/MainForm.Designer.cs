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
            this.StartButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.labelpoz1 = new System.Windows.Forms.Label();
            this.labelpoz2 = new System.Windows.Forms.Label();
            this.labelpzoadv = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Logout
            // 
            this.Logout.Location = new System.Drawing.Point(157, 60);
            this.Logout.Name = "Logout";
            this.Logout.Size = new System.Drawing.Size(181, 59);
            this.Logout.TabIndex = 0;
            this.Logout.Text = "Logout";
            this.Logout.UseVisualStyleBackColor = true;
            this.Logout.Click += new System.EventHandler(this.Logout_Click);
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(12, 60);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(126, 52);
            this.StartButton.TabIndex = 3;
            this.StartButton.Text = "start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(104, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "label2";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(364, 12);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(519, 462);
            this.flowLayoutPanel1.TabIndex = 13;
            // 
            // labelpoz1
            // 
            this.labelpoz1.AutoSize = true;
            this.labelpoz1.Location = new System.Drawing.Point(227, 168);
            this.labelpoz1.Name = "labelpoz1";
            this.labelpoz1.Size = new System.Drawing.Size(46, 17);
            this.labelpoz1.TabIndex = 14;
            this.labelpoz1.Text = "label3";
            // 
            // labelpoz2
            // 
            this.labelpoz2.AutoSize = true;
            this.labelpoz2.Location = new System.Drawing.Point(227, 228);
            this.labelpoz2.Name = "labelpoz2";
            this.labelpoz2.Size = new System.Drawing.Size(46, 17);
            this.labelpoz2.TabIndex = 15;
            this.labelpoz2.Text = "label4";
            // 
            // labelpzoadv
            // 
            this.labelpzoadv.AutoSize = true;
            this.labelpzoadv.Location = new System.Drawing.Point(227, 284);
            this.labelpzoadv.Name = "labelpzoadv";
            this.labelpzoadv.Size = new System.Drawing.Size(46, 17);
            this.labelpzoadv.TabIndex = 16;
            this.labelpzoadv.Text = "label5";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(65, 168);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 17);
            this.label3.TabIndex = 17;
            this.label3.Text = "Pozitie barcuta 1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(65, 228);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 17);
            this.label4.TabIndex = 18;
            this.label4.Text = "Pozitie barcuta 2 ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 284);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(176, 17);
            this.label5.TabIndex = 19;
            this.label5.Text = "Pozitie aleasa de adversar";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(923, 486);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelpzoadv);
            this.Controls.Add(this.labelpoz2);
            this.Controls.Add(this.labelpoz1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.Logout);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Logout;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label labelpoz1;
        private System.Windows.Forms.Label labelpoz2;
        private System.Windows.Forms.Label labelpzoadv;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}