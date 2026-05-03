
namespace Knowledge_Matrix
{
    public partial class WinForm : Form
    {
        public bool isReplay = false;
        public WinForm()
        {
            InitializeComponent();
        }
        private void button_NewGame_Click(object sender, EventArgs e)
        {
            isReplay = true;
            this.DialogResult = DialogResult.OK; 
            this.Close(); 
        }
        public bool GetIsReplay()
        {
            return isReplay;
        }
        private void button_Exit_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show(
                   "Вы уверены, что хотите закрыть приложение?",
                   "Подтверждение",
                   MessageBoxButtons.YesNo,
                   MessageBoxIcon.Question
                );
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

    }
}
