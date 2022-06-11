using Xunit;
using ScrumBoardLibrary.Task;

namespace ScrumBoardTest
{
    public class TaskTest
    {
        [Fact]
        public void CreateTask_TaskWillCreate()
        {
            //Arrange
            string taskTitle = "Task title";
            string taskDescription = "Task description";
            //Act
            ITask task = new Task(taskTitle, taskDescription, TaskPriority.MEDIUM);
            //Assert
            Assert.False(string.IsNullOrEmpty(task.ID));
            Assert.Equal(taskTitle, task.Title);
            Assert.Equal(taskDescription, task.Description);
            Assert.Equal(TaskPriority.MEDIUM, task.Priority);
        }

        [Fact]
        public void ChangeTaskTitle_TaskTitleWillChange()
        {
            //Arrange
            string newTaskTitle = "Task title ver. 2";
            ITask task = new Task("Task", "Task description", TaskPriority.MEDIUM);
            //Act
            task.Title = newTaskTitle;
            //Assert
            Assert.Equal(newTaskTitle, task.Title);
        }

        [Fact]
        public void ChangeTaskDescription_TaskDescriptionWillChange()
        {
            //Arrange
            string newTaskDescription = "Task description ver. 2";
            ITask task = new Task("Task", "Task description", TaskPriority.MEDIUM);
            //Act
            task.Description = newTaskDescription;
            //Assert
            Assert.Equal(newTaskDescription, task.Description);
        }

        [Fact]
        public void ChangeTaskPriority_TaskPriorityWillChange()
        {
            //Arrange
            ITask task = new Task("Task", "Task description", TaskPriority.MEDIUM);
            //Act
            task.Priority = TaskPriority.EASY;
            //Assert
            Assert.Equal(TaskPriority.EASY, task.Priority);
        }
    }
}