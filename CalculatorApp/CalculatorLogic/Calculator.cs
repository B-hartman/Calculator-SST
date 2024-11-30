namespace CalculatorLogic;

public static class Calculator
{
    private const bool IsPopulation = true;
    private const bool IsSample = false;
    
    public static double ComputeSampleStandardDeviation(List<double> valuesList)
    {
        return ComputeStandardDeviation(valuesList, IsSample);
    }
    
    public static double ComputePopulationStandardDeviation(List<double> valuesList)
    {
        return ComputeStandardDeviation(valuesList, IsPopulation);
    }

    public static double ComputeStandardDeviation(List<double> valuesList, bool isPopulation)
    {
        if (valuesList == null || valuesList.Count == 0)
        {
            throw new ArgumentException("valuesList parameter cannot be null or empty");
        }

        double mean = CalcMean(valuesList);
        double squareOfDifferences = CalcSquareOfDifferences(valuesList, mean);
        double variance = CalcVariance(squareOfDifferences, valuesList.Count, isPopulation);
        
        return Math.Sqrt(variance);
    }
    
    public static double CalcMean(List<double> values)
    {
        if (values == null || values.Count == 0)
        {
            throw new ArgumentException("Values cannot be null or empty.");
        }

        double result = 0;
        for (int i = 0; i < values.Count; i++)
        {
            result += values[i];
        }
        return result / values.Count;
    }

    public static double CalcSquareOfDifferences(List<double> values, double mean)
    {
        if (values == null || values.Count == 0)
        {
            throw new ArgumentException("values parameter cannot be null or empty");
        }

        double squareAccumulator = 0;
        for (int i = 0; i < values.Count; i++)
        {
            double difference = values[i] - mean;
            double squareOfDifference = difference * difference;
            squareAccumulator += squareOfDifference;
        }

        return squareAccumulator;
    }
    
    public static double CalcVariance(double squareOfDifferences, int numValues, bool isPopulation)
    {
        if (!isPopulation)
        {
            numValues -= 1;
        }

        if (numValues < 1)
        {
            throw new ArgumentException("numValues is too low (sample size must be >= 2, population size must be >= 1)");
        }

        return squareOfDifferences / numValues;
    }

    public static String CalcLinearRegression(List<double> xList, List<double> yList)
    {
        
        if ( xList == null || xList.Count == 0 || xList.Count != yList.Count)
        {
            throw new ArgumentException("xList and yList must have the same number of elements, and cannot be empty or null");
        }
        double xAccumulator = 0;
        double yAccumulator = 0;
        double pairAccumulator = 0;
        double squareAccumulator = 0;
        for (int i = 0; i < xList.Count; i++)
        {
            pairAccumulator += xList[i] * yList[i];
            xAccumulator += xList[i];
            yAccumulator += yList[i];
            squareAccumulator += Math.Pow(xList[i], 2);
        }
        return "Y = " + CalcSlope(xAccumulator,yAccumulator,pairAccumulator,squareAccumulator, xList.Count) + "X + " + CalcIntercept(xAccumulator,yAccumulator,pairAccumulator,squareAccumulator, xList.Count);
    }

    private static double CalcSlope(double sumOfXList, double sumOfYList, double sumOfPairs, double sumOfXSquared, int numValues)
    {
        return ((numValues * sumOfPairs) - (sumOfXList * sumOfYList)) /
               ((numValues * sumOfXSquared) - Math.Pow(sumOfXList, 2));
    }
    
    private static double CalcIntercept(double sumOfXList, double sumOfYList, double sumOfPairs, double sumOfXSquared, int numValues)
    {
        return ((sumOfYList * sumOfXSquared) - (sumOfXList * sumOfPairs)) /
               ((numValues * sumOfXSquared) - Math.Pow(sumOfXList, 2));
    }

    public static double CalcZScore(double value, double mean, double standardDeviation)
    {
        if (mean == 0 || standardDeviation == 0)
        {
            throw new ArgumentException("Mean and standard deviation cannot be 0");
        }
        return (value-mean)/(standardDeviation);
    }

    public static double PredictY(double x, double slope, double intercept)
    {
        return slope * x + intercept;
    }
}