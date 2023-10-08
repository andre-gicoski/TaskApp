using TaskApp.Models;
using TaskApp.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace TaskApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskkController : ControllerBase
    {
        private readonly ITaskkRepository _taskkRepository;
        
        public TaskkController(ITaskkRepository taskkRepository)
        {
            _taskkRepository = taskkRepository;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Taskk>>> GetAllTaskks()
        {
            List<Taskk> taskks = await _taskkRepository.GetAllTaskks();
            return Ok(taskks);
        }
        
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Taskk>> GetTaskkById(int id)
        {
            Taskk taskk = await _taskkRepository.GetTaskkById(id);

            if (taskk == null)
            {
                return NotFound();
            }

            return Ok(taskk);
        }

        [HttpPost]
        public async Task<ActionResult<Taskk>> AddTaskk ([FromBody] Taskk taskkModel)
        {
            Taskk taskk = await _taskkRepository.AddTaskk(taskkModel);

            return Ok(taskk);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Taskk>> UpdateTaskk([FromBody] Taskk taskkModel,int id)
        {
            taskkModel.Id = id;
            Taskk taskk = await _taskkRepository.UpdateTaskk(taskkModel,id);

            return Ok(taskk);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<bool>> DeleteTaskk(int id)
        {
            bool taskk = await _taskkRepository.DeleteTaskk(id);

            return Ok(taskk);
        }
    }
}