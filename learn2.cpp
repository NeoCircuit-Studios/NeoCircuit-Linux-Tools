using System;
using System.Diagnostics;
using System.Threading;

class Program
{
    static void Main()
    {
        Console.Clear();
        Banner();

        Console.WriteLine("Choose an option:");
        Console.WriteLine("1: Install Wine for Farming Simulator (including Step 3)");
        Console.WriteLine("2: Update Scripts");
        Console.WriteLine("3: Start FS25 DedicatedServer and Make Shortcut");
        Console.WriteLine("4: Update Ubuntu System");
        Console.WriteLine("5: Delete Everything The Scripts Made");
        Console.WriteLine("6: install Wine and Run Hello-Wine test");
        Console.WriteLine("7: install Farming Simulator from mounted Cd-Rom (Step 1 Required!!!)");
        Console.WriteLine();

        Console.Write("Enter your choice [1-7]: ");
        var input = Console.ReadLine();

        switch (input)
        {
            case "1":
                InstallWineForFS();
                break;
            case "2":
                UpdateScripts();
                break;
            case "3":
                RunDedicatedServer();
                break;
            case "4":
                UpdateLinux();
                break;
            case "5":
                DeleteEverything();
                break;
            case "6":
                HelloWineTest();
                break;
            case "7":
                InstallFromCdRom();
                break;
            default:
                Console.WriteLine("Invalid option.");
                break;
        }
    }

    static void Banner()
    {
        Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
        Console.WriteLine("      NeoCircuit-Studios (NS)");
        Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
        Console.WriteLine("\nV0.1.3\nloading...\n");
    }

    static void RunCommand(string command)
    {
        var psi = new ProcessStartInfo
        {
            FileName = "/bin/bash",
            Arguments = $"-c \"{command}\"",
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false
        };

        using (var process = Process.Start(psi))
        {
            process.WaitForExit();
            Console.WriteLine(process.StandardOutput.ReadToEnd());
            Console.Error.WriteLine(process.StandardError.ReadToEnd());
        }
    }

    static void UpdateLinux()
    {
        Console.WriteLine("Updating System...\n");
        Thread.Sleep(1000);
        RunCommand("sudo apt update -y");
        Thread.Sleep(1000);
        Console.WriteLine("50%");
        RunCommand("sudo apt upgrade -y");
        Thread.Sleep(1000);
        Console.WriteLine("100%\n");
    }

    static void UpdateScripts()
    {
        RunCommand("sudo rm Update.sh NS-Update.sh");
        RunCommand("sudo wget https://raw.githubusercontent.com/NeoCircuit-Studios/fs-winehelper/main/NS-Update.sh");
        RunCommand("dos2unix NS-Update.sh");
        RunCommand("sudo chmod +x NS-Update.sh");
        RunCommand("sudo ./NS-Update.sh");
    }

    static void installDependencies()
    {
        Console.WriteLine("Installing dependencies...\n");

        RunCommand("sudo apt install dos2unix -y");
        RunCommand("sudo dpkg --add-architecture i386");
        RunCommand("sudo apt update -y");
        RunCommand("sudo apt install gcc-multilib g++-multilib libc6:i386 libc6-dev-i386 -y");
        RunCommand("sudo apt install wine64 wine32 libwine libwine:i386 fonts-wine -y");
        RunCommand("sudo apt install libx11-dev:i386 libfreetype6-dev:i386 flex -y");
        RunCommand("sudo apt install bison wget git -y");
        RunCommand("sudo apt install build-essential flex bison gcc-multilib g++-multilib libncurses5-dev libssl-dev libfreetype6-dev libx11-dev libxext-dev libxcb1-dev libxrandr-dev libxinerama-dev libxcomposite-dev libxfixes-dev libxml2-dev libxslt1-dev libfontconfig1-dev -y");
        RunCommand("sudo apt install -y p7zip-full");
        RunCommand("sudo apt autoremove -y");

        Console.WriteLine("All dependencies installed!\n");
    }

    static void InstallWineForFS()
    {
        UpdateLinux();
        UpdateScripts();
        installDependencies();
        MakeDir();
        DownloadScripts();
        ConfigScripts();
        RunCommand("sudo ./install-configure-FS.sh");
    }

    static void MakeDir()
    {
        RunCommand("rm -r NeoCircuit-Studios");
        RunCommand("mkdir NeoCircuit-Studios");
       // RunCommand("cd NeoCircuit-Studios"); //this does not work in cs
       Directory.SetCurrentDirectory("NeoCircuit-Studios")
       Directory.SetCurrentDirectory(".."); // to go back


     if (Directory.Exists("NeoCircuit-Studios"))
      {
          Directory.SetCurrentDirectory("NeoCircuit-Studios");
      }
      else
      {
         Console.WriteLine("Directory not found.");
      }
    }

    static void DownloadScripts()
    {
        var baseUrl = "https://raw.githubusercontent.com/NeoCircuit-Studios/fs-winehelper/main/NeoCircuit-Studios/";

        RunCommand($"sudo wget {baseUrl}install-configure-FS-from-source.sh");
        RunCommand($"sudo wget {baseUrl}install-configure-FS.sh");
        RunCommand($"sudo wget {baseUrl}Just-Install-Wine.sh");
        RunCommand($"sudo wget {baseUrl}Install-FS-Cdrom.sh");
    }

    static void ConfigScripts()
    {
        RunCommand("dos2unix install-configure-FS-from-source.sh");
        RunCommand("dos2unix install-configure-FS.sh");
        RunCommand("dos2unix Just-Install-Wine.sh");
        RunCommand("dos2unix Install-FS-Cdrom.sh");

        RunCommand("sudo chmod +x install-configure-FS-from-source.sh");
        RunCommand("sudo chmod +x install-configure-FS.sh");
        RunCommand("sudo chmod +x Just-Install-Wine.sh");
        RunCommand("sudo chmod +x Install-FS-Cdrom.sh");
    }

    static void RunDedicatedServer()
    {
        UpdateScripts();
        RunCommand("sudo wget https://raw.githubusercontent.com/NeoCircuit-Studios/fs-winehelper/main/NS-Run-Dedicated-Server.sh");
        RunCommand("dos2unix NS-Run-Dedicated-Server.sh");
        RunCommand("sudo chmod +x NS-Run-Dedicated-Server.sh");
        RunCommand("sudo ./NS-Run-Dedicated-Server.sh");
    }

    static void HelloWineTest()
    {
        UpdateLinux();
        UpdateScripts();
        installDependencies();
        MakeDir();
        DownloadScripts();
        ConfigScripts();
        RunCommand("sudo ./Just-Install-Wine.sh");
    }

    static void InstallFromCdRom()
    {
        UpdateLinux();
        UpdateScripts();
        MakeDir();
        DownloadScripts();
        ConfigScripts();
        RunCommand("sudo ./Install-FS-Cdrom.sh");
    }

    static void DeleteEverything()
    {
        RunCommand("sudo rm -r NeoCircuit-Studios");
        RunCommand("sudo rm Update.sh NS-Update.sh Run-Dedicated-Server.sh NS-Run-Dedicated-Server.sh ini.guust");
        Console.WriteLine("Everything is Deleted, Except Build.sh/NS-Build.sh. You can delete it manually.");
    }
}
