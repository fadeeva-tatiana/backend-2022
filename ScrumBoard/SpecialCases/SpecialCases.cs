namespace ScrumBoard.SpecialCases
{
    public class MaximumNumbers : System.Exception
    {
        public MaximumNumbers()
            : base("the number of columns on the board is exceeded, the maximum count of columns is 10")
        {
        }
    }
}