using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace SurfRater.Avalonia.LocalData;

public class SpecialFolderKeyValueStore : IKeyValueStore
{
    private string GetFilePath()
    {
        var folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        var appFolder = Path.Combine(folder, "SurfRater.LocalMemory");
        Directory.CreateDirectory(appFolder);
        return Path.Combine(appFolder, "kvstore.json");
    }

    private Dictionary<string, string> LoadAll()
    {
        var path = GetFilePath();
        if (!File.Exists(path)) return new Dictionary<string, string>();
        var json = File.ReadAllText(path);
        return JsonSerializer.Deserialize<Dictionary<string, string>>(json)
               ?? new Dictionary<string, string>();
    }

    public void Save(string key, string value)
    {
        var data = LoadAll();
        data[key] = value;
        File.WriteAllText(GetFilePath(), JsonSerializer.Serialize(data));
    }

    public string Load(string key)
    {
        var data = LoadAll();
        return data.TryGetValue(key, out var value) ? value : string.Empty;
    }
}