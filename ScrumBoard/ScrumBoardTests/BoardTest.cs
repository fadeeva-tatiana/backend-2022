using Xunit;
using ScrumBoard.Creator;
using ScrumBoard.Body;
using ScrumBoard.SpecialCases;

namespace ScrumTest
{
    public class BoardTest
    {
        //Объявление названий строк
        private string trial_Title = "Board Title";
        private string trial_Column_Title = "Column Title";
        private string trial_Task_Title = "Task Title";
        private string trial_Description = "Description";
        private Task_priority trial_Priority = Task_priority.MEDIUM;
        private BoardInterface trial_Board()
        {
            return ScrumBoardCreator.Create_board(trial_Title);
        }

        private ColumnInterface trial_Column()
        {
            return ScrumBoardCreator.Create_column(trial_Column_Title);
        }

        private TaskInterface trial_Task()
        {
            return ScrumBoardCreator.Create_task(trial_Task_Title, trial_Description, trial_Priority);
        }

        [Fact]
        public void If_count_of_columns_more_than_10()
        {
            //Arrange
            BoardInterface board = trial_Board();
            //Act
            for (int n = 0; n < 10; n++)
            {
                board.Add_column(ScrumBoardCreator.Create_column(n.ToString()));
            }
            //Assert
            Assert.Throws<MaximumColumns>(() => board.Add_column(trial_Column()));
        }

        [Fact]
        public void Create_board()
        {
            //Arrange
            BoardInterface board = trial_Board();
            //Act

            //Assert
            Assert.Equal(trial_Title, board.Title);
        }

        [Fact]
        public void Find_column_by_title_on_board()
        {
            //Arrange
            BoardInterface board = trial_Board();
            ColumnInterface column = trial_Column();
            //Act
            board.Add_column(column);
            //Assert
            Assert.Equal(column, board.Find_column_by_title(column.Title));
        }

        [Fact]
        public void Delete_task_from_column()
        {
            //Arrange
            BoardInterface board = trial_Board();
            ColumnInterface column = trial_Column();
            board.Add_column(column);
            TaskInterface task = trial_Task();
            column.Add_task(task);
            //Act
            board.Delete_task(task.Title);
            //Assert
            Assert.Empty(column.Find_tasks());
        }
        [Fact]
        public void Move_tasks_on_board()
        {
            //Arrange
            BoardInterface board = trial_Board();
            ColumnInterface column_Number1 = ScrumBoardCreator.Create_column("Number1");
            ColumnInterface column_Number2 = ScrumBoardCreator.Create_column("Number2");
            board.Add_column(column_Number1);
            board.Add_column(column_Number2);
            TaskInterface task = trial_Task();
            board.Add_task_to_column(task);
            //Act
            board.Move_task(task.Title);
            //Assert
            Assert.Empty(column_Number1.Find_tasks());
            Assert.Collection(column_Number2.Find_tasks(),
            column_Task => Assert.Equal(task, column_Task));
        }

    }
}