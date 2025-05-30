// NeoCircuit-Studios (NS) 2025
/////

// made by AI:
🧠 BASICS
✅ Variables
csharp

int age = 25;
string name = "Neo";
bool isReady = true;

✅ Constants
csharp

const double Pi = 3.14159;

✅ Arrays & Lists
csharp

int[] numbers = { 1, 2, 3 };
List<string> items = new List<string> { "apple", "banana" };


🔀 CONTROL FLOW


✅ If / Else
csharp


if (age >= 18)
{
    Console.WriteLine("Adult");
}
else
{
    Console.WriteLine("Minor");
}


✅ Switch
csharp

switch (choice)
{
    case 1:
        Console.WriteLine("One");
        break;
    case 2:
        Console.WriteLine("Two");
        break;
    default:
        Console.WriteLine("Other");
        break;
}

✅ Ternary Operator
csharp

string result = (age >= 18) ? "Adult" : "Minor";


🔁 LOOPS


✅ For Loop
csharp

for (int i = 0; i < 5; i++)
{
    Console.WriteLine(i);
}

✅ Foreach
csharp

foreach (string item in items)
{
    Console.WriteLine(item);
}

✅ While
csharp

int i = 0;
while (i < 3)
{
    Console.WriteLine(i);
    i++;
}


📂 FILES & FOLDERS


✅ Check if File/Folder Exists
csharp

if (File.Exists("log.txt")) { /* file exists */ }
if (Directory.Exists("NeoCircuit-Studios")) { /* dir exists */ }


✅ Read/Write Files
csharp

File.WriteAllText("test.txt", "Hello!");
string content = File.ReadAllText("test.txt");


🔧 METHODS


✅ Simple Method
csharp

void Greet(string name)
{
    Console.WriteLine($"Hello, {name}");
}


🔄 THREADING


✅ Sleep / Wait
csharp

Thread.Sleep(3000); // 3 seconds


✅ Async Delay
csharp

await Task.Delay(3000); // async version




🖥️ CONSOLE



✅ Read/Write
csharp

Console.WriteLine("Enter your name:");
string name = Console.ReadLine();


✅ Clear/Beep

Console.Clear();
Console.Beep();


🧪 LOGIC & BOOLEAN
csharp

bool hasPermission = true;
if (hasPermission && age >= 18)
{
    Console.WriteLine("Access granted");
}


🗂️ DIRECTORY OPERATIONS
csharp

Directory.CreateDirectory("Logs");
Directory.SetCurrentDirectory("NeoCircuit-Studios");
Directory.SetCurrentDirectory(".."); // go up


⚙️ RUNNING COMMANDS (CLI)
csharp

Process.Start("bash", "-c \"ls -la\"");


🔐 TRY / CATCH
csharp

try
{
    File.Delete("nonexistent.txt");
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}



GOTO sample:

bool keepRunning = true;
while (keepRunning)
{
    // your logic here
    if (someCondition)
        keepRunning = false; // will stop the loop
}


or 

while (true)
{
    Console.WriteLine("Choose an option:");
    Console.WriteLine("1. Wine");
    Console.WriteLine("2. SSH");
    Console.WriteLine("3. Exit");
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
            Console.WriteLine("Goodbye!");
            Environment.Exit(0);
            break;
        default:
            Console.WriteLine("Invalid option. Try again.");
            continue; // loop again
    }

    Console.WriteLine("\nPress Enter to return to menu...");
    Console.ReadLine();
}



have colors:

Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine("An Error occurred while trying to start a Corescript");
Console.ResetColor(); // Reset to default color afterward


yes or no:

Console.WriteLine("Do you want to install wine now? (y/n)");
            Console.WriteLine("Do you want to start the Farming Simulator Dedicated Server now? (y/n)");

            string input = Console.ReadLine().Trim().ToLower();

            if (input == "y" || input == "yes" || input == "ja")
            {

            }
            else if (input == "n" || input == "no" || input == "nee")
            {
                Console.WriteLine("You can start the server later by running the NS-Run-Dedicated-Server.sh script in the server directory.");
                Console.WriteLine("Press any key to return to the main menu...");
                Console.ReadKey();
                Main(); // Return to the main menu
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter 'y' or 'n'.");
            }