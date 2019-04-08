namespace FutbolSimulasyonu
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.skor1 = new System.Windows.Forms.Label();
            this.skor2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.sure = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(86, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(162, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(328, 12);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(162, 20);
            this.textBox2.TabIndex = 1;
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // skor1
            // 
            this.skor1.AutoSize = true;
            this.skor1.Location = new System.Drawing.Point(254, 15);
            this.skor1.Name = "skor1";
            this.skor1.Size = new System.Drawing.Size(13, 13);
            this.skor1.TabIndex = 2;
            this.skor1.Text = "0";
            // 
            // skor2
            // 
            this.skor2.AutoSize = true;
            this.skor2.Location = new System.Drawing.Point(309, 15);
            this.skor2.Name = "skor2";
            this.skor2.Size = new System.Drawing.Size(13, 13);
            this.skor2.TabIndex = 3;
            this.skor2.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(282, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(10, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "-";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 38);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(584, 361);
            this.richTextBox1.TabIndex = 5;
            this.richTextBox1.Text = "";
            // 
            // sure
            // 
            this.sure.AutoSize = true;
            this.sure.Location = new System.Drawing.Point(582, 15);
            this.sure.Name = "sure";
            this.sure.Size = new System.Drawing.Size(13, 13);
            this.sure.TabIndex = 6;
            this.sure.Text = "0";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(267, 405);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Maçı Başlat";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 440);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.sure);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.skor2);
            this.Controls.Add(this.skor1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form2";
            this.Text = "Futbol Simulasyonu v1.00 - Maç Yap";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label skor1;
        private System.Windows.Forms.Label skor2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label sure;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button1;

    }
}