using System;

namespace ResolutionHill.ViewModel.Helpers
{
    public static class ValueHelper
    {
        public static int InverseModulo26(int value)
        {
            int valueModulo26 = value%26;
            if (valueModulo26 < 0)
                valueModulo26 += 26;

            switch (valueModulo26)
            {
                case 1:
                    return 1;
                case 3:
                    return 9;
                case 5:
                    return 21;
                case 7:
                    return 15;
                case 9:
                    return 3;
                case 11:
                    return 19;
                case 15:
                    return 7;
                case 17:
                    return 23;
                case 19:
                    return 11;
                case 21:
                    return 5;
                case 23:
                    return 17;
                case 25:
                    return 25;
                default:
                    throw new Exception();
            }
        }

        public static int PGCD(int value1, int value2)
        {
            while (value1 != value2)
            {
                if (value1 > value2)
                    value1 -= value2;
                else
                    value2 -= value1;
            }

            return value1;
        }
    }
}
