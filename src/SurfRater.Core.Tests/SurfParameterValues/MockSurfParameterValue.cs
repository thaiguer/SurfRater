using SurfRater.Core.Model.Entities;

namespace SurfRater.Core.Tests.SurfParameterValues;

public class MockSurfParameterValueTests : SurfParameterValue
{
    public MockSurfParameterValueTests(double currentValue, double idealValue) : base(currentValue, idealValue)
    {
    }
}