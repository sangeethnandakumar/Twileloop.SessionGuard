namespace Twileloop.SessionGuard.Demo
{
    partial class Main
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
            panel1 = new Panel();
            headerComponent1 = new HeaderComponent();
            panel2 = new Panel();
            splitContainer1 = new SplitContainer();
            QueryWindow = new RichTextBox();
            panel3 = new Panel();
            footerComponent1 = new FooterComponent();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlLight;
            panel1.Controls.Add(headerComponent1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1038, 34);
            panel1.TabIndex = 0;
            // 
            // headerComponent1
            // 
            headerComponent1.BackColor = Color.White;
            headerComponent1.ComponentName = "Header";
            headerComponent1.Dock = DockStyle.Fill;
            headerComponent1.Location = new Point(0, 0);
            headerComponent1.Name = "headerComponent1";
            headerComponent1.Size = new Size(1038, 34);
            headerComponent1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(splitContainer1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 34);
            panel2.Name = "panel2";
            panel2.Size = new Size(1038, 554);
            panel2.TabIndex = 1;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(QueryWindow);
            splitContainer1.Size = new Size(1038, 554);
            splitContainer1.SplitterDistance = 346;
            splitContainer1.TabIndex = 0;
            // 
            // QueryWindow
            // 
            QueryWindow.Dock = DockStyle.Fill;
            QueryWindow.Font = new Font("Tahoma", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            QueryWindow.Location = new Point(0, 0);
            QueryWindow.Name = "QueryWindow";
            QueryWindow.Size = new Size(688, 554);
            QueryWindow.TabIndex = 0;
            QueryWindow.Text = "";
            QueryWindow.TextChanged += QueryWindow_TextChanged;
            // 
            // panel3
            // 
            panel3.BackColor = Color.DarkBlue;
            panel3.Controls.Add(footerComponent1);
            panel3.Dock = DockStyle.Bottom;
            panel3.Location = new Point(0, 548);
            panel3.Name = "panel3";
            panel3.Size = new Size(1038, 40);
            panel3.TabIndex = 2;
            // 
            // footerComponent1
            // 
            footerComponent1.BackColor = Color.FromArgb(0, 0, 192);
            footerComponent1.ComponentName = "Footer";
            footerComponent1.Dock = DockStyle.Bottom;
            footerComponent1.Location = new Point(0, 8);
            footerComponent1.Name = "footerComponent1";
            footerComponent1.Size = new Size(1038, 32);
            footerComponent1.TabIndex = 0;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1038, 588);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "Main";
            Load += Main_Load;
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private FooterComponent footerComponent1;
        private SplitContainer splitContainer1;
        private RichTextBox QueryWindow;
        private HeaderComponent headerComponent1;
    }
}