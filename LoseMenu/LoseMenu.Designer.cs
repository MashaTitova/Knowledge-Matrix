namespace LoseMenu
{
    partial class LoseMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoseMenu));
            label_KnowlegeMatrix = new Label();
            flowLayoutPanel_DifficaltyLevel = new FlowLayoutPanel();
            button_LoadGame = new Button();
            button_NewGame = new Button();
            button_ExitGame = new Button();
            flowLayoutPanel_DifficaltyLevel.SuspendLayout();
            SuspendLayout();
            // 
            // label_KnowlegeMatrix
            // 
            label_KnowlegeMatrix.BackColor = Color.Transparent;
            label_KnowlegeMatrix.Dock = DockStyle.Top;
            label_KnowlegeMatrix.Font = new Font("Segoe UI Semibold", 40F, FontStyle.Bold);
            label_KnowlegeMatrix.ForeColor = Color.WhiteSmoke;
            label_KnowlegeMatrix.Location = new Point(0, 0);
            label_KnowlegeMatrix.Name = "label_KnowlegeMatrix";
            label_KnowlegeMatrix.Size = new Size(1302, 147);
            label_KnowlegeMatrix.TabIndex = 1;
            label_KnowlegeMatrix.Text = "Вы проиграли";
            label_KnowlegeMatrix.TextAlign = ContentAlignment.TopCenter;
            // 
            // flowLayoutPanel_DifficaltyLevel
            // 
            flowLayoutPanel_DifficaltyLevel.Anchor = AnchorStyles.None;
            flowLayoutPanel_DifficaltyLevel.BackColor = Color.Transparent;
            flowLayoutPanel_DifficaltyLevel.Controls.Add(button_LoadGame);
            flowLayoutPanel_DifficaltyLevel.Controls.Add(button_NewGame);
            flowLayoutPanel_DifficaltyLevel.Controls.Add(button_ExitGame);
            flowLayoutPanel_DifficaltyLevel.Location = new Point(387, 368);
            flowLayoutPanel_DifficaltyLevel.Name = "flowLayoutPanel_DifficaltyLevel";
            flowLayoutPanel_DifficaltyLevel.Size = new Size(516, 422);
            flowLayoutPanel_DifficaltyLevel.TabIndex = 4;
            flowLayoutPanel_DifficaltyLevel.Visible = false;
            // 
            // button_LoadGame
            // 
            button_LoadGame.Anchor = AnchorStyles.None;
            button_LoadGame.BackColor = SystemColors.Highlight;
            button_LoadGame.FlatAppearance.BorderColor = Color.FromArgb(0, 192, 192);
            button_LoadGame.FlatAppearance.BorderSize = 10;
            button_LoadGame.FlatAppearance.CheckedBackColor = Color.Teal;
            button_LoadGame.Font = new Font("Segoe UI Semibold", 12.125F, FontStyle.Bold);
            button_LoadGame.ForeColor = SystemColors.ButtonHighlight;
            button_LoadGame.Location = new Point(3, 3);
            button_LoadGame.Name = "button_LoadGame";
            button_LoadGame.Size = new Size(502, 129);
            button_LoadGame.TabIndex = 14;
            button_LoadGame.Text = "Загрузить игру";
            button_LoadGame.UseVisualStyleBackColor = false;
            // 
            // button_NewGame
            // 
            button_NewGame.Anchor = AnchorStyles.None;
            button_NewGame.BackColor = SystemColors.Highlight;
            button_NewGame.FlatAppearance.BorderColor = Color.FromArgb(0, 192, 192);
            button_NewGame.FlatAppearance.BorderSize = 10;
            button_NewGame.FlatAppearance.CheckedBackColor = Color.Teal;
            button_NewGame.Font = new Font("Segoe UI Semibold", 12.125F, FontStyle.Bold);
            button_NewGame.ForeColor = SystemColors.ButtonHighlight;
            button_NewGame.Location = new Point(3, 138);
            button_NewGame.Name = "button_NewGame";
            button_NewGame.Size = new Size(502, 129);
            button_NewGame.TabIndex = 13;
            button_NewGame.Text = "Начать новую игру";
            button_NewGame.UseVisualStyleBackColor = false;
            // 
            // button_ExitGame
            // 
            button_ExitGame.Anchor = AnchorStyles.None;
            button_ExitGame.BackColor = SystemColors.Highlight;
            button_ExitGame.FlatAppearance.BorderColor = Color.FromArgb(0, 192, 192);
            button_ExitGame.FlatAppearance.BorderSize = 10;
            button_ExitGame.FlatAppearance.CheckedBackColor = Color.Teal;
            button_ExitGame.Font = new Font("Segoe UI Semibold", 12.125F, FontStyle.Bold);
            button_ExitGame.ForeColor = SystemColors.ButtonHighlight;
            button_ExitGame.Location = new Point(3, 273);
            button_ExitGame.Name = "button_ExitGame";
            button_ExitGame.Size = new Size(502, 129);
            button_ExitGame.TabIndex = 12;
            button_ExitGame.Text = "Покинуть игру";
            button_ExitGame.UseVisualStyleBackColor = false;
            // 
            // LoseMenu
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1302, 1225);
            Controls.Add(flowLayoutPanel_DifficaltyLevel);
            Controls.Add(label_KnowlegeMatrix);
            Name = "LoseMenu";
            Text = "Проигрыш";
            Load += Form1_Load;
            flowLayoutPanel_DifficaltyLevel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label label_KnowlegeMatrix;
        private FlowLayoutPanel flowLayoutPanel_DifficaltyLevel;
        private Button button_LoadGame;
        private Button button_NewGame;
        private Button button_ExitGame;
    }
}
