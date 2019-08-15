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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.StartButton = new System.Windows.Forms.Button();
            this.AlegeButton = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.GhicesteButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // Logout
            // 
            this.Logout.Location = new System.Drawing.Point(38, 305);
            this.Logout.Name = "Logout";
            this.Logout.Size = new System.Drawing.Size(181, 59);
            this.Logout.TabIndex = 0;
            this.Logout.Text = "Logout";
            this.Logout.UseVisualStyleBackColor = true;
            this.Logout.Click += new System.EventHandler(this.Logout_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(495, 174);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 26);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(442, 253);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(495, 227);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(126, 52);
            this.StartButton.TabIndex = 3;
            this.StartButton.Text = "start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // AlegeButton
            // 
            this.AlegeButton.Location = new System.Drawing.Point(495, 73);
            this.AlegeButton.Name = "AlegeButton";
            this.AlegeButton.Size = new System.Drawing.Size(85, 44);
            this.AlegeButton.TabIndex = 4;
            this.AlegeButton.Text = "alege";
            this.AlegeButton.UseVisualStyleBackColor = true;
            this.AlegeButton.Click += new System.EventHandler(this.AlegeButton_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(632, 119);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 22);
            this.textBox2.TabIndex = 5;
            // 
            // GhicesteButton
            // 
            this.GhicesteButton.Location = new System.Drawing.Point(632, 73);
            this.GhicesteButton.Name = "GhicesteButton";
            this.GhicesteButton.Size = new System.Drawing.Size(121, 23);
            this.GhicesteButton.TabIndex = 6;
            this.GhicesteButton.Text = "GhicesteLitera";
            this.GhicesteButton.UseVisualStyleBackColor = true;
            this.GhicesteButton.Click += new System.EventHandler(this.GhicesteButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(492, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(692, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "label2";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 392);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.GhicesteButton);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.AlegeButton);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.Logout);
            this.Name = "MainForm";
            this.Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Logout;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Button AlegeButton;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button GhicesteButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}