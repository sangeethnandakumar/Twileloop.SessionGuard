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
            Write = new Button();
            Read = new Button();
            Text = new RichTextBox();
            SuspendLayout();
            // 
            // Write
            // 
            Write.Location = new Point(31, 26);
            Write.Name = "Write";
            Write.Size = new Size(168, 37);
            Write.TabIndex = 0;
            Write.Text = "Write 'sample.amr'";
            Write.UseVisualStyleBackColor = true;
            Write.Click += Write_Click;
            // 
            // Read
            // 
            Read.Location = new Point(31, 69);
            Read.Name = "Read";
            Read.Size = new Size(168, 37);
            Read.TabIndex = 1;
            Read.Text = "Read 'sample.amr'";
            Read.UseVisualStyleBackColor = true;
            Read.Click += Read_Click;
            // 
            // Text
            // 
            Text.Font = new Font("Tahoma", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            Text.Location = new Point(224, 20);
            Text.Name = "Text";
            Text.Size = new Size(331, 88);
            Text.TabIndex = 2;
            Text.Text = "";
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(592, 221);
            Controls.Add(Text);
            Controls.Add(Read);
            Controls.Add(Write);
            Name = "Main";
            ResumeLayout(false);
        }

        #endregion

        private Button Write;
        private Button Read;
        private RichTextBox Text;
    }
}