using System;
using System.Security.Cryptography.X509Certificates;
using MapAndCenter;
using NAudio.Wave;

public class Era2Corals
{
    private static void DeadCorals()
    {
        string[] ArtLines = {
            "     ~                      ~     _                      o  ",
            "          _   o        ~        ><_x         o         ~    ",
            "        ><_x                                                ", 
            "    0           ~            o   ()    ))   ~           ~   ",
            "                  ~            ((((   ;)               0    ",
            "           o                   ~ )) (( (            ~       ",
            "              ~                  ((   ))))               o  ",
            "    o  ~     _     0             &)) ((    ~                ",
            "           ><_x             69      &; )                v   ",
            "       ~            96    6  9      )) ((     g   Y    g    ",
            "                    996   66      ((   ))      YgYG   YG    ",
            "  ~        1   41   6  69  66      (((;;&  o      GGGYYG    ",
            "   o      41 14     666996         ;))      ~     gYY       ",
            "       ~    144  vvv    69     o    ((       vvv  GGg     ~ ",
            ",¬¬¬,,,,,,,44114,VVV,,,696,¬¬¬,,,,,,,)),,¬¬¬¬VVV·,,YYY,,¬¬¬¬",
            };

        int consoleWidth = Console.WindowWidth;

        foreach (var line in ArtLines)
        {
            foreach (char currentChar in line)
            {
                if (currentChar == '@' || currentChar == 'o')
                    Console.ForegroundColor = ConsoleColor.White;

                else if (currentChar == 'G')
                    Console.ForegroundColor = ConsoleColor.DarkGray;

                else if (currentChar == 'g')
                    Console.ForegroundColor = ConsoleColor.DarkGray;

                else if (currentChar == 'Y')
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                
                else if (currentChar == 'o')
                    Console.ForegroundColor = ConsoleColor.DarkGray;

                else if (currentChar == '-' || currentChar == '.' || currentChar == 'p' || currentChar == 'b' || currentChar == 'd' || currentChar == 'q' || currentChar == '`' || currentChar == '{')
                    Console.ForegroundColor = ConsoleColor.DarkGray;

                else if (currentChar == '#' || currentChar == '~' || currentChar == '◎')
                    Console.ForegroundColor = ConsoleColor.Gray;

                else if (currentChar == ';')
                    Console.ForegroundColor = ConsoleColor.DarkGray;

                else if (currentChar == '&' || currentChar == ')')
                    Console.ForegroundColor = ConsoleColor.DarkGray;

                else if (currentChar == '/' || currentChar == '_')
                    Console.ForegroundColor = ConsoleColor.Gray;
                
                else if (currentChar == '8' || currentChar == '<' || currentChar == '⸨' || currentChar == '■')
                    Console.ForegroundColor = ConsoleColor.DarkGray;

                // Era 2 characters
                else if (currentChar == '\'' || currentChar == '¬' || currentChar == '{' || currentChar == '}')
                    Console.ForegroundColor = ConsoleColor.DarkGray;

                else if (currentChar == ',' || currentChar == '·' || currentChar == '-')
                    Console.ForegroundColor = ConsoleColor.DarkGray;

                else if (currentChar == '(')
                    Console.ForegroundColor = ConsoleColor.DarkGray; 
                
                else if (currentChar == '9')
                    Console.ForegroundColor = ConsoleColor.DarkGray;

                else if (currentChar == '6' || currentChar == '○')
                    Console.ForegroundColor = ConsoleColor.DarkGray;

                else if (currentChar == '>' || currentChar == '4' || currentChar == '⊗')
                    Console.ForegroundColor = ConsoleColor.DarkGray;

                else if (currentChar == '1' || currentChar == 'O')
                    Console.ForegroundColor = ConsoleColor.DarkGray;

                else
                    Console.ResetColor();

                Console.Write(currentChar);
            }
            Console.ResetColor();
            Console.WriteLine();
        }
    }
    
    private static void AliveCorals()
    {
        string[] ArtLines = {
            "     ~                      ~      _                     o  ",
            "              o        ~         ><_>        o         ~    ",
            "        ~                                                   ", 
            "    0           ~            o   ()    ))   ~           ~   ",
            "   _              ~    _       ((((   ;)               0    ",
            " ><_>      o         ><_>      ~ )) (( (         _  ~       ",
            "              ~                  ((   ))))     ><_>      o  ",
            "       ~           0             &)) ((    ~                ",
            "                _           69      &; )                Y   ",
            "       ~      ><_>  96    6  9      )) ((     g   g    g    ",
            "     o              996   66      ((   ))      YgYG   gG    ",
            "  ~        1   41   6  69  66      (((;;&  o      gGGgYG    ",
            "          41 14     666996         ;))      ~     gYY       ",
            "       ~    144  vvv    69     o    ((       vvv  gGg     ~ ",
            ",¬¬¬,,,,,,,44114,VVV,,,696,¬¬¬,,,,,,,)),,¬¬¬¬VVV·,,YYY,,¬¬¬¬",
            };

        int consoleWidth = Console.WindowWidth;

        foreach (var line in ArtLines)
        {
            foreach (char currentChar in line)
            {
                if (currentChar == '@' || currentChar == 'o')
                    Console.ForegroundColor = ConsoleColor.White;

                else if (currentChar == 'G' || currentChar == 'Y')
                    Console.ForegroundColor = ConsoleColor.DarkYellow;

                else if (currentChar == 'g')
                    Console.ForegroundColor = ConsoleColor.Yellow;
                
                else if (currentChar == 'o')
                    Console.ForegroundColor = ConsoleColor.Cyan;

                else if (currentChar == '-' || currentChar == '.' || currentChar == 'p' || currentChar == 'b' || currentChar == 'd' || currentChar == 'q' || currentChar == '`' || currentChar == '{')
                    Console.ForegroundColor = ConsoleColor.Yellow;

                else if (currentChar == '#' || currentChar == '~' || currentChar == '◎')
                    Console.ForegroundColor = ConsoleColor.DarkCyan;

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

    // Instance of the point system
    private PointSystem pointSystem = new PointSystem();

    // Tracks if the map has been viewed
    private bool hasViewedMap = false;

    // Displays the introduction to Era 2 Corals
    public void Intro()
    {
        EraTitle eraTitle = new EraTitle();
        eraTitle.Print("Welcome to Era 2 Corals!");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("You have teleported to Era 2 to save the corals!\n");
        Console.ResetColor();

        CharactersManager.NPC_Color("nova");
        Console.WriteLine(" You have teleported next to the ocean 🌊");
        Console.WriteLine("The water is murky and lifeless.");
        Console.WriteLine();
        Console.Write("Type ");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("map");
        Console.ResetColor();
        Console.WriteLine(" to see where you are.\n");

        ValidateUserInput();
    }

    // Validates the user's input for 'observe' or 'map'
    private void ValidateUserInput()
    {
        string userInput;
        bool inMapPhase = true;  // Track if we're in the map phase

        while (true)
        {
            userInput = (Console.ReadLine() ?? "").Trim().ToLower();

            if (inMapPhase)
            {
                if (userInput == "map")
                {
                    // Display the map and set the flag
                    Map.DisplayMap("Era2Corals");
                    hasViewedMap = true;

                    Console.WriteLine();
                    Console.Write("Type ");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("observe");
                    Console.ResetColor();
                    Console.WriteLine(", to look around.");

                    inMapPhase = false;  // Transition to the "observe" phase
                }
                else
                {
                    // Handle invalid input for the map phase
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input. Please try again.");
                    Console.ResetColor();
                    Console.WriteLine();
                    Console.Write("Please type ");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("map");
                    Console.ResetColor();
                    Console.WriteLine(" to see 👀 where you are.");
                }
            }
            else
            {
                // Now in the "observe" phase
                if (userInput == "observe")
                {
                    // Ensure the map has been viewed first
                    if (hasViewedMap)
                    {
                        Story(); // Proceed with the story
                        break;   // Exit the loop and finish the process
                    }
                    else
                    {
                        // If the map hasn't been viewed yet
                        Console.Write("You must view the map first by typing ");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("map");
                        Console.ResetColor();
                        Console.WriteLine(" before observing your surroundings.");
                    }
                }
                else
                {
                    // Handle invalid input for the "observe" phase
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input.");
                    Console.ResetColor();
                    Console.WriteLine();
                    Console.Write("Please type ");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("observe");
                    Console.ResetColor();
                    Console.WriteLine(" to look around.");
                }
            }
        }
    }

    private void Story()
    {
        Console.Clear();
        Console.WriteLine("Looks like the fish are starting to die.");
        Console.WriteLine("I should do something to help them");

        Console.WriteLine();
        CharactersManager.NPC_Color("nova");
        Console.WriteLine(" Coral reefs are like the rainforests of the sea, providing vital habitats for a diverse array of marine life.");
        Console.WriteLine();
        Console.WriteLine("We should try to recover the corals.");
        Console.WriteLine("\n\n");
        DeadCorals();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("\nPRESS ENTER");
        Console.ResetColor();
        Console.WriteLine(" to continue");
        Console.ReadLine();
        ExecuteObservationLogic();
    }

    // Executes the logic for observing the surroundings
    private void ExecuteObservationLogic()
    {
        Console.Clear();
        Transition transition = new Transition();
        transition.EmojiTransition("🐠", "🌊");
        Console.WriteLine("\nYou see 👀 a broken water pump. It might help regenerate the coral reefs.");
        Console.Write("\nType ");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("investigate");
        Console.ResetColor();
        Console.Write(" to check out the pump.");
        Console.WriteLine();

        // Now, validate the user's input for 'investigate'
        ValidateInvestigateInput();
    }


    // Validates the user's input for 'investigate'
    private void ValidateInvestigateInput()
    {
        while (true)
        {
            string userInput1;
            userInput1 = (Console.ReadLine()??"").Trim().ToLower();

            if (userInput1 == "investigate")
            {
                InvestigatePumpLogic();
                break;
            }
            else
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input");
                Console.ResetColor();
                Console.WriteLine();
                Console.Write("Please type ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("investigate");
                Console.ResetColor();
                Console.WriteLine(" to examine the water pump.");
            }
        }
    }

    // Logic when the user investigates the water pump
    private void InvestigatePumpLogic()
    {
        Console.Clear();
        Console.WriteLine();
        Console.WriteLine("\nThere are materials next to the water pump. They look useful!\n");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("PRESS ENTER");
        Console.ResetColor();
        Console.WriteLine(" to continue");
        Console.ReadLine();

        Console.WriteLine("A man approaches from afar...");
        Console.WriteLine();

        CharactersManager.NPC_Color("");
        Console.WriteLine(" Hey, looks like you need help with fixing that water pump.\n\n");

        string[] ArtLines = {
            "            '\\",
            "           '  \\   {)",
            "   -~-~  '     \\@  |     _   -~--~--~-~-~-~-~-~-~-~-~-~~",
            "-~-~   '     ___`\\/|______\\   -~-~-~-~-~--~-~-~-~-~-~~~-~",
            "~-~ ' ~-~    \\-=-=-=-=-=-/(}~-~-~--~-~-~-~-~-~-~-~-~~-~-~",
            "~'-~-~-~-~-~-~-~-~-~-~-~-~-~-~-~-~-~-~--~-~-~-~-~-~~-~",
            "-~--~-~-~~-~-~-~-~-~-~-~-~-~-~-~-~--~--~-~-~~-~-~-~-~~-",
            "~-~-~-~-~-~-~-~-~-~-~-~-~-~-~-~-~-~-~-~-~-~-~-~-~-~"
        };

        foreach (var line in ArtLines)
        {
            for (int i = 0; i < line.Length; i++)
            {
                char currentChar = line[i];

                if (currentChar == '=' || currentChar == '_')
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else if (currentChar == '/' || currentChar == '|' || currentChar == '{' || currentChar == ')')
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                else if (currentChar == '~')
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                }
                else if (currentChar == '-')
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
                else if (currentChar == '\'')
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
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

        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("1. ");
        Console.ResetColor();
        Console.WriteLine("Yes, I need to save the coral reefs, but I don't know what to do.");
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("2. ");
        Console.ResetColor();
        Console.WriteLine("Ask Nova who this man is.");

        while(true)
        {
            string userInput2 = (Console.ReadLine() ?? "").Trim().ToLower();
            if (userInput2 == "1")
            {
                FishermanHelp();
                break;
            }
            else
            {
                Console.WriteLine();
                CharactersManager.NPC_Color("nova");
                Console.Write(" This man looks like a local ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Magenta;
                Console.Write(" fisherman ");
                Console.ResetColor();
                Console.Write(". He might help us rebuild the corals.\n");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("\n\nPRESS ENTER");
                Console.ResetColor();
                Console.WriteLine(" to continue");
                Console.ReadLine();
                FishermanHelp();
                break;
            }
        }
        
    }

    // Describes the fisherman's assistance
    private void FishermanHelp()
    {
        Console.Clear();
        Console.WriteLine("\n\n");
        CharactersManager.NPC_Color("fisherman");
        Console.Write(" The materials next to the water pump are ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("nitrogen");
        Console.ResetColor();
        Console.Write(" and ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("phosphorus.");
        Console.ResetColor();
        Console.WriteLine();

        CharactersManager.NPC_Color("fisherman");
        Console.WriteLine(" Mix these two materials and pump them underwater to rebuild the coral polyps which holds the coral reefs together!");
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("PRESS ENTER");
        Console.ResetColor();
        Console.WriteLine(" to continue");
        Console.ReadLine();
        FixPump();
    }

    private void FixPump()
    {
        Console.Clear();
        Console.WriteLine("\n\n");
        CharactersManager.NPC_Color("fisherman");
        Console.WriteLine(" I can fix the pump for you but you should get the generator working again.");
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("PRESS ENTER");
        Console.ResetColor();
        Console.WriteLine(" to continue");
        Console.ReadLine();
        FixGenerator();
    }

    private void FixGenerator()
    {
        Console.Clear();
        Console.WriteLine("\n\n");
        CharactersManager.NPC_Color("nova");
        Console.WriteLine(" To get the generator working you need an energy source");
        Console.WriteLine();

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("PRESS ENTER");
        Console.ResetColor();
        Console.WriteLine(" to continue");
        Console.ReadLine();

        CharactersManager.NPC_Color("nova");
        Console.Write(" I managed to gather some photovoltaic cells from ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("Era 1");
        Console.ResetColor();
        Console.WriteLine(", and we can make our own mini solar panel.");
        Console.WriteLine("\nYou could use the energy from solar panels by connecting the cables.");
        Console.WriteLine();

        Console.Write("Type ");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("connect");
        Console.ResetColor();
        Console.Write(" to attach the cables");
        Console.WriteLine();
        while (true)
        {
            string userInput3 = (Console.ReadLine()??"").Trim().ToLower();

            if (userInput3 == "connect")
            {
                Console.WriteLine("\n\n🔌⚡ Connecting the cables... ");
                Console.WriteLine();
                Console.WriteLine();
                CharactersManager.NPC_Color("nova");
                Console.WriteLine(" Cables connected successfully. Generator is operational ✅");
                
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("\nPRESS ENTER");
                Console.ResetColor();
                Console.WriteLine(" to continue");
                
                Console.ReadLine();
                MixMaterials();
                break; // Exit the loop
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Wrong input: ");
                Console.ResetColor();
                Console.Write("Type ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("connect");
                Console.ResetColor();
            }
        }
    }

    private void MixMaterials()
    {
        Console.Clear();
        Console.WriteLine("\n\n");
        CharactersManager.NPC_Color("fisherman");
        Console.WriteLine(" I fixed the water pump.\n");
        Console.WriteLine("The rest is in your hands, Darwin");
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("PRESS ENTER");
        Console.ResetColor();
        Console.WriteLine(" to continue");
        Console.ReadLine();
        Console.WriteLine();
        CharactersManager.NPC_Color("nova");
        Console.Write(" You should ");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("mix");
        Console.ResetColor();
        Console.WriteLine(" the materials now.");
        Console.WriteLine();

        while (true)
        {
            string userInput4 = (Console.ReadLine() ?? "").Trim().ToLower();
            if (userInput4 == "mix")
            {
                Console.WriteLine("\n🧪 Mixing nitrogen and phosphorus ⚗️...");
                Console.WriteLine();
                CharactersManager.NPC_Color("nova");
                Console.Write(" Materials successfully mixed.");
                Console.WriteLine("You should now pump them to the dead 🪸 corals 🪸 underwater!");
                Console.WriteLine();
                
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("PRESS ENTER");
                Console.ResetColor();
                Console.WriteLine(" to continue");
                Console.ReadLine();
                
                PumpMaterials();
                break;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Wrong input: ");
                Console.ResetColor();
                Console.Write("Type ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("mix");
                Console.ResetColor();
            }
        }
    }

    private void PumpMaterials()
    {
        Console.Clear();
        Console.WriteLine("\n\n");
        Console.Write("To pour the mixture type ");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("put");
        Console.ResetColor();
        Console.WriteLine();

        while(true)
        {
            string userInput5 = (Console.ReadLine() ?? "").Trim().ToLower();
            if (userInput5 == "put")
            {
                Console.WriteLine();
                CharactersManager.NPC_Color("nova");
                Console.WriteLine(" You dispensed the mixture succesfully!");
                Console.WriteLine("\n");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("PRESS ENTER");
                Console.ResetColor();
                Console.WriteLine(" to continue");
                Console.ReadLine();
                
                QuizEnter();
                break;
            }

            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Wrong input: ");
                Console.ResetColor();
                Console.Write("Type ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("put");
                Console.ResetColor();
            }
        }
    }

    public void CoralsTable()
    {
        Console.WriteLine("\n");
        CharactersManager.NPC_Color("nova");
        Console.WriteLine(" 🪸 Let’s dive into some fascinating facts about corals!");
        Console.WriteLine();

        // Coral Reef Insights
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("═════════════════════════════════════════════════════════════════════════════════════════════════");

        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("                                   🪸 Coral Reef Insights 🌊                                  ");

        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("═════════════════════════════════════════════════════════════════════════════════════════════════");

        // Main content
        Console.ResetColor();
        Console.WriteLine();

        // 🌊 What is a coral reef?
        Console.ForegroundColor = ConsoleColor.Green; // Set text color to green
        Console.WriteLine("🌊 What is a coral reef?");
        Console.ResetColor(); // Reset to default color
        Console.WriteLine("   - An underwater ecosystem characterized by reef-building corals.");
        Console.WriteLine();

        // 🌀 What are coral polyps?
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("🌀 What are coral polyps?");
        Console.ResetColor();
        Console.WriteLine("   - Coral polyps are tiny, soft-bodied organisms that form the structure of coral reefs.");
        Console.WriteLine("     They secrete calcium carbonate (CaCO3) to build protective skeletons,");
        Console.WriteLine("     which over time create vast reef structures.");
        Console.WriteLine();

        // 🌟 How do coral reefs form?
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("🌟 How do coral reefs form?");
        Console.ResetColor();
        Console.WriteLine("   - Reefs are formed by colonies of coral polyps held together by calcium carbonate.");
        Console.WriteLine();

        // 🌎 Why are coral reefs important?
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("🌎 Why are coral reefs important?");
        Console.ResetColor();
        Console.WriteLine("   - Coral reefs support 25% of marine life, protect coastlines from erosion,");
        Console.WriteLine("     and contribute to the global economy through tourism and fisheries.");
        Console.WriteLine();

        // ✨ Fun Fact
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("✨ Fun Fact: ");
        Console.ResetColor();
        Console.WriteLine("Coral reefs are often called \"the rainforests of the sea\" due to their biodiversity.");
        Console.WriteLine();

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("🤔 What is happening in our world?");
        Console.ResetColor();
        Console.WriteLine("     🔆 Thailand is a leader in coral restoration using solar-powered techniques.\n");
        Console.WriteLine("     ⚛️ Calcium carbonate (CaCO3) is researched for its role in sustainable materials.\n");
        Console.Write("     👷🏼 Like the creation of ");
        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.DarkGreen;
        Console.Write(" green cement ");
        Console.ResetColor();
        Console.WriteLine(" from CaCO3");
        // Bottom padding and final divider
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("═════════════════════════════════════════════════════════════════════════════════════════════════");
        Console.ResetColor();
        Console.WriteLine();
        Console.WriteLine("📌 Press any key to continue...");
        Console.ReadKey();
    }

    private void QuizEnter()
    {
        Console.Clear();
        Console.WriteLine("\n\n");
        CharactersManager.NPC_Color("nova");
        Console.WriteLine(" Looks like you need to enter a code to pump the mixture.");
        Console.WriteLine();

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("PRESS ENTER");
        Console.ResetColor();
        Console.WriteLine(" to continue");
        Console.ReadLine();

        Console.WriteLine();
        CharactersManager.NPC_Color("nova");
        Console.Write(" To obtain the code, you must solve the quiz that the ");
        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.Magenta;
        Console.Write(" fisherman ");
        Console.ResetColor();
        Console.WriteLine(" has prepared for us.");
        Console.WriteLine("He wants to see if we are worthy 🔨");
        Console.WriteLine();
        CharactersManager.NPC_Color("nova");
        Console.WriteLine(" But not to worry, I have your back Darwin 🤗\n\n");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("PRESS ENTER");
        Console.ResetColor();
        Console.WriteLine(" to continue");
        Console.ReadLine();
        CoralsTable();
        Console.Clear();
        quiz1();
    }

    private void quiz1()
    {
        Transition transition = new Transition();
        transition.EmojiTransition("🐠", "🌊");

        Console.WriteLine("\n🪸 What is a coral reef?");
        Console.WriteLine();

        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("1- ");
        Console.ResetColor();
        Console.WriteLine("An underwater ecosystem characterized by reef-building corals");

        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("2- ");
        Console.ResetColor();
        Console.WriteLine("They are forests that are not important");

        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("3- ");
        Console.ResetColor();
        Console.WriteLine("A type of seaweed");

        string userInput6 = (Console.ReadLine()??"").Trim().ToLower();
        if (userInput6 == "1")
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("✅ Correct answer");
            Console.ResetColor();
            quiz2();
        }
        else if (userInput6 == "2" || userInput6 == "3")
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n❌ Wrong answer");
            Console.ResetColor();
            quiz1();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("⚠️ Wrong input.\n");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Type ");
            Console.ResetColor();
            Console.Write("1, 2, or 3");
            Console.WriteLine();
            Console.ResetColor();
            quiz1();
        }
    }

    private void quiz2()
    {
        Transition transition = new Transition();
        transition.EmojiTransition("🐠", "🌊");

        Console.WriteLine("\n🪸 How do coral reefs form?");
        Console.WriteLine();

        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("1- ");
        Console.ResetColor();
        Console.WriteLine("By the seeds that birds leave on the water");

        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("2- ");
        Console.ResetColor();
        Console.WriteLine("By different chemicals that humans make");

        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("3- ");
        Console.ResetColor();
        Console.WriteLine("Reefs are formed of colonies of coral polyps");

        string userInput7 = (Console.ReadLine() ?? "").Trim().ToLower();

        if (userInput7 == "3")
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("✅ Correct answer");
            Console.ResetColor();
            quiz3();
        }
        else if (userInput7 == "1" || userInput7 == "2")
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("❌ Wrong answer");
            Console.ResetColor();
            quiz2();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("⚠️ Wrong input.");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Type ");
            Console.ResetColor();
            Console.Write("1, 2, or 3");
            Console.WriteLine();
            Console.ResetColor();
            quiz2();
        }
    }

    private void quiz3()
    {
        Transition transition = new Transition();
        transition.EmojiTransition("🐠", "🌊");

        Console.WriteLine("\n🪸 What holds the coral polyps together?");
        Console.WriteLine();

        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("1- ");
        Console.ResetColor();
        Console.WriteLine("Calcium carbonate (CaCO3)");

        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("2- ");
        Console.ResetColor();
        Console.WriteLine("Electrical energy");

        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("3- ");
        Console.ResetColor();
        Console.WriteLine("Beeswax");

        string userInput8 = (Console.ReadLine() ?? "").Trim().ToLower();

        if (userInput8 == "1")
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("✅ Correct answer");
            Console.ResetColor();
            quiz4();
        }
        else if (userInput8 == "2" || userInput8 == "3")
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("❌ Wrong answer");
            Console.ResetColor();
            quiz3();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("⚠️ Wrong input.");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Type ");
            Console.ResetColor();
            Console.Write("1, 2, or 3");
            Console.WriteLine();
            Console.ResetColor();
            quiz3();
        }
    }

    private void quiz4()
    {
        Transition transition = new Transition();
        transition.EmojiTransition("🐠", "🌊");

        Console.WriteLine("\n🪸 What is the nickname of coral reefs?");
        Console.WriteLine();

        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("1- ");
        Console.ResetColor();
        Console.WriteLine("Underwater Fossils");

        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("2- ");
        Console.ResetColor();
        Console.WriteLine("The rainforests of the sea");

        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("3- ");
        Console.ResetColor();
        Console.WriteLine("Sea creatures");

        string userInput9 = (Console.ReadLine() ?? "").Trim().ToLower();

        if (userInput9 == "2")
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("✅ Correct answer");
            Console.ResetColor();
            EnterCode();
        }
        else if (userInput9 == "1" || userInput9 == "3")
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("❌ Wrong answer");
            Console.ResetColor();
            quiz4();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("⚠️ Wrong input.");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Type ");
            Console.ResetColor();
            Console.Write("1, 2, or 3");
            Console.WriteLine();
            Console.ResetColor();
            quiz4();
        }
    }

    private void EnterCode()
    {
        Console.Clear();
        Console.WriteLine("\n\n");
        Transition transition = new Transition();
        transition.EmojiTransition("🐠", "🌊");
        Console.WriteLine("\n\n");
        CharactersManager.NPC_Color("nova");
        Console.WriteLine(" The code is Nemo");
        Console.WriteLine();

        Console.Write("Type ");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("nemo");
        Console.ResetColor();
        Console.Write(" to activate the pump");
        Console.WriteLine();

        while(true)
        {
            string userInput10 = (Console.ReadLine()??"").Trim().ToLower();
            if(userInput10 == "nemo")
            {
                Console.WriteLine("\n");
                Console.WriteLine("🥳 Congratulations you have succesfully revived the coral reefs");
                Console.WriteLine("\n");
                PrintFishArt();
                break;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\nWrong input: ");
                Console.ResetColor();
                Console.Write("Type ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("nemo");
                Console.ResetColor();     
            } 
        }
    }

    private void PrintFishArt()
    {
        string[] artLines = {
        "       o                 o        O    o     O  ",
        "  o               o                   O         ",
        "  O o   O     o   ______      o                 ",
        "                _/  (   / _                     ",
        "      _       _/  (       /_  o                 ",
        "     | |_   _/  (   (    0  /_                  ",
        "     |== |_/  (   (           |            o    ",
        "     |=== _ (   (   (         |               O ",
        "     |==_/ |_ (   (         _/                 o",
        "     |_/    |_ (   (    __/                     ",
        "  o          | _ (      _/          o           ",
        "    O           |  |___/            O           ",
        "               /__/                             ",
        };

        int consoleWidth = Console.WindowWidth;
        foreach (var line in artLines)
        {
            int padding = (consoleWidth - line.Length) / 2;
            padding = Math.Max(0, padding);
            Console.Write(new string(' ', padding));
            for (int i = 0; i < line.Length; i++)
            {
                char currentChar = line[i];
                if (currentChar == '(')
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                }
                else if (currentChar == 'o')
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
                else
                {
                    Console.ResetColor(); // Reset color for other characters
                }
                Console.Write(currentChar);
            }
            Console.ResetColor();
            Console.WriteLine();
        }

        using (var audioFile = new AudioFileReader("Music/Ocean.mp3"))
        using (var sound = new WaveOutEvent())
        {
            sound.Init(audioFile);
            sound.Play();

            // Wait for user input
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("\n\nPRESS ENTER");
            Console.ResetColor();
            Console.WriteLine(" to continue");
            Console.ReadLine();
            sound.Stop();
        }
        Console.ResetColor();
        Console.WriteLine("\n");

        CharactersManager.NPC_Color("fisherman");
        Console.WriteLine(" Thank you for restoring life to the corals and creating a home for all marine creatures.");
        Console.WriteLine("\nIncluding Nemo right here.");
        Console.WriteLine();
        AliveCorals();
    }

    // Main entry point into the Era 2 Corals area
    public void Enter()
    {
        string actionE1;
        EraTitle eraTitle = new EraTitle();
        eraTitle.Print("Welcome to Era 2 Corals!");
        Console.Write("\nWould you like to ");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("ENTER");
        Console.ResetColor();
        Console.WriteLine(" era 2 corals?");

        actionE1 = Console.ReadLine()!.Trim().ToLower();

        while (actionE1 != "enter")
        {
                if (actionE1 == "map") {
                        Map.DisplayMap("Era2Corals");
                        actionE1 = Console.ReadLine()!.Trim().ToLower();
                }
                else if (actionE1 != "enter") {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nInvalid choice.");
                    Console.ResetColor();
                    actionE1 = Console.ReadLine()!.Trim().ToLower();
                }
        }
        if (actionE1 == "enter") 
        {
            Console.Clear();
            Intro();

            // Add points to Era 2 Corals
            PointSystem.Instance.AddPoints(3, 4);  // 4 points for Era2Corals (3)

            // Display the points earned across all eras
            PointSystem.Instance.DisplayPointsEarned();
        }
    }
}