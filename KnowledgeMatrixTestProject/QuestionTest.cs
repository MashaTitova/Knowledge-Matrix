
using UsefullClassLibrary;


public class QuestionTests
{
    [Fact]
    public void Question_InitializesPropertiesCorrectly()
    {
        var category = "Математика";
        var difficulty = "Средний";
        var questionText = "Сколько будет 2+2?";
        var answers = new List<string> { "3", "4", "5" };

        var question = new Question(category, difficulty, questionText, answers);

        Assert.Equal(category, question.Category);
        Assert.Equal(difficulty, question.Difficulty);
        Assert.Equal(questionText, question.QuestionText);
        Assert.Same(answers, question.Answers); 
    }

    [Fact]
    public void ChoiseQuestion_ValidCategories_ReturnsFilteredQuestions()
    {
        var questions = new HashSet<Question>
        {
            new Question("Математика", "Легкий", "2+2?", new List<string>()),
            new Question("Физика", "Средний", "Что такое гравитация?", new List<string>()),
            new Question("Математика", "Сложный", "Решите уравнение", new List<string>()),
            new Question("Химия", "Легкий", "Формула воды?", new List<string>())
        };
        var categories = new List<string> { "Математика", "Физика" };

        var result = Question.ChoiseQuestion(categories, questions);

        Assert.Equal(3, result.Count); 
        Assert.Contains(result, q => q.Category == "Математика");
        Assert.Contains(result, q => q.Category == "Физика");
    }

    [Fact]
    public void ChoiseQuestion_EmptyCategories_ReturnsEmptyList()
    {
        var questions = new HashSet<Question>
        {
            new Question("Математика", "Легкий", "2+2?", new List<string>())
        };
        var categories = new List<string>();


        var result = Question.ChoiseQuestion(categories, questions);

        Assert.Empty(result);
    }

    [Fact]
    public void ChoiseQuestion_NonExistentCategories_ReturnsEmptyList()
    {
        var questions = new HashSet<Question>
        {
            new Question("Математика", "Легкий", "2+2?", new List<string>())
        };
        var categories = new List<string> { "Биология" };

        var result = Question.ChoiseQuestion(categories, questions);

        Assert.Empty(result);
    }



    [Fact]
    public void ChoiseQuestion_QuestionsIsEmpty_ReturnsEmptyList()
    {

        var questions = new HashSet<Question>();
        var categories = new List<string> { "Математика" };

        var result = Question.ChoiseQuestion(categories, questions);


        Assert.Empty(result);
    }
}