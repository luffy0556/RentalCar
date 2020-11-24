using System;

namespace CarRentalService
{
    sealed class Util
    {
        public static double ReadDouble(string input, double def)
        {
            double d = double.TryParse(input, out d) ? d : def;
            return d;
        }

        public static int ReadInt(string input, int def)
        {
            int i = int.TryParse(input, out i) ? i : def;
            return i;
        }

        public static bool ReadBool(string input, bool def)
        {
            bool b = bool.TryParse(input, out b) ? b : def;
            return b;
        }
    }
}