//using System;
//using System.Threading.Tasks;
//using Dotnet.Onion.Template.Application.ViewModels;
//using Dotnet.Onion.Template.Domain;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Logging;


//namespace Dotnet.Onion.Template.API.Controllers
//{

//    [Produces("application/json")]
//    [ApiVersion("1.0")]
//    [Route("api/v{version:apiVersion}/[controller]")]
//    public class TasksController : MainController
//    {
//        private readonly ITaskService _taskService;
//        private readonly ILogger<TasksController> _logger;

//        public TasksController(INotifier notifier, ITaskService taskService, ILogger<TasksController> logger) : base(notifier)
//        {
//            _taskService = taskService;
//            _logger = logger;
//        }


//        /// <summary>
//        /// Get Tasks
//        /// </summary>
//        /// <returns>Returns a list of All Tasks</returns>
//        [HttpGet]
//        [ProducesResponseType(typeof(TaskViewModel), StatusCodes.Status200OK)]
//        public async Task<IActionResult> Get()
//        {
//            try
//            {
//                return Ok(await _taskService.GetAll());
//            }
//            catch (Exception ex)
//            {
//                _logger.LogError($"Error: message: {ex.Message} ");

//                return StatusCode(StatusCodes.Status500InternalServerError, new { exception_message = ex.Message });
//            }
//        }

//        /// <summary>
//        /// Get Task by ID
//        /// </summary>
//        /// <param name="id">Task's ID</param>
//        /// <returns>Returns a Task by its ID</returns>
//        [HttpGet("{id}", Name = "Get")]
//        [ProducesResponseType(typeof(TaskViewModel), StatusCodes.Status200OK)]
//        public async Task<IActionResult> Get(Guid id)
//        {
//            try
//            {
//                return Ok(await _taskService.GetById(id));
//            }
//            catch (Exception ex)
//            {
//                _logger.LogError($"Error: message: {ex.Message} ");

//                return StatusCode(StatusCodes.Status500InternalServerError, new { exception_message = ex.Message });
//            }
//        }

//        /// <summary>
//        /// Create a new Task
//        /// </summary>
//        /// <param name="taskViewModel"></param>
//        /// <returns></returns>
//        [HttpPost]
//        [ProducesResponseType(typeof(TaskViewModel), StatusCodes.Status200OK)]
//        public async Task<IActionResult> Post([FromBody] TaskViewModel taskViewModel)
//        {
//            try
//            {
//                return Ok(await _taskService.Create(taskViewModel));
//            }
//            catch (Exception ex)
//            {
//                _logger.LogError($"Error: message: {ex.Message} ");

//                return StatusCode(StatusCodes.Status500InternalServerError, new { exception_message = ex.Message });
//            }
//        }

//        /// <summary>
//        /// Delete a Task
//        /// </summary>
//        /// <param name="id">Task's ID</param>
//        /// <returns></returns>
//        [HttpDelete("{id}", Name = "Delete")]
//        [ProducesResponseType(StatusCodes.Status204NoContent)]
//        public async Task<IActionResult> Delete([FromRoute]Guid id)
//        {
//            try
//            {
//                await _taskService.Delete(id);
//                return StatusCode(StatusCodes.Status204NoContent);

//            }
//            catch (Exception ex)
//            {
//                _logger.LogError($"Error: message: {ex.Message} ");
//                return StatusCode(StatusCodes.Status500InternalServerError, new { exception_message = ex.Message });
//            }
//        }

       
//    }
//}
