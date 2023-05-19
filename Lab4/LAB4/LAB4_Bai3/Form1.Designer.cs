namespace LAB4_Bai3
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
            this.btDownload = new System.Windows.Forms.Button();
            this.textURL = new System.Windows.Forms.TextBox();
            this.textPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 147);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(452, 286);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // btDownload
            // 
            this.btDownload.Location = new System.Drawing.Point(505, 40);
            this.btDownload.Name = "btDownload";
            this.btDownload.Size = new System.Drawing.Size(94, 29);
            this.btDownload.TabIndex = 1;
            this.btDownload.Text = "Download";
            this.btDownload.UseVisualStyleBackColor = true;
            this.btDownload.Click += new System.EventHandler(this.btDownload_Click);
            // 
            // textURL
            // 
            this.textURL.Location = new System.Drawing.Point(12, 39);
            this.textURL.Name = "textURL";
            this.textURL.Size = new System.Drawing.Size(452, 27);
            this.textURL.TabIndex = 2;
            // 
            // textPath
            // 
            this.textPath.Location = new System.Drawing.Point(12, 98);
            this.textPath.Name = "textPath";
            this.textPath.Size = new System.Drawing.Size(452, 27);
            this.textPath.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "URL";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Path";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textPath);
            this.Controls.Add(this.textURL);
            this.Controls.Add(this.btDownload);
            this.Controls.Add(this.richTextBox1);
            this.Name = "Form1";
            this.Text = "Bài 3";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RichTextBox richTextBox1;
        private Button btDownload;
        private TextBox textURL;
        private TextBox textPath;
        private Label label1;
        private Label label2;
    }
}