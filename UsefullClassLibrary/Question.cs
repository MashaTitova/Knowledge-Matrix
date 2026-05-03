public class Question
{
    // Категория вопроса
    public string Category { get; set; }
    // Сложность вопроса
    public string Difficulty { get; set; }
    // Текст вопроса
    public string QuestionText { get; set; }
    // Варианты ответа на вопрос
    public List<string> Answers { get; set; }

    /// <summary>
    /// Конструктор класса Question
    /// </summary>
    /// <param name="category">Категория вопроса</param>
    /// <param name= "difficulty">Сложность вопроса</param>
    /// <param name="questionText">Текст вопроса</param>
    /// <param name="answers">Варианты ответа на вопрос</param>
    public Question(string category, string difficulty, string questionText, List<string> answers)
    {
        Category = category;
        Difficulty = difficulty;
        QuestionText = questionText;
        Answers = answers;
    }
    /// <summary>
    /// Фильтрует все вопросы по заданным категориям
    /// </summary>
    /// <param name="categories">Катигории для фильтрации</param>
    /// <param name="questions">Коллекция с вопросвми</param>
    /// <returns>Возвращает список отфильтрованных вопросов</returns>
    public static List<Question> ChoiseQuestion(List<string> categories, HashSet<Question> questions)
    {
        List<Question> sortedQuestions = new List<Question>();
        foreach (var category in categories)
        {
            var filteredQuestions = questions
            .Where(q => q.Category == category)
            .ToList();
            sortedQuestions.AddRange(filteredQuestions);
        }
        return sortedQuestions;

    }
}