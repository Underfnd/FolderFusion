using FolderFusion;

public class StartProgram
{
    public static void Start()
    {
        Configs configs = new Configs();
        bool isProcessing = true;

        while (isProcessing)
        {
            Console.WriteLine("1. Start work");
            Console.WriteLine("2. Open Settings file");
            Console.WriteLine("3. Open Consider list file");
            Console.WriteLine("4. Open Ignore list file");
            Console.WriteLine("5. Open Result file");
            Console.WriteLine("6. Change Settings");
            Console.WriteLine("7. Exit");

            string? input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    Work.Start();
                    break;
                case "2":
                    Work.OpenFile(configs.SettingsPath);
                    break;
                case "3":
                    Work.OpenFile(configs.ConsiderPath);
                    break;
                case "4":
                    Work.OpenFile(configs.IgnorePath);
                    break;
                case "5":
                    Work.OpenFile(configs.ResultPath);
                    break;
                case "6":
                    Settings.ChangeSettings();
                    break;
                case "7":
                    isProcessing = false;
                    break;
                default:
                    Console.WriteLine("Shit, are you blind?");
                    break;
            }
        }
    }
}