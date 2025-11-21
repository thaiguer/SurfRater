namespace SurfRater.Avalonia.LocalData;

public interface IKeyValueStore
{
    void Save(string key, string value);
    string Load(string key);
}