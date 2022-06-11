namespace ScrumBoard.Exception;

public class ColumnsLimitException : System.Exception
{
    public ColumnsLimitException() : base("Column limite is 10")
    {
    }
}