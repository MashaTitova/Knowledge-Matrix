namespace Knowledge_Matrix
{
    partial class WinForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WinForm));
            button_Exit = new Button();
            button_NewGame = new Button();
            SuspendLayout();
            // 
            // button_Exit
            // 
            button_Exit.BackColor = Color.Transparent;
            button_Exit.FlatStyle = FlatStyle.Popup;
            button_Exit.Font = new Font("Segoe UI", 14F);
            button_Exit.ForeColor = Color.WhiteSmoke;
            button_Exit.Location = new Point(704, 881);
            button_Exit.Name = "button_Exit";
            button_Exit.Size = new Size(273, 130);
            button_Exit.TabIndex = 3;
            button_Exit.Text = "Выход из приложения";
            button_Exit.UseVisualStyleBackColor = false;
            // 
            // button_NewGame
            // 
            button_NewGame.BackColor = Color.Transparent;
            button_NewGame.FlatStyle = FlatStyle.Popup;
            button_NewGame.Font = new Font("Segoe UI", 14F);
            button_NewGame.ForeColor = Color.WhiteSmoke;
            button_NewGame.Location = new Point(128, 881);
            button_NewGame.Name = "button_NewGame";
            button_NewGame.Size = new Size(273, 130);
            button_NewGame.TabIndex = 2;
            button_NewGame.Text = "Новая игра";
            button_NewGame.UseVisualStyleBackColor = false;
            // 
            // WinForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1060, 1097);
            Controls.Add(button_Exit);
            Controls.Add(button_NewGame);
            DoubleBuffered = true;
            Name = "WinForm";
            Text = "Победа";
            Load += WinForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button button_Exit;
        private Button button_NewGame;
    }
}