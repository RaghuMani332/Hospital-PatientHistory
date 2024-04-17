namespace Hospital_PatientHistory.Service.Interface
{
    public interface IHistoryService
    {
        void AddHistory(String patentEmail, string issue);
        object GetHistory(string patientEmail);
    }
}
