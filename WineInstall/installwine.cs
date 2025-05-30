// NeoCircuit-Studios (NS) 2025
using System;
using System.Diagnostics;
using System.Threading;

//todo

//Consider Console.Clear() before displaying the main menu for better UX.

//Avoid goto

class InstallWine
{

    static bool WineDependenciesInstalled = false;
    static void Main()
    {


        Console.WriteLine("Choose An Option:");
        Console.WriteLine();

        Console.WriteLine("1: Install Wine");
        Console.WriteLine("2: Uninstall Wine");
        Console.WriteLine("3: Run Wine Test App");
        Console.WriteLine();
        Console.WriteLine("4: Back to Main Menu");

        Console.WriteLine();

        Console.Write("Enter your choice [1-4]: ");

        var input2 = Console.ReadLine();

        switch (input2)
        {
            case "1":
                runInstallWine();
                break;
            case "2":
                UninstallWine();
                break;
            case "3":
                RunWineTestApp();
                break;
            case "4":
                Main();
                return; // Back to main menu
            default:
                Console.WriteLine("Invalid option.");
                backtocore(); // Loop back to core menu
                break;
        }
    }


    static void RunWineTestApp()
    {
        if (WineDependenciesInstalled)
        {
            goto okey;
        }
        else
        {
            installWineDependencies();
            goto okey;
        }


    okey:
        Console.WriteLine("Downloading Wine Test App...");
        Console.WriteLine();
        var baseUrl = "https://raw.githubusercontent.com/NeoCircuit-Studios/NeoCircuit-Linux-Tools/main/Builds/";
        RunCommand($"sudo wget {baseUrl}Hello_Wine.7z");
        Console.WriteLine();
        Console.WriteLine("Extracting Wine Test App...");
        Console.WriteLine();
        RunCommand("sudo 7z x Hello_Wine.7z -o./Hello_Wine"); // Extract the app to a folder named Hello_Wine
        Thread.Sleep(2000);
        Console.WriteLine();


        Console.WriteLine("Running Wine Test App...");
        Thread.Sleep(2000);
        Console.WriteLine();
        RunCommand("sudo wine ./Hello_Wine/Hello_Wine.exe"); // run derctly the app with wine in the folder Hello_Wine.
        Console.WriteLine();
        Thread.Sleep(2000);
        Console.WriteLine("Wine Test App has been run successfully.");
        Console.WriteLine();
        Thread.Sleep(2000);
        Console.WriteLine("this should print 'Hello Wine!, from NeoCircuit-Studios!!'.");
        Console.WriteLine("if not then Wine is not installed Correctly!!");
        Console.WriteLine();
        Thread.Sleep(2000);
        Console.WriteLine("Press any key to return to the Wine menu...");
        Console.ReadKey();
        backtocore(); // Return to the Wine menu
    }

    static void UninstallWine()
    {
        Console.WriteLine("Uninstalling Wine...");
        Console.WriteLine();
        Thread.Sleep(2000);

        // Step 1: Remove Wine packages
        Console.WriteLine("Removing Wine packages...");
        Console.WriteLine();
        Thread.Sleep(2000);
        RunCommand("sudo apt remove --purge wine wine64 wine32 wine32-preloader wine32-tools wine64-preloader wine64-tools -y");
        Console.WriteLine();
        Thread.Sleep(2000);

        // Step 2: Auto-remove unnecessary dependencies
        Console.WriteLine("Removing unnecessary dependencies...");
        Console.WriteLine();
        Thread.Sleep(2000);
        RunCommand("sudo apt autoremove --purge -y");
        RunCommand("sudo apt clean");
        Console.WriteLine();
        Thread.Sleep(2000);

        // Step 3: Remove Wine config and data
        Console.WriteLine("Removing Wine configuration and data directories...");
        Console.WriteLine();
        Thread.Sleep(2000);
        RunCommand("rm -rf ~/.wine");
        RunCommand("rm -rf ~/.local/share/applications/wine*");
        RunCommand("rm -rf ~/.config/wine");
        Console.WriteLine();
        Thread.Sleep(2000);

        // Step 4: Remove Wine repository (optional)
        Console.WriteLine("Removing Wine repository...");
        Console.WriteLine();
        Thread.Sleep(2000);
        RunCommand("sudo rm /etc/apt/sources.list.d/winehq-*.list");
        RunCommand("sudo apt update");
        Console.WriteLine();
        Thread.Sleep(2000);

        Console.WriteLine("Wine has been fully uninstalled.");
        Console.WriteLine("Press any key to return to the Wine menu...");
        Console.ReadKey();
        backtocore(); // Return to the Wine menu

    }


    static void PrintWineDisclaimer()
    {
        Console.WriteLine("Wine is NOT owned by NeoCircuit-Studios (NS)\n");
        Console.WriteLine("Wine Copyright:");
        Console.WriteLine("Copyright (c) 1993-2025 the Wine project authors");
        Console.WriteLine("Wine is free software; you can redistribute it and/or modify it under");
        Console.WriteLine("the terms of the GNU LGPL v2.1 or later.");
        Console.WriteLine("No warranty is provided.\n");
    }

    static void installWineDependencies()
    {
        Console.WriteLine("Installing Wine dependencies...\n");

        RunCommand("sudo dpkg --add-architecture i386");
        RunCommand("sudo apt update -y");
        RunCommand("sudo apt install gcc-multilib g++-multilib libc6:i386 libc6-dev-i386 -y");
        RunCommand("sudo apt install wine64 wine32 libwine libwine:i386 fonts-wine -y");
        RunCommand("sudo apt install libx11-dev:i386 libfreetype6-dev:i386 flex -y");
        RunCommand("sudo apt install bison wget git -y");
        RunCommand("sudo apt install build-essential flex bison gcc-multilib g++-multilib libncurses5-dev libssl-dev libfreetype6-dev libx11-dev libxext-dev libxcb1-dev libxrandr-dev libxinerama-dev libxcomposite-dev libxfixes-dev libxml2-dev libxslt1-dev libfontconfig1-dev -y");
        RunCommand("sudo apt install -y p7zip-full");
        RunCommand("sudo apt autoremove -y");

        WineDependenciesInstalled = true; // Use the class-level variable instead of redeclaring it locally

        Console.WriteLine("All Wine dependencies installed!\n");
    }

    static void backtocore()
    {
        RunCommand("sudo ./Core-x64.guust"); // start the core script
    }

    static void runInstallWine()
    {
        PrintWineDisclaimer();
        Console.WriteLine();
        Thread.Sleep(2000);
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
        Console.WriteLine();

        if (WineDependenciesInstalled)
        {
            goto okey2;
        }
        else
        {
            installWineDependencies();
            goto okey2;
        }

    okey2:
        Console.WriteLine("Installing Wine...\n");
        Thread.Sleep(2000);


        RunCommand("sudo apt update -y");
        RunCommand("sudo apt install software-properties-common wget -y");
        Console.WriteLine();
        RunCommand("sudo wget -nc https://dl.winehq.org/wine-builds/winehq.key");
        Console.WriteLine();
        RunCommand("sudo apt-key add winehq.key");
        Console.WriteLine();
        RunCommand("sudo add-apt-repository 'deb https://dl.winehq.org/wine-builds/ubuntu/ focal main'");
        Console.WriteLine();
        RunCommand("sudo apt update -y");
        Console.WriteLine();
        Thread.Sleep(2000);

        Console.WriteLine("Installing Wine packages...");
        Console.WriteLine();
        Thread.Sleep(2000);

        RunCommand("sudo apt install --install-recommends winehq-stable -y");
        Console.WriteLine();
        RunCommand("sudo apt install wine32");
        Console.WriteLine();
        RunCommand("sudo apt install --install-recommends winehq-stable winetricks -y");
        Console.WriteLine();
        RunCommand("winetricks corefonts vcrun2015 vcrun2019 dotnet48 dxvk -y");
        Console.WriteLine();
        Thread.Sleep(2000);
        Console.WriteLine("Wine installation is complete!");
        Thread.Sleep(2000);
        Console.WriteLine();
        Console.WriteLine();

        Console.WriteLine("Verify Installation..");
        Thread.Sleep(3000);
        Console.WriteLine();
        RunCommand("wine --version");
        Console.WriteLine();
        Console.WriteLine("Looks like Wine Is Installed successfully!");
        Thread.Sleep(3000);
        Console.WriteLine();

        Console.WriteLine("Running First-Time Wine Configuration..");
        Thread.Sleep(2000);
        Console.WriteLine();

        RunCommand("winecfg");

        Console.WriteLine();
        Console.WriteLine("Testing Wine..");
        RunWineTestAppFORInstall(); // wine test app.


        Thread.Sleep(1000);
        Console.WriteLine("Wine has been installed successfully!");
        Console.WriteLine();
        Thread.Sleep(2000);
        Console.WriteLine("Press any key to return to the Wine menu...");
        Console.ReadKey();
        Main(); // Return to the Wine menu


    }

    static void RunWineTestAppFORInstall()
    {
        if (WineDependenciesInstalled)
        {
            goto okey;
        }
        else
        {
            installWineDependencies();
            goto okey;
        }


    okey:
        Console.WriteLine("Downloading Wine Test App...");
        Console.WriteLine();
        var baseUrl = "https://raw.githubusercontent.com/NeoCircuit-Studios/NeoCircuit-Linux-Tools/main/Builds/";
        RunCommand($"sudo wget {baseUrl}Hello_Wine.7z");
        Console.WriteLine();
        Console.WriteLine("Extracting Wine Test App...");
        Console.WriteLine();
        RunCommand("sudo 7z x Hello_Wine.7z -o./Hello_Wine"); // Extract the app to a folder named Hello_Wine
        Thread.Sleep(2000);
        Console.WriteLine();


        Console.WriteLine("Running Wine Test App...");
        Thread.Sleep(2000);
        Console.WriteLine();
        RunCommand("sudo wine ./Hello_Wine/Hello_Wine.exe"); // run derctly the app with wine in the folder Hello_Wine.
        Console.WriteLine();
        Thread.Sleep(2000);
        Console.WriteLine("Wine Test App has been run successfully.");
        Console.WriteLine();
        Thread.Sleep(2000);
        Console.WriteLine("this should print 'Hello Wine!, from NeoCircuit-Studios!!'.");
        Console.WriteLine("if not then Wine is not installed Correctly!!");
        Console.WriteLine();
        Thread.Sleep(2000);
        Console.WriteLine("Press any key to return...");
        Console.ReadKey();
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



}
