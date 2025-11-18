using System.Text.Json;

namespace FolderFusion;
public class Settings
{
    public string? GetAllDirsAndFiles = "Consider"; // it`s default parameter, it`s will be update in UpdateSettings() and other too
    public void UpdateSettings()
    {
        Configs configs = new Configs();

        string settingsPath = configs.SettingsPath;

        if (File.Exists(settingsPath))
        {
            string json = File.ReadAllText(settingsPath);
            Settings? settings = JsonSerializer.Deserialize<Settings>(json) ?? new Settings();

            if (settings != null)
            {
                GetAllDirsAndFiles = settings.GetAllDirsAndFiles;
            }
        }
    }
}