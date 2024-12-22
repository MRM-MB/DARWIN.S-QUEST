using MapAndCenter;
using NAudio.Wave; // -> dotnet add package NAudio

public class Era3SDU
{
    // Create a PointSystem instance
    PointSystem pointSystem = new PointSystem();

    // Class for my CandyCane structure
    public class CandyCane
    {
        // Display the top of the candy cane
        public static void DisplayCandyCaneTop()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("╔"); // Red corner
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("═══"); // White straight lines
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("╗ "); // Red corner
            Console.ResetColor();
        }

        // Display the candy cane bar (alternating lines)
        public static void DisplayBar(int lineNumber)
        {
            if (lineNumber % 2 == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.Write("║  "); // The trunk of the candy cane
            Console.ResetColor();
        }
    }

    // Method that prints the welcome message for Era 3 SDU
    public void Enter()
    {
        // Function to get the current real year
        static int CurrentYear()
        {
            return DateTime.Now.Year;
        }

        int Year = CurrentYear();

        EraTitle eraTitle = new EraTitle();
        eraTitle.Print("Welcome to Era 3 SDU!");

        Console.WriteLine();
        Console.WriteLine();
        CharactersManager.NPC_Color("nova");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(" You have teleported to Era3SDU (Era 3)!"); // Show arrival text
        Console.ResetColor();
        Console.WriteLine();
        
        Console.WriteLine();
        CandyCane.DisplayCandyCaneTop();
        CandyCane.DisplayBar(1);
        Console.WriteLine();
        CandyCane.DisplayBar(2);
        Console.WriteLine("You've just teleported to Denmark.");
        CandyCane.DisplayBar(3);
        Console.WriteLine();
        CandyCane.DisplayBar(4);
        Console.WriteLine($"It's the year {Year}, and the weather isn’t ideal 🥶");
        CandyCane.DisplayBar(5);
        Console.WriteLine();
        CandyCane.DisplayBar(6);
        Console.WriteLine("The temperature is freezing ❄️, and the rain 🌧️ is coming down hard.");
        CandyCane.DisplayBar(7);
        Console.WriteLine();
        CandyCane.DisplayBar(8);
        Console.WriteLine("You should head into the nearby building for cover ☂️");
        CandyCane.DisplayBar(9);
        Console.WriteLine();
        Console.WriteLine();

        PrintSDUBuilding();
        Console.WriteLine();

        string? userInput = null;
        bool insideBuilding = false;

        // Loop until the user either enters or sees the map, and then enters at SDU building
        while (!insideBuilding)
        {
            using (var audioFile = new AudioFileReader("Music/rain.mp3"))
            using (var sound = new WaveOutEvent())
            {
                sound.Init(audioFile);
                sound.Play();

                // Display the prompt with "enter" and "map" in cyan
                Console.Write("Type ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("enter");
                Console.ResetColor();
                Console.Write(" to proceed or ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("map");
                Console.ResetColor();
                Console.WriteLine(" to see where you are:");

                userInput = Console.ReadLine()?.Trim().ToLower();
                sound.Stop();
            }

            if (userInput == "enter")
            {
                // Proceed to display the art and dialog
                insideBuilding = true;  // Exit loop after entering

                // Calling the Emoji transition from Transition class
                Transition transition = new Transition();
                transition.EmojiTransition("☔", "🌧️");  // Use custom emojis here
            }
            else if (userInput == "map")
            {
                // Display the map for Era 3 SDU
                Map.DisplayMap("Era3SDU");

                // After showing the map, the user must type 'enter' to proceed
                Console.Write("Type ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("enter");
                Console.ResetColor();
                Console.WriteLine(" to go inside the building:");

                while (!insideBuilding)  // Loop until they type 'enter' after seeing the map
                {
                    userInput = Console.ReadLine()?.Trim().ToLower();
                    if (userInput == "enter")
                    {
                        insideBuilding = true;  // Exit loop after entering

                        // Calling the Emoji transition from Transition class
                        Transition transition = new Transition();
                        transition.EmojiTransition("☔", "🌧️");  // Use custom emojis here
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nInvalid choice.");
                        Console.ResetColor();
                        Console.Write("Please type ");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("enter");
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
        eraTitleAgain.Print("Welcome to Era 3 SDU!");

        Console.WriteLine();
        Console.WriteLine();
        CharactersManager.NPC_Color("nova");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(" You are inside SDU (Sønderborg)!"); // Show arrival text
        Console.ResetColor();
        Console.WriteLine();
        
        // If the player has chosen to enter, show the ASCII art and dialog
        PrintEra3Art();
        ShowDialog();
    }

    // Hangman style game for the word BEESWAX to help the Mechatronics student
    private void NovaAiHangman()
    {
        string wordToGuess = "BEESWAX";
        char[] guessedWord = { '_', '_', 'E', '_', '_', 'A', '_' };
        int attempts = 6; // Number of attempts allowed

        CharactersManager.NPC_Color("nova");

        Console.WriteLine(" Come on, Darwin! You can do this!");

        Console.Write("Remember, back in ");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.Write("Era 2 'Bees'");
        Console.ResetColor();
        Console.WriteLine(" , we used honey to create this material, and it is mainly utilized for food preservation.");
        Console.WriteLine("The same material can be used as a coating agent to make materials more durable and resistant.");
        Console.WriteLine();
        Console.WriteLine("You can do it! Here's a hint:");

        while (attempts > 0 && new string(guessedWord) != wordToGuess)
        {
            Console.WriteLine();
            Console.WriteLine();
            CandyCane.DisplayCandyCaneTop(); // Show the top part of the candy cane
            CandyCane.DisplayBar(1);
            Console.WriteLine();
            CandyCane.DisplayBar(2);
            Console.WriteLine($"Attempts left: {attempts}");
            CandyCane.DisplayBar(3);
            Console.WriteLine();
            CandyCane.DisplayBar(4);
            Console.WriteLine($"Guessed word so far: {new string(guessedWord)}");
            CandyCane.DisplayBar(5);
            Console.WriteLine();

            Console.Write("\nGuess a letter: ");
            char userGuess = char.ToUpper(Console.ReadKey().KeyChar);
            Console.WriteLine();

            bool correctGuess = false;
            for (int i = 0; i < wordToGuess.Length; i++)
            {
                if (wordToGuess[i] == userGuess)
                {
                    guessedWord[i] = userGuess;
                    correctGuess = true;
                }
            }

            if (!correctGuess)
            {
                attempts--;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("❌ Incorrect guess!");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("✅ Good guess!");
                Console.ResetColor();
            }
        }

        if (new string(guessedWord) == wordToGuess)
        {
            // Transition
            Transition transitionC = new Transition();
            transitionC.EmojiTransition("★", "🎄");  // Use custom emojis here
            
            Console.WriteLine();
            CharactersManager.NPC_Color("nova");
            Console.WriteLine(" That's right! Beeswax is a great biodegradable material to recommend.");

            Console.WriteLine();
            CandyCane.DisplayCandyCaneTop(); // Show the top part of the candy cane
            CandyCane.DisplayBar(1);
            Console.WriteLine();
            CandyCane.DisplayBar(2);
            Console.WriteLine("You inform Matthew and his team that beeswax is a reusable, sustainable way to strengthen their 3D-printed parts.");
            CandyCane.DisplayBar(3);
            Console.WriteLine();
            CandyCane.DisplayBar(4);
            Console.WriteLine("Beeswax forms a protective layer that guards against wear, prevents degradation, and even strengthens materials over time.");
            CandyCane.DisplayBar(5);
            Console.WriteLine();
            CandyCane.DisplayBar(6);
            Console.WriteLine("Making it ideal for improving the longevity and toughness of 3D-printed parts.");
            CandyCane.DisplayBar(7);
            Console.WriteLine();

            Console.WriteLine();
            CharactersManager.NPC_Color("matthew");
            Console.WriteLine(" Thank you so much! That sounds fantastic and is exactly what we’re looking for.");
            Console.WriteLine("We really appreciate your suggestion, and we’ll definitely be using it.");
            Console.WriteLine();
            Console.WriteLine();

            bool isValid = false;  // Flag to control the loop
            string? response;

            while (!isValid)
            {
                Console.WriteLine("Answer Matthew: ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("_______________");
                Console.ResetColor();
                Console.WriteLine();

                // Show the menu options
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("1.");
                Console.ResetColor();
                Console.WriteLine(" Glad I could help, Merry Christmas! 🎄☃️");

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("2.");
                Console.ResetColor();
                Console.WriteLine(" Anytime, good luck with your project and Happy Holidays! 🍀😊☃️");

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("3.");
                Console.ResetColor();
                Console.WriteLine(" Of course, the more people share ideas, the better. Merry Christmas! ❄️🎅");

                // Validate the user's input
                response = Console.ReadLine();  // Allow the response to be nullable

                // Check for null or invalid response
                if (string.IsNullOrEmpty(response) || (response != "1" && response != "2" && response != "3"))
                {
                    // Invalid input
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nInvalid choice.");
                    Console.ResetColor();

                    Console.Write("Please select ");

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("1");
                    Console.ResetColor();

                    Console.Write(", ");

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("2");
                    Console.ResetColor();

                    Console.Write(", or ");

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("3");
                    Console.ResetColor();

                    Console.WriteLine(".");

                    Console.WriteLine();
                    Console.WriteLine();
                }
                else
                {
                    Transition transitionMatt = new Transition();
                    transitionMatt.EmojiTransition("★", "🎄");

                    // Valid input, handle the response
                    isValid = true;  // Exit loop as we have a valid response

                    switch (response)
                    {
                        case "1":
                            Console.WriteLine();
                            CharactersManager.NPC_Color("matthew");
                            Console.WriteLine(" Thank you so much! Your help was exactly what we needed. Have a wonderful holiday season! 🎄🔔");
                            Console.WriteLine("And please enjoy a freshly made cookie from our Christmas party today! 🍪");
                            break;

                        case "2":
                            Console.WriteLine();
                            CharactersManager.NPC_Color("matthew");
                            Console.WriteLine(" Thank you! Your suggestion will have a positive impact 🦾. Have a wonderful holiday season! ‧₊˚🎄✩ ₊˚🦌⊹♡");
                            break;

                        case "3":
                            Console.WriteLine();
                            CharactersManager.NPC_Color("matthew");
                            Console.WriteLine(" Absolutely! Collaborating makes everything better. Thanks again and happy holidays! 🎅☃️🔔");
                            break;
                    }
                }
            }

            Console.WriteLine();
            CandyCane.DisplayCandyCaneTop(); // Show the top part of the candy cane
            CandyCane.DisplayBar(1);
            Console.WriteLine();
            CandyCane.DisplayBar(2);
            Console.WriteLine("Look at that—the other mechatronics students are gathering around the team you helped and are also considering using beeswax for their projects.");
            CandyCane.DisplayBar(3);
            Console.WriteLine();
            CandyCane.DisplayBar(4);
            Console.WriteLine("You've truly made a valuable contribution today, and you've inspired these young minds.");
            CandyCane.DisplayBar(5);
            Console.WriteLine();
            CandyCane.DisplayBar(6);
            Console.WriteLine("😊 You should be proud of yourself!");
            CandyCane.DisplayBar(7);
            Console.WriteLine();
            Console.WriteLine();

            // Add points to Era 3 SDU
            PointSystem.Instance.AddPoints(4, 8);  // 8 points for Era3SDU (4)

            // Display the points earned across all eras
            PointSystem.Instance.DisplayPointsEarned();

            // Nova Message
            CharactersManager.NPC_Color("nova");
            Console.WriteLine(" Alright, Darwin, let's head back home and see if our efforts across multiple adventures have brought any meaningful improvements.");
            Console.WriteLine();
            Console.WriteLine();
        }
        else
        {
            // Transition
            Transition transitionC = new Transition();
            transitionC.EmojiTransition("★", "🎄");  // Use custom emojis here

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nYou've run out of attempts!");
            Console.ResetColor();
            Console.WriteLine();
            CharactersManager.NPC_Color("nova");
            Console.Write(" The word you were looking for is ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("BEESWAX");
            Console.ResetColor();

            Console.WriteLine();
            CandyCane.DisplayCandyCaneTop(); // Show the top part of the candy cane
            CandyCane.DisplayBar(1);
            Console.WriteLine();
            CandyCane.DisplayBar(2);
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Write(" Nova ");
            Console.ResetColor();
            Console.WriteLine(" informs Matthew and his team that beeswax is a reusable, sustainable way to strengthen their 3D-printed parts.");
            CandyCane.DisplayBar(3);
            Console.WriteLine();
            CandyCane.DisplayBar(4);
            Console.WriteLine("Beeswax forms a protective layer that guards against wear, prevents degradation, and even strengthens materials over time.");
            CandyCane.DisplayBar(5);
            Console.WriteLine();
            CandyCane.DisplayBar(6);
            Console.WriteLine("Making it ideal for improving the longevity and toughness of 3D-printed parts.");
            CandyCane.DisplayBar(7);
            Console.WriteLine();

            Console.WriteLine();
            CharactersManager.NPC_Color("matthew");
            Console.WriteLine(" Thank you so much! That sounds fantastic and is exactly what we’re looking for.");
            Console.WriteLine("We really appreciate your suggestion, and we’ll definitely be using it.");
            Console.WriteLine();
            Console.WriteLine();

            bool isValid = false;  // Flag to control the loop
            string? response;

            while (!isValid)
            {
                Console.WriteLine("Answer Matthew: ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("_______________");
                Console.ResetColor();
                Console.WriteLine();

                // Show the menu options
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("1.");
                Console.ResetColor();
                Console.WriteLine(" Glad I could help, Merry Christmas! 🎄☃️");

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("2.");
                Console.ResetColor();
                Console.WriteLine(" Anytime, good luck with your project and Happy Holidays! 🍀😊☃️");

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("3.");
                Console.ResetColor();
                Console.WriteLine(" Of course, the more people share ideas, the better. Merry Christmas! ❄️🎅");

                // Validate the user's input
                response = Console.ReadLine();  // Allow the response to be nullable

                // Check for null or invalid response
                if (string.IsNullOrEmpty(response) || (response != "1" && response != "2" && response != "3"))
                {
                    // Invalid input
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nInvalid choice.");
                    Console.ResetColor();

                    Console.Write("Please select ");

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("1");
                    Console.ResetColor();

                    Console.Write(", ");

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("2");
                    Console.ResetColor();

                    Console.Write(", or ");

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("3");
                    Console.ResetColor();

                    Console.WriteLine(".");

                    Console.WriteLine();
                    Console.WriteLine();
                }
                else
                {
                    Transition transitionMatt = new Transition();
                    transitionMatt.EmojiTransition("★", "🎄");

                    // Valid input, handle the response
                    isValid = true;  // Exit loop as we have a valid response

                    switch (response)
                    {
                        case "1":
                            Console.WriteLine();
                            CharactersManager.NPC_Color("matthew");
                            Console.WriteLine(" Thank you so much! Your help was exactly what we needed. Have a wonderful holiday season! 🎄🔔");
                            Console.WriteLine("And please enjoy a freshly made cookie from our Christmas party today! 🍪");
                            break;

                        case "2":
                            Console.WriteLine();
                            CharactersManager.NPC_Color("matthew");
                            Console.WriteLine(" Thank you! Your suggestion will have a positive impact 🦾. Have a wonderful holiday season! ‧₊˚🎄✩ ₊˚🦌⊹♡");
                            break;

                        case "3":
                            Console.WriteLine();
                            CharactersManager.NPC_Color("matthew");
                            Console.WriteLine(" Absolutely! Collaborating makes everything better. Thanks again and happy holidays! 🎅☃️🔔");
                            break;
                    }
                }
            }

            Console.WriteLine();
            CandyCane.DisplayCandyCaneTop(); // Show the top part of the candy cane
            CandyCane.DisplayBar(1);
            Console.WriteLine();
            CandyCane.DisplayBar(2);
            Console.WriteLine("Look at that—the other mechatronics students are gathering around the team you helped and are also considering using beeswax for their projects.");
            CandyCane.DisplayBar(3);
            Console.WriteLine();
            CandyCane.DisplayBar(4);
            Console.WriteLine("We've truly made a valuable contribution today, and you've inspired these young minds.");
            CandyCane.DisplayBar(5);
            Console.WriteLine();
            Console.WriteLine();

            // The player failed to guess the word BEESWAX
            // so no points are assigned this time

            // Display the points the player earned across all eras
            pointSystem.DisplayPointsEarned();

            // Nova Message
            CharactersManager.NPC_Color("nova");
            Console.WriteLine(" Alright, Darwin, let's head back home and see if our efforts across multiple adventures have brought any meaningful improvements.");
            Console.WriteLine();
            Console.WriteLine();
        }
    }

    private void PrintSDUBuilding()
    {
        string[] artLines = {
            "    /      *   //    /      /    *     /   *  /    /      /  *       /      *   /      *      /    / /  *  /     /       /        /   *  /   /",
            " /   *  // /   /      / *   /       /    /      /  *       /     /     * /      /  /     /     /    / /  *  //   /   *    /    /   /   *   // ",
            "  //    /     *  /  *     /   *     /      *          /   *          /      //       /      /  /*     /     *    /    /   //    /      /  /  /",
            "/      *     //     //      /          *       /   *     //     * /   /     * /   / *   /  /     /    /    /   *   /    /     /    / *  /  * /",
            " *    /   * ╔════┌───/─┐═══/╗  *   //  /   /  * ╔═/══┌─/───┐═══/╗   /   * /    /  /    *     /  / *   ╔═/══┌/────┐══/═╗  /  *   /   //  *  /  ",
            " / *    /  /║··/·│· E ·│·/··║/╔══/═_____/_═══/╗ ║·/··│■ ■/■│·//·║  // /  /  /  *   /╔═══____/___══/═╗/║·/··│■ ■/■│·/··║ ╔═/══____/__═/══╗/ */ ",
            " ╔───:/──╗  │■/■ │  N /│ ■ ■│ │═══//════/═════│ │■/■ │■/■ ■│/■ ■│ /  /  &%&%&%// /  │═/══════/══════│ │■ ■ │■ ■ ■│ ■ ■│ │═════/═══════/═│  / /",
            "╔═!!!!!!!═╗ │■ ■ │  T  │ ■/■│/│L L │■ ■ ■│ L/L│ │■ ■/│■ ■ ■│ ■/■│   / %&%&&%&&%  /  │L L │  ■  │ L/L│ │■ ■/│■ ■/■│/■ ■│ │L L │  M  │ L L│ */  ",
            "║ ═/═══// ║ │■ ■/│  E  │ ■ ■│ │L L/│■ ■ ■│ L L│ │■ ■ │■ ■/■│ ■ ■│ /   &&%& %&&%/&// │L/L │/ ■  │ L L│ │■ ■ │■ ■ ■│ ■/■│ │L L/│  C  │ L/L│  /  ",
            "║│ S D U │║=│■ ■ │  R  │/■ ■│=│L L │■ ■ ■│/L L│=│■/■ │■ ■ ■│ ■/■│==== &%% ` /%& ====│L L │  ■/ │/L L│=│■ ■ │■ ■/■│ ■ ■│=│L L │  E /│ L L│/ * /",
            "║│ ┌─│─┐/│║=│─/──┘_____└/───│=│────┘/____└────│=│──/─┘_/___└/───│===/=== | | =====/=│────┘_/___└─/──│=│─/──┘_____└────│=│──/─┘__/__└──/─│ /   ",
            "║│/│ │ │ │║ │____║▒▒▒▒▒║_/__│ │__:_║░░░░░║_:__│ │/___║▒▒▒▒▒║__/_│,;,;/,;,| |;//,;,;,│__:_║░░░░░║_:__│ │____║▒▒▒▒▒║_/__│ │__:_║░░░░░║_:__│,;,;/",
        };

        // Centering
        int consoleWidth = Console.WindowWidth;

        foreach (var line in artLines)
        {
            int padding = (consoleWidth - line.Length) / 2;
            padding = Math.Max(0, padding);
            Console.Write(new string(' ', padding));

            // SDU Christmas Colors
            for (int i = 0; i < line.Length; i++)
            {
                char currentChar = line[i];

                if (currentChar == '/')
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
                else if (currentChar == '■' || currentChar == 'L' || currentChar == '!')
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                else if (currentChar == 'S' || currentChar == 'E' || currentChar == 'N' || 
                currentChar == 'T' || currentChar == 'R' || currentChar == 'M' || currentChar == 'C')
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                }
                else if (currentChar == '&' || currentChar == ',' || currentChar == 'U')
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else if (currentChar == '%' || currentChar == ';')
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
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
    }

    private void PrintEra3Art()
    {
        string[] artLines = {
            "                                                                     OOO             ",
            "    @@@@@@@@     ###########        $$$$        $$$$               OOOOO             ",
            "  @@@@@@@@@@@    ##############     $$$$        $$$$             OOOOOO              ",
            " @@@@            ####       ####    $$$$        $$$$            OOOOO                ",
            "  @@@@           ####        ####   $$$$        $$$$                   OOOOOOOO      ",
            "   @@@@@@@       ####        ####   $$$$        $$$$       OOOOOOO     OOOOOOOOOO    ",
            "      @@@@@@@    ####        ####   $$$$        $$$$     OOO       OO    OOOOOOOOOO  ",
            "         @@@@@   ####        ####   $$$$        $$$$           OOOOOOOOO             ",
            "          @@@@   ####       ####    $$$$        $$$$          OOOOOOOOOO             ",
            "  @@@@@@@@@@@@   ##############      $$$$$$$$$$$$$$             OOOOOOOO             ",
            "   @@@@@@@@@     ###########          $$$$$$$$$$$$               OOOOOO              ",
        };

        // Centering
        int consoleWidth = Console.WindowWidth;

        foreach (var line in artLines)
        {
            int padding = (consoleWidth - line.Length) / 2;
            padding = Math.Max(0, padding);
            Console.Write(new string(' ', padding));

            // SDU Christmas Colors
            for (int i = 0; i < line.Length; i++)
            {
                char currentChar = line[i];

                if (currentChar == '@')
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else if (currentChar == '#')
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (currentChar == '$')
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else if (currentChar == 'O')
                {
                    Console.ForegroundColor = ConsoleColor.Red;
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
    }

    private void ShowDialog()
    {
        // Mini-Story Begins:
        Console.WriteLine();
        Console.WriteLine();
        CandyCane.DisplayCandyCaneTop(); // Show the top part of the candy cane
        CandyCane.DisplayBar(1);
        Console.WriteLine();
        CandyCane.DisplayBar(2);
        Console.WriteLine("You have just entered South Denmark University in the city of Sønderborg.");
        CandyCane.DisplayBar(3);
        Console.WriteLine();
        CandyCane.DisplayBar(4);
        Console.WriteLine("It's the end of the year, almost 🎅 Christmas 🎄, and the campus is bustling with students working on their final semester projects.");
        CandyCane.DisplayBar(5);
        Console.WriteLine();
        CandyCane.DisplayBar(6);
        Console.WriteLine("As you walk through the halls, you hear 📢 noises coming from the Mechatronics lab.");
        CandyCane.DisplayBar(7);
        Console.WriteLine();

        // Enter Mechatronics Lab YES/NO
        string choice;
        do
        {
            using (var audioFile = new AudioFileReader("Music/mechatronics.mp3"))
            using (var sound = new WaveOutEvent())
            {
                sound.Init(audioFile);
                sound.Play();
                // Enter Choice
                Console.WriteLine();
                Console.Write("\nDo you want to investigate the Mechatronics lab? (Enter ");

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("1");
                Console.ResetColor();

                Console.Write(" or ");

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("2");
                Console.ResetColor();

                Console.WriteLine(")");

                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("1.");
                Console.ResetColor();
                Console.WriteLine(" Yes");

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("2.");
                Console.ResetColor();
                Console.WriteLine(" No");

                // Handle user input, trim whitespace, and ensure it's not null
                choice = Console.ReadLine()?.Trim() ?? "invalid";
                sound.Stop();
            }

            // If the input is invalid
            if (choice != "1" && choice != "2")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nInvalid choice."); // Adds a space "\n"
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
            }
        } while (choice != "1" && choice != "2");  // Loop for valid input

        if (choice == "1")
        {
            // Calling the Emoji transition from Transition class
            Transition transition = new Transition();
            transition.EmojiTransition("★", "🎄");  // Use custom emojis here            
            VisitMechatronicsLab();
        }
        else
        {
            Transition transitionRedo = new Transition();
            transitionRedo.EmojiTransition("★", "🎄");
            Console.WriteLine();
            CharactersManager.NPC_Color("nova");
            Console.WriteLine(" Are you sure you don't want to investigate the Mechatronics lab?");
            Console.WriteLine("You could really help some people, you never know. Investigate and see 👀 what's going on.");
            
            // Second choice if the player initially selects "No"
            string secondChoice;
            do
            {
                Console.WriteLine();
                Console.Write("\nDo you want to leave SDU or investigate the lab? (Enter ");

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("1");
                Console.ResetColor();

                Console.Write(" or ");

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("2");
                Console.ResetColor();

                Console.WriteLine(")");

                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("1.");
                Console.ResetColor();
                Console.WriteLine(" Leave SDU");

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("2.");
                Console.ResetColor();
                Console.WriteLine(" Investigate the lab");

                // Handle user input, trim whitespace, and ensure it's not null
                secondChoice = Console.ReadLine()?.Trim() ?? "invalid";

                // If the input is invalid
                if (secondChoice != "1" && secondChoice != "2")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nInvalid choice."); // Adds a space "\n"
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
                }
            } while (secondChoice != "1" && secondChoice != "2");  // Loop for valid input

            if (secondChoice == "1")
            {
                Transition transition = new Transition();
                transition.EmojiTransition("★", "🎄");

                Console.WriteLine();
                CandyCane.DisplayCandyCaneTop();
                CandyCane.DisplayBar(1);
                Console.WriteLine();
                CandyCane.DisplayBar(2);
                Console.WriteLine("You chose to leave the eerie noises of the Mechatronics lab behind, opting to continue your journey elsewhere.");
                CandyCane.DisplayBar(3);
                Console.WriteLine();
                Console.WriteLine();

                CharactersManager.NPC_Color("nova");
                Console.WriteLine(" Alright, Darwin, let's head back home and see if our efforts across multiple adventures have brought any meaningful improvements.");
                Console.WriteLine();
                Console.WriteLine();
            }
            else
            {
                // Calling the Emoji transition from Transition class
                Transition transition = new Transition();
                transition.EmojiTransition("★", "🎄");  // Use custom emojis here            
                VisitMechatronicsLab();
            }
        }
    }

    private void VisitMechatronicsLab()
    {
        Console.WriteLine();
        CandyCane.DisplayCandyCaneTop(); // Show the top part of the candy cane
        CandyCane.DisplayBar(1);
        Console.WriteLine();
        CandyCane.DisplayBar(2);
        Console.WriteLine("As you enter the Mechatronics lab, you notice a group of students gathered around a 3D printer,");
        CandyCane.DisplayBar(3);
        Console.WriteLine();
        CandyCane.DisplayBar(4);
        Console.WriteLine("busy working 🔧 on their semester project.");
        CandyCane.DisplayBar(5);
        Console.WriteLine();
        CandyCane.DisplayBar(6);

        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.DarkMagenta;
        Console.Write(" Matthew ");
        Console.ResetColor();
        Console.WriteLine(" a mechatronics student approaches you.");
        CandyCane.DisplayBar(7);
        Console.WriteLine();

        // Mechatronics student speaking
        Console.WriteLine();
        CharactersManager.NPC_Color("matthew");
        Console.WriteLine(" Hi there! We're trying to print 3D pieces for our 🚗 car project, but they aren't durable enough.");
        Console.WriteLine("We're particularly interested in biodegradable materials to align with the 17 sustainable goals.");

        string userResponse;
        do
        {
            Console.WriteLine();
            Console.WriteLine("\nDo you have any ideas?");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("1.");
            Console.ResetColor();
            Console.WriteLine(" Yes, I might have some that come to mind.");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("2.");
            Console.ResetColor();
            Console.Write(" Ask ");
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" NOVA ");
            Console.ResetColor();
            Console.WriteLine(" (AI) for help.");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("3.");
            Console.ResetColor();
            Console.WriteLine(" No, sorry.");

            userResponse = Console.ReadLine()?.Trim() ?? "invalid";

            if (userResponse == "1")
            {
                // Choice "1"

                // Transition
                Transition transition = new Transition();
                transition.EmojiTransition("★", "🎄");  // Use custom emojis here 

                string innerResponse;
                do
                {
                    Console.WriteLine("\n🤔 A few options come to mind, but I'm undecisive between them. Hmmm...");
                    Console.WriteLine();

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("A.");
                    Console.ResetColor();
                    Console.WriteLine(" Epoxy Resin seems like a good recommendation.");

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("B.");
                    Console.ResetColor();
                    Console.WriteLine(" I could also say Carbon Fiber.");

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("C.");
                    Console.ResetColor();
                    Console.WriteLine(" Or use beeswax coating.");

                    innerResponse = Console.ReadLine()?.Trim()?.ToUpper() ?? "INVALID";

                    if (innerResponse == "A" || innerResponse == "B")
                    {
                        // Transition
                        Transition transitionAB = new Transition();
                        transitionAB.EmojiTransition("★", "🎄");  // Use custom emojis here 

                        // Matthew's response when choosing A or B
                        Console.WriteLine();
                        CharactersManager.NPC_Color("matthew");
                        Console.WriteLine(" That is not a biodegradable or eco-friendly material for the environment.");
                        Console.WriteLine("We can't use that in our semester project.");
                        Console.WriteLine();
                        Console.WriteLine("Are you sure you can't help us think of any other material? We really need to make this 3D pieces more durable.");

                        // Prompting the user again with updated options
                        string newResponse;
                        do
                        {
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine("What would you like to do?");
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write("1.");
                            Console.ResetColor();
                            Console.Write(" Ask ");
                            Console.BackgroundColor = ConsoleColor.DarkGreen;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(" NOVA ");
                            Console.ResetColor();
                            Console.WriteLine(" (AI) for help.");

                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write("2.");
                            Console.ResetColor();
                            Console.WriteLine(" No, sorry, I can't help.");

                            newResponse = Console.ReadLine()?.Trim() ?? "invalid";

                            if (newResponse == "1")
                            {
                                // Transition
                                Transition transitionAI = new Transition();
                                transitionAI.EmojiTransition("💭", "🤖");  // Use custom emojis here
                                Console.WriteLine(); 

                                // Call the hangman game
                                NovaAiHangman();
                            }
                            else if (newResponse == "2")
                            {
                                Transition transitionewResponse = new Transition();
                                transitionewResponse.EmojiTransition("★", "🎄");

                                Console.WriteLine();
                                CharactersManager.NPC_Color("matthew");
                                Console.WriteLine(" No worries, I'm sure we'll come up with something. Thank you for your time!");
                                Console.WriteLine();

                                CandyCane.DisplayCandyCaneTop();
                                CandyCane.DisplayBar(1);
                                Console.WriteLine();
                                CandyCane.DisplayBar(2);
                                Console.WriteLine("You wish Matthew a good day and then make your way out of the Mechatronics lab.");
                                CandyCane.DisplayBar(3);
                                Console.WriteLine();
                                Console.WriteLine();

                                CharactersManager.NPC_Color("nova");
                                Console.WriteLine(" Alright, Darwin, let's head back home and see if our efforts across multiple adventures have brought any meaningful improvements.");
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

                                Console.WriteLine(".");
                            }

                        } while (newResponse != "1" && newResponse != "2");

                    }
                    else if (innerResponse == "C")
                    {
                        // Transition
                        Transition transitionC = new Transition();
                        transitionC.EmojiTransition("★", "🎄");  // Use custom emojis here
                        
                        Console.WriteLine();
                        CharactersManager.NPC_Color("nova");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(" Correct choice: Beeswax!");
                        Console.ResetColor();

                        Console.WriteLine();
                        CandyCane.DisplayCandyCaneTop(); // Show the top part of the candy cane
                        CandyCane.DisplayBar(1);
                        Console.WriteLine();
                        CandyCane.DisplayBar(2);
                        Console.WriteLine("You inform Matthew and his team that beeswax is a reusable, sustainable way to strengthen their 3D-printed parts.");
                        CandyCane.DisplayBar(3);
                        Console.WriteLine();
                        CandyCane.DisplayBar(4);
                        Console.WriteLine("Beeswax forms a protective layer that guards against wear, prevents degradation, and even strengthens materials over time.");
                        CandyCane.DisplayBar(5);
                        Console.WriteLine();
                        CandyCane.DisplayBar(6);
                        Console.WriteLine("Making it ideal for improving the longevity and toughness of 3D-printed parts.");
                        CandyCane.DisplayBar(7);
                        Console.WriteLine();

                        Console.WriteLine();
                        CharactersManager.NPC_Color("matthew");
                        Console.WriteLine(" Thank you so much! That sounds fantastic and is exactly what we’re looking for.");
                        Console.WriteLine("We really appreciate your suggestion, and we’ll definitely be using it.");
                        Console.WriteLine();
                        Console.WriteLine();

                        bool isValid = false;  // Flag to control the loop
                        string? response;

                        while (!isValid)
                        {
                            Console.WriteLine("Answer Matthew: ");
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("_______________");
                            Console.ResetColor();
                            Console.WriteLine();

                            // Show the menu options
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write("1.");
                            Console.ResetColor();
                            Console.WriteLine(" Glad I could help, Merry Christmas! 🎄☃️");

                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write("2.");
                            Console.ResetColor();
                            Console.WriteLine(" Anytime, good luck with your project and Happy Holidays! 🍀😊☃️");

                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write("3.");
                            Console.ResetColor();
                            Console.WriteLine(" Of course, the more people share ideas, the better. Merry Christmas! ❄️🎅");

                            // Validate the user's input
                            response = Console.ReadLine();  // Allow the response to be nullable

                            // Check for null or invalid response
                            if (string.IsNullOrEmpty(response) || (response != "1" && response != "2" && response != "3"))
                            {
                                // Invalid input
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\nInvalid choice.");
                                Console.ResetColor();

                                Console.Write("Please select ");

                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.Write("1");
                                Console.ResetColor();

                                Console.Write(", ");

                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.Write("2");
                                Console.ResetColor();

                                Console.Write(", or ");

                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.Write("3");
                                Console.ResetColor();

                                Console.WriteLine(".");

                                Console.WriteLine();
                                Console.WriteLine();
                            }
                            else
                            {
                                Transition transitionMatt = new Transition();
                                transitionMatt.EmojiTransition("★", "🎄");

                                // Valid input, handle the response
                                isValid = true;  // Exit loop as we have a valid response

                                switch (response)
                                {
                                    case "1":
                                        Console.WriteLine();
                                        CharactersManager.NPC_Color("matthew");
                                        Console.WriteLine(" Thank you so much! Your help was exactly what we needed. Have a wonderful holiday season! 🎄🔔");
                                        Console.WriteLine("And please enjoy a freshly made cookie from our Christmas party today! 🍪");
                                        break;

                                    case "2":
                                        Console.WriteLine();
                                        CharactersManager.NPC_Color("matthew");
                                        Console.WriteLine(" Thank you! Your suggestion will have a positive impact 🦾. Have a wonderful holiday season! ‧₊˚🎄✩ ₊˚🦌⊹♡");
                                        break;

                                    case "3":
                                        Console.WriteLine();
                                        CharactersManager.NPC_Color("matthew");
                                        Console.WriteLine(" Absolutely! Collaborating makes everything better. Thanks again and happy holidays! 🎅☃️🔔");
                                        break;
                                }
                            }
                        }

                        Console.WriteLine();
                        CandyCane.DisplayCandyCaneTop(); // Show the top part of the candy cane
                        CandyCane.DisplayBar(1);
                        Console.WriteLine();
                        CandyCane.DisplayBar(2);
                        Console.WriteLine("Look at that—the other mechatronics students are gathering around the team you helped and are also considering using beeswax for their projects.");
                        CandyCane.DisplayBar(3);
                        Console.WriteLine();
                        CandyCane.DisplayBar(4);
                        Console.WriteLine("You've truly made a valuable contribution today, and you've inspired these young minds.");
                        CandyCane.DisplayBar(5);
                        Console.WriteLine();
                        CandyCane.DisplayBar(6);
                        Console.WriteLine("😊 You should be proud of yourself!");
                        CandyCane.DisplayBar(7);
                        Console.WriteLine();
                        Console.WriteLine();

                        // Points for Era3SDU
                        PointSystem.Instance.AddPoints(4, 8);;  // 8 points for Era3SDU (4)

                        // Display the points the player earned across all eras
                        PointSystem.Instance.DisplayPointsEarned();

                        // Nova Message
                        CharactersManager.NPC_Color("nova");
                        Console.WriteLine(" Alright, Darwin, let's head back home and see if our efforts across multiple adventures have brought any meaningful improvements.");
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
                        Console.Write("A");
                        Console.ResetColor();

                        Console.Write(", ");

                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("B");
                        Console.ResetColor();

                        Console.Write(", or ");

                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("C");
                        Console.ResetColor();

                        Console.WriteLine(".");
                    }

                } while (innerResponse != "C" && innerResponse != "A" && innerResponse != "B");

            }
            else if (userResponse == "2")
            {
                // Transition
                Transition transitionAI = new Transition();
                transitionAI.EmojiTransition("💭", "🤖");  // Use custom emojis here
                Console.WriteLine(); 

                // Call the hangman game
                NovaAiHangman();
            }
            else if (userResponse == "3")
            {
                Transition transition = new Transition();
                transition.EmojiTransition("★", "🎄");

                Console.WriteLine();
                CharactersManager.NPC_Color("matthew");
                Console.WriteLine(" No worries, I'm sure we'll come up with something. Have a great rest of your day!");
                Console.WriteLine();

                CandyCane.DisplayCandyCaneTop();
                CandyCane.DisplayBar(1);
                Console.WriteLine();
                CandyCane.DisplayBar(2);
                Console.WriteLine("You wish Matthew a good day and then make your way out of the Mechatronics lab.");
                CandyCane.DisplayBar(3);
                Console.WriteLine();
                Console.WriteLine();

                CharactersManager.NPC_Color("nova");
                Console.WriteLine(" Alright, Darwin, let's head back home and see if our efforts across multiple adventures have brought any meaningful improvements.");
                Console.WriteLine();
                Console.WriteLine();
            }
            else
            {
                // Invalid input for the outer menu
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nInvalid choice.");
                Console.ResetColor();

                Console.Write("Please select ");

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("1");
                Console.ResetColor();

                Console.Write(", ");

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("2");
                Console.ResetColor();

                Console.Write(", or ");

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("3");
                Console.ResetColor();

                Console.WriteLine(".");
            }

        } while (userResponse != "1" && userResponse != "2" && userResponse != "3");
    }
}