namespace UsefullClassLibrary
{
    public class Question
    {
        public string Category { get; set; }     
        public string Difficulty { get; set; }    
        public string QuestionText { get; set; }  
        public List<string> Answers { get; set; }   

        public Question(string category, string difficulty, string questionText, List<string> answers)
        {
            Category = category;
            Difficulty = difficulty;
            QuestionText = questionText;
            Answers = answers;
        }
        public static List<Question> ChoiseQuestion(List<string> categories, HashSet<Question> questions)
        {
            List<Question> sortedQuestions = new List<Question>();
            List<string> difficultyLevels = new List<string> {"Легкий", "Средний", "Сложный"};
            foreach (var category in categories)
            {
                foreach(var level in difficultyLevels)
                {
                    var filteredQuestions = questions
                        .Where(q => q.Category == category && q.Difficulty == level)
                        .ToList();
                    sortedQuestions.AddRange(filteredQuestions);
                }
            }
            return sortedQuestions;
            
        }
        
    }
}
