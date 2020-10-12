using System;

namespace Kata.Main.Algorithms
{
    public class GradeStudernts
    {
        public static int[] gradingStudents(int[] grades)
        {
            var roundedGrades = new int[grades.Length];
            for (int i = 0; i < grades.Length; i++)
            {
                if (grades[i] >= 38)
                {
                    var roundGrade = (int)Math.Ceiling((decimal)grades[i] / 5) * 5;
                    if (roundGrade - grades[i] <= 2)
                    {
                        roundedGrades[i] = roundGrade;
                        continue;
                    }
                }
                roundedGrades[i] = grades[i];
            }
            return roundedGrades;
        }
    }
}
