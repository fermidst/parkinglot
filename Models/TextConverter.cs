using System;

namespace ParkingLot.Models
{
    public class TextConverter
    {
        private readonly Func<string, string> _conversion;

        public TextConverter(Func<string, string> conversion)
        {
            _conversion = conversion;
        }

        public string ConvertText(string inputText) => _conversion(inputText);
    }
}