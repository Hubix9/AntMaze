namespace AntMazeWinforms
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
            panel1 = new Panel();
            PaintEmptyButton = new Button();
            PaintWallButton = new Button();
            SetStartButton = new Button();
            SetEndButton = new Button();
            label1 = new Label();
            ModeLabel = new Label();
            SolveButton = new Button();
            ResetButton = new Button();
            label2 = new Label();
            CurrentStatusLabel = new Label();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(788, 400);
            panel1.TabIndex = 0;
            panel1.Click += panel1_Click;
            panel1.Paint += panel1_Paint;
            // 
            // PaintEmptyButton
            // 
            PaintEmptyButton.Location = new Point(12, 456);
            PaintEmptyButton.Name = "PaintEmptyButton";
            PaintEmptyButton.Size = new Size(102, 23);
            PaintEmptyButton.TabIndex = 1;
            PaintEmptyButton.Text = "Paint Empty";
            PaintEmptyButton.UseVisualStyleBackColor = true;
            PaintEmptyButton.Click += PaintEmptyButton_Click;
            // 
            // PaintWallButton
            // 
            PaintWallButton.Location = new Point(120, 456);
            PaintWallButton.Name = "PaintWallButton";
            PaintWallButton.Size = new Size(75, 23);
            PaintWallButton.TabIndex = 2;
            PaintWallButton.Text = "Paint Wall";
            PaintWallButton.UseVisualStyleBackColor = true;
            PaintWallButton.Click += PaintWallButton_Click;
            // 
            // SetStartButton
            // 
            SetStartButton.Location = new Point(201, 456);
            SetStartButton.Name = "SetStartButton";
            SetStartButton.Size = new Size(75, 23);
            SetStartButton.TabIndex = 3;
            SetStartButton.Text = "Set Start";
            SetStartButton.UseVisualStyleBackColor = true;
            SetStartButton.Click += SetStartButton_Click;
            // 
            // SetEndButton
            // 
            SetEndButton.Location = new Point(282, 456);
            SetEndButton.Name = "SetEndButton";
            SetEndButton.Size = new Size(75, 23);
            SetEndButton.TabIndex = 4;
            SetEndButton.Text = "Set End";
            SetEndButton.UseVisualStyleBackColor = true;
            SetEndButton.Click += SetEndButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 427);
            label1.Name = "label1";
            label1.Size = new Size(84, 15);
            label1.TabIndex = 5;
            label1.Text = "Current mode:";
            // 
            // ModeLabel
            // 
            ModeLabel.AutoSize = true;
            ModeLabel.Location = new Point(120, 427);
            ModeLabel.Name = "ModeLabel";
            ModeLabel.Size = new Size(36, 15);
            ModeLabel.TabIndex = 6;
            ModeLabel.Text = "None";
            // 
            // SolveButton
            // 
            SolveButton.Location = new Point(695, 456);
            SolveButton.Name = "SolveButton";
            SolveButton.Size = new Size(105, 23);
            SolveButton.TabIndex = 7;
            SolveButton.Text = "Solve Maze!";
            SolveButton.UseVisualStyleBackColor = true;
            SolveButton.Click += SolveButton_Click;
            // 
            // ResetButton
            // 
            ResetButton.Location = new Point(604, 456);
            ResetButton.Name = "ResetButton";
            ResetButton.Size = new Size(75, 23);
            ResetButton.TabIndex = 8;
            ResetButton.Text = "Reset";
            ResetButton.UseVisualStyleBackColor = true;
            ResetButton.Click += ResetButton_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(201, 427);
            label2.Name = "label2";
            label2.Size = new Size(85, 15);
            label2.TabIndex = 9;
            label2.Text = "Current Status:";
            // 
            // CurrentStatusLabel
            // 
            CurrentStatusLabel.AutoSize = true;
            CurrentStatusLabel.Location = new Point(292, 427);
            CurrentStatusLabel.Name = "CurrentStatusLabel";
            CurrentStatusLabel.Size = new Size(26, 15);
            CurrentStatusLabel.TabIndex = 10;
            CurrentStatusLabel.Text = "Idle";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(812, 561);
            Controls.Add(CurrentStatusLabel);
            Controls.Add(label2);
            Controls.Add(ResetButton);
            Controls.Add(SolveButton);
            Controls.Add(ModeLabel);
            Controls.Add(label1);
            Controls.Add(SetEndButton);
            Controls.Add(SetStartButton);
            Controls.Add(PaintWallButton);
            Controls.Add(PaintEmptyButton);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Button PaintEmptyButton;
        private Button PaintWallButton;
        private Button SetStartButton;
        private Button SetEndButton;
        private Label label1;
        private Label ModeLabel;
        private Button SolveButton;
        private Button ResetButton;
        private Label label2;
        private Label CurrentStatusLabel;
    }
}
