using GetQuestions;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using System.Windows.Forms.VisualStyles;
using UsefullClassLibrary;

namespace Knowledge_Matrix
{
    public partial class Form_KnowledgeMatrix : Form
    {
        static HashSet<Question> uniqueQuestions = new HashSet<Question>();
        static Dictionary<string, string> iconsDictionary = new Dictionary<string, string>();
        static List<String> choisenCategories = new List<String>();
        static List<Question> choisenQuestions = new List<Question>();
        private List<Question> currentQuestionsMix = new List<Question>();
        private List<Question> currentQuestions = new List<Question>();
        private int money = 0;
        private Dictionary<string, HashSet<string>> completedCategoriesLevels =
    new Dictionary<string, HashSet<string>>();
        private string currentCategory = "";
        private string currentLevel = "";
        int constantLenght = 0;
        static List<string> currentAnswers = new List<string>();
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
            if (button_return.Text == "Закончить игру")
            {
                DialogResult result = MessageBox.Show(
                  "Вы уверены, что хотите закончить игру?",
                  "Подтверждение",
                  MessageBoxButtons.YesNo,
                  MessageBoxIcon.Question
               );
                if (result == DialogResult.Yes)
                {
                    button_Info.Visible = true;
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
            if (button_return.Text == "Вернуться к уровням сложности")
            {
                flowLayoutPanel_DifficaltyLevel.Visible = true;
                button_50.Visible = false;
                button_PeopleHelp.Visible = false;
                button_FriendHelp.Visible = false;
                panel_Question.Visible = false;
                label_Quize.Text = "Выберите уровень сложности";
                button_return.Text = "Вернуться к категориям";
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
            button_Category1.Name = iconsDictionary.Keys.ElementAt(choisen[0]);

            label_Category2.Text = iconsDictionary.Keys.ElementAt(choisen[1]);
            button_Category2.BackgroundImage = Image.FromFile($".\\Icons\\{iconsDictionary.Values.ElementAt(choisen[1])}");
            button_Category2.Name = iconsDictionary.Keys.ElementAt(choisen[1]);

            label_Category3.Text = iconsDictionary.Keys.ElementAt(choisen[2]);
            button_Category3.BackgroundImage = Image.FromFile($".\\Icons\\{iconsDictionary.Values.ElementAt(choisen[2])}");
            button_Category3.Name = iconsDictionary.Keys.ElementAt(choisen[2]);

            label_Category4.Text = iconsDictionary.Keys.ElementAt(choisen[3]);
            button_Category4.BackgroundImage = Image.FromFile($".\\Icons\\{iconsDictionary.Values.ElementAt(choisen[3])}");
            button_Category4.Name = iconsDictionary.Keys.ElementAt(choisen[3]);

            label_Category5.Text = iconsDictionary.Keys.ElementAt(choisen[4]);
            button_Category5.BackgroundImage = Image.FromFile($".\\Icons\\{iconsDictionary.Values.ElementAt(choisen[4])}");
            button_Category5.Name = iconsDictionary.Keys.ElementAt(choisen[4]);

            label_Category6.Text = iconsDictionary.Keys.ElementAt(choisen[5]);
            button_Category6.BackgroundImage = Image.FromFile($".\\Icons\\{iconsDictionary.Values.ElementAt(choisen[5])}");
            button_Category6.Name = iconsDictionary.Keys.ElementAt(choisen[5]);
        }
        private void FillData()
        {
            try
            {
                ReadFile.CheckFile(".\\Data\\Icons.csv");
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                        $"{ex.Message}",
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                button_Start.Enabled = false;
            }
            StreamReader g = new StreamReader(".\\Data\\Icons.csv");
            g.ReadLine();
            for (int i = 0; i < File.ReadAllLines(".\\Data\\Icons.csv").Length - 1; i++)
            {
                try
                {
                    string[] categoryAndIcon = Convert.ToString(g.ReadLine()).Split(";");
                    iconsDictionary.Add(categoryAndIcon[0], categoryAndIcon[1]);
                }
                catch (Exception)
                {
                    MessageBox.Show(
                      "Ошибка в файле Icons" +
                      $"Строка {i + 2}",
                      "Ошибка",
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Error);
                    button_Start.Enabled = false;
                }

            }
            try
            {
                ReadFile.CheckFile(".\\Data\\ListOfQuestions.csv");
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                        $"{ex.Message}",
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                button_Start.Enabled = false;
            }
            StreamReader f = new StreamReader(".\\Data\\ListOfQuestions.csv");
            f.ReadLine();


            for (int i = 0; i < File.ReadAllLines(".\\Data\\ListOfQuestions.csv").Length - 1; i++)
            {
                try
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
                    if (!uniqueQuestions.Any(existingQ => existingQ.QuestionText == q.QuestionText))
                    {
                        uniqueQuestions.Add(q);
                    }
                }
                catch
                {
                    MessageBox.Show(
                      "Ошибка в файле ListOfQuestions" +
                      $"Строка {i + 2}",
                      "Ошибка",
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Error);
                    button_Start.Enabled = false;
                }



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
                button_Info.Visible = false;
                panel_Title.Visible = true;
                panel_MenuButtons.Visible = true;
                button_50.Enabled = true;
                button_PeopleHelp.Enabled = true;
                button_FriendHelp.Enabled = true;
                completedCategoriesLevels.Clear();
                choisenCategories.Clear();
                choisenQuestions.Clear(); ;
                currentQuestionsMix.Clear();
                currentQuestions.Clear();
                label_Coins.Text = "0";
                SetCategoryIcons();
                button_Answer1.Enabled = true;
                button_Answer2.Enabled = true;
                button_Answer3.Enabled = true;
                button_Answer4.Enabled = true;
                panel_StartGame.Visible = false;
                panel_Coins.Visible = true;
                label_Quize.Text = "Задача: ответить на вопросы всех категорий";
                label_KnowlegeMatrix.Text = "Выберите категорию";
                panel_CategoryButtons.Visible = true;
                button_return.Text = "Закончить игру";
                foreach (Control ctrl in panel_CategoryButtons.Controls)
                {
                    if (ctrl is Button button)
                    {
                        button.Enabled = true;
                    }
                }
                foreach (Control ctrl in flowLayoutPanel_DifficaltyLevel.Controls)
                {
                    if (ctrl is Button button)
                    {
                        button.Enabled = true;
                    }
                }
            }
        }

        private bool ProcessAllButtonsInPanel(Control container)
        {
            bool flag = false;
            foreach (Control ctrl in container.Controls)
            {
                foreach (Control child in ctrl.Controls)
                {
                    if (child is Button but && but.Enabled)
                    {
                        flag = true;
                        return flag;
                    }
                    else if (ctrl.HasChildren)
                    {
                        // Рекурсивный вызов для вложенных контейнеров
                        ProcessAllButtonsInPanel(ctrl);
                        // Если флаг уже установлен, прерываем дальнейший поиск
                        if (flag) return flag;
                    }
                }

            }
            return flag;
        }
        private void button_Category_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            bool isEnabled = ProcessAllButtonsInPanel(panel_CategoryButtons);
            if (!isEnabled)
            {
                WinForm form = new WinForm();
                form.ShowDialog();
            }

            string labelName = button.Name.Replace("button_", "label_");
            label_KnowlegeMatrix.Text = $"Категория: {button.Name}";
            panel_CategoryButtons.Visible = false;
            label_Quize.Text = "Выберите уровень сложности";
            flowLayoutPanel_DifficaltyLevel.Visible = true;
            button_return.Text = "Вернуться к категориям";
            if (button.Name != currentCategory)
            {
                foreach (Control ctrl in flowLayoutPanel_DifficaltyLevel.Controls)
                {
                    foreach (Control child in ctrl.Controls)
                    {
                        if (child is Button but)
                        {
                            but.Enabled = true;
                        }
                    }
                }
            }


        }
        private void ChooseLevel(object sender, EventArgs e)
        {
            button_50.Enabled = true;
            button_PeopleHelp.Enabled = true;
            button_FriendHelp.Enabled = true;
            var button = (Button)sender;
            currentQuestionsMix.Clear();
            currentQuestions.Clear();
            button_50.Visible = true;
            button_PeopleHelp.Visible = true;
            button_FriendHelp.Visible = true;
            flowLayoutPanel_DifficaltyLevel.Visible = false;
            panel_Question.Visible = true;
            label_Quize.Text = $"Уровень: {button.Text}";
            button_return.Text = "Вернуться к уровням сложности";
            currentCategory = label_KnowlegeMatrix.Text.Replace("Категория: ", "");

            SetQuestions();
        }
        private void SetQuestions()
        {
            currentLevel = label_Quize.Text.Replace("Уровень: ", "");
            constantLenght = 0;
            // Фильтруем вопросы
            var currentQuestionsAll = choisenQuestions
                .Where(p => p.Category == currentCategory)
                .Where(p => p.Difficulty == currentLevel)
                .ToList();
            var random = new Random();
            currentQuestions = currentQuestionsAll
                .OrderBy(x => random.Next())
                .Take(5)
                .ToList();
            constantLenght = currentQuestions.Count();
            if (constantLenght == 0)
            {
                MessageBox.Show("В данной категории и уровне сложности нет вопросов!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            currentQuestionsMix.Clear();
            List<int> mix = Randomazer.CastomRandom(currentQuestions.Count, currentQuestions.Count);
            for (int i = 0; i < mix.Count; i++)
            {
                currentQuestionsMix.Add(currentQuestions[mix[i]]);
            }

            // Показываем первый вопрос
            ShowNextQuestion();
        }


        private void ShowNextQuestion()
        {
            if (currentQuestions.Count() <= 0 || currentQuestionsMix.Count <= 0)
            {

                // Добавляем уровень в список пройденных для данной категории
                if (!completedCategoriesLevels.ContainsKey(currentCategory))
                {
                    completedCategoriesLevels.Add(currentCategory, new HashSet<string>());
                }
                completedCategoriesLevels[currentCategory].Add(currentLevel);
                UpdateDifficultyButtons();
                if (completedCategoriesLevels[currentCategory].Count == 3)
                {

                    label_Quize.Text = "Задача: ответить на все вопросы всех категорий";
                    label_KnowlegeMatrix.Text = "Выберите категорию";
                    button_return.Text = "Закончить игру";
                    panel_CategoryButtons.Visible = true;
                    panel_Question.Visible = false;
                    foreach (Control ctrl in panel_CategoryButtons.Controls)
                    {
                        foreach (Control child in ctrl.Controls)
                        {
                            if (child is Button but)
                            {
                                string category = but.Name;

                                if (category == currentCategory)
                                {
                                    but.Enabled = false;
                                }
                            }
                        }

                    }

                }
                currentQuestionsMix.Clear();
                currentQuestions.Clear();
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

            Question question = currentQuestionsMix[currentQuestionsMix.Count - 1];


            currentQuestionsMix.Remove(question);

            // Рассчитываем номер вопроса ПОСЛЕ удаления
            int totalQuestions = constantLenght;
            int questionsAnswered = totalQuestions - currentQuestionsMix.Count;
            int currentPosition = questionsAnswered; // Уже +1 не нужно, т.к. удалили вопрос

            label_YourLevel.Text = $"{currentPosition}/{totalQuestions}";
            label_NumberOfQuestion.Text = $"Вопрос {currentPosition}";

            // Отображаем вопрос и ответы
            label_AskingQuestion.Text = question.QuestionText;

            // Перемешиваем ответы
            List<int> answers = Randomazer.CastomRandom(4, question.Answers.Count);
            // Обновляем текст кнопок
            button_Answer1.Text = question.Answers[answers[0]];
            button_Answer2.Text = question.Answers[answers[1]];
            button_Answer3.Text = question.Answers[answers[2]];
            button_Answer4.Text = question.Answers[answers[3]];

            foreach (Control ctrl in panel_Question.Controls)
            {
                if (ctrl is Button button)
                {
                    button.Enabled = true;
                    button.Visible = true;
                }
            }
            button_50.Enabled = true;
            button_PeopleHelp.Enabled = true;
            button_FriendHelp.Enabled = true;


        }
        private void UpdateDifficultyButtons()
        {

            foreach (Control ctrl in flowLayoutPanel_DifficaltyLevel.Controls)
            {
                if (ctrl is Button button)
                {
                    string level = button.Text;

                    if (completedCategoriesLevels.ContainsKey(currentCategory) &&
                        completedCategoriesLevels[currentCategory].Contains(level))
                    {
                        button.Enabled = false;
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
                    earned = -20;
                }
                if (currentQuestion[0].Difficulty == "Сложный")
                {
                    earned = -35;
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
                MoneyLess();

            }

            ShowNextQuestion();
        }
        private void MoneyLess()
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
                button_Info.Visible = true;
                button_50.Visible = false;
                button_PeopleHelp.Visible = false;
                button_FriendHelp.Visible = false;
                panel_Question.Visible = false;
                money = 0;
                panel_StartGame.Visible = true;
                panel_Coins.Visible = false;
                label_Quize.Text = "Интеллектуальный квиз";
                label_KnowlegeMatrix.Text = "Матрица Знаний";

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

        private void button_50_Click(object sender, EventArgs e)
        {

            button_50.Enabled = false;
            try
            {
                Question currentQuestion = GetHint();
                string correctAnswer = currentQuestion.Answers[0];

                List<Button> wrongAnswerButtons = new List<Button>();
                foreach (Control ctrl in panel_Question.Controls)
                {
                    if (ctrl is Button button && button.Name.StartsWith("button_Answer"))
                    {
                        if (button.Text != correctAnswer)
                        {
                            wrongAnswerButtons.Add(button);
                        }
                    }
                }

                if (wrongAnswerButtons.Count < 2)
                {

                    return;
                }

                Random random = new Random();
                int firstIndex = random.Next(wrongAnswerButtons.Count);
                Button firstButton = wrongAnswerButtons[firstIndex];

                int secondIndex;
                do
                {
                    secondIndex = random.Next(wrongAnswerButtons.Count);
                } while (secondIndex == firstIndex);
                Button secondButton = wrongAnswerButtons[secondIndex];

                firstButton.Visible = false;
                secondButton.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"{ex.Message}",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                    );
                return;
            }

        }

        private void button_PeopleHelp_Click(object sender, EventArgs e)
        {
            int choisenAnswer = Randomazer.OtherOpinionGenerator();
            button_PeopleHelp.Enabled = false;
            try
            {
                Question currentQuestion = GetHint();
                Form_PeopleHelp form = new Form_PeopleHelp();
                List<string> Answers = currentQuestion.Answers;
                List<int> ans = Randomazer.CastomRandom(4, 4);
                form.textBox_CTextChange(Answers[choisenAnswer]);
                ans.Remove(choisenAnswer);
                form.textBox_ATextChange(Answers[ans[0]]);
                form.textBox_BTextChange(Answers[ans[1]]);
                form.textBox_DTextChange(Answers[ans[2]]);
                form.ShowDialog();

            }
            catch (Exception ex)
            {
                MessageBox.Show(
                   $"{ex.Message}",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                    );
                return;
            }

        }
        private void GetFriendHelpForm(object sender, EventArgs e)
        {
            button_FriendHelp.Enabled = false;

            try
            {
                Question currentQuestion = GetHint();
                FriendHelp form = new FriendHelp();
                currentAnswers = currentQuestion.Answers;
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"{ex.Message}",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                    );
                return;
            }

        }
        public static string GetFriendHelp()
        {
            int choisenAnswer = Randomazer.OtherOpinionGenerator();
            return currentAnswers[choisenAnswer];
        }
        private Question GetHint()
        {
            if (money < 30)
            {
                throw new Exception("Не хватает монеточек на подсказку");
            }
            money -= 30;
            label_Coins.Text = money.ToString();
            if (money < 0)
            {
                MoneyLess();
            }

            string currentQuestionText = label_AskingQuestion.Text;

            Question currentQuestion = uniqueQuestions
                .FirstOrDefault(q => q.QuestionText == currentQuestionText);

            if (currentQuestion == null)
            {
                throw new Exception("Текущий вопрос не найден в базе данных!");
            }
            return currentQuestion;
        }

        public void button_NewGame_Click()
        {
            button_Info.Visible = true;
            WinForm form = new WinForm();
            form.Close();
            button_50.Visible = false;
            button_PeopleHelp.Visible = false;
            button_FriendHelp.Visible = false;
            panel_Question.Visible = false;
            money = 0;
            panel_StartGame.Visible = true;
            panel_Coins.Visible = false;
            label_Quize.Text = "Интеллектуальный квиз";
            label_KnowlegeMatrix.Text = "Матрица Знаний";
        }

        private void button_Info_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                    "Интелектуальный квиз \"Матрица знаний\".\n" +
                    "Задача игры: ответить на все вопросы во всех категориях. \n" +
                    "При каждой новой игре категории и вопросы обновляются. \n" +
                    "За провильные ответы модно получить монеточки, за неправильные - потерять. \n" +
                    "Также за монеточки модно купить подсказки\n" +
                    "Важно! Если количество монеточек станет меньше 0, игра будет окончена (проигрыш).\n" +
                    "Хорошой игры!",
                    "Об игре",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Asterisk
                    );
            return;
        }
    }
}
 
