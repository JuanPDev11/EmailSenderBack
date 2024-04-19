using EmailSender.DataAccess.DTOS;
using EmailSender.DataAccess.Repositories.IRepositories;
using EmailSender.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmailSender.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public TasksController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("getTasks")]
        public async Task<IActionResult> GetTasks()
        {
            TasksDTO dto = new TasksDTO()
            {
                Tasks = await _unitOfWork.tasksRepo.GetAll(includeProperties:"Sender")
            };

            return Ok(dto.Tasks);
        }

        

        [HttpPost("postTask/{id?}")]
        public async Task<IActionResult> PostTask(int? id)
        {
            TasksDTO dto = new TasksDTO();

            if(id == null)
            {
                dto.TasksUnit = new Tasks
                {
                    Name = Request.Form["name"],
                    Periodicity = Request.Form["periodicity"],
                    Hour = TimeSpan.Parse(Request.Form["hour"]),
                    Addressee = Request.Form["addressee"],
                    SenderId = int.Parse(Request.Form["sender"])
                };
                await _unitOfWork.tasksRepo.Add(dto.TasksUnit);
                await _unitOfWork.Save();
                return Ok(new { message = "Task Addes Succesfully" });
            }
            else
            {
                var taskDB = await _unitOfWork.tasksRepo.GetT(x=>x.Id == id);
                if(taskDB != null) 
                {
                    dto.TasksUnit = new Tasks
                    {
                        Id = taskDB.Id,
                        Name = Request.Form["name"],
                        Periodicity = Request.Form["periodicity"],
                        Hour = TimeSpan.Parse(Request.Form["hour"]),
                        Addressee = Request.Form["addressee"],
                        SenderId = int.Parse(Request.Form["sender"])
                    };
                    await _unitOfWork.tasksRepo.Update(dto.TasksUnit);
                    await _unitOfWork.Save();
                }
                return Ok(new { message = "Task Updated Successfully" });
            }
        }
    }
}
