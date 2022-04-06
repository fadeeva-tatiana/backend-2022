namespace ScrumBoard.SpecialCases
{
    public class MaximumColumns : System.Exception
    {
        public MaximumColumns()
            : base("the number of columns on the board is exceeded, the maximum count of columns is 10")
        {
        }
    }
}