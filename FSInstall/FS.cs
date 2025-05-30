// NeoCircuit-Studios (NS) 2025
using Microsoft.VisualBasic.FileIO;
using System;
using System.Diagnostics;
using System.IO;

//todo

//Consider Console.Clear() before displaying the main menu for better UX.

//Avoid goto

class FS
{
    static void Main()
    {
        Console.WriteLine("Choose An Option:");
        Console.WriteLine();


        Console.WriteLine("1: Install Farming Simulator From Cd-ROM (Wine required)");
        Console.WriteLine("2: Configure Farming Simulator Dedicated Server (Wine required)");
        Console.WriteLine();
        Console.WriteLine("3: Back to Main Menu");
        Console.WriteLine();

        Thread.Sleep(500);

        Console.Write("Enter your choice [1-3]: ");
        var input = Console.ReadLine();

        switch (input)
        {
            case "1":
                InstallFSFromCDROM();
                break;
            case "2":
                Fsdsinstall();
                break;
            case "3":
                Backtocore();
                break;
            default:
                Console.WriteLine("Invalid option.");
                Main();
                break;
        }
    }

    static void Backtocore()
    {
        RunCommand("sudo ./Core-x64.guust"); // start the core script
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

    static bool CheckWineInstalled()
    {
        var psi = new ProcessStartInfo
        {
            FileName = "/bin/bash",
            Arguments = "-c \"wine --version\"",
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false
        };

        try
        {
            using (var process = Process.Start(psi))
            {
                process.WaitForExit();
                string output = process.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();

                if (!string.IsNullOrWhiteSpace(output) && output.ToLower().Contains("wine"))
                {
                    Console.WriteLine("Wine is installed: " + output.Trim());
                    return true;
                }
                else
                {
                    Console.WriteLine("Wine not found. Error: " + error.Trim());
                    return false;
                }
            }
        }
        catch
        {
            Console.WriteLine("Wine check failed. Likely not installed.");
            return false;
        }
    }



    static void InstallFSFromCDROM()
    {
        if (CheckWineInstalled())
        {
            Console.WriteLine("Wine is installed on this system.");
            goto okey;
        }
        else
        {
            Console.WriteLine("Wine is not installed.");
            Console.WriteLine("Please install Wine first.");
            Console.WriteLine("Do you want to install wine now? (y/n)");

            string input = Console.ReadLine().Trim().ToLower();

            if (input == "y" || input == "yes" || input == "ja")
            {
                goto retry2; // Loop back to the script download and configuration
            }
            else
            {
                Console.WriteLine("do you want to continue anyway?(y/n)");
                input = Console.ReadLine().Trim().ToLower();

                if (input == "y" || input == "yes")
                {
                    goto okey; // Skip Wine installation and proceed to the next step
                }
                else
                {
                    Console.WriteLine("Exiting the script. Please install Wine and try again.");
                    Main(); // Return to the main menu

                }
            }

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
            Console.WriteLine("WineInstall.guust has been downloaded and made executable.");
            if (File.Exists("WineInstall-x64.guust"))
            {
                RunCommand("sudo ./WineInstall-x64.guust"); // start the WineInstall script
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red; // set to color red :)
                Console.WriteLine();
                Console.WriteLine("ERROR: An Error occurred while trying to start a WineInstallscript! ErrorCode: 'CANT FIND FILE 'WineInstall.guust'.'");
                Thread.Sleep(2000);
                Console.WriteLine("Press any key to return to the MainMenu...");
                Console.ReadKey();
                Console.ResetColor(); // Reset to default color afterward
                Main(); // Return to the main menu
            }


        }

    okey:
        Console.WriteLine("Installing Farming Simulator from CD-ROM...");
        Console.WriteLine();
        Thread.Sleep(1000);

        Console.WriteLine("Warning!: The Location of the Cd-ROM might be different than made and in this script so it might not work");
        Console.WriteLine();
        Thread.Sleep(3000);

        RunCommand("sudo mount /dev/sr0 /mnt");
        RunCommand("cd /mnt");

        Console.WriteLine("trying to run 'setup.exe' with Wine..");
        Console.WriteLine();
        Thread.Sleep(3000);

        RunCommand("wine setup.exe");

        Console.WriteLine("if it was successful, you should see the install Window...");
        Thread.Sleep(4000);
        Main(); // Return to the main menu
    }

    static void Fsdsinstall()
    {
        Console.WriteLine("Configure Farming Simulator Dedicated Server...");
        Console.WriteLine();
        Thread.Sleep(3000);

        if (CheckWineInstalled())
        {
            Console.WriteLine("Wine is installed on this system.");
            goto givethepath; //to resume
        }
        else
        {
            Console.WriteLine("Wine is not installed.");
            Console.WriteLine("Please install Wine first.");
            Console.WriteLine("Do you want to install wine now? (y/n)");

            string input = Console.ReadLine().Trim().ToLower();

            if (input == "y" || input == "yes" || input == "ja")
            {
                goto retry3; // Loop back to the script download and configuration
            }
            else
            {
                Console.WriteLine("do you want to continue anyway?(y/n)");
                input = Console.ReadLine().Trim().ToLower();

                if (input == "y" || input == "yes")
                {
                    goto givethepath; // Skip Wine installation and proceed to the next step
                }
                else
                {
                    Console.WriteLine("Exiting the script. Please install Wine and try again.");
                    Main(); // Return to the main menu
                }
            }
        }

    retry3:
        Console.WriteLine();
        Console.WriteLine("Downloading and Configuring Scripts...");
        Console.WriteLine();
        Thread.Sleep(3000);

        var baseUrl = "https://raw.githubusercontent.com/NeoCircuit-Studios/NeoCircuit-Linux-Tools/main/Builds/";

        RunCommand($"sudo wget {baseUrl}WineInstall-x64.guust");
        RunCommand("sudo chmod +x WineInstall-x64.guust");
        Console.WriteLine();
        Thread.Sleep(2000);
        Console.WriteLine("WineInstall.guust has been downloaded and made executable.");
        if (File.Exists("WineInstall-x64.guust"))
        {
            RunCommand("sudo ./WineInstall-x64.guust"); // start the WineInstall script
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red; // set to color red :)
            Console.WriteLine();
            Console.WriteLine("ERROR: An Error occurred while trying to start a WineInstallscript! ErrorCode: 'CANT FIND FILE 'WineInstall.guust'.'");
            Thread.Sleep(2000);
            Console.WriteLine("Press any key to return to the MainMenu...");
            Console.ReadKey();
            Console.ResetColor(); // Reset to default color afterward
            Main(); // Return to the main menu
        }


    givethepath:
        Console.WriteLine("Can you please provide the root path to your Farming Simulator Dedicated Server installation?");
        Console.WriteLine("e.g. /home/user/FarmingSimulatorDedicatedServer");
        Console.WriteLine();
        Console.Write("Enter the path: ");
        string fsdsPath = Console.ReadLine().Trim();
        if (Directory.Exists(fsdsPath))
        {
            Console.WriteLine($"Farming Simulator Dedicated Server found at: {fsdsPath}");
            Console.WriteLine("Configuring the server...");
            Console.WriteLine();
            Thread.Sleep(2000);

            Console.WriteLine("Downloading the dedicated server configuration file...");
            Console.WriteLine();
            var baseUrl2 = "https://raw.githubusercontent.com/NeoCircuit-Studios/NeoCircuit-Linux-Tools/main/Builds/";

            RunCommand($"sudo wget {baseUrl2}dedicatedServer.xml");
            RunCommand($"sudo wget {baseUrl2}NS-Run-Dedicated-Server.sh");
            RunCommand("sudo chmod +x NS-Run-Dedicated-Server.sh");
            Console.WriteLine("Configuration file downloaded successfully.");
            Console.WriteLine();

            Console.WriteLine("Copying the configuration file to the server directory...");

            Console.WriteLine();

            RunCommand($"sudo cp dedicatedServer.xml \"{fsdsPath}\"");
            RunCommand($"sudo cp NS-Run-Dedicated-Server.sh \"{fsdsPath}\"");
            Console.WriteLine("Configuration file copied successfully.");
            Console.WriteLine();

        yesorno:
            Console.WriteLine("Do you want to start the Farming Simulator Dedicated Server now? (y/n)");

            string input = Console.ReadLine().Trim().ToLower();

            if (input == "y" || input == "yes" || input == "ja")
            {
                Console.WriteLine("Starting the Farming Simulator Dedicated Server...");
                RunCommand($"sudo \"{fsdsPath}/NS-Run-Dedicated-Server.sh\"");
                Main();

            }
            else if (input == "n" || input == "no" || input == "nee")
            {
                Console.WriteLine("You can start the server later by running the NS-Run-Dedicated-Server.sh script in the Farming Simulator directory.");
                Console.WriteLine("Press any key to return to the main menu...");
                Console.ReadKey();
                Main(); // Return to the main menu
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter 'y' or 'n'.");
                goto yesorno; //lol
            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("ERROR: The specified path does not exist. Please check the path and try again.");
            Console.ResetColor();
            goto givethepath; // Loop back to ask for the path again
        }
    }
}