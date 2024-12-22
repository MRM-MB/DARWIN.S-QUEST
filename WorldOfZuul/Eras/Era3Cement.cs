using System.IO.Compression;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using MapAndCenter;
using NAudio.Wave; // -> dotnet add package NAudio

public class Era3Cement
{
    // Point system implemented
    PointSystem pointSystem = new PointSystem();
    
    // Construction Left Margin -> Very similar to the CandyCane design from Era3SDU
    // ==============================
    //        Margin Separator
    // ==============================
    public class Tape
    {
        // The word "WARNING" split into characters
        private static readonly string[] WarningText = { "W", "A", "R", "N", "I", "N", "G" };
        private static readonly int WarningHeight = WarningText.Length + 2; // 1 arrow above and below

        // Arrows above and below "WARNING"
        public static void DisplayBar(int lineNumber, int Height)
        {
            int padding = (Height - WarningHeight) / 2;

            if (lineNumber == padding)
            {
                Arrow(); // Arrange arrow
            }
            else if (lineNumber > padding && lineNumber <= padding + WarningText.Length)
            {
                // Vertically "WARNING"
                WarningTxt(lineNumber - padding - 1, lineNumber);
            }
            else if (lineNumber == padding + WarningText.Length + 1)
            {
                Arrow(); // Arrange arrow
            }
            else
            {
                // Nno arrows in top/bottom
                BlankLine(lineNumber);
            }
        }

        // Display a single upward red arrow
        private static void Arrow()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(" ^ ");
            Console.ResetColor();
            Console.Write("║  ");
        }

        // Display a single letter from the word "WARNING" vertically in yellow
        private static void WarningTxt(int index, int lineNumber)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($" {WarningText[index]} ");  // Single letter from "WARNING"
            Console.ResetColor();
            ColorBar(lineNumber);  // Alternating color for "║"
        }

        // Alternate "║" character between red and white
        private static void ColorBar(int lineNumber)
        {
            if (lineNumber % 2 == 0)
            {
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            Console.Write("║  ");
            Console.ResetColor();
        }

        private static void BlankLine(int lineNumber)
        {
            Console.Write("    ");  // Blank space for alignment
            ColorBar(lineNumber);
        }
    }

    // ==============================
    //      Question Validation
    // ==============================
    public void InvalidInput()
    {
        // Invalid input
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\nInvalid choice.");
        Console.ResetColor();

        Console.Write("Please select ");

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("1");
        Console.ResetColor();

        Console.Write(" or ");

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("2");
        Console.ResetColor();

        Console.WriteLine(".");
        Console.WriteLine();
    }

    // ==============================
    //          ASCII ART
    // ==============================
    private void PrintDoorArt()
    {
        string[] ArtLines = {
            "═════ SDU! ══════════════════════════════════════",
            "    .::::::.      _EXIT_        7       L        ",
            "   ::`    `::   || _  _ ||                   7   ",
            "   ::.    .::   |||■||■|||          *            ",
            "   `:(>()<):`   |||■||■|||   L      $            ",
            "      //\\\\      || _  _9||         /^\\    L     ",
            "      /  \\      |||■||■|||        /0!^\\         ",
            "                |||■||■|||       /^!^o^\\        ",
            "                ||______||       /0^!^!\\        ",
            "               %__________%     /o^!^0^!\\       ",
            "═══════════════|__________|══════ [MMM] ═════════"
        };

        foreach (var line in ArtLines)
        {
            for (int i = 0; i < line.Length; i++)
            {
                char currentChar = line[i];

                if (currentChar == '/' || currentChar == '\\' || currentChar == ':' || currentChar == '`' || currentChar == '.' || currentChar == 'U')
                {
                    Console.ForegroundColor = ConsoleColor.Green;  // Plants
                }
                else if (currentChar == '$' || currentChar == '^')
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen; // Plant leaves
                }
                else if (currentChar == '<' || currentChar == '>' || currentChar == ')' || currentChar == '(' || currentChar == 'L' || currentChar == 'o' || currentChar == 'E'|| currentChar == 'X' || currentChar == 'I' || currentChar == 'T' || currentChar == 'S')
                {
                    Console.ForegroundColor = ConsoleColor.Red;   // Bow and decorations
                }
                else if (currentChar == '0')
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow; // More decor
                }
                else if (currentChar == '*')
                {
                    Console.ForegroundColor = ConsoleColor.Yellow; // Star
                }
                else if (currentChar == '■' || currentChar == '!')
                {
                    Console.ForegroundColor = ConsoleColor.Cyan; // Glow blue elements
                }
                else if (currentChar == '═')
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray; // Wall room color
                }
                else if (currentChar == 'M' || currentChar == '[' || currentChar == ']')
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan; // Wall room color
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

    private void PrintFogArt()
    {
        string[] ArtLines = {
            "⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀    ",
            "⠀⠀⣤⣤⣶⣶⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⣶⣦⣤⡤⢤⣴⣶⣶⣤⠄⠀  ",
            "⠀⠠⢴⣾⣿⣿⡿⠟⠛⠛⠛⠛⠛⢛⣉⣩⣥⣤⣤⣤⣤⣤⣤⣀⣀⠀⠀⠀   ",
            "⠀⠀⠀⠀⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠉⠉⠛⠛⠛⠋⠉⠉⠀⠀⠀⠀⠀⠀⠀    ",
            "⠀⠀⠀⠀⢤⣤⣶⣶⣶⣶⣶⣶⣤⣤⣤⣴⣶⣶⣶⣦⣄⣠⣤⣤⣤⣀⣀⡀    ",
            "⠀⠀⠀⠀⠀⠀⠀⠉⠉⣉⣉⣀⣻⣿⣿⣿⣿⣿⣿⣿⡿⠿⠛⠛⠛⠛⠉⠉⠁   ",
            "⠀⠀⠀⠀⣀⣤⣀⡀⠀  \\\\⠛  *||* //⣉⣩⣤⣤⣤⣄⣀⡀     ",
            "    ⠒⠿⣿⣿⣿⡿⠗o⠗o*o*★⠛o⠛o*⠛⣿⣿⣿⣿⣿⣿⣿⣿⠶ ",
            "⠀⠀⠀⠀⠀⠉⣀⣀⣤⣿⣿⣿⣿⣿⣿⣯⣍⣁⣁⡀⡀⡀⡀⡀⠀⠀        ",
            "⠀⠀⠀⠀⠀⠀⠀⠈⠉⠉⠉⠉⠙⠛⠛⠛⠛⢛⣻⣿⣿⣿⣿⣿⣷⣦⣤⣄⡀    ",
            "⠀⠀⠀⠀⠀⠀⠀⣠⣴⣶⣿⣶⣤⣀⠀⠀⠀⠀⠉⠛⠻⠿⠿⠿⠿⠟⠛⠉⠀⠀    ",
            "⠀⠀⢀⣀⣠⣤⣤⣬⣽⣿⣿⣟⣉⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀     ",
            "⠀⠀⠀⠀⢩⣭⣿⣿⣿⡉⠉⠉⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣠⣤⣤⣤⣄⡀⠀⠀     ",
            "⠀⠀⠀⠀⠀⠀⠈⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠠⠤⢴⣶⣾⣿⣿⣿⣿⣶⠤⠄⠀     ",
            "⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠉⠀⠀⠀⠀⠀⠀       "
        };

        foreach (var line in ArtLines)
        {
            for (int i = 0; i < line.Length; i++)
            {
                char currentChar = line[i];

                if (currentChar == '⠠' || currentChar == '⣶' || currentChar == '⠤' || currentChar == '⣤' || currentChar == '⠙' || currentChar == '⣄' || currentChar == '⢴' || currentChar == '⠛' || currentChar == '⠉')
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;  // Fog
                }
                else if (currentChar == '*' || currentChar == '★' || currentChar == '\\')
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow; // Light Source
                }
                else if (currentChar == '|' || currentChar == 'o' || currentChar == '/')
                {
                    Console.ForegroundColor = ConsoleColor.Yellow; // Light
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

        Console.ResetColor();
    }

    private void PrintTrainArt()
    {
        string[] ArtLines = {
            "____________   ________________________________________^__    ",
            " ___   ___  |||  ___   ___   ___    ___ ___  |   __  ,----\\  ",
            "|■■■| |■■■| ||| |■■■| |■■■| |■■■|  |   |   | |  |  | |-----\\ ",
            "|■■■| |■■■| ||| |■■■| |■■■| |■■■|  | O | O | |  |  |        \\",
            "            |||                    |___|___| |  |══|         )",
            "____________|||______________________________|___══_________/ ",
            "-------------------------------------------------------------",
            "////////////////////////////////////////////////////////------'         "
        };

        foreach (var line in ArtLines)
        {
            for (int i = 0; i < line.Length; i++)
            {
                char currentChar = line[i];

                if (currentChar == '-')
                {
                    Console.ForegroundColor = ConsoleColor.Gray;  // Tracks
                }
                else if (currentChar == '/')
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray; // Tracks 2
                }
                else if (currentChar == '_' || currentChar == '^' || currentChar == '\\')
                {
                    Console.ForegroundColor = ConsoleColor.Red;   // Train Wagon
                }
                else if (currentChar == '■' || currentChar == ')')
                {
                    Console.ForegroundColor = ConsoleColor.Yellow; // Lights
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

    private void PrintSmallTreeArt()
    {
        string[] ArtLines = {
            "         *          ",
            "        { }         ",
            "       {   }        ",
            "      {     }       ",
            "     {       }      ",
            "-- HAPPY HOLIDAYS --",
        };

        foreach (var line in ArtLines)
        {
            for (int i = 0; i < line.Length; i++)
            {
                char currentChar = line[i];

                if (currentChar == '{' || currentChar == '}')
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;  // Leaves
                }
                else if (currentChar == '*')
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow; // Star
                }
                else if (currentChar == '|')
                {
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;   // Wood
                }
                else if (currentChar == '-' || currentChar == 'H' || currentChar == 'A' || currentChar == 'P' || currentChar == 'Y' || currentChar == 'O' || currentChar == 'L' || currentChar == 'I' || currentChar == 'D' || currentChar == 'S')
                {
                    Console.ForegroundColor = ConsoleColor.Red; // Text and decor
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

    private void PrintArrivalKArt()
    {
        string[] ArtLines = {
        "  _                     ",
        " (_),,,,,,,,,.          ",
        " |/| Kolding |          ",
        " ║/║ STATION |          ",
        " |/|\"\"\"\"\"\"\"\"\"` ",
        " ║/║                    ",
        " |/|                    ",
        };

        foreach (var line in ArtLines)
        {
            for (int i = 0; i < line.Length; i++)
            {
                char currentChar = line[i];

                if (currentChar == '(' || currentChar == ')' || currentChar == '_')
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;  // Top
                }
                else if (currentChar == '/' || currentChar == '║')
                {
                    Console.ForegroundColor = ConsoleColor.Red; // Pole Decor
                }
                else if (currentChar == 'K' || currentChar == 'o' || currentChar == 'l' || currentChar == 'd' || currentChar == 'i' || currentChar == 'n' || currentChar == 'g')
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;   // Text "Kolding"
                }
                else if (currentChar == 'S' || currentChar == 'T' || currentChar == 'A' || currentChar == 'I' || currentChar == 'O' || currentChar == 'N')
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan; // Text "Station"
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

    private void PrintArrivalFArt()
    {
        string[] ArtLines = {
        "  _                          ",
        " (_),,,,,,,,,,,,.            ",
        " |/| Fredericia |            ",
        " ║/║ STATION    |            ",
        " |/|\"\"\"\"\"\"\"\"\"\"\"\"`",
        " ║/║                         ",
        " |/|                         ",
        };

        foreach (var line in ArtLines)
        {
            for (int i = 0; i < line.Length; i++)
            {
                char currentChar = line[i];

                if (currentChar == '(' || currentChar == ')' || currentChar == '_')
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;  // Top
                }
                else if (currentChar == '/' || currentChar == '║')
                {
                    Console.ForegroundColor = ConsoleColor.Red; // Pole Decor
                }
                else if (currentChar == 'F' || currentChar == 'r' || currentChar == 'e' || currentChar == 'd' || currentChar == 'r' || currentChar == 'i' || currentChar == 'c' || currentChar == 'a')
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;   // Text "Kolding"
                }
                else if (currentChar == 'S' || currentChar == 'T' || currentChar == 'A' || currentChar == 'I' || currentChar == 'O' || currentChar == 'N')
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan; // Text "Station"
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

    private void PrintGreenCementArt()
    {
        string[] ArtLines = {
        "                     ...        ",
        "                      {-)   |\\ ",
        "                 [m,].-.-.   / ",
        "[][__][__]         \\(/\\../\\)/  ",
        "[__][__][__][__]      |  |",
        "[][__][__][__][__][] /   |",
        "[__][__][__][__][__]| /| |",
        "[][__][__][__][__][]| || |  ~~~~",
        "[__][__][__][__][__]==,==,  \\__/"
        };

        foreach (var line in ArtLines)
        {
            for (int i = 0; i < line.Length; i++)
            {
                char currentChar = line[i];

                if (currentChar == '[' || currentChar == ']')
                {
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;  // Bricks
                }
                else if (currentChar == '_' || currentChar == '~')
                {
                    Console.ForegroundColor = ConsoleColor.Green; // Green Cement
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
    private void PrintEndingPortalArt()
    {
        string[] ArtLines = {
            "            _____              ",
            "        _^^^^^^^^^^^_          ",
            "     .^^^ *       * ^^^.       ",
            "   .^^  *           *  ^^.     ",
            "  .^^  *             *  ^^.    ",
            " .^^  *               *  ^^.   ",
            " ::  *                 *  ::   ",
            " ::  *                 *  ::   ",
            " ::  *                 *  ::   ",
            " .^^  *               *  ^^.   ",
            "  .^^  *             *  ^^.    ",
            "   .^^  *           *  ^^.     ",
            "     .^^  *        *  ^^.      ",
            "         ^^........^^          ",
            "             ‾‾‾‾              "
        };

        Random random = new Random();  // For random color selection

        foreach (var line in ArtLines)
        {
            foreach (char currentChar in line)
            {
                if (currentChar == '‾' || currentChar == '^' || currentChar == '_')
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                }
                else if (currentChar == '.' || currentChar == ':')
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                }
                else if (currentChar == '*')
                {
                    // Random color for '*'
                    Console.ForegroundColor = random.Next(2) == 0 ? ConsoleColor.Blue : ConsoleColor.Cyan;
                }
                else
                {
                    Console.ResetColor();
                }

                Console.Write(currentChar);
            }
            Console.WriteLine();
        }

        using (var audioFile = new AudioFileReader("Music/portal.mp3"))
        using (var sound = new WaveOutEvent())
        {
            sound.Init(audioFile);
            sound.Play();

            // Wait for user input
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("\n\nPRESS ENTER");
            Console.ResetColor();
            Console.WriteLine(" to continue...");
            Console.ReadLine();
            sound.Stop();
        }

        Console.ResetColor();
    }

    private void PrintCongratulationsArt()
    {
        string [] ArtLines = {
        "                                   .''.                                                 .''.               ",
        "       .''.      .        *''*    :_\\/_:     .            .''.        .      *''*      :_\\/_:     .      ",
        "      :_\\/_:   _\\(/_  .:.*_\\/_*   : /\\ :  .'.:.'.        :_\\/_:   _\\(/_  .:.*_\\/_*     : /\\ :.'.:.'.",
        "  .''.: /\\ :   ./)\\   ':'* /\\ * :  '..'.  -=:o:=-    .''.: /\\ :   ./)\\   ':'* /\\ * :    '..'.-=:o:=- ",
        " :_\\/_:'.:::.    ' *''*    * '.\\'/.' _\\(/_'.':'.'   :_\\/_:'.:::.    ' *''*    * '.\\'/.' _\\(/_'.':'.' ",
        " : /\\ : :::::     *_\\/_*     -= o =-  /)\\    '  *   : /\\ : :::::     *_\\/_*     -= o =-  /)\\    '  * ",
        "  '..'  ':::'     * /\\ *     .'/.\'.   '              '..'  ':::'     * /\\ *     .'/.\'.   '            ",
        "      *            *..*                                  *            *..*                              ",
    };

        foreach (var line in ArtLines)
        {
            for (int i = 0; i < line.Length; i++)
            {
                char currentChar = line[i];

                if (currentChar == '.' || currentChar == '=')
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                else if (currentChar == ':')
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }
                else if (currentChar == '/')
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else if (currentChar == '\\')
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else if (currentChar == '*')
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                }
                else if (currentChar == '_')
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
                else
                {
                    Console.ResetColor();
                }

                Console.Write(currentChar);
            }
            Console.ResetColor();
            Console.WriteLine();
        }
    }
    // ==============================
    //     ERA ARRIVAL GREETING
    // ==============================
    public void Enter()
    {
        EraTitle eraTitle = new EraTitle();
        eraTitle.Print("Welcome to Era 3 Cement!");

        Console.WriteLine();
        Console.WriteLine();
        CharactersManager.NPC_Color("nova");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(" Yo..u h$ve t?l?p!---t?d to Era?Ce*%ent (Era 3)!");
        Console.ResetColor();

        // Nova ERROR beginning
        Transition transition = new Transition();
        transition.EmojiTransition("💥", "⚠️");
        Console.WriteLine();

        Console.WriteLine();
        int Height = 15;  // Total height of the warning margin

        // Warning margin
        Tape.DisplayBar(1, Height);
        Console.WriteLine();
        Tape.DisplayBar(2, Height);
        Console.WriteLine();
        Tape.DisplayBar(3, Height);
        Console.WriteLine();
        Tape.DisplayBar(4, Height);
        Console.WriteLine("You attempted to teleport, but something went wrong and the process didn’t go as planned.");
        Tape.DisplayBar(5, Height);
        Console.WriteLine();
        Tape.DisplayBar(6, Height);
        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.Green;
        Console.Write(" Nova ");
        Console.ResetColor();
        Console.WriteLine(" is acting strangely, and it's clear there's a problem with her behavior.");
        Tape.DisplayBar(7, Height);
        Console.WriteLine();
        Tape.DisplayBar(8, Height);
        Console.WriteLine("There's a student-only Christmas 🎄☃️ event happening at the university, and sadly you're not allowed to stay.");
        Tape.DisplayBar(9, Height);
        Console.WriteLine();
        Tape.DisplayBar(10, Height);
        Console.WriteLine("With no other options, you find a door and are forced to leave the building.");
        Tape.DisplayBar(11, Height);
        Console.WriteLine();
        Tape.DisplayBar(12, Height);
        Console.WriteLine();
        Tape.DisplayBar(13, Height);
        Console.WriteLine();

        Console.WriteLine();
        Console.WriteLine();
        PrintDoorArt();
        Console.WriteLine();

        string? userInput = null;
        bool AccessEnding = false;

        // Loop until the user either Opens the door or sees the map
        while (!AccessEnding)
        {   using (var audioFile = new AudioFileReader("Music/christmas.mp3"))
            using (var sound = new WaveOutEvent())
            {
                sound.Init(audioFile);
                sound.Play();
                // Display the prompt with "Open" and "map" in cyan
                Console.Write("Type ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Open");
                Console.ResetColor();
                Console.Write(" to proceed or ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("map");
                Console.ResetColor();
                Console.WriteLine(" to see where you are:");

                userInput = Console.ReadLine()?.Trim().ToLower();
                sound.Stop();
            }

            if (userInput == "open")
            {
                // Proceed to display the art and dialog
                AccessEnding = true;  // Exit loop after Entering

                // Calling the Emoji transition from Transition class
                transition.EmojiTransition("💥", "⚠️");
            }
            else if (userInput == "map")
            {
                // Display the map for Era 3 Cement
                Map.DisplayMap("Era3Cement");

                // After showing the map, the user must type 'Open' to proceed
                Console.Write("Type ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Open");
                Console.ResetColor();
                Console.WriteLine(" to go outside the building:");

                while (!AccessEnding)  // Loop until they type 'Open' after seeing the map
                {
                    userInput = Console.ReadLine()?.Trim().ToLower();
                    if (userInput == "open")
                    {
                        AccessEnding = true;  // Exit loop after Entering

                        // Calling the Emoji transition from Transition class
                        transition.EmojiTransition("💥", "⚠️");  // Use custom emojis here
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nInvalid choice.");
                        Console.ResetColor();
                        Console.Write("Please type ");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("Open");
                        Console.ResetColor();
                        Console.WriteLine(" to proceed.");
                    }
                }
            }
            else
            {
                // Invalid input handling
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nInvalid choice.");
                Console.ResetColor();
            }
        }

        Console.Clear();

        EraTitle eraTitleAgain = new EraTitle();
        eraTitleAgain.Print("Welcome to Era 3 Cement!");
        Console.WriteLine();
        CharactersManager.NPC_Color("nova");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(" Yo_u arrrre outside* SDU (Sønebo?')!");
        Console.ResetColor();

        // Nova malfunction
        transition.EmojiTransition("💥", "🤖");
        Console.WriteLine();
        Console.WriteLine();
        CharactersManager.NPC_Color("nova");
        Console.WriteLine(" Darwi?, &y sysstem is%malfunc--malfunctioning*@@#.:(");
        Console.WriteLine("I am una--ble to telepot @s ba*k home* Som%thi%!*#? affec%--*af-f-fecting* my sys#!&...");

        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("W--Warning!");
        Console.ResetColor();
        Console.Write(" H?za&#ous !ct&-acti%&ac*ivity detected nearby.");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write(" Th? trainn tracksss... 🛤️ :(");
        Console.ResetColor();
        
        Console.WriteLine();
        Console.WriteLine();
        
        PrintFogArt();
        
        Console.WriteLine();
        Tape.DisplayBar(3, Height);
        Console.WriteLine();
        Tape.DisplayBar(4, Height);
        Console.WriteLine();
        Tape.DisplayBar(5, Height);
        Console.WriteLine();
        Tape.DisplayBar(6, Height);
        Console.WriteLine("As you step outside the university, you're met with thick fog, obscuring your vision 👀.");
        Tape.DisplayBar(7, Height);
        Console.WriteLine();
        Tape.DisplayBar(8, Height);
        Console.Write("The only thing you can make out is a bright 🔦 ");
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.Write("yellow light");
        Console.ResetColor();
        Console.WriteLine(" 🔦 in the distance.");
        Tape.DisplayBar(9, Height);
        Console.WriteLine();
        Tape.DisplayBar(10, Height);
        Console.WriteLine();
        Tape.DisplayBar(11, Height);
        Console.WriteLine();
        Console.WriteLine();
        
        // Go to Train Station (Bright Light) or try to enter the university
        bool isValid = false;  // Flag to control the loop
        string? response;

        while (!isValid)
        {
            Console.WriteLine("What would you like to do?");
            Console.WriteLine();

            // Display options with cyan numbers
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("1.");
            Console.ResetColor();
            Console.WriteLine(" Ignore the light and head back to the university.");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("2.");
            Console.ResetColor();
            Console.WriteLine(" Walk towards the bright light.");

            // Get user input
            response = Console.ReadLine();

            // Validate the user's input
            if (string.IsNullOrEmpty(response) || (response != "1" && response != "2"))
            {
                // Invalid input
                InvalidInput();
                Console.WriteLine();
            }
            else
            {
                isValid = true;  // Valid input, exit loop
                transition.EmojiTransition("💥", "🤖");
                Console.WriteLine();
                switch (response)
                {
                    case "1":
                        Console.WriteLine();
                        Tape.DisplayBar(1, Height);
                        Console.WriteLine();
                        Tape.DisplayBar(2, Height);
                        Console.WriteLine();
                        Tape.DisplayBar(3, Height);
                        Console.WriteLine();
                        Tape.DisplayBar(4, Height);
                        Console.WriteLine("As you decide to turn around, hoping to find the door 🚪 you originally came through, the thick fog makes it impossible to 📍 locate.");
                        Tape.DisplayBar(5, Height);
                        Console.WriteLine();
                        Tape.DisplayBar(6, Height);
                        Console.WriteLine("You decide to return to the light ✨ you saw earlier, but now it’s not as clear as it was before.");
                        Tape.DisplayBar(7, Height);
                        Console.WriteLine();
                        Tape.DisplayBar(8, Height);
                        Console.Write("Fortunately, you stumble upon a ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        Console.Write(" faculty member from the university. ");
                        Console.ResetColor();
                        Console.WriteLine();
                        Tape.DisplayBar(9, Height);
                        Console.WriteLine();
                        Tape.DisplayBar(10, Height);
                        Console.Write("You decide to approach him:");
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.Write(" \"Excuse me, could you tell me about that bright light over there❓\"");
                        Console.WriteLine();
                        Tape.DisplayBar(11, Height);
                        Console.WriteLine();
                        Tape.DisplayBar(12, Height);
                        Console.WriteLine();
                        Tape.DisplayBar(13, Height);
                        Console.WriteLine();
                        Console.WriteLine();

                        // Professor starts talking
                        DialogueWithProfessor();

                        break;

                    case "2":
                        Console.Clear();

                        // The Conductor informs the player what is going on
                        DialogueWithConductor ();

                        // CHOOSE -> Kolding || Fredericia
                        TrainDestination();
                        break;
                }
            }
        }
    }

    // ==============================
    //       Taking the train
    // ==============================
    public void TrainStation()
    {
        int Height = 15;

        CharactersManager.NPC_Color("nova");
        Console.Write(" Darwin, I've managed to self-repair some of my malfunctions, but several features are still unavailable, including ");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("teleportation.");
        Console.ResetColor();
        Console.WriteLine("However, you're very close to the hazardous material I've detected.");

        Console.WriteLine();
        Tape.DisplayBar(1, Height);
        Console.WriteLine();
        Tape.DisplayBar(2, Height);
        Console.WriteLine();
        Tape.DisplayBar(3, Height);
        Console.WriteLine();
        Tape.DisplayBar(4, Height);
        Console.WriteLine();
        Tape.DisplayBar(5, Height);
        Console.WriteLine("At the train station, you look around, searsymbolng for any hazardous materials.");
        Tape.DisplayBar(6, Height);
        Console.WriteLine();
        Tape.DisplayBar(7, Height);
        Console.WriteLine("After some time, you find nothing out of the ordinary—only two men working 🛠️ on the tracks.");
        Tape.DisplayBar(8, Height);
        Console.WriteLine();
        Tape.DisplayBar(9, Height);
        Console.WriteLine("The announcement for the next train echoes through the station; it’s set to arrive in about 10 minutes.");
        Tape.DisplayBar(10, Height);
        Console.WriteLine();
        Tape.DisplayBar(11, Height);
        Console.WriteLine();
        Tape.DisplayBar(12, Height);
        Console.WriteLine();
        Tape.DisplayBar(13, Height);
        Console.WriteLine();
        ApproachTheWorkers();
    }
    
    public void TrainDestination()
    {
        bool isValid = false;
        string? playerChoice;

        while (!isValid)
        {
            using (var audioFile = new AudioFileReader("Music/train.mp3"))
            using (var sound = new WaveOutEvent())
            {
                sound.Init(audioFile);
                sound.Play();

                Console.WriteLine("\nWhere would you like to go?");
                Console.WriteLine();
                
                // Display options in cyan
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("1.");
                Console.ResetColor();
                Console.WriteLine(" Kolding");

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("2.");
                Console.ResetColor();
                Console.WriteLine(" Fredericia");

                // Get user input
                playerChoice = Console.ReadLine();

                // Stop the sound after user input
                sound.Stop();
            }

            // Validate input
            if (string.IsNullOrEmpty(playerChoice) || (playerChoice != "1" && playerChoice != "2"))
            {
                // Invalid input message in red
                InvalidInput();
            }
            else
            {
                isValid = true;  // Valid input, exit loop
                Transition transition = new Transition();
                transition.EmojiTransition("🚂", "📍");
                Console.WriteLine();

                switch (playerChoice)
                {
                    case "1":
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        PrintArrivalKArt();
                        Console.ResetColor();

                        // Kolding storyline
                        TrainStation();
                        break;

                    case "2":
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        PrintArrivalFArt();
                        Console.ResetColor();

                        // Fredericia storyline
                        TrainStation();
                        break;
                }
            }
        }
    }

    // ==============================
    //      Character Dialogue
    // ==============================
    public void DialogueWithProfessor()
    {
        bool isValid = false;
        string? playerResponse;
        CharactersManager.NPC_Color("prof");
        Console.WriteLine(" Yes, if you 🔄 turn around and walk straight ahead, you'll find the 🚂 train station (Sønderborg).");
        
        while (!isValid)
        {
            // Ask player to choose between two options
            Console.WriteLine();
            Console.WriteLine("What do you say?");
            Console.WriteLine();

            // Display options with cyan numbers
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("1.");
            Console.ResetColor();
            Console.WriteLine(" Thank you, 👋 have a nice day!");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("2.");
            Console.ResetColor();
            Console.WriteLine(" Thank you so much! Enjoy the Christmas party! 🎉🎄");

            // Get player response
            playerResponse = Console.ReadLine();

            // Validate input
            if (string.IsNullOrEmpty(playerResponse) || (playerResponse != "1" && playerResponse != "2"))
            {
                // Invalid input
                InvalidInput();
            }
            else
            {
                isValid = true; // Valid input, exit loop
                Transition transition = new Transition();
                transition.EmojiTransition("🎄", "🎅");
                Console.WriteLine();

                switch (playerResponse)
                {
                    case "1":
                        Console.WriteLine();
                        CharactersManager.NPC_Color("prof");
                        Console.WriteLine(" No worries, you too 😊");
                        Thread.Sleep(1000); // 1 second - Pause
                        transition.EmojiTransition("🎄", "🎅");
                        Console.Clear();

                        // The Conductor informs the player what is going on with the trains
                        DialogueWithConductor ();

                        // CHOOSE -> Kolding || Fredericia
                        TrainDestination();
                        break;

                    case "2":
                        Console.WriteLine();
                        CharactersManager.NPC_Color("prof");
                        Console.WriteLine(" Of course, and Merry Christmas 🎄🎅");
                        Console.WriteLine();
                        PrintSmallTreeArt();

                        // Play max_tree.mp3
                        using (var audioFile = new AudioFileReader("Music/max_tree.mp3"))
                        using (var sound = new WaveOutEvent())
                        {
                            sound.Init(audioFile);
                            sound.Play();

                            // Wait for the audio to finish
                            while (sound.PlaybackState == PlaybackState.Playing)
                            {
                                Thread.Sleep(1); // 1 millisecond - Pause
                            }
                        }
                        Thread.Sleep(1000); // 1 second - Pause

                        transition.EmojiTransition("🎄", "🎅");
                        Console.Clear();
                        
                        // The Conductor informs the player what is going on with the trains
                        DialogueWithConductor ();

                        // CHOOSE -> Kolding || Fredericia
                        TrainDestination();
                        break;
                }
            }
        }
    }

    public void DialogueWithConductor () 
    {
        int Height = 15;
        Console.WriteLine();
        Console.WriteLine();
        
        // Print The Train
        PrintTrainArt();

        Console.WriteLine();
        Console.WriteLine();
        Tape.DisplayBar(1, Height);
        Console.WriteLine();
        Tape.DisplayBar(2, Height);
        Console.WriteLine();
        Tape.DisplayBar(3, Height);
        Console.WriteLine();
        Tape.DisplayBar(4, Height);
        Console.WriteLine();
        Tape.DisplayBar(5, Height);
        Console.WriteLine("You head toward the bright light and soon find yourself at Sønderborg Train Station.");
        Tape.DisplayBar(6, Height);
        Console.WriteLine();
        Tape.DisplayBar(7, Height);
        Console.WriteLine("As a train pulls in, the conductor steps down onto the platform.");
        Tape.DisplayBar(8, Height);
        Console.WriteLine();
        Tape.DisplayBar(9, Height);
        Console.WriteLine("You ask him if there’s anything unusual happening with the train tracks.");
        Tape.DisplayBar(10, Height);
        Console.WriteLine();
        Tape.DisplayBar(11, Height);
        Console.WriteLine();
        Tape.DisplayBar(12, Height);
        Console.WriteLine();
        Tape.DisplayBar(13, Height);
        Console.WriteLine();
        Console.WriteLine();
        
        CharactersManager.NPC_Color("traincond");
        Console.WriteLine(" Well, if by 'unusual' you mean frequent delays and shifts, then yes, we’re having quite a few of those!");
        Console.WriteLine("There’s ongoing track 🛠️ repair work expected to last until the end of the year.");
        Console.WriteLine("Most repairs are taking place near the 📍Fredericia and 📍Kolding stations.");
        Console.WriteLine();
        Console.Write("🎯 You realize you’ll need to investigate further to resolve the issues with ");
        Console.BackgroundColor = ConsoleColor.DarkGreen;
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write(" Nova ");
        Console.ResetColor();
        Console.WriteLine(" and find a way back home 🏠");
        Console.WriteLine();
    }

    public void TableCement() // Information Table - Cement
    {
        // Title
        string title = "🌍 Consequences & Disadvantages of Using Traditional Cement 🌍";
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine(new string('═', 82));
        Console.WriteLine(title.PadLeft((82 + title.Length) / 2).PadRight(82)); // Center the title within 82 characters
        Console.WriteLine(new string('═', 82));
        Console.ResetColor();

        // Table Header
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("| {0,-30} | {1,-45} |", "ASPECT", "IMPACT");
        Console.WriteLine(new string('─', 82));
        Console.ResetColor();

        // Table Rows
        PrintRow("🌍 Carbon Emissions", 
                "Cement production accounts for ~8% of global CO₂ emissions due to high-energy clinker production.");
        PrintRow("🔥 Energy Intensity", 
                "Requires extreme heat (1450°C) fueled by fossil fuels, making it highly energy-intensive.");
        PrintRow("💧 Water & Pollution", 
                "High water usage; wastewater and dust release pollutes water bodies, impacting wildlife.");
        PrintRow("⛰️ Land Degradation", 
                "Mining for raw materials like limestone leads to deforestation and habitat loss.");
        PrintRow("🌐 Resource Depletion", 
                "Heavy reliance on finite materials like limestone and sand increases resource strain.");

        // Footer Line
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine(new string('═', 82));
        Console.ResetColor();
    }

    static void PrintRow(string aspect, string impact)
    {
        // Print the aspect column
        Console.Write("| {0,-30} |", aspect);

        // Split the impact text into lines of up to 45 characters
        int maxImpactWidth = 45;
        string[] words = impact.Split(' ');
        string currentLine = "";
        bool firstLine = true;

        foreach (var word in words)
        {
            if ((currentLine + word).Length > maxImpactWidth)
            {
                if (firstLine)
                {
                    // Print the first line with aspect and impact, padded to exact width
                    Console.WriteLine(" {0,-45} |", PadToWidth(currentLine.TrimEnd(), maxImpactWidth));
                    firstLine = false;
                }
                else
                {
                    // Print subsequent lines for impact, indented to align with impact column.
                    Console.WriteLine("| {0,-30} | {1,-45} |", "", PadToWidth(currentLine.TrimEnd(), maxImpactWidth));
                }
                currentLine = word + " ";
            }
            else
            {
                currentLine += word + " ";
            }
        }

        // Print any remaining text in the current line
        if (!string.IsNullOrEmpty(currentLine))
        {
            if (firstLine)
            {
                Console.WriteLine(" {0,-45} |", PadToWidth(currentLine.TrimEnd(), maxImpactWidth));
            }
            else
            {
                Console.WriteLine("| {0,-30} | {1,-45} |", "", PadToWidth(currentLine.TrimEnd(), maxImpactWidth));
            }
        }

        // Print the line separator after each row
        Console.WriteLine(new string('─', 82));
    }

    static string PadToWidth(string text, int width)
    {
        int extraSpaces = width - text.Length;
        return text.Length >= width ? text.Substring(0, width) : text + new string(' ', width - text.Length);
    }

    public void DialogueWithWorkers()
    {
        CharactersManager.NPC_Color("worker1");
        Console.WriteLine(" Godmorgen, we apologize for the inconvenience.");
        Console.WriteLine();
        CharactersManager.NPC_Color("worker2");
        Console.WriteLine(" We’re currently repairing the tracks, so no trains will be arriving or departing from this station at the moment.");
        Console.WriteLine();

        Thread.Sleep(2000); // 2 second - Pause
        Transition transition = new Transition();
        transition.EmojiTransition("🤖", "💡");
        Console.WriteLine();

        CharactersManager.NPC_Color("nova");
        Console.Write(" Darwin, I have identified the");
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.Write(" hazardous material: ");
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("cement.");
        Console.ResetColor();
        Console.WriteLine("It appears the workers may be using it to repair the train tracks.");
        Console.WriteLine();

        // Provide player with learning options
        bool isValid = false;
        string? playerResponse;

        while (!isValid)
        {
            Console.WriteLine();
            Console.WriteLine("What would you like to do?");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("1.");
            Console.ResetColor();
            Console.WriteLine(" Learn about the consequences of using traditional cement.");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("2.");
            Console.ResetColor();
            Console.WriteLine(" Explore a sustainable alternative to recommend.");

            // Get player response
            playerResponse = Console.ReadLine();

            // Validate input
            if (string.IsNullOrEmpty(playerResponse) || (playerResponse != "1" && playerResponse != "2"))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nInvalid choice.");
                Console.ResetColor();

                Console.Write("Please select ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("1");
                Console.ResetColor();
                Console.Write(" or ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("2");
                Console.ResetColor();
                Console.WriteLine(".");
                Console.WriteLine();
            }
            else
            {
                isValid = true; // Valid input, exit loop
                transition.EmojiTransition("🌍", "🛠️");
                Console.WriteLine();

                switch (playerResponse)
                {
                    case "1":
                        Console.WriteLine();
                        
                        // Display the table
                        TableCement();

                        // The user tries to guess "Green Cement" or Nova provides the answer with a QUIZZ
                        StartChooseGame();
                        break;

                    case "2":
                        Console.WriteLine();
                        CharactersManager.NPC_Color("nova");
                        Console.Write(" Darwin, remember in ");
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.Write("Era 2 'Corals'");
                        Console.ResetColor();
                        Console.Write(" we discussed that we could use CaCO3 to create");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(" P??,o ...m5!nio.");
                        Console.ResetColor();
                        Thread.Sleep(2000); // Delay
                        transition.EmojiTransition("⚡", "🤖");
                        Console.WriteLine();
                        Console.WriteLine();
                        CharactersManager.NPC_Color("nova");
                        Console.WriteLine(" Sorry Darwin, my system is still malfunctioning, and I can't provide you with the material name.");
                        Console.WriteLine("Learning about traditional cement's consequences might help you recall the material's name.");
                        Thread.Sleep(2000); // Delay
                        Console.WriteLine();
                        transition.EmojiTransition("🤖 ", "❌");
                        Console.WriteLine();
                        Console.WriteLine();

                        // Display the table
                        TableCement();

                        // The user tries to guess "Green Cement" or Nova provides the answer with a QUIZZ
                        StartChooseGame();
                        break;
                }
            }
        }
    }

    public void ApproachTheWorkers()
    {
        bool isValid = false;
        string? playerResponse;
        int Height = 15;
        
        while (!isValid)
        {
            using (var audioFile = new AudioFileReader("Music/station.mp3"))
            using (var sound = new WaveOutEvent())
            {
                sound.Init(audioFile);
                sound.Play();

                // Prompt the player to choose between two options
                Console.WriteLine("\nType your action:");
                Console.WriteLine();

                // Display options with cyan numbers
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("1.");
                Console.ResetColor();
                Console.WriteLine(" Approach the workers.");

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("2.");
                Console.ResetColor();
                Console.WriteLine(" Take the next train back.");

                // Get player response
                playerResponse = Console.ReadLine();

                // Stop the sound after user input
                sound.Stop();
            }

            // Validate input
            if (string.IsNullOrEmpty(playerResponse) || (playerResponse != "1" && playerResponse != "2"))
            {
                // Invalid input
                InvalidInput();
            }
            else
            {
                isValid = true; // Valid input, exit loop
                Transition transition = new Transition();
                transition.EmojiTransition("🔧", "🚂");
                Console.WriteLine();

                switch (playerResponse)
                {
                    case "1":
                        DialogueWithWorkers();
                        break;

                    case "2":
                        Console.WriteLine();
                        Console.WriteLine();
                        Tape.DisplayBar(3, Height);
                        Console.WriteLine();
                        Tape.DisplayBar(4, Height);
                        Console.WriteLine();
                        Tape.DisplayBar(5, Height);
                        Console.WriteLine();
                        Tape.DisplayBar(6, Height);
                        Console.WriteLine("You decide to head back to catch the next train, only to discover that all trains have been canceled 🛑, leaving you stranded at the station.");
                        Tape.DisplayBar(7, Height);
                        Console.WriteLine();
                        Tape.DisplayBar(8, Height);
                        Console.Write("With no other options, you approach the workers ( ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.DarkCyan;
                        Console.Write(" Asger ");
                        Console.ResetColor();
                        Console.Write(" and ");
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.DarkYellow;
                        Console.Write(" Christian ");
                        Console.ResetColor();
                        Console.WriteLine(" ) to find out what’s happening.");
                        Tape.DisplayBar(9, Height);
                        Console.WriteLine();
                        Tape.DisplayBar(10, Height);
                        Console.WriteLine();
                        Tape.DisplayBar(11, Height);
                        Console.WriteLine();
                        Console.WriteLine();

                        DialogueWithWorkers();
                        break;
                }
            }
        }
    }

    // ==============================
    //       GAMES OF THE ERA
    // ==============================
    public void StartChooseGame()
    {
        Console.WriteLine();
        Console.WriteLine("📌 Press any key to continue...");
        Console.ReadKey();
        ChooseGame();
    }

    public void ChooseGame()
    {
        Transition transition = new Transition();
        transition.EmojiTransition("🤖", "⚙️");
        Console.WriteLine();
        Console.WriteLine();
        CharactersManager.NPC_Color("nova");

        bool isValid = false;
        string? playerResponse;

        Console.WriteLine(" Alright, Darwin, now that you're aware of the disadvantages of traditional cement...");

        while (!isValid)
        {
            // Ask player to choose between two options
            Console.WriteLine();
            Console.WriteLine("\nWhat would you like to do?");
            Console.WriteLine();

            // Display options with cyan numbers
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("1.");
            Console.ResetColor();
            Console.WriteLine(" Try guessing an alternative biodegradable material.");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("2.");
            Console.ResetColor();
            Console.Write(" Help ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Write(" Nova ");
            Console.ResetColor();
            Console.WriteLine(" remember the biodegradable material.");

            // Get player response
            playerResponse = Console.ReadLine();

            // Validate input
            if (string.IsNullOrEmpty(playerResponse) || (playerResponse != "1" && playerResponse != "2"))
            {
                // Invalid input
                InvalidInput();
            }
            else
            {
                isValid = true; // Valid input, exit loop

                switch (playerResponse)
                {
                    case "1":
                        Game_1(); // In this game the player tries to guess Green Cement
                        break;

                    case "2":
                        Game_2(); // Quizz to remember Green Cement
                        break;
                }
            }
        }
    }

    // GAME 1
    public void Game_1() 
    {
        Transition transition = new Transition();
        transition.EmojiTransition("🤖", "💡");
        Console.WriteLine();
        Console.WriteLine();

        CharactersManager.NPC_Color("nova");
        Console.WriteLine(" Which biodegradable material can you recommend to the workers?");

        bool isValid = false;
        string? playerResponse;

        while (!isValid)
        {
            // Ask player to choose between two options
            Console.WriteLine();
            Console.WriteLine("\nChoose a material");
            Console.WriteLine();

            // Display options with cyan numbers
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("1.");
            Console.ResetColor();
            Console.WriteLine(" Portland Cement");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("2.");
            Console.ResetColor();
            Console.WriteLine(" Green Cement");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("3.");
            Console.ResetColor();
            Console.WriteLine(" Glass Fiber Cement");

            // Get player response
            playerResponse = Console.ReadLine();

            // Validate input
            if (string.IsNullOrEmpty(playerResponse) || (playerResponse != "1" && playerResponse != "2" && playerResponse != "3"))
            {
                // Invalid input
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nInvalid choice.");
                Console.ResetColor();

                Console.Write("Please select ");

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("1");
                Console.ResetColor();

                Console.Write(" or ");

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("2");
                Console.ResetColor();

                Console.Write(" or ");

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("3");
                Console.ResetColor();

                Console.WriteLine(".");
            }
            else
            {
                isValid = true; // Valid input, exit loop
                transition.EmojiTransition("⚡", "🤖");
                Console.WriteLine();

                switch (playerResponse)
                {
                    case "1":
                        Console.WriteLine();
                        CharactersManager.NPC_Color("nova");
                        Console.Write(" I apologize, Darwin. ");
                        Console.WriteLine("I still can’t recall the exact material, but my backup system indicates that ");
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write("Portland Cement");
                        Console.ResetColor();
                        Console.Write(" is ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("incorrect.");
                        Console.ResetColor();
                        Console.WriteLine();
                        Console.WriteLine("Help me remember the material.");
                        Console.WriteLine();
                        Console.WriteLine("🤖 Press any key to continue...");
                        Console.ReadKey();
                        Game_2();
                        break;

                    case "2": 
                        // Add points to Era 3 Cement
                        PointSystem.Instance.AddPoints(5, 16);  // 16 points for Era3Cement (5)

                        // Start Workers Response to Green Cement
                        Console.WriteLine();
                        CharactersManager.NPC_Color("nova");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(" Green cement");
                        Console.ResetColor();
                        Console.WriteLine(" has been processed, and the system is updated!");
                        Console.WriteLine();
                        Console.WriteLine("🤖 Press any key to continue...");
                        Console.ReadKey();
                        WorkersResponse();
                        break;

                    case "3":
                        Console.WriteLine();
                        CharactersManager.NPC_Color("nova");
                        Console.Write(" I apologize, Darwin. ");
                        Console.WriteLine("I still can’t recall the exact material, but my backup system indicates that ");
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write("Glass Fiber Cement");
                        Console.ResetColor();
                        Console.Write(" is ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("incorrect.");
                        Console.ResetColor();
                        Console.WriteLine();
                        Console.WriteLine("Help me remember the material.");
                        Console.WriteLine();
                        Console.WriteLine("🤖 Press any key to continue...");
                        Console.ReadKey();
                        Game_2();
                        break;
                }
            }
        }
    }

    // Game 2
    public void Game_2()
    {
        Transition transition = new Transition();
        transition.EmojiTransition("🤖", "💡");
        Console.WriteLine();

        CharactersManager.NPC_Color("nova");
        Console.WriteLine(" Thank you for your assistance :)");
        Console.WriteLine();
        Console.Write("Let’s work through these ");
        Console.BackgroundColor = ConsoleColor.DarkMagenta;
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write(" 4 questions ");
        Console.ResetColor();
        Console.WriteLine(" together, as I hope to update my system and recall the material.");

        // START QUIZZ
        bool isValid = false;
        string? playerResponse;

        while (!isValid)
        {
            // Introduction
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("📚 Cement Knowledge Quiz 📚");
            Console.WriteLine();

            // Question 1
            bool question1Correct = false;
            while (!question1Correct)
            {
                Console.WriteLine("\n1)📜 What percentage of global CO₂ emissions is attributed to cement production?");
                Console.WriteLine();

                // Display options with cyan numbers
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("1.");
                Console.ResetColor();
                Console.WriteLine(" Approximately 5%");

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("2.");
                Console.ResetColor();
                Console.WriteLine(" Approximately 8%");

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("3.");
                Console.ResetColor();
                Console.WriteLine(" Approximately 12%");

                playerResponse = Console.ReadLine();

                if (playerResponse == "2")
                {
                    transition.EmojiTransition("🤖", "💡");
                    Console.WriteLine("\n🟢 CORRECT! Moving to the next question...");
                    Console.WriteLine();
                    question1Correct = true;
                }
                else if (playerResponse == "1" || playerResponse == "3")
                {
                    transition.EmojiTransition("🤖", "🚨");
                    Console.Write("\n🔴 My backup system indicates that is incorrect. ");
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(" Try again! ");
                    Console.ResetColor();
                    Console.WriteLine();
                    Console.WriteLine();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nInvalid choice.");
                    Console.ResetColor();

                    Console.Write("Please select ");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("1");
                    Console.ResetColor();
                    Console.Write(" or ");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("2");
                    Console.ResetColor();
                    Console.Write(" or ");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("3");
                    Console.ResetColor();
                    Console.WriteLine(".");
                    Console.WriteLine();
                }
            }

            // Question 2
            bool question2Correct = false;
            while (!question2Correct)
            {
                Console.WriteLine("\n2)📜 Cement production requires temperatures around ___ degrees Celsius, making it energy-intensive.");
                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("1.");
                Console.ResetColor();
                Console.WriteLine(" 800°C");

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("2.");
                Console.ResetColor();
                Console.WriteLine(" 1200°C");

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("3.");
                Console.ResetColor();
                Console.WriteLine(" 1450°C");

                playerResponse = Console.ReadLine();

                if (playerResponse == "3")
                {
                    transition.EmojiTransition("🤖", "💡");
                    Console.WriteLine("\n🟢 CORRECT! Moving to the next question...");
                    Console.WriteLine();
                    question2Correct = true;
                }
                else if (playerResponse == "1" || playerResponse == "2")
                {
                    transition.EmojiTransition("🤖", "🚨");
                    Console.Write("\n🔴 Hmm, my system shows that is not right. ");
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(" Try again! ");
                    Console.ResetColor();
                    Console.WriteLine();
                    Console.WriteLine();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nInvalid choice.");
                    Console.ResetColor();

                    Console.Write("Please select ");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("1");
                    Console.ResetColor();
                    Console.Write(" or ");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("2");
                    Console.ResetColor();
                    Console.Write(" or ");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("3");
                    Console.ResetColor();
                    Console.WriteLine(".");
                    Console.WriteLine();
                }
            }

            // Question 3
            bool question3Correct = false;
            while (!question3Correct)
            {
                Console.WriteLine("\n3)📜 Which environmental impact is associated with high water usage in cement production?");
                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("1.");
                Console.ResetColor();
                Console.WriteLine(" Resource Depletion");

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("2.");
                Console.ResetColor();
                Console.WriteLine(" Water Pollution");

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("3.");
                Console.ResetColor();
                Console.WriteLine(" Carbon Emissions");

                playerResponse = Console.ReadLine();

                if (playerResponse == "2")
                {
                    transition.EmojiTransition("🤖", "💡");
                    Console.WriteLine("\n🟢 CORRECT! Moving to the next question...");
                    Console.WriteLine();
                    question3Correct = true;
                }
                else if (playerResponse == "1" || playerResponse == "3")
                {   transition.EmojiTransition("🤖", "🚨");
                    Console.Write("\n🔴 I’m detecting an error in that answer. ");
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(" Try again! ");
                    Console.ResetColor();
                    Console.WriteLine();
                    Console.WriteLine();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nInvalid choice.");
                    Console.ResetColor();

                    Console.Write("Please select ");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("1");
                    Console.ResetColor();
                    Console.Write(" or ");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("2");
                    Console.ResetColor();
                    Console.Write(" or ");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("3");
                    Console.ResetColor();
                    Console.WriteLine(".");
                    Console.WriteLine();
                }
            }

            // Question 4
            bool question4Correct = false;
            while (!question4Correct)
            {
                Console.WriteLine("\n4)📜 What is one consequence of mining for raw materials like limestone?");
                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("1.");
                Console.ResetColor();
                Console.WriteLine(" Air Pollution");

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("2.");
                Console.ResetColor();
                Console.WriteLine(" Deforestation and habitat loss");

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("3.");
                Console.ResetColor();
                Console.WriteLine(" Increased water availability");

                playerResponse = Console.ReadLine();

                if (playerResponse == "2")
                {
                    transition.EmojiTransition("🤖", "💡");
                    Console.Write("\n🟢 CORRECT! You completed the quiz successfully. ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    Console.Write(" Well done! ");
                    Console.ResetColor();
                    Console.WriteLine();
                    Console.WriteLine();
                    question4Correct = true;
                    isValid = true; // Mark the quiz as completed
                    
                    // Add points to Era 3 Cement
                    PointSystem.Instance.AddPoints(5, 16);  // 16 points for Era3Cement (5)

                    // Start Workers Response to Green Cement
                    WorkersResponse();
                }
                else if (playerResponse == "1" || playerResponse == "3")
                {
                    transition.EmojiTransition("🤖", "🚨");
                    Console.Write("\n🔴 Oops! That answer doesn’t seem accurate. ");
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(" Try again! ");
                    Console.ResetColor();
                    Console.WriteLine();
                    Console.WriteLine();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nInvalid choice.");
                    Console.ResetColor();

                    Console.Write("Please select ");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("1");
                    Console.ResetColor();
                    Console.Write(" or ");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("2");
                    Console.ResetColor();
                    Console.Write(" or ");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("3");
                    Console.ResetColor();
                    Console.WriteLine(".");
                    Console.WriteLine();
                }
            }
        }
    }

    // Game 3
    public void DecipherOnYourOwn() 
    {
        CharactersManager.NPC_Color("nova");
        Console.WriteLine(" That's the spirit! I'm sure you can do it.");
        Console.WriteLine();

        Console.WriteLine("📌 Press any key when you're ready with the translation...");
        Console.ReadKey();
        QuestionTranslatedByUser(); // Try to give an answer           
    }

    public void QuestionTranslatedByUser() 
    {
        Transition transition = new();
        bool isValid = false;
        string? playerResponse;
        int numAnswers = 0;

        while (!isValid)
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("🚧 Respond to the workers' question 🚧");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("📢 ");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.Write(" Ved du om nogen eksempler fra den virkelige verden, hvor grøn cement er blevet brugt ");
            Console.ResetColor();
            Console.WriteLine(" ❓");
            Console.WriteLine();

            // Possible Answers
            bool questionCorrect = false;
            while (!questionCorrect)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("1.");
                Console.ResetColor();
                Console.WriteLine(" Germany, Italy, and Sweden are currently leading this initiative.");

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("2.");
                Console.ResetColor();
                Console.WriteLine(" Changi Airport (Singapore) uses recycled concrete for their aircraft stands and roads.");

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("3.");
                Console.ResetColor();
                Console.WriteLine(" I use green cement in my day-to-day life, I love it.");

                playerResponse = Console.ReadLine();

                if (playerResponse == "2")
                {
                    transition.EmojiTransition("🎉", "🎊");
                    FinalEnding(); // Access the ending of the game 😮‍💨
                    questionCorrect = true;
                    isValid = true; // Exit the quiz loop
                }
                else if (playerResponse == "1" || playerResponse == "3")
                {
                    transition.EmojiTransition("🤖", "🚨");

                    if (numAnswers == 0)
                    {
                        Console.WriteLine();
                        Console.WriteLine("\n😯 The worker looks at you, surprised, not understanding why you said that 😯");
                    }
                    else if (numAnswers == 1)
                    {
                        Console.WriteLine();
                        Console.WriteLine("\n🤨 The worker sighs, losing patience and about to leave 🤨");
                    }

                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(" Try again! ");
                    Console.ResetColor();
                    Console.WriteLine();
                    Console.WriteLine();
                    numAnswers++;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nInvalid choice.");
                    Console.ResetColor();

                    Console.Write("Please select ");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("1");
                    Console.ResetColor();
                    Console.Write(" or ");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("2");
                    Console.ResetColor();
                    Console.Write(" or ");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("3");
                    Console.ResetColor();
                    Console.WriteLine(".");
                    Console.WriteLine();
                }
            }
        }
    }

    public void UseNovaToTranslate() 
    {
        Console.WriteLine();
        CharactersManager.NPC_Color("nova");
        Console.WriteLine(" Alright, I'll use some of my remaining energy ⚡🔋 to provide a translation.");
        Console.WriteLine("However, I can only do it once.");
        Console.WriteLine();
        Console.WriteLine("Here it goes❗❗❗");
        Console.WriteLine();
        Transition transition = new();
        Thread.Sleep(2000);
        transition.EmojiTransition("🔋", "⚡");
        Console.WriteLine();

        // Original Text
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("══════════════════════════════════════════════════════════════════════════════════════");
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("                               🔴 Original Danish Text 🔴                            ");
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("══════════════════════════════════════════════════════════════════════════════════════");
        Console.ResetColor();
        Console.WriteLine();
        Console.WriteLine("Ved du om nogen eksempler fra den virkelige verden, hvor grøn cement er blevet brugt?");
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("--------------------------------------------------------------------------------------");
        Console.ResetColor();

        Console.WriteLine();
        Console.WriteLine("✅ System ready to translate: Press any key to continue...");
        Console.ReadKey();
        transition.EmojiTransition("🔎", "🤖");
        Console.WriteLine();
        Console.WriteLine();

        // Mixed translation by NOVA
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("══════════════════════════════════════════════════════════════════════════════════════");
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("                             🟢 Partially Translated Text 🟢                         ");
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("══════════════════════════════════════════════════════════════════════════════════════");
        Console.ResetColor();
        Console.WriteLine();
        Console.Write("Ved du om ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("any ");
        Console.ResetColor();
        Console.Write("eksempler ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("from");
        Console.ResetColor();
        Console.Write(" den virkelige verden, ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("where ");
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("green ");
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("cement has ");
        Console.ResetColor();
        Console.Write("blevet ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("used?");
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("--------------------------------------------------------------------------------------");
        Console.ResetColor();

        Console.WriteLine();
        CharactersManager.NPC_Color("nova");
        Console.WriteLine(" My apologies — my system is still malfunctioning, so I couldn’t translate everything directly.");
        Console.WriteLine("However, I managed to put together a table with the words you need to translate.");
        Console.WriteLine();
        Console.BackgroundColor = ConsoleColor.DarkRed;
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write(" Be warned: ");
        Console.ResetColor();
        Console.WriteLine(" the words are scrambled, so you'll need to decipher each one❗ 🤔");
        Console.WriteLine();
        Console.WriteLine("🤖 Press any key to continue...");
        Console.ReadKey();
        Console.WriteLine();
        Console.WriteLine();


        // Translation Table //

        // Danish words
        string[] danishWords = { "Ved", "du", "om", "nogen eksempler", "fra den virkelige verden", "hvor", "grøn cement", "er blevet brugt?" };

        // English translations, scrambled
        string[] englishWordsScrambled = { "any examples", "green cement", "you", "has been used?", "Do", "where", "of", "from the real world" };

        // Danish words to color green
        string[] wordsToColorGreen = { "nogen", "fra", "grøn", "cement", "hvor", "er", "brugt?" };

        // Table Header
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.DarkCyan;
        Console.Write(" Translation Table ");
        Console.ResetColor();
        Console.WriteLine();
        Console.Write("Danish".PadRight(35));
        Console.Write("English ");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("(Scrambled)".PadRight(35));
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine(new string('-', 60));
        Console.ResetColor();

        // Scrambled English translation
        for (int i = 0; i < danishWords.Length; i++)
        {
            // Split the Danish phrase into words
            string[] words = danishWords[i].Split(' ');

            // Create a buffer to display the colored Danish phrase
            string coloredDanishPhrase = "";

            foreach (var word in words)
            {
                // Check if the word should be green
                if (Array.Exists(wordsToColorGreen, greenWord => greenWord == word))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else
                {
                    Console.ResetColor();
                }

                // Append each word to the buffer
                coloredDanishPhrase += word + " ";
                
                // Print the word to maintain color and spacing
                Console.Write(word + " ");
            }

            // Color back to white after the Danish phrase
            Console.ResetColor();

            // (Padding) - fixed width for alignment
            int paddingLength = 35 - coloredDanishPhrase.Length;
            string padding = new string(' ', Math.Max(0, paddingLength));
            Console.Write(padding);

            // English translation (aligned column)
            Console.WriteLine("{0,-30}", englishWordsScrambled[i]);
        }
        Console.ResetColor();

        // Bottom Line
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine(new string('-', 60));
        Console.ResetColor();

        // Instructions for player
        Console.WriteLine("\n🔴 Match each Danish word to its correct English meaning❗");
        Console.WriteLine();
        Console.WriteLine("\nUse the table above to try translating the sentence:\n");
        Console.Write("Ved du om ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("any ");
        Console.ResetColor();
        Console.Write("eksempler ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("from");
        Console.ResetColor();
        Console.Write(" den virkelige verden, ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("where ");
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("green ");
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("cement has ");
        Console.ResetColor();
        Console.Write("blevet ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("used?");
        Console.ResetColor();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("🤖 Press any key when you're ready with the translation...");
        Console.ReadKey();
        Console.WriteLine();
        transition.EmojiTransition("🔎", "🤖");
        Console.WriteLine();

        // Answer Question after possible translation
        QuestionTranslatedByUser();
    }

    // ============================================
    //      ENDING OF ERA3CEMENT - TRANSLATION    
    // ============================================
    public void WorkersResponse()
    {
        Transition transition = new Transition();
        transition.EmojiTransition("✅", "🤖");
        Console.WriteLine();
        CharactersManager.NPC_Color("nova");
        Console.Write(" Excellent work, Darwin! The material we needed is called ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Green Cement.");
        Console.ResetColor();
        Console.WriteLine();
        transition.EmojiTransition("🤖", "💡");
        Console.WriteLine();

        // FUN FACT about Green Cement
        CharactersManager.NPC_Color("nova");
        Console.WriteLine(" 🤩 Check out what I found about green cement!");
        Console.WriteLine();
        
        // ASCII Green Cement
        PrintGreenCementArt();
        // Header
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("═══════════════════════════════════════════════════════════════════");
        
        // Centered "Green Cement Insights" in green
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("                    🪨 Green Cement Insights 🌱                   ");
        
        // Divider line
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("═══════════════════════════════════════════════════════════════════");

        // Main content
        Console.ResetColor();
        Console.WriteLine();
        Console.WriteLine("🌍 Widely used in major construction to lower carbon footprint.\n");

        Console.WriteLine("🌟 Leading Countries:");
        Console.WriteLine("    🇳🇱  The Netherlands");
        Console.WriteLine("    🇸🇪  Sweden");
        Console.WriteLine("    🇩🇪  Germany\n");

        Console.WriteLine("🏗️  Perfect for large infrastructure projects.\n");
        Console.WriteLine("🌱  Supports environmental goals and sustainable urban growth.\n");

        Console.WriteLine("🛫 Example: Changi Airport (Singapore) uses recycled concrete in ");
        Console.WriteLine("aircraft stands, and roads, showcasing sustainable infrastructure.");

        // Bottom padding and final divider
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("═══════════════════════════════════════════════════════════════════");
        Console.ResetColor();
        Console.WriteLine();
        Console.WriteLine("📌 Press any key to continue...");
        Console.ReadKey();
        DanishToEnglish();
    }

    public void DanishToEnglish() 
    {
        // Narration - Workers
        Transition transition = new Transition();
        transition.EmojiTransition("🌍", "🌱");
        Console.WriteLine();

        Console.WriteLine();
        int Height = 15;  // Total height of the warning margin

        // Warning margin
        Tape.DisplayBar(1, Height);
        Console.WriteLine();
        Tape.DisplayBar(2, Height);
        Console.WriteLine();
        Tape.DisplayBar(3, Height);
        Console.WriteLine();
        Tape.DisplayBar(4, Height);
        Console.WriteLine("You present the idea of using green cement to the workers.");
        Tape.DisplayBar(5, Height);
        Console.WriteLine();
        Tape.DisplayBar(6, Height);
        Console.WriteLine("They value your contribution to Sønderborg's ProjectZero 2029, which brings them closer to their environmental goals.");
        Tape.DisplayBar(7, Height);
        Console.WriteLine();
        Tape.DisplayBar(8, Height);
        Console.WriteLine("The workers thank you for your suggestion.");
        Tape.DisplayBar(9, Height);
        Console.WriteLine();
        Tape.DisplayBar(10, Height);
        Console.WriteLine("One of the workers approaches you with a question.");
        Tape.DisplayBar(11, Height);
        Console.WriteLine();
        Tape.DisplayBar(12, Height);
        Console.WriteLine();
        Tape.DisplayBar(13, Height);
        Console.WriteLine();

        Console.WriteLine();
        CharactersManager.NPC_Color("worker2");
        Console.WriteLine(" Thank you again! I was wondering...");
        Console.WriteLine();
        Console.Write("📢 ");
        Console.ForegroundColor = ConsoleColor.Black;
        Console.BackgroundColor = ConsoleColor.DarkYellow;
        Console.Write(" Ved du om nogen eksempler fra den virkelige verden, hvor grøn cement er blevet brugt ");
        Console.ResetColor();
        Console.WriteLine(" ❓");
        Console.WriteLine();
        Thread.Sleep(2000); // Wait a bit (2s)
        transition.EmojiTransition("🤖", "🔍");
        Console.WriteLine();
        CharactersManager.NPC_Color("nova");
        Console.WriteLine(" Oh no❗ We haven’t fully convinced the workers yet, and some of my functions, like the translator, are still malfunctioning.");
        Console.WriteLine("I can tell the future hasn’t changed.");
        Console.WriteLine("We need to decipher the worker’s question and provide the right answer to win him over.");
        Console.WriteLine();
        Console.WriteLine("📌 Press any key to continue...");
        Console.ReadKey();
        Console.WriteLine();

        // Begin the Mini Game
        transition.EmojiTransition("⚙️", "🤖");
        Console.WriteLine();
        Console.WriteLine();
        CharactersManager.NPC_Color("nova");
        Console.WriteLine(" Alright, Darwin, let's try to decipher the text.");

        bool isValid = false;
        string? playerResponse;

        while (!isValid)
        {
            Console.WriteLine();
            Console.WriteLine("\nWhat would you like to do?");
            Console.WriteLine();

            // Options
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("1.");
            Console.ResetColor();
            Console.WriteLine(" Don't worry! I'm a Danish whiz 🧙‍♂️ — I can totally translate this myself❗");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("2.");
            Console.ResetColor();
            Console.Write(" Try using ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Write(" NOVA ");
            Console.ResetColor();
            Console.WriteLine(" to translate it.");

            playerResponse = Console.ReadLine();

            // Validate input
            if (string.IsNullOrEmpty(playerResponse) || (playerResponse != "1" && playerResponse != "2"))
            {
                InvalidInput();
            }
            else
            {
                isValid = true;

                switch (playerResponse)
                {
                    case "1":
                        Console.WriteLine();
                        transition.EmojiTransition("🔎", "🧠");
                        Console.WriteLine();
                        DecipherOnYourOwn();
                        break;

                    case "2":
                    Console.WriteLine();
                        transition.EmojiTransition("🔎", "🤖");
                        Console.WriteLine();
                        UseNovaToTranslate();
                        break;
                }
            }
        }
    }
    // =========================================
    //        LUIGI'S GLITCH ANIMATION    
    // =========================================
    public static void PortalTravel()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        string[] glitchFrames = new string[]
        {
            "@🪸%🚂ñ☀️!🐝", "Ω🎉ç♻️∫🤖˜", "∞🪸✨∂", "🚂∆∆🤖º🐝", "☀️9∞§🐝•🚂M", "✨≈☀️",
            "$✨I🤖!🐝¿", "♻️?@#🪸", "🚂π🤖@i🪸", "🎉≈ç∂✨¬∆", "@£☀️§∞🐝∞♻️ª",
            "$🎉@!♻️,🤖", "☀️?@✨🪸p7", "∑🚂@i🐝", "Ω≈k🤖ç🚂∂🎉¬∆", "🪸£✨§🤖¢☀️•ª",
            "$✨I🤖!🐝¿", "@🪸%ñ☀️!🐝", "∞🪸✨∂", "🎉≈🐝ç∂✨¬∆", "🐝£☀️§∞🐝∞🎉♻️ª",
        };

        Random random = new();
        int animationDuration = 4000;
        int frameTime = 100;

        DateTime endTime = DateTime.Now.AddMilliseconds(animationDuration);      
        Console.ForegroundColor = ConsoleColor.DarkCyan;                     
        while (DateTime.Now < endTime)
        {
            string glitch = glitchFrames[random.Next(glitchFrames.Length)];
            int left = random.Next(Console.WindowWidth - glitch.Length);
            int top = random.Next(Console.WindowHeight);

            Console.SetCursorPosition(left, top);
            Console.Write(glitch);
            
            Thread.Sleep(frameTime);
        }
        Console.ResetColor();
        Console.Clear();
        Console.Clear();
        Console.WriteLine();
    }

    // ============================
    //      ENDING OF ALL ERAS     
    // ============================            
    public void FinalEnding()                  
    {                                          
        Transition transition = new();         
        int Height = 15;
        Console.WriteLine();

        Tape.DisplayBar(1, Height);
        Console.WriteLine();
        Tape.DisplayBar(2, Height);
        Console.WriteLine();
        Tape.DisplayBar(3, Height);
        Console.WriteLine();
        Tape.DisplayBar(4, Height);
        Console.WriteLine();
        Tape.DisplayBar(5, Height);
        Console.WriteLine("The Sønderborg ProjectZero is now on track to achieve carbon neutrality by 2029.");
        Tape.DisplayBar(6, Height);
        Console.WriteLine();
        Tape.DisplayBar(7, Height);
        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.DarkCyan;
        Console.Write(" Asger ");
        Console.ResetColor();
        Console.Write(" and ");
        Console.ForegroundColor = ConsoleColor.Black;
        Console.BackgroundColor = ConsoleColor.DarkYellow;
        Console.Write(" Christian ");
        Console.ResetColor();
        Console.WriteLine(" thank you warmly and say goodbye."); 
        Tape.DisplayBar(8, Height);
        Console.WriteLine();       
        Tape.DisplayBar(9, Height);
        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.DarkGreen;
        Console.Write(" Nova ");
        Console.ResetColor();
        Console.WriteLine(" returns, fully restored and ready to assist you again!");
        Tape.DisplayBar(10, Height);
        Console.WriteLine();
        Tape.DisplayBar(11, Height);
        Console.WriteLine();
        Tape.DisplayBar(12, Height);
        Console.WriteLine();
        Tape.DisplayBar(13, Height);
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("📌 Press any key to continue...");
        Console.ReadKey();
        Console.WriteLine();
        transition.EmojiTransition("🎉", "🎊");
        Console.WriteLine();
        Console.WriteLine();

        Console.WriteLine(" 🟢 You did wonderfully! 🟢 ");
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.DarkGreen;
        CharactersManager.NPC_Color("nova");
        Console.ResetColor();
        Console.WriteLine(" I'm so proud of you for helping everyone you encountered on your quest.");
        Console.WriteLine("You've made a positive impact on your surroundings, environment, and ecosystem.");
        Console.WriteLine();

        CharactersManager.NPC_Color("nova");
        Console.WriteLine(" Great news, Darwin! I’m back to normal.");
        Console.Write("We can finally ");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("teleport");
        Console.ResetColor();
        Console.WriteLine(" back to our homeworld.");
        Console.WriteLine();
        Console.WriteLine("Plus, here are all the experience points you accumulated throughout the different eras on your quest:");
        Console.WriteLine();
        Console.WriteLine();
        Console.BackgroundColor = ConsoleColor.DarkGreen;
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("       Well Done!       ");
        Console.ResetColor();
        Console.WriteLine();
        PointSystem.Instance.DisplayPointsEarned();
        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.DarkMagenta;
        Console.Write("    CONGRATULATIONS!    ");
        Console.ResetColor();
        Console.WriteLine();
        Console.WriteLine();
        PrintCongratulationsArt();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("🎉 Press any key to continue...");
        
        using (var audioFile = new AudioFileReader("Music/fireworks.mp3"))
        using (var sound = new WaveOutEvent())
        {
            sound.Init(audioFile);
            sound.Play();

            // Wait for user input
            Console.ReadKey();
            sound.Stop();
        }

        Console.WriteLine();
        transition.EmojiTransition("🌀", "✨");
        Console.WriteLine();
        Console.WriteLine();

        Console.WriteLine();
        Tape.DisplayBar(3, Height);
        Console.WriteLine();
        Tape.DisplayBar(4, Height);
        Console.WriteLine();
        Tape.DisplayBar(5, Height);
        Console.WriteLine();
        Tape.DisplayBar(6, Height);
        Console.WriteLine("Nova is now fully available and has gained the ability to teleport 🌀");
        Tape.DisplayBar(7, Height);
        Console.WriteLine();
        Tape.DisplayBar(8, Height);
        Console.Write("A portal materializes in front of you as Nova explains, ");
        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.DarkGreen;
        Console.Write(" - We can go home now - ");
        Console.ResetColor();
        Console.WriteLine();
        Tape.DisplayBar(9, Height);
        Console.WriteLine();
        Tape.DisplayBar(10, Height);
        Console.WriteLine();
        Tape.DisplayBar(11, Height);
        Console.WriteLine();
        Console.WriteLine();

        // Ending Portal Art
        PrintEndingPortalArt();
        Console.WriteLine();

        // Loop to teleport to the ENDING of the GAME
        string? userInput = null;
        bool AccessEnding = false;

        while (!AccessEnding)
        {            
            Console.Write("Type ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Teleport");
            Console.ResetColor();
            Console.Write(" to proceed or ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("map");
            Console.ResetColor();
            Console.WriteLine(" to see where you are:");

            userInput = Console.ReadLine()?.Trim().ToLower();

            if (userInput == "teleport")
            {
                // Proceed to display the art and dialog
                AccessEnding = true;  // Exit loop after Entering

                // Calling the Emoji transition from Transition class
                transition.EmojiTransition("🌀", "✨");
            }
            else if (userInput == "map")
            {
                // Display the map for Era 3 Cement
                Map.DisplayMap("Era3Cement");

                // After showing the map, the user must type 'Teleport' to proceed
                Console.Write("Type ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Teleport");
                Console.ResetColor();
                Console.WriteLine(" to go back to your homeworld:");

                while (!AccessEnding)  // Loop until they type 'Teleport' after seeing the map
                {
                    userInput = Console.ReadLine()?.Trim().ToLower();
                    if (userInput == "teleport")
                    {
                        AccessEnding = true;  // Exit loop after Teleporting

                        // Calling the Emoji transition from Transition class
                        transition.EmojiTransition("🌀", "✨");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nInvalid choice.");
                        Console.ResetColor();
                        Console.Write("Please type ");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("Teleport");
                        Console.ResetColor();
                        Console.WriteLine(" to proceed.");
                    }
                }
            }
            else
            {
                // Invalid input handling
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nInvalid choice.");
                Console.ResetColor();
            }
        }
        Console.Clear();

        // Implement Luigi's Animation after "teleport"
        using (var audioFile = new AudioFileReader("Music/Glitch_sound.mp3"))
        using (var sound = new WaveOutEvent())
        {
            sound.Init(audioFile);
            sound.Play();

            // Play Luigi's glitch animation
            PortalTravel();
            sound.Stop();
        }

        // Get the specific Ending file for the user -> The CHECK happens at 23 points
        int totalScore = PointSystem.Instance.GetTotalScore();
        if (totalScore <= 23)
        {
            BadEnding badEnding = new ();
            badEnding.PlayBadEnding();
        }
        else
        {
            GoodEnding goodEnding = new ();
            goodEnding.PlayGoodEnding();
        }
    }
}