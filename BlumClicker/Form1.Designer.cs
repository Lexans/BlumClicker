namespace BlumClicker
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            buttonStart = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            radioButtonLD = new RadioButton();
            radioButtonDesktop = new RadioButton();
            SuspendLayout();
            // 
            // buttonStart
            // 
            buttonStart.Location = new Point(12, 12);
            buttonStart.Name = "buttonStart";
            buttonStart.Size = new Size(146, 29);
            buttonStart.TabIndex = 1;
            buttonStart.Text = "Запустить";
            buttonStart.UseVisualStyleBackColor = true;
            buttonStart.Click += button1_Click;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // radioButtonLD
            // 
            radioButtonLD.AutoSize = true;
            radioButtonLD.Location = new Point(12, 76);
            radioButtonLD.Name = "radioButtonLD";
            radioButtonLD.Size = new Size(88, 24);
            radioButtonLD.TabIndex = 2;
            radioButtonLD.Text = "LDPlayer";
            radioButtonLD.UseVisualStyleBackColor = true;
            // 
            // radioButtonDesktop
            // 
            radioButtonDesktop.AutoSize = true;
            radioButtonDesktop.Checked = true;
            radioButtonDesktop.Location = new Point(12, 46);
            radioButtonDesktop.Name = "radioButtonDesktop";
            radioButtonDesktop.Size = new Size(147, 24);
            radioButtonDesktop.TabIndex = 3;
            radioButtonDesktop.TabStop = true;
            radioButtonDesktop.Text = "TelegramDesktop";
            radioButtonDesktop.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(304, 112);
            Controls.Add(radioButtonDesktop);
            Controls.Add(radioButtonLD);
            Controls.Add(buttonStart);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form1";
            Text = "Автокликер Blum";
            FormClosed += Form1_FormClosed;
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button buttonStart;
        private System.Windows.Forms.Timer timer1;
        private RadioButton radioButtonLD;
        private RadioButton radioButtonDesktop;
    }
}
