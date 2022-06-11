using Microsoft.AspNetCore.Mvc;
using WebScrumBoard2.DTO;
using WebScrumBoard2.Models;

namespace WebScrumBoard2.Controllers
{
    [ApiController]
    [Route("scrumBoard")]
    public class ScrumBoardController : ControllerBase
    {
        private readonly IScrumBoardStorage _methods;

        public ScrumBoardController(IScrumBoardStorage methods)
        {
            _methods = methods;
        }

        [HttpPost("newBoard")] //POST. "scrumBoard/newBoard"
        public IActionResult CreateNewBoard([FromBody] CreateBoardDTO arg)
        {
            try
            {
                _methods.AddBoard(arg);
            }

            catch
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpPost("{boardID}/newColumn")] //POST. "scrumBoard/{boardID}/newColumn"
        public IActionResult CreateNewColumn(string boardID, [FromBody] CreateColumnDTO arg)
        {
            try
            {
                _methods.AddColumn(boardID, arg);
            }
            catch
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpPost("{boardID}/newTask")] //POST. "scrumBoard/{boardID}/newTask"
        public IActionResult CreateNewTask(string boardID, [FromBody] CreateTaskDTO arg)
        {
            try
            {
                _methods.AddTask(boardID, arg);
            }

            catch
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpGet("{boardID}")] //GET. "scrumBoard/{boardUID}"
        public IActionResult GetBoardByID(string boardID)
        {
            BoardDTO board;
            try
            {
                board = _methods.GetBoard(boardID);
            }

            catch
            {
                return NotFound();
            }

            return Ok(board);
        }

        [HttpDelete("{boardID}/deleteBoard")] //DELETE. "scrumBoard/{boardID}/deleteBoard"
        public IActionResult DeleteBoard(string boardID)
        {
            try
            {
                _methods.DeleteBoard(boardID);
            }
            catch
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpDelete("{boardID}/delete/{taskID}")] //DELETE. "scrumBoard/{boardID}/delete/{taskID}"
        public IActionResult DeleteTask(string boardID, string taskID)
        {
            try
            {
                _methods.DeleteTask(boardID, taskID);
            }

            catch
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpGet("allBoards")] //GET. "scrumBoard/allBoards"
        public IActionResult ShowAllBoards()
        {
            IEnumerable<BoardDTO> listBoards;

            try
            {
                listBoards = _methods.GetAllBoard();
            }

            catch
            {
                listBoards = Enumerable.Empty<BoardDTO>();
            }

            return Ok(listBoards);
        }

        [HttpPut("{boardID}/move/{taskID}")] //PUT. "scrumBoard/{boardID}/move/{taskID}"
        public IActionResult MoveTaskIntoColumn(string boardID, string taskID, [FromBody] MoveTaskDTO arg)
        {
            try
            {
                _methods.MoveTask(boardID, taskID, arg);
            }

            catch
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}