using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    internal class StandardGradeBook : BaseGradeBook
    {
        public StandardGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
            Type = GradeBookType.Standard;
        }
    }
}
