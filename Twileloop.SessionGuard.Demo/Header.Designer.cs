namespace Twileloop.SessionGuard.Demo
{
    partial class Header
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            Subheading = new Label();
            Heading = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveCaption;
            panel1.Controls.Add(Subheading);
            panel1.Controls.Add(Heading);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(655, 88);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // Subheading
            // 
            Subheading.AutoSize = true;
            Subheading.Font = new Font("Calibri", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Subheading.Location = new Point(18, 40);
            Subheading.Name = "Subheading";
            Subheading.Size = new Size(46, 18);
            Subheading.TabIndex = 1;
            Subheading.Text = "label2";
            // 
            // Heading
            // 
            Heading.AutoSize = true;
            Heading.Font = new Font("Tahoma", 14.25F);
            Heading.Location = new Point(18, 17);
            Heading.Name = "Heading";
            Heading.Size = new Size(59, 23);
            Heading.TabIndex = 0;
            Heading.Text = "label1";
            // 
            // Header
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Name = "Header";
            Size = new Size(655, 88);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label Subheading;
        private Label Heading;
    }
}
