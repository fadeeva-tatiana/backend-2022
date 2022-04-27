using Microsoft.AspNetCore.Mvc;
using WebScrumBoard.DTO;
using TasksDTO;
using WebScrumBoard.Models;

namespace WebScrumBoard.Controllers;

[Route("API/boards")]
[ApiController]
public class WebScrumBoardController : ControllerBase
{
    private readonly WebScrumBoardStorageInterface _repository;

    public WebScrumBoardController(WebScrumBoardStorageInterface repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public IActionResult GetListBoards()
    {
        IEnumerable<BoardDTO> boards;
        try
        {
            boards = _repository.GetAllBoard();
        }
        catch
        {
            boards = Enumerable.Empty<BoardDTO>();
        }
        return Ok(boards);
    }

    [HttpGet("{boardID}")]
    public IActionResult Get_board_by_ID(string boardID)
    {
        BoardDTO board;
        try
        {
            board = _repository.Get_board(boardID);
        }
        catch
        {
            return NotFound();
        }
        return Ok(board);
    }

    [HttpPost]
    public IActionResult Create_board([FromBody] CreateBoardDTO param)
    {
        try
        {
            _repository.Add_board(param);
        }
        catch
        {
            return BadRequest();
        }
        return Ok();
    }

    [HttpDelete("{boardID}")]
    public IActionResult Remove_board(string boardID)
    {
        try
        {
            _repository.Remove_board(boardID);
        }
        catch
        {
            return BadRequest();
        }
        return Ok();
    }

    [HttpPost("{boardID}/column")]
    public IActionResult Create_column(string boardID, [FromBody] CreateColumnDTO param)
    {
        try
        {
            _repository.Add_column(boardID, param);
        }
        catch
        {
            return NotFound();
        }
        return Ok();
    }

    [HttpPut("{boardID}/column")]
    public IActionResult Edit_column(string boardID, [FromBody] EditColumnDTO param)
    {
        try
        {
            _repository.Edit_column(boardID, param);
        }
        catch
        {
            return BadRequest();
        }
        return Ok();
    }

    [HttpPut("{boardID}/task/{taskID}")]
    public IActionResult Move_task(string boardID, string taskID, [FromBody] MoveTaskDTO param)
    {
        try
        {
            _repository.Move_task(boardID, taskID, param);
        }
        catch
        {
            return BadRequest();
        }
        return Ok();
    }

    [HttpPost("{boardID}/task")]
    public IActionResult Create_task(string boardID, [FromBody] CreateTaskDTO param)
    {
        try
        {
            _repository.Add_task(boardID, param);
        }
        catch
        {
            return BadRequest();
        }
        return Ok();
    }

    [HttpPut("{boardID}/task")]
    public IActionResult Edit_task(string boardID, [FromBody] EditTaskDTO param)
    {
        try
        {
            _repository.Edit_task(boardID, param);
        }
        catch
        {
            return BadRequest();
        }
        return Ok();
    }

    [HttpDelete("{boardID}/task/{taskID}")]
    public IActionResult Remove_task(string boardID, string taskID)
    {
        try
        {
            _repository.Remove_task(boardID, taskID);
        }
        catch
        {
            return BadRequest();
        }
        return Ok();
    }
}