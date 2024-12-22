using System;
using System.Threading; // For adding delays between animation frames
using NAudio.Wave; // -> dotnet add package NAudio

public class Portal
{
    private int currentEra;

    // Track if ...
    private bool visitedBees;   // the player has visited the Bees room
    private bool visitedCorals; // the player has visited the Corals room
    private bool firstTeleport; // it's the first teleport for the player

    public string CurrentRoomName { get; private set; }

    // Constructor to initialize the starting room as Homeworld
    public Portal()
    {
        currentEra = 0; // Start at Homeworld (Era 0)
        CurrentRoomName = "Homeworld"; // Initial room is Homeworld
        visitedBees = false;
        visitedCorals = false;
        firstTeleport = true; // Mark that the player has not teleported yet

        Console.Clear();
        PrintTeleportMessage($"You are currently in {CurrentRoomName}.", false); // No animation on start
    }

    // Method to handle teleportation and move to the next era
    public void Teleport()
    {
        if (firstTeleport)
        {
            // If this is the player's first teleport, send them to Era 1
            currentEra = 1;
            CurrentRoomName = "Era1";
            PrintTeleportMessage($"Teleporting!!!", true); // Show animation

            // Execute the logic for Era 1 - Klara's file
            Era1 era1 = new Era1();
            era1.Enter();
            PrintTeleportMessage($"You have teleported to {CurrentRoomName}!", false); // Show arrival text

            // Mark that the player has used teleport for the first time
            firstTeleport = false;
            return;
        }

        // New check to move to "The End" after Era3Cement
        if (currentEra == 4)
        {
            currentEra++; // Move to final era, The End
            CurrentRoomName = "The End";
            PrintEndMessage("You have reached the end of your journey. Thank you for playing Darwin's Quest!");

            // Final interaction in The End
            return;
        }

        // Era 2 (Bees and Corals)
        if (currentEra == 2)
        {
            if (!visitedBees && !visitedCorals)
            {
                // Prompt the player for choice between Bees and Corals
                Console.WriteLine();
                Console.Write("You are in Era 2! Choose your path (");

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("1");
                Console.ResetColor();

                Console.Write(" or ");

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("2");
                Console.ResetColor();

                Console.WriteLine("):");

                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("1. "); // Print "1." in cyan
                Console.ResetColor();
                Console.WriteLine("Save the Bees");
                
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("2. "); // Print "2." in cyan
                Console.ResetColor();
                Console.WriteLine("Save the Coral Reefs");

                Console.Write("> ");
                string? choice = Console.ReadLine();
                Console.WriteLine();

                if (choice == "1")
                {
                    CurrentRoomName = "Era2Bees";
                    visitedBees = true;

                    PrintTeleportMessage("Teleporting to the Bees!", true); // Show only animation

                    // Execute Era2Bees logic - Lukas' file
                    Era2Bees bees = new Era2Bees();
                    bees.Enter();
                    PrintTeleportMessage($"You have teleported to {CurrentRoomName} (Era {currentEra})!", false); // Show arrival text
                }
                else if (choice == "2")
                {
                    CurrentRoomName = "Era2Corals";
                    visitedCorals = true;

                    PrintTeleportMessage("Teleporting to the Coral Reefs!", true); // Show only animation

                    // Execute Era2Corals logic - Arda's file
                    Era2Corals corals = new Era2Corals();
                    corals.Enter();
                    PrintTeleportMessage($"You have teleported to {CurrentRoomName} (Era {currentEra})!", false); // Show arrival text

                }
                else
                {
                    // Print "Invalid choice" in red
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid choice."); 
                    Console.ResetColor();

                    // Print "Staying in Era 2 Main Room." in green
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Staying in Era 2 Main Room.");
                    Console.ResetColor();

                    CurrentRoomName = "Era2";
                }
            }
            else if (visitedBees && !visitedCorals)
            {
                // If Bees were visited first, teleport to Corals next
                CurrentRoomName = "Era2Corals";
                visitedCorals = true;
                PrintTeleportMessage("Teleporting to the Coral Reefs!", true); // Show only animation

                // Execute Era2Corals logic - Arda's file
                Era2Corals corals = new Era2Corals();
                corals.Enter();
                PrintTeleportMessage($"You have teleported to {CurrentRoomName} (Era {currentEra})!", false); // Show arrival text
            }
            else if (!visitedBees && visitedCorals)
            {
                // If Corals were visited first, teleport to Bees next
                CurrentRoomName = "Era2Bees";
                visitedBees = true;
                PrintTeleportMessage("Teleporting to Save the Bees!", true); // Show only animation

                // Execute Era2Bees logic - Lukas' file
                Era2Bees bees = new Era2Bees();
                bees.Enter();
                PrintTeleportMessage($"You have teleported to {CurrentRoomName} (Era {currentEra})!", false); // Show arrival text
            }
            else if (visitedBees && visitedCorals)
            {
                // After visiting both Bees and Corals, go to Era 3 SDU
                currentEra = 3;
                CurrentRoomName = "Era3SDU";
                PrintTeleportMessage($"You have teleported to {CurrentRoomName} (Era {currentEra})!", true); // Show only animation

                // Execute Era3SDU logic - Manish's file
                Era3SDU era3sdu = new Era3SDU();
                era3sdu.Enter();
                //PrintTeleportMessage($"You have teleported to {CurrentRoomName} (Era {currentEra})!", false); // Show arrival text
            }
        }
        else
        {
            // Linear era progression
            currentEra++; // Move to the next era

            switch (currentEra)
            {
                case 1:
                    CurrentRoomName = "Era1";
                    break;
                case 2:
                    CurrentRoomName = "Era2";
                    PrintTeleportMessage($"Teleporting!!!", true); // Show only animation
                    
                    // Execute Era2 logic
                    Era2 era2 = new Era2();
                    era2.Enter();
                    PrintTeleportMessage($"You have teleported to {CurrentRoomName}!", false); // Show arrival text
                    break;
                case 3:
                    CurrentRoomName = "Era3SDU";
                    break;
                case 4:
                    CurrentRoomName = "The End"; // End after Cement era
                    PrintTeleportMessage($"Teleporting!!!", true); // Show only animation
                    
                    // Execute Era3Cement after Era3SDU
                    Era3Cement cement = new Era3Cement();
                    cement.Enter();
                    //PrintTeleportMessage($"You have teleported to {CurrentRoomName} (Era 3)!", false); // Show arrival text
                    break;
                default:
                    PrintEndMessage("Teleportation is now offline — this is the end of your journey. Thank you for playing Darwin's Quest!");
                    return;
            }
        }
    }

    // Method to print the teleportation message in green with space above and below
    private void PrintTeleportMessage(string message, bool showAnimation)
    {
        if (showAnimation)
        {
            TeleportAnimation();
        }

        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(message);
        Console.ResetColor();
        Console.WriteLine();
    }

    // Teleportation ASCII animation
    private void TeleportAnimation()
    {
        using (var audioFile = new AudioFileReader("Music/teleport.mp3"))
        using (var music = new WaveOutEvent())
        {
            music.Init(audioFile);
            music.Play();
        
        string[] frames = new string[]
        {
            "Teleporting...     (   )    ",
            "Teleporting...    ((   ))   ",
            "Teleporting...   (((   )))  ",
            "Teleporting...  (((     ))) ",
            "Teleporting... ((((     ))))",
            "Teleporting...  (((     ))) ",
            "Teleporting...   (((   )))  ",
            "Teleporting...    ((   ))   ",
            "Teleporting...     (   )    "
        };

        int[] delays = new int[] { 350, 300, 250, 200, 150, 200, 250, 300, 350 };

        for (int i = 0; i < frames.Length; i++)
        {
            Console.SetCursorPosition(0, Console.CursorTop - 1); // Avoid flicker
            Console.Write(new string(' ', Console.WindowWidth)); // Clear line
            Console.SetCursorPosition(0, Console.CursorTop);

            // Set color based on the animation stage
            if (i < frames.Length / 2)
                Console.ForegroundColor = ConsoleColor.Yellow; // First color
            else
                Console.ForegroundColor = ConsoleColor.DarkYellow; // Color Change

            Console.WriteLine(frames[i]);
            Console.ResetColor();
            Thread.Sleep(delays[i]); // Slight delay
        }
        Console.WriteLine();
        music.Stop();
        }
    }

    // Method to print the end message in red with space above and below
    private void PrintEndMessage(string message)
    {
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ResetColor();
        Console.WriteLine();
    }

    // Getter for the current era
    public int GetCurrentEra()
    {
        return currentEra;
    }
}