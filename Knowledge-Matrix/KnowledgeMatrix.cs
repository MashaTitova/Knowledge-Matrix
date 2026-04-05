using GetQuestions;
using System.Windows.Forms.VisualStyles;
using UsefullClassLibrary;

namespace Knowledge_Matrix
{
    public partial class Form_KnowledgeMatrix : Form
    {
        static HashSet<Question> uniqueQuestions = new HashSet<Question>();
        static Dictionary<string, string> iconsDictionary = new Dictionary<string, string>();
        static List <String> choisenCategories = new List<String>();
        static List<Question> choisenQuestions = new List<Question>();
        public Form_KnowledgeMatrix()
        {
            InitializeComponent();
            this.BackgroundImageLayout = ImageLayout.Stretch;
            FillData();
        }

        private void button_return_Click(object sender, EventArgs e)
        {
            if (button_return.Text == "Выход из приложения")
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
            if (button_return.Text == "Возврат в меню")
            {
                panel_StartGame.Visible = true;
                panel_Coins.Visible = false;
                label_Quize.Text = "Интеллектуальный квиз";
                label_KnowlegeMatrix.Text = "Матрица Знаний";
                panel_CategoryButtons.Visible = false;
                button_50.Visible = false;
                button_PeopleHelp.Visible = false;
                button_FriendHelp.Visible = false;
                button_return.Text = "Выход из приложения";
            }
        }
        private void SetCategoryIcons()
        {
            List<int> choisen = Randomazer.CastomRandom(iconsDictionary.Count, 6);
            for (int i = 0; i < choisen.Count; i++)
            {
                choisenCategories.Add(iconsDictionary.Keys.ElementAt(choisen[i]));
            }
            choisenQuestions = Question.ChoiseQuestion(choisenCategories, uniqueQuestions);

            label_Category1.Text = iconsDictionary.Keys.ElementAt(choisen[0]);
            button_Category1.BackgroundImage = Image.FromFile($".\\Icons\\{iconsDictionary.Values.ElementAt(choisen[0])}");

            label_Category2.Text = iconsDictionary.Keys.ElementAt(choisen[1]);
            button_Category2.BackgroundImage = Image.FromFile($".\\Icons\\{iconsDictionary.Values.ElementAt(choisen[1])}");

            label_Category3.Text = iconsDictionary.Keys.ElementAt(choisen[2]);
            button_Category3.BackgroundImage = Image.FromFile($".\\Icons\\{iconsDictionary.Values.ElementAt(choisen[2])}");

            label_Category4.Text = iconsDictionary.Keys.ElementAt(choisen[3]);
            button_Category4.BackgroundImage = Image.FromFile($".\\Icons\\{iconsDictionary.Values.ElementAt(choisen[3])}");

            label_Category5.Text = iconsDictionary.Keys.ElementAt(choisen[4]);
            button_Category5.BackgroundImage = Image.FromFile($".\\Icons\\{iconsDictionary.Values.ElementAt(choisen[4])}");

            label_Category6.Text = iconsDictionary.Keys.ElementAt(choisen[5]);
            button_Category6.BackgroundImage = Image.FromFile($".\\Icons\\{iconsDictionary.Values.ElementAt(choisen[5])}");
        }
        private void FillData()
        {
            StreamReader g = new StreamReader(".\\Data\\Icons.csv");
            g.ReadLine();
            for (int i = 0; i < File.ReadAllLines(".\\Data\\Icons.csv").Length - 1; i++)
            {
                string[] categoryAndIcon = Convert.ToString(g.ReadLine()).Split(";");
                iconsDictionary.Add(categoryAndIcon[0], categoryAndIcon[1]);
            }

            StreamReader f = new StreamReader(".\\Data\\ListOfQuestions.csv");
            f.ReadLine();


            for (int i = 0; i < File.ReadAllLines(".\\Data\\ListOfQuestions.csv").Length - 1; i++)
            {
                string s = Convert.ToString(f.ReadLine());
                string[] parts = s.Split(';');
                string answersStr = parts[3].Trim('[', ']');
                string[] answerParts = answersStr.Split(',');
                List<string> answers = answerParts.ToList();

                Question q = new Question(
                category: parts[0],
                difficulty: parts[1],
                questionText: parts[2],
                answers: answers);
                uniqueQuestions.Add(q);
            }
        }
        private void button_Start_Click(object sender, EventArgs e)
        {
            if (uniqueQuestions.Count != 0)
            {
                SetCategoryIcons();
                panel_StartGame.Visible = false;
                panel_Coins.Visible = true;
                label_Quize.Text = "Задача: ответить на все вопросы во всех категориях";
                label_KnowlegeMatrix.Text = "Выберите категорию";
                panel_CategoryButtons.Visible = true;
                button_50.Visible = true;
                button_PeopleHelp.Visible = true;
                button_FriendHelp.Visible = true;
                button_return.Text = "Возврат в меню";


            }
        }
        private  void button_Category_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            string labelName = button.Name.Replace("button_", "label_");
            Control[] foundControls = this.Controls.Find(labelName, true);
            string targetCategory = "";
            if (foundControls.Length > 0 && foundControls[0] is Label targetLabel)
            {
                targetCategory = targetLabel.Text;
            }
            var filteredQuestions = uniqueQuestions
                .Where(q => q.Category == targetCategory)
                .ToList();
            List <int> sequence = Randomazer.CastomRandom(filteredQuestions.Count, filteredQuestions.Count);

        }
    }
}
 