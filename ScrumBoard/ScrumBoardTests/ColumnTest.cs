using Xunit;
using System.Collections.Generic;
using ScrumBoardLibrary.Task;
using ScrumBoardLibrary.Column;

namespace ScrumBoardTest
{
    public class ColumnTest
    {
        [Fact]
        public void CreateColumn_NewColumnWillCreate()
        {
            //Arrange
            string columnTitle = "Column title";
            //Act
            IColumn column = new Column(columnTitle);
            //Assert
            Assert.False(string.IsNullOrEmpty(column.ID));
            Assert.Equal(columnTitle, column.Title);
            Assert.Empty(column.GetAllTask());
        }

        [Fact]
        public void ChangeColumnTitle_ColumnTitleWillChange()
        {
            //Arrange
            string newColumnTitle = "Column title ver. 2";
            IColumn column = new Column("Column title");
            //Act
            column.Title = newColumnTitle;
            //Assert
            Assert.Equal(newColumnTitle, column.Title);
        }

        [Fact]
        public void AddTaskInColumn_NewTaskWillAdd()
        {
            //Arrange
            string columnName = "Column title";
            ITask task = new Task("Task", "Task description", TaskPriority.MEDIUM);
            IColumn column = new Column(columnName);
            //Act
            column.AddTask(task);
            //Assert
            Assert.Equal(task, column.GetAllTask()[0]);
        }

        [Fact]
        public void GetTaskFromColumn_ReturnAddedTaskFromColumn()
        {
            //Arrange
            ITask task = new Task("Task", "Task description", TaskPriority.MEDIUM);
            IColumn column = new Column("Column title");
            column.AddTask(task);
            //Act
            ITask? retTask = column.GetTask(task.ID);
            //Assert
            Assert.Equal(task, retTask);
        }

        [Fact]
        public void EditTaskInColumn_TaskInColumnWillEdit()
        {
            //Arrange
            string newTaskTitle = "Task title ver. 2";
            string newTaskDescription = "Task description ver. 2";
            ITask task = new Task("Task", "Task descritpion", TaskPriority.MEDIUM);
            IColumn column = new Column("Column title");
            column.AddTask(task);
            //Act
            column.EditTask(task.ID, newTaskTitle, newTaskDescription, TaskPriority.HARD);
            //Assert
            ITask? retTask = column.GetTask(task.ID);
            Assert.NotNull(retTask);
            Assert.Equal(newTaskTitle, retTask.Title);
            Assert.Equal(newTaskDescription, retTask.Description);
            Assert.Equal(TaskPriority.HARD, retTask.Priority);
        }

        [Fact]
        public void DeleteTaskInColumn_TaskWillDeleteFromColumn()
        {
            //Arrange
            ITask task = new Task("Task", "task description", TaskPriority.MEDIUM);
            IColumn column = new Column("Column title");
            column.AddTask(task);
            //Act
            column.DeleteTask(task.ID);
            //Assert
            Assert.Null(column.GetTask(task.ID));
        }

        [Fact]
        public void GetAllTaskFromColumn_AllTasksFromColumnWillReturn()
        {
            //Arrange
            ITask task1 = new Task("Task number 1", "Make a projekt (task 1)", TaskPriority.MEDIUM);
            ITask task2 = new Task("Task number 2", "Wash the floor (task 2)", TaskPriority.EASY);
            ITask task3 = new Task("Task number 3", "Cook the dishes (task 3)", TaskPriority.HARD);
            IColumn column = new Column("Column title");
            column.AddTask(task1);
            column.AddTask(task2);
            column.AddTask(task3);
            //Act
            List<ITask> taskList = column.GetAllTask();
            //Assert
            Assert.Equal(new List<ITask>() { task1, task2, task3 }, taskList);
        }
    }
}