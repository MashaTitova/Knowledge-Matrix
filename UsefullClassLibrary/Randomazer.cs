using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace GetQuestions
{
    public class Randomazer
    {
        static Random random = new Random();
        public static List<int> CastomRandom(int lenght, int number)
        {
            List <int> choisen = new List <int>();
            while(choisen.Count != number)
            { 
                int num = random.Next(lenght);
                if (!choisen.Contains(num))
                {
                    choisen.Add(num);
                }
            }
            return choisen;
        }
    }
}
