namespace Kata.Main.Algorithms
{
    public class PasswordStrength
    {
        public static int MinimumNumberForPasswordStrength(int n, string password)
        {
            var numbers = "0123456789";
            var lower_case = "abcdefghijklmnopqrstuvwxyz";
            var upper_case = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var special_characters = "!@#$%^&*()-+";
            bool numberDetected = false;
            bool lowerDetected = false;
            bool upperDetected = false;
            bool specialDetected = false;
            var criteria = 4;
            foreach (var s in password)
            {
                if (!numberDetected && numbers.Contains(s))
                {
                    criteria--;
                    numberDetected = true;
                }
                else if (!lowerDetected && lower_case.Contains(s))
                {
                    criteria--;
                    lowerDetected = true;
                }
                else if (!upperDetected && upper_case.Contains(s))
                {
                    criteria--;
                    upperDetected = true;
                }
                else if (!specialDetected && special_characters.Contains(s))
                {
                    criteria--;
                    specialDetected = true;
                }
            }

            return n >= 6 ? criteria : criteria > 6 - n ? criteria : 6 - n;
        }
    }
}
