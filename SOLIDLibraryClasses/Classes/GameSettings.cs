using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SOLIDLibraryClasses.Interfaces;

namespace SOLIDLibraryClasses.Classes
{
    public class GameSettings : ISettings
    {
        public int Min { get; private set; }
        public int Max { get; private set; }
        public int MaxAttempts { get; private set; }

        public GameSettings(int min, int max, int maxAttempts)
        {
            if (min > max)
            {
                throw new ArgumentException("Maximum number can't be lower than minimum number.");
            }
            Min = min;
            Max = max;
            MaxAttempts = maxAttempts;
        }
        public GameSettings() { }
    }
}
