namespace LAB4_B1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.textURL = new System.Windows.Forms.TextBox();
            this.btGet = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 76);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(747, 362);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // textURL
            // 
            this.textURL.Location = new System.Drawing.Point(12, 31);
            this.textURL.Name = "textURL";
            this.textURL.Size = new System.Drawing.Size(635, 27);
            this.textURL.TabIndex = 1;
            // 
            // btGet
            // 
            this.btGet.Location = new System.Drawing.Point(665, 31);
            this.btGet.Name = "btGet";
            this.btGet.Size = new System.Drawing.Size(94, 29);
            this.btGet.TabIndex = 2;
            this.btGet.Text = "GET";
            this.btGet.UseVisualStyleBackColor = true;
            this.btGet.Click += new System.EventHandler(this.btGet_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btGet);
            this.Controls.Add(this.textURL);
            this.Controls.Add(this.richTextBox1);
            this.Name = "Form1";
            this.Text = "Bài 1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RichTextBox richTextBox1;
        private TextBox textURL;
        private Button btGet;
    }
}