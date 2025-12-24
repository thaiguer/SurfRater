using SurfRater.Core.Model.Entities;

namespace SurfRater.Core.Tests.SurfParameterValues;

[TestClass]
public class SurfParameterValueTests
{
    [TestMethod]
    [DataRow(1, 1, 1)]
    [DataRow(2, 1, 0.5)]
    [DataRow(5, 1, 0.2)]
    [DataRow(5, 10, 0.5)]
    [DataRow(3, 8, 0.375)]
    public void SurfParameterValue(double currentValue, double idealValue, double expectedRatio)
    {
        var surfParameterValue = new MockSurfParameterValueTests(currentValue, idealValue);
        var calculatedRatio = surfParameterValue.Ratio;
        Assert.AreEqual(expectedRatio, calculatedRatio);
    }
}