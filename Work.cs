using System.Diagnostics;

namespace FolderFusion;
public class Work
{
    public static string dirNameExample = @"C:\...";
    // public static string dirName = @"C:\University\Programming\Math Statistics";
    public static void Start()
    {
        Settings settings = new Settings();
        settings.UpdateSettings();

        File.WriteAllText(Configs.GetProjectRootPath("Result.txt"), string.Empty); // make result empty
        string dirName = GetPathFromUser(); // get path of directory
        GetAllDirsAndFiles(dirName, settings.GetAllDirsAndFiles!, settings.IsWriteDirecoryName!); 
    }

    public static string GetPathFromUser()
    {
        System.Console.WriteLine($"Enter path to directory you want get all text from all files and directories: \nLike {dirNameExample}");
        string? path = Console.ReadLine();

        if (path == null)
        {
            throw new Exception("Path cann`t be null!");
        }

        return path;
    }

    public static void GetAllDirsAndFiles(string dirName, string methodSetting, string isIgnoreDirecoryName)
    {
        
        var directory = new DirectoryInfo(dirName);
        
        if (directory.Exists)
        {
            Console.WriteLine("Подкаталоги:");
            DirectoryInfo[] dirs = directory.GetDirectories();
            foreach (DirectoryInfo dir in dirs)
            {
                if (methodSetting.Equals("Consider"))
                {
                    if (IsAllow(dir.FullName, "Consider.txt"))
                    {
                        Console.WriteLine(dir.FullName);
                        GetAllDirsAndFiles(dir.FullName, methodSetting, isIgnoreDirecoryName);
                    }
                }
                if (methodSetting.Equals("Ignore"))
                {
                    if (!IsAllow(dir.FullName, "Ignore.txt"))
                    {
                        Console.WriteLine(dir.FullName);
                        GetAllDirsAndFiles(dir.FullName, methodSetting, isIgnoreDirecoryName);
                    }
                }
            }
            Console.WriteLine();

            Console.WriteLine("Файлы:");
            FileInfo[] files = directory.GetFiles();
            foreach (FileInfo file in files)
            {
                if (methodSetting.Equals("Consider"))
                {
                    if (IsAllow(file.FullName, "Consider.txt"))
                    {
                        Console.WriteLine(file.FullName);
                        GetAndWriteTextFromFile(file.FullName, isIgnoreDirecoryName);
                    }
                }

                if (methodSetting.Equals("Ignore"))
                {
                    if (!IsAllow(file.FullName, "Ignore.txt"))
                    {
                        Console.WriteLine(file.FullName);
                        GetAndWriteTextFromFile(file.FullName, isIgnoreDirecoryName);
                    }
                }
            }
        }
    }

    public static void GetAndWriteTextFromFile(string path, string isWriteDirecoryName)
    {
        bool isWriteDirName = isWriteDirecoryName.Equals("true");
        File.AppendAllText(Configs.GetProjectRootPath("Result.txt"), Environment.NewLine);
        string fileContents = File.ReadAllText(path);

        // if (isIgnore) 
       
        // System.Console.WriteLine(fileContents);
        // path = path.Replace(path , ""); 
        // path = path.Replace(path , "// "); 
        if (isWriteDirName)
            File.AppendAllText(Configs.GetProjectRootPath("Result.txt"), path);

        File.AppendAllText(Configs.GetProjectRootPath("Result.txt"), Environment.NewLine);
        File.AppendAllText(Configs.GetProjectRootPath("Result.txt"), fileContents);
        File.AppendAllText(Configs.GetProjectRootPath("Result.txt"), Environment.NewLine);
    }

    private static bool IsAllow(string path, string method)
    {
        string[] list = File.ReadAllLines(Configs.GetProjectRootPath(method));

        foreach (string str in list)
        {
            if (string.IsNullOrWhiteSpace(str)) 
                continue;

            // Для расширений файлов (начинаются с точки) - проверяем расширение
            if (str.StartsWith("."))
            {
                if (Path.GetExtension(path).Equals(str, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            // Для папок - проверяем имя папки
            else if (Directory.Exists(path))
            {
                string folderName = Path.GetFileName(path);
                if (folderName.Equals(str, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            // Для файлов - проверяем имя файла
            else if (File.Exists(path))
            {
                string fileName = Path.GetFileName(path);
                if (fileName.Equals(str, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
        }
        return false;
    }

    public static void OpenFile(string pathToFile)
    {
        Process.Start("notepad.exe", pathToFile);
    }
}