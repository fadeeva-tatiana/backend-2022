using Microsoft.AspNetCore.Mvc;
using WebScrumBoard.DTO;
using TasksDTO;

namespace WebScrumBoard.Controllers;

[Route("api/boards")]
[ApiController]
public class BoardsController : ControllerBase
{
    private readonly ScrumBoardRepositoryInterface _repository;

    public BoardsController(ScrumBoardRepositoryInterface repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public IActionResult GetListBoards()
    {
        IEnumerable<BoardDTO> boards;
        try
        {
            boards = _repository.Get_all_board();
        }
        catch
        {
            boards = Enumerable.Empty<BoardDTO>();
        }
        return Ok(boards);
    }

    [HttpGet("{boardGUID}")]
    public IActionResult Get_board_by_GUID(string boardGUID)
    {
        BoardDTO board;
        try
        {
            board = _repository.Get_board(boardGUID);
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

    [HttpDelete("{boardGUID}")]
    public IActionResult Remove_board(string boardGUID)
    {
        try
        {
            _repository.Remove_board(boardGUID);
        }
        catch
        {
            return BadRequest();
        }
        return Ok();
    }

    [HttpPost("{boardGUID}/column")]
    public IActionResult Create_column(string boardGUID, [FromBody] CreateColumnDTO param)
    {
        try
        {
            _repository.Add_column(boardGUID, param);
        }
        catch
        {
            return NotFound();
        }
        return Ok();
    }

    [HttpPut("{boardGUID}/column")]
    public IActionResult Edit_column(string boardGUID, [FromBody] EditColumnDTO param)
    {
        try
        {
            _repository.Edit_column(boardGUID, param);
        }
        catch
        {
            return BadRequest();
        }
        return Ok();
    }

    [HttpDelete("{boardGUID}/column/{columnGUID}")]
    public IActionResult Remove_column(string boardGUID, string columnGUID)
    {
        try
        {
            _repository.Remove_column(boardGUID, columnGUID);
        }
        catch
        {
            return BadRequest();
        }
        return Ok();
    }

    [HttpPut("{boardGUID}/task/{taskGUID}")]
    public IActionResult Move_task(string boardGUID, string taskGUID, [FromBody] MoveTaskDTO param)
    {
        try
        {
            _repository.Move_task(boardGUID, taskGUID, param);
        }
        catch
        {
            return BadRequest();
        }
        return Ok();
    }

    [HttpPost("{boardGUID}/task")]
    public IActionResult Create_task(string boardGUID, [FromBody] CreateTaskDTO param)
    {
        try
        {
            _repository.Add_task(boardGUID, param);
        }
        catch
        {
            return BadRequest();
        }
        return Ok();
    }

    [HttpPut("{boardGUID}/task")]
    public IActionResult Edit_task(string boardGUID, [FromBody] EditTaskDTO param)
    {
        try
        {
            _repository.Edit_task(boardGUID, param);
        }
        catch
        {
            return BadRequest();
        }
        return Ok();
    }

    [HttpDelete("{boardGUID}/task/{taskGUID}")]
    public IActionResult Remove_task(string boardGUID, string taskGUID)
    {
        try
        {
            _repository.Remove_task(boardGUID, taskGUID);
        }
        catch
        {
            return BadRequest();
        }
        return Ok();
    }
}