namespace testS
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
            this.messageCurrent = new System.Windows.Forms.Label();
            this.btListen = new System.Windows.Forms.Button();
            this.notice_board = new System.Windows.Forms.RichTextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.tbPath = new System.Windows.Forms.TextBox();
            this.btPath = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // messageCurrent
            // 
            this.messageCurrent.AutoSize = true;
            this.messageCurrent.Location = new System.Drawing.Point(165, 347);
            this.messageCurrent.Name = "messageCurrent";
            this.messageCurrent.Size = new System.Drawing.Size(0, 20);
            this.messageCurrent.TabIndex = 0;
            // 
            // btListen
            // 
            this.btListen.BackColor = System.Drawing.Color.LightBlue;
            this.btListen.Location = new System.Drawing.Point(450, 35);
            this.btListen.Name = "btListen";
            this.btListen.Size = new System.Drawing.Size(94, 29);
            this.btListen.TabIndex = 1;
            this.btListen.Text = "Listen";
            this.btListen.UseVisualStyleBackColor = false;
            this.btListen.Click += new System.EventHandler(this.btListen_Click);
            // 
            // notice_board
            // 
            this.notice_board.BackColor = System.Drawing.Color.White;
            this.notice_board.Location = new System.Drawing.Point(12, 23);
            this.notice_board.Name = "notice_board";
            this.notice_board.ReadOnly = true;
            this.notice_board.Size = new System.Drawing.Size(361, 302);
            this.notice_board.TabIndex = 2;
            this.notice_board.Text = "";
            // 
            // tbPath
            // 
            this.tbPath.Location = new System.Drawing.Point(12, 402);
            this.tbPath.Multiline = true;
            this.tbPath.Name = "tbPath";
            this.tbPath.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbPath.Size = new System.Drawing.Size(361, 27);
            this.tbPath.TabIndex = 3;
            // 
            // btPath
            // 
            this.btPath.AllowDrop = true;
            this.btPath.BackColor = System.Drawing.Color.LightBlue;
            this.btPath.Location = new System.Drawing.Point(456, 383);
            this.btPath.Name = "btPath";
            this.btPath.Size = new System.Drawing.Size(88, 55);
            this.btPath.TabIndex = 4;
            this.btPath.Text = "Shared File";
            this.btPath.UseVisualStyleBackColor = false;
            this.btPath.Click += new System.EventHandler(this.btPath_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(602, 450);
            this.Controls.Add(this.btPath);
            this.Controls.Add(this.tbPath);
            this.Controls.Add(this.notice_board);
            this.Controls.Add(this.btListen);
            this.Controls.Add(this.messageCurrent);
            this.Name = "Form1";
            this.Text = "Server";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label messageCurrent;
        private Button btListen;
        private RichTextBox notice_board;
        private FolderBrowserDialog folderBrowserDialog1;
        private TextBox tbPath;
        private Button btPath;
    }
}