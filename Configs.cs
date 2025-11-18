namespace FolderFusion;
public class Configs 
{
    public string SettingsPath { get; }
    public string ConsiderPath { get; }
    public string IgnorePath { get; }
    public string ResultPath { get; }

    public Configs() 
    {
        SettingsPath = GetProjectRootPath("settings.json");
        ConsiderPath = GetProjectRootPath("Consider.txt");
        IgnorePath = GetProjectRootPath("Ignore.txt");
        ResultPath = GetProjectRootPath("Result.txt");
    }

    public static string GetProjectRootPath(string fileName)
    {
        string binPath = AppContext.BaseDirectory;
        string projectRoot = binPath[..binPath.IndexOf("bin")];
        return Path.Combine(projectRoot, fileName);
    }
}
