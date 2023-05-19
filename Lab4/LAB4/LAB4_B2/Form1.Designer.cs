namespace LAB4_B2
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
            this.btPost = new System.Windows.Forms.Button();
            this.textURL = new System.Windows.Forms.TextBox();
            this.textData = new System.Windows.Forms.TextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btPost
            // 
            this.btPost.Location = new System.Drawing.Point(696, 27);
            this.btPost.Name = "btPost";
            this.btPost.Size = new System.Drawing.Size(94, 29);
            this.btPost.TabIndex = 0;
            this.btPost.Text = "POST";
            this.btPost.UseVisualStyleBackColor = true;
            this.btPost.Click += new System.EventHandler(this.btPost_Click);
            // 
            // textURL
            // 
            this.textURL.Location = new System.Drawing.Point(78, 27);
            this.textURL.Name = "textURL";
            this.textURL.Size = new System.Drawing.Size(607, 27);
            this.textURL.TabIndex = 1;
            // 
            // textData
            // 
            this.textData.Location = new System.Drawing.Point(78, 73);
            this.textData.Name = "textData";
            this.textData.Size = new System.Drawing.Size(230, 27);
            this.textData.TabIndex = 1;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(31, 136);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(610, 302);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "URL";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Post Data";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.textData);
            this.Controls.Add(this.textURL);
            this.Controls.Add(this.btPost);
            this.Name = "Form1";
            this.Text = "Bài 2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btPost;
        private TextBox textURL;
        private TextBox textData;
        private RichTextBox richTextBox1;
        private Label label1;
        private Label label2;
    }
}