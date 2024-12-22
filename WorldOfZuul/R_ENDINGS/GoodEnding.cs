using System;
using NAudio.Wave;

public class GoodEnding
{
    private void PrintTreeArt()
    {
        
    string[] TreeArt = {
        @"      ;   :   ;                                                       _{\\ _{\\{\\/}/}/}__              ",
        @"   .   \_,!,_/   ,                                                   {/{/\\}{/{/\\}(\\}{/\\} _          ",
        @"    `.,'     `.,'                                                   {/{/\\}{/{/\\}(_)/}{/{/\\}  _       ",
        @"     /         \                                                 {\\{/(\\}\\}{/{/\\}\\}{/){/\\}\\} }    ",
        @"~ -- :          : -- ~                                             {/{/(_)/}{\\{/)\\}{\\(_){/}/}/}/}     ",
        @"     \         /                                              _{\\{/{/{\\{/{/(_) /}/}/}{\\(/}/}/}      ",
        @"    ,'`._   _.'`.                                             {/{/{\\{\\{\\(/}{\\{\\/}/}{\\}(_){\\/}\\} ",
        @"   '   / `!` \    `                                           _{\\{/{\\{/(_)/}/}{/{/{/\\}\\})\\}{/\\}   ",
        @"      ;   :   ;                                              {/{/{\\{\\(/}{/{\\{\\{\\/})/}{\\(_)/}/}\\} ",
        @"                                                              {\\{\\/}(_){\\{\\{\\/}/}(_){\\/}{\\/}/})/}",
        @"                                                               {/{\\{\\/}{/{\\{\\{\\/}/}{\\{\\/}/}\\}(_)",
        @"                                                              {/{\\{\\/}{/){\\{\\{\\/}/}{\\{(/}/}\\}/}  ",
        @"                                                               {/{\\{\\/}(_){\\{\\{(/}/}{\\(_)/}/}\\}   ",
        @"                                                                 {/({/{\\{/{\\{\\/}(_){\\/}/}\\}/}(\\}  ",
        @"                                                                  (_){/{\\/}{\\{\\/}/}{\\{\\)/}/}(_)    ",
        @"                                                                    {/{/{\\{\\/}{/{\\{\\{(_)/}          ", 
        @"                                                                     {/{\\{\\{\\/}/}{\\{\\\\}/}         ",
        @"               ,@@@@@@@,                                               {){/ {\\/}{\\/} \\}\\}                           ,@@@@@@@,                             ",
        @"       ,,,.   ,@@@@@@/@@,  .@@8888@.                                        \\.-'.-/                            ,,,.   ,@@@@@@/@@,  .@@8888@.                 ",
        @"    ,&%%&%&&%,@@@@@/@@@@@@,8888\\88/8@                             __...--- |'-.-'| --...__                  ,&%%&%&&%,@@@@@/@@@@@@,8888\\88/8@               ",
        @"   ,%&\\%&&%&&%,@@@\\@@@/@@@88\\88888/88'           - -     _...--\   .-'   |'-.-'|  ' -.  \ \ --..__       ,%&\\%&&%&&%,@@@\\@@@/@@@88\\88888/88'            ",
        @"   %&&%&%&/%&&%@@\\@@/ /@@@88888\\88888'                  -\       . .      |. -._|    . .                  %&&%&%&/%&&%@@\\@@/ /@@@88888\\88888              ",
        @"   %&&%/ %&%%&&@@\\ V /@@' `88\\8 `/88'                .  .  '-  '    .--'  | '-.'|    .  '  . '            %&&%/ %&%%&&@@\\ V /@@' `88\\8 `/88'              ",
        @"  `&%\\ ` /%&'    |.|        \\ '|8'            .                  ' ..     |'-_.-|                        `&%\\ ` /%&'    |.|        \\ '|8'                 ",
        @"       |o|        | |         | |                     .    .  '  .       _.-|-._ -|-._  .  '  .                 |o|        | |         | |                    ",
        @"       |.|        | |         | |          .                           .'   |'- .-|   '.                        |.|        | |         | |          .         ",
        @"      \\\\/ ._\\//_/__/  ,\\_//__\\\\/.  \\_//__/_         ..-'   ' .  '.   `-._.-'   .'  '  - .               \\\\/ ._\\//_/__/  ,\\_//__\\\\/.  \\_//__/_   ",
        @"                                                            .-' '        '-._______.-'     '  .                                                               ",
        @"  ./              ,    ..-                     ,                 .      ,                                  ./              ,    ..-                     ,     ",
        @"                                  |/     ' ..                .       .         .    ' '-.                                                  |/     ' ..        ",
        @"         //     .--'         ,                     .        ╔═══════════════════════════╗       --.               //     .--'         ,                     . ",
        @"                .      .-                                   ║          This is          ║           -                    .      .-                            ",
        @"  ' ..                          ' ..       \\   .--'        ║     THE TREE OF WISDOM    ║     |/           ' ..                          ' ..       \\   .--' ",
        @"         .       ..-'        ,                              ║     and you created it!   ║                         .       ..-'        ,                       ",
        @"  .--'         .                     .-       ' ..          ╚═══════════════════════════╝     ' ..         .--'         .                     .-              "
    };

    foreach (var line in TreeArt)
        {
            for (int i = 0; i < line.Length; i++)
            {
                char currentChar = line[i];

                if (currentChar == '}' || currentChar == '{' || currentChar == '(' || currentChar == ')' || currentChar == '@' || currentChar == '_')
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;  // Leaves
                }
                else if (currentChar == '/' || currentChar == '8' || currentChar == '%' || currentChar == '&' || currentChar == '\\')
                {
                    Console.ForegroundColor = ConsoleColor.Green; // Small Leaves
                }
                else if (currentChar == '.' || currentChar == ',')
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray; // Rocks or imperfections
                }
                else if (currentChar == ':' || currentChar == ';' || currentChar == '~')
                {
                    Console.ForegroundColor = ConsoleColor.Yellow; // sun details
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
    public void PlayGoodEnding()
    {
        //  ------------- Part to modify ------------------
        PrintTreeArt();
        Console.WriteLine();
        Console.WriteLine();
        using (var audioFile = new AudioFileReader("Music/birds.mp3"))
        using (var sound = new WaveOutEvent())
        {
            sound.Init(audioFile);
            sound.Play();

            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("\n\nPRESS ENTER");
            Console.ResetColor();
            Console.WriteLine(" to continue");
            Console.ReadLine();

            sound.Stop();
        }
        Console.ResetColor();
        Console.Clear();
        Console.WriteLine();
        CharactersManager.NPC_Color("nova");
        Console.WriteLine(" In Darwin's Quest, every choice you made was like planting a seed of wisdom.");
        Console.WriteLine("Together, these seeds have grown into the marvelous tree you saw before, a reminder that knowledge and action are the roots of a sustainable future.");
        Console.ResetColor();
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("\n\nPRESS ENTER");
        Console.ResetColor();
        Console.WriteLine(" to continue");
        Console.ReadLine(); // Wait for a ENTER press
        Console.Clear();
        //  ----------------------------------------------

        // Display the credits - No need to modify -> It only calls the code in Credits.cs
        Console.WriteLine();
        
        Credits credits = new Credits();
        credits.PrintCredits();
    }
}