using System;
using NAudio.Wave;

public class BadEnding
{
    private void PrintTreeArt()
    {
        
    string[] TreeArt = {
        @".--.                                                                            +                                                                            ",
        @"    )    +                   +                +                                                                            +                         +       ",
        @"    -.--.        +                                               +        +          +      +         +                                                      ",
        @"         )                                                +            _        +                    +              +                      +                 ",
        @"       _'-. _             +         +      +           +              /;-._,-.____        ,-----.__                              +                           ",
        @"  _        ) ).-.                                               +    (_:#::_.:::. `-._   /:, /-._, `._,                                                      ",
        @" {              )-.                                  +                 \\   _|`'=:_::.`.);  \\ __/ /                   +                   +                 ",
        @"___________________)     +     +         +                                 ,    `./  \\:. `.   )==-'  +                         +                  +         ",
        @"                 +                                       +      ., ,-=-.  ,\\, +#./`   \\:.  / /           +                                                 ",
        @"    +                          +                     +           \\/:/`-' , ,\\ '` ` `   ): , /_  -o                      +                                  ",
        @"                       +                                    +    /:+- - + +- : :- + + -:'  /(o-) \\)     +                               +                   ",
        @"         +                        +         +          +      ,=':  \\   ` `/` ' , , ,:' `'--'.--'---._/`7        +                                +         ",
        @"                    +                                        (    \\: \\,-._` ` + '\\, ,'   _,--._,---':.__/                                                 ",
        @"                                       +                           \\:  `  X` _| _,\\/'   .-'                           +          +           +             ",
        @"                   +        +                        +               ':._:`\\____  /:'  /      +               +                                         +   ", 
        @"    +                                                                   \\::.  :\\/:'  /              +                             +                        ",
        @"               ,@@@@@@@,                      +        +                 `.:.  /:'  };'    +                       +   ,@@@@@@@,                             ",
        @"       ,,,.   ,@@@@@@/@@,  .@@8888@.                           +           ):_(:;   |           +              ,,,.   ,@@@@@@/@@,  .@@8888@.          +      ",
        @"    ,&%%&%&&%,@@@@@/@@@@@@,8888\\88/8@                                    /:. _/ ,  |                       ,&%%&%&&%,@@@@@/@@@@@@,8888\\88/8@               ",
        @"   ,%&\\%&&%&&%,@@@\\@@@/@@@88\\88888/88'           +                  + (|::.     ,`                  +   ,%&\\%&&%&&%,@@@\\@@@/@@@88\\88888/88'            ",
        @"   %&&%&%&/%&&%@@\\@@/ /@@@88888\\88888'                   +              |::.    {\\       +              %&&%&%&/%&&%@@\\@@/ /@@@88888\\88888'     +       ",
        @"   %&&%/ %&%%&&@@\\ V /@@' `88\\8 `/88'                                   |::.\\ `. !                      %&&%/ %&%%&&@@\\ V /@@' `88\\8 `/88'              ",
        @"  `&%\\ ` /%&'    |.|        \\ '|8'    +       +                         |:::(\\   |              +      `&%\\ ` /%&'    |.|        \\ '|8'                 ",
        @"       |o|        | |    +    | |                        +        O       |:::/{ }  |     +            (o      |o|        | |     +   | |        +       +   ",
        @" +     |.|        | |         | |          +                      )  ___/#\\::`/ (O '==._____   O, (O  /`      |.|  +     | |         | |          .         ",
        @"      \\\\/ ._\\//_/__/  ,\\_//__\\\\/.  \\_//__/_          ~~~w/w~'~~,\\` `:/,-(~`'~~~~~~~~'~o~\\~/~w|/~     \\\\/ ._\\//_/__/  ,\\_//__\\\\/.  \\_//__/_   ",
        @"                                                          ~~~~~~~~~~~~~~~~~~~~~~~\\W~~~~~~~~~~~~\\|/~~                                                       ",
        @"  ./              ,    ..-                     ,      .         .      ~,                                 ./              ,    ..-                     ,     ",
        @"                                  |/     ' ..               .       .   -     .    ' '-.                                                  |/     ' ..        ",
        @"         //     .--'         ,                     .        ╔═══════════════════════════╗       --.               //     .--'         ,                    . ",
        @"                .      .-                                   ║        This is            ║           -                    .      .-                           ",
        @"  ' ..                          ' ..       \\   .--'        ║     THE TREE OF WISDOM    ║     |/           ' ..                          ' ..      \\   .--' ",
        @"         .       ..-'        ,                              ║    and you created it!    ║                         .       ..-'        ,                      ",
        @"  .--'         .                     .-       ' ..          ╚═══════════════════════════╝     ' ..         .--'         .                     .-             "
    };

    foreach (var line in TreeArt)
        {
            for (int i = 0; i < line.Length; i++)
            {
                char currentChar = line[i];

                if (currentChar == '~' || currentChar == '@' || currentChar == '&')
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;  // Leaves and grass
                }
                else if (currentChar == '8' || currentChar == '%')
                {
                    Console.ForegroundColor = ConsoleColor.Green; // Small Leaves and grass
                }
                else if (currentChar == '.')
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray; // Rocks or imperfections
                }
                else if (currentChar == ')')
                {
                    Console.ForegroundColor = ConsoleColor.White; // Snow and cloud
                }
                else if (currentChar == '/' || currentChar == '}' || currentChar == '{')
                {
                    Console.ForegroundColor = ConsoleColor.Gray; // Dry branches
                }
                else if (currentChar == ',' || currentChar == '+' || currentChar == '(')
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed; // Dry branches
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

    public void PlayBadEnding()
    {
        //  ------------- Part to modify ------------------
        PrintTreeArt();
        Console.WriteLine();
        Console.WriteLine();
        using (var audioFile = new AudioFileReader("Music/Forest_Fire.mp3"))
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
        Console.WriteLine("Together, these seeds have grown into the tree you saw before, a reminder that knowledge and action are the roots of a sustainable future.");
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
        Console.WriteLine(" You've faced some challenges, but every setback is an opportunity to learn.");
        Console.WriteLine("With a bit more effort, you can change your approach and make the world even greener.");
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("\n\nPRESS ANY KEY");
        Console.ResetColor();
        Console.WriteLine(" to continue...");
        Console.ReadKey(); // Wait for a key press
        Console.WriteLine();
        Console.WriteLine();
        Console.Clear();
        //  ----------------------------------------------

        // Display the credits - No need to modify -> It only calls the code in Credits.cs
        Console.WriteLine();
        
        Credits credits = new Credits();
        credits.PrintCredits();
    }
}