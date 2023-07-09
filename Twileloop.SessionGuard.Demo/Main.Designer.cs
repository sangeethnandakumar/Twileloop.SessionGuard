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
            Tab = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            tabPage3 = new TabPage();
            tabPage4 = new TabPage();
            tabPage5 = new TabPage();
            Next = new Button();
            Prev = new Button();
            Tab.SuspendLayout();
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
            Counter.Location = new Point(269, 141);
            Counter.Name = "Counter";
            Counter.Size = new Size(25, 30);
            Counter.TabIndex = 3;
            Counter.Text = "0";
            // 
            // Minus
            // 
            Minus.Location = new Point(205, 184);
            Minus.Name = "Minus";
            Minus.Size = new Size(71, 37);
            Minus.TabIndex = 4;
            Minus.Text = "-";
            Minus.UseVisualStyleBackColor = true;
            Minus.Click += Minus_Click;
            // 
            // Plus
            // 
            Plus.Location = new Point(282, 184);
            Plus.Name = "Plus";
            Plus.Size = new Size(71, 37);
            Plus.TabIndex = 5;
            Plus.Text = "+";
            Plus.UseVisualStyleBackColor = true;
            Plus.Click += Plus_Click;
            // 
            // Tab
            // 
            Tab.Controls.Add(tabPage1);
            Tab.Controls.Add(tabPage2);
            Tab.Controls.Add(tabPage3);
            Tab.Controls.Add(tabPage4);
            Tab.Controls.Add(tabPage5);
            Tab.Location = new Point(69, 258);
            Tab.Name = "Tab";
            Tab.SelectedIndex = 0;
            Tab.Size = new Size(445, 168);
            Tab.TabIndex = 6;
            // 
            // tabPage1
            // 
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(437, 140);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "tabPage1";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(437, 140);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "tabPage2";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(437, 140);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "tabPage3";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            tabPage4.Location = new Point(4, 24);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(3);
            tabPage4.Size = new Size(437, 140);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "tabPage4";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            tabPage5.Location = new Point(4, 24);
            tabPage5.Name = "tabPage5";
            tabPage5.Padding = new Padding(3);
            tabPage5.Size = new Size(437, 140);
            tabPage5.TabIndex = 4;
            tabPage5.Text = "tabPage5";
            tabPage5.UseVisualStyleBackColor = true;
            // 
            // Next
            // 
            Next.Location = new Point(400, 432);
            Next.Name = "Next";
            Next.Size = new Size(110, 37);
            Next.TabIndex = 8;
            Next.Text = "Next";
            Next.UseVisualStyleBackColor = true;
            Next.Click += Next_Click;
            // 
            // Prev
            // 
            Prev.Location = new Point(282, 432);
            Prev.Name = "Prev";
            Prev.Size = new Size(110, 37);
            Prev.TabIndex = 7;
            Prev.Text = "Previous";
            Prev.UseVisualStyleBackColor = true;
            Prev.Click += Prev_Click;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(585, 508);
            Controls.Add(Next);
            Controls.Add(Prev);
            Controls.Add(Tab);
            Controls.Add(Plus);
            Controls.Add(Minus);
            Controls.Add(Counter);
            Controls.Add(Text);
            Controls.Add(Read);
            Controls.Add(Write);
            Name = "Main";
            Tab.ResumeLayout(false);
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
        private TabControl Tab;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private TabPage tabPage5;
        private Button Next;
        private Button Prev;
    }
}