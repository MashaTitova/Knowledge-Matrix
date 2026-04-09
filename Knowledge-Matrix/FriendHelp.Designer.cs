namespace Knowledge_Matrix
{
    partial class FriendHelp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FriendHelp));
            panel_Friend = new Panel();
            textBox_FriendsReplic = new TextBox();
            button_YourReplic = new Button();
            SuspendLayout();
            // 
            // panel_Friend
            // 
            panel_Friend.Anchor = AnchorStyles.None;
            panel_Friend.BackColor = Color.Transparent;
            panel_Friend.BackgroundImage = (Image)resources.GetObject("panel_Friend.BackgroundImage");
            panel_Friend.BackgroundImageLayout = ImageLayout.Stretch;
            panel_Friend.Location = new Point(283, 29);
            panel_Friend.Name = "panel_Friend";
            panel_Friend.Size = new Size(721, 661);
            panel_Friend.TabIndex = 0;
            // 
            // textBox_FriendsReplic
            // 
            textBox_FriendsReplic.Anchor = AnchorStyles.None;
            textBox_FriendsReplic.Font = new Font("Segoe UI", 14F);
            textBox_FriendsReplic.Location = new Point(283, 696);
            textBox_FriendsReplic.Multiline = true;
            textBox_FriendsReplic.Name = "textBox_FriendsReplic";
            textBox_FriendsReplic.ReadOnly = true;
            textBox_FriendsReplic.Size = new Size(721, 252);
            textBox_FriendsReplic.TabIndex = 1;
            // 
            // button_YourReplic
            // 
            button_YourReplic.Anchor = AnchorStyles.None;
            button_YourReplic.Location = new Point(509, 954);
            button_YourReplic.Name = "button_YourReplic";
            button_YourReplic.Size = new Size(267, 137);
            button_YourReplic.TabIndex = 2;
            button_YourReplic.Text = "Привет";
            button_YourReplic.UseVisualStyleBackColor = true;
            button_YourReplic.Click += buttonYourReplic_Click;
            // 
            // FriendHelp
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1208, 1126);
            Controls.Add(button_YourReplic);
            Controls.Add(textBox_FriendsReplic);
            Controls.Add(panel_Friend);
            DoubleBuffered = true;
            Name = "FriendHelp";
            Text = "Помощь друга";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel_Friend;
        private TextBox textBox_FriendsReplic;
        private Button button_YourReplic;
    }
}