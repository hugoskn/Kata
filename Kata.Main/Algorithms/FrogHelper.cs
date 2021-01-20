namespace Kata.Main.Algorithms
{
    class FrogHelper
    {
        public static int FrogLeaps(int X, int Y, int D)
        {
            if (X == Y)
                return 0;
            if (X + D >= Y)
                return 1;

            var distanceLeft = Y - (X + D);
            var jumpsLeft = distanceLeft / D;
            return distanceLeft % D == 0 ? jumpsLeft + 1 : jumpsLeft + 2;
        }
    }
}
