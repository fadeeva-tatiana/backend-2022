using Xunit;
using System.Collections.Generic;
using ScrumBoardLibrary.Task;
using ScrumBoardLibrary.Column;
using ScrumBoardLibrary.Board;
using ScrumBoard.Exception;

namespace ScrumBoardTest
{
    public class BoardTest
    {
        [Fact]
        public void CreateBoard_BoardWillCreate()
        {
            //Arrange
            string boardTitle = "Название доски";
            //Act
            IBoard board = new Board(boardTitle);
            //Assert
            Assert.Equal(boardTitle, board.Title);
            Assert.Empty(board.GetAllColumn());
        }

        [Fact]
        public void AddColumnInBoard_NewColumnWillCreate()
        {
            //Arrange
            IColumn column = new Column("Column title");
            IBoard board = new Board("Board title");
            //Act
            board.AddColumn(column);
            //Assert
            Assert.Equal(column, board.GetAllColumn()[0]);
        }

        [Fact]
        public void AddAlreadyExistColumnInBoard_ExceptionWillReturn()
        {
            //Arrange
            IColumn column = new Column("Column title");
            IBoard board = new Board("Board title");
            board.AddColumn(column);
            //Act && Assert
            Assert.Throws<ColumnExistException>(() => board.AddColumn(column));
        }

        [Fact]
        public void AddExtraColumnInBoard_ExceprionWillReturn()
        {
            //Arrange
            IBoard board = new Board("Board title");
            for (int i = 1; i <= 10; i++)
            {
                board.AddColumn(new Column("Column title" + i));
            }
            //Act && Assert
            Assert.Throws<ColumnsLimitException>(
                () => board.AddColumn(new Column("Column max number is 10"))
            );
        }

        [Fact]
        public void EditColumnTitleInBoard_ColumnTitleWillChange()
        {
            //Arrange
            string newColumnTitle = "New column title";
            IColumn column = new Column("Column title");
            IBoard board = new Board("Board title");
            board.AddColumn(column);
            //Act
            board.EditColumnTitle(column.ID, newColumnTitle);
            //Assert
            Assert.Equal(newColumnTitle, column.Title);
        }

        [Fact]
        public void EditNotExistColumnTitleInBoard_ExceptionWillReturn()
        {
            //Arrange
            IBoard board = new Board("BoardTitle");
            //Act && Assert
            Assert.Throws<ColumnNotFoundException>(() => board.EditColumnTitle("", "New column title"));
        }

        [Fact]
        public void AddTaskOnBoardInColumn_NewTaskWillAdd()
        {
            //Arrange
            ITask task = new Task("Task", "Task description", TaskPriority.MEDIUM);
            IColumn column = new Column("Column title");
            IBoard board = new Board("Board title");
            board.AddColumn(column);
            //Act
            board.AddTask(task);
            //Assert
            Assert.Equal(task, column.GetAllTask()[0]);
        }

        [Fact]
        public void AddTaskOnBoardInSpecialColumn_NewTaskWillAdd()
        {
            //Arrange
            ITask task = new Task("Задача", "Описание задачи", TaskPriority.MEDIUM);
            IColumn column1 = new Column("Title column number 1");
            IColumn column2 = new Column("Title column number 2");
            IBoard board = new Board("Board title");
            board.AddColumn(column1);
            board.AddColumn(column2);
            //Act
            board.AddTask(task, 1);
            //Assert
            Assert.Equal(task, column2.GetAllTask()[0]);
        }

        [Fact]
        public void AddTaskInBoardInNotExistColumn_ExceptionWillReturn()
        {
            //Arrange
            ITask task = new Task("Task", "Task description", TaskPriority.MEDIUM);
            IBoard board = new Board("Board title");
            //Act && Assert
            Assert.Throws<ColumnNotFoundException>(() => board.AddTask(task, 5));
        }

        [Fact]
        public void GetTask_FromBoard_ReturnTask()
        {
            //Arrange
            ITask task = new Task("Task", "Task description", TaskPriority.MEDIUM);
            IColumn column = new Column("Column title");
            IBoard board = new Board("Board title");
            board.AddColumn(column);
            board.AddTask(task);
            //Act
            ITask retTask = board.GetTask(task.ID);
            //Assert
            Assert.Equal(task, retTask);
        }

        [Fact]
        public void GetNotExistTask_FromBoard_ReturnExeption()
        {
            //Arrange
            IBoard board = new Board("Board title");
            //Act && Assert
            Assert.Throws<TaskNotFoundException>(() => board.GetTask(""));
        }

        [Fact]
        public void GetColumn_FromBoard_ReturnColumn()
        {
            //Arrange
            IColumn column = new Column("Column title");
            IBoard board = new Board("Board title");
            board.AddColumn(column);
            //Act
            IColumn retColumn = board.GetColumn(column.ID);
            //Assert
            Assert.Equal(column, retColumn);
        }

        [Fact]
        public void GetNotExistColumn_FromBoard_ReturnExeption()
        {
            //Arrange
            IBoard board = new Board("Board title");
            //Act && Assert
            Assert.Throws<ColumnNotFoundException>(() => board.GetColumn(""));
        }

        [Fact]
        public void GetAllColumn_FromBoard_ReturnAllColumn()
        {
            //Arrange
            IColumn column1 = new Column("Column number 1 title");
            IColumn column2 = new Column("Column number 2 title");
            IColumn column3 = new Column("Column number 3 title");
            IBoard board = new Board("Board title");
            board.AddColumn(column1);
            board.AddColumn(column2);
            board.AddColumn(column3);
            //Act
            List<IColumn> columnList = board.GetAllColumn();
            //Assert
            Assert.Equal(new List<IColumn>() { column1, column2, column3 }, columnList);
        }

        [Fact]
        public void EditTask_OnBoard_TaskWillChange()
        {
            //Arrange
            string newTaskName = "New task";
            string newTaskDescription = "New task description";
            ITask task = new Task("Task", "Task description", TaskPriority.MEDIUM);
            IColumn column = new Column("Column title");
            IBoard board = new Board("Board title");
            column.AddTask(task);
            board.AddColumn(column);
            //Act
            board.EditTask(task.ID, newTaskName, newTaskDescription, TaskPriority.HARD);
            //Assert
            ITask retTask = board.GetTask(task.ID);
            Assert.Equal(newTaskName, retTask.Title);
            Assert.Equal(newTaskDescription, retTask.Description);
            Assert.Equal(TaskPriority.HARD, retTask.Priority);
        }

        [Fact]
        public void EditNotExistTask_OnBoard_ReturnExeption()
        {
            //Arrange
            IBoard board = new Board("Board title");
            //Act && Assert
            Assert.Throws<TaskNotFoundException>(() => board.EditTask("", "", "", TaskPriority.HARD));
        }

        [Fact]
        public void DeleteTask_OnBoard_TaskWillDelete()
        {
            //Arrange
            ITask task = new Task("Task", "Task description", TaskPriority.MEDIUM);
            IColumn column = new Column("Column title");
            IBoard board = new Board("Board title");
            column.AddTask(task);
            board.AddColumn(column);
            //Act
            board.DeleteTask(task.ID);
            //Assert
            Assert.Throws<TaskNotFoundException>(() => board.GetTask(task.ID));
        }

        [Fact]
        public void DeleteNotExistTask_OnBoard_ReturnExeption()
        {
            //Arrange
            IBoard board = new Board("Board title");
            //Act && Assert
            Assert.Throws<TaskNotFoundException>(() => board.DeleteTask(""));
        }

        [Fact]
        public void DeleteColumn_OnBoard_ColumnWillDelete()
        {
            //Arrange
            IColumn column = new Column("Column title");
            IBoard board = new Board("Board title");
            board.AddColumn(column);
            //Act
            board.DeleteColumn(column.ID);
            //Assert
            Assert.Throws<ColumnNotFoundException>(() => board.GetColumn(column.ID));
        }

        [Fact]
        public void DeleteNotExistColumn_OnBoard_ReturnExeption()
        {
            //Arrange
            IBoard board = new Board("Board title");
            //Act && Assert
            Assert.Throws<ColumnNotFoundException>(() => board.DeleteColumn(""));
        }

        [Fact]
        public void TaskTransfer_OnBoard_ColumnWillDelete()
        {
            //Arrange
            ITask task = new Task("Task", "Task description", TaskPriority.MEDIUM);
            IColumn column1 = new Column("Column title number 1");
            IColumn column2 = new Column("Column title number 2");
            IBoard board = new Board("Board title");
            board.AddColumn(column1);
            board.AddColumn(column2);
            board.AddTask(task);
            //Act
            board.MoveTask(column2.ID, task.ID);
            //Assert
            Assert.Empty(board.GetColumn(column1.ID).GetAllTask());
            Assert.Equal(task, board.GetColumn(column2.ID).GetTask(task.ID));
        }
    }
}