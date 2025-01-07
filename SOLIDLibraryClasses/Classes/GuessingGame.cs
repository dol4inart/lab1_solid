using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SOLIDLibraryClasses.Interfaces;

namespace SOLIDLibraryClasses.Classes
{
    public class GuessingGame
    {
        private readonly IInput _input;
        private readonly IOutput _output;
        private readonly ISettings _settings;
        private int _numberToGuess;

        public GuessingGame(IInput input, IOutput output, ISettings settings)
        {
            _input = input;
            _output = output;
            _settings = settings;
            _numberToGuess = new Random().Next(settings.Min, settings.Max + 1);
        }

        public void Play()
        {
            _output.Print($"Welcome to Guess the Number! Try to guess the number between {_settings.Min} and {_settings.Max}. You have {_settings.MaxAttempts} attempts.");

            for (int attempt = 1; attempt <= _settings.MaxAttempts; attempt++)
            {
                _output.Print($"Attempt {attempt}/{_settings.MaxAttempts}: Enter your guess:");
                if (int.TryParse(_input.GetInput(), out int guess))
                {
                    if (guess < _settings.Min || guess > _settings.Max)
                    {
                        _output.Print($"Please enter a number between {_settings.Min} and {_settings.Max}.");
                    }
                    else if (guess < _numberToGuess)
                    {
                        _output.Print("The number is higher.");
                    }
                    else if (guess > _numberToGuess)
                    {
                        _output.Print("The number is lower.");
                    }
                    else
                    {
                        _output.Print("Congratulations! You guessed the number.");
                        return;
                    }
                }
                else
                {
                    _output.Print("Invalid input. Please enter a valid number.");
                    attempt--;  // Не уменьшаем число попыток при некорректном вводе
                }
            }

            _output.Print($"Sorry, you've used all your attempts. The number was {_numberToGuess}.");
        }
    }
}
