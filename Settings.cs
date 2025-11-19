using System.Text.Json;

namespace FolderFusion;
public class Settings
{
    public string? GetAllDirsAndFiles {get; set;} // Use Consider.txt or Ignore.txt?
    public string? IsWriteDirecoryName {get; set;} // Ignore direcory name?
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
                IsWriteDirecoryName = settings.IsWriteDirecoryName;
            }
        }
    }

    public static void ChangeSettings()
    {
        Configs configs = new Configs();
        Settings currentSettings = new Settings();
        currentSettings.UpdateSettings(); // Загружаем текущие настройки

        bool editing = true;

        while (editing)
        {
            Console.Clear();
            Console.WriteLine("=== Изменение настроек ===");
            Console.WriteLine($"1. Метод фильтрации: {currentSettings.GetAllDirsAndFiles ?? "Consider"}");
            Console.WriteLine($"2. Запись пути директории: {currentSettings.IsWriteDirecoryName ?? "true"}");
            Console.WriteLine("3. Сохранить и выйти");
            Console.WriteLine("4. Выйти без сохранения");
            Console.WriteLine("===========================");

            string? input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    Console.WriteLine("Выберите метод фильтрации:");
                    Console.WriteLine("1. Consider - обрабатывать только указанные файлы/папки");
                    Console.WriteLine("2. Ignore - обрабатывать все, кроме указанных файлов/папок");
                    
                    string? filterInput = Console.ReadLine();
                    currentSettings.GetAllDirsAndFiles = filterInput switch
                    {
                        "1" => "Consider",
                        "2" => "Ignore",
                        _ => currentSettings.GetAllDirsAndFiles
                    };
                    Console.WriteLine($"Установлено: {currentSettings.GetAllDirsAndFiles}");
                    Console.WriteLine("Нажмите любую клавишу для продолжения...");
                    Console.ReadKey();
                    break;

                case "2":
                    Console.WriteLine("Записывать полный путь директории?");
                    Console.WriteLine("1. Да (true)");
                    Console.WriteLine("2. Нет (false)");
                    
                    string? pathInput = Console.ReadLine();
                    currentSettings.IsWriteDirecoryName = pathInput switch
                    {
                        "1" => "true",
                        "2" => "false",
                        _ => currentSettings.IsWriteDirecoryName
                    };
                    Console.WriteLine($"Установлено: {currentSettings.IsWriteDirecoryName}");
                    Console.WriteLine("Нажмите любую клавишу для продолжения...");
                    Console.ReadKey();
                    break;

                case "3":
                    SaveSettings(currentSettings, configs.SettingsPath);
                    Console.WriteLine("Настройки сохранены!");
                    Console.WriteLine("Нажмите любую клавишу для продолжения...");
                    Console.ReadKey();
                    editing = false;
                    break;

                case "4":
                    Console.WriteLine("Изменения не сохранены!");
                    Console.WriteLine("Нажмите любую клавишу для продолжения...");
                    Console.ReadKey();
                    editing = false;
                    break;

                default:
                    Console.WriteLine("Неверный выбор! Нажмите любую клавишу...");
                    Console.ReadKey();
                    break;
            }
        }
    }

    private static void SaveSettings(Settings settings, string settingsPath)
    {
        try
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(settings, options);
            File.WriteAllText(settingsPath, json);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при сохранении настроек: {ex.Message}");
        }
    }
}