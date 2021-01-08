using System;

namespace Kata.Main.Tools
{
    public static class MathExtensions
    {
        public static double NthRoot(double number, double root)
        {
            return Math.Pow(number, 1.0 / root);            
        }
    }
}
