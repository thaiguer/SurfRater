using SurfRater.Avalonia.LocalData;

namespace SurfRater.Avalonia.Tests.LocalData;

[TestClass]
public class SpecialFolderKeyValueStoreTests
{
    [TestMethod]
    public void WriteThenRead()
    {
        string key = "mutley";
        string value = "ação";

        var firstInstance = new SpecialFolderKeyValueStore();
        firstInstance.Save(key, value);
        
        var secondInstance = new SpecialFolderKeyValueStore();
        string storedValue = secondInstance.Load(key);

        Assert.AreEqual(value, storedValue);
    }
}