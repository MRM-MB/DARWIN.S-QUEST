/// <summary>
/// How to use it:
/// --------------

/// This point system assigns specific values to each era, allowing us to track which eras the player has completed.
/// You can check out how I implemented the PointSystem in the Era3SDU file, but here's the code you need to add.

/// CODE TO IMPLEMENT IN YOUR FILE:
    /*

    // Create a PointSystem instance in your main class -> Only write this one time
    PointSystem pointSystem = new PointSystem();

    // Points for the specific era 
    PointSystem.Instance.AddPoints(4, 8);  // 8 points for Era3SDU (4) -> (4, 8) are exmaple values that only work for my era, check the table for your exact numbers.

    // Display the points the player earned across all eras
    PointSystem.Instance.DisplayPointsEarned();

    */
    
/// The first number in the function above represents the era, while the second number indicates the points assigned to that era.

/// Here’s a table showing the corresponding values for each era and the points assigned to it.
/// WARNING: You can only use the PointSystem once per era, awarding the user all the points assigned for that era in a single quiz or question to accurately track completion.

/// TABLE - Assign Point Values:
    /*
    Era1 (1): 1 point
    Era2Bees (2): 2 points
    Era2Corals (3): 4 points
    Era3SDU (4): 8 points
    Era3Cement (5): 16 points
    */
/// </summary>

public class PointSystem
{
    /*
    PointSystem into a singleton: 
    
    A singleton makes sure that only one instance of the PointSystem class exists. 
    Accessible from any file of Darwin's Quest without needing to explicitly pass it around.
    */

    // Declare instance as nullable
    private static PointSystem? instance = null;

    public static PointSystem Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new PointSystem();
            }
            return instance;
        }
    }

    // Point values for each era
    private int era1Points;
    private int era2BessPoints;
    private int era2CoralsPoints;
    private int era3SDUPoints;
    private int era3CementPoints;

    // Constructor to initialize points to 0
    public PointSystem()
    {
        era1Points = 0;
        era2BessPoints = 0;
        era2CoralsPoints = 0;
        era3SDUPoints = 0;
        era3CementPoints = 0;
    }

    // Add points to a specific era
    public void AddPoints(int era, int points)
    {
        switch (era)
        {
            case 1:
                era1Points += points;
                break;
            case 2:
                era2BessPoints += points;
                break;
            case 3:
                era2CoralsPoints += points;
                break;
            case 4:
                era3SDUPoints += points;
                break;
            case 5:
                era3CementPoints += points;
                break;
            default:
                Console.WriteLine("Invalid era.");
                break;
        }
    }

    // Total score
    public int GetTotalScore()
    {
        return era1Points + era2BessPoints + era2CoralsPoints + era3SDUPoints + era3CementPoints;
    }

    // Method to check which eras were cleared
    public bool IsEraCleared(int era)
    {
        switch (era)
        {
            case 1: return era1Points > 0;
            case 2: return era2BessPoints > 0;
            case 3: return era2CoralsPoints > 0;
            case 4: return era3SDUPoints > 0;
            case 5: return era3CementPoints > 0;
            default: return false;
        }
    }

    // Status of each era
    public void DisplayPointsEarned()
    {
        // Display header
        Console.WriteLine();
        Console.WriteLine("   ~ Points Earned ~   ");
        Console.WriteLine("=======================");

        // Display Era 1 points
        if (era1Points != 0)
            Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Era 1:   {"".PadRight(4)} {era1Points} point");
        Console.ResetColor();

        // Display Era 2 points as a group
        Console.WriteLine();
        Console.WriteLine("Era 2:");
        if (era2BessPoints != 0)
            Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"   {"Bees:".PadRight(10)} {era2BessPoints} points");
        Console.ResetColor();

        if (era2CoralsPoints != 0)
            Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"   {"Corals:".PadRight(10)} {era2CoralsPoints} points");
        Console.ResetColor();

        // Display Era 3 points as a group
        Console.WriteLine();
        Console.WriteLine("Era 3:");
        if (era3SDUPoints != 0)
            Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"   {"SDU:".PadRight(10)} {era3SDUPoints} points");
        Console.ResetColor();

        if (era3CementPoints != 0)
            Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"   {"Cement:".PadRight(10)} {era3CementPoints} points");
        Console.ResetColor();

        // Display footer
        Console.WriteLine("=======================");

        // Total score
        int totalScore = GetTotalScore();
        if (totalScore != 0)
            Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($" Total Score: {totalScore} points");
        Console.ResetColor();

        Console.WriteLine();
    }
}