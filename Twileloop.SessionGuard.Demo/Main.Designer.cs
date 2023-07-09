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
            Counter = new Label();
            Minus = new Button();
            Plus = new Button();
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
            // Counter
            // 
            Counter.AutoSize = true;
            Counter.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            Counter.Location = new Point(272, 127);
            Counter.Name = "Counter";
            Counter.Size = new Size(25, 30);
            Counter.TabIndex = 3;
            Counter.Text = "0";
            // 
            // Minus
            // 
            Minus.Location = new Point(208, 170);
            Minus.Name = "Minus";
            Minus.Size = new Size(71, 37);
            Minus.TabIndex = 4;
            Minus.Text = "-";
            Minus.UseVisualStyleBackColor = true;
            Minus.Click += Minus_Click;
            // 
            // Plus
            // 
            Plus.Location = new Point(285, 170);
            Plus.Name = "Plus";
            Plus.Size = new Size(71, 37);
            Plus.TabIndex = 5;
            Plus.Text = "+";
            Plus.UseVisualStyleBackColor = true;
            Plus.Click += Plus_Click;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(592, 221);
            Controls.Add(Plus);
            Controls.Add(Minus);
            Controls.Add(Counter);
            Controls.Add(Text);
            Controls.Add(Read);
            Controls.Add(Write);
            Name = "Main";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Write;
        private Button Read;
        private RichTextBox Text;
        private Label Counter;
        private Button Minus;
        private Button Plus;
    }
}