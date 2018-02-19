using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            base.Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
                throw new InvalidOperationException();
            var thresh = (int)Math.Ceiling(Students.Count * 0.2);
            var average = Students.OrderByDescending(e => e.AverageGrade).Select(e => e.AverageGrade).ToList();
            if (averageGrade >= average[thresh - 1])
                return 'A';
            else if (averageGrade >= average[(thresh * 2) - 1])
                return 'B';
            else if (averageGrade >= average[(thresh * 3) - 1])
                return 'C';
            else if (averageGrade >= average[(thresh * 4) - 1])
                return 'D';            
            return 'F';
        }
    }
}
