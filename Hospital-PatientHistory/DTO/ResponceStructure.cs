namespace Hospital_PatientHistory.DTO
{
    public class ResponceStructure<T>
    {
        public ResponceStructure(T data,String message,bool isSuccess) 
        {
            this.data = data;
            this.Message = message;
            this.isSuccess = isSuccess;
        }
       public T data;
       public String Message;
       public bool isSuccess;
    }
}
