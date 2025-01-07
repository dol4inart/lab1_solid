using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using SOLIDLibraryClasses.Classes;
using SOLIDLibraryClasses.ClassesForInterfaces;
using SOLIDLibraryClasses.Interfaces;

namespace solid_TP
{
    class Program
    {
        static void Main(string[] args)
        {

            IInput input = new ConsoleInput();
            IOutput output = new ConsoleOutput();
            ISettings settings = new GameSettings();

            bool playAgain = false;
            bool changeSettings = false;

            do
            {
                int min, max, maxAttempts;
                if (!playAgain)
                {
                    output.Print("Enter minimum number for the range:");
                    min = int.Parse(input.GetInput());

                    output.Print("Enter maximum number for the range:");
                    max = int.Parse(input.GetInput());

                    output.Print("Enter maximum number of attempts:");
                    maxAttempts = int.Parse(input.GetInput());

                    //обработка пользовательской глупости
                    int errors = 0;
                    while (min > max)
                    {
                        if (errors == 3)
                        {
                            output.Print("I'm so sorry, but you stupid gamer! Exiting...");
                            return;
                        }
                        errors++;
                        output.Print("Maximum number can't be lower than minimum number! Try again.");
                        output.Print("Enter minimum number for the range:");
                        min = int.Parse(input.GetInput());

                        output.Print("Enter maximum number for the range:");
                        max = int.Parse(input.GetInput());

                        output.Print("Enter maximum number of attempts:");
                        maxAttempts = int.Parse(input.GetInput());

                    }

                    settings = new GameSettings(min, max, maxAttempts);
                }
                GuessingGame game = new GuessingGame(input, output, settings);
                game.Play();

                output.Print("Do you want to play again? (yes/no)");
                playAgain = input.GetInput().ToLower() == "yes";

                if (playAgain)
                {
                    output.Print("Do you want to change the settings? (yes/no)");
                    changeSettings = (input.GetInput().ToLower() == "yes");
                    if (changeSettings)
                    {
                        output.Print("Enter new minimum number for the range:");
                        min = int.Parse(input.GetInput());

                        output.Print("Enter new maximum number for the range:");
                        max = int.Parse(input.GetInput());

                        output.Print("Enter new maximum number of attempts:");
                        maxAttempts = int.Parse(input.GetInput());

                        settings = new GameSettings(min, max, maxAttempts);
                    }
                }
            } while (playAgain);
            output.Print("Thanks for playing :)");
        }
    }
}
