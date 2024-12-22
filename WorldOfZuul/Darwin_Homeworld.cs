using System;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using MapAndCenter;
using NAudio.Wave;

// Method that prints the welcome message for Darwin_Homeworld - Luigi
public class Darwin_Homeworld
{
    // Method to show an enhanced initializing ASCII animation
    public static void ShowAnimation()
    {
        string[] frames = new string[]
        {
            "....Initializing....",
            "...Initializing...",
            "..Initializing..",
            ".Initializing.",
            "Initializing",
            ".Initializing.",
            "..Initializing..",
            "...Initializing...",
            "....Initializing....",
        };

        int[] delays = new int[] { 350, 300, 250, 200, 150, 200, 250, 300, 350 };
        
        for (int i = 0; i < frames.Length; i++)
        {
            // Move cursor up to avoid flicker
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            
            // Clear the line to ensure smooth animation
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, Console.CursorTop);

            // Set color based on the stage of animation
            if (i < frames.Length / 2)
                Console.ForegroundColor = ConsoleColor.Cyan; // Initial color for first half
            else
                Console.ForegroundColor = ConsoleColor.DarkCyan; // Color change for second half

            // Display the current frame
            Console.WriteLine(frames[i]);
            Console.ResetColor();
            Thread.Sleep(delays[i]); // Dynamic delay for each frame
        }

        // Leave an empty line after the animation
        Console.WriteLine();
    }

    public static void ShowGlitch()
    {
        // Set console encoding to UTF-8 to support special characters
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        string[] glitchFrames = new string[]
        {
            "@#%*&!~", "Ω≈ç√∫˜", "¥†ƒ∂", "¶∆∆∞¢", "£¢∞§¶•", "≠≈°",
            "$#@!¿", "¿?@#$", "∑π∂√", "Ω≈ç∂˚¬∆", "@£¢§∞¢•ª"
        };

        Random random = new();
        int animationDuration = 4000;       // Duration of the animation in milliseconds (4 seconds)
        int frameTime = 100;                // Time each frame appears on screen in milliseconds

        DateTime endTime = DateTime.Now.AddMilliseconds(animationDuration);         // Calculate end time
        Console.ForegroundColor = ConsoleColor.DarkGreen;                           // Set animation color
        while (DateTime.Now < endTime)
        {
            string glitch = glitchFrames[random.Next(glitchFrames.Length)];
            int left = random.Next(Console.WindowWidth - glitch.Length);
            int top = random.Next(Console.WindowHeight);

            Console.SetCursorPosition(left, top);
            Console.Write(glitch);
            
            Thread.Sleep(frameTime);
        }

        Console.Clear();
        // Restoring System message
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        string message = "Restoring System...";
        foreach (char c in message)
        {
            Console.Write(c);
            Thread.Sleep(150); // Adjust the delay as needed
        }
        Console.ResetColor();
        Console.WriteLine();
    }

    private void PrintSmallTre()
    {
        
    string[] SmallTree = {
        "     11                               ",
        "      111                             ",
        "       11111                          ",
        "        1111111                       ",
        "         11111111                     ",
        "          11111111                    ",
        "           11111111                   ",
        "             1111111         111111111",
        "              111111   111111111111111",
        "                11    11111111111111  ",
        "                 111  11111111111     ",
        "                       111111         ",
        "                    11 111            ",
        "                    1                 ",
        "                     1                ",
        "     111111111      1                 ",
        "  11111            11                 ",
        "11             111111                 "
    };

    foreach (var line in SmallTree)
        {
            for (int i = 0; i < line.Length; i++)
            {
                char currentChar = line[i];

                if (currentChar == '1')
                {
                    Console.ForegroundColor = ConsoleColor.Green;  // Leaves
                }
                else
                {
                    Console.ResetColor();  // Default for other characters
                }

                Console.Write(currentChar);
            }
            Console.ResetColor();
            Console.WriteLine();
        }
    }
    
    // Introduction messages
    public void Enter()
    {
        // introduction to the game
        EraTitle eraTitle = new();
        eraTitle.Print("Darwin's Homeworld");
        
        string[] intro1 = {"The world as you know it is on the brink of collapse.",
        "Once-vibrant cities lie abandoned, swallowed by relentless sandstorms and rising seas, while the last survivors cling to life amidst dwindling resources.",
        "This is the outcome of centuries of neglect, a world brought to its knees by humanity's mistakes."};
        Map.CenterText(intro1);

        // Wait for user input
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("\n\nPRESS ANY KEY");
        Console.ResetColor();
        Console.WriteLine(" to continue...");
        Console.ReadKey(); // Wait for a key press
        Console.Clear();
        
        eraTitle.Print("Darwin's Homeworld");
        string[] intro2 = {"But hope is not yet lost.",
        "You are the chosen one: a last, unexpected chance to change the course of history.",
        "Although probably you lack the knowledge and experience to rewrite the world's fate, your journey will teach you what humanity lost along the way.",
        "Together with a mate you'll be sent back to the pivotal moments that shaped this future, forced to learn, adapt, and make choices that could undo the devastation."};
        Map.CenterText(intro2);

        // Wait for user input
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("\n\nPRESS ANY KEY");
        Console.ResetColor();
        Console.WriteLine(" to continue...");
        Console.ReadKey(); // Wait for a key press
        Console.Clear();
        
        eraTitle.Print("Darwin's Homeworld");
        string[] intro3 = {"Each step you take brings new understanding, but the weight of your mission grows heavier.",
        "Will you find the wisdom and courage needed to correct humanity's errors and create a future worth saving?"};
        Map.CenterText(intro3);
        
        // Wait for user input
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("\n\nPRESS ANY KEY");
        Console.ResetColor();
        Console.WriteLine(" to continue...");
        Console.ReadKey(); // Wait for a key press
        Console.Clear();

        eraTitle.Print("Darwin's Homeworld");
        string[] intro4 = {"Every choice you make in Darwin's Quest is like planting a seed of wisdom.",
        "By the end, these seeds will either grow into a lush, vibrant tree, a symbol of knowledge and growth,",
        "or wither into a dry, lifeless one, reflecting missed opportunities and lessons left unlearned."};
        Map.CenterText(intro4);
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();

        Console.ForegroundColor = ConsoleColor.Green;

        string[] smallTree = {
        "     11                               ",
        "      111                             ",
        "       11111                          ",
        "        1111111                       ",
        "         11111111                     ",
        "          11111111                    ",
        "           11111111                   ",
        "             1111111         111111111",
        "              111111   111111111111111",
        "                11    11111111111111  ",
        "                 111  11111111111     ",
        "                       111111         ",
        "                    11 111            ",
        "                    1                 ",
        "                     1                ",
        "     111111111      1                 ",
        "  11111            11                 ",
        "11             111111                 "};

        Map.CenterText(smallTree);
        Console.ResetColor();

        // Wait for user input
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("\n\nPRESS ANY KEY");
        Console.ResetColor();
        Console.WriteLine(" to continue...");
        Console.ReadKey(); // Wait for a key press
        Console.Clear();

        // Nova AI assistant introduction
        using (var audioFile = new AudioFileReader("Music/Glitch_sound.mp3"))
        using (var sound = new WaveOutEvent())
        {
            sound.Init(audioFile);
            sound.Play();

            // Play glitch animations
            ShowGlitch();
            ShowAnimation();

            // Wait for user input
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("\n\nPRESS ENTER");
            Console.ResetColor();
            Console.WriteLine(" to continue");
            Console.ReadLine();
            sound.Stop();
        }
        
        Console.Clear();
        Console.WriteLine();
        CharactersManager.NPC_Color("");
        Console.WriteLine(" Apologies for the interference. It seems my system experienced a temporary glitch.");
        Console.WriteLine("These visual disturbances are rare... but not unexpected given the times we are in.");
        Console.WriteLine();
        bool continueRunning = true;
        while (continueRunning)
        {
            Console.Write("Press '");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("a");
            Console.ResetColor();
            Console.Write("' to ask who they are or '");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("q");
            Console.ResetColor();
            Console.Write("' to continue");
            Console.WriteLine();

            // Capture user input without displaying it
            char input = Console.ReadKey(true).KeyChar;
            switch (input)
            {
                case 'a':
                case 'A':
                    Console.Clear();
                    Console.WriteLine();
                    CharactersManager.NPC_Color("nova");
                    Console.WriteLine(" I am Nova, your dedicated AI assistant, here to help you navigate critical historical moments and learn from humanity's past.");
                    Console.WriteLine("My purpose is to provide essential information, guidance, and strategic support as you face challenges.");
                    Console.WriteLine("I will be by your side throughout this journey, analyzing data and offering insights.");
                    Console.WriteLine("Together, perhaps, we can restore the future.");
                    Console.ResetColor();
                    continueRunning = false;
                    break;  
                case 'q':
                case 'Q':
                    continueRunning = false;
                    break;                  
                default:
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("Aren't you curious to know them?");
                    Console.WriteLine();
                    break;
            }
        }
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("\n\nPRESS ANY KEY");
        Console.ResetColor();
        Console.WriteLine(" to continue...");
        Console.ReadKey(); // Wait for a key press
        Console.Clear();
        Console.WriteLine();
        CharactersManager.NPC_Color("nova");
        Console.WriteLine(" Alright! Now that you know who I am (at least I hope so), I think it's time to tell you how the game works and how to navigate this adventure!");
        Console.ResetColor();
        // Wait for user input
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("\n\nPRESS ANY KEY");
        Console.ResetColor();
        Console.WriteLine(" to continue...");
        Console.ReadKey(); // Wait for a key press
        Console.Clear();
        Console.WriteLine();
        CharactersManager.NPC_Color("nova");
        Console.WriteLine(" The game is made up of various rooms, each with its own unique challenges for you to solve.");
        Console.WriteLine("You will need to navigate through them all, learning something new with each one.");
        Console.WriteLine("At the end of every room, you will receive a score that will ultimately determine the success or failure of your renewed present");
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("\n\nPRESS ANY KEY");
        Console.ResetColor();
        Console.WriteLine(" to continue...");
        Console.ReadKey(); // Wait for a key press
        Console.Clear();
        // Commands variables
        string command1 = "";
        string command2 = "";
        string command3 = "";
        string command4 = "";
        
    static void DrawTable(string command1, string command2, string command3, string command4)
    {
        Console.WriteLine("╔═══════════════╦═══════════════════════════════════════════════════════════════════════════════════════════════╗");
        Console.WriteLine("║ Command       ║ Description                                                                                   ║");
        Console.WriteLine("╠═══════════════╬═══════════════════════════════════════════════════════════════════════════════════════════════╣");

        // Displays each selected command, if present
        PrintCommandRow("teleport", command1);
        PrintCommandRow("look", command2);
        PrintCommandRow("map", command3);
        PrintCommandRow("investigate", command4);

        Console.WriteLine("╚═══════════════╩═══════════════════════════════════════════════════════════════════════════════════════════════╝");
        Console.WriteLine();
        CharactersManager.NPC_Color("nova");
        Console.WriteLine(" Select the category you prefer to find the right command:");
        Console.WriteLine();
        Console.Write("'");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("1");
        Console.ResetColor();
        Console.WriteLine("' = Go through the rooms");
        Console.Write("'");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("2");
        Console.ResetColor();
        Console.WriteLine("' = Checking out the room");
        Console.Write("'");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("3");
        Console.ResetColor();
        Console.WriteLine("' = Where am I?");
        Console.Write("'");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("4");
        Console.ResetColor();
        Console.WriteLine("' = Gaining Insight");
        Console.WriteLine("\n");
        Console.Write("👀 ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("Look out");
        Console.ResetColor();
        Console.Write(" for the ");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("highlighted words");
        Console.ResetColor();
        Console.WriteLine("—they might be game commands you'll need to type.");

        Console.WriteLine();
        Console.Write("'");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("c");
        Console.ResetColor(); // Reset to default color
        Console.WriteLine("' = Press to continue...");
    }
    
    // Print a table row with colored text
    static void PrintCommandRow(string keyword, string command)
    {
        if (!string.IsNullOrEmpty(command))
        {
            // Print the cell for the command with the text colored in cyan
            Console.Write("║ ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"{keyword,-12} ");
            Console.ResetColor();
            Console.Write(" ║ ");
            // Print the cell for the description in green
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(command.PadRight(76));
            Console.ResetColor();
            Console.WriteLine(" ║");
        }
        else
        {
            // Blank line if the command has not yet been selected
            Console.WriteLine("║               ║                                                                                               ║");
        }
    }
        
        bool condition = true;
        DrawTable(command1, command2, command3, command4);
        while (condition)
        {
            char input = Console.ReadKey(true).KeyChar;
            Console.Clear();
            
            // Update the selected command
            switch (input)
            {
                case '1':
                    command1 = "To move through the eras, just type 'teleport' and magic will do the rest!                   ";
                    break;
                case '2':
                    command2 = "Sometimes, a place has secrets worth a closer look. Type 'look' to inspect your surroundings.";
                    break;
                case '3':
                    command3 = "Feeling a bit disoriented? Just type 'map', and voilà: the area map appears!                 ";
                    break;
                case '4':
                    command4 = "Type 'investigate' to gain era knowledge and information.                                    ";
                    break;
                case 'c':
                case 'C':
                    condition = false;
                    continue;
                default:
                    CharactersManager.NPC_Color("nova");
                    Console.WriteLine();
                    Console.WriteLine("--------------------------");
                    Console.WriteLine("| This is not a command! |");
                    Console.WriteLine("--------------------------");
                    Console.WriteLine();
                    Console.ResetColor();
                    break;
            }

            // Print the table with the updated commands
            DrawTable(command1, command2, command3, command4);
        }

        Console.Clear();
        Console.WriteLine();
        CharactersManager.NPC_Color("nova");
        Console.WriteLine(" Now you know everything you need to start your adventure. Are you ready to travel back in time?");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("Type '");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("teleport");
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("' to enter the first era!");
        Console.ResetColor();
        Console.WriteLine();
    }
}