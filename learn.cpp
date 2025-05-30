using System;
using System.Diagnostics;
using System.Threading;

class Program
{
    static void Main()
    {
        ShowBanner();

        Thread.Sleep(3000);
        PrintWineDisclaimer();

        Thread.Sleep(5000);
        Console.WriteLine("V0.1.3\n");

        Console.WriteLine("Initializing Install Script..\n");
        Thread.Sleep(1000);

        RunCommand("sudo", "wget https://github.com/NeoCircuit-Studios/fs-winehelper/blob/main/NS-Update.sh");

        RunCommand("sudo", "rm Update.sh");
        RunCommand("sudo", "rm NS-Update.sh");

        Console.WriteLine("\nUninstalling Any Wine Installs\n");
        Thread.Sleep(2000);
        RunCommand("sudo", "dpkg -r wine");

        Console.WriteLine("\nInstalling Wine and Dependencies...\n");
        Thread.Sleep(2000);
        RunCommand("sudo", "apt install --install-recommends winehq-stable -y");
        RunCommand("sudo", "apt install wine32 -y");
        RunCommand("sudo", "apt install --install-recommends winehq-stable winetricks -y");
        RunCommand("winetricks", "corefonts vcrun2015 vcrun2019 dotnet48 dxvk -y");

        Console.WriteLine("\nVerifying Wine Installation...\n");
        Thread.Sleep(2000);
        RunCommand("wine", "--version");

        Console.WriteLine("\nFirst-Time Wine Configuration...\n");
        Thread.Sleep(2000);
        RunCommand("winecfg", "");

        Console.WriteLine("\nTesting Wine Setup...\n");
        RunCommand("sudo", "wget https://github.com/NeoCircuit-Studios/fs-winehelper/blob/main/NeoCircuit-Studios/Hello_Wine.7z");
        RunCommand("7z", "x Hello_Wine.7z");
        RunCommand("sudo", "rm Hello_Wine.7z");
        RunCommand("wine", "Hello_Wine/Hello_Wine.exe");

        ConfigureFarmingSimServer();
    }

    static void RunCommand(string cmd, string args)
    {
        Process.Start(new ProcessStartInfo
        {
            FileName = cmd,
            Arguments = args,
            UseShellExecute = false,
            RedirectStandardOutput = true,
            RedirectStandardError = true
        })?.WaitForExit();
    }

    static void ShowBanner()
    {
        Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
        Console.WriteLine("      NeoCircuit-Studios (NS)");
        Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\n");
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

    static void ConfigureFarmingSimServer()
    {
        Console.WriteLine("Configuring Farming Simulator 25 Server...");
        Thread.Sleep(2000);
        RunCommand("sudo", "rm -f dedicatedServer.xml");
        RunCommand("sudo", "wget https://github.com/NeoCircuit-Studios/fs-winehelper/blob/main/dedicatedServer.xml");
        Console.WriteLine("Done.");
    }
}
