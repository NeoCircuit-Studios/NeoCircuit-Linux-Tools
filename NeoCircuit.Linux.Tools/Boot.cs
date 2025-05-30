// NeoCircuit-Studios (NS) 2025
using System;
using System.Diagnostics;
using System.Threading;

//todo

//Consider Console.Clear() before displaying the main menu for better UX.

//Avoid goto


class Boot
{
    static void Main(string[] args)
    {
        bool delete = false;
        //bool force = false; // an other arg

        foreach (string arg in args)
        {
            if (arg == "-delete") delete = true;
            //if (arg == "-force") force = true;
        }

        if (delete)
        {
            DeleteCommand(); // for funtion
            return;
        }


    start: // for the "goto" command
        ShowBanner();
        Thread.Sleep(3000);
        Console.WriteLine("Starting NeoCircuit-Studios (NS) Bootloader...\n");

        Console.WriteLine("Checking for updates...");
        Console.WriteLine();
        Thread.Sleep(2000);
        Console.WriteLine("Updating Linux System...\n");
        Thread.Sleep(2000);
        Console.WriteLine();
        UpdateLinux(); // Update the Linux System
        MakeDir(); // Remove and Create the NeoCircuit-Studios directory
        Console.WriteLine("Downloading Core Script...");
        Directory.SetCurrentDirectory("NeoCircuit-Studios"); // MAKE SURE THAT THE DIR EXISTs!!! // Change to the NeoCircuit-Studios directory // otherwise it will shit himself
        DownloadCore();
        ConfigCoreScript(); //to make it work

        if (File.Exists("Core-x64.guust"))
        {
            RunCommand("sudo ./Core-x64.guust"); // start the core script
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red; // set to color red :)
            Console.WriteLine();
            Console.WriteLine("ERROR: An Error occurred while trying to start a Corescript! ErrorCode: 'CANT FIND FILE 'Core.guust'.'");
            Console.ResetColor(); // Reset to default color afterward
            goto start;
        }

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


    static void ShowBanner()
    {
        Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
        Console.WriteLine("      NeoCircuit-Studios (NS)");
        Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\n");

        // Console.Beep(659, 200); // E5  // windows only // cool for error
    }
    static void MakeDir()
    {
        RunCommand("rm -r NeoCircuit-Studios");
        RunCommand("mkdir NeoCircuit-Studios");
        //Directory.SetCurrentDirectory("NeoCircuit-Studios"); //no cd // no need to change the directory here.
    }
    static void UpdateLinux()
    {
        // Console.WriteLine("Updating System...\n");
        Thread.Sleep(1000);
        RunCommand("sudo apt update -y");
        Thread.Sleep(1000);
        Console.WriteLine();
        Console.WriteLine("50%");
        RunCommand("sudo apt upgrade -y");
        Thread.Sleep(1000);
        Console.WriteLine("100%\n");
    }

    static void DownloadCore()
    {
        var baseUrl = "https://raw.githubusercontent.com/NeoCircuit-Studios/NeoCircuit-Linux-Tools/main/Builds/";

        RunCommand($"sudo wget {baseUrl}Core-x64.guust");
    }
    static void ConfigCoreScript()
    {
        RunCommand("sudo chmod +x Core-x64.guust");
    }

    static void DeleteCommand()
    {

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("Are you sure you want to delete everything? (y/n): ");
        Console.ResetColor();

        var input = Console.ReadLine();
        if (input?.ToLower() != "y")
        {
            Console.WriteLine("Aborted.");
            Environment.Exit(0); // Stop the entire app
        }


        Console.WriteLine("Deleting NeoCircuit-Studios directory...");
        Console.WriteLine();

        RunCommand("sudo rm -rf NeoCircuit-Studios");
        Console.ForegroundColor = ConsoleColor.Green; // green is user friendly
        Console.WriteLine("Deletion complete!, everything is deleted except this script.");
        Console.WriteLine();
        Console.ResetColor(); //not anymore
        Console.WriteLine("this script will quit now...");
        Console.WriteLine();
        Thread.Sleep(3000); //just waiy lol

        Environment.Exit(0); // Stop the app after deletion
    }


}