using System;
using System.Data;
using MapAndCenter;
using System.Security.Cryptography.X509Certificates;
using NAudio.Wave;

public class Era2Bees
{
    // Method that prints the welcome message for Era 2 Bees - Lukas
    public static void WriteParagraph()
    {
        Console.WriteLine();
        Console.WriteLine();
    }

    //ConsoleClear
    public static void ConsoleClear()
    {
        Console.Clear();
        WriteParagraph();
        WriteParagraph();
    }

    //proceed in dialogue
    public static void ConsoleContinue()
    {
        WriteParagraph();
        WriteParagraph();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("PRESS ENTER");
        Console.ResetColor();
        Console.WriteLine(" to continue");
        Console.ReadLine();
    }
    //First introduction with the underground resistance group
    
    public static void FirstEncounter()
    {
        ConsoleClear();
        Transition transition = new Transition();
        transition.EmojiTransition("🌲🌳🌿","🐝");
        WriteParagraph();
        WriteParagraph();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("You tumble through a swirling portal and land awkwardly on your feet in a dimly lit, high-tech underground base."); 
        Console.ResetColor();
        Console.WriteLine("\n");
        string[] ArtLines = 
        {
            "                                                  _o6868868o_",
            "                                               .o688\"'    \"`688o,",
            "                                            .o86'             `88o,",
            "                                           ,88'  `'             `88,",
            "                                          ,68'        ,\".        `88,",
            "                                         ,88'        [!!!]  `'    `68,",
            "                                         88'         `=\"='         `88",
            "                                         .86        ' F:J   `        68.",
            "                                        [8[     '     F:J     `     ]6]",
            "                                        [8[   '       F:J       `   ]8]",
            "                                        `86  '       ,F:J.       `  66'",
            "                                         88 '  ,\".   ||_||   ,\".  `,88",
            "                                         `88. _|:|,,,'\"_\"`,,,|:|  ,68'",
            "                                          `68;:,^.---//^\\---,^.:,88'",
            "                                           `68o!II::::|H|::::II;o68'",
            "                                             `86o.\"\"\",':`\"\"\",o86'",
            "                                               `868o;:-:-:;6888'",
            "                                                  `6688868868'"
        };

        foreach (var line in ArtLines)
        {
            for (int i = 0; i < line.Length; i++)
            {
                char currentChar = line[i];

                if (currentChar == '\'' || currentChar == ']' || currentChar == ',' || currentChar == '.' || currentChar == '[')
                {
                    Console.ForegroundColor = ConsoleColor.Blue; // Sun
                }
                else if (currentChar == '`' || currentChar == '8')
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan; // Tracks 2
                }
                else if (currentChar == '6' || currentChar == 'o')
                {
                    Console.ForegroundColor = ConsoleColor.DarkBlue; // Tracks 2
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

        using (var audioFile = new AudioFileReader("Music/portal.mp3"))
        using (var sound = new WaveOutEvent())
        {
            sound.Init(audioFile);
            sound.Play();

            ConsoleContinue();
            sound.Stop();
        }
        
        ConsoleClear();
        CharactersManager.NPC_Color("nova");
        Console.WriteLine(" Don't worry Darwin, I'm here with you. It seems we've arrived in a world that could use a little help from us.");
        ConsoleContinue();

        ConsoleClear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("At that moment, a tall, charismatic man with a determined look steps forward. This is ");
        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.Blue;
        Console.Write(" Mathmany ");
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(" , the leader of an underground resistance group.");
        Console.ResetColor();
        ConsoleContinue();

        ConsoleClear();
        CharactersManager.NPC_Color("mathmany");
        Console.WriteLine(" I'd like to say \"welcome\", but there's no time for pleasantries.");
        Console.WriteLine("Our world is suffering, and it seems we're in dire need of someone who understands reason and truth.");
        Console.WriteLine("Even though I see you around here the first time. You look quite like a guy with guts, who is ready to do the right thing.");  
        ConsoleContinue();

        //maybe making a decision to help or not to help
        ConsoleClear();
        CharactersManager.NPC_Color("nova");
        Console.WriteLine(" Yes Darwin, let's help them, it might save this era and work out in our favor in the end.");
        ConsoleContinue();

        ConsoleClear();
        CharactersManager.NPC_Color("mathmany");
        Console.WriteLine(" You're in our last refuge, the heart of our resistance.");
        Console.Write("Our world is under the grip of a man named ");
        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.Red;
        Console.Write(" Donald ");
        Console.ResetColor();
        Console.WriteLine(" the ruthless CEO of CSA, \"Create Solar Amps\".");
        Console.WriteLine("His company manufactures solar panels, which sounds good on the surface, right?");  
        ConsoleContinue();

        ConsoleClear();
        CharactersManager.NPC_Color("nova");
        Console.WriteLine(" Solar panels? Renewable energy is a positive thing, usually...");
        Console.Write("This is actually the reason why we build them in ");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("Era 1 ");
        Console.ResetColor();
        ConsoleContinue();

        ConsoleClear();
        CharactersManager.NPC_Color("mathmany");
        Console.Write(" True, but ");
        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.Red;
        Console.Write(" Donald ");
        Console.ResetColor();
        Console.WriteLine(" is twisting it for personal profit.");
        Console.WriteLine("He spreads misinformation and funds false studies, all aimed at eradicating insects—especially pollinators.");
        Console.WriteLine("He claims they're a threat to human health and prosperity, while the reality is quite the opposite.");  
        ConsoleContinue();

        ConsoleClear();
        CharactersManager.NPC_Color("nova");
        Console.WriteLine(" Hey Darwin, in some databases from your old world I found that");
        Console.WriteLine("insects especially pollinators like bees, are essential for ecosystems.");
        Console.WriteLine("Without them, food production and plant biodiversity would collapse.");
        ConsoleContinue();

        ConsoleClear();
        CharactersManager.NPC_Color("nova");
        Console.Write(" But why would ");
        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.Red;
        Console.Write(" Donald ");
        Console.ResetColor();
        Console.WriteLine(" want to harm insects if they're so essential?");
        ConsoleContinue();

        ConsoleClear();
        CharactersManager.NPC_Color("mathmany");
        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.Red;
        Console.Write("\n\n Donald ");
        Console.ResetColor();
        Console.WriteLine(" is a greedy guy.");
        Console.WriteLine("With fewer insects, he can push for more synthetic farming techniques and expand his solar farms unchecked.");
        Console.WriteLine("But it's short-sighted. The harm he's causing to ecosystems will destroy food sources, reduce biodiversity, and ultimately hurt people."); 
        Console.WriteLine("He's willing to risk it all for his bottom line, leaving our world on the brink of destruction.");   
        ConsoleContinue();

        ConsoleClear();
        CharactersManager.NPC_Color("nova");
        Console.WriteLine(" This sounds… horrible. Darwin we need to help them.");
        ConsoleContinue();

        //after that minigame starts to learn facts about insect and bees
        //FactsGuessingGame();
        FactsFetching();
    }

    public static void InvalidAnswer()
    {
        ConsoleClear();
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
        Console.Write(" or ");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("3");
        Console.ResetColor();
        Console.WriteLine(".");
        Console.WriteLine();
        ConsoleContinue();

    }
    //Method for wrong answer
    public static void WrongAnswer()
    {
        ConsoleClear();
        Transition transitionB = new Transition();
        transitionB.EmojiTransition("❌","❓");
        Console.Write("\n🔴 Hmm, the system shows that it's not right. ");
        Console.BackgroundColor = ConsoleColor.DarkRed;
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write(" Try again! ");
        Console.ResetColor();
        Console.WriteLine();
        Console.WriteLine();
    }

    public static void FactsFetching()
    {
        string command1 = "";
        string command2 = "";
        string command3 = "";
        string command4 = "";
        string secondcommand1 = "";
        string secondcommand2 = "";
        string secondcommand3 = "";
        string secondcommand4 = "";
        string keyword1 = "P_ll_n_t_rs";
        string keyword2 = "P_st_c_d_s";
        string keyword3 = "B__d_v_rs_ty";
        string keyword4 = "Bee_wa_";

        command1 = "Insects like bees and butterflies that transfer pollen between plants,                       ";
        secondcommand1  = "enabling the production of seeds and fruits, essential for food production.                  ";
        
        //    break;
        //case "pesticides":
        command2        = "Chemicals used to kill pests but often harmful to pollinators,                               ";
        secondcommand2  = "contributing to declining insect populations.                                                ";
        
        //    break;
        //case "biodiversity":
        command3        = "The variety of life in ecosystems, which ensures stability, resilience,                      ";
        secondcommand3  = "and sustainability by creating interdependent relationships.                                 ";
        
        //    break;
        //case "beeswax":
        command4        = "A natural wax produced by honey bees to build honeycombs,                                    ";
        secondcommand4  = "used for storing honey and protecting the hive.                                              ";
        
        ConsoleClear();
        CharactersManager.NPC_Color("mathmany");
        Console.WriteLine(" Knowledge is our best weapon. ");
        Console.Write("If you're to confront ");
        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.Red;
        Console.Write(" Donald ");
        Console.ResetColor();
        Console.WriteLine(" publicly, you'll need to arm yourself with facts.");
        Console.WriteLine();
        Console.WriteLine("Understand the vital role that insects play in the ecosystem, especially as pollinators.");
        Console.WriteLine("We have a forbidden library in our module, but currently it's a bit buggy.");
        Console.Write("Every new fact, that you decipher will increase your stregth in knowledge to oppose ");
        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.Red;
        Console.Write(" Donald ");
        Console.ResetColor();        
        Console.WriteLine(" in the debate.");
        ConsoleContinue();

        //Drawtable function with facts inside
        static void DrawTable(string keyword1, string keyword2, string keyword3, string keyword4, string command1, string command2, string command3, string command4,string secondcommand1, string secondcommand2, string secondcommand3, string secondcommand4)
        {
            Console.WriteLine("╔═══════════════╦═══════════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║ keyword       ║ Description                                                                                   ║");
            //Console.WriteLine("╠═══════════════╬═══════════════════════════════════════════════════════════════════════════════════════════════╣");
            Console.WriteLine("╚═══════════════╩═══════════════════════════════════════════════════════════════════════════════════════════════╝");
    
            // Displays each selected command, if present
            PrintCommandRow(keyword1, command1,secondcommand1);
            PrintCommandRow(keyword2, command2,secondcommand2);
            PrintCommandRow(keyword3, command3,secondcommand3);
            PrintCommandRow(keyword4, command4,secondcommand4);
    
            //Console.WriteLine("╚═══════════════╩═══════════════════════════════════════════════════════════════════════════════════════════════╝");
            Console.WriteLine();
            CharactersManager.NPC_Color("nova");
            Console.WriteLine(" Decipher the words to gain knowledge:");
            Console.ResetColor();
            Console.WriteLine();
            Console.Write("1) ");
            foreach (char c in "otlPsonilrai")
            {
                if ("oia".Contains(c))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(c);
                    Console.ResetColor();
                }
                else
                {
                    Console.Write(c);
                }
            }
            Console.WriteLine();

            Console.Write("2) ");
            foreach (char c in "dPeicsiest")
            {
                if ("ei".Contains(c))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(c);
                    Console.ResetColor();
                }
                else
                {
                    Console.Write(c);
                }
            }
            Console.WriteLine();

            Console.Write("3) ");
            foreach (char c in "tyividBrisoe")
            {
                if ("ioe".Contains(c))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(c);
                    Console.ResetColor();
                }
                else
                {
                    Console.Write(c);
                }
            }
            Console.WriteLine();

            Console.Write("4) ");
            foreach (char c in "wsxBeae")
            {
                if ("sw".Contains(c))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(c);
                    Console.ResetColor();
                }
                else
                {
                    Console.Write(c);
                }
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("🟢 Place the ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("green letters");
            Console.ResetColor();
            Console.WriteLine(" into the correct blank spaces to complete the missing word.");
            Console.WriteLine();
            Console.Write("🚨 Try ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("typing your guessed word");
            Console.ResetColor();
            Console.Write(" or '");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("c");
            Console.ResetColor();
            Console.WriteLine("' to continue...");
        }
    
        // Print a table row with colored text
        static void PrintCommandRow(string keyword, string command, string secondcommand)
        {
        if (!string.IsNullOrEmpty(keyword))
        {
            // Print the cell for the command with the text colored in cyan
            Console.Write("║ ");
            Console.Write($"{keyword,-12} ");
            Console.ResetColor();
            Console.Write(" ║ ");

            // Print the cell for the description in green
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(command.PadRight(76));
            Console.ResetColor();
            Console.WriteLine(" ║");

            //second line left
            Console.Write("║               ║ ");
            //Console.ForegroundColor = ConsoleColor.Cyan;
            //Console.Write("║ ".PadRight(12));
            //Console.ResetColor();
            //Console.Write(" ║ ");

            //second line right
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(secondcommand.PadRight(76));
            Console.ResetColor();
            Console.WriteLine(" ║");
            Console.WriteLine("╚═══════════════╩═══════════════════════════════════════════════════════════════════════════════════════════════╝");
        }
        else
        {
            // Blank line if the command has not yet been selected
            //Console.WriteLine("║               ║",command,"                                                                                               ║");
            //Console.WriteLine("║               ║",secondcommand,"                                                                                               ║");
            
            //first line left
            Console.Write("║               ║ ");

            //second line right
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(command.PadRight(76));
            Console.ResetColor();
            Console.WriteLine(" ║");

            //second line left
            Console.Write("║               ║ ");

            //second line right
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(secondcommand.PadRight(76));
            Console.ResetColor();
            Console.WriteLine(" ║");
            Console.WriteLine("╠═══════════════╬═══════════════════════════════════════════════════════════════════════════════════════════════╣");
        }
    }
        
        bool condition = true;
        DrawTable(keyword1, keyword2, keyword3, keyword4,command1, command2, command3, command4, secondcommand1, secondcommand2, secondcommand3, secondcommand4);
        while (condition)
        {
            string input = Console.ReadLine()!.Trim().ToLower();
            Console.Clear();
            
            // Update the selected command
            switch (input.ToLower())
            {
                case "pollinators":
                    keyword1 = "Pollinators";
                    //command1        = "Insects like bees and butterflies that transfer pollen between plants,                       ";
                    //secondcommand1  = "enabling the production of seeds and fruits, essential for food production.                  ";
                    break;

                case "pesticides":
                    keyword2 = "Pesticides";
                    //command2        = "Chemicals used to kill pests but often harmful to pollinators,                               ";
                    //secondcommand2  = "contributing to declining insect populations.                                                ";
                    break;

                case "biodiversity":
                    keyword3 = "Biodiversity";
                    //command3        = "The variety of life in ecosystems, which ensures stability, resilience,                      ";
                    //secondcommand3  = "and sustainability by creating interdependent relationships.                                 ";
                    break;

                case "beeswax":
                   keyword4 = "Beeswax";
                    //command4        = "A natural wax produced by honey bees to build honeycombs,                                    ";
                    //secondcommand4  = "used for storing honey and protecting the hive.                                              ";
                    break;

                case "c":
                case "C":
                    condition = false;
                    continue;

                default:
                    CharactersManager.NPC_Color("nova");
                    Console.WriteLine();
                    Console.WriteLine("--------------------------");
                    Console.WriteLine("| This is not a command! |");
                    Console.WriteLine("--------------------------");
                    Console.WriteLine();
                    Console.ResetColor();
                    break;
            }
            // Print the table with the updated commands
            DrawTable(keyword1, keyword2, keyword3, keyword4, command1, command2, command3, command4, secondcommand1, secondcommand2, secondcommand3, secondcommand4);
        }
        ConsoleContinue();
        FactsGuessingGame();
    }

    private static void DrawTable(object command1, object command2, object command3, object command4, object secondcommand1, object secondcommand2, object secondcommand3, object secondcommand4)
    {
        throw new NotImplementedException();
    }

    public static void FactsGuessingGame(){

        string? playerResponse;
        bool question1Correct = false;

        ConsoleClear();
        CharactersManager.NPC_Color("mathmany");
        //Console.WriteLine("Knowledge is our best weapon.");
        Console.Write(" If you're to confront ");
        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.Red;
        Console.Write(" Donald ");
        Console.ResetColor();
        Console.WriteLine(" publicly, you'll need to arm yourself with facts.");
        Console.WriteLine();
        Console.WriteLine("Understand the vital role that insects play in the ecosystem, especially as pollinators.");
        Console.WriteLine("We've set up a training module. It's a game of sorts, but every answer you get right strengthens your knowledge to expose his lies.");   
        ConsoleContinue();
                    
        //first question
        while (!question1Correct)
        {
            ConsoleClear();
            Transition transitionQ = new Transition();
            transitionQ.EmojiTransition("💻","🔵");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("\n1)");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(" What role do bees play in their ecosystem?");
            Console.WriteLine();
            
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("1.");
            Console.ResetColor();
            Console.WriteLine(" They simply collect nectar and make honey.");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("2.");
            Console.ResetColor();
            Console.WriteLine(" They're primary pollinators, crucial for the growth of many plants and crops.");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("3.");
            Console.ResetColor();
            Console.WriteLine(" They only serve as food for other animals.");

            playerResponse = Console.ReadLine();

            if (playerResponse == "2")
            {
                Transition transitionG = new Transition();
                transitionG.EmojiTransition("✔️","💚");
                Console.WriteLine("\n🟢 CORRECT! Moving to the next question...");
                Console.WriteLine();
                question1Correct = true;
            }
            else if (playerResponse == "1" || playerResponse == "3")
            {
                WrongAnswer();
                ConsoleContinue();
            }
            else
            {  
                InvalidAnswer();
            }
        }
        ConsoleContinue();
        ConsoleClear();
        question1Correct = false;

        //second question
        while (!question1Correct)
        {   
            ConsoleClear();
            Transition transitionQ = new Transition();
            transitionQ.EmojiTransition("💻","🔵");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("\n2)");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(" Why is biodiversity important to maintaining healthy ecosystems?");
            Console.WriteLine();
            
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("1.");
            Console.ResetColor();
            Console.WriteLine(" It allows a single species to dominate, providing stability.");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("2.");
            Console.ResetColor();
            Console.WriteLine(" Biodiversity means there's always another species ready to replace any that might disappear.");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("3.");
            Console.ResetColor();
            Console.WriteLine(" Biodiversity creates interdependent relationships, where each species contributes to balance and resilience.");

            playerResponse = Console.ReadLine();

            if (playerResponse == "3")
            {
                Transition transitionG = new Transition();
                transitionG.EmojiTransition("✔️","💚");
                Console.WriteLine("\n🟢 CORRECT! Moving to the next question...");
                Console.WriteLine();
                question1Correct = true;
            }
            else if (playerResponse == "1" || playerResponse == "2")
            {
                WrongAnswer();
                ConsoleContinue();
            }
            else
            {  
                InvalidAnswer();
            }
        }
        ConsoleContinue();
        ConsoleClear();
        question1Correct = false;

        //third question
        while (!question1Correct)
        {   
            ConsoleClear();
            Transition transitionQ = new Transition();
            transitionQ.EmojiTransition("💻","🔵");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("\n3)");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(" How do bees use beeswax?");
            Console.WriteLine();
            
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("1.");
            Console.ResetColor();
            Console.WriteLine(" They eat it for energy.");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("2.");
            Console.ResetColor();
            Console.WriteLine(" They use it to construct their hives, storing honey and housing larvae.");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("3.");
            Console.ResetColor();
            Console.WriteLine(" They use it to attract predators to their hives.");

            playerResponse = Console.ReadLine();

            if (playerResponse == "2")
            {
                Transition transitionG = new Transition();
                transitionG.EmojiTransition("✔️","💚");
                Console.WriteLine("\n🟢 CORRECT! Moving to the next question...");
                Console.WriteLine();
                question1Correct = true;
            }
            else if (playerResponse == "1" || playerResponse == "3")
            {
                WrongAnswer();
                ConsoleContinue();
            }
            else
            {  
                InvalidAnswer();
            }
        }
        ConsoleContinue();
        ConsoleClear();
        DonaldGameIntro();
    }

    public static void Decision()
    {
        WriteParagraph();
        Console.Write("Type ");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("1 ");
        Console.ResetColor();
        Console.Write("or ");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("2 ");
        Console.ResetColor();
        Console.Write("to decide if its true or wrong what ");
        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.Red;
        Console.Write(" Donald J. ");
        Console.ResetColor();
        Console.WriteLine(" is saying");
        WriteParagraph();

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("1. ");
        Console.ResetColor();
        Console.Write("(");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("False "); 
        Console.ResetColor();
        Console.WriteLine("information) Intervene and counter the argument.");

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("2. ");
        Console.ResetColor();
        Console.Write("(");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("True "); 
        Console.ResetColor();
        Console.WriteLine("information) Agree with the argument.");
    }

    //public debate game against Donald
    public static void DonaldGameIntro()
    {
        int csapoints = 0;
        Transition transition = new Transition();
        transition.EmojiTransition("💼","📜");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("With Mathmany's support, Darwin steps onto a public stage, facing ");
        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.Red;
        Console.WriteLine(" Donald ");
        Console.ResetColor();

        Console.WriteLine();
        Console.Write("A crowd gathers, curious and uncertain, as Darwin prepares to speak out.");
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.Red;
        Console.Write(" Donald ");
        Console.ResetColor();
        Console.Write(" , a polished man with a cold gaze, begins his speech."); 
        Console.ResetColor();
        ConsoleContinue();

        ConsoleClear();
        CharactersManager.NPC_Color("donald");
        Console.WriteLine(" Let me just say, folks, I'm building solar panels—the best solar panels out there."); 
        Console.WriteLine("Nobody builds solar panels like we do. They're huge, they're powerful, and they're saving the world."); 
        Console.WriteLine("Trust me, everyone agrees. We're making the sun work harder than ever before.");
        ConsoleContinue();

        ConsoleClear();
        CharactersManager.NPC_Color("mathmany");
        Console.WriteLine(" Stay sharp, Darwin. He's mixing truth with fiction. Remember what we learned...focus on facts and don't let his charisma distract you.");
        Console.WriteLine("Be sure to interrupt him, if he says something wrong and expose his lies."); 
        Console.WriteLine("But if you do that while you are in the wrong, you are running danger to be exposed yourself and divide the audience.");
        ConsoleContinue();

        //game happens now
        // First Decision
        bool question1Correct = false;
        string? playerResponse;

        while (!question1Correct)
        {   
            ConsoleClear();
            CharactersManager.NPC_Color("donald");
            Console.WriteLine(" Insects? Total pests, believe me. They do nothing for us.");
            Console.WriteLine("They eat crops, they're dirty, and they don't belong in a clean, modern society.");
            WriteParagraph();
            Decision();
            playerResponse = Console.ReadLine();

            if (playerResponse == "1")
            {
                csapoints++;
                ConsoleClear();
                Console.WriteLine("That's not true. Insects, especially pollinators like bees, contribute to 35% of global food production."); 
                Console.WriteLine("Without them, crops would fail, and food prices would skyrocket!");
                ConsoleContinue();

                ConsoleClear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("The audience murmurs, nodding in agreement with Darwin's logic."); 
                Console.ResetColor();
                ConsoleContinue();

                ConsoleClear();
                CharactersManager.NPC_Color("mathmany");
                Console.WriteLine(" Good job, Darwin. Keep going 👍");
                ConsoleContinue();

                question1Correct = true;
            }
            else if (playerResponse == "2")
            {
                csapoints--;
                ConsoleClear();
                Console.WriteLine("I think you have a point. Many insects do ruin crops.");
                ConsoleContinue();

                ConsoleClear();
                CharactersManager.NPC_Color("donald");
                Console.WriteLine(" They’re pests that spread disease and famine!");
                Console.WriteLine("We need to exterminate them!!");
                ConsoleContinue();

                ConsoleClear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The audience grows anxious, shaking their heads in disbelief."); 
                Console.ResetColor();
                ConsoleContinue();

                ConsoleClear();
                CharactersManager.NPC_Color("mathmany");
                Console.WriteLine(" Why didn’t you intervene? Now the people believe him.");
                ConsoleContinue();

                question1Correct = true;
            }
            else
            {  
                InvalidAnswerDonald();
            }
        }

        // Second Decision
        question1Correct = false;

        while (!question1Correct)
        {   
            ConsoleClear();
            CharactersManager.NPC_Color("donald");
            Console.WriteLine(" Solar panels are great for reducing carbon emissions, folks.");
            Console.WriteLine("We’ve done a fantastic job—better than anyone—at producing renewable energy. Everyone says it.");
            WriteParagraph();
            Decision();
            playerResponse = Console.ReadLine();

            if (playerResponse == "2")
            {
                csapoints++;
                ConsoleClear();
                Console.WriteLine("That's true. Solar panels reduce carbon emissions,");
                Console.WriteLine("but they can also coexist with nature if we integrate pollinator habitats into solar farms.");
                Console.WriteLine("Imagine the synergy! It’s crucial to provide habitats for insects.");
                ConsoleContinue();

                ConsoleClear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("The audience murmurs, nodding in agreement with Darwin's logic.");
                Console.ResetColor();
                ConsoleContinue();

                ConsoleClear();
                CharactersManager.NPC_Color("mathmany");
                Console.WriteLine(" Good job, Darwin. Keep it up 👍");
                ConsoleContinue();

                question1Correct = true;
            }
            else if (playerResponse == "1")
            {
                csapoints--;
                ConsoleClear();
                Console.WriteLine("That's not true. Solar farms should be abolished. Their existence harms the entire population.");
                ConsoleContinue();

                ConsoleClear();
                CharactersManager.NPC_Color("donald");
                Console.WriteLine(" By abolishing solar farms, we’d return to the dark times our grandfathers endured.");
                Console.WriteLine("And believe me—nobody wants that.");
                Console.WriteLine("Building solar panels is single-handedly saving the planet!");
                ConsoleContinue();

                ConsoleClear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The audience grows anxious, shaking their heads in disbelief."); 
                Console.ResetColor();
                ConsoleContinue();

                ConsoleClear();
                CharactersManager.NPC_Color("mathmany");
                Console.WriteLine(" Why didn’t you intervene? Now the people believe him.");
                ConsoleContinue();

                question1Correct = true;
            }
            else
            {  
                InvalidAnswerDonald();
            }
        }

        // Third Decision
        question1Correct = false;

        while (!question1Correct)
        {
            ConsoleClear();
            CharactersManager.NPC_Color("donald");
            Console.WriteLine(" Bees? Useless, like any other pollinator. Why bother when synthetic techniques are so much better?");
            Console.WriteLine("They’re efficient, predictable, and scalable!");
            WriteParagraph();
            Decision();
            playerResponse = Console.ReadLine();

            if (playerResponse == "1")
            {
                csapoints++;

                ConsoleClear();
                Console.WriteLine("Not when it destroys ecosystems. Synthetic techniques can’t replicate the biodiversity");
                Console.WriteLine("that pollinators sustain. Do you know what else bees give us? Honey and beeswax—two incredibly versatile materials!");
                ConsoleContinue();

                ConsoleClear();
                CharactersManager.NPC_Color("timmy");
                Console.WriteLine(" Wait, beeswax? What’s that for? Can it keep my snacks fresh, Darwin?");
                ConsoleContinue();

                ConsoleClear();
                Console.WriteLine("😊 Exactly, Timmy! Beeswax is used to make beeswax wraps—a sustainable alternative to plastic wrap.");
                Console.WriteLine("You can use them to store sandwiches, fruit, or cheese!");
                Console.WriteLine("Imagine conserving nature while avoiding plastic waste. That’s the power of pollinators❗");
                Console.WriteLine();

                CharactersManager.NPC_Color("timmy");
                Console.WriteLine(" 😲 Whoa, that’s so cool! I want to protect bees now to help the planet!");
                ConsoleContinue();

                ConsoleClear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("The audience murmurs, nodding in agreement with Darwin's logic.");
                Console.ResetColor();
                ConsoleContinue();

                ConsoleClear();
                CharactersManager.NPC_Color("mathmany");
                Console.WriteLine(" Good job, Darwin. That should be his last argument.");
                ConsoleContinue();

                question1Correct = true;
            }
            else if (playerResponse == "2")
            {
                csapoints--;

                // Shorter agreement with Donald in Option 1
                ConsoleClear();
                Console.WriteLine("You’re right. Synthetic techniques are more efficient, and they can work better for large-scale production.");
                ConsoleContinue();

                ConsoleClear();
                CharactersManager.NPC_Color("donald");
                Console.WriteLine(" Exactly! And with that, we’ll leave the bees behind where they belong.");
                ConsoleContinue();

                ConsoleClear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The audience nods, agreeing with Donald’s logic.");
                Console.ResetColor();
                ConsoleContinue();

                ConsoleClear();
                CharactersManager.NPC_Color("mathmany");
                Console.WriteLine(" You could’ve challenged him more, Darwin.");
                Console.WriteLine("Hopefully, your previous arguments left an impact on the audience.");
                ConsoleContinue();

                question1Correct = true;
            }
            else
            {  
                InvalidAnswerDonald();
            }
        }
        // Transition
        transition.EmojiTransition("🥉 🥈", "🥇");

        if (csapoints < 0)
        {
            ConsoleClear();
            CharactersManager.NPC_Color("donald");
            Console.WriteLine(" Folks, we’ve got the best solar panels in the world. No bees, no bugs—just clean energy.");         
            Console.WriteLine("Trust me, you don’t want pests buzzing around your homes and farms.");  
            Console.WriteLine("We’re building a future that’s better, cleaner, and smarter."); 
            ConsoleContinue();

            ConsoleClear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("The crowd erupts into applause, cheering in agreement.");
            Console.ResetColor();
            Console.Write("\n👀 Darwin glances at ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Write(" Mathmany ");
            Console.ResetColor();
            Console.WriteLine(", concern on his face.");
            Console.ResetColor();
            ConsoleContinue();

            ConsoleClear();
            CharactersManager.NPC_Color("mathmany");
            Console.WriteLine(" They don’t understand. He’s spinning this as progress while ignoring the damage it causes.");
            ConsoleContinue();

            ConsoleClear();
            CharactersManager.NPC_Color("nova");
            Console.WriteLine(" Darwin, I’ll send you back in time. Ironically, the only upside to these solar panels");
            Console.WriteLine("is that their energy powers our teleporter.");
            Console.WriteLine("Go back and try again to convince Donald and the people to respect nature.");
            ConsoleContinue();

            ConsoleClear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("And so Darwin goes back in time to debate ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Red;
            Console.Write(" Donald ");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(" once again.");
            Console.ResetColor();
            WriteParagraph();
            Console.WriteLine("(Answer at least 2 questions correctly to progress the story.)");
            Console.ResetColor();
            ConsoleContinue();

            DonaldGameIntro();
        }
            else
            {  
                ConsoleClear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("The audience erupts into applause as Darwin makes his final statement, confidently summarizing his arguments.");
                Console.ResetColor();
                ConsoleContinue();

                ConsoleClear();
                CharactersManager.NPC_Color("donald");
                Console.WriteLine(" 😞 But my solar farms... The land... What about that?");
                ConsoleContinue();

                ConsoleClear();
                Console.WriteLine("You’re in a unique position to lead change. Why not integrate pollinator-friendly practices");
                Console.WriteLine("into your solar farms? Studies show that solar farms with native plants and pollinator habitats thrive.");
                Console.WriteLine("Your farms could generate clean energy and protect biodiversity.");
                ConsoleContinue();

                ConsoleClear();
                CharactersManager.NPC_Color("donald");
                Console.WriteLine(" Solar farms... with pollinator habitats? That would put CSA on the map for the right reasons.");
                ConsoleContinue();

                ConsoleClear();
                Console.WriteLine("And you’d be helping the planet. By collaborating with nature, you’re not just producing energy—");
                Console.WriteLine("you’re securing food systems and a sustainable future.");
                ConsoleContinue();

                ConsoleClear();
                CharactersManager.NPC_Color("donald");
                Console.Write(" I never thought of it that way. Maybe… Maybe I’ve been wrong. I’m sorry, Darwin and ");
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.DarkYellow;
                Console.Write(" Timmy ");
                Console.ResetColor();
                Console.Write(". And ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.Write(" Mathmany ");
                Console.ResetColor();
                Console.WriteLine(".");
                Console.WriteLine("And to all the pollinators I’ve spoken out against. I’ll make this right!");
                ConsoleContinue();
                
                ConsoleClear();
                CharactersManager.NPC_Color("mathmany");
                Console.WriteLine(" Thank you so much Darwin 🤗");
                Console.WriteLine();

                Console.WriteLine("\n");
                string[] ArtLines = {
                    "                           ,   |   ,                                           ",
                    "                      \\               /                                       ",
                    "                           ,,_--_,                  .' '.            __     💖",
                    "                    \\./   ,// _  _\\   \\./  .        .   .           (__\\_  ",
                    "                    ;;;\\   //  o  o  /;;;     .         .         . -{{_(|8)  ",
                    "      //)     .'.    \\  \\  |    _\\  /  /      ' .  . ' ' .  . '     (__/    ",
                    "     ⸨ ■ -.   . 💖    \\  \\  \\  O / /  /                                     ",
                    "      \"\" '. . ' '      \\ `-'\\__/-' /                      .' '.             ",
                    "                          \\   \\/  /          ❤️    //)    .   .       .     ",
                    "                           |  /\\ |                ⸨ ■ -.      .        .      ",
                    "                           | |//||                  \"\"'. . ' ' .  . '        ",
                    "                           |  \\/ |                                            ",
                    "           .' '.        .--'-----'-----.                                       ",
                    "  .        .   .       /|              |     (\\\\   💖                       ",
                    "   .         .        / |              |   .- ■ )                              ",
                    "       .  . ' ' .  . '| |     d888b    |. .   \"\"                             ",
                    "                      | |   d8888888b  |                                       ",
                    "                      | |   888888888  |                                       "
                };

                foreach (var line in ArtLines)
                {
                    for (int i = 0; i < line.Length; i++)
                    {
                        char currentChar = line[i];

                        if (currentChar == '8' || currentChar == 'd' || currentChar == 'b' || currentChar == '■' || currentChar == ')'|| currentChar == '{' | currentChar == '⸨')
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow; // Sun
                        }
                        else if (currentChar == '.' || currentChar == '\'')
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGray; // Tracks 2
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
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Red;
                Console.Write(" Donald ");
                Console.ResetColor();
                Console.WriteLine(" pledged to transform CSA into a beacon of sustainability. His solar farms would now");
                Console.WriteLine("include pollinator gardens, ensuring a future where technology and nature thrive together.");
                question1Correct = true;   
            }
    }

    //Invalid Answer for Donald game (2 choices)
    public static void InvalidAnswerDonald()
    {
        ConsoleClear();
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
        Console.WriteLine();
        ConsoleContinue();
    }

    PointSystem pointSystem = new PointSystem();
    public void Enter()
    {
        string action = " ";
        //var E2Map = new Map();
        EraTitle eraTitle = new EraTitle();
        eraTitle.Print("Welcome to Era 2 Bees!");

        Console.WriteLine();
        Console.WriteLine();
        CharactersManager.NPC_Color("nova");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(" You have teleported to Era2 to save the bees!"); // Show arrival text
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
        Console.WriteLine(" era 2 bees?");

        action = Console.ReadLine()!.Trim().ToLower();

        while (action != "enter")
        {
                if (action == "map") {
                        Map.DisplayMap("Era2Bees");
                        action = Console.ReadLine()!.Trim().ToLower();
                }
                else if (action != "enter") {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nInvalid choice.");
                    Console.ResetColor();
                    action = Console.ReadLine()!.Trim().ToLower();
                }
        }
        if (action == "enter") 
        {
            Console.Clear();
            FirstEncounter();

            using (var audioFile = new AudioFileReader("Music/winnerwinnerchickendinner.mp3"))
            using (var sound = new WaveOutEvent())
            {
                sound.Init(audioFile);
                sound.Play();
                
                ConsoleContinue();
                sound.Stop();
            }

            // Add points to Era 2 Bees
            PointSystem.Instance.AddPoints(2, 2);  // 2 points for Era2Bees (2)

            // Display the points earned across all eras
            PointSystem.Instance.DisplayPointsEarned();
        }
    }
}