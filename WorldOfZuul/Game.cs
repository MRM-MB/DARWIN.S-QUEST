using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using MapAndCenter;
using NAudio.Wave; // -> dotnet add package NAudio

namespace WorldOfZuul
{
    public class Game
    {
        private Room? currentRoom;
        private Room? previousRoom;
        private Portal? portal;
        private PointSystem pointSystem;

        public Game()
        {
            CreateRooms();
            pointSystem = new PointSystem();  // Initialize the PointSystem
        }

        private void CreateRooms()
        {
            Room? outside = new("Outside", "You are standing outside the main entrance of the university. To the east is a large building, to the south is a computing lab, and to the west is the campus pub.");
            Room? theatre = new("Theatre", "You find yourself inside a large lecture theatre. Rows of seats ascend up to the back, and there's a podium at the front. It's quite dark and quiet.");
            Room? pub = new("Pub", "You've entered the campus pub. It's a cozy place, with a few students chatting over drinks. There's a bar near you and some pool tables at the far end.");
            Room? lab = new("Lab", "You're in a computing lab. Desks with computers line the walls, and there's an office to the east. The hum of machines fills the room.");
            Room? office = new("Office", "You've entered what seems to be an administration office. There's a large desk with a computer on it, and some bookshelves lining one wall.");

            outside.SetExits(null, theatre, lab, pub); // North, East, South, West
            theatre.SetExit("west", outside);
            pub.SetExit("east", outside);
            lab.SetExits(outside, office, null, null);
            office.SetExit("west", lab);

            currentRoom = outside;
        }

        public void Play()
        {
            Parser parser = new();
            var newMap = new Map();  // Making an instance of the map is necessary
            portal = new Portal();
            // WHEN SWITCHING ROOMS PLEASE DEFINE IT AS HERE!

            PrintWelcome();

            bool continuePlaying = true;
            while (continuePlaying)
            {
                // Show the current era instead of the default "Outside"
                if ($"{portal.CurrentRoomName}" == "Homeworld") // The player need to follow the introduction to understand the game. In this way they won't know how to teleport to the next era
                {
                    Console.WriteLine("");
                }
                else
                {
                    Console.Write($"Current Era: {portal.CurrentRoomName}");
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.Write("> Type ");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("teleport");
                    Console.ResetColor();
                    Console.WriteLine(" to continue.");
                }
                // Console.WriteLine(currentRoom?.ShortDescription);
                // Console.Write("> ");

                string? input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Please enter a command.");
                    Console.ResetColor();
                    Console.WriteLine();
                    continue;
                }

                Command? command = parser.GetCommand(input);

                if (command == null)
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("I don't know that command.");
                    Console.ResetColor();
                    Console.WriteLine();
                    continue;
                }

                switch (command.Name)
                {
                    case "look":
                        Console.WriteLine(currentRoom?.LongDescription);
                        break;

                    case "back":
                        if (previousRoom == null)
                            Console.WriteLine("You can't go back from here!");
                        else
                            currentRoom = previousRoom;
                        break;

                    /*case "north":
                    case "south":
                    case "east":
                    case "west":
                        Move(command.Name);
                        break;*/

                    case "quit":
                        continuePlaying = false;
                        break;

                    case "help":
                        PrintHelp();
                        break;

                    case "map":
                    // Display the map of the current era
                    Map.DisplayMap(portal.CurrentRoomName);
                    break;

                    case "teleport":
                    // Teleport and change the era
                    portal.Teleport();
                    break;

                    case "points":
                    // Display the points earned by the player
                    PointSystem.Instance.DisplayPointsEarned();
                    break;

                    default:
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("I don't know that command.");
                        Console.ResetColor();
                        Console.WriteLine();
                        break;
                }
            }

            Console.WriteLine("Thank you for playing Darwin's quest!");
        }

        private void Move(string direction)
        {
            if (currentRoom?.Exits.ContainsKey(direction) == true)
            {
                previousRoom = currentRoom;
                currentRoom = currentRoom?.Exits[direction];
            }
            else
            {
                Console.WriteLine($"You can't go {direction}!");
            }
        }
        private static void PrintWelcome()
        {
            Console.Clear();

            string[] lines = {
                "+====+",
                "|(::)|",
                "| )( |",
                "|(  )|",
                "+====+",
                "In the shadow of a dying Earth, where rivers run dry and the sky chokes with ash, humanity stands at the brink of extinction."
            };
            Map.CenterText(lines);

            // Wait for user input
            Console.WriteLine("\n\nPress any key to continue...");
            Console.ReadKey(); // Wait for a key press
            Console.Clear();

            lines = new string[] {
                "+====+",
                "|(..)|",
                "| )( |",
                "|(..)|",
                "+====+",
                "A secret, ancient technology, lost to time, is unearthed — a gateway to the past."
            };
            Map.CenterText(lines);
            Console.WriteLine("\n\nPress any key to continue...");
            Console.ReadKey();
            Console.Clear();

            lines = new string[] {
                "+====+",
                "|(  )|",
                "| )( |",
                "|(::)|",
                "+====+",
                "Only by traveling through the forgotten eras of human history can you rewrite the mistakes that brought the world to its knees, and restore balance before it’s too late."
            };
            Map.CenterText(lines);
            Console.WriteLine("\n\nPress any key to continue...");
            Console.ReadKey();
            Console.Clear();

            // Title Display for Tablets or Small Computers
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            string message = "Press 's' for small devices like tablets (e.g., Microsoft Surface) or any other key for larger devices like laptops:";

            // Use the new function to center the message
            Console.WriteLine();
            Console.WriteLine();
            ScreenCentering.DisplayCenteredMessage(message);
            Console.ResetColor();

            // Capture user input without displaying it
            char userInput = Console.ReadKey(true).KeyChar;
            Console.WriteLine();
            Console.Clear();

            // ASCII art lines with dollar signs
            lines = new string[]
            {
                @"                                                                                                                                                        ",
                @"           ::                                                                                                                             ::            ",
                @"           ::                                                                                                                             ::**@@@@@     ",
                @"           ::                                                                                                                             ::*@@@@@@@    ",
                @"           ::                                                                                                                             ::*@@@@@@@    ",
                @"    *@@@@@@::                                                                                                                             ::@@@@@@      ",
                @"   *@@@@@@@:: $$$$$$$\                                    $$\         $$\                $$$$$$\                                  $$\     ::@@@@@       ",
                @"   @@@@ **@:: $$  __$$\                                   \__|        $  |              $$  __$$\                                 $$ |    ::@@@@@@*     ",
                @"   *@@  *@@:: $$ |  $$ | $$$$$$\   $$$$$$\  $$\  $$\  $$\ $$\ $$$$$$$\\_/$$$$$$$\       $$ /  $$ |$$\   $$\  $$$$$$\   $$$$$$$\ $$$$$$\   ::@@@**@@@@   ",
                @"       *@@@:: $$ |  $$ | \____$$\ $$  __$$\ $$ | $$ | $$ |$$ |$$  __$$\ $$  _____|      $$ |  $$ |$$ |  $$ |$$  __$$\ $$  _____|\_$$  _|  ::@@   *@@@@@ ",
                @"**     @@@@:: $$ |  $$ | $$$$$$$ |$$ |  \__|$$ | $$ | $$ |$$ |$$ |  $$ |\$$$$$$\        $$ |  $$ |$$ |  $$ |$$$$$$$$ |\$$$$$$\    $$ |    ::@       *** ",
                @"@@@ *@@@@@@:: $$ |  $$ |$$  __$$ |$$ |      $$ | $$ | $$ |$$ |$$ |  $$ | \____$$\       $$ $$\$$ |$$ |  $$ |$$   ____| \____$$\   $$ |$$\ ::@**         ",
                @"*@@@@@@@ @@:: $$$$$$$  |\$$$$$$$ |$$ |      \$$$$$\$$$$  |$$ |$$ |  $$ |$$$$$$$  |      \$$$$$$ / \$$$$$$  |\$$$$$$$\ $$$$$$$  |  \$$$$  |::@@@@*       ",
                @" *@@@@@  *@:: \_______/  \_______|\__|       \_____\____/ \__|\__|  \__|\_______/        \___$$$\  \______/  \_______|\_______/    \____/ ::@@@*        ",
                @"  **@@     ::                                                                                \___|                                        ::@*          ",
                @"           ::                                                                                                                             :@*           ",
                @"           ::                                                                                                                             ::*           ",
                @"                                                                                                                                                        ",
                @"                                                                                                                                                        ",                                                                                
            };

            // Use the new function to center ASCII art and handle device display
            ScreenCentering.DisplayCenteredAscii(lines, userInput);

            PrintHelp();
        }

        private static void IntroArt()
        {
            int consoleHeight = Console.WindowHeight;
            int artHeight = 15;  // Height of ASCII art (number of lines in `ArtLines`)
            int startRow = consoleHeight - artHeight;
            Console.SetCursorPosition(0, startRow);

            string[] ArtLines = {
                "                                                                         ~      _                                    //⸩                            ",
                "        d8b                                  .=+                    ~         ><_>        o    ~ +==.               ⸨ ■ -                           ",
                "     d88888b                                 - +=.                                              +#+ =               \"\"           .' '.       __   ", 
                "     888888888                               .. .%+. ~       ~            o   ()    ))   ~      ++#  -.               .        .   .     '   ⸨__\\   ",
                "     888888888 ``                       *@@@@  .%.+.    ~      ~    _       ((((   ;)        .=#+#  ..    *@@@@       .      ,   ,       '. -{{_⸨|8⸩",
                "      q88888p   ``                      *@@@@  .%.+..   o         ><_>      ~ )) (( (        .=#+#  ..    *@@@@         '  (  ( O  ). '      ⸨__/   ",
                "        q8p ``   ``                *@@@@@@@ =  -+=%=.                         ((   ))))     .-+=%..    *@@@@@            ( (     )  ))              ",
                "         ``   ``  ``              *@@@@@@@@ =  -++#=.=          0             &)) ((    ~  +.=#=#.. *@@@@@@@@          ; ( (   )  O  ) ;            ",
                "          ``   ``  ``            *@   @@@@@ =..-++#+.=       _           69      &; )       +.=#=#.*@@  *@@@@            (  O (   )) / )            ",
                "      ___________  __________     @@  @@@@   #+-+++#+.=    ><_>  96    6  9      )) ((    o +.=#=#.*@@  *@@@              ( ( \\     O ) ;           ",
                "     /__/___/___/ /__/___/__/        *@@@   =  .++%+.=           996   66      ((   ))     +.-+=#..   *@@@@                ( |  // ))       //⸩     ",
                "    /__/___/___/ /__/___/__/        *@@@@@@*   .+=#=.   1   41   6  69  66      (((;;&      ..+=%-.   *@@@@@@       { }      |   |   { }   ⸨ ■ -    ",
                "  /__/___/___/ /__/___/__/         @@@   *@@@..#-#-    41 14     666996         ;))      ~  .++#+   *@@   *@@@@   {(◎)}     |   |  {(○)}   \"\"     ",
                "    ║║      ║║   ║║     ║║         *@@      *@@*.==      144  vvv    69          ((            #+*@@*@@@      *@@    (       |   |    (             ",
                ";&;;║║&;;&;;║║;;&║║;;;;&║║;;;;; *@@@@  ;;;;;; %+  ¬¬¬¬¬,44114,VVV,,,696,¬¬¬,,,,,,,)),,¬¬¬¬¬¬¬·,,-*  *@@  ;;&&;; *@@ ;;);;;;&&;;;;;;;&&;);;;;&&;;;;;;",
                };

            int consoleWidth = Console.WindowWidth;

            foreach (var line in ArtLines)
            {
                int padding = (consoleWidth - line.Length) / 2;  // Calculate padding based on the current console width
                Console.Write(new string(' ', Math.Max(0, padding)));  // Ensure padding is not negative (Avoid Error 0 in the console width)

                foreach (char currentChar in line)
                {
                    if (currentChar == '@' || currentChar == 'o')
                        Console.ForegroundColor = ConsoleColor.White;

                    else if (currentChar == '*' || currentChar == '║' || currentChar == '^')
                        Console.ForegroundColor = ConsoleColor.DarkGray;

                    else if (currentChar == '=' || currentChar == '%' || currentChar == '║' || currentChar == 'o')
                        Console.ForegroundColor = ConsoleColor.Cyan;

                    else if (currentChar == '+')
                        Console.ForegroundColor = ConsoleColor.Blue;

                    else if (currentChar == '-' || currentChar == '.' || currentChar == 'p' || currentChar == 'b' || currentChar == 'd' || currentChar == 'q' || currentChar == '`' || currentChar == '{')
                        Console.ForegroundColor = ConsoleColor.Yellow;

                    else if (currentChar == '#' || currentChar == '~' || currentChar == '◎')
                        Console.ForegroundColor = ConsoleColor.DarkCyan;

                    // Era 1 characters
                    else if (currentChar == ';')
                        Console.ForegroundColor = ConsoleColor.Green;

                    else if (currentChar == '&' || currentChar == ')')
                        Console.ForegroundColor = ConsoleColor.DarkGreen;

                    else if (currentChar == '/' || currentChar == '_')
                        Console.ForegroundColor = ConsoleColor.Gray;
                    
                    else if (currentChar == '8' || currentChar == '<' || currentChar == '⸨' || currentChar == '■')
                        Console.ForegroundColor = ConsoleColor.DarkYellow;

                    // Era 2 characters
                    else if (currentChar == '\'' || currentChar == '¬' || currentChar == '{' || currentChar == '}')
                        Console.ForegroundColor = ConsoleColor.Yellow;

                    else if (currentChar == ',' || currentChar == '·' || currentChar == '-')
                        Console.ForegroundColor = ConsoleColor.DarkYellow;

                    else if (currentChar == '(')
                        Console.ForegroundColor = ConsoleColor.Green; 
                    
                    else if (currentChar == '9')
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;

                    else if (currentChar == '6' || currentChar == '○')
                        Console.ForegroundColor = ConsoleColor.Magenta;

                    else if (currentChar == '>' || currentChar == '4' || currentChar == '⊗')
                        Console.ForegroundColor = ConsoleColor.Red;

                    else if (currentChar == '1' || currentChar == 'O')
                        Console.ForegroundColor = ConsoleColor.DarkRed;

                    else
                        Console.ResetColor();

                    Console.Write(currentChar);
                }
                Console.ResetColor();
                Console.WriteLine();
            }
        }

        private static void PrintHelp()
        {   
        string[] lines = {
                "╔][══════════════════════════════════════════][╗",
                "║        📜 Journey into the eras 📜         ║",
                " ║                                            ║ ",
                " ║          Press ENTER to continue!          ║ ",
                " ║                                            ║ ",
                "╚][══════════════════════════════════════════][╝",
                ""
        };
        int consoleWidth = Console.WindowWidth;
        foreach (var line in lines)
        {
            int spaces = (consoleWidth - line.Length) / 2;
            if (spaces > 0)
            {
                Console.Write(new string(' ', spaces));
            }
            foreach (char currentChar in line)
            {
                if (currentChar == '╔' || currentChar == '╗' || currentChar == '╚' || currentChar == '╝' || currentChar == '═' || currentChar == '║')
                    Console.ForegroundColor = ConsoleColor.DarkYellow;  // Frame body
                else if (currentChar == 'E' || currentChar == 'N' || currentChar == 'T' || currentChar == 'R')
                    Console.ForegroundColor = ConsoleColor.DarkGreen; // ENTER text
                else if (currentChar == '[' || currentChar == ']')
                    Console.ForegroundColor = ConsoleColor.Yellow; // Gear of frame
                else
                    Console.ResetColor();  // Default for other characters

                Console.Write(currentChar);
            }
            Console.ResetColor();
            Console.WriteLine();
        }

        // Just some space above the Mini Darwin ASCII art
        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine();
        }
        
            // Mini Darwin ASCII art
            IntroArt();

            // Play intro sound of the game title
            using (var audioFile = new AudioFileReader("Music/intro.mp3"))
            using (var sound = new WaveOutEvent())
            {
                bool IsStopping = false; // Flag to prevent looping on manual stop

                // Event handler to loop the music
                sound.PlaybackStopped += (sender, e) =>
                {
                    if (!IsStopping) // Only loop if playback wasn't stopped intentionally
                    {
                        audioFile.Position = 0; // Reset to the start
                        sound.Play();           // Restart playback
                    }
                };

                sound.Init(audioFile);
                sound.Play();

                Console.ReadLine(); // Press ENTER to start playing

                // Set flag and stop playback
                IsStopping = true;
                sound.Stop();
            }

            Console.Clear();

            // Execute Darwin_Homeworld.cs - Luigi's file
            Darwin_Homeworld darwinHomeworld = new Darwin_Homeworld();
            darwinHomeworld.Enter();

            // Console.WriteLine("Navigate by typing 'north', 'south', 'east', or 'west'.");
            // Console.WriteLine("Type 'look' for more details.");
            // Console.WriteLine("Type 'back' to go to the previous room.");
            // Console.WriteLine("Type 'help' to print this message again.");
            // Console.WriteLine("Type 'quit' to exit the game."); 
        }
    }
}