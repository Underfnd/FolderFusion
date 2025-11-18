namespace FolderFusion;
public class Configs 
{
    public string SettingsPath { get; }

    public Configs() 
    {
        SettingsPath = GetProjectRootPath("settings.json");
    }

    public static string GetProjectRootPath(string fileName)
    {
        string binPath = AppContext.BaseDirectory;
        string projectRoot = binPath[..binPath.IndexOf("bin")];
        return Path.Combine(projectRoot, fileName);
    }
}
