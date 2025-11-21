namespace SurfRater.Core.MathModel.Implementation;

public class SurfParameter
{
    public SurfParameter(string parameterName, double currentValue, double idealValue)
    {
        ParameterName = parameterName;
        ForecastValue = currentValue;
        IdealValue = idealValue;
    }

    public string ParameterName { get; set; }
    public double ForecastValue { get; set; }
    public double IdealValue { get; set; }
}