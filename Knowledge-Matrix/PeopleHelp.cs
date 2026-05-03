using GetQuestions;
using System.Windows.Forms.DataVisualization.Charting;
namespace Knowledge_Matrix
{
    public partial class Form_PeopleHelp : Form
    {
        public Form_PeopleHelp()
        {
            InitializeComponent();
            GetAnswers();
        }
        private void GetAnswers()
        {
            List<string> answers = Form_KnowledgeMatrix.currentAnswers;
            int choisenAnswer = Randomazer.OtherOpinionGenerator();
            double[] randomDistribution = GenerateWeightedRandomDistribution(4, choisenAnswer, 2.0);
            List<int> shakeAnswers = Randomazer.CastomRandom(4, 4);
            double[] shakedRandomDistribution = new double[4];
            for(int i = 0; i < 4; i++)
            {
                shakedRandomDistribution[i] = randomDistribution[shakeAnswers[i]];
            }
            UpdateChart(shakedRandomDistribution);
           
            textBox_A.Text = answers[shakeAnswers[0]];
            textBox_B.Text = answers[shakeAnswers[1]];
            textBox_C.Text = answers[shakeAnswers[2]];
            textBox_D.Text = answers[shakeAnswers[3]];

        }
        private double[] GenerateWeightedRandomDistribution(int numOfCategories, int preferredIndex, double preferredWeight)
        {
            Random r = new Random();
            double[] weights = new double[numOfCategories];

            for (int i = 0; i < numOfCategories; i++)
            {
                weights[i] = (i == preferredIndex) ? preferredWeight : 1.0;
            }

            double[] values = new double[numOfCategories];
            double sum = 0;

            for (int i = 0; i < numOfCategories; i++)
            {
                values[i] = r.NextDouble() * weights[i];
                sum += values[i];
            }

            double[] percentages = new double[numOfCategories];
            for (int i = 0; i < numOfCategories; i++)
            {
                percentages[i] = Math.Round((values[i] / sum) * 100.0);
            }

            return percentages;
        }

        private void UpdateChart(double[] data)
        {
            chart.Series.Clear();
            chart.Titles.Clear();
            var title = new Title($"Результаты голосования зала");
            chart.Titles.Add(title);

            var series = new Series
            {
                ChartType = SeriesChartType.Pie,
                IsValueShownAsLabel = true
            };
            string[] labels = { "Категория A", "Категория B", "Категория C", "Категория D" };
            for (int i = 0; i < data.Length; i++)
            {
                series.Points.AddXY(labels[i], data[i]);
            }
            series.LabelFormat = "{#}%";
            chart.Series.Add(series);
            var chartArea = chart.ChartAreas[0];

            series.Palette = ChartColorPalette.Fire;

        }

    }
}
