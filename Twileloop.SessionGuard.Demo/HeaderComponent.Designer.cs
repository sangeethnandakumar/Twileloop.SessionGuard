namespace Twileloop.SessionGuard.Demo
{
    partial class HeaderComponent
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
            progressBar1 = new ProgressBar();
            button1 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(3, 3);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(156, 28);
            progressBar1.TabIndex = 0;
            // 
            // button1
            // 
            button1.Font = new Font("Calibri", 12F, FontStyle.Bold);
            button1.ForeColor = Color.IndianRed;
            button1.Location = new Point(165, 3);
            button1.Name = "button1";
            button1.Size = new Size(47, 28);
            button1.TabIndex = 1;
            button1.Text = "-";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Calibri", 12F, FontStyle.Bold);
            button2.ForeColor = Color.IndianRed;
            button2.Location = new Point(218, 3);
            button2.Name = "button2";
            button2.Size = new Size(47, 28);
            button2.TabIndex = 2;
            button2.Text = "+";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // HeaderComponent
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(progressBar1);
            Name = "HeaderComponent";
            Size = new Size(811, 35);
            Load += HeaderComponent_Load;
            ResumeLayout(false);
        }

        #endregion

        private ProgressBar progressBar1;
        private Button button1;
        private Button button2;
    }
}
