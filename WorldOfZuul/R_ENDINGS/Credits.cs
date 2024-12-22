using System;
using System.Collections.Generic;
using System.Diagnostics;
using NAudio.Wave; // -> dotnet add package NAudio

public class Credits
{
    public void PrintCredits()
    {
        // Ask player for their name
        CharactersManager.NPC_Color("nova");
        Console.WriteLine(" And of course, thank you for guiding Darwin on this adventure to improve our ecosystem.");
        Console.WriteLine();

        CharactersManager.NPC_Color("nova");
        Console.WriteLine(" Now, before you go, may I know your name? ");
        Console.WriteLine();
        Console.Write(" ➡️ Enter your name: ");

        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.Blue;
        string playerName = Console.ReadLine() ?? "Player"; // "Player" as a default
        Console.ResetColor();

        Console.WriteLine();
        CharactersManager.NPC_Color("nova");
        Console.Write(" Thank you, ");

        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.Blue;
        Console.Write($" {playerName} ");
        Console.ResetColor();

        Console.WriteLine(", for playing Darwin's Quest. Your journey made all the difference. Have a wonderful day!");

        // Credits
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("🤖 PRESS ANY KEY");
        Console.ResetColor();
        Console.WriteLine(" to continue...");

        // Wait for user input
        Console.ReadKey(true);
        Console.Clear();

        int width = Console.WindowWidth;

        string[] asciiArt = new string[]
        {
            @" ____                      _       _        ___                  _   ",
            @"|  _ \  __ _ _ ____      _(_)_ __ ( )___   / _ \ _   _  ___  ___| |_ ",
            @"| | | |/ _` | '__\ \ /\ / / | '_ \|// __| | | | | | | |/ _ \/ __| __|",
            @"| |_| | (_| | |   \ V  V /| | | | | \__ \ | |_| | |_| |  __/\__ \ |_ ",
            @"|____/ \__,_|_|    \_/\_/ |_|_| |_| |___/  \__\_\\__,_|\___||___/\__|"
        };

        // Credits with feedback section
        string[] credits = new string[]
        {
            "╔═══════════════════════════════════════════════════════════════════╗",
            "║               Made by First-Semester Software Students            ║",
            "║                                                                   ║",
            "║                       We'd ❤️ your (F)eedback!                    ║",
            "╚═══════════════════════════════════════════════════════════════════╝",
            "",
            "                📍 South Denmark University, Sønderborg             ",
            "",
            "                           ===== CREDITS =====                       ",
            "",
            "╔═══════════════════════════════════════════════════════════════════╗",
            "║ Introduction and Endings 📜 .............. Luigi Colluto          ║",
            "║                                                                   ║",
            "║ Era 1 ☀️ ................................. Klara Delia            ║",
            "║                                                                   ║",
            "║ Era 2 (Bees) 🐝 .......................... Lukas Ekkert           ║",
            "║                                                                   ║",
            "║ Era 2 (Corals) 🪸 ........................ Arda Atakol            ║",
            "║                                                                   ║",
            "║ Era 3 ♻️ ................................. Manish Raj Moriche     ║",
            "╚═══════════════════════════════════════════════════════════════════╝",
            "",
            "                     For more info type S, P or F                    ",
            "",
            "(S)upervisor                                              (P)rofessor"
        };

        void PrintCenteredContent(List<string> additionalInfo)
        {
            Console.Clear();
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            foreach (string line in asciiArt)
            {
                Console.WriteLine(line.PadLeft((width + line.Length) / 2));
            }
            Console.ResetColor();

            Console.WriteLine();

            foreach (string line in credits)
            {
                if (line.Contains("(F)eedback"))
                {
                    string before = line.Substring(0, line.IndexOf("(F)"));
                    string highlight = "(F)";
                    string after = line.Substring(line.IndexOf("(F)") + 3);

                    Console.Write(before.PadLeft((width + line.Length) / 2 - (line.Length - before.Length)));
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write(highlight);
                    Console.ResetColor();
                    Console.Write(after);
                    Console.WriteLine();
                }
                else if (line.Contains("(S)upervisor") || line.Contains("(P)rofessor"))
                {
                    int paddingLeft = (width + line.Length) / 2 - line.Length;
                    Console.Write(new string(' ', paddingLeft)); // Add left padding

                    string[] parts = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    
                    for (int i = 0; i < parts.Length; i++)
                    {
                        if (parts[i].StartsWith("(S)") || parts[i].StartsWith("(P)"))
                        {
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.Write(parts[i].Substring(0, 3));
                            Console.ResetColor();
                            Console.Write(parts[i].Substring(3));
                        }
                        else
                        {
                            Console.Write(parts[i]);
                        }
                        if (i < parts.Length - 1)
                        {
                            int spacesToAdd = line.IndexOf(parts[i + 1]) - (line.IndexOf(parts[i]) + parts[i].Length);
                            Console.Write(new string(' ', spacesToAdd));
                        }
                    }
                    Console.WriteLine();
                }
                else if (line.Contains("For more info type S, P or F"))
                {
                    int paddingLeft = (width + line.Length) / 2 - line.Length;
                    Console.Write(new string(' ', paddingLeft));

                    string[] parts = line.Split(' ');
                    
                    foreach (string part in parts)
                    {
                        if (part == "S," || part == "P" || part == "F")
                        {
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.Write(part);
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.Write(part);
                        }
                        Console.Write(" ");
                    }
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine(line.PadLeft((width + line.Length) / 2));
                }
            }

            if (additionalInfo.Count > 0)
            {
                Console.WriteLine();
                foreach (string line in additionalInfo)
                {
                    Console.WriteLine(line.PadLeft((width + line.Length) / 2));
                }
            }
        }

        List<string> additionalInfo = new List<string>();
        PrintCenteredContent(additionalInfo);

        bool supervisorShown = false;
        bool professorShown = false;

        while (true)
        {
            // Music
        using (var audioFile = new AudioFileReader("Music/credits.mp3"))
        using (var sound = new WaveOutEvent())
        {
            sound.Init(audioFile);
            sound.Play();
            var key = Console.ReadKey(true).Key;
            sound.Stop();
            
            if (key == ConsoleKey.S && !supervisorShown)
            {
                additionalInfo.Add("╔═══════════════════════════════════════════════════════════════════╗");
                additionalInfo.Add("║ 📌 Supervisor: Aleksandra Maria Kril                              ║");
                additionalInfo.Add("║ Second-Year Software Engineering Student                          ║");
                additionalInfo.Add("╚═══════════════════════════════════════════════════════════════════╝");
                supervisorShown = true;
                PrintCenteredContent(additionalInfo);
            }
            else if (key == ConsoleKey.P && !professorShown)
            {
                additionalInfo.Add("");
                additionalInfo.Add("╔═══════════════════════════════════════════════════════════════════╗");
                additionalInfo.Add("║ 📌 Professor: Mubashrah Saddiqa                                   ║");
                additionalInfo.Add("║ Coordinator for Software First-Semester Projects                  ║");
                additionalInfo.Add("╚═══════════════════════════════════════════════════════════════════╝");
                professorShown = true;
                PrintCenteredContent(additionalInfo);
            }
            else if (key == ConsoleKey.F)
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = "https://docs.google.com/forms/d/e/1FAIpQLSepaiI6StqAGZBac9ib0zF2SkEw1VMte-f58OmVYVGJLhMLpg/viewform", // Survey Link
                    UseShellExecute = true
                });
            }
        }
        }
    }
}