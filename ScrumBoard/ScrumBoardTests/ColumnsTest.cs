using Xunit;
using ScrumBoard.Creator;
using ScrumBoard.Body;

namespace ScrumTest
{
    public class ColumnsTest
    {
        private string trial_Title = "Column title";
        private string trial_Task_Title = "Task title";
        private string trial_Description = "Description";
        private Task_priority trial_Priority = Task_priority.MEDIUM;

        [Fact]
        public void CreateColumnToBoard()
        {
            //Arrange
            IColumn column = trial_Column();
            //Act

            //Assert
            Assert.Equal(trial_Title, column.Title);
            Assert.Empty(column.FindTasks());
        }

        [Fact]
        public void Remove_task_from_column()
        {
            //Arrange
            IColumn column = trial_Column();
            ITask task = trial_Task();
            column.AddTask(task);
            //Act
            column.DeleteTaskByTitle(task.Title);
            //Assert
            Assert.Empty(column.FindTasks());
        }

        [Fact]
        public void AddTaskToColumnInBoard()
        {
            //Arrange
            IColumn column = trial_Column();
            ITask task = trial_Task();
            //Act
            column.AddTask(task);
            //Assert
            Assert.Collection(column.FindTasks(),
            columnTask => Assert.Equal(task, columnTask));
        }

        [Fact]
        public void ChangeColumnTitleInBoard()
        {
            //Arrange
            IColumn column = trial_Column();
            string newTitle = "Updated";
            //Act
            column.Title = newTitle;
            //Assert
            Assert.Equal(newTitle, column.Title);
        }

        private IColumn trial_Column()
        {
            return ScrumBoardCreator.CreateColumn(trial_Title); ;
        }

        private ITask trial_Task()
        {
            return ScrumBoardCreator.CreateTask(trial_Task_Title, trial_Description, trial_Priority);
        }
    }
}