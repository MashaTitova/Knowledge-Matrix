using GetQuestions;
using System.Reflection.Emit;
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
        private List<Question> currentQuestions; 
        private int currentQuestionIndex = 0;
        private int money = 0;
        private Dictionary<string, HashSet<string>> completedCategoriesLevels =
    new Dictionary<string, HashSet<string>>();
        public  Form_KnowledgeMatrix()
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
            if (button_return.Text == "Закончить игру")
            {
                DialogResult result = MessageBox.Show(
                  "Вы уверены, что хотите закончить игру?",
                  "Подтверждение",
                  MessageBoxButtons.YesNo,
                  MessageBoxIcon.Question
               );
                if(result == DialogResult.Yes)
                {
                    money = 0;
                    panel_StartGame.Visible = true;
                    panel_Coins.Visible = false;
                    label_Quize.Text = "Интеллектуальный квиз";
                    label_KnowlegeMatrix.Text = "Матрица Знаний";
                    panel_CategoryButtons.Visible = false;
                    button_return.Text = "Выход из приложения";
                }
                
            }
            if (button_return.Text == "Вернуться к категориям")
            {
                panel_CategoryButtons.Visible = true;
                label_Quize.Text = "Задача: ответить на все вопросы всех категорий";
                label_KnowlegeMatrix.Text = "Выберите категорию";
                button_return.Text = "Закончить игру";
                flowLayoutPanel_DifficaltyLevel.Visible = false;
            }
            if(button_return.Text == "Вернуться к уровням сложности")
            {
                flowLayoutPanel_DifficaltyLevel.Visible = true;
                button_50.Visible = false;
                button_PeopleHelp.Visible = false;
                button_FriendHelp.Visible = false;
                panel_Question.Visible = false;
                label_Quize.Text = "Выберите уровень сложности";
                button_return.Text = "Вернуться к категориям";
            }
            currentQuestionIndex = 0;
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
            completedCategoriesLevels.Clear();
            if (uniqueQuestions.Count != 0)
            {
                DialogResult result = MessageBox.Show(
                  "Начать новую игру?",
                  "Подтверждение",
                  MessageBoxButtons.YesNo,
                  MessageBoxIcon.Question
               );
                SetCategoryIcons();
                panel_StartGame.Visible = false;
                panel_Coins.Visible = true;
                label_Quize.Text = "Задача: ответить на вопросы всех категорий";
                label_KnowlegeMatrix.Text = "Выберите категорию";
                panel_CategoryButtons.Visible = true;
                button_return.Text = "Закончить игру";

            }
        }
        private  void button_Category_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            string labelName = button.Name.Replace("button_", "label_");
            Control[] foundControls = this.Controls.Find(labelName, true);
            string targetCategory = "";
            if (foundControls.Length > 0 && foundControls[0] is System.Windows.Forms.Label targetLabel)
            {
                targetCategory = targetLabel.Text;
            }
            panel_CategoryButtons.Visible = false;
            label_Quize.Text = "Выберите уровень сложности";
            label_KnowlegeMatrix.Text = $"Категория: {targetCategory}";
            flowLayoutPanel_DifficaltyLevel.Visible = true;
            button_return.Text = "Вернуться к категориям";
            


        }
        private void ChooseLevel (object sender, EventArgs e)
        {
            var button = (Button)sender;
            button_50.Visible = true;
            button_PeopleHelp.Visible = true;
            button_FriendHelp.Visible = true;
            flowLayoutPanel_DifficaltyLevel.Visible = false;
            panel_Question.Visible = true;
            label_Quize.Text =  $"Уровень: {button.Text}";
            button_return.Text = "Вернуться к уровням сложности";
            SetQuestions();
        }
        private void SetQuestions()
        {
            string category = label_KnowlegeMatrix.Text.Replace("Категория: ", "");
            string level = label_Quize.Text.Replace("Уровень: ", "");

            // Фильтруем вопросы
            currentQuestions = choisenQuestions
                .Where(p => p.Category == category)
                .Where(p => p.Difficulty == level)
                .ToList();


            // Показываем первый вопрос
            ShowNextQuestion();
        }

        private void ShowNextQuestion()
        {
            
            if (currentQuestionIndex >= currentQuestions.Count)
            {
                string category = label_KnowlegeMatrix.Text.Replace("Категория: ", "");
                string level = label_Quize.Text.Replace("Уровень: ", "");
                currentQuestionIndex = 0;
                // Добавляем уровень в список пройденных для данной категории
                if (!completedCategoriesLevels.ContainsKey(category))
                {
                    completedCategoriesLevels.Add(category, new HashSet<string>());
                }
                completedCategoriesLevels[category].Add(level);
                panel_Question.Visible = false;
                MessageBox.Show(
                   "Все вопросы данной категории и данного уровня сложности пройдены",
                   "Пройдено",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Asterisk);
                flowLayoutPanel_DifficaltyLevel.Visible = true;
                button_50.Visible = false;
                button_PeopleHelp.Visible = false;
                button_FriendHelp.Visible = false;
                panel_Question.Visible = false;
                label_Quize.Text = "Выберите уровень сложности";
                button_return.Text = "Вернуться к категориям";
                return;

            }

            Question question = currentQuestions[currentQuestionIndex];
            label_AskingQuestion.Text = question.QuestionText;

            // Перемешиваем ответы
            List<int> answers = Randomazer.CastomRandom(4, question.Answers.Count);

            // Обновляем текст кнопок
            button_Answer1.Text = question.Answers[answers[0]];
            button_Answer2.Text = question.Answers[answers[1]];
            button_Answer3.Text = question.Answers[answers[2]];
            button_Answer4.Text = question.Answers[answers[3]]; 

            // Обновляем индикаторы прогресса
            label_YourLevel.Text = $"{currentQuestionIndex + 1}/{5}";
            label_NumberOfQuestion.Text = $"Вопрос {currentQuestionIndex + 1}";
        }
        private void UpdateDifficultyButtons()
        {
            string currentCategory = label_KnowlegeMatrix.Text.Replace("Категория: ", "");

            foreach (Control ctrl in flowLayoutPanel_DifficaltyLevel.Controls)
            {
                if (ctrl is Button button)
                {
                    string level = button.Text; 

                    if (completedCategoriesLevels.ContainsKey(currentCategory) &&
                        completedCategoriesLevels[currentCategory].Contains(level))
                    {
                        button.Enabled = false; 
                        button.BackColor = Color.Gray; 
                    }
                    else
                    {
                        button.Enabled = true;
                        button.BackColor = SystemColors.Control; 
                    }
                    if (completedCategoriesLevels[currentCategory].Count == 3)
                    {
                        button.Enabled = false;
                    }
                    else
                    {
                        button.Enabled = true;
                    }
                }
            }
        }

        private void button_Answer1_Click(object sender, EventArgs e)
        {
            ProcessAnswer(button_Answer1.Text); 
        }

        private void button_Answer2_Click(object sender, EventArgs e)
        {
            ProcessAnswer(button_Answer2.Text);
        }

        private void button_Answer3_Click(object sender, EventArgs e)
        {
            ProcessAnswer(button_Answer3.Text);
        }

        private void button_Answer4_Click(object sender, EventArgs e)
        {
            ProcessAnswer(button_Answer4.Text);
        }

        private void ProcessAnswer(string answer)
        {
            var currentQuestion = choisenQuestions
               .Where(p => p.QuestionText == label_AskingQuestion.Text)
               .ToList();
            int earned = 0;
            if (answer == currentQuestion[0].Answers[0])
            {
                if (currentQuestion[0].Difficulty == "Легкий")
                {
                    earned = 15;
                }
                if (currentQuestion[0].Difficulty == "Средний")
                {
                    earned = 30;
                }
                if (currentQuestion[0].Difficulty == "Сложный")
                {
                    earned = 45;
                }
                money += earned;
                MessageBox.Show(
                   "Ответ верный!\n" +
                   $"Вы выиграли {earned} монеточек",
                   "Верно",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Asterisk);
            }
            else
            {
                if (currentQuestion[0].Difficulty == "Легкий")
                {
                    earned = -5;
                }
                if (currentQuestion[0].Difficulty == "Средний")
                {
                    earned = -15;
                }
                if (currentQuestion[0].Difficulty == "Сложный")
                {
                    earned = -25;
                }
                money += earned;
                MessageBox.Show(
                   "Ответ неверный!\n" +
                   $"Вы проиграли {-earned} монеточек",
                   "Неверно",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Asterisk);
            }
            label_Coins.Text = Convert.ToString(money);
            if (money < 0)
            {
                MessageBox.Show(
                   "У вас больше нет монеточек :( \n" +
                   $"Вы проиграли",
                   "Проигрыш",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Asterisk);
                label_AskingQuestion.Text = "Продолжение невозможно";
                button_Answer1.Text = "";
                button_Answer2.Text = "";
                button_Answer3.Text = "";
                button_Answer4.Text = "";
                button_Answer1.Enabled = false;
                button_Answer2.Enabled = false;
                button_Answer3.Enabled = false;
                button_Answer4.Enabled = false;
                DialogResult result = MessageBox.Show(
                  "Начать новую игру?",
                  "Новая игра",
                  MessageBoxButtons.YesNo,
                  MessageBoxIcon.Question
               );
                if (result == DialogResult.Yes)
                {
                    button_50.Visible = false;
                    button_PeopleHelp.Visible = false;
                    button_FriendHelp.Visible = false;
                    panel_Question.Visible = false;
                    money = 0;
                    panel_StartGame.Visible = true;
                    panel_Coins.Visible = false;
                    label_Quize.Text = "Интеллектуальный квиз";
                    label_KnowlegeMatrix.Text = "Матрица Знаний";
                    currentQuestionIndex = 0;

                }
                else
                {
                    MessageBox.Show(
                   "До новых встреч",
                   "Выход из игры",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.None);
                    Application.Exit();
                }
            }
            
            currentQuestionIndex++;
            ShowNextQuestion();
        }
    }
}
 