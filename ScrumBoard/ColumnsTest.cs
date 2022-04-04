using Xunit;
using ScrumBoard.Creator;
using ScrumBoard.Body;

namespace ScrumTest
{
    public class ColumnsTest
    {
        [Fact]
        public void Create_column_to_board()
        {
            //Arrange
            ColumnInterface column = trial_Column();
            //Act

            //Assert
            Assert.Equal(trial_Title, column.Title);
            Assert.Empty(column.Find_tasks());
        }

        [Fact]
        public void Remove_task_from_column()
        {
            //Arrange
            ColumnInterface column = trial_Column();
            TaskInterface task = trial_Task();
            column.Add_task(task);
            //Act
            column.Delete_task_by_title(task.Title);
            //Assert
            Assert.Empty(column.Find_tasks());
        }

        [Fact]
        public void Add_task_to_column_in_board()
        {
            //Arrange
            ColumnInterface column = trial_Column();
            TaskInterface task = trial_Task();
            //Act
            column.Add_task(task);
            //Assert
            Assert.Collection(column.Find_tasks(),
            columnTask => Assert.Equal(task, columnTask));
        }

        [Fact]
        public void Change_column_title_in_board()
        {
            //Arrange
            ColumnInterface column = trial_Column();
            string newTitle = "Updated";
            //Act
            column.Title = newTitle;
            //Assert
            Assert.Equal(newTitle, column.Title);
        }

        private ColumnInterface trial_Column()
        {
            return ScrumBoardCreator.Create_column(trial_Title); ;
        }

        private TaskInterface trial_Task()
        {
            return ScrumBoardCreator.Create_task(trial_Task_Title, trial_Description, trial_Priority);
        }

        private string trial_Title = "Column title";
        private string trial_Task_Title = "Task title";
        private string trial_Description = "Description";
        private Task_priority trial_Priority = Task_priority.MEDIUM;
    }
}