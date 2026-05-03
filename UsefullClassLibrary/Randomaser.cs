
namespace GetQuestions
{
    /// <summary>
    /// Класс для выбора случайных значений с учетом условий
    /// </summary>
    public class Randomazer
    {
        static Random random = new Random();
        /// <summary>
        /// Делает выборку заданного количество значений в диапазоне от 0 до заданного значения
        /// </summary>
        /// <param name="lenght">Диапазон значений выборки</param>
        /// <param name="number">Количество возвращаемых значений выборки</param>
        /// <returns>Возвращает выборку заданного количество значений number в диапазоне от 0 до заданного значения lenght</returns>
        public static List<int> CastomRandom(int lenght, int number)
        {
            List<int> choisen = new List<int>();
            while (choisen.Count != number)
            {
                int num = random.Next(lenght);
                if (!choisen.Contains(num))
                {
                    choisen.Add(num);
                }
            }
            return choisen;
        }
        /// <summary>
        /// Выбирает один из 4 вариантов ответа с учетом разной вероятностей
        /// </summary>
        /// <returns>Выьранный элемент</returns>
        public static int OtherOpinionGenerator()
        {
            int[] probability = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 2, 2, 3, 3];
            int trueAnswer = probability[random.Next(probability.Length)];
            return trueAnswer;
        }
    }

}