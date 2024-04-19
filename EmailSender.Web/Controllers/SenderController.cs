using EmailSender.DataAccess.DTOS;
using EmailSender.DataAccess.Repositories.IRepositories;
using EmailSender.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmailSender.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SenderController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public SenderController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("getSenders/{id?}")]
        public async Task<IActionResult> GetSenders(int? id)
        {
            SenderDTO dto = new SenderDTO();
            
            if(id == null)
            {
                dto.Senders = await _unitOfWork.senderRepo.GetAll();
                return Ok(dto);
            }
            else
            {
                dto.Senders = await _unitOfWork.senderRepo.GetAll();
                dto.TaskUnit = await _unitOfWork.tasksRepo.GetT(x=> x.Id == id);
                return Ok(dto);
            }
            

            
        }
    }
}
