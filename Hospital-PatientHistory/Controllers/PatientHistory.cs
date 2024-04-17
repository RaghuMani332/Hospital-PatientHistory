using Hospital_PatientHistory.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_PatientHistory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles ="DOCTOR")]
    public class PatientHistory(IHistoryService service) : ControllerBase
    {
        [HttpPost]
        public String AddHistory(String PatentEmail,String Issue)
        {
            service.AddHistory(PatentEmail, Issue);
            return "User History Added";
            
        }
        [HttpGet]
        public object GetHistory(String PatientEmail) 
        {
            return service.GetHistory(PatientEmail);
        }
    }
}
