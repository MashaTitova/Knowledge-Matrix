using GetQuestions;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;
using static System.Windows.Forms.LinkLabel;


namespace Knowledge_Matrix
{
    public partial class Form_KnowledgeMatrix : Form
    {
        static HashSet<Question> uniqueQuestions = new HashSet<Question>();
        static Dictionary<string, string> iconsDictionary = new Dictionary<string, string>();
        static List<String> choisenCategories = new List<String>();
        static List<Question> choisenQuestions = new List<Question>();
        private List<Question> currentQuestionsMix = new List<Question>();
        private bool isGameWon = false;
        private List<Question> currentQuestions = new List<Question>();
        private int money = 0;
        private Dictionary<string, HashSet<string>> completedCategoriesLevels =
            new Dictionary<string, HashSet<string>>();
        private string currentCategory = "";
        private string currentLevel = "";
        private int constantLenght = 0;
        public static List<string> currentAnswers = new List<string>();
        private int saveMoney = 0;
        private Dictionary<string, HashSet<string>> saveCompletedCategoriesLevels =
            new Dictionary<string, HashSet<string>>();
        private bool wasSaved = false;
        static List<String> saveChoisenCategories = new List<String>();
        static List<Question> saveChoisenQuestions = new List<Question>();
        bool isLoss = false;
        public Form_KnowledgeMatrix()
        {
            InitializeComponent();
            this.BackgroundImageLayout = ImageLayout.Stretch;
            FillData();
            ReadSavingData();
        }
        private void SaveGameBeforExit()
        {
            StringBuilder gameData = new StringBuilder();

            gameData.AppendLine(money.ToString());

            if (completedCategoriesLevels.Count > 0)
            {
                foreach (var category in completedCategoriesLevels)
                {
                    string levels = string.Join(",", category.Value);
                    gameData.AppendLine($"{category.Key}:{levels}");
                }
                gameData.AppendLine();
            }
            else
            {
                gameData.AppendLine(); 
            }

            gameData.AppendLine(string.Join(";", choisenCategories));

            foreach (var question in choisenQuestions)
            {
                string answers = string.Join(",", question.Answers);
                gameData.AppendLine($"{question.Category};{question.Difficulty};{question.QuestionText};{answers}");
            }

            File.WriteAllText("Saving.txt", gameData.ToString());
        }
        private void KnoledgeMatrix_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isLoss)
            {
                DialogResult result = MessageBox.Show(
                 "Вы уверены, что хотите выйти из игры?",
                 "Подтверждение",
                 MessageBoxButtons.YesNo,
                 MessageBoxIcon.Question
               );
                if (result == DialogResult.Yes)
                {
                    DialogResult resultSave = MessageBox.Show(
                    "Сохранить игру?",
                    "Загрузка",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                    if (resultSave == DialogResult.Yes)
                    {
                        SaveGameBeforExit();
                        MessageBox.Show(
                       "Игра сохранена",
                       "Сохранение",
                       MessageBoxButtons.OK,
                       MessageBoxIcon.None);
                    }
                }
                else
                {
                    e.Cancel = true;
                }
            }
                
        }
        /// <summary>
        /// Переход между панелями
        /// </summary>
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
                    MessageBox.Show(
                    "До новых встреч",
                    "Выход из игры",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.None);
                    Application.Exit();
                }
            }
            if (button_return.Text == "Выход из игры")
            {
                DialogResult result = MessageBox.Show(
                  "Вы уверены, что хотите выйти из игры?",
                  "Подтверждение",
                  MessageBoxButtons.YesNo,
                  MessageBoxIcon.Question
                );
                if (result == DialogResult.Yes)
                {
                    DialogResult resultSave = MessageBox.Show(
                    "Сохранить игру?",
                    "Загрузка",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                    if (resultSave == DialogResult.Yes)
                    {
                        SaveGameBeforExit();
                        MessageBox.Show(
                       "Игра сохранена",
                       "Сохранение",
                       MessageBoxButtons.OK,
                       MessageBoxIcon.None);
                    }
                    money = 0;
                    panel_StartGame.Visible = true;
                    panel_Coins.Visible = false;
                    label_Quize.Text = "Интеллектуальный квиз";
                    label_KnowlegeMatrix.Text = "Матрица Знаний";
                    panel_CategoryButtons.Visible = false;
                    button_return.Text = "Выход из приложения";
                    button_InfoOrMenu.Text = "Об игре";
                    completedCategoriesLevels = new Dictionary<string, HashSet<string>>();
                }
                else
                {
                    wasSaved = false;
                }

            }
            if (button_return.Text == "Вернуться к категориям")
            {
                panel_CategoryButtons.Visible = true;
                label_Quize.Text = "Задача: ответить на все вопросы всех категорий";
                label_KnowlegeMatrix.Text = "Выберите категорию";
                button_return.Text = "Выход из игры";
                flowLayoutPanel_DifficaltyLevel.Visible = false;
                button_InfoOrMenu.Text = "Сохранить игру";
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
                button_InfoOrMenu.Visible = true;
            }
        }
        /// <summary>
        /// Выбор категорий
        /// </summary>
        private void SetCategoryIcons()
        {
            List<int> choisen = new List<int>();
            if (wasSaved)
            {
                var categoryIndexMap = new Dictionary<string, int>();
                int index = 0;
                foreach (var category in iconsDictionary.Keys)
                {
                    categoryIndexMap[category] = index++;
                }

                foreach (var category in saveChoisenCategories)
                {
                    if (categoryIndexMap.ContainsKey(category))
                    {
                        choisen.Add(categoryIndexMap[category]);
                    }
                }
            }
            else
            {
                choisenCategories.Clear();
                choisenQuestions.Clear();

                choisen = Randomazer.CastomRandom(iconsDictionary.Count, 6);
                for (int i = 0; i < choisen.Count; i++)
                {
                    choisenCategories.Add(iconsDictionary.Keys.ElementAt(choisen[i]));
                }
                choisenQuestions = Question.ChoiseQuestion(choisenCategories, uniqueQuestions);
            }
            // Назначение кнопкам изображений и подписей категорий
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
        /// <summary>
        /// Получение данных из файлов
        /// </summary>
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
        /// <summary>
        /// Начало новой игры, сброс всех параметров
        /// </summary>
        private void button_Start_Click(object sender, EventArgs e)
        {
            wasSaved = false;
            if (File.Exists("Saving.txt"))
            {
                ReadSavingData(); 

                if (saveChoisenQuestions.Count > 0 && saveChoisenCategories.Count > 0)
                {
                    DialogResult result = MessageBox.Show(
                        "Загрузить сохранённую игру?",
                        "Загрузка",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        if (LoadGame(true))
                        {
                            SetCategoryIcons();
                            UpdateAllCategoryButtons();
                            panel_Title.Visible = true;
                            panel_MenuButtons.Visible = true;
                            panel_StartGame.Visible = false;
                            panel_Coins.Visible = true;
                            label_Quize.Text = "Задача: ответить на вопросы всех категорий";
                            label_KnowlegeMatrix.Text = "Выберите категорию";
                            panel_CategoryButtons.Visible = true;
                            button_return.Text = "Выход из игры";
                            button_InfoOrMenu.Text = "Сохранить игру";
                            button_InfoOrMenu.Visible = true;
                            return;
                        }
                    }
                    else
                    {
                        saveMoney = 0;
                        saveCompletedCategoriesLevels = new Dictionary<string, HashSet<string>>();
                    }
                }
            }


            DialogResult newGameResult = MessageBox.Show(
                "Начать новую игру?",
                "Подтверждение",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (newGameResult == DialogResult.No)
            {
                Application.Exit();
                return;
            }
            isGameWon = false;
            UpdateAllCategoryButtons();
            button_InfoOrMenu.Text = "Сохранить игру";
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
            button_return.Text = "Выход из игры";
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

        /// <summary>
        /// Выбор категорий
        /// </summary>
        private void button_Category_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            currentCategory = button.Name;

            label_KnowlegeMatrix.Text = $"Категория: {button.Name}";
            panel_CategoryButtons.Visible = false;
            label_Quize.Text = "Выберите уровень сложности";
            flowLayoutPanel_DifficaltyLevel.Visible = true;
            button_return.Text = "Вернуться к категориям";

            UpdateDifficultyButtons();
            UpdateAllCategoryButtons();
        }
        /// <summary>
        /// Выбор уровня сложности
        /// </summary>
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
            button_InfoOrMenu.Visible = false;

            SetQuestions();
        }
        /// <summary>
        /// Отбор вопросов
        /// </summary>
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

            ShowNextQuestion();
        }
        /// <summary>
        /// Проверка прохождения категорий
        /// </summary>
        private void UpdateAllCategoryButtons()
        {
            foreach (Control ctrl in panel_CategoryButtons.Controls)
            {
                foreach (Control c in ctrl.Controls)
                {
                    if (c is Button categoryButton)
                    {
                        string categoryName = categoryButton.Name;
                        bool isCategoryCompleted = completedCategoriesLevels.ContainsKey(categoryName) &&
                                       completedCategoriesLevels[categoryName].Count == 3;
                        categoryButton.Enabled = !isCategoryCompleted;
                    }
                }
            }
        }
        /// <summary>
        /// Проверка на выигрыш
        /// </summary>
        private void CheckGameCompletion()
        {
            // Проверяем, что все выбранные категории завершены
            bool allCategoriesCompleted = true;
            foreach (string category in choisenCategories)
            {
                if (!completedCategoriesLevels.ContainsKey(category) ||
                    completedCategoriesLevels[category].Count < 3)
                {
                    allCategoriesCompleted = false;
                    break;
                }
            }

            if (allCategoriesCompleted && !isGameWon)
            {
                OpenSettingsForm();
            }
        }
        private void ShowNextQuestion()
        {

            if (currentQuestions.Count() <= 0 || currentQuestionsMix.Count <= 0)
            {
                if (!completedCategoriesLevels.ContainsKey(currentCategory))
                {
                    completedCategoriesLevels[currentCategory] = new HashSet<string>();
                }
                completedCategoriesLevels[currentCategory].Add(currentLevel);
                UpdateDifficultyButtons();

                bool isCategoryCompleted = completedCategoriesLevels[currentCategory].Count == 3;
                if (isCategoryCompleted)
                {
                    label_Quize.Text = "Задача: ответить на все вопросы всех категорий";
                    label_KnowlegeMatrix.Text = "Выберите категорию";
                    button_return.Text = "Выход из игры";
                    panel_CategoryButtons.Visible = true;
                    panel_Question.Visible = false;

                    UpdateAllCategoryButtons();
                    CheckGameCompletion();
                    return;
                }

                currentQuestionsMix.Clear();
                currentQuestions.Clear();
                panel_Question.Visible = false;
                MessageBox.Show(
                    "Все вопросы данной категории в данном уровне сложности пройдены",
                    "Пройдено",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Asterisk);
                flowLayoutPanel_DifficaltyLevel.Visible = true;
                button_50.Visible = false;
                button_PeopleHelp.Visible = false;
                button_FriendHelp.Visible = false;
                label_Quize.Text = "Выберите уровень сложности";
                button_return.Text = "Вернуться к категориям";
                button_InfoOrMenu.Text = "Сохранить игру";
                button_InfoOrMenu.Visible = true;
                return;
            }


            Question question = currentQuestionsMix[currentQuestionsMix.Count - 1];


            currentQuestionsMix.Remove(question);

            int totalQuestions = constantLenght;
            int currentPosition = totalQuestions - currentQuestionsMix.Count;

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
        /// <summary>
        /// Блокировка кнопок сложности
        /// </summary>
        private void UpdateDifficultyButtons()
        {

            bool isCurrentCategoryCompleted = completedCategoriesLevels.ContainsKey(currentCategory) &&
                                           completedCategoriesLevels[currentCategory].Count == 3;

            foreach (Control ctrl in flowLayoutPanel_DifficaltyLevel.Controls)
            {
                if (ctrl is Button button)
                {
                    string level = button.Text;

                    // Если категория завершена — блокируем все кнопки уровней
                    if (isCurrentCategoryCompleted)
                    {
                        button.Enabled = false;
                    }
                    else
                    {
                        // Иначе проверяем, пройден ли конкретно этот уровень
                        bool isLevelCompleted = completedCategoriesLevels.ContainsKey(currentCategory) &&
                                       completedCategoriesLevels[currentCategory].Contains(level);
                        button.Enabled = !isLevelCompleted;
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
        /// <summary>
        /// Проверка правильности ответа
        /// </summary>
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
                    earned = -30;
                }
                if (currentQuestion[0].Difficulty == "Средний")
                {
                    earned = -60;
                }
                if (currentQuestion[0].Difficulty == "Сложный")
                {
                    earned = -90;
                }
                money += earned;
                MessageBox.Show(
                   "Ответ неверный!\n" +
                   $"Верный ответ {currentQuestion[0].Answers[0]}\n" +
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
        /// <summary>
        /// Количество монет меньше 0
        /// </summary>
        private void MoneyLess()
        {
            isLoss = true;
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
                completedCategoriesLevels = new Dictionary<string, HashSet<string>>();
                button_InfoOrMenu.Visible = true;
            }
            else
            {

                DialogResult resultLoad = MessageBox.Show(
                "Загрузить сохраненную игру?",
                "Загрузка",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
                if(resultLoad == DialogResult.Yes)
                {
                   bool saved = LoadGame();
                    if (!saved)
                    {
                        MessageBox.Show(
                   "До новых встреч",
                   "Выход из игры",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.None);
                        Application.Exit();
                    }
                    panel_CategoryButtons.Visible = true;
                    label_Quize.Text = "Задача: ответить на все вопросы всех категорий";
                    label_KnowlegeMatrix.Text = "Выберите категорию";
                    button_return.Text = "Выход из игры";
                    flowLayoutPanel_DifficaltyLevel.Visible = false;
                    button_InfoOrMenu.Text = "Сохранить игру";
                    button_50.Visible = false;
                    button_PeopleHelp.Visible = false;
                    button_FriendHelp.Visible = false;
                    panel_Question.Visible = false;
                    button_InfoOrMenu.Visible = true;
                    
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
                currentAnswers = currentQuestion.Answers;
                Form_PeopleHelp form = new Form_PeopleHelp();
                this.Hide();
                DialogResult result = form.ShowDialog();
                this.Show();

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
                this.Hide();
                DialogResult result = form.ShowDialog();
                this.Show();
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
        /// <summary>
        /// Подготовка к получению подстказки
        /// </summary>
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
        private void OpenSettingsForm()
        {
            using (WinForm settingsForm = new WinForm())
            {
                this.Hide();
                DialogResult result = settingsForm.ShowDialog();

                if (result == DialogResult.OK)
                {
                    bool replay = settingsForm.GetIsReplay();

                    if (replay)
                    {
                        NewGame();
                    }
                }

                this.Show();
            }
        }

        public void NewGame()
        {
            button_InfoOrMenu.Visible = true;
            button_50.Visible = false;
            button_PeopleHelp.Visible = false;
            button_FriendHelp.Visible = false;
            panel_Question.Visible = false;
            money = 0;
            panel_StartGame.Visible = true;
            panel_Coins.Visible = false;
            label_Quize.Text = "Интеллектуальный квиз";
            label_KnowlegeMatrix.Text = "Матрица Знаний";
            completedCategoriesLevels = new Dictionary<string, HashSet<string>>();
            wasSaved = false;
            panel_CategoryButtons.Visible = false;
            button_return.Text = "Выход из приложения";
            button_InfoOrMenu.Text = "Об игре";

        }


        private void GetInfoOrSaveGame(object sender, EventArgs e)
        {
            if(button_InfoOrMenu.Text == "Об игре")
            {
                MessageBox.Show(
                   "Интелектуальный квиз \"Матрица знаний\".\n" +
                   "Задача игры: ответить на все вопросы во всех категориях. \n" +
                   "Вы можете загрузить сохраненную игру или начать новую.\n" +
                   "При каждой новой игре категории и вопросы обновляются. \n" +
                   "На этапе выбора категорий или выбора уровня сложности вы можете сохранить игру. \n" +
                   "За провильные ответы можно получить монеточки, за неправильные - потерять. \n" +
                   "Также за монеточки можно купить подсказки.\n" +
                   "Важно! Если количество монеточек станет меньше 0, игра будет окончена (проигрыш).\n" +
                   "Если игра была сохранена, при проигрыше вам будет предложено загрузить сохраненную игру.\n" +
                   "При выходе из приложения вам также будет придложено сохранить игру, чтобы вы могли вернуться к ней в другой раз.\n" +
                   "Хорошой игры!",
                   "Об игре",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Asterisk
                   );
                return;
            }
            if(button_InfoOrMenu.Text == "Сохранить игру") 
            {
                saveMoney = money;
                if(completedCategoriesLevels.Count == 0)
                {
                    saveCompletedCategoriesLevels = new Dictionary<string, HashSet<string>>();
                }
                foreach (var copy in completedCategoriesLevels)
                {
                    saveCompletedCategoriesLevels[copy.Key] = new HashSet<string>(copy.Value);
                }
                MessageBox.Show(
               "Игра сохранена",
               "Сохранение",
               MessageBoxButtons.OK,
               MessageBoxIcon.None);
            }
            

        }
        public void ReadSavingData()
        {
            try
            {
                if (!File.Exists("Saving.txt"))
                    return;

                string[] lines = File.ReadAllLines("Saving.txt");

                if (lines.Length < 4) 
                    return;

                if (int.TryParse(lines[0], out int loadedMoney))
                {
                    saveMoney = loadedMoney;
                }

                saveCompletedCategoriesLevels.Clear();
                int lineIndex = 1;

                while (!string.IsNullOrEmpty(lines[lineIndex]))
                {
                    string line = lines[lineIndex];
                    if (line.Contains(":"))
                    {
                        string[] parts = line.Split(':', 2);
                        string category = parts[0];
                        string levelsString = parts[1];

                        HashSet<string> levels = new HashSet<string>(
                            levelsString.Split(',')
                        .Where(l => !string.IsNullOrEmpty(l))
                        );

                        saveCompletedCategoriesLevels[category] = levels;
                    }
                    lineIndex++;
                }

                lineIndex++;

                saveChoisenCategories.Clear();
                if (lineIndex < lines.Length)
                {
                    string categoriesLine = lines[lineIndex];
                    if (!string.IsNullOrEmpty(categoriesLine))
                    {
                        saveChoisenCategories.AddRange(
                            categoriesLine.Split(';'));
                    }
                }

                saveChoisenQuestions.Clear();
                lineIndex++; 

                for (int i = lineIndex; i < lines.Length; i++)
                {
                    string line = lines[i];
                    if (string.IsNullOrEmpty(line))
                        continue;

                    string[] parts = line.Split(';');
                    if (parts.Length == 4)
                    {
                        List<string> answers = parts[3].Split(",").ToList();
                        Question q = new Question(
                        category: parts[0],
                        difficulty: parts[1],
                        questionText: parts[2],
                        answers: answers
                        );
                        saveChoisenQuestions.Add(q);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show(
                    $"Ошибка при загрузке сохранения",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
        private bool LoadGame(bool globalSave = false)
        {
            if (saveChoisenCategories.Count == 0 || saveChoisenQuestions.Count == 0)
            {
                MessageBox.Show(
                    "Сохранение не найдено",
                    "Загрузка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }

            money = saveMoney;
            label_Coins.Text = money.ToString();


            foreach (var category in saveCompletedCategoriesLevels)
            {
                completedCategoriesLevels[category.Key] = new HashSet<string>(category.Value);
            }
            if (globalSave)
            {
                choisenCategories.AddRange(saveChoisenCategories);
                choisenQuestions.AddRange(saveChoisenQuestions);
                wasSaved = true;
            }
            UpdateAllCategoryButtons();
            UpdateDifficultyButtons();

            MessageBox.Show(
                "Игра успешно загружена",
                "Загрузка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            return true;
        }
            
    }
}
 
