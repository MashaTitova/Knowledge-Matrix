
using GetQuestions; 

public class RandomazerTests
{
    [Fact]
    public void CastomRandom_ValidParameters_ReturnsCorrectCount()
    {

        int length = 10;
        int number = 5;

        var result = Randomazer.CastomRandom(length, number);

        Assert.Equal(number, result.Count);
        Assert.True(result.All(x => x >= 0 && x < length));
    }

    [Fact]
    public void CastomRandom_NumberEqualsLength_ReturnsAllNumbers()
    {
        int length = 5;
        int number = 5;

        var result = Randomazer.CastomRandom(length, number);

        Assert.Equal(length, result.Count);
        Assert.True(result.Distinct().Count() == length);
        Assert.True(result.Min() == 0);
        Assert.True(result.Max() == length - 1);
    }

    [Fact]
    public void CastomRandom_NumberIsZero_ReturnsEmptyList()
    {
        int length = 10;
        int number = 0;


        var result = Randomazer.CastomRandom(length, number);

        Assert.Empty(result);
    }

    [Fact]
    public void CastomRandom_ReturnsUniqueNumbers()
    {
        int length = 20;
        int number = 10;

        var result = Randomazer.CastomRandom(length, number);

        var distinctCount = result.Distinct().Count();
        Assert.Equal(result.Count, distinctCount);
    }

    [Fact]
    public void OtherOpinionGenerator_ReturnsValuesInRange()
    {
        for (int i = 0; i < 100; i++)
        {
            var result = Randomazer.OtherOpinionGenerator();
            Assert.True(result >= 0 && result <= 3);
        }
    }

    [Fact]
    public void OtherOpinionGenerator_FollowsProbabilityDistribution()
    {
        var results = new Dictionary<int, int>
        {
            [0] = 0,
            [1] = 0,
            [2] = 0,
            [3] = 0
        };
        int totalCalls = 10000;

        for (int i = 0; i < totalCalls; i++)
        {
            var result = Randomazer.OtherOpinionGenerator();
            results[result]++;
        }

        decimal expectedZeroPercent = 62.5m;
        decimal tolerance = 5.0m; 

        decimal actualZeroPercent = (decimal)results[0] / totalCalls * 100;

        Assert.InRange(actualZeroPercent, expectedZeroPercent - tolerance, expectedZeroPercent + tolerance);

        foreach (var key in new[] { 1, 2, 3 })
        {
            decimal actualPercent = (decimal)results[key] / totalCalls * 100;
            Assert.InRange(actualPercent, 7.5m, 17.5m); 
        }
    }

    [Fact]
    public void OtherOpinionGenerator_MultipleCalls_NotAlwaysReturnsSameValue()
    {
        var differentResults = new HashSet<int>();

        for (int i = 0; i < 50; i++)
        {
            differentResults.Add(Randomazer.OtherOpinionGenerator());
        }

        Assert.True(differentResults.Count > 1);
    }
}