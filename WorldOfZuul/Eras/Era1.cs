using System;
using System.Collections;
using System.ComponentModel.Design.Serialization;
using MapAndCenter;
using NAudio.Wave;

public class Era1
{
    // Method that prints the welcome message for Era 1 - Klara

    public static void DrawSunset()
    {

        string[] sunset = {
                        "                +",
                        "                ++",
                        "                ++",
                        "               +++",
                        "          +++  +++",
                        "          +++  +++",
                        "          +++  +++",
                        "          +++  +++                   ))))))))) ",
                        "          ++++++++                )))))))))))))))",
                        "          ++++++++  ++          ))))))))))))))))))))",
                        "              ++++++++         )))))))))))))))))))))",
                        "              ++++++++         )))))))))))))))))))))",
                        "              +++++            )))))))))))))))))))))",
                        "--------  ----+++++-------                  ------- -----------------",
                        "       ----   +++++       ----------------   ---",
                        "              +++++   ---                               ---",
                        "    ----      +++++       -            -----|",
                        "        --------                             -----"
                    };

        int consoleWidth = Console.WindowWidth;

        foreach (var line in sunset)
        {
            for (int i = 0; i < line.Length; i++)
            {
                char currentChar = line[i];

                if (currentChar == '+')
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                }
                else if (currentChar == ')')
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                else if (currentChar == '-')
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
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
            // Play sound
            using (var audioFile = new AudioFileReader("Music/sand.mp3"))
            using (var sound = new WaveOutEvent())
            {
                sound.Init(audioFile);
                sound.Play();

                Console.SetCursorPosition(0, Console.CursorTop - 1);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("\nPRESS ENTER");
                Console.ResetColor();
                Console.WriteLine(" to continue");
                Console.ReadLine();

                sound.Stop();
        }
    }
    
    public static void DrawTextDivider()
    {
        
        string[] sunset = {
                        " ",
                        "︶ ⊹ ︶ ︶ ☀️ ︶ ︶ ⊹ ︶",
                        " "
                    };

        int consoleWidth = Console.WindowWidth;

        foreach (var line in sunset)
        {
            for (int i = 0; i < line.Length; i++)
            {
                char currentChar = line[i];

                if (currentChar == '︶')
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
                else if (currentChar == '⊹')
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
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

    public static void PanelSearching()
    {
        
   string commandE1 = "";
//searching for parts of the solar panels
   string[] lines = {
        "You enter a barren wasteland, not so different from the one you've lived in up until now.",
        "You feel slightly disorientated, but then you remember..."
        };
        Array.ForEach(lines, Console.WriteLine);
   lines = new string[] {
        "That you've got a mission you need to complete.",
        "What you see now, is a desolate desert, but soon..."
        };
        Array.ForEach(lines, Console.WriteLine);

        Console.WriteLine("You will restore the world through the power of nature.");
        Console.Write("But first, it would be a good idea to ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("LOOK");
        Console.ResetColor();
        Console.WriteLine(" around");
        Console.WriteLine("");

        DrawTextDivider();

        commandE1 = Console.ReadLine()!.Trim().ToLower();

   while (commandE1.ToLower() != "look"){
        lines = new string[] {
                "Right now I should LOOK for parts of the solar panels."
        };
        Array.ForEach(lines, Console.WriteLine);
        commandE1 = Console.ReadLine()!.Trim().ToLower();
        DrawTextDivider();
   }
 lines = new string[] {"You look around and see some solar panels.",
                                          " "};       
        Array.ForEach(lines, Console.WriteLine);
 lines = new string[] {
        "You approach the solar panels, this technology feeling so distant to you.",
        "Remembering how your society chose to advance, leaving more sustainable energy options behind...",
        "Now knowing how the world was destroyed, it pained you.",
        " "};
        Array.ForEach(lines, Console.WriteLine);
        Console.Write("Perhaps it would be good to ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("LOOK");
        Console.ResetColor();
        Console.WriteLine(" around some more.");
        Console.WriteLine("");
        commandE1 = Console.ReadLine()!.Trim().ToLower();

  while (commandE1.ToLower() != "look"){
        Console.Write("Right now I should ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("LOOK");
        Console.ResetColor();
        Console.WriteLine(" for parts of the solar panels.");
        Console.WriteLine("");
        commandE1 = Console.ReadLine()!.Trim().ToLower();
        DrawTextDivider();
   }

   ///now using the command investigation to learn more about them
 lines = new string[] {
        "You look around and see some a few more parts for the solar panels.",
                " ",
        "But how do I piece them together...?"
        };
        Console.WriteLine();
        Array.ForEach(lines, Console.WriteLine);
        DrawTextDivider();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("\nPRESS ENTER");
        Console.ResetColor();
        Console.WriteLine(" to continue");
        Console.ReadLine();

        Transition transition = new Transition();
        transition.EmojiTransition("☀️", "⚡"); 
///INVESTIGATE part of this part
        CharactersManager.NPC_Color("nova"); 
        Console.Write(" Darwin! Try ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("INVESTIGATING");
        Console.ResetColor();
        Console.WriteLine(" what you found!");
        Console.WriteLine("");
        CharactersManager.NPC_Color("nova");
        Console.WriteLine(" We might learn more about how the panels function.");

        DrawTextDivider();


    while (commandE1.ToLower() != "investigate") {
        Console.Write("I think I should ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("INVESTIGATE");
        Console.ResetColor();
        Console.WriteLine(" right now...");
        Console.WriteLine("");
        commandE1 = Console.ReadLine()!.Trim().ToLower();
    }

    DrawTextDivider();
        
    lines = new string[] {
                        "Aha! Looking at the photovoltaic cells made you remember, that although they are well constructed,",
                        "they should be protected from SOLAR STORMS.",
                        "",
                        "Solar radiation storms occur when a large-scale magnetic eruption, often causing a coronal mass ejection and associated solar flare,", 
                        "accelerates charged particles in the solar atmosphere to very high velocities."
                        };
                         Array.ForEach(lines, Console.WriteLine);
                          lines = new string[] {
                        "",
                        "I think there's still more to investigate."
                        };
                         Array.ForEach(lines, Console.WriteLine);
                         commandE1 = Console.ReadLine()!.Trim().ToLower();

         DrawTextDivider();


    while (commandE1.ToLower() != "investigate") {
        Console.Write("I think I should ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("INVESTIGATE");
        Console.ResetColor();
        Console.WriteLine(" right now...");
        Console.WriteLine("");
        commandE1 = Console.ReadLine()!.Trim().ToLower();
    }
    lines = new string[] {
                        "Thinking about how the energy is from the Sun, you wonder: where does this energy come from?",
                        "Energy in the Sun is caused by NUCLEAR FUSION! And that is happening here too.",
                        "",
                        "Nuclear fusion is the process by which two light atomic nuclei combine to form a single heavier one while releasing massive amounts of energy."
                        };
                        Array.ForEach(lines, Console.WriteLine);

                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("\nPRESS ENTER");
                        Console.ResetColor();
                        Console.WriteLine(" to continue");
                        Console.ReadLine();
                          lines = new string[] {
                        "   ",
                        "I think that's all I can remember for now... But it isn't quite it yet. There must be more I can do."
                        };
                        Array.ForEach(lines, Console.WriteLine);
                        
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("\nPRESS ENTER");
                        Console.ResetColor();
                        Console.WriteLine(" to continue");
                        Console.ReadLine();
                        
    DrawTextDivider();                     
}
    
    public static void DrawPanel()
    {
        string[] sunset = {
                        "))))))))+++",
                        "))))))+++++",
                        ")))))++++ ++",
                        "   ++   ++ ++//////////////////",
                        "    ++   ++//------//-------//",
                        "     ++   //------//-------///",
                        "      ++ //------//-------////",
                        "       +//------//-------// //",
                        "       //------//-------//////",
                        "      ///////////////////"
        };

        int consoleWidth = Console.WindowWidth;

        foreach (var line in sunset)
        {
            for (int i = 0; i < line.Length; i++)
            {
                char currentChar = line[i];

                if (currentChar == '+')
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                else if (currentChar == '/')
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                else if (currentChar == '-')
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
                else if (currentChar == ')')
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
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
            // Play sound
            using (var audioFile = new AudioFileReader("Music/wind.mp3"))
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
    }

    public static void DrawPerson()
    {
         string[] person = {
                        "  /////",
                        " (o_ o)",
                        "   ><  ",
                       @"|| * \\",
                        "||___(/ ",
                        " | | | ",
                        " |_|_|",
                        " =   =",
                    };

        int consoleWidth = Console.WindowWidth;

        foreach (var line in person)
        {
            for (int i = 0; i < line.Length; i++)
            {
                char currentChar = line[i];

                if (currentChar == '>' || currentChar == '<')
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else if (currentChar == '|')
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
                else if (currentChar == '*')
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                else if (currentChar == '=')
                {
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
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


    public static void DrawPuzzle(){
        string[] puzzle = {
                "R Z P X Q W E D Q",
                "I A A P I A L Y J",
                "P A L R P N E K G",
                "T P I O T O C J D",
                "B N X A S C T C I",
                "G T A E H I R Y H",
                "T F O A R L O X X",
                "C B H V V I N R X",
                "B P B X I S S M U"
        };
        Array.ForEach(puzzle, Console.WriteLine);

    }
    public static void TalkToPeopleOrQuiz()
    {
        string commandE1 = " ";
        string responseE1 = " ";
        string replyE1 = " ";
        string puzzleGuess = " ";

        bool word1 = false;
        bool word2 = false;
        bool word3 = false;
        bool word4 = false;
        bool word5 = false;

        // int help = 1;
        // bool allCorrectAnswers = false;
        
        bool solarPanelBuilt = false;

        CharactersManager.NPC_Color("nova");
        Console.WriteLine(" It looks like you've managed to collect all the pieces we need!");
        Console.WriteLine();
        CharactersManager.NPC_Color("nova");
        Console.WriteLine(" Sadly, it looks like all the further data on how to build solar panels has been lost.");
        Console.WriteLine();
        CharactersManager.NPC_Color("nova");
        Console.WriteLine(" Scanning the area...");
        Console.WriteLine();
        CharactersManager.NPC_Color("nova");
        Console.WriteLine(" It looks like there might be another human from this era nearby!");
        Console.WriteLine();
        CharactersManager.NPC_Color("nova");
        Console.WriteLine(" Darwin, what shall you do?");
        Console.WriteLine();
        DrawTextDivider();

    while (true)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("1 ");
        Console.ResetColor();
        Console.WriteLine("Go and talk to the person in the distance.");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("2 ");
        Console.ResetColor();
        Console.WriteLine("Try and build the solar panel.");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("3 ");
        Console.ResetColor();
        Console.WriteLine("Leave this era and proceed to teleport to the next.");
        Console.WriteLine();
        commandE1 = Console.ReadLine()!.Trim().ToLower();

        DrawTextDivider();

           switch (commandE1) {

           case "1":   //TALKING WITH THE OTHER PERSON + MINIGAME
                DrawPerson();
                Console.WriteLine("You walk up to a person in the distance, waving your hand.");
                Console.WriteLine("As you get closer, you notice it's just a young boy.");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                 Console.Write("1 ");
                 Console.ResetColor();
                 Console.WriteLine("Hello, who are you?");
                 Console.ForegroundColor = ConsoleColor.Yellow;
                 Console.Write("2 ");
                 Console.ResetColor();
                 Console.WriteLine("Are you lost, kid?");
                 Console.WriteLine();
                responseE1 = Console.ReadLine()!.Trim().ToLower();

                 while (responseE1 != "1" && responseE1 != "2")  {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nInvalid choice.");
                        Console.ResetColor();
                        responseE1 = Console.ReadLine()!.Trim().ToLower();
                 }

                 DrawTextDivider();

                switch (responseE1) {
                        case "1":
                        CharactersManager.NPC_Color("matthew");
                        Console.WriteLine(" ...hello, I'm Matthew.");
                        Console.WriteLine();
                        CharactersManager.NPC_Color("matthew");
                        Console.WriteLine(" You look different from other people here.");
                        Console.WriteLine();
                        CharactersManager.NPC_Color("matthew");
                        Console.WriteLine(" I know you must be wondering what I'm doing out here all alone.");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("\nPRESS ENTER");
                        Console.ResetColor();
                        Console.WriteLine(" to continue");
                        Console.ReadLine();
                        break;

                        case "2":
                        CharactersManager.NPC_Color("matthew");
                        Console.WriteLine(" No, not quite. I know how to get back, I'm just looking for clues...");
                        Console.WriteLine();
                        CharactersManager.NPC_Color("matthew");
                        Console.WriteLine(" You look different from other people here...");
                        Console.WriteLine();
                        CharactersManager.NPC_Color("matthew");
                        Console.WriteLine(" I know you must be wondering what I'm doing out here all alone.");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("\nPRESS ENTER");
                        Console.ResetColor();
                        Console.WriteLine(" to continue");
                        Console.ReadLine();
                        break;
                }
                Console.WriteLine();

                        CharactersManager.NPC_Color("matthew");
                        Console.WriteLine(" The thing is I'm looking to decipher this puzzle. I was told that these words and what they mean could save our planet.");
                        Console.WriteLine();
                        CharactersManager.NPC_Color("matthew");
                        Console.WriteLine(" Can you help me...?");
                        Console.WriteLine();

                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("1 ");
                        Console.ResetColor();
                        Console.WriteLine("Yes, of course.");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("2 ");
                        Console.ResetColor();
                        Console.WriteLine("Sorry, I'm busy with something else right now...");
                        Console.WriteLine();
                        replyE1 = Console.ReadLine()!.Trim().ToLower();

                         while (replyE1 != "1" && replyE1 != "2")  {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nInvalid choice.");
                        Console.ResetColor();
                        replyE1 = Console.ReadLine()!.Trim().ToLower();
                        }

                        if (replyE1 == "1") {
                        CharactersManager.NPC_Color("matthew");
                        Console.WriteLine(" Thank you! I heard that some important keywords are hidden in this grid."); 
                        Console.WriteLine(); 
                        CharactersManager.NPC_Color("matthew");
                        Console.WriteLine(" Maybe once you find them, your robot friend can help us learn more about them!"); 
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("\nPRESS ENTER");
                        Console.ResetColor();
                        Console.WriteLine(" to continue");
                        Console.ReadLine();
                           DrawTextDivider();

                                while (!(word1 && word2 && word3 && word4 && word5)) {
                                     
                                        DrawPuzzle();
                                        Console.Write("Write the word you found or type ");
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.Write("HELP");
                                        Console.ResetColor();
                                        Console.WriteLine(" for a hint: ");
                                        Console.WriteLine("");
                                        puzzleGuess = Console.ReadLine()!.Trim().ToLower();

                                        switch (puzzleGuess) {
                                                case "help":
                                                case "HELP":

                                                if (word1 == false) {
                                                CharactersManager.NPC_Color("nova");
                                                Console.WriteLine(" Hmm, what are the tiny electric-powered mollecules in the panels called again?");}
                                                else if (word2 == false) {
                                                CharactersManager.NPC_Color("nova");
                                                Console.WriteLine(" What word would you use to describe energy that comes directly from the sun and powers panels to generate electricity?");}
                                                else if (word3 == false) {
                                                CharactersManager.NPC_Color("nova");
                                                Console.WriteLine(" Solar panels don’t just capture light during sunny days! What do we feel when it's very sunny?");}
                                                else if (word4 == false) {
                                                CharactersManager.NPC_Color("nova");
                                                Console.WriteLine(" How would you describe the system thanks to which electrcity can come into homes? I'm pretty sure they used wires...");}
                                                else if (word5 == false) {
                                                CharactersManager.NPC_Color("nova");
                                                Console.WriteLine(" What material is good for buildig solar panels? It must be able to capture sunlight! You can do this Darwin!");}

                                                      /*  switch(help){
                                                         case 1:
                                                         
                                                          CharactersManager.NPC_Color("nova");
                                                          Console.WriteLine("Hmm, what are the tiny electric-powered mollecules in the panels called again?");
                                                          help = help + 1;
                                                         break;

                                                         case 2:
                                                          CharactersManager.NPC_Color("nova");
                                                          Console.WriteLine("What word would you use to describe energy that comes directly from the sun and powers panels to generate electricity?");
                                                          help = help + 1;
                                                         break;

                                                         case 3:
                                                          CharactersManager.NPC_Color("nova");
                                                          Console.WriteLine("Solar panels don’t just capture light during sunny days! What do we feel when it's very sunny?");
                                                          help = help + 1;
                                                         break;

                                                         case 4:
                                                          CharactersManager.NPC_Color("nova");
                                                          Console.WriteLine("How would you describe the system thanks to which electrcity can come into homes? I'm pretty sure they used wires...");
                                                          help = help + 1;
                                                         break;

                                                         case 5:
                                                          CharactersManager.NPC_Color("nova");
                                                          Console.WriteLine("What material is good for buildig solar panels? It must be able to capture sunlight! You can do this Darwin!");
                                                          help = help - 4;
                                                         break;

                                                        }*/
                                                break;
                                                case "electrons": //word1
                                                if (word1 == true) {
                                                   CharactersManager.NPC_Color("nova");
                                                   Console.WriteLine(" I think we already found this word, let's try looking for another one.");
                                                 }
                                                 if (word1 == false) {
                                                   CharactersManager.NPC_Color("nova");
                                                   Console.WriteLine(" Great job! I remember now that these tiny, charged particles are set in motion within solar cells to create an electric current.");
                                                   word1 = true;
                                                 }
                                                break;
                                                case "solar":   //word2
                                                if (word2 == true) {
                                                   CharactersManager.NPC_Color("nova");
                                                   Console.WriteLine(" I think we already found this word, let's try looking for another one.");
                                                 }
                                                 if (word2 == false) {
                                                   CharactersManager.NPC_Color("nova");
                                                   Console.WriteLine(" This word describes energy that comes directly from the sun and powers panels to generate electricity.");
                                                   word2 = true;
                                                 }
                                                break;
                                                case "heat":  //word3
                                                if (word3 == true) {
                                                   CharactersManager.NPC_Color("nova");
                                                   Console.WriteLine(" I think we already found this word, let's try looking for another one.");}
                                                if (word3 == false) {
                                                   CharactersManager.NPC_Color("nova");
                                                   Console.WriteLine(" You've got a keen eye for this! Solar panels don’t just capture light; they also endure this byproduct on hot, sunny days, which can affect efficiency.");
                                                   word3 = true;
                                                 }
                                                break;
                                                case "wiring": //word4
                                                if (word4 == true) {
                                                   CharactersManager.NPC_Color("nova");
                                                   Console.WriteLine(" I think we already found this word, let's try looking for another one.");}
                                                 if (word4 == false) {
                                                   CharactersManager.NPC_Color("nova");
                                                   Console.WriteLine(" This part of a solar panel helps carry the electricity generated by the cells to power devices and buildings.");
                                                   word4 = true;
                                                 }
                                                break;
                                                case "silicon": //word5
                                                if (word5 == true) {
                                                   CharactersManager.NPC_Color("nova");
                                                   Console.WriteLine(" I think we already found this word, let's try looking for another one.");}
                                                 if (word5 == false) {
                                                   CharactersManager.NPC_Color("nova");
                                                   Console.WriteLine(" Ah, now I remember! This is the main material used in solar cells due to its excellent properties for capturing sunlight and conducting electricity.");
                                                   word5 = true;
                                                 }
                                                break;
                                        default:
                                          CharactersManager.NPC_Color("nova");
                                          Console.WriteLine(" That doesn't seem to be a possible word... Try again! Don't give up Darwin!");
                                        break;
                                        }
                                DrawTextDivider();
                                }
                        CharactersManager.NPC_Color("nova");
                        Console.WriteLine(" You did it! We learned so much more and now that I heard those words again I remember so much more!");
                        Console.WriteLine("\n");
                        CharactersManager.NPC_Color("matthew");
                        Console.WriteLine(" You're amazing! When I grow up, I want to study hard and work on sustainability, so the desert that now exists will be no more.");
                        Console.WriteLine("\n");
                        CharactersManager.NPC_Color("nova");
                        Console.WriteLine(" I think we're ready to try and build the solar panels now.");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("\nPRESS ENTER");
                        Console.ResetColor();
                        Console.WriteLine(" to continue");
                        Console.ReadLine();
                        DrawTextDivider();
                        }

           break;
                
           case "2":  //BIG QUIZ
            int correctAnswers = 0;

           CharactersManager.NPC_Color("nova");
           Console.WriteLine(" Okay Darwin, go for it!");
           Console.WriteLine();
           Transition transition = new Transition();
           transition.EmojiTransition("☀️", "⚡"); 
           Console.WriteLine();

        ///Question 1
           Console.ForegroundColor = ConsoleColor.Yellow;
           Console.WriteLine("What do solar panels use to convert sunlight into electricity");
           Console.ResetColor();
           string[] lines = {
             "1. Photons",
             "2. Solar mirrors",
             "3. Photovoltaic cells",
             " ",
             "Type the number of your answer!"
            };
           Array.ForEach(lines, Console.WriteLine);
           responseE1 = Console.ReadLine()!.Trim().ToLower();
            while (responseE1 != "1" && responseE1 != "2" && responseE1 != "3")  {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nInvalid choice.");
                        Console.ResetColor();
                        responseE1 = Console.ReadLine()!.Trim().ToLower(); }
            if (responseE1 == "3"){
                CharactersManager.NPC_Color("nova");
                Console.WriteLine(" Great job! That's correct!");
                correctAnswers++;
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("\nPRESS ENTER");
                Console.ResetColor();
                Console.WriteLine(" to continue");
                Console.ReadLine();
            }
            else{
                CharactersManager.NPC_Color("nova");
                Console.WriteLine(" That doesn't seem to be correct... I think they're called photovoltaic cells.");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("\nPRESS ENTER");
                Console.ResetColor();
                Console.WriteLine(" to continue");
                Console.ReadLine();
            };
            DrawTextDivider();
        
         ///Question 2
           Console.ForegroundColor = ConsoleColor.Yellow;
           Console.WriteLine("Which of the following is a benefit of solar energy?");
           Console.ResetColor();
            lines = new string[] {
             "1. It produces clean energy with no emissions",
             "2. It works 24/7, regardless of sunlight",
             "3. It requires a lot of water to generate electricity",
             " ",
             "Type the number of your answer!"
            };
           Array.ForEach(lines, Console.WriteLine);
           responseE1 = Console.ReadLine()!.Trim().ToLower();
            while (responseE1 != "1" && responseE1 != "2" && responseE1 != "3")  {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nInvalid choice.");
                        Console.ResetColor();
                        responseE1 = Console.ReadLine()!.Trim().ToLower(); }
            if (responseE1 == "1"){
                CharactersManager.NPC_Color("nova");
                Console.WriteLine(" Exactly! You've got this Darwin!");
                correctAnswers++;
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("\nPRESS ENTER");
                Console.ResetColor();
                Console.WriteLine(" to continue");
                Console.ReadLine();
            }
            else{
                CharactersManager.NPC_Color("nova");
                Console.WriteLine(" Not quite...Remember, solar energy is sustainable, meaning it leaves no emissions!");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("\nPRESS ENTER");
                Console.ResetColor();
                Console.WriteLine(" to continue");
                Console.ReadLine();
            };
            DrawTextDivider();
        
         ///Question 3
           Console.ForegroundColor = ConsoleColor.Yellow;
           Console.WriteLine("What process is used in fusion energy, which also powers the sun?");
           Console.ResetColor();
            lines = new string[] {
             "1. Electromagnetic radiation",
             "2. Combustion",
             "3. Nuclear fusion",
             " ",
             "Type the number of your answer!"
            };
           Array.ForEach(lines, Console.WriteLine);
           responseE1 = Console.ReadLine()!.Trim().ToLower();
            while (responseE1 != "1" && responseE1 != "2" && responseE1 != "3")  {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nInvalid choice.");
                        Console.ResetColor();
                        responseE1 = Console.ReadLine()!.Trim().ToLower(); }
            if (responseE1 == "3"){
                CharactersManager.NPC_Color("nova");
                Console.WriteLine(" Correct! You're really good at this!");
                correctAnswers++;
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("\nPRESS ENTER");
                Console.ResetColor();
                Console.WriteLine(" to continue");
                Console.ReadLine();
            }
            else{
                CharactersManager.NPC_Color("nova");
                Console.WriteLine(" Nuclear fusion is the cause! It's a special process with lots of small nuclei, which generates energy.");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("\nPRESS ENTER");
                Console.ResetColor();
                Console.WriteLine(" to continue");
                Console.ReadLine();
            };
            DrawTextDivider();

            ///Question 4
           Console.ForegroundColor = ConsoleColor.Yellow;
           Console.WriteLine("What type of energy do solar panels convert sunlight into?");
           Console.ResetColor();
            lines = new string[] {
             "1. Thermal energy",
             "2. Electrical energy",
             "3. Mechanical energy",
             " ",
             "Type the number of your answer!"
            };
           Array.ForEach(lines, Console.WriteLine);
           responseE1 = Console.ReadLine()!.Trim().ToLower();
            while (responseE1 != "1" && responseE1 != "2" && responseE1 != "3")  {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nInvalid choice.");
                        Console.ResetColor();
                        responseE1 = Console.ReadLine()!.Trim().ToLower(); }
            if (responseE1 == "2"){
                CharactersManager.NPC_Color("nova");
                Console.WriteLine(" Amazing! That's right!");
                correctAnswers++;
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("\nPRESS ENTER");
                Console.ResetColor();
                Console.WriteLine(" to continue");
                Console.ReadLine();
            }
            else{
                CharactersManager.NPC_Color("nova");
                Console.WriteLine(" The energy we collect is electrical, meaning we can use it for all sorts of things!");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("\nPRESS ENTER");
                Console.ResetColor();
                Console.WriteLine(" to continue");
                Console.ReadLine();
            };
            DrawTextDivider();
            ///Question 5
           Console.ForegroundColor = ConsoleColor.Yellow;
           Console.WriteLine("What material is commonly used to make the photovoltaic cells in solar panels?");
           Console.ResetColor();
            lines = new string[] {
             "1. Copper",
             "2. Silicon",
             "3. Iron",
             " ",
             "Type the number of your answer!"
            };
           Array.ForEach(lines, Console.WriteLine);
           responseE1 = Console.ReadLine()!.Trim().ToLower();
            while (responseE1 != "1" && responseE1 != "2" && responseE1 != "3")  {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nInvalid choice.");
                        Console.ResetColor();
                        responseE1 = Console.ReadLine()!.Trim().ToLower(); }
            if (responseE1 == "2"){
                CharactersManager.NPC_Color("nova");
                Console.WriteLine(" Correct! Great job, Darwin!");
                correctAnswers++;
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("\nPRESS ENTER");
                Console.ResetColor();
                Console.WriteLine(" to continue");
                Console.ReadLine();
            }
            else{
                CharactersManager.NPC_Color("nova");
                Console.WriteLine(" Not quite, silicon is optimal because of its  excellent properties for capturing sunlight and conducting electricity.");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("\nPRESS ENTER");
                Console.ResetColor();
                Console.WriteLine(" to continue");
                Console.ReadLine();
            };

                DrawTextDivider();

        if (correctAnswers == 5) {
                solarPanelBuilt = true;
                DrawPanel();
                Console.WriteLine();
                CharactersManager.NPC_Color("nova");
                Console.WriteLine(" Darwin, you did it!! Amazing❗");
                Console.WriteLine();
                CharactersManager.NPC_Color("nova");
                Console.WriteLine(" Now, people in this era will be able to generate electrcity and restore nature.");
                Console.WriteLine();
                CharactersManager.NPC_Color("nova");
                Console.Write(" The teleportation device is now ⚡charged⚡ with solar energy. You can now select ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Option 3!");
                Console.ResetColor();
                Console.WriteLine();
                // allCorrectAnswers = true;
        }
        else {
                CharactersManager.NPC_Color("nova");
                Console.WriteLine(" You didn't quite get it right this time, but no worries.");
                Console.WriteLine();
                CharactersManager.NPC_Color("nova");
                Console.WriteLine(" Try again and don't give up!");
                Console.WriteLine();
        }
        break;
        case "3":
            if (!solarPanelBuilt)
            {
                CharactersManager.NPC_Color("nova");
                Console.WriteLine(" 😲 Oh no! The teleportation machine has used all of our remaining power ⚡ to get here.");
                Console.WriteLine("and now we must use solar energy to power it once again.");
                Console.WriteLine();
                CharactersManager.NPC_Color("nova");
                Console.Write(" We need the ☀️ solar panels to teleport to the next era. Let's complete the task in ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Option 2");
                Console.ResetColor();
                Console.WriteLine("!");
                Console.WriteLine();
            }
            else
            {
                CharactersManager.NPC_Color("nova");
                Console.WriteLine(" The teleportation machine is ready! Let's leave this era and proceed to the next.");
                Console.WriteLine();
                PointSystem.Instance.AddPoints(1, 1);
                PointSystem.Instance.DisplayPointsEarned();
                return;
            }
            break;

        default:
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nInvalid choice.");
            Console.ResetColor();
            break;
        }
    }
}

    public void Enter()
    {
        string actionE1 = " ";
        //var E1Map = new Map();
        EraTitle eraTitle = new EraTitle();
        eraTitle.Print("Welcome to Era 1!");

        PointSystem pointSystem = new PointSystem();

        Console.WriteLine();
        Console.WriteLine();
        CharactersManager.NPC_Color("nova");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(" You have teleported to Era1!"); // Show arrival text
        Console.ResetColor();
        Console.WriteLine();

        Console.Write("Would you like to check the ");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("MAP");
        Console.ResetColor();
        Console.Write(" or ");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("ENTER");
        Console.ResetColor();
        Console.WriteLine(" era 1?");

        actionE1 = Console.ReadLine()!.Trim().ToLower();

        while (actionE1 != "enter"){
                if (actionE1 == "map") {
                        Map.DisplayMap("Era1");
                        actionE1 = Console.ReadLine()!.Trim().ToLower();
                }
                else if (actionE1 != "enter") {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nInvalid choice.");
                Console.ResetColor();
                actionE1 = Console.ReadLine()!.Trim().ToLower();
                }
        }
        if (actionE1 == "enter") {
        DrawSunset();
        PanelSearching();
        TalkToPeopleOrQuiz();
        }
       /* else if (actionE1 == "enter") {
                WorldOfZuul.input 
        }*/
    }
}