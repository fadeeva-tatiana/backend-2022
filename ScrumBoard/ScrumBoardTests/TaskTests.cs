using Xunit;
using ScrumBoard.Creator;
using ScrumBoard.Body;

namespace ScrumTest
{
    public class TaskTests
    {
        private TaskInterface trial_Task()
        {
            return ScrumBoardCreator.Create_task(trial_Title, trial_Description, trial_Priority);
        }
        private string trial_Title = "Title";
        private string trial_Description = "Description";
        private Task_priority trial_Priority = Task_priority.MEDIUM;

        [Fact]
        public void Create_task_to_column()
        {
            //Arrange
            TaskInterface task = trial_Task();
            //Act

            //Assert
            Assert.Equal(trial_Title, task.Title);
            Assert.Equal(trial_Description, task.Description);
            Assert.Equal(trial_Priority, task.Priority);
        }

        [Fact]
        public void Rename_task_title()
        {
            //Arrange
            TaskInterface task = trial_Task();
            string newTitle = "Updated";
            //Act
            task.Title = newTitle;
            //Assert
            Assert.Equal(newTitle, task.Title);
        }

        [Fact]
        public void Change_task_priority()
        {
            //Arrange
            TaskInterface task = trial_Task();
            Task_priority newPriority = Task_priority.HARD;
            //Act
            task.Priority = newPriority;
            //Assert
            Assert.Equal(newPriority, task.Priority);
        }

        [Fact]
        public void Rename_task_description()
        {
            //Arrange
            TaskInterface task = trial_Task();
            string newDescription = "Updated";
            //Act
            task.Description = newDescription;
            //Assert
            Assert.Equal(newDescription, task.Description);
        }
    }
}