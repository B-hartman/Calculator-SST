using CalculatorLogic;
namespace LogicTests;

public class Tests
{
    [Test]
    public void PopStandardDeviation_EmptyList_ExceptionThrown()
    {
        //Arrange
        List<double> emptyValues = new List<double>();
        //Act
        //Assert
        Assert.That(() => Calculator.ComputePopulationStandardDeviation(emptyValues), Throws.ArgumentException.With.Message.EqualTo("valuesList parameter cannot be null or empty"));
    }
    [Test]
    public void PopStandardDeviation_NullList_ExceptionThrown()
    {
        //Arrange
        List<double> nullValues = null;
        //Act
        //Assert
        Assert.That(() => Calculator.ComputePopulationStandardDeviation(nullValues), Throws.ArgumentException.With.Message.EqualTo("valuesList parameter cannot be null or empty"));
    }
    [Test]
    public void PopStandardDeviation_PassingList_Calculated()
    {
        //Arrange
        List<double> passingValues = new List<double>() { 12, 13, 18, 17, 15, 20 };
        //Act
        double standardDev = Calculator.ComputePopulationStandardDeviation(passingValues);
        //Assert
        Assert.That(standardDev, Is.EqualTo(2.7938424357067).Within(1e-10));
    }
    [Test]
    public void SampStandardDeviation_EmptyList_ExceptionThrown()
    {
        //Arrange
        List<double> emptyValues = new List<double>();
        //Act
        //Assert
        Assert.That(() => Calculator.ComputeSampleStandardDeviation(emptyValues), Throws.ArgumentException.With.Message.EqualTo("valuesList parameter cannot be null or empty"));
    }
    [Test]
    public void SampStandardDeviation_NullList_ExceptionThrown()
    {
        //Arrange
        List<double> nullValues = null;
        //Act
        //Assert
        Assert.That(() => Calculator.ComputeSampleStandardDeviation(nullValues), Throws.ArgumentException.With.Message.EqualTo("valuesList parameter cannot be null or empty"));

    }
    [Test]
    public void SampStandardDeviation_PassingList_Calculated()
    {
        //Arrange
        List<double> passingValues = new List<double>() { 12, 13, 18, 17, 15, 20 };
        //Act
        double standardDev = Calculator.ComputeSampleStandardDeviation(passingValues);
        //Assert
        Assert.That(standardDev, Is.EqualTo(3.0605010483035).Within(1e-10));
    }
    [Test]
    public void Mean_EmptyList_ExceptionThrown()
    {
        //Arrange
        List<double> emptyValues = new List<double>();
        //Act
        //Assert
        Assert.That(() => Calculator.CalcMean(emptyValues), Throws.ArgumentException.With.Message.EqualTo("Values cannot be null or empty."));

    }   
    [Test]
    public void Mean_NullList_ExceptionThrown()
    {
        //Arrange
        List<double> nullValues = null;
        //Act
        //Assert
        Assert.That(() => Calculator.CalcMean(nullValues), Throws.ArgumentException.With.Message.EqualTo("Values cannot be null or empty."));
    }
    public void CalcSquareOfDifferences_EmptyList_ExceptionThrown()
    {
        //Arrange
        List<double> emptyValues = new List<double>();
        double fakeMean = 0;
        //Act
        //Assert
        Assert.That(() => Calculator.CalcSquareOfDifferences(emptyValues, fakeMean), Throws.ArgumentException.With.Message.EqualTo("values parameter cannot be null or empty"));
    }   
    [Test]
    public void CalcSquareOfDifferences_NullList_ExceptionThrown()
    {
        //Arrange
        List<double> nullValues = null;
        double fakeMean = 0;
        //Act
        //Assert
        Assert.That(() => Calculator.CalcSquareOfDifferences(nullValues, fakeMean), Throws.ArgumentException.With.Message.EqualTo("values parameter cannot be null or empty"));

        
    }   
    [Test]
    public void Variance_SmallListSample_ExceptionThrown()
    {
        //Arrange
        int smallListSize = 1;
        double fakeSquareOfDifferences = 250;
        bool notPopulation = false;
        //Act
        //Assert
        Assert.That(() => Calculator.CalcVariance(fakeSquareOfDifferences, smallListSize, notPopulation), Throws.ArgumentException.With.Message.EqualTo("numValues is too low (sample size must be >= 2, population size must be >= 1)"));
    }   
    [Test]
    public void Variance_SmallListPopulation_ExceptionThrown()
    {
        //Arrange
        int smallListSize = 0;
        double fakeSquareOfDifferences = 250;
        bool isPopulation = true;
        //Act
        //Assert
        Assert.That(() => Calculator.CalcVariance(fakeSquareOfDifferences, smallListSize, isPopulation), Throws.ArgumentException.With.Message.EqualTo("numValues is too low (sample size must be >= 2, population size must be >= 1)"));
    }

    [Test]
    public void LinearRegression_NullList_ExceptionThrown()
    {
        //Arrange
        List<double> nullValues = null;
        List<double> fakeYList = new List<double>() { 10, 11, 12 };
        //Act
        //Assert
        Assert.That(() => Calculator.CalcLinearRegression(nullValues, fakeYList), Throws.ArgumentException.With.Message.EqualTo("xList and yList must have the same number of elements, and cannot be empty or null"));

    }

    [Test]
    public void LinearRegression_EmptyList_ExceptionThrown()
    {
        //Arrange
        List<double> emptyValues = new List<double>();
        List<double> fakeYList = new List<double>() { 10, 11, 12 };
        //Act
        //Assert
        Assert.That(() => Calculator.CalcLinearRegression(emptyValues, fakeYList), Throws.ArgumentException.With.Message.EqualTo("xList and yList must have the same number of elements, and cannot be empty or null"));
    }
    
    [Test]
    public void LinearRegression_MismatchedListCounts_ExceptionThrown()
    {
        //Arrange
        List<double> fakeXList = new List<double>() { 1 };
        List<double> fakeYList = new List<double>() { 10, 11, 12 };
        //Act
        //Assert
        Assert.That(() => Calculator.CalcLinearRegression(fakeXList, fakeYList), Throws.ArgumentException.With.Message.EqualTo("xList and yList must have the same number of elements, and cannot be empty or null"));
    }
    
    [Test]
    public void LinearRegression_SimpleList_RegressionCalculated()
    {
        //Arrange
        List<double> xList = new List<double>() { 10, 20, 30, 40, 50 };
        List<double> yList = new List<double>() { 10, 20, 30, 40, 50 };
        //Act
        String result = Calculator.CalcLinearRegression(xList, yList);
        //Assert
        Assert.That(result, Is.EqualTo("Y = 1X + 0"));
    }
    
    [Test]
    public void Zscore_DividebyZeroMean_ExceptionThrown()
    {
        //Arrange
        double fakeValue = 100;
        double mean = 0;
        double stdDev = 100;
        //Act
        //Assert
        Assert.That(() => Calculator.CalcZScore(fakeValue,mean,stdDev), Throws.ArgumentException.With.Message.EqualTo("Mean and standard deviation cannot be 0"));
    }
    
    [Test]
    public void Zscore_DividebyZeroStdDev_ExceptionThrown()
    {
        //Arrange
        double fakeValue = 100;
        double mean = 100;
        double stdDev = 0;
        //Act
        //Assert
        Assert.That(() => Calculator.CalcZScore(fakeValue,mean,stdDev), Throws.ArgumentException.With.Message.EqualTo("Mean and standard deviation cannot be 0"));
        
    }
    
    [Test]
    public void Zscore_CorrectScore_ZScoreCalculated()
    {
        //Arrange
        double value = 90;
        double mean = 100;
        double stdDev = 10;
        //Act
        double Z = Calculator.CalcZScore(value, mean, stdDev);
        //Assert
        Assert.That(Z, Is.EqualTo(-1.0));
    }
    [Test]
    public void PredictY_SimpleEquation_Calculated()
    {
        //Arrange
        double value = 1.535;
        double slope = 61.272186542107434;
        double intercept = -39.061955918838656;
        //Act
        double result = Calculator.PredictY(value, slope, intercept);
        //Assert
        Assert.That(result, Is.EqualTo(54.990850423296244));
    }
}