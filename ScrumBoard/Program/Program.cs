using ScrumBoard.Creator;
using ScrumBoard.Body;

namespace ScrumBoard
{
    class Program
    {
        private static string Priority_of_tasks(Task_priority priority)
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
        private static BoardInterface Activate_board()
        {
            BoardInterface board = ScrumBoardCreator.Create_board("First ScrumBoard");

            ColumnInterface Need_To_Do_Column = ScrumBoardCreator.Create_column("Need To Do");
            ColumnInterface In_Progress_Column = ScrumBoardCreator.Create_column("In Progress");
            ColumnInterface Completed_Column = ScrumBoardCreator.Create_column("Completed");
            board.Add_column(Need_To_Do_Column);
            board.Add_column(In_Progress_Column);
            board.Add_column(Completed_Column);

            return board;
        }

        private static void Print_board(BoardInterface board) //Печатаем в консоль Доску
        {
            foreach (ColumnInterface column in board.Find_columns())
            {
                Print_column(column);
            }
        }

        private static void Print_column(ColumnInterface column) //Печатаем в консоль колонки
        {
            Console.WriteLine($"| {column.Title} |");
            Print_tasks(column);
        }

        public static void Main(string[] args)
        {
            BoardInterface board = Activate_board();
            Console.WriteLine("Start boards\n");
            Print_board(board);

            //Добавляем первое задание 
            TaskInterface FinishTheApp = ScrumBoardCreator.Create_task("Finish the app", "Complete as soon as possible", Task_priority.HARD);
            board.Add_task_to_column(FinishTheApp, "In Progress");
            Console.WriteLine("\nTask added in \"In Progress\" \n");
            Print_board(board);

            board.Rename_task("Finish the app", "Create an app");
            board.Change_task_description("Create an app", "complete to deadline, but it's not soon");
            board.Change_task_priority("Create an app", Task_priority.MEDIUM);
            Console.WriteLine("\nApp task are updated\n");
            Print_board(board);

            //Добавляем второе задание
            TaskInterface WipeTheDust = ScrumBoardCreator.Create_task("Wipe the dust", "Too much dust in the room", Task_priority.EASY);
            board.Add_task_to_column(WipeTheDust);
            Console.WriteLine("\nSecond task has added\n");
            Print_board(board);

            board.Move_task("Wipe the dust");
            Console.WriteLine("\nTask moved\n");
            Print_board(board);

            board.Move_task("Create an app");
            board.Move_task("Wipe the dust");
            Console.WriteLine("\nAll tasks completed\n");
            Print_board(board);

            board.Delete_task("Create an app");
            board.Delete_task("Wipe the dust");
            Console.WriteLine("\nAll tasks are removed\n");
            Print_board(board);
        }
        private static void Print_tasks(ColumnInterface column) //Печатаем в консоль задания
        {
            foreach (TaskInterface task in column.Find_tasks())
            {
                Print_task(task);
            }
        }

        private static void Print_task(TaskInterface task) //Печатаем [Приоритет задачи] Название: Описание
        {
            Console.WriteLine($"  [{Priority_of_tasks(task.Priority)}] {task.Title}: {task.Description}");
        }
    }
}