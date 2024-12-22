using System;
using System.Threading;

/// <summary>
/// How to use it:
/// --------------

/// This transition utilizes emojis and prints a row of them in an alternating pattern.

/// CODE TO IMPLEMENT IN YOUR FILE:
    /*
    
    Transition transition = new Transition();

    transition.EmojiTransition("★", "🎄");  // Use custom emojis here
    
    */

/// I primarily implemented this in my ERA3SDU file, so feel free to check how I called and used the emojis.
/// You can use this class to create your own emoji transitions in your eras. 
/// I mainly use it to separate sections and paragraphs when the user provides input, enhancing readability.

/// If you have any questions about how to use it, please let me know!
/// </summary>

public class Transition
{
    public void EmojiTransition(string emoji1, string emoji2)
    {
        Console.WriteLine();
        int delay = 100; // Set the delay time between emoji prints

        for (int i = 0; i < 12; i++) // Prints out 12 emojis in total, 6 of each
        {
            if (i % 2 == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write($"{emoji1} "); // Print the first emoji
            }
            else
            {
                Console.Write($"{emoji2} "); // Print the second emoji
            }
            Console.ResetColor();
            Thread.Sleep(delay);
        }
        Console.WriteLine(); // Move to the next line after the transition
    }
}
