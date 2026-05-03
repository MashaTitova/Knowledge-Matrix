namespace Knowledge_Matrix
{
    partial class Form_PeopleHelp
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_PeopleHelp));
            panel_PeopleHelp = new Panel();
            chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            textBox_D = new TextBox();
            textBox_C = new TextBox();
            textBox_B = new TextBox();
            textBox_A = new TextBox();
            label_D = new Label();
            label_C = new Label();
            label_B = new Label();
            label_A = new Label();
            panel_PeopleHelp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chart).BeginInit();
            SuspendLayout();
            // 
            // panel_PeopleHelp
            // 
            panel_PeopleHelp.BackColor = Color.Transparent;
            panel_PeopleHelp.Controls.Add(chart);
            panel_PeopleHelp.Controls.Add(textBox_D);
            panel_PeopleHelp.Controls.Add(textBox_C);
            panel_PeopleHelp.Controls.Add(textBox_B);
            panel_PeopleHelp.Controls.Add(textBox_A);
            panel_PeopleHelp.Controls.Add(label_D);
            panel_PeopleHelp.Controls.Add(label_C);
            panel_PeopleHelp.Controls.Add(label_B);
            panel_PeopleHelp.Controls.Add(label_A);
            panel_PeopleHelp.Location = new Point(12, 12);
            panel_PeopleHelp.Name = "panel_PeopleHelp";
            panel_PeopleHelp.Size = new Size(1100, 1100);
            panel_PeopleHelp.TabIndex = 0;
            // 
            // chart
            // 
            chartArea1.Name = "ChartArea1";
            chart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            chart.Legends.Add(legend1);
            chart.Location = new Point(337, 22);
            chart.Name = "chart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            chart.Series.Add(series1);
            chart.Size = new Size(623, 608);
            chart.TabIndex = 10;
            chart.Text = "chart1";
            // 
            // textBox_D
            // 
            textBox_D.Anchor = AnchorStyles.None;
            textBox_D.Enabled = false;
            textBox_D.Font = new Font("Segoe UI", 16F);
            textBox_D.ForeColor = SystemColors.InactiveCaptionText;
            textBox_D.Location = new Point(337, 972);
            textBox_D.Multiline = true;
            textBox_D.Name = "textBox_D";
            textBox_D.Size = new Size(623, 65);
            textBox_D.TabIndex = 9;
            // 
            // textBox_C
            // 
            textBox_C.Anchor = AnchorStyles.None;
            textBox_C.Enabled = false;
            textBox_C.Font = new Font("Segoe UI", 16F);
            textBox_C.ForeColor = SystemColors.InactiveCaptionText;
            textBox_C.Location = new Point(337, 871);
            textBox_C.Multiline = true;
            textBox_C.Name = "textBox_C";
            textBox_C.Size = new Size(623, 65);
            textBox_C.TabIndex = 8;
            // 
            // textBox_B
            // 
            textBox_B.Anchor = AnchorStyles.None;
            textBox_B.Enabled = false;
            textBox_B.Font = new Font("Segoe UI", 16F);
            textBox_B.ForeColor = SystemColors.InactiveCaptionText;
            textBox_B.Location = new Point(337, 768);
            textBox_B.Multiline = true;
            textBox_B.Name = "textBox_B";
            textBox_B.Size = new Size(623, 65);
            textBox_B.TabIndex = 7;
            // 
            // textBox_A
            // 
            textBox_A.Anchor = AnchorStyles.None;
            textBox_A.Enabled = false;
            textBox_A.Font = new Font("Segoe UI", 16F);
            textBox_A.ForeColor = SystemColors.InactiveCaptionText;
            textBox_A.Location = new Point(337, 661);
            textBox_A.Multiline = true;
            textBox_A.Name = "textBox_A";
            textBox_A.Size = new Size(623, 65);
            textBox_A.TabIndex = 6;
            // 
            // label_D
            // 
            label_D.Anchor = AnchorStyles.None;
            label_D.Font = new Font("Segoe UI", 26F);
            label_D.ForeColor = Color.WhiteSmoke;
            label_D.Location = new Point(225, 958);
            label_D.Name = "label_D";
            label_D.Size = new Size(76, 79);
            label_D.TabIndex = 5;
            label_D.Text = "D";
            // 
            // label_C
            // 
            label_C.Anchor = AnchorStyles.None;
            label_C.Font = new Font("Segoe UI", 26F);
            label_C.ForeColor = Color.WhiteSmoke;
            label_C.Location = new Point(225, 857);
            label_C.Name = "label_C";
            label_C.Size = new Size(76, 79);
            label_C.TabIndex = 4;
            label_C.Text = "C";
            // 
            // label_B
            // 
            label_B.Anchor = AnchorStyles.None;
            label_B.Font = new Font("Segoe UI", 26F);
            label_B.ForeColor = Color.WhiteSmoke;
            label_B.Location = new Point(225, 754);
            label_B.Name = "label_B";
            label_B.Size = new Size(76, 79);
            label_B.TabIndex = 3;
            label_B.Text = "B";
            // 
            // label_A
            // 
            label_A.Anchor = AnchorStyles.None;
            label_A.Font = new Font("Segoe UI", 26F);
            label_A.ForeColor = Color.WhiteSmoke;
            label_A.Location = new Point(225, 647);
            label_A.Name = "label_A";
            label_A.Size = new Size(76, 79);
            label_A.TabIndex = 2;
            label_A.Text = "A";
            // 
            // Form_PeopleHelp
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1119, 1156);
            Controls.Add(panel_PeopleHelp);
            Name = "Form_PeopleHelp";
            Text = "Помощь зала";
            panel_PeopleHelp.ResumeLayout(false);
            panel_PeopleHelp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)chart).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel_PeopleHelp;
        private Label label_A;
        private Label label_B;
        private TextBox textBox_D;
        private TextBox textBox_C;
        private TextBox textBox_B;
        private TextBox textBox_A;
        private Label label_D;
        private Label label_C;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
    }
}