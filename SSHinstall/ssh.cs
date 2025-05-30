// NeoCircuit-Studios (NS) 2025
using System;
using System.Diagnostics;
using System.Net.Sockets;
using System.Net;
using System.Threading;
//todo:

//Security Suggestions for Public SSH:
//Offer the user to create a new user for SSH access.
//Optionally set up SSH key-based authentication.
//Suggest disabling root login via /etc/ssh/sshd_config.

//Consider Console.Clear() before displaying the main menu for better UX.

//Missing Dependency Install Method
//installSSHDependencies() is declared but empty. If not needed, remove it or use it to install ufw, net-tools, etc.

//Avoid goto



class SSH
{
    static void Main()
    {
        Console.WriteLine("Choose An Option:");
        Console.WriteLine();
        Console.WriteLine("1. install Local SSH Server");
        Console.WriteLine("2. Install SSH Client");
        Console.WriteLine();

        Console.WriteLine("3. Install Public SSH Server (Outside the local network)");

        Console.WriteLine();
        Console.WriteLine("4: uninstall SSH Server");
        Console.WriteLine("5. uninstall SSH Client");
        Console.WriteLine();
        Console.WriteLine("6. Back to Main Menu");

        Console.Write("Enter your choice [1-6]: ");

        var input2 = Console.ReadLine();

        switch (input2)
        {
            case "1":
                InstallSSHServer();
                break;

            case "2":
                InstallSSHClient();
                break;

            case "3":
                InstallPublicSSHServer();
                break;
            case "4":
                UninstallSSHServer();
                return; // Back to main menu

            case "5":

                UninstallSSHClient();
                return; // Back to main menu

            case "6":
                Console.WriteLine("Returning to Main Menu...");
                Thread.Sleep(2000);
                backtocore(); // Loop back to core menu
                return; // Exit the SSH menu
            default:
                Console.WriteLine("Invalid option.");
                Main(); // Loop back to ssh menu
                break;
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

    static void backtocore()
    {
        RunCommand("sudo ./Core-x64.guust"); // start the core script
    }

    static void installSSHDependencies()
    {
    }

    static void InstallSSHServer()
    {
        Console.WriteLine("Installing Local OpenSSH Server...");

        // Update package list
        RunCommand("sudo apt update");
        RunCommand("sudo apt upgrade -y");
        Console.WriteLine();
        Thread.Sleep(2000);

        // Install OpenSSH Server
        RunCommand("sudo apt install openssh-server -y");
        Console.WriteLine();
        Thread.Sleep(2000);

        Console.Write("Do you want to enable SSH on boot? (y/n): ");
        string input = Console.ReadLine().Trim().ToLower();

        if (input == "y" || input == "yes")
        {
            Console.WriteLine("Enabling SSH to start on boot...");
            RunCommand("sudo systemctl enable ssh"); // to Enable SSH to start at boot
            Console.WriteLine();
            Thread.Sleep(2000);
            goto sshcon;
        }
        else
        {
            Console.WriteLine("Skipping enabling SSH on boot.");
            Console.WriteLine();
            Thread.Sleep(2000);
            goto sshcon;
        }


    sshcon:
        // Start SSH service
        Console.WriteLine("Starting OpenSSH Server...");
        Console.WriteLine();
        Thread.Sleep(2000);
        RunCommand("sudo systemctl start ssh");
        Console.WriteLine();
        Thread.Sleep(2000);

        // Check status
        RunCommand("sudo systemctl status ssh");
        Console.WriteLine();
        Thread.Sleep(2000);

        Console.WriteLine("OpenSSH Server installation complete.");
        Console.WriteLine();
        Thread.Sleep(2000);

        string localIP = "Not found";

        foreach (var host in Dns.GetHostEntry(Dns.GetHostName()).AddressList)
        {
            if (host.AddressFamily == AddressFamily.InterNetwork)
            {
                localIP = host.ToString();
                break;
            }
        }

        Console.WriteLine("Local SSH Server is running on the following IP address and port:");
        Console.WriteLine($"Local IP Address: {localIP}");
        Console.WriteLine("Default SSH Port: 22");
        Console.WriteLine();
        Thread.Sleep(2000);
        Console.WriteLine("Press any key to return to the SSH menu...");
        Console.ReadKey();
        Main(); // Return to SSH menu

    }


    static void InstallSSHClient()
    {
        Console.WriteLine("Installing OpenSSH Client...");
        Console.WriteLine();
        Thread.Sleep(2000);

        // Update package list
        RunCommand("sudo apt update");
        RunCommand("sudo apt upgrade -y");

        // Install OpenSSH Client

        RunCommand("sudo apt install -y openssh-client");

        Console.WriteLine("OpenSSH Client installation complete.");
        Console.WriteLine();
        Thread.Sleep(2000);

        Console.WriteLine();
        Thread.Sleep(2000);
        Console.WriteLine("Press any key to return to the SSH menu...");
        Console.ReadKey();
        Main(); // Return to SSH menu
    }

    static void UninstallSSHServer()
    {
        Console.WriteLine("Uninstalling OpenSSH Server...");
        Console.WriteLine();
        Thread.Sleep(2000);

        // Remove the OpenSSH server package
        RunCommand("sudo apt remove --purge openssh-server -y");
        Console.WriteLine();
        Thread.Sleep(2000);

        // Remove unused dependencies
        RunCommand("sudo apt autoremove -y");
        Console.WriteLine();
        Thread.Sleep(2000);

        // Clean up apt cache
        RunCommand("sudo apt clean");
        Console.WriteLine();
        Thread.Sleep(2000);

        Console.WriteLine("OpenSSH Server has been uninstalled.");
        Console.WriteLine();
        Thread.Sleep(2000);
        Console.WriteLine("Press any key to return to the SSH menu...");
        Console.ReadKey();
        Main(); // Return to SSH menu
    }

    static void UninstallSSHClient()
    {
        Console.WriteLine("Uninstalling OpenSSH Client...");
        Console.WriteLine();
        Thread.Sleep(2000);

        // Uninstall the SSH client
        RunCommand("sudo apt remove --purge openssh-client -y");
        Console.WriteLine();
        Thread.Sleep(2000);

        // Optional: Clean up dependencies and cache
        RunCommand("sudo apt autoremove --purge -y");
        RunCommand("sudo apt clean");
        Console.WriteLine();
        Thread.Sleep(2000);

        Console.WriteLine("OpenSSH Client has been uninstalled.");
        Console.WriteLine();
        Thread.Sleep(2000);
        Console.WriteLine("Press any key to return to the SSH menu...");
        Console.ReadKey();
        Main(); // Return to SSH menu
    }

    static void InstallPublicSSHServer()
    {
        Thread.Sleep(2000);
        Console.WriteLine("WARNING: Hosting a SSH server outside your local network can be dangerous, proceed with caution!.");
        Console.ReadKey();
        Console.WriteLine("Do you want to continue? (y/n)");
        Thread.Sleep(1000);
        string input = Console.ReadLine().Trim().ToLower();

        if (input == "y" || input == "yes")
        {
            goto yes;
        }
        else
        {
            Main(); //back to SSH menu
            Console.WriteLine();
            Thread.Sleep(2000);
        }
    yes:
        Console.WriteLine("Installing Public SSH Server...");
        Console.WriteLine();
        Thread.Sleep(2000);

        // Install SSH server
        RunCommand("sudo apt update");
        RunCommand("sudo apt install openssh-server -y");

        // Enable and start SSH service
        RunCommand("sudo systemctl enable ssh");
        RunCommand("sudo systemctl start ssh");

        // Check status
        RunCommand("sudo systemctl status ssh");

        // Allow SSH through firewall (if UFW is used)
        RunCommand("sudo ufw allow ssh");  // opens port 22
        RunCommand("sudo ufw reload");

        Console.WriteLine("SSH server installed and started successfully.");
        Console.WriteLine();
        Thread.Sleep(2000);
        Console.WriteLine("To access your SSH server from outside your local network, you need to set up port forwarding on your router!");
        Console.WriteLine();
        Thread.Sleep(1000);
        Console.WriteLine("You can find your public IP address by searching 'What is my IP' in a web browser.");
        Console.WriteLine();
        Thread.Sleep(1000);
        Console.WriteLine("Make sure to secure your SSH server with strong passwords or SSH keys.");
        Console.WriteLine();
        Thread.Sleep(2000);
        Console.WriteLine("Press any key to return to the Wine menu...");
        Console.ReadKey();
        Main(); // Return to SSH menu
    }
}