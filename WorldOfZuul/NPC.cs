using System;

// A class for adding characters along with their corresponding format and color.

// How to call it? -> EXAMPLE for NOVA: CharactersManager.NPC_Color("nova");
public class CharactersManager
{
    public static void NPC_Color(string npcName)
    {
        // Match NPC name to appropriate color and text
        (ConsoleColor Foreground, ConsoleColor Background, string Text) npcDetails = npcName.ToLower() switch
        {
            // Please add your character and the corresponding era.

            // ==============================
            //           ALL ERAS    
            // ==============================
            "nova" => // AI companion throughout the game
                (ConsoleColor.White, ConsoleColor.DarkGreen, " NOVA: "),

            // ==============================
            //          ERA 2 BEES   
            // ==============================
            "mathmany" => // Underground Leader - Era2Bees
                (ConsoleColor.White, ConsoleColor.Blue, " Mathmany: "),

            "donald" => // CEO of CSA-(C)reate (S)olar (A)mps - Era2Bees
            (ConsoleColor.White, ConsoleColor.Red, " Donald J.: "),

            "timmy" => // KID present in the EPIC debate with the evil Donald J.
            (ConsoleColor.Black, ConsoleColor.DarkYellow, " Little Timmy Tim: "),

            // ==============================
            //           ERA 3 SDU    
            // ==============================
            "matthew" => // Mechatronic Student - Era3SDU
                (ConsoleColor.White, ConsoleColor.DarkMagenta, " Matthew: "),

            // ==============================
            //          ERA 3 CEMENT   
            // ==============================
            "prof" => // SDU Professor encountered in the fog - Era3Cement
                (ConsoleColor.White, ConsoleColor.DarkBlue, " Dr. Maximus Kaos: "),

            "traincond" => // Train Conductor that explains what is happening - Era3Cement
                (ConsoleColor.White, ConsoleColor.DarkRed, " Train Conductor: "),

            "worker1" => // Railway Track Worker 1 - Era3Cement
                (ConsoleColor.White, ConsoleColor.DarkCyan, " Asger: "),

            "worker2" => // Railway Track Worker 2 - Era3Cement
                (ConsoleColor.Black, ConsoleColor.DarkYellow, " Christian: "),

            "fisherman" => //A fisherman next to ocean - Era2Corals
                (ConsoleColor.White, ConsoleColor.Magenta," Fisherman: "),

            // --⬆️--⬆️--⬆️--- Add more NPCs here with additional cases ---⬆️--⬆️--⬆️--
            
            _ => (ConsoleColor.White, ConsoleColor.DarkCyan, " UNKNOWN: ") // Default case
        };

        // Apply the console colors and write the NPC label
        Console.ForegroundColor = npcDetails.Foreground;
        Console.BackgroundColor = npcDetails.Background;
        Console.Write(npcDetails.Text);

        // Reset colors after writing
        Console.ResetColor();
    }
}
