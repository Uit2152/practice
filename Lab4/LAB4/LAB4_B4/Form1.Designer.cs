namespace LAB4_B4
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.textBox = new System.Windows.Forms.ToolStripTextBox();
            this.bt = new System.Windows.Forms.ToolStripButton();
            this.sourceBt = new System.Windows.Forms.ToolStripButton();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.downloadsHTMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.webView = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.webView)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.textBox,
            this.bt,
            this.sourceBt,
            this.toolStripSplitButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 27);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // textBox
            // 
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(100, 27);
            // 
            // bt
            // 
            this.bt.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bt.Name = "bt";
            this.bt.Size = new System.Drawing.Size(32, 24);
            this.bt.Text = "Go";
            this.bt.Click += new System.EventHandler(this.bt_Click);
            // 
            // sourceBt
            // 
            this.sourceBt.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sourceBt.Name = "sourceBt";
            this.sourceBt.Size = new System.Drawing.Size(58, 24);
            this.sourceBt.Text = "Source";
            this.sourceBt.Click += new System.EventHandler(this.sourceBt_Click);
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSplitButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.downloadsHTMLToolStripMenuItem});
            this.toolStripSplitButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton1.Image")));
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(39, 24);
            this.toolStripSplitButton1.Text = "toolStripSplitButton1";
            // 
            // downloadsHTMLToolStripMenuItem
            // 
            this.downloadsHTMLToolStripMenuItem.Name = "downloadsHTMLToolStripMenuItem";
            this.downloadsHTMLToolStripMenuItem.Size = new System.Drawing.Size(229, 26);
            this.downloadsHTMLToolStripMenuItem.Text = "Download HTML file";
            this.downloadsHTMLToolStripMenuItem.Click += new System.EventHandler(this.downloadsHTMLToolStripMenuItem_Click);
            // 
            // webView
            // 
            this.webView.AllowExternalDrop = true;
            this.webView.CreationProperties = null;
            this.webView.DefaultBackgroundColor = System.Drawing.Color.White;
            this.webView.Location = new System.Drawing.Point(0, 30);
            this.webView.Name = "webView";
            this.webView.Size = new System.Drawing.Size(800, 421);
            this.webView.Source = new System.Uri("https://www.microsoft.com", System.UriKind.Absolute);
            this.webView.TabIndex = 1;
            this.webView.ZoomFactor = 1D;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.webView);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.webView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ToolStrip toolStrip1;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView;
        private ToolStripButton bt;
        private ToolStripTextBox textBox;
        private ToolStripButton sourceBt;
        private ToolStripSplitButton toolStripSplitButton1;
        private ToolStripMenuItem downloadsHTMLToolStripMenuItem;
    }
}