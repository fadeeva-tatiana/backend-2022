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
        private IBoard trial_Board()
        {
            return ScrumBoardCreator.CreateBoard(trial_Title);
        }

        private IColumn trial_Column()
        {
            return ScrumBoardCreator.CreateColumn(trial_Column_Title);
        }

        private ITask trial_Task()
        {
            return ScrumBoardCreator.CreateTask(trial_Task_Title, trial_Description, trial_Priority);
        }

        [Fact]
        public void IfCountOfColumnsMoreThan10()
        {
            //Arrange
            IBoard board = trial_Board();
            //Act
            for (int n = 0; n < 10; n++)
            {
                board.AddColumn(ScrumBoardCreator.CreateColumn(n.ToString()));
            }
            //Assert
            Assert.Throws<Maximum_columns>(() => board.AddColumn(trial_Column()));
        }

        [Fact]
        public void CreateBoard()
        {
            //Arrange
            IBoard board = trial_Board();
            //Act

            //Assert
            Assert.Equal(trial_Title, board.Title);
        }

        [Fact]
        public void FindColumnByTitleOnBoard()
        {
            //Arrange
            IBoard board = trial_Board();
            IColumn column = trial_Column();
            //Act
            board.AddColumn(column);
            //Assert
            Assert.Equal(column, board.FindColumnByTitle(column.Title));
        }

        [Fact]
        public void DeleteTaskFromColumn()
        {
            //Arrange
            IBoard board = trial_Board();
            IColumn column = trial_Column();
            board.AddColumn(column);
            ITask task = trial_Task();
            column.AddTask(task);
            //Act
            board.DeleteTask(task.Title);
            //Assert
            Assert.Empty(column.FindTasks());
        }
        [Fact]
        public void MoveTasksOnBoard()
        {
            //Arrange
            IBoard board = trial_Board();
            IColumn column_Number1 = ScrumBoardCreator.CreateColumn("Number1");
            IColumn column_Number2 = ScrumBoardCreator.CreateColumn("Number2");
            board.AddColumn(column_Number1);
            board.AddColumn(column_Number2);
            ITask task = trial_Task();
            board.AddTaskToColumn(task);
            //Act
            board.MoveTask(task.Title);
            //Assert
            Assert.Empty(column_Number1.FindTasks());
            Assert.Collection(column_Number2.FindTasks(),
            column_Task => Assert.Equal(task, column_Task));
        }

    }
}