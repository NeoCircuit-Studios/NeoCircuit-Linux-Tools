// NeoCircuit-Studios (NS) 2025
using Microsoft.VisualBasic.FileIO;
using System;
using System.Diagnostics;
using System.Threading;

//todo

//Consider Console.Clear() before displaying the main menu for better UX.

//Avoid goto

class Core
{
    static void Main()
    {

        ShowBanner();
        //Update_NCLT(); // to update the main script //todo: in paralle? also tell the user it is downloading.
        Console.WriteLine();
        Console.WriteLine("Welcome to NeoCircuit-Studios (NS)!\n");
        Thread.Sleep(2000);
        Console.WriteLine();
        Console.WriteLine();
    retry: // Loop back to the menu if needed
        Console.WriteLine("Choose an Tool or APP to get more options:");
        Console.WriteLine();

        Console.WriteLine("1: Wine");
        Console.WriteLine("2: SSH");
        Console.WriteLine("3: Farming Simulator 22-25.");
        Console.WriteLine("4: Update Ubuntu System.");
        Console.WriteLine("5: Delete Everything The Scripts Made.");
        Console.WriteLine(); //also ollama
        Thread.Sleep(500);

        Console.Write("Enter your choice [1-5]: ");
        var input = Console.ReadLine();

        switch (input)
        {
            case "1":
                InstallWineScriptandRun();
                break;
            case "2":
                InstallSSH();
                break;
            case "3":
                Farming_Simulator();
                break;
            case "4":
                UpdateLinux();
                break;
            case "5":
                DeleteEverything();
                break;
            case "6":
                //HelloWineTest();
                Console.WriteLine("Invalid option.");
                goto retry; // Loop back to the menu
                            // break;
            case "7":
                //InstallFromCdRom();
                Console.WriteLine("Invalid option.");
                goto retry; // Loop back to the menu
                            // break;
            default:
                Console.WriteLine("Invalid option.");
                goto retry; // Loop back to the menu
                //break;

        }


    }

    static void ShowBanner()
    {
        Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
        Console.WriteLine("      NeoCircuit-Studios (NS)");
        Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\n");

        // Console.Beep(659, 200); // E5  // windows only // cool for error
    }

    static void RunCommand(string command)
    {
        var psi = new ProcessStartInfo
        {
            FileName = "/bin/bash",
            Arguments = $"-c \"{command}\"",
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        using var process = new Process { StartInfo = psi };

        process.OutputDataReceived += (sender, e) =>
        {
            if (!string.IsNullOrEmpty(e.Data))
                Console.WriteLine(e.Data);
        };

        process.ErrorDataReceived += (sender, e) =>
        {
            if (!string.IsNullOrEmpty(e.Data))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Data);
                Console.ResetColor();
            }
        };

        process.Start();

        process.BeginOutputReadLine();
        process.BeginErrorReadLine();

        process.WaitForExit();
    }

    static void Update_NCLT()
    {
    }

    static void InstallWineScriptandRun()
    {
    retry2: // Loop back if needed

        Console.WriteLine();
        Console.WriteLine("Downloading and Configuring Scripts...");
        Console.WriteLine();
        Thread.Sleep(3000);

        var baseUrl = "https://raw.githubusercontent.com/NeoCircuit-Studios/NeoCircuit-Linux-Tools/main/Builds/";

        RunCommand($"sudo wget {baseUrl}WineInstall-x64.guust");
        RunCommand("sudo chmod +x WineInstall-x64.guust");
        Console.WriteLine();
        Thread.Sleep(2000);
        Console.WriteLine("WineInstall script has been downloaded and made executable.");
        if (File.Exists("WineInstall-x64.guust"))
        {
            RunCommand("sudo ./WineInstall-x64.guust"); // start the WineInstall script
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red; // set to color red :)
            Console.WriteLine();
            Console.WriteLine("ERROR: An Error occurred while trying to start a WineInstallscript! ErrorCode: 'CANT FIND FILE 'WineInstall.guust'.'");
            Console.ResetColor(); // Reset to default color afterward
            Thread.Sleep(3000);
            goto retry2; // Loop back to the menu
        }
    }



    static void InstallSSH()
    {
    retry3:
        Console.WriteLine();
        Console.WriteLine("Downloading and Configuring Scripts...");
        Console.WriteLine();
        Thread.Sleep(3000);

        var baseUrl = "https://raw.githubusercontent.com/NeoCircuit-Studios/NeoCircuit-Linux-Tools/main/Builds/";

        RunCommand($"sudo wget {baseUrl}SSHinstall-x64.guust");
        RunCommand("sudo chmod +x SSHinstall-x64.guust");
        Console.WriteLine();
        Thread.Sleep(2000);
        Console.WriteLine("SSHinstall script has been downloaded and made executable.");
        if (File.Exists("SSHinstall-x64.guust"))
        {
            RunCommand("sudo ./SSHinstall-x64.guust"); // start the SSHinstall script
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red; // set to color red :)
            Console.WriteLine();
            Console.WriteLine("ERROR: An Error occurred while trying to start a SSHinstallscript! ErrorCode: 'CANT FIND FILE 'SSHinstall.guust'.'");
            Console.ResetColor(); // Reset to default color afterward
            Thread.Sleep(3000);
            goto retry3; // Loop back to the menu
        }
    }
    static void Farming_Simulator()
    {
    retry4:
        Console.WriteLine();
        Console.WriteLine("Downloading and Configuring Scripts...");
        Console.WriteLine();
        Thread.Sleep(3000);

        var baseUrl = "https://raw.githubusercontent.com/NeoCircuit-Studios/NeoCircuit-Linux-Tools/main/Builds/";

        RunCommand($"sudo wget {baseUrl}FSInstall-x64.guust");
        RunCommand("sudo chmod +x FSInstall-x64.guust");
        Console.WriteLine();
        Thread.Sleep(2000);
        Console.WriteLine("FSInstall script has been downloaded and made executable.");
        if (File.Exists("FSInstall-x64.guust"))
        {
            RunCommand("sudo ./FSInstall-x64.guust"); // start the WineInstall script
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red; // set to color red :)
            Console.WriteLine();
            Console.WriteLine("ERROR: An Error occurred while trying to start a FSInstallscript! ErrorCode: 'CANT FIND FILE 'FSInstall.guust'.'");
            Console.ResetColor(); // Reset to default color afterward
            Thread.Sleep(3000);
            goto retry4; // Loop back to the menu
        }
    }

    static void InstallOllama()
    {

    }

    static void UpdateLinux()
    {
        Console.WriteLine("Updating Ubuntu System...");
        Console.WriteLine();
        RunCommand("sudo apt update && sudo apt upgrade -y");
        Console.WriteLine();
        Console.WriteLine("Ubuntu System has been updated successfully.");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
        Console.WriteLine();
        Main(); // Return to the main menu
    }

    static void DeleteEverything()
    {
        Console.WriteLine("Deleting everything that the scripts made...");
        Directory.SetCurrentDirectory(".."); // to go back a dir 
        RunCommand("sudo ./NeoCircuit-Linux-Tools-x64 -delete"); // run the main script to delete everything
        Environment.Exit(0); // Stop the app

    }

}