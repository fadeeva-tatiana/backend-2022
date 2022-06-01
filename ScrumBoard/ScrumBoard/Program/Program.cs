using ScrumBoard.Creator;
using ScrumBoard.Body;

namespace ScrumBoard
{
    class Program
    {
        private static string PriorityOfTasks(Task_priority priority)
        {
            switch (priority)
            {
                case Task_priority.HARD:
                    return "HARD";
                case Task_priority.MEDIUM:
                    return "MEDIUM";
                case Task_priority.EASY:
                    return "EASY";
                case Task_priority.NONE:
                    return "NONE";
                default:
                    return "";
            }
        }
        private static IBoard ActivateBoard()
        {
            IBoard board = ScrumBoardCreator.CreateBoard("First ScrumBoard");

            IColumn Need_To_Do_Column = ScrumBoardCreator.CreateColumn("Need To Do");
            IColumn In_Progress_Column = ScrumBoardCreator.CreateColumn("In Progress");
            IColumn Completed_Column = ScrumBoardCreator.CreateColumn("Completed");
            board.AddColumn(Need_To_Do_Column);
            board.AddColumn(In_Progress_Column);
            board.AddColumn(Completed_Column);

            return board;
        }

        private static void PrintBoard(IBoard board) //Печатаем в консоль Доску
        {
            foreach (IColumn column in board.FindColumns())
            {
                PrintColumn(column);
            }
        }

        private static void PrintColumn(IColumn column) //Печатаем в консоль колонки
        {
            Console.WriteLine($"| {column.Title} |");
            PrintTasks(column);
        }

        public static void Main(string[] args)
        {
            IBoard board = ActivateBoard();
            Console.WriteLine("Start boards\n");
            PrintBoard(board);

            //Добавляем первое задание 
            ITask FinishTheApp = ScrumBoardCreator.CreateTask("Finish the app", "Complete as soon as possible", Task_priority.HARD);
            board.AddTaskToColumn(FinishTheApp, "In Progress");
            Console.WriteLine("\nTask added in \"In Progress\" \n");
            PrintBoard(board);

            board.RenameTask("Finish the app", "Create an app");
            board.ChangeTaskDescription("Create an app", "complete to deadline, but it's not soon");
            board.ChangeTaskPriority("Create an app", Task_priority.MEDIUM);
            Console.WriteLine("\nApp task are updated\n");
            PrintBoard(board);

            //Добавляем второе задание
            ITask WipeTheDust = ScrumBoardCreator.CreateTask("Wipe the dust", "Too much dust in the room", Task_priority.EASY);
            board.AddTaskToColumn(WipeTheDust);
            Console.WriteLine("\nSecond task has added\n");
            PrintBoard(board);

            board.MoveTask("Wipe the dust");
            Console.WriteLine("\nTask moved\n");
            PrintBoard(board);

            board.MoveTask( "Create an app");
            board.MoveTask("Wipe the dust");
            Console.WriteLine("\nAll tasks completed\n");
            PrintBoard(board);

            board.DeleteTask("Create an app");
            board.DeleteTask("Wipe the dust");
            Console.WriteLine("\nAll tasks are deleted\n");
            PrintBoard(board);
        }
        private static void PrintTasks(IColumn column) //Печатаем в консоль задания
        {
            foreach (ITask task in column.FindTasks())
            {
                PrintTask(task);
            }
        }

        private static void PrintTask(ITask task) //Печатаем [Приоритет задачи] Название: Описание
        {
            Console.WriteLine($"  [{PriorityOfTasks(task.Priority)}] {task.Title}: {task.Description}");
        }
    }
}