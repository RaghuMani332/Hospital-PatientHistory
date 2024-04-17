using Dapper;
using Hospital_HospitalService.Context;
using Hospital_PatientHistory.DTO;
using Hospital_PatientHistory.Service.Interface;
using System.Net.Http;

namespace Hospital_PatientHistory.Service.Impl
{
    public class HistoryServiceImpl(IHttpClientFactory httpClientFactory, DapperContext context) : IHistoryService
    {
        public void AddHistory(String patientEmail, string Issue)
        {
            UserObject user = getUserByEmailId(patientEmail);
            Console.WriteLine(user.userID+" "+user.firstName);
            /*String PatientQuery= "INSERT INTO Patients (PatientId, PatientName) VALUES (@PatientId, @PatientName); ";               
           int i= context.getConnection().Execute(PatientQuery, new { PatientId =user.userID , PatientName =user.firstName});*/
            
            var query = @"INSERT INTO PatientHistory (PatientId, Issue)
                              VALUES (@PatientId, @Issue)";
           context.getConnection().Execute(query,new { PatientId =user.userID, Issue =Issue});
        }

        public object GetHistory(string patientEmail)
        {
            UserObject user = getUserByEmailId(patientEmail);
            String query = "select * from PatientHistory where PatientId = @PatientId";
            return context.getConnection().Query(query, new { patientId = user.userID });
        }

        public UserObject getUserByEmailId(String patentEmail)
        {
            var httpclient = httpClientFactory.CreateClient("userByEmail");
            var responce = httpclient.GetAsync($"getbyemail?email={patentEmail}").Result;
            if (responce.IsSuccessStatusCode)
            {
                return responce.Content.ReadFromJsonAsync<UserObject>().Result;
            }
            throw new Exception("UserNotFound Create User FIRST OE TRY DIFFERENT EMAIL ID");
        }
    }
}
